using System;
using UnityEngine;
using UVector2 = global::UnityEngine.Vector2;

namespace Unauticna.HyperbolicSpace
{
    /// <summary>Fixed global origin and geodesic axes drawn as a navigation overlay.
    /// All Unity calls stay on the main thread. No spawned objects/materials.</summary>
    [DisallowMultipleComponent, RequireComponent(typeof(HyperbolicCamera3D))]
    public sealed class HyperbolicOriginGuide : MonoBehaviour
    {
        public bool showAxes=true;
        [Tooltip("Length on each side of the origin, in curvature radii.")]
        [Range(.02f,1f)] public float axisLength=.25f;
        [Tooltip("Hide the small origin axes beyond this hyperbolic distance in curvature radii. The bearing remains visible.")]
        [Range(.5f,8f)] public float axesVisibleDistance=3f;
        [Range(1f,30f)] public float calculationsPerSecond=10f;
        public Color xColor=new Color(1f,.35f,.35f),yColor=new Color(.35f,1f,.4f),zColor=new Color(.35f,.65f,1f);
        public Color originColor=new Color(1f,.9f,.35f);

        const int Segments=16,Points=Segments+1;
        readonly MegaPoint[] axisPoints=new MegaPoint[3*Points];
        readonly Vector3[] projected=new Vector3[3*Points];
        readonly bool[] valid=new bool[3*Points];
        HyperbolicCamera3D owner;
        Camera view;
        MegaPoint lastPosition;
        Vector3 direction;
        decimal distance;
        bool distanceKnown,hasFrame,axesReady;
        float nextCalculation,lastLength=-1,lastRadius=-1,lastRange=-1;
        string distanceLabel="",distanceBehindLabel="";

        void Awake() { owner=GetComponent<HyperbolicCamera3D>();view=GetComponent<Camera>(); }
        void OnEnable() {hasFrame=false;nextCalculation=0;}

        void LateUpdate()
        {
            if(owner==null||!owner.showOriginGuide||view==null||!view.enabled)return;
            if(hasFrame&&Time.unscaledTime<nextCalculation)return;
            nextCalculation=Time.unscaledTime+1f/Mathf.Clamp(calculationsPerSecond,1f,30f);
            float length=Mathf.Clamp(axisLength,.02f,1f);
            float radius=Mathf.Max(.1f,owner.curvatureRadius);
            float range=Mathf.Clamp(axesVisibleDistance,.5f,8f);
            MegaPoint position=owner.Position;
            if(hasFrame&&position.Equals(lastPosition)&&length==lastLength&&radius==lastRadius&&range==lastRange)return;
            if(length!=lastLength)
            {
                for(int axis=0;axis<3;axis++)for(int i=0;i<Points;i++)
                    axisPoints[axis*Points+i]=HyperbolicOriginMath.AxisPoint(axis,(decimal)length*(2m*i/Segments-1));
            }
            DVec3 bearing=HyperbolicOriginMath.Bearing(position,out distance,out distanceKnown);
            direction=ToFloat(bearing);
            distanceLabel=distanceKnown?"До центра: "+(distance*(decimal)radius).ToString("0.00")+" ед.":"Центр далеко / направление ~";
            distanceBehindLabel=distanceLabel+" | сзади";
            axesReady=distanceKnown&&distance<=(decimal)range;
            if(axesReady)for(int i=0;i<axisPoints.Length;i++)
            {
                valid[i]=axisPoints[i].TryToLocal(position,out H3Point local);
                if(valid[i])
                {
                    DVec3 v=H3Math.LogDirection(H3Point.Origin,local,out decimal d);
                    projected[i]=ToFloat(v*(d*(decimal)radius));
                }
            }
            lastPosition=position;lastLength=length;lastRadius=radius;lastRange=range;hasFrame=true;
        }

        // Explicit action only: never teleport when enabling the guide or rebasing.
        [ContextMenu("Return camera to global origin")]
        public void ReturnToOrigin()
        {
            if(owner==null)owner=GetComponent<HyperbolicCamera3D>();
            owner.SetPosition(MegaPoint.Origin);
            hasFrame=false;nextCalculation=0;
        }

        void OnGUI()
        {
            if(!hasFrame||owner==null||!owner.showOriginGuide||view==null||!view.enabled||Event.current.type!=EventType.Repaint)return;
            // Respect a non-fullscreen camera viewport. This is a HUD, not a depth-tested mesh.
            Rect pixels=view.pixelRect;
            if(pixels.width<80||pixels.height<80)return;
            Color oldColor=GUI.color;
            GUI.BeginGroup(new Rect(pixels.x,Screen.height-pixels.y-pixels.height,pixels.width,pixels.height));
            try
            {
                if(showAxes&&axesReady)for(int axis=0;axis<3;axis++)
                {
                    GUI.color=axis==0?xColor:axis==1?yColor:zColor;
                    for(int i=0;i<Segments;i++)
                    {
                        int n=axis*Points+i;
                        if(valid[n]&&valid[n+1])DrawWorldSegment(projected[n],projected[n+1],pixels);
                    }
                    int end=axis*Points+Segments;
                    if(valid[end]&&TryScreen(projected[end],pixels,out UVector2 label))
                        GUI.Label(new Rect(label.x+4,label.y-10,28,22),axis==0?"+X":axis==1?"+Y":"+Z");
                }
                GUI.color=originColor;
                bool atOrigin=distanceKnown&&distance<.00001m;
                string state=atOrigin?"Вы в центре (0, 1, 0)":distanceLabel;
                if(!atOrigin)
                {
                    // A unit-distance proxy is only used for the bearing, not for the axes.
                    Vector3 local=view.transform.InverseTransformDirection(direction);
                    if(TryScreen(direction*Mathf.Max(1,view.nearClipPlane*2),pixels,out UVector2 marker))
                    {
                        Line(marker.x-7,marker.y,marker.x+7,marker.y);
                        Line(marker.x,marker.y-7,marker.x,marker.y+7);
                        GUI.Label(new Rect(Mathf.Clamp(marker.x+12,0,pixels.width-105),Mathf.Clamp(marker.y-12,0,pixels.height-24),105,24),"Центр (0,1,0)");
                    }
                    else
                    {
                        // Camera-space x/y preserve the correct side for a target behind us.
                        float dx=local.x,dy=-local.y;
                        if(dx*dx+dy*dy<.000001f)dx=1;
                        float limitX=pixels.width*.5f-26,limitY=pixels.height*.5f-26;
                        float k=1/Mathf.Max(Mathf.Abs(dx)/limitX,Mathf.Abs(dy)/limitY);
                        float x=pixels.width*.5f+dx*k,y=pixels.height*.5f+dy*k;
                        float norm=Mathf.Sqrt(dx*dx+dy*dy);dx/=norm;dy/=norm;
                        Line(x-18*dx,y-18*dy,x,y);
                        Line(x,y,x-8*dx+5*dy,y-8*dy-5*dx);
                        Line(x,y,x-8*dx-5*dy,y-8*dy+5*dx);
                    }
                    if(local.z<0)state=distanceBehindLabel;
                }
                GUI.Box(new Rect(12,pixels.height-44,Mathf.Min(420,pixels.width-24),32),state);
            }
            finally {GUI.EndGroup();GUI.color=oldColor;}
        }

        bool TryScreen(Vector3 offset,Rect pixels,out UVector2 screen)
        {
            Vector3 p=view.WorldToViewportPoint(view.transform.position+offset);
            screen=new UVector2(p.x*pixels.width,(1-p.y)*pixels.height);
            return p.z>=view.nearClipPlane&&p.x>=0&&p.x<=1&&p.y>=0&&p.y<=1;
        }

        void DrawWorldSegment(Vector3 a,Vector3 b,Rect pixels)
        {
            // Clip against the near plane before perspective projection.
            float near=Mathf.Max(.001f,view.nearClipPlane);
            float za=Vector3.Dot(view.transform.forward,a),zb=Vector3.Dot(view.transform.forward,b);
            if(za<near&&zb<near)return;
            if(za<near)a=a+(b-a)*((near-za)/(zb-za));
            else if(zb<near)b=b+(a-b)*((near-zb)/(za-zb));
            Vector3 pa=view.WorldToViewportPoint(view.transform.position+a),pb=view.WorldToViewportPoint(view.transform.position+b);
            float dx=pb.x-pa.x,dy=pb.y-pa.y,lo=0,hi=1;
            if(!Clip(-dx,pa.x,ref lo,ref hi)||!Clip(dx,1-pa.x,ref lo,ref hi)||
               !Clip(-dy,pa.y,ref lo,ref hi)||!Clip(dy,1-pa.y,ref lo,ref hi))return;
            Line((pa.x+lo*dx)*pixels.width,(1-pa.y-lo*dy)*pixels.height,
                 (pa.x+hi*dx)*pixels.width,(1-pa.y-hi*dy)*pixels.height);
        }
        static bool Clip(float p,float q,ref float lo,ref float hi)
        {
            if(p==0)return q>=0;
            float t=q/p;
            if(p<0) {if(t>hi)return false;lo=Mathf.Max(lo,t);}
            else {if(t<lo)return false;hi=Mathf.Min(hi,t);}
            return true;
        }
        static void Line(float ax,float ay,float bx,float by)
        {
            float dx=bx-ax,dy=by-ay,length=Mathf.Sqrt(dx*dx+dy*dy);
            if(length<.1f)return;
            Matrix4x4 old=GUI.matrix;
            GUIUtility.RotateAroundPivot(Mathf.Atan2(dy,dx)*Mathf.Rad2Deg,new UVector2(ax,ay));
            GUI.DrawTexture(new Rect(ax,ay-1,length,2),Texture2D.whiteTexture);
            GUI.matrix=old;
        }
        static Vector3 ToFloat(DVec3 v)=>new Vector3((float)v.X,(float)v.Y,(float)v.Z);
    }
}
