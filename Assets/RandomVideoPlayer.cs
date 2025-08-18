using UnityEngine;
using UnityEngine.Video;

public class RandomVideoPlayer : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip[] clip;
    void Start()
    {
        InvokeRepeating("RePlay",0,13);
    }

    private void RePlay()
    {
        player.clip = clip[Random.Range(0, clip.Length)];
        player.Play();
    }
}
