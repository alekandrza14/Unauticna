using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.AdaptivePerformance;
using UnityEngine.AI;
using UnityEngine.Analytics;
using UnityEngine.Android;
using UnityEngine.Animations;
using UnityEngine.Apple;
using UnityEngine.Assertions;
using UnityEngine.Audio;
using UnityEngine.Categorization;
using UnityEngine.CrashReportHandler;
using UnityEngine.DedicatedServer;
using UnityEngine.Device;//Class1
using UnityEngine.Diagnostics;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Experimental;
using UnityEngine.Experimental.AI;
using UnityEngine.Experimental.Animations;
using UnityEngine.Experimental.AssetBundlePatching;
using UnityEngine.Experimental.Audio;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Playables;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Video;
using UnityEngine.Internal;//Class1
using UnityEngine.Jobs;//Class1
using UnityEngine.LowLevelPhysics;
using UnityEngine.LowLevel;
using UnityEngine.Lumin;
using UnityEngine.Networking;
using UnityEngine.ParticleSystemJobs;//Class1
using UnityEngine.Playables;
using UnityEngine.PlayerLoop;
using UnityEngine.Polybrush;//Class1
//using UnityEngine.Pool; Class1
using UnityEngine.ProBuilder;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.Search;
using UnityEngine.SearchService;//dead
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;
using UnityEngine.Sprites;
using UnityEngine.Subsystems;
using UnityEngine.SubsystemsImplementation;
using UnityEngine.TerrainTools;
using UnityEngine.TerrainUtils;
using UnityEngine.TestTools;
using UnityEngine.TextCore;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using UnityEngine.Video;
using UnityEngine.Windows;
using UnityEngine.XR;
using System.Threading.Tasks;
using System;

public class DnSpyFunctionalEasyActivator : MonoBehaviour
{
    public float para;
    public int chara;
    public static object ancent;
    Texture2D sas8 = null;
    void Start()
    {
        para = AccessibilitySettings.fontScale;
        AdaptiveLut sas = new AdaptiveLut();
        chara = NavMesh.pathfindingIterationsPerFrame;
        ancent = Gender.Male;
        ancent = AndroidGameMode.Performance;
        ancent = CustomStreamPropertyType.Bool;
        ancent = FrameCaptureDestination.DevTools;
        Assert.IsNull(sas);
        ancent = AudioMixerUpdateMode.UnscaledTime;
        ancent = new CategoryInfoAttribute();
        ancent = CrashReportHandler.logBufferSize;
        ancent = Arguments.LogPath;
        ancent = PlayerConnection.connected;
        ancent = PersistentListenerMode.EventDefined;
        ancent = EventHandle.Used;
        ancent = NavMeshPolyTypes.Ground;
        ancent = AnimationStreamSource.DefaultValues;
        AssetBundleUtility.PatchAssetBundles(new AssetBundle[0], new string[0]);
        ancent = AudioSampleProvider.consumeSampleFramesNativeFunction;
        ancent = AngularFalloffType.LUT;
        ancent = TexturePlayableBinding.Create("ttt", gameObject);
        ancent = DefaultFormat.Video;
        ancent = VideoPlayerExtensions.GetAudioSampleProvider(new VideoPlayer(),ushort.MaxValue);
        ancent = GeometryType.Invalid;
        PlayerLoop sas2 = null;
        ancent = sas2;
        UsesLuminPlatformLevelAttribute sas3 = null;
        ancent = sas3;
        ancent = DownloadedTextureFlags.LinearColorSpace;
        ancent = DataStreamType.Texture;
        PreUpdate.UpdateVideo sas4 = new PreUpdate.UpdateVideo();
        ancent = sas4;
        ancent = MeshSyncState.NeedsRebuild;
        ancent = Profiler.supported;
        ObjectPool<script> sas5 = null;
        ancent = sas5;
        SceneManager.LoadScene(0);
        PreserveAttribute sas6 = null;
        ancent = sas6;
        ancent = SearchViewFlags.OpenInspectorPreview;
        FormerlySerializedAsAttribute sas7 = null;
        ancent = sas7;
        ancent = TimeScope.Today;
        DataUtility.GetPadding(Sprite.Create(sas8,new UnityEngine.Rect(0,0,0,0), new UnityEngine.Vector2(0,0)));
        ExampleSubsystem sas9 = null;
        ancent = sas9;
        SubsystemProvider sas10 = null;
        ancent = sas10;
        ancent = TerrainBuiltinPaintMaterialPasses.RaiseLowerHeight;
        TerrainMap sas11 = null;
        ancent = sas11;
        ExcludeFromCoverageAttribute sas12 = null;
        ancent = sas12;
        Glyph sas13 = null;
        ancent = sas13;
        Tile sas14 = null;
        ancent = sas14;
        SpriteAtlas sas15 = null;
        ancent = sas15;
        Text sas16 = null;
        ancent = sas16;
        ancent = Align.Auto;
        ancent = VFXCameraBufferTypes.Color;
        ancent = CrashReporting.crashReportFolder;
        ancent = GameViewRenderMode.LeftEye;

    }
    public static string path = "";
    public static async void GetAudioClipFromFreeFoleder(string path1, AudioClip clip)
    {
        // build your absolute path
        path = path1;
         // wait for the LoadObjects and set your property
         AudioClip CurrentClip = await LoadClip(path);
        clip = CurrentClip;

        //... do something with it
    }
    static async Task<AudioClip> LoadClip(string path)
    {
        AudioClip clip = null;
        if (path[path.Length - 1] == 'v') using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV))
            {
                uwr.SendWebRequest();

                // wrap tasks in try/catch, otherwise it'll fail silently
                try
                {
                    while (!uwr.isDone) await Task.Delay(5);

                    if (uwr.isNetworkError || uwr.isHttpError) Debug.Log($"{uwr.error}");
                    else
                    {
                        clip = DownloadHandlerAudioClip.GetContent(uwr);
                    }
                }
                catch (Exception err)
                {
                    Debug.Log($"{err.Message}, {err.StackTrace}");
                }
            }
        if (path[path.Length - 1] == '3') using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG))
            {
                uwr.SendWebRequest();

                // wrap tasks in try/catch, otherwise it'll fail silently
                try
                {
                    while (!uwr.isDone) await Task.Delay(5);

                    if (uwr.isNetworkError || uwr.isHttpError) Debug.Log($"{uwr.error}");
                    else
                    {
                        clip = DownloadHandlerAudioClip.GetContent(uwr);
                    }
                }
                catch (Exception err)
                {
                    Debug.Log($"{err.Message}, {err.StackTrace}");
                }
            }
        if (path[path.Length - 1] == 'g') using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.OGGVORBIS))
            {
                uwr.SendWebRequest();

                // wrap tasks in try/catch, otherwise it'll fail silently
                try
                {
                    while (!uwr.isDone) await Task.Delay(5);

                    if (uwr.isNetworkError || uwr.isHttpError) Debug.Log($"{uwr.error}");
                    else
                    {
                        clip = DownloadHandlerAudioClip.GetContent(uwr);
                    }
                }
                catch (Exception err)
                {
                    Debug.Log($"{err.Message}, {err.StackTrace}");
                }
            }

        return clip;
    }
    public static System.Collections.IEnumerator GetTextResFolder(string pichure, Texture texture)
    {
        Debug.Log(System.IO.Path.GetDirectoryName(UnityEngine.Application.dataPath) + @"\res\" + pichure);
        Debug.Log(System.IO.Path.GetDirectoryName(@"res\" + pichure));
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(UnityEngine.Application.dataPath)) + @"\res\" + pichure))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);   
            }
            else
            {
                // Get downloaded asset bundle
                texture = DownloadHandlerTexture.GetContent(uwr);
                //   Texture t = Globalprefs.txt;

                //   im.sprite = Sprite.Create((Texture2D)t, new Rect(0, 0, Globalprefs.txt.width, Globalprefs.txt.height), Vector2.zero);
                
                Debug.Log("1");
                //  im.enabled = true;
                //   anim.Play("panel");

            }
        }
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(System.IO.Path.GetDirectoryName(UnityEngine.Application.dataPath) + @"\res\" + pichure))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                texture = DownloadHandlerTexture.GetContent(uwr);
                //   Texture t = Globalprefs.txt;

                //   im.sprite = Sprite.Create((Texture2D)t, new Rect(0, 0, Globalprefs.txt.width, Globalprefs.txt.height), Vector2.zero);
                
                Debug.Log("1");
                //  im.enabled = true;
                //   anim.Play("panel");

            }
        }
    }
}

