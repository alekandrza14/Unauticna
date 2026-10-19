using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Unauticna.MediaStudio
{
    public static class MediaFFmpeg
    {
        public static string Number(double x)=>x.ToString("0.#########",CultureInfo.InvariantCulture);
        // Windows CommandLineToArgvW quoting; no shell, cmd.exe or interpolation of filters from filenames.
        public static string Quote(string text)
        {
            var b=new StringBuilder("\"");int slashes=0;
            foreach(char c in text){if(c=='\\'){slashes++;continue;}if(c=='\"'){b.Append('\\',slashes*2+1);b.Append(c);}else{b.Append('\\',slashes);b.Append(c);}slashes=0;}
            b.Append('\\',slashes*2);return b.Append('"').ToString();
        }
        public static Process Start(string exe,IEnumerable<string> args,bool input=false)
        {
            var info=new ProcessStartInfo(exe,string.Join(" ",args.Select(Quote))) {
                UseShellExecute=false,CreateNoWindow=true,RedirectStandardError=true,RedirectStandardOutput=true,RedirectStandardInput=input
            };
            var p=new Process{StartInfo=info};if(!p.Start())throw new IOException("Не удалось запустить FFmpeg.");return p;
        }
        public static async Task<string> Run(string exe,IEnumerable<string> args,CancellationToken token)
        {
            using(var p=Start(exe,args))
            using(token.Register(()=>{try{if(!p.HasExited)p.Kill();}catch{}}))
            {
                Task<string> output=p.StandardOutput.ReadToEndAsync();
                // Bound stderr memory even for long recordings/analysis.
                var tail=new Queue<string>();var reader=Task.Run(async()=>{string line;while((line=await p.StandardError.ReadLineAsync())!=null){if(tail.Count>=20000)tail.Dequeue();tail.Enqueue(line);}});
                await Task.Run(()=>p.WaitForExit());await reader;var text=await output;token.ThrowIfCancellationRequested();
                if(p.ExitCode!=0)throw new IOException("FFmpeg: "+string.Join("\n",tail).Substring(Math.Max(0,string.Join("\n",tail).Length-4000)));
                return text+"\n"+string.Join("\n",tail);
            }
        }
        public static async Task<MediaInfo> Probe(string probe,string file,CancellationToken token)
        {
            string output=await Run(probe,new[]{"-v","error","-show_entries","format=duration:stream=codec_type","-of","default=noprint_wrappers=1",file},token);
            var m=Regex.Match(output,@"duration=([0-9.]+)");
            if(!m.Success||!output.Contains("codec_type=video"))throw new IOException("Файл не содержит поддерживаемое видео с длительностью.");
            double d=double.Parse(m.Groups[1].Value,CultureInfo.InvariantCulture);
            if(!MediaProject.Finite(d)||d<=0)throw new IOException("Неверная длительность видео.");
            return new MediaInfo{duration=d,audio=output.Contains("codec_type=audio")};
        }
        public static async Task<List<TimeSpanRange>> Silence(string exe,MediaClip clip,double db,double minimum,CancellationToken token)
        {
            if(!clip.audio)return clip.end-clip.start>=minimum?new List<TimeSpanRange>{new TimeSpanRange(clip.start,clip.end)}:new List<TimeSpanRange>();
            string log=await Run(exe,new[]{"-hide_banner","-nostdin","-i",clip.path,"-vn","-af","silencedetect=noise="+Number(db)+"dB:d="+Number(minimum),"-f","null","-"},token);
            return ParseSilence(log,clip.end);
        }
        public static List<TimeSpanRange> ParseSilence(string log,double end)
        {
            var result=new List<TimeSpanRange>();double? start=null;
            foreach(Match m in Regex.Matches(log,@"silence_(start|end):\s*(-?[0-9.]+)"))
            {
                double value=double.Parse(m.Groups[2].Value,CultureInfo.InvariantCulture);
                if(m.Groups[1].Value=="start")start=Math.Max(0,value);
                else if(start.HasValue){if(value>start.Value)result.Add(new TimeSpanRange(start.Value,value));start=null;}
            }
            if(start.HasValue&&end>start.Value)result.Add(new TimeSpanRange(start.Value,end));return result;
        }
        public static string Tempo(double speed)
        {
            var filters=new List<string>();while(speed>2){filters.Add("atempo=2");speed/=2;}while(speed<.5){filters.Add("atempo=0.5");speed/=.5;}
            filters.Add("atempo="+Number(speed));return string.Join(",",filters);
        }
        public static void Commit(string temp,string destination)
        {if(File.Exists(destination))File.Replace(temp,destination,null);else File.Move(temp,destination);}
        public static async Task Export(string exe,MediaProject project,string destination,Action<string> status,CancellationToken token)
        {
            project.Validate();if(project.clips.Count==0)throw new InvalidOperationException("Добавь видео на монтажную ленту.");
            destination=Path.GetFullPath(destination);
            foreach(var c in project.clips)if(string.Equals(Path.GetFullPath(c.path),destination,StringComparison.OrdinalIgnoreCase))throw new IOException("Экспортируй в новый файл, не поверх исходного видео.");
            // FFmpeg 9 removed -filter_complex_script. Prefer the supported file-loading syntax.
            string help=await Run(exe,new[]{"-hide_banner","-h","full"},token);
            string filterScriptOption=help.Contains("-filter_complex_script")?"-filter_complex_script":"-/filter_complex";
            string dir=Path.Combine(Path.GetDirectoryName(destination),".media-"+Guid.NewGuid().ToString("N"));Directory.CreateDirectory(dir);
            try
            {
                var overlays=new List<string>();for(int i=0;i<project.drawings.Count;i++){string f=Path.Combine(dir,"draw"+i+".png");File.WriteAllBytes(f,Convert.FromBase64String(project.drawings[i].png));overlays.Add(f);}
                var parts=new List<string>();
                for(int i=0;i<project.clips.Count;i++)
                {
                    token.ThrowIfCancellationRequested();status?.Invoke("Экспорт клипа "+(i+1)+" / "+project.clips.Count);
                    var c=project.clips[i];string part=Path.Combine(dir,"part"+i.ToString("D5")+".mp4");parts.Add(part);
                    var args=new List<string>{"-hide_banner","-loglevel","error","-nostdin","-y","-ss",Number(c.start),"-t",Number(c.end-c.start),"-i",c.path};
                    var drawings=new List<int>();for(int k=0;k<project.drawings.Count;k++){var d=project.drawings[k];if(string.Equals(d.source,c.path,StringComparison.OrdinalIgnoreCase)&&d.end>c.start&&d.start<c.end){drawings.Add(k);args.AddRange(new[]{"-loop","1","-i",overlays[k]});}}
                    string size=project.width+":"+project.height;
                    var filter=new StringBuilder("[0:v]setpts=(PTS-STARTPTS)/"+Number(c.speed)+",scale="+size+":force_original_aspect_ratio=decrease,pad="+size+":(ow-iw)/2:(oh-ih)/2,setsar=1,fps="+project.fps+"[v0];");
                    for(int k=0;k<drawings.Count;k++)
                    {
                        var d=project.drawings[drawings[k]];double a=Math.Max(0,(d.start-c.start)/c.speed),b=Math.Min(c.Duration,(d.end-c.start)/c.speed);
                        filter.Append("["+(k+1)+":v]scale="+size+",format=rgba[o"+k+"];[v"+k+"][o"+k+"]overlay=0:0:enable='gte(t,"+Number(a)+")*lt(t,"+Number(b)+")':eof_action=repeat[v"+(k+1)+"];");
                    }
                    filter.Append("[v"+drawings.Count+"]format=yuv420p[v];");
                    if(c.audio)filter.Append("[0:a]asetpts=PTS-STARTPTS,"+Tempo(c.speed)+",aresample=48000,aformat=channel_layouts=stereo,apad,atrim=duration="+Number(c.Duration)+"[a]");
                    else filter.Append("anullsrc=r=48000:cl=stereo,atrim=duration="+Number(c.Duration)+"[a]");
                    string script=Path.Combine(dir,"filter.txt");File.WriteAllText(script,filter.ToString(),new UTF8Encoding(false));
                    args.AddRange(new[]{"-filter_complex_threads","2",filterScriptOption,script,"-map","[v]","-map","[a]","-t",Number(c.Duration),"-c:v","libx264","-preset","veryfast","-crf","20","-threads","2","-c:a","aac","-b:a","192k",part});
                    await Run(exe,args,token);
                }
                string concat=Path.Combine(dir,"parts.txt");File.WriteAllLines(concat,parts.Select(p=>"file '"+Path.GetFileName(p)+"'"),new UTF8Encoding(false));
                string ready=Path.Combine(dir,"finished.mp4");
                await Run(exe,new[]{"-hide_banner","-loglevel","error","-nostdin","-y","-f","concat","-safe","1","-i",concat,"-c","copy","-movflags","+faststart",ready},token);
                token.ThrowIfCancellationRequested();Commit(ready,destination);
            }
            finally{try{Directory.Delete(dir,true);}catch{}}
        }
    }
}
