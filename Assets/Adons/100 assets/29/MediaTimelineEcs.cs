using System;
using FFS.Libraries.StaticEcs;
namespace Unauticna.MediaStudio
{
    public struct MediaWorldType:IWorldType{}
    public abstract class MediaWorld:World<MediaWorldType>{}
    public struct TimelineClip:IComponent{public int Index;public double Offset,Duration,SourceStart,Speed;}
    // Only one editor is open. Rebuild on edits, never allocate entities each frame.
    public sealed class MediaTimelineEcs:IDisposable
    {
        bool created;
        public void Rebuild(MediaProject project)
        {
            Dispose();MediaWorld.Create();created=true;MediaWorld.Types().Component<TimelineClip>();MediaWorld.Initialize();double at=0;
            for(int i=0;i<project.clips.Count;i++){var c=project.clips[i];MediaWorld.NewEntity<Default>().Set(new TimelineClip{Index=i,Offset=at,Duration=c.Duration,SourceStart=c.start,Speed=c.speed});at+=c.Duration;}
        }
        public int Locate(double time,out double source)
        {
            source=0;if(!created)return -1;int last=-1;double end=0;
            foreach(var e in MediaWorld.Query<All<TimelineClip>>().Entities())
            {
                ref readonly var c=ref e.Read<TimelineClip>();
                if(time>=c.Offset&&time<c.Offset+c.Duration){source=c.SourceStart+(time-c.Offset)*c.Speed;return c.Index;}
                if(c.Index>last){last=c.Index;end=c.SourceStart+c.Duration*c.Speed;}
            }
            source=end;return last;
        }
        public void Dispose(){if(created){MediaWorld.Destroy();created=false;}}
    }
}
