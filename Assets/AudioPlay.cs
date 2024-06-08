using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AudioPlay : MonoBehaviour
{
    private string musicDir = "C:/data/musick.wav";
    public InputField ifd;
    AudioSource source;

    private void Start()
    {
        if (VarSave.GetFloat(
            "Creative" + "_gameSettings", SaveType.global) >= .1f)
        {
            VarSave.LoadFloat("reason", 1);
        }
        Global.PauseManager.Pause();
        ifd.text = musicDir;
    }

    async public void Run()
    {
        // build your absolute path
        FindFirstObjectByType<SaveMelody>().gameObject.AddComponent<DELETE>();
        var path = ifd.text;
        source = Instantiate(Resources.Load<GameObject>("audios/Nill"),transform.position,Quaternion.identity).GetComponent<AudioSource>();
        // wait for the LoadObjects and set your property
      AudioClip  CurrentClip = await LoadClip(path);
        source.clip = CurrentClip;
        source.Play();

        VarSave.SetString("MusickPatch", ifd.text);
        Global.PauseManager.Play();
        Destroy(gameObject);
        //... do something with it
    }

    async Task<AudioClip> LoadClip(string path)
    {
        AudioClip clip = null;
        if (path[path.Length-1] == 'v')   using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV))
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
        if (path[path.Length-1] == '3') using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG))
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
        if (path[path.Length-1] == 'g') using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.OGGVORBIS))
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
}
