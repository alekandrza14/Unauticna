using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
namespace Unauticna.MediaStudio
{
    [DisallowMultipleComponent]
    public sealed class MediaScreenRecorder:MonoBehaviour
    {
        public int fps=30,maximumWidth=1280,maximumHeight=720;
        public bool flipVertical=true;
        public MediaCaptureWriter Writer{get;private set;}
        public bool Active=>Writer!=null&&!Writer.Completion.IsCompleted;
        public string LastFile{get;private set;}
        public string Error{get;private set;}
        RenderTexture screen,capture;bool pending,running;MediaAudioTap tap;float nextAudioSearch;
        public void Begin(string exe,string path,Camera camera)
        {
            if(Writer!=null||pending||screen!=null)throw new InvalidOperationException("Подожди завершения предыдущей записи.");
            if(!SystemInfo.supportsAsyncGPUReadback)throw new NotSupportedException("GPU не поддерживает AsyncGPUReadback.");
            fps=Mathf.Clamp(fps,1,60);
            int sw=Screen.width,sh=Screen.height;float scale=Mathf.Min(1f,Mathf.Min((float)maximumWidth/sw,(float)maximumHeight/sh));int w=Mathf.Max(2,((int)(sw*scale)/2)*2),h=Mathf.Max(2,((int)(sh*scale)/2)*2);
            screen=new RenderTexture(sw,sh,0,RenderTextureFormat.ARGB32);capture=new RenderTexture(w,h,0,RenderTextureFormat.ARGB32);screen.Create();capture.Create();
            Writer=new MediaCaptureWriter(exe,path,w,h,Mathf.Clamp(fps,1,60),AudioSettings.outputSampleRate,flipVertical);
            LastFile=null;Error=null;running=true;BindAudio(camera);StartCoroutine(CaptureFrames(sw,sh));
        }
        void BindAudio(Camera camera)
        {
            var listener=camera!=null?camera.GetComponent<AudioListener>():null;
            if(listener==null||!listener.enabled)listener=UnityEngine.Object.FindFirstObjectByType<AudioListener>();
            if(listener==null)return;tap=listener.GetComponent<MediaAudioTap>();if(tap==null)tap=listener.gameObject.AddComponent<MediaAudioTap>();tap.Sink=Writer;
        }
        IEnumerator CaptureFrames(int sw,int sh)
        {
            var wait=new WaitForEndOfFrame();float next=0;
            while(running&&Active&&!Writer.Stopping)
            {
                yield return wait;
                if(!running||!Active||Writer.Stopping)break;
                if(Screen.width!=sw||Screen.height!=sh){Error="Размер окна изменился: запись завершена.";Stop();break;}
                if(pending||Time.realtimeSinceStartup<next)continue;
                next=Time.realtimeSinceStartup+1f/fps;
                if(!Writer.FreeFrames.TryDequeue(out var bytes))continue;
                var owner=Writer;pending=true;
                try
                {
                    ScreenCapture.CaptureScreenshotIntoRenderTexture(screen);Graphics.Blit(screen,capture);
                    AsyncGPUReadback.Request(capture,0,TextureFormat.RGBA32,r=>{
                        pending=false;
                        try
                        {
                            if(r.hasError)throw new InvalidOperationException("Ошибка чтения кадра GPU.");
                            if(owner.Stopping){owner.FreeFrames.Enqueue(bytes);return;}
                            r.GetData<byte>().CopyTo(bytes);owner.Frames.Enqueue(bytes);
                        }
                        catch(Exception e){owner.FreeFrames.Enqueue(bytes);Error=e.Message;owner.Stop();}
                    });
                }
                catch(Exception e){pending=false;owner.FreeFrames.Enqueue(bytes);Error=e.Message;Stop();}
            }
        }
        public void Stop(){running=false;Writer?.Stop();if(tap!=null)tap.Sink=null;}
        void Update()
        {
            if(Active&&tap==null&&Time.realtimeSinceStartup>nextAudioSearch){nextAudioSearch=Time.realtimeSinceStartup+1;BindAudio(null);}
            if(Writer!=null&&Writer.Completion.IsCompleted)
            {
                try{LastFile=Writer.Completion.GetAwaiter().GetResult();if(Writer.AudioBlocks==0)Error="Видео записано без звука: активный AudioListener не передал аудио.";}
                catch(Exception e){Error=e.Message;Debug.LogException(e,this);}
                Writer=null;running=false;if(tap!=null)tap.Sink=null;
            }
            if(!Active&&!pending&&screen!=null){screen.Release();capture.Release();Destroy(screen);Destroy(capture);screen=null;capture=null;}
        }
        void OnDestroy(){Stop();Writer?.Abort();if(pending)AsyncGPUReadback.WaitAllRequests();if(screen!=null){screen.Release();Destroy(screen);}if(capture!=null){capture.Release();Destroy(capture);}}
        void OnApplicationQuit(){Stop();Writer?.Abort();}
    }
}
