using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Unauticna.MediaStudio
{
    // Owns only plain buffers, files and processes. Never touches Unity objects.
    public sealed class MediaCaptureWriter
    {
        public readonly Stopwatch Clock=new Stopwatch();
        public readonly ConcurrentQueue<byte[]> FreeFrames=new ConcurrentQueue<byte[]>();
        public readonly ConcurrentQueue<byte[]> Frames=new ConcurrentQueue<byte[]>();
        public readonly Task<string> Completion;
        public volatile bool Stopping;
        public double StopTime;
        public int AudioBlocks;
        public int RepeatedFrames;
        readonly int width,height,fps,sampleRate;
        readonly string exe,destination,folder;
        readonly CancellationTokenSource cancel=new CancellationTokenSource();
        readonly ConcurrentQueue<AudioBlock> audio=new ConcurrentQueue<AudioBlock>();
        readonly ConcurrentQueue<float[]> freeAudio=new ConcurrentQueue<float[]>();
        struct AudioBlock{public float[] data;public int frames;public double time;}
        public MediaCaptureWriter(string exe,string path,int w,int h,int fps,int sampleRate,bool flip)
        {
            this.exe=exe;destination=path;width=w;height=h;this.fps=fps;this.sampleRate=sampleRate;
            folder=Path.Combine(Path.GetDirectoryName(path),"capture-"+Guid.NewGuid().ToString("N"));Directory.CreateDirectory(folder);
            for(int i=0;i<4;i++)FreeFrames.Enqueue(new byte[w*h*4]);
            for(int i=0;i<64;i++)freeAudio.Enqueue(new float[16384]);
            Completion=Task.Run(()=>Record(flip));
        }
        public void PushAudio(float[] data,int channels)
        {
            if(Stopping||!Clock.IsRunning||channels<1)return;
            int count=data.Length/channels;
            if(count*2>16384||!freeAudio.TryDequeue(out var buffer))return;
            for(int i=0;i<count;i++){buffer[i*2]=data[i*channels];buffer[i*2+1]=data[i*channels+Math.Min(1,channels-1)];}
            audio.Enqueue(new AudioBlock{data=buffer,frames=count,time=Math.Max(0,Clock.Elapsed.TotalSeconds-(double)count/sampleRate)});
            Interlocked.Increment(ref AudioBlocks);
        }
        public void Stop(){if(Stopping)return;StopTime=Clock.Elapsed.TotalSeconds;Stopping=true;}
        public void Abort(){Stop();cancel.Cancel();}
        async Task<string> Record(bool flip)
        {
            string video=Path.Combine(folder,"video.mkv"),wav=Path.Combine(folder,"audio.wav");byte[] last=null;
            try
            {
                while(!Frames.TryDequeue(out last)){cancel.Token.ThrowIfCancellationRequested();if(Stopping)throw new OperationCanceledException("Запись остановлена до первого кадра.");await Task.Delay(10);}
                using(var process=MediaFFmpeg.Start(exe,new[]{"-hide_banner","-loglevel","error","-y","-f","rawvideo","-pixel_format","rgba","-video_size",width+"x"+height,"-framerate",fps.ToString(),"-i","pipe:0","-an","-vf",flip?"vflip,format=yuv420p":"format=yuv420p","-c:v","libx264","-preset","ultrafast","-crf","21","-threads","2",video},true))
                using(cancel.Token.Register(()=>{try{process.Kill();}catch{}}))
                using(var sound=new FileStream(wav,FileMode.Create,FileAccess.ReadWrite,FileShare.Read))
                {
                    sound.Write(new byte[44],0,44);long audioFrames=0;byte[] pcm=new byte[32768];int frames=0;Clock.Start();
                    var err=process.StandardError.ReadToEndAsync();var stdout=process.StandardOutput.ReadToEndAsync();
                    while(true)
                    {
                        cancel.Token.ThrowIfCancellationRequested();double elapsed=Stopping?StopTime:Clock.Elapsed.TotalSeconds;
                        int needed=Math.Max(1,(int)Math.Ceiling(elapsed*fps));
                        if(Stopping&&frames>=needed)break;
                        if(!Stopping&&frames>elapsed*fps){DrainAudio(sound,pcm,ref audioFrames);await Task.Delay(2);continue;}
                        bool changed=false;while(Frames.TryDequeue(out var fresh)){FreeFrames.Enqueue(last);last=fresh;changed=true;}
                        if(!changed&&frames>0)RepeatedFrames++;
                        process.StandardInput.BaseStream.Write(last,0,last.Length);frames++;
                        DrainAudio(sound,pcm,ref audioFrames);
                    }
                    process.StandardInput.Close();
                    if(!process.WaitForExit(30000)){process.Kill();throw new IOException("Кодировщик не завершил запись за 30 секунд.");}
                    string error=await err;await stdout;
                    if(process.ExitCode!=0)throw new IOException("Ошибка записи FFmpeg: "+error);
                    DrainAudio(sound,pcm,ref audioFrames);
                    long target=(long)Math.Round((double)frames/fps*sampleRate);
                    sound.SetLength(44+target*4);WriteWaveHeader(sound,target);
                }
                string result=Path.Combine(folder,"finished.mp4");
                await MediaFFmpeg.Run(exe,new[]{"-hide_banner","-loglevel","error","-nostdin","-y","-i",video,"-i",wav,"-map","0:v:0","-map","1:a:0","-c:v","copy","-c:a","aac","-b:a","192k","-shortest","-movflags","+faststart",result},cancel.Token);
                MediaFFmpeg.Commit(result,destination);try{Directory.Delete(folder,true);}catch{}return destination;
            }
            finally{Stopping=true;Clock.Stop();if(last!=null)FreeFrames.Enqueue(last);}
        }
        void DrainAudio(FileStream stream,byte[] pcm,ref long written)
        {
            while(audio.TryDequeue(out var block))
            {
                long expected=(long)(block.time*sampleRate);
                // Large callback gaps become silence, without compressing the audio timeline.
                if(expected-written>sampleRate/10){stream.Position=44+expected*4;written=expected;}
                for(int i=0;i<block.frames*2;i++){float v=block.data[i];short s=float.IsNaN(v)?(short)0:(short)(Math.Max(-1,Math.Min(1,v))*32767);pcm[i*2]=(byte)s;pcm[i*2+1]=(byte)(s>>8);}
                stream.Write(pcm,0,block.frames*4);written+=block.frames;freeAudio.Enqueue(block.data);
            }
        }
        void WriteWaveHeader(FileStream stream,long frames)
        {
            long size=frames*4;if(size>uint.MaxValue-36)throw new IOException("Запись превысила размер WAV 4 ГБ: используй более короткие записи.");
            stream.Position=0;using(var b=new BinaryWriter(stream,System.Text.Encoding.ASCII,true))
            {b.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));b.Write((uint)size+36);b.Write(System.Text.Encoding.ASCII.GetBytes("WAVEfmt "));b.Write(16);b.Write((short)1);b.Write((short)2);b.Write(sampleRate);b.Write(sampleRate*4);b.Write((short)4);b.Write((short)16);b.Write(System.Text.Encoding.ASCII.GetBytes("data"));b.Write((uint)size);}
        }
    }
}
