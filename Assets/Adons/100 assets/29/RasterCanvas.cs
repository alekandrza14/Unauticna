using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unauticna.MediaStudio
{
    public sealed class RasterLayer
    {
        public string name;public bool visible=true;public byte[] pixels;
        public RasterLayer(string n,int bytes){name=n;pixels=new byte[bytes];}
    }
    public sealed class RasterCanvas
    {
        public int Width{get;private set;} public int Height{get;private set;}
        public List<RasterLayer> Layers{get;private set;}=new List<RasterLayer>();
        public int Selected;
        sealed class Snapshot{public int w,h,selected;public List<RasterLayer> layers;public long bytes;}
        readonly List<Snapshot> history=new List<Snapshot>();long historyBytes;
        public RasterCanvas(int w,int h){CheckSize(w,h);Width=w;Height=h;AddLayer();}
        static void CheckSize(int w,int h){if(w<1||h<1||w>4096||h>4096||(long)w*h>8388608)throw new ArgumentException("Изображение: максимум 4096 по стороне и 8 мегапикселей.");}
        public void Checkpoint()
        {
            var copy=new List<RasterLayer>();foreach(var l in Layers)copy.Add(new RasterLayer(l.name,0){pixels=(byte[])l.pixels.Clone(),visible=l.visible});
            long bytes=(long)Width*Height*4*Layers.Count;history.Add(new Snapshot{w=Width,h=Height,selected=Selected,layers=copy,bytes=bytes});historyBytes+=bytes;
            while(history.Count>1&&(history.Count>12||historyBytes>96L*1024*1024)){historyBytes-=history[0].bytes;history.RemoveAt(0);}
        }
        public bool Undo(){if(history.Count==0)return false;var s=history[history.Count-1];history.RemoveAt(history.Count-1);historyBytes-=s.bytes;Width=s.w;Height=s.h;Selected=s.selected;Layers=s.layers;return true;}
        public void AddLayer(){if(Layers.Count>=8)throw new InvalidOperationException("Максимум 8 слоёв.");Layers.Add(new RasterLayer("Слой "+(Layers.Count+1),Width*Height*4));Selected=Layers.Count-1;}
        public void DeleteLayer(){if(Layers.Count<=1)Array.Clear(Layers[0].pixels,0,Layers[0].pixels.Length);else{Layers.RemoveAt(Selected);Selected=Math.Min(Selected,Layers.Count-1);}}
        public void Stroke(float x0,float y0,float x1,float y1,float radius,byte red,byte green,byte blue,byte alpha,bool erase)
        {
            double dx=x1-x0,dy=y1-y0;int steps=Math.Max(1,(int)(Math.Sqrt(dx*dx+dy*dy)/Math.Max(1,radius*.4f)));
            for(int k=0;k<=steps;k++)Dab(x0+(x1-x0)*k/steps,y0+(y1-y0)*k/steps,radius,red,green,blue,alpha,erase);
        }
        void Dab(float cx,float cy,float r,byte red,byte green,byte blue,byte alpha,bool erase)
        {
            var p=Layers[Selected].pixels;int minX=Math.Max(0,(int)(cx-r)),maxX=Math.Min(Width-1,(int)(cx+r)),minY=Math.Max(0,(int)(cy-r)),maxY=Math.Min(Height-1,(int)(cy+r));
            for(int y=minY;y<=maxY;y++)for(int x=minX;x<=maxX;x++)
            {
                if((x-cx)*(x-cx)+(y-cy)*(y-cy)>r*r)continue;int i=(y*Width+x)*4;
                if(erase){p[i+3]=(byte)(p[i+3]*(255-alpha)/255);continue;}
                Blend(p,i,red,green,blue,alpha);
            }
        }
        static void Blend(byte[] p,int i,byte r,byte g,byte b,byte a)
        {
            float sa=a/255f,da=p[i+3]/255f,oa=sa+da*(1-sa);if(oa<=0)return;
            p[i]=(byte)((r*sa+p[i]*da*(1-sa))/oa);p[i+1]=(byte)((g*sa+p[i+1]*da*(1-sa))/oa);p[i+2]=(byte)((b*sa+p[i+2]*da*(1-sa))/oa);p[i+3]=(byte)Math.Min(255,oa*255+.5f);
        }
        public byte[] Composite()
        {
            var result=new byte[Width*Height*4];Parallel.For(0,Height,new ParallelOptions{MaxDegreeOfParallelism=4},y=>{
                for(int x=0;x<Width;x++){int i=(y*Width+x)*4;foreach(var l in Layers)if(l.visible)Blend(result,i,l.pixels[i],l.pixels[i+1],l.pixels[i+2],l.pixels[i+3]);}
            });return result;
        }
        public void Crop(int x,int y,int w,int h)
        {
            x=Math.Max(0,x);y=Math.Max(0,y);w=Math.Min(w,Width-x);h=Math.Min(h,Height-y);CheckSize(w,h);int oldW=Width;
            Map(w,h,(xx,yy)=>((yy+y)*oldW+xx+x)*4);
        }
        public void Resize(int w,int h){CheckSize(w,h);int ow=Width,oh=Height;Map(w,h,(x,y)=>((y*oh/h)*ow+x*ow/w)*4);}
        public void Flip(){int w=Width;Map(Width,Height,(x,y)=>(y*w+w-1-x)*4);}
        public void Rotate(){int w=Width,h=Height;Map(h,w,(x,y)=>((h-1-x)*w+y)*4);}
        void Map(int w,int h,Func<int,int,int> index)
        {
            foreach(var layer in Layers){var src=layer.pixels;var dst=new byte[w*h*4];Parallel.For(0,h,new ParallelOptions{MaxDegreeOfParallelism=4},y=>{for(int x=0;x<w;x++)Buffer.BlockCopy(src,index(x,y),dst,(y*w+x)*4,4);});layer.pixels=dst;}
            Width=w;Height=h;
        }
        public void Adjust(float brightness,float contrast)
        {
            var p=Layers[Selected].pixels;Parallel.For(0,Height,new ParallelOptions{MaxDegreeOfParallelism=4},y=>{for(int x=0;x<Width;x++){int i=(y*Width+x)*4;for(int c=0;c<3;c++)p[i+c]=(byte)Math.Max(0,Math.Min(255,((p[i+c]/255f-.5f)*contrast+.5f+brightness)*255));}});
        }
    }
}
