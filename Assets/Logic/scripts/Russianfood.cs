using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

// Put this on the player or a scene manager, NOT inside RussianFood.prefab.
[DefaultExecutionOrder(200)]
[DisallowMultipleComponent]
public sealed class Russianfood : MonoBehaviour
{
    public StaticEcsNeeds needs;
    public mover playerMover;
    public Rigidbody playerBody;
    public Camera videoCamera;
    public string prefabPath = "RussianFood";
    public bool fullscreen = true;
    [Tooltip("Other scripts handling look, interaction or player input.")]
    public Behaviour[] additionalControls;
    [Min(1f)] public float prepareTimeout = 30f;
    [Min(1f)] public float stallTimeout = 30f;

    public bool IsPlaying { get; private set; }
    private static Russianfood active;
    private GameObject instance;
    private VideoPlayer video;
    private bool failedAtZero, controlsLocked, oldPaused;
    private bool bodySaved;
    private RigidbodyConstraints oldConstraints;
    private float deadline, lastProgressTime;
    private long lastFrame = -1;
    private bool started;
    private readonly List<Behaviour> disabledControls = new List<Behaviour>();

    private void Start()
    {
        if (needs == null) needs = GetComponent<StaticEcsNeeds>();
        if (needs == null) needs = FindFirstObjectByType<StaticEcsNeeds>();
        if (playerMover == null) playerMover = GetComponent<mover>();
        if (playerMover == null) playerMover = FindFirstObjectByType<mover>();
        if (playerBody == null && playerMover != null)
            playerBody = playerMover.GetComponent<Rigidbody>();
        if (videoCamera == null) videoCamera = Camera.main;
        if (needs == null || playerMover == null)
        {
            Debug.LogError("Russianfood: assign Needs and Player Mover.", this);
            enabled = false;
        }
    }

    private void Update()
    {
        if (IsPlaying)
        {
            if (instance == null || video == null || !video.isActiveAndEnabled)
            {
                Fail("The video object was removed or disabled.");
                return;
            }
            if (!started && Time.unscaledTime > deadline)
                Fail("Video preparation timed out.");
            else if (started)
            {
                if (video.frame != lastFrame)
                {
                    lastFrame = video.frame;
                    lastProgressTime = Time.unscaledTime;
                }
                else if (Time.unscaledTime - lastProgressTime > stallTimeout)
                    Fail("Video playback stopped progressing.");
            }
            return;
        }
        if (needs == null || !needs.isActiveAndEnabled) return;
        if (needs.GetValues().Food > 0f)
        {
            failedAtZero = false;
            return;
        }
        if (!failedAtZero && active == null && !needs.paused && !Globalprefs.Pause)
            BeginMovie();
    }

    private void BeginMovie()
    {
        active = this;
        IsPlaying = true;
        started = false;
        lastFrame = -1;
        try
        {
            var prefab = Resources.Load<GameObject>(prefabPath);
            if (prefab == null)
                throw new InvalidOperationException("Missing Resources/" + prefabPath + ".prefab");
            instance = Instantiate(prefab);
            instance.SetActive(true);
            video = instance.GetComponentInChildren<VideoPlayer>(true);
            if (video == null)
                throw new InvalidOperationException("RussianFood.prefab needs a VideoPlayer.");
            if (!video.gameObject.activeInHierarchy)
                throw new InvalidOperationException("The VideoPlayer object must be active in the prefab.");
            video.enabled = true;
            video.Stop();
            video.playOnAwake = false;
            video.isLooping = false;
            video.playbackSpeed = 1f;
            if (video.source == VideoSource.VideoClip && video.clip == null)
                throw new InvalidOperationException("Assign the movie to VideoPlayer > Video Clip.");
            if (video.source == VideoSource.Url && string.IsNullOrWhiteSpace(video.url))
                throw new InvalidOperationException("VideoPlayer URL is empty.");
            if (fullscreen)
            {
                if (videoCamera == null)
                    throw new InvalidOperationException("Assign Video Camera.");
                video.renderMode = VideoRenderMode.CameraNearPlane;
                video.targetCamera = videoCamera;
                video.targetCameraAlpha = 1f;
                video.aspectRatio = VideoAspectRatio.FitInside;
            }
            LockControls();
            video.prepareCompleted += Prepared;
            video.loopPointReached += Finished;
            video.errorReceived += VideoError;
            deadline = Time.unscaledTime + Mathf.Max(1f, prepareTimeout);
            video.Prepare();
        }
        catch (Exception ex) { Fail(ex.Message); }
    }

    private void LockControls()
    {
        oldPaused = needs.paused;
        controlsLocked = true;
        needs.paused = true;
        DisableControl(playerMover);
        if (additionalControls != null)
            foreach (var control in additionalControls) DisableControl(control);
        if (playerBody != null)
        {
            oldConstraints = playerBody.constraints;
            bodySaved = true;
            if (!playerBody.isKinematic)
            {
                playerBody.linearVelocity = Vector3.zero;
                playerBody.angularVelocity = Vector3.zero;
            }
            playerBody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void DisableControl(Behaviour control)
    {
        if (control == null || control == this || control == needs || control == video
            || control is Camera || control is AudioListener || !control.enabled) return;
        disabledControls.Add(control);
        control.enabled = false;
    }

    private void Prepared(VideoPlayer source)
    {
        if (!IsPlaying || source != video) return;
        started = true;
        lastProgressTime = Time.unscaledTime;
        source.Play();
    }

    private void Finished(VideoPlayer source)
    {
        if (!IsPlaying || source != video) return;
        try
        {
            if (needs != null && needs.isActiveAndEnabled)
            {
                var values = needs.GetValues();
                values.Food = 100f;
                needs.SetValues(values);
            }
        }
        finally { Cleanup(); }
    }

    private void VideoError(VideoPlayer source, string message) { Fail(message); }

    private void Fail(string message)
    {
        failedAtZero = true; // Avoid an endless instantiate/error loop at Food == 0.
        Debug.LogError("Russianfood: " + message, this);
        Cleanup();
    }

    [ContextMenu("Retry after video error")]
    public void Retry() { failedAtZero = false; }

    private void OnDisable() { Cleanup(); }
    private void OnDestroy() { Cleanup(); }

    private void Cleanup()
    {
        if (video != null)
        {
            video.prepareCompleted -= Prepared;
            video.loopPointReached -= Finished;
            video.errorReceived -= VideoError;
            video.Stop();
        }
        if (instance != null) Destroy(instance);
        instance = null;
        video = null;
        if (controlsLocked)
        {
            if (bodySaved && playerBody != null) playerBody.constraints = oldConstraints;
            if (needs != null) needs.paused = oldPaused;
            foreach (var control in disabledControls)
                if (control != null) control.enabled = true;
        }
        disabledControls.Clear();
        controlsLocked = false;
        bodySaved = false;
        IsPlaying = false;
        if (active == this) active = null;
    }
}
