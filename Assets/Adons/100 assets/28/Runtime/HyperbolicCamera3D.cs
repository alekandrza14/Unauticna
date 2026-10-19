using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Unauticna.HyperbolicSpace
{
    [DisallowMultipleComponent, RequireComponent(typeof(Camera))]
    public sealed class HyperbolicCamera3D : MonoBehaviour
    {
        [Min(.1f)] public float curvatureRadius=20f;
        [Header("Initial position: decimal strings, not float coordinates")]
        public string initialX="0",initialY="1",initialZ="0";
        [Tooltip("The entire coordinate is multiplied by 2 to this power. May exceed Int64.")]
        public string initialScalePower="0";
        public bool inputEnabled=true;
        [Min(0)] public float moveSpeed=8f;
        [Min(1)] public float sprintMultiplier=3f;
        [Range(.01f,1f)] public float mouseSensitivity=.15f;
        public bool showHelp=true;
        [Tooltip("Show the fixed global origin, geodesic axes and direction HUD.")]
        public bool showOriginGuide=true;

        private readonly HyperbolicNavigator navigator=new HyperbolicNavigator();
        public MegaPoint Position=>navigator.Position;
        public H3Point LocalPosition=>navigator.LocalPosition;
        public Camera ViewCamera { get; private set; }
        private bool ownsCursor;
        private CursorLockMode oldLock;
        private bool oldVisible;
        private string status;
        private float nextStatus;

        void Awake()
        {
            ViewCamera=GetComponent<Camera>();
            SetPosition(MegaPoint.FromCoordinates(initialX,initialY,initialZ,initialScalePower));
            if(GetComponent<HyperbolicOriginGuide>()==null)gameObject.AddComponent<HyperbolicOriginGuide>();
        }

        public void SetPosition(H3Point point)=>navigator.SetPosition(MegaPoint.FromLocal(point));
        public void SetPosition(MegaPoint point)=>navigator.SetPosition(point);
        public void SetPosition(string x,string y,string z,string scalePower="0")=>SetPosition(MegaPoint.FromCoordinates(x,y,z,scalePower));

        [ContextMenu("Rebase Now (keep global position)")]
        public void RebaseNow()=>navigator.RebaseNow();

        [Serializable]
        public sealed class CameraState
        {
            public int version=2;
            public MegaPositionData position;
            public float rotationX,rotationY,rotationZ,rotationW;
            public float curvatureRadius;
        }
        public string SaveStateJson()
        {
            Quaternion q=transform.rotation;
            return JsonUtility.ToJson(new CameraState {position=Position.ToData(),rotationX=q.x,rotationY=q.y,
                rotationZ=q.z,rotationW=q.w,curvatureRadius=curvatureRadius});
        }
        public void LoadStateJson(string json)
        {
            var data=JsonUtility.FromJson<CameraState>(json);
            if(data==null||data.version!=2||!H3Math.Finite(data.curvatureRadius)||data.curvatureRadius<=0)
                throw new ArgumentException("Invalid H3 camera save.");
            if(Mathf.Abs(data.curvatureRadius-curvatureRadius)>.0001f)
                throw new ArgumentException("Use the saved curvature radius before starting the starfield.");
            if(!H3Math.Finite(data.rotationX)||!H3Math.Finite(data.rotationY)||!H3Math.Finite(data.rotationZ)||!H3Math.Finite(data.rotationW))
                throw new ArgumentException("Invalid saved camera rotation.");
            Quaternion q=new Quaternion(data.rotationX,data.rotationY,data.rotationZ,data.rotationW);
            float norm=q.x*q.x+q.y*q.y+q.z*q.z+q.w*q.w;
            if(!H3Math.Finite(norm)||norm<.000001f)throw new ArgumentException("Invalid saved camera rotation.");
            SetPosition(MegaPoint.FromData(data.position));
            transform.rotation=q.normalized;
        }

        /// <summary>Local displacement in game units. Does not change Unity transform.position.</summary>
        public void MoveLocal(Vector3 displacement)
        {
            if(!H3Math.Finite(displacement.x)||!H3Math.Finite(displacement.y)||!H3Math.Finite(displacement.z))
                throw new ArgumentException("Movement must be finite.");
            MoveLocal(ToDecimal(displacement));
        }
        public void MoveLocal(decimal x,decimal y,decimal z)=>MoveLocal(new DVec3(x,y,z));
        public void MoveLocal(DVec3 displacement)
        {
            decimal radius=Math.Max(.1m,(decimal)curvatureRadius);
            decimal needed=Math.Max(1,decimal.Ceiling(displacement.Length/(radius*.15m)));
            if(needed>4096)throw new ArgumentOutOfRangeException(nameof(displacement),"Use SetPosition for a large teleportation in one call.");
            int steps=(int)needed;
            DVec3 part=displacement/steps;
            for(int i=0;i<steps;i++)
            {
                DVec3 forward=ToDecimal(transform.forward),up=ToDecimal(transform.up);
                DVec3 right=new DVec3(up.Y*forward.Z-up.Z*forward.Y,up.Z*forward.X-up.X*forward.Z,up.X*forward.Y-up.Y*forward.X).Normalized;
                DVec3 world=right*part.X+up*part.Y+forward*part.Z;
                navigator.MoveCanonical(world,radius,ref forward,ref up);
                transform.rotation=Quaternion.LookRotation(ToFloat(forward),ToFloat(up));
            }
        }

        void Update()
        {
            if(!inputEnabled || !Application.isFocused || Time.timeScale<=0)
            { ReleaseCursor(); return; }
            ReadInput(out Vector3 move,out global::UnityEngine.Vector2 look,out bool looking,out bool sprint,out float roll);
            if(looking)
            {
                if(!ownsCursor)
                {
                    oldLock=Cursor.lockState; oldVisible=Cursor.visible; ownsCursor=true;
                    Cursor.lockState=CursorLockMode.Locked; Cursor.visible=false;
                }
                transform.rotation=transform.rotation*Quaternion.Euler(-look.y*mouseSensitivity,look.x*mouseSensitivity,0);
            }
            else ReleaseCursor();
            float dt=Mathf.Min(Time.deltaTime,.05f);
            if(roll!=0)transform.rotation=transform.rotation*Quaternion.AngleAxis(roll*60f*dt,Vector3.forward);
            if(move.sqrMagnitude>1)move.Normalize();
            if(move.sqrMagnitude>0)
            {
                MoveLocal(move*(moveSpeed*(sprint?sprintMultiplier:1)*dt));
            }
        }

        private static void ReadInput(out Vector3 move,out global::UnityEngine.Vector2 look,out bool looking,out bool sprint,out float roll)
        {
            move=Vector3.zero; look=global::UnityEngine.Vector2.zero; looking=false; sprint=false; roll=0;
#if ENABLE_INPUT_SYSTEM
            var k=Keyboard.current;
            if(k!=null)
            {
                move.x=(k.dKey.isPressed?1:0)-(k.aKey.isPressed?1:0);
                move.z=(k.wKey.isPressed?1:0)-(k.sKey.isPressed?1:0);
                move.y=(k.spaceKey.isPressed?1:0)-((k.leftCtrlKey.isPressed||k.rightCtrlKey.isPressed)?1:0);
                sprint=k.leftShiftKey.isPressed||k.rightShiftKey.isPressed;
                roll=(k.qKey.isPressed?1:0)-(k.eKey.isPressed?1:0);
            }
            var m=Mouse.current;
            if(m!=null) { look=m.delta.ReadValue(); looking=m.rightButton.isPressed; }
#else
            move.x=(Input.GetKey(KeyCode.D)?1:0)-(Input.GetKey(KeyCode.A)?1:0);
            move.z=(Input.GetKey(KeyCode.W)?1:0)-(Input.GetKey(KeyCode.S)?1:0);
            move.y=(Input.GetKey(KeyCode.Space)?1:0)-((Input.GetKey(KeyCode.LeftControl)||Input.GetKey(KeyCode.RightControl))?1:0);
            sprint=Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift);
            roll=(Input.GetKey(KeyCode.Q)?1:0)-(Input.GetKey(KeyCode.E)?1:0);
            looking=Input.GetMouseButton(1);
            // Legacy axes are smoothed units, not pixels.
            if(looking)look=new global::UnityEngine.Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"))*10f;
#endif
        }

        private void ReleaseCursor()
        {
            if(!ownsCursor)return;
            Cursor.lockState=oldLock; Cursor.visible=oldVisible; ownsCursor=false;
        }
        void OnDisable()=>ReleaseCursor();
        void OnApplicationFocus(bool focus) { if(!focus)ReleaseCursor(); }
        void OnGUI()
        {
            if(!showHelp)return;
            if(status==null||Time.unscaledTime>=nextStatus)
            {
                nextStatus=Time.unscaledTime+.2f;
                status="HYPERBOLIC SPACE / DECIMAL + MEGA\nWASD: fly   Space / Ctrl: up / down   Shift: faster\nRMB + mouse: look   Q / E: roll\nLocal: "+LocalPosition.X.ToString("G5")+", "+LocalPosition.Y.ToString("G5")+", "+LocalPosition.Z.ToString("G5")+"   Rebases: "+navigator.RebaseCount+"\nMega layer: "+Short(Position.Level.ToString())+"   Cell: "+Short(Position.CellX.ToString())+", "+Short(Position.CellZ.ToString());
            }
            GUI.Box(new Rect(12,12,650,108),status);
        }
        private static string Short(string s)=>s.Length<=24?s:s.Substring(0,10)+"…"+s.Substring(s.Length-10);
        private static DVec3 ToDecimal(Vector3 v)=>new DVec3((decimal)v.x,(decimal)v.y,(decimal)v.z);
        private static Vector3 ToFloat(DVec3 v)=>new Vector3((float)v.X,(float)v.Y,(float)v.Z);
    }
}
