using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;
using UVector2=UnityEngine.Vector2;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Unauticna.MediaStudio
{
    [DisallowMultipleComponent]
    public sealed class MediaStudioHost:MonoBehaviour
    {
        static MediaStudioHost instance;
        public static bool IsOpen=>instance!=null&&instance.open;
        public string ffmpegPath="";
        public string Workspace{get;private set;}
        public bool open;
        MediaScreenRecorder recorder;Camera playerCamera;VideoPlayer video;AudioSource previewAudio;
        MediaProject project=new MediaProject();MediaTimelineEcs timeline=new MediaTimelineEcs();
        RasterCanvas picture=new RasterCanvas(1280,720),ink=new RasterCanvas(1280,720);
        readonly List<Texture2D> layerTextures=new List<Texture2D>();
        readonly Dictionary<MediaDrawing,Texture2D> drawings=new Dictionary<MediaDrawing,Texture2D>();
        readonly List<string> undo=new List<string>();
        Task job;CancellationTokenSource cancellation;readonly System.Collections.Concurrent.ConcurrentQueue<Action> main=new System.Collections.Concurrent.ConcurrentQueue<Action>();
        volatile string status="F9 — запись игры. F10 — открыть/закрыть студию.";
        int tab,clipIndex=-1,loadedClip=-1,tool;double playhead,requestedSource;bool playing,preparing,seeking,painting;
        string currentUrl,annotationSeconds="1",resizeW="1280",resizeH="720",projectFile;
        float brush=10,red=1,green=.2f,blue=.1f,alpha=1,brightness,contrast=1,silenceDb=-35,silenceSeconds=1;
        bool oneFrame=true,dirty=true;UVector2 scroll,lastPoint,cropStart,cropEnd;CursorLockMode oldLock;bool oldVisible;
        bool Busy=>job!=null;RasterCanvas Canvas=>tab==0?ink:picture;
        public static MediaStudioHost Ensure(Camera camera=null)
        {
            if(instance==null)new GameObject("Unauticna Media Studio").AddComponent<MediaStudioHost>();
            if(camera!=null)instance.playerCamera=camera;return instance;
        }
        public static bool PlayerUpdate(GameObject playerCamera)
        {
#if ENABLE_INPUT_SYSTEM
            bool record=Keyboard.current!=null&&Keyboard.current.f9Key.wasPressedThisFrame;
            bool edit=Keyboard.current!=null&&Keyboard.current.f10Key.wasPressedThisFrame;
#else
            bool record=Input.GetKeyDown(KeyCode.F9),edit=Input.GetKeyDown(KeyCode.F10);
#endif
            if(record||edit){var host=Ensure(playerCamera!=null?playerCamera.GetComponent<Camera>():null);if(record)host.ToggleRecording();if(edit)host.SetOpen(!host.open);}
            return IsOpen;
        }
        public static void OpenEditor(GameObject camera){Ensure(camera!=null?camera.GetComponent<Camera>():null).SetOpen(true);}
        public static void TogglePlayerRecording(GameObject camera){Ensure(camera!=null?camera.GetComponent<Camera>():null).ToggleRecording();}
        public static void CloseEditor(){if(instance!=null)instance.SetOpen(false);}
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]static void ResetStatic(){instance=null;}
        void Awake()
        {
            if(instance!=null&&instance!=this){Destroy(gameObject);return;}instance=this;DontDestroyOnLoad(gameObject);
            Workspace=Path.Combine(Application.persistentDataPath,"MediaStudio");Directory.CreateDirectory(Workspace);
            ffmpegPath=Path.Combine(FindToolsDirectory(),"ffmpeg.exe");
            if(!File.Exists(ffmpegPath)||!File.Exists(ProbePath))status="Положи ffmpeg.exe и ffprobe.exe в "+Path.GetDirectoryName(ffmpegPath);
            recorder=gameObject.AddComponent<MediaScreenRecorder>();
            video=gameObject.AddComponent<VideoPlayer>();video.playOnAwake=false;video.renderMode=VideoRenderMode.APIOnly;video.source=VideoSource.Url;video.audioOutputMode=VideoAudioOutputMode.AudioSource;
            video.timeUpdateMode=VideoTimeUpdateMode.UnscaledGameTime;video.controlledAudioTrackCount=1;
            previewAudio=gameObject.AddComponent<AudioSource>();previewAudio.playOnAwake=false;previewAudio.spatialBlend=0;previewAudio.ignoreListenerPause=true;
            video.SetTargetAudioSource(0,previewAudio);video.EnableAudioTrack(0,true);
            video.prepareCompleted+=Prepared;video.seekCompleted+=p=>{seeking=false;};video.errorReceived+=(p,e)=>{preparing=false;seeking=false;playing=false;status=e;};
            video.sendFrameReadyEvents=true;video.frameReady+=(p,f)=>{seeking=false;if(!playing)p.Pause();};timeline.Rebuild(project);
        }
        internal static string FindToolsDirectory()
        {
            // Editor: <project>/Assets. Windows player: <build>/<game>_Data.
            // Do not depend on the launcher's current working directory.
            string root=Path.GetDirectoryName(Path.GetFullPath(Application.dataPath));
            string tools=Path.Combine(root,"res","cmd");
#if !UNITY_EDITOR
            // Launcher layout: <game>/Application/Game.exe, <game>/res/cmd/.
            if(!File.Exists(Path.Combine(tools,"ffmpeg.exe")))
            {
                var parent=Directory.GetParent(root);
                if(parent!=null)
                {
                    string outer=Path.Combine(parent.FullName,"res","cmd");
                    if(File.Exists(Path.Combine(outer,"ffmpeg.exe"))&&File.Exists(Path.Combine(outer,"ffprobe.exe")))return outer;
                }
            }
#endif
            return tools;
        }
        string ProbePath=>Path.GetDirectoryName(ffmpegPath)==""?"ffprobe":Path.Combine(Path.GetDirectoryName(ffmpegPath),"ffprobe.exe");
        void SetOpen(bool value)
        {
            if(open==value)return;open=value;
            if(open){oldLock=Cursor.lockState;oldVisible=Cursor.visible;Cursor.lockState=CursorLockMode.None;Cursor.visible=true;}
            else{playing=false;video.Pause();Cursor.lockState=oldLock;Cursor.visible=oldVisible;painting=false;}
        }
        public void ToggleRecording()
        {
            if(recorder.Active){recorder.Stop();status="Завершается запись…";return;}
            try{string path=Path.Combine(Workspace,"recording-"+DateTime.Now.ToString("yyyyMMdd-HHmmss-fff")+".mp4");recorder.Begin(ffmpegPath,path,playerCamera);status="Запись игры: F9 — остановить.";}
            catch(Exception e){status=e.Message;Debug.LogException(e,this);}
        }
        void Update()
        {
            if(job!=null&&job.IsCompleted)
            {
                bool failed=false;
                try{job.GetAwaiter().GetResult();}catch(OperationCanceledException){failed=true;status="Операция отменена.";}catch(Exception e){failed=true;status=e.Message;Debug.LogException(e,this);}
                job=null;cancellation.Dispose();cancellation=null;
                if(failed)while(main.TryDequeue(out _)){}
            }
            if(job==null)while(main.TryDequeue(out var action)){try{action();}catch(Exception e){status=e.Message;Debug.LogException(e,this);}if(job!=null)break;}
            if(open){Cursor.lockState=CursorLockMode.None;Cursor.visible=true;}
            if(playing&&!preparing&&!seeking&&!Busy)
            {playhead+=Time.unscaledDeltaTime;if(playhead>=project.Duration){playhead=project.Duration;playing=false;video.Pause();}SetTime(playhead,false);}
            if(open&&dirty&&!Busy)RefreshTextures();
        }
        void Work(Func<CancellationToken,Task> work)
        {
            if(Busy)return;playing=false;video.Pause();cancellation=new CancellationTokenSource();var token=cancellation.Token;job=Task.Run(()=>work(token));
        }
        void Remember(){undo.Add(JsonUtility.ToJson(project));if(undo.Count>16)undo.RemoveAt(0);}
        void Changed(){project.Validate();timeline.Rebuild(project);playhead=Math.Min(playhead,project.Duration);loadedClip=-1;SetTime(playhead,true);}
        void SetTime(double value,bool force)
        {
            playhead=Math.Max(0,Math.Min(project.Duration,value));clipIndex=timeline.Locate(playhead,out requestedSource);
            if(clipIndex<0){video.Stop();currentUrl=null;preparing=false;seeking=false;loadedClip=-1;return;}var c=project.clips[clipIndex];requestedSource=Math.Min(c.end-.00001,requestedSource);
            string url=new Uri(Path.GetFullPath(c.path)).AbsoluteUri;
            if(currentUrl!=url){currentUrl=url;video.Stop();video.url=url;preparing=true;seeking=false;loadedClip=clipIndex;video.Prepare();return;}
            if(preparing)return;
            if(force||loadedClip!=clipIndex){loadedClip=clipIndex;seeking=true;video.time=requestedSource;video.Play();}
            if(video.canSetPlaybackSpeed)video.playbackSpeed=(float)c.speed;
            if(playing&&!video.isPlaying)video.Play();
        }
        void Prepared(VideoPlayer p)
        {
            preparing=false;if(clipIndex<0)return;
            if(p.audioTrackCount>0){p.EnableAudioTrack(0,true);p.SetTargetAudioSource(0,previewAudio);}
            if(p.canSetPlaybackSpeed)p.playbackSpeed=(float)project.clips[clipIndex].speed;
            seeking=true;p.time=requestedSource;p.Play();
        }
        void ImportVideo()
        {
            string path=MediaFileDialog.Choose(false,"Импорт видео","Видео|*.mp4;*.mov;*.mkv;*.avi;*.webm|Все файлы|*.*",null,Workspace);if(path==null)return;
            string probe=ProbePath;Remember();Work(async token=>{var info=await MediaFFmpeg.Probe(probe,path,token);main.Enqueue(()=>{double at=project.Duration;project.clips.Add(new MediaClip{path=path,end=info.duration,audio=info.audio});Changed();SetTime(at,true);status="Импортировано: "+Path.GetFileName(path);});});
        }
        void AutoSilence()
        {
            if(project.clips.Count==0)return;Remember();var snapshot=JsonUtility.FromJson<MediaProject>(JsonUtility.ToJson(project));string exe=ffmpegPath;double threshold=silenceDb,minimum=silenceSeconds;
            Work(async token=>{
                var cache=new Dictionary<string,List<TimeSpanRange>>();var clips=new List<MediaClip>();
                foreach(var c in snapshot.clips){token.ThrowIfCancellationRequested();status="Анализ тишины: "+Path.GetFileName(c.path);if(!cache.TryGetValue(c.path,out var spans)){var whole=c.Copy(0,snapshot.clips.FindAll(x=>x.path==c.path).ConvertAll(x=>x.end).Max(),1);spans=await MediaFFmpeg.Silence(exe,whole,threshold,minimum,token);cache[c.path]=spans;}clips.AddRange(MediaProject.SpeedSilence(c,spans));}
                snapshot.clips=clips;snapshot.Validate();main.Enqueue(()=>{project=snapshot;Changed();status="Тихие участки ускорены в 6 раз. Можно отменить.";});
            });
        }
        void SaveVideoProject()
        {
            string path=MediaFileDialog.Choose(true,"Сохранить монтаж","Монтаж JSON|*.uvideo.json|JSON|*.json","uvideo.json",Workspace);if(path==null)return;
            string json=JsonUtility.ToJson(project,true);Work(async token=>{await Task.Run(()=>AtomicText(path,json),token);main.Enqueue(()=>{projectFile=path;status="Монтаж сохранён.";});});
        }
        void LoadVideoProject()
        {
            string path=MediaFileDialog.Choose(false,"Загрузить монтаж","Монтаж JSON|*.uvideo.json;*.json",null,Workspace);if(path==null)return;
            Work(async token=>{string json=await Task.Run(()=>File.ReadAllText(path),token);main.Enqueue(()=>{var loaded=JsonUtility.FromJson<MediaProject>(json);loaded.Validate();foreach(var c in loaded.clips)if(!File.Exists(c.path))throw new FileNotFoundException("Нет исходного видео",c.path);Remember();project=loaded;projectFile=path;ink=new RasterCanvas(project.width,project.height);dirty=true;ClearDrawingTextures();Changed();status="Монтаж загружен.";});});
        }
        void ExportVideo()
        {
            string path=MediaFileDialog.Choose(true,"Экспорт MP4","Видео MP4|*.mp4","mp4",Workspace);if(path==null)return;
            var snapshot=JsonUtility.FromJson<MediaProject>(JsonUtility.ToJson(project));string exe=ffmpegPath;
            Work(async token=>{await MediaFFmpeg.Export(exe,snapshot,path,s=>status=s,token);status="Готово: "+path;});
        }
        static void AtomicText(string path,string text){string temp=path+"."+Guid.NewGuid().ToString("N")+".tmp";try{File.WriteAllText(temp,text);MediaFFmpeg.Commit(temp,path);}finally{if(File.Exists(temp))File.Delete(temp);}}
        static byte[] Pixels(Texture2D t){var c=t.GetPixels32();var p=new byte[c.Length*4];for(int i=0;i<c.Length;i++){p[i*4]=c[i].r;p[i*4+1]=c[i].g;p[i*4+2]=c[i].b;p[i*4+3]=c[i].a;}return p;}
        static Texture2D Texture(byte[] pixels,int w,int h){var t=new Texture2D(w,h,TextureFormat.RGBA32,false);t.LoadRawTextureData(pixels);t.Apply();return t;}
        static byte[] Png(byte[] pixels,int w,int h){var t=Texture(pixels,w,h);try{return t.EncodeToPNG();}finally{Destroy(t);}}
        void AddDrawing()
        {
            if(clipIndex<0)return;playing=false;video.Pause();Remember();var c=project.clips[clipIndex];double a=requestedSource;
            double duration=oneFrame?c.speed/project.fps:Parse(annotationSeconds,1);string png=Convert.ToBase64String(Png(ink.Composite(),ink.Width,ink.Height));
            project.drawings.Add(new MediaDrawing{source=c.path,start=a,end=Math.Min(c.end,a+Math.Max(1.0/project.fps,duration)),png=png});
            ink=new RasterCanvas(project.width,project.height);dirty=true;status="Рисунок закреплён за исходными кадрами.";
        }
        void ImportImage()
        {
            string path=MediaFileDialog.Choose(false,"Открыть изображение","Изображения|*.png;*.jpg;*.jpeg",null,Workspace);if(path==null)return;
            Work(async token=>{var bytes=await Task.Run(()=>File.ReadAllBytes(path),token);main.Enqueue(()=>{var t=new Texture2D(2,2);try{if(!t.LoadImage(bytes))throw new IOException("Изображение не прочитано.");var c=new RasterCanvas(t.width,t.height);c.Layers[0].pixels=Pixels(t);picture=c;dirty=true;resizeW=t.width.ToString();resizeH=t.height.ToString();status="Изображение открыто.";}finally{Destroy(t);}});});
        }
        void ExportImage()
        {
            string path=MediaFileDialog.Choose(true,"Сохранить изображение","PNG|*.png|JPEG|*.jpg","png",Workspace);if(path==null)return;
            var canvas=picture;bool jpeg=Path.GetExtension(path).Equals(".jpg",StringComparison.OrdinalIgnoreCase)||Path.GetExtension(path).Equals(".jpeg",StringComparison.OrdinalIgnoreCase);
            Work(async token=>{var pixels=await Task.Run(()=>canvas.Composite(),token);if(jpeg)for(int i=0;i<pixels.Length;i+=4){float a=pixels[i+3]/255f;for(int j=0;j<3;j++)pixels[i+j]=(byte)(pixels[i+j]*a+255*(1-a));pixels[i+3]=255;}
                main.Enqueue(()=>{var t=Texture(pixels,canvas.Width,canvas.Height);byte[] bytes;try{bytes=jpeg?t.EncodeToJPG(92):t.EncodeToPNG();}finally{Destroy(t);}main.Enqueue(()=>SaveBytes(path,bytes));});});
        }
        void SaveBytes(string path,byte[] bytes){Work(async token=>{await Task.Run(()=>{string temp=path+".tmp-"+Guid.NewGuid().ToString("N");try{File.WriteAllBytes(temp,bytes);MediaFFmpeg.Commit(temp,path);}finally{if(File.Exists(temp))File.Delete(temp);}},token);status="Сохранено: "+path;});}
        [Serializable]sealed class ImageSave{public int version=1,width,height,selected;public List<LayerSave> layers=new List<LayerSave>();}
        [Serializable]sealed class LayerSave{public string name,png;public bool visible;}
        void SaveImageProject()
        {
            string path=MediaFileDialog.Choose(true,"Сохранить слои","Слои JSON|*.uimage.json","uimage.json",Workspace);if(path==null)return;
            var data=new ImageSave{width=picture.Width,height=picture.Height,selected=picture.Selected};foreach(var l in picture.Layers)data.layers.Add(new LayerSave{name=l.name,visible=l.visible,png=Convert.ToBase64String(Png(l.pixels,picture.Width,picture.Height))});string json=JsonUtility.ToJson(data);
            Work(token=>Task.Run(()=>{AtomicText(path,json);status="Слои сохранены.";},token));
        }
        void LoadImageProject()
        {
            string path=MediaFileDialog.Choose(false,"Загрузить слои","Слои JSON|*.uimage.json;*.json",null,Workspace);if(path==null)return;
            Work(async token=>{var json=await Task.Run(()=>File.ReadAllText(path),token);main.Enqueue(()=>{var data=JsonUtility.FromJson<ImageSave>(json);if(data==null||data.version!=1||data.layers==null||data.layers.Count<1||data.layers.Count>8)throw new IOException("Неверный проект изображения.");var c=new RasterCanvas(data.width,data.height);c.Layers.Clear();foreach(var l in data.layers){var t=new Texture2D(2,2);try{if(!t.LoadImage(Convert.FromBase64String(l.png))||t.width!=c.Width||t.height!=c.Height)throw new IOException("Размер слоя не совпадает.");c.Layers.Add(new RasterLayer(l.name,0){pixels=Pixels(t),visible=l.visible});}finally{Destroy(t);}}c.Selected=Mathf.Clamp(data.selected,0,c.Layers.Count-1);picture=c;dirty=true;});});
        }
        void RasterWork(Action action){Canvas.Checkpoint();Work(token=>Task.Run(()=>{action();main.Enqueue(()=>dirty=true);},token));}
        static double Parse(string s,double fallback)=>double.TryParse(s.Replace(',','.'),System.Globalization.NumberStyles.Float,System.Globalization.CultureInfo.InvariantCulture,out var v)&&MediaProject.Finite(v)?v:fallback;
        void RefreshTextures()
        {
            if(layerTextures.Count!=Canvas.Layers.Count||layerTextures.Count>0&&(layerTextures[0].width!=Canvas.Width||layerTextures[0].height!=Canvas.Height))
            {foreach(var t in layerTextures)Destroy(t);layerTextures.Clear();foreach(var l in Canvas.Layers)layerTextures.Add(Texture(l.pixels,Canvas.Width,Canvas.Height));}
            else for(int i=0;i<layerTextures.Count;i++){layerTextures[i].LoadRawTextureData(Canvas.Layers[i].pixels);layerTextures[i].Apply();}
            dirty=false;
        }
        void ClearDrawingTextures(){foreach(var t in drawings.Values)Destroy(t);drawings.Clear();}
        void OnDestroy(){if(instance!=this)return;instance=null;SetOpen(false);cancellation?.Cancel();timeline.Dispose();foreach(var t in layerTextures)Destroy(t);ClearDrawingTextures();}
        void OnGUI()
        {
            if(!open){if(recorder!=null&&recorder.Active)GUI.Label(new Rect(12,12,380,28),"● REC  F9 — остановить");return;}
            GUI.Window(197510,new Rect(8,8,Mathf.Max(640,Screen.width-16),Mathf.Max(480,Screen.height-16)),DrawWindow,"Unauticna Media Studio — F10 закрыть");
        }
        void DrawWindow(int id)
        {
            float width=Mathf.Max(640,Screen.width-16),height=Mathf.Max(480,Screen.height-16);
            GUI.enabled=!Busy;
            int next=GUI.Toolbar(new Rect(12,28,300,30),tab,new[]{"Видео","Изображение"});
            if(next!=tab){tab=next;tool=0;dirty=true;playing=false;video.Pause();painting=false;}
            GUI.enabled=true;if(GUI.Button(new Rect(width-100,28,88,30),"Закрыть"))SetOpen(false);
            if(Busy&&GUI.Button(new Rect(width-220,28,112,30),"Отменить"))cancellation.Cancel();
            GUILayout.BeginArea(new Rect(12,66,300,height-116));scroll=GUILayout.BeginScrollView(scroll);
            GUI.enabled=!Busy;
            try{if(tab==0)VideoControls();else ImageControls();BrushControls();}
            catch(Exception e){status=e.Message;Debug.LogException(e,this);}
            GUI.enabled=true;GUILayout.EndScrollView();GUILayout.EndArea();
            Rect viewArea=new Rect(324,66,width-336,height-202);GUI.Box(viewArea,"");
            float aspect=tab==0?(float)project.width/project.height:(float)picture.Width/picture.Height;
            Rect display=Fit(viewArea,aspect);var oldColor=GUI.color;GUI.color=new Color(.17f,.17f,.19f,1);GUI.DrawTexture(display,Texture2D.whiteTexture);GUI.color=oldColor;
            if(tab==0&&video.texture!=null)GUI.DrawTexture(display,video.texture,ScaleMode.ScaleToFit,false);
            if(tab==0&&clipIndex>=0)
            {
                var c=project.clips[clipIndex];foreach(var d in project.drawings)
                {
                    if(d.source!=c.path||requestedSource<d.start||requestedSource>=d.end)continue;
                    if(!drawings.TryGetValue(d,out var t)){if(drawings.Count>=8)ClearDrawingTextures();t=new Texture2D(2,2);if(t.LoadImage(Convert.FromBase64String(d.png)))drawings[d]=t;else{Destroy(t);continue;}}
                    GUI.DrawTexture(display,t,ScaleMode.StretchToFill,true);
                }
            }
            for(int i=0;i<layerTextures.Count&&i<Canvas.Layers.Count;i++)if(Canvas.Layers[i].visible)GUI.DrawTexture(display,layerTextures[i],ScaleMode.StretchToFill,true);
            if(painting&&tool==2){Rect crop=DragRect(display,cropStart,cropEnd);GUI.Box(crop,"Обрезка");}
            HandlePaint(display);
            if(tab==0)DrawTimeline(new Rect(324,height-128,width-336,76));
            GUI.Label(new Rect(12,height-46,width-24,38),status);
        }
        void VideoControls()
        {
            if(GUILayout.Button("Импортировать видео"))ImportVideo();
            GUILayout.BeginHorizontal();if(GUILayout.Button("Загрузить монтаж"))LoadVideoProject();if(GUILayout.Button("Сохранить"))SaveVideoProject();GUILayout.EndHorizontal();
            if(GUILayout.Button("Экспорт MP4"))ExportVideo();
            GUILayout.BeginHorizontal();if(GUILayout.Button(playing?"Пауза":"▶ Играть")){playing=!playing;if(playing){if(playhead>=project.Duration)SetTime(0,true);else SetTime(playhead,true);}else video.Pause();}
            if(GUILayout.Button("◀ кадр")){playing=false;SetTime(playhead-1.0/project.fps,true);}if(GUILayout.Button("кадр ▶")){playing=false;SetTime(playhead+1.0/project.fps,true);}GUILayout.EndHorizontal();
            GUILayout.Label("Клипов: "+project.clips.Count+"   Рисунков: "+project.drawings.Count);
            if(clipIndex>=0&&clipIndex<project.clips.Count)
            {
                var c=project.clips[clipIndex];GUILayout.Label("Клип "+(clipIndex+1)+": "+Path.GetFileName(c.path));GUILayout.Label(MediaFFmpeg.Number(c.start)+" — "+MediaFFmpeg.Number(c.end)+" сек, ×"+c.speed);
                GUILayout.BeginHorizontal();if(GUILayout.Button("Начало здесь")&&requestedSource<c.end-.02){Remember();c.start=requestedSource;Changed();}
                if(GUILayout.Button("Конец здесь")&&requestedSource>c.start+.02){Remember();c.end=requestedSource;Changed();}GUILayout.EndHorizontal();
                if(GUILayout.Button("Разрезать в этом кадре")){Remember();project.Split(clipIndex,requestedSource);Changed();}
                if(GUILayout.Button("Удалить выбранный клип")){Remember();project.clips.RemoveAt(clipIndex);Changed();}
                GUILayout.BeginHorizontal();if(GUILayout.Button("← Раньше")&&clipIndex>0){Remember();int i=clipIndex;var temp=project.clips[i-1];project.clips[i-1]=c;project.clips[i]=temp;Changed();SetTime(project.Offset(i-1),true);}
                if(GUILayout.Button("Позже →")&&clipIndex<project.clips.Count-1){Remember();int i=clipIndex;var temp=project.clips[i+1];project.clips[i+1]=c;project.clips[i]=temp;Changed();SetTime(project.Offset(i+1),true);}GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();if(GUILayout.Button("Скорость ×1")){Remember();c.speed=1;Changed();}if(GUILayout.Button("×6")){Remember();c.speed=6;Changed();}GUILayout.EndHorizontal();
            }
            if(GUILayout.Button("Отменить монтаж")&&undo.Count>0){project=JsonUtility.FromJson<MediaProject>(undo[undo.Count-1]);undo.RemoveAt(undo.Count-1);ClearDrawingTextures();Changed();}
            GUILayout.Space(8);GUILayout.Label("Тишина ниже "+silenceDb.ToString("F0")+" dB");silenceDb=GUILayout.HorizontalSlider(silenceDb,-65,-15);
            GUILayout.Label("Дольше "+silenceSeconds.ToString("F1")+" сек");silenceSeconds=GUILayout.HorizontalSlider(silenceSeconds,.2f,8);
            if(GUILayout.Button("Автоматически: вся тишина ×6"))AutoSilence();
            oneFrame=GUILayout.Toggle(oneFrame,"Рисунок на один итоговый кадр");if(!oneFrame){GUILayout.Label("Длительность рисунка (сек исходника)");annotationSeconds=GUILayout.TextField(annotationSeconds);}
            if(GUILayout.Button("Закрепить рисунок на видео"))AddDrawing();
            if(GUILayout.Button("Убрать последний рисунок")&&project.drawings.Count>0){Remember();project.drawings.RemoveAt(project.drawings.Count-1);ClearDrawingTextures();}
            GUILayout.Space(10);if(GUILayout.Button(recorder.Active?"Остановить запись F9":"Записать игру F9"))ToggleRecording();
            if(!string.IsNullOrEmpty(recorder.LastFile)&&GUILayout.Button("Добавить последнюю запись"))
            {string path=recorder.LastFile,probe=ProbePath;Remember();Work(async token=>{var info=await MediaFFmpeg.Probe(probe,path,token);main.Enqueue(()=>{project.clips.Add(new MediaClip{path=path,end=info.duration,audio=info.audio});Changed();});});}
            if(!string.IsNullOrEmpty(recorder.Error))GUILayout.Label(recorder.Error);
            recorder.flipVertical=GUILayout.Toggle(recorder.flipVertical,"Перевернуть кадр записи по вертикали");
            GUILayout.Label("FFmpeg: "+ffmpegPath);
            if(GUILayout.Button("Выбрать ffmpeg.exe")){string p=MediaFileDialog.Choose(false,"Выбрать ffmpeg.exe","FFmpeg|ffmpeg.exe|EXE|*.exe",null,FindToolsDirectory());if(p!=null)ffmpegPath=p;}
        }
        void ImageControls()
        {
            if(GUILayout.Button("Открыть PNG / JPEG"))ImportImage();
            GUILayout.BeginHorizontal();if(GUILayout.Button("Загрузить слои"))LoadImageProject();if(GUILayout.Button("Сохранить слои"))SaveImageProject();GUILayout.EndHorizontal();
            if(GUILayout.Button("Сохранить PNG / JPEG"))ExportImage();
            GUILayout.Label("Размер: "+picture.Width+" × "+picture.Height);
            GUILayout.BeginHorizontal();resizeW=GUILayout.TextField(resizeW);resizeH=GUILayout.TextField(resizeH);GUILayout.EndHorizontal();
            if(GUILayout.Button("Изменить размер")){int w=(int)Parse(resizeW,picture.Width),h=(int)Parse(resizeH,picture.Height);RasterWork(()=>picture.Resize(w,h));}
            if(GUILayout.Button("Новый прозрачный холст")){picture=new RasterCanvas((int)Parse(resizeW,1280),(int)Parse(resizeH,720));dirty=true;}
            GUILayout.BeginHorizontal();if(GUILayout.Button("Поворот 90°"))RasterWork(()=>picture.Rotate());if(GUILayout.Button("Зеркало"))RasterWork(()=>picture.Flip());GUILayout.EndHorizontal();
            GUILayout.Label("Яркость "+brightness.ToString("F2"));brightness=GUILayout.HorizontalSlider(brightness,-1,1);
            GUILayout.Label("Контраст "+contrast.ToString("F2"));contrast=GUILayout.HorizontalSlider(contrast,0,3);
            if(GUILayout.Button("Применить к слою")){float b=brightness,c=contrast;RasterWork(()=>picture.Adjust(b,c));}
        }
        void BrushControls()
        {
            GUILayout.Space(8);GUILayout.Label("Рисование мышью");tool=GUILayout.Toolbar(tool,tab==0?new[]{"Кисть","Ластик"}:new[]{"Кисть","Ластик","Обрезка"});
            GUILayout.Label("Кисть: "+brush.ToString("F0")+" px");brush=GUILayout.HorizontalSlider(brush,1,100);
            GUILayout.Label("Красный / зелёный / синий / прозрачность");red=GUILayout.HorizontalSlider(red,0,1);green=GUILayout.HorizontalSlider(green,0,1);blue=GUILayout.HorizontalSlider(blue,0,1);alpha=GUILayout.HorizontalSlider(alpha,0,1);
            if(GUILayout.Button("Отменить рисунок")){Canvas.Undo();dirty=true;}
            GUILayout.BeginHorizontal();if(GUILayout.Button("+ Слой")){Canvas.Checkpoint();Canvas.AddLayer();dirty=true;}if(GUILayout.Button("− Слой")){Canvas.Checkpoint();Canvas.DeleteLayer();dirty=true;}GUILayout.EndHorizontal();
            for(int i=Canvas.Layers.Count-1;i>=0;i--){GUILayout.BeginHorizontal();Canvas.Layers[i].visible=GUILayout.Toggle(Canvas.Layers[i].visible,"");if(GUILayout.Button((Canvas.Selected==i?"● ":"")+Canvas.Layers[i].name))Canvas.Selected=i;GUILayout.EndHorizontal();}
        }
        void DrawTimeline(Rect rect)
        {
            GUI.Label(new Rect(rect.x,rect.y,rect.width,22),playhead.ToString("F2")+" / "+project.Duration.ToString("F2")+" сек");
            GUI.enabled=!Busy;float before=(float)playhead;float value=GUI.HorizontalSlider(new Rect(rect.x,rect.y+25,rect.width,20),before,0,(float)Math.Max(.01,project.Duration));
            if(value!=before){playing=false;SetTime(value,true);}GUI.enabled=true;
            double offset=0;var saved=GUI.color;foreach(var c in project.clips){float x=rect.x+(float)(offset/Math.Max(.01,project.Duration))*rect.width,w=(float)(c.Duration/Math.Max(.01,project.Duration))*rect.width;GUI.color=c.speed==6?new Color(.8f,.5f,.2f):new Color(.2f,.55f,.8f);if(w>=1)GUI.DrawTexture(new Rect(x,rect.y+48,w,20),Texture2D.whiteTexture);offset+=c.Duration;}GUI.color=saved;
            var e=Event.current;Rect strip=new Rect(rect.x,rect.y+48,rect.width,20);if(!Busy&&e.type==EventType.MouseDown&&strip.Contains(e.mousePosition)){playing=false;SetTime((e.mousePosition.x-strip.x)/strip.width*project.Duration,true);e.Use();}
        }
        static Rect Fit(Rect area,float aspect){float w=area.width,h=w/aspect;if(h>area.height){h=area.height;w=h*aspect;}return new Rect(area.x+(area.width-w)/2,area.y+(area.height-h)/2,w,h);}
        static Rect DragRect(Rect display,UVector2 a,UVector2 b)=>new Rect(display.x+Mathf.Min(a.x,b.x)*display.width,display.y+(1-Mathf.Max(a.y,b.y))*display.height,Mathf.Abs(a.x-b.x)*display.width,Mathf.Abs(a.y-b.y)*display.height);
        void HandlePaint(Rect display)
        {
            if(Busy)return;var e=Event.current;UVector2 p=new UVector2(Mathf.Clamp01((e.mousePosition.x-display.x)/display.width),1-Mathf.Clamp01((e.mousePosition.y-display.y)/display.height));
            if(e.type==EventType.MouseDown&&e.button==0&&display.Contains(e.mousePosition))
            {playing=false;video.Pause();painting=true;Canvas.Checkpoint();lastPoint=p;cropStart=p;cropEnd=p;if(tool<2)Paint(p,p);e.Use();}
            else if(painting&&e.type==EventType.MouseDrag){cropEnd=p;if(tool<2)Paint(lastPoint,p);lastPoint=p;e.Use();}
            else if(painting&&e.type==EventType.MouseUp){painting=false;if(tool==2&&tab==1){int x=(int)(Mathf.Min(cropStart.x,p.x)*picture.Width),y=(int)(Mathf.Min(cropStart.y,p.y)*picture.Height),w=(int)(Mathf.Abs(cropStart.x-p.x)*picture.Width),h=(int)(Mathf.Abs(cropStart.y-p.y)*picture.Height);if(w>0&&h>0){Work(token=>Task.Run(()=>{picture.Crop(x,y,w,h);main.Enqueue(()=>dirty=true);},token));}}e.Use();}
        }
        void Paint(UVector2 a,UVector2 b){Canvas.Stroke(a.x*(Canvas.Width-1),a.y*(Canvas.Height-1),b.x*(Canvas.Width-1),b.y*(Canvas.Height-1),brush,(byte)(red*255),(byte)(green*255),(byte)(blue*255),(byte)(alpha*255),tool==1);dirty=true;}
    }
}
