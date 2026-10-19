using System;
using System.Collections.Generic;
using System.Linq;

namespace Unauticna.MediaStudio
{
    [Serializable] public sealed class MediaClip
    {
        public string path; public double start, end, speed=1; public bool audio=true;
        public double Duration => (end-start)/speed;
        public MediaClip Copy(double a,double b,double rate) => new MediaClip {path=path,start=a,end=b,speed=rate,audio=audio};
    }
    [Serializable] public sealed class MediaDrawing
    {
        public string source, png; public double start,end;
    }
    [Serializable] public sealed class MediaProject
    {
        public int version=1,width=1280,height=720,fps=30;
        public List<MediaClip> clips=new List<MediaClip>();
        public List<MediaDrawing> drawings=new List<MediaDrawing>();
        public double Duration => clips.Sum(c=>c.Duration);
        public void Validate()
        {
            if(version!=1||width<64||height<64||width>4096||height>4096||width%2!=0||height%2!=0||fps<1||fps>120||clips==null||drawings==null||clips.Count>4096)
                throw new ArgumentException("Неверный формат монтажного проекта.");
            foreach(var c in clips)if(c==null||string.IsNullOrWhiteSpace(c.path)||!Finite(c.start)||!Finite(c.end)||!Finite(c.speed)||c.start<0||c.end<=c.start||c.speed<.125||c.speed>16)
                throw new ArgumentException("Неверный диапазон или скорость клипа.");
            foreach(var d in drawings)if(d==null||string.IsNullOrEmpty(d.source)||string.IsNullOrEmpty(d.png)||!Finite(d.start)||!Finite(d.end)||d.start<0||d.end<=d.start)
                throw new ArgumentException("Неверный рисунок на видео.");
        }
        public static bool Finite(double x)=>!double.IsNaN(x)&&!double.IsInfinity(x);
        public int Locate(double outputTime,out double sourceTime)
        {
            double t=Math.Max(0,outputTime);
            for(int i=0;i<clips.Count;i++)
            {var c=clips[i];if(t<c.Duration||i==clips.Count-1){sourceTime=Math.Min(c.end,c.start+t*c.speed);return i;}t-=c.Duration;}
            sourceTime=0;return -1;
        }
        public double Offset(int index){double t=0;for(int i=0;i<index;i++)t+=clips[i].Duration;return t;}
        public bool Split(int index,double time)
        {
            var c=clips[index];if(time<=c.start+.001||time>=c.end-.001)return false;
            clips[index]=c.Copy(c.start,time,c.speed);clips.Insert(index+1,c.Copy(time,c.end,c.speed));return true;
        }
        // Silent spans use source time, so cuts, speed changes and drawings remain aligned.
        public static List<MediaClip> SpeedSilence(MediaClip c,IEnumerable<TimeSpanRange> silent)
        {
            var ranges=silent.OrderBy(s=>s.start).ToArray();var result=new List<MediaClip>();double cursor=c.start;
            foreach(var s in ranges)
            {
                double a=Math.Max(cursor,Math.Max(c.start,s.start)),b=Math.Min(c.end,s.end);
                if(b<=a)continue;
                if(a>cursor)result.Add(c.Copy(cursor,a,c.speed));
                result.Add(c.Copy(a,b,6));cursor=b;
            }
            if(cursor<c.end)result.Add(c.Copy(cursor,c.end,c.speed));return result;
        }
    }
    public struct TimeSpanRange {public double start,end;public TimeSpanRange(double a,double b){start=a;end=b;}}
    public sealed class MediaInfo {public double duration;public bool audio;}
}
