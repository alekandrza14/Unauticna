using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class CustomGimnLoad : MonoBehaviour
{
    private string musicDir = Path.GetFullPath("res/Audio/gimn")+"\\";
    public InputField ifd;
    public AudioSource source;
    private void Start()
    {
        Run();
    }
    public void EditGimn()
    {
        VarSave.SetString("CustomGimn", ifd.text);
        Run();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async public void Run()
    {
        if (VarSave.GetString("CustomGimn") != "") ifd.text = VarSave.GetString("CustomGimn");
        // build your absolute path
        var path = musicDir + ifd.text;
        Debug.Log(path);
        // wait for the LoadObjects and set your property
        AudioClip CurrentClip = await LoadClip(path);
        source.clip = CurrentClip;
        source.Play();

        //... do something with it
    }
    async Task<AudioClip> LoadClip(string path)
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
