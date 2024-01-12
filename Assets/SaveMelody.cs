using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class SaveMelody : MonoBehaviour
{
    AudioSource source;
    async void Start()
    {
        // build your absolute path
        if (File.Exists(VarSave.GetString("MusickPatch")))
        {
            var path = VarSave.GetString("MusickPatch");
            source = GetComponent<AudioSource>();
            // wait for the load and set your property
            AudioClip CurrentClip = await LoadClip(path);
            source.clip = CurrentClip;
            source.time = VarSave.GetFloat("Musick");


            if (VarSave.GetBool("isplaying")) source.Play();
        }
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
    int u;
    private void Update()
    {
        if (source != null)
        {


            if (source.time > 0)
            {
                VarSave.SetFloat("Musick", source.time);

                VarSave.SetBool("isplaying", source.isPlaying);
            }
            if (!source.isPlaying)
            {
                u++;
                if (u > 60)
                {
                    VarSave.SetBool("isplaying", source.isPlaying);
                }
            }
        }
    }

}
