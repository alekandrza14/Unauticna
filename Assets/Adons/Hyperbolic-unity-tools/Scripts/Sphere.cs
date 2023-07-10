using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class points
{

    [SerializeField] public Sphere points1;
    [SerializeField] public Sphere points2;
}
[ExecuteAlways]
static public class Hyperbolicmovetool
{

    public static Sphere mainEdit;
}
[ExecuteAlways]
[AddComponentMenu("Hyperbolic space/Hyperbolic Point")]
public class Sphere : MonoBehaviour
{
    Vector4 oldposition;
    [HideInInspector] public Vector3 mposition;
    
    [HideInInspector] public Vector4 position;
    [Header("=============")]
    [Header("Tie")]
    [SerializeField] public points points = new points();

    [HideInInspector] public Quaternion rotation;
    [HideInInspector] public Polar3 p2 = new Polar3();
    [HideInInspector] public Polar3 p3 = new Polar3();
    [HideInInspector] public Vector3 ls = Vector3.one;
    [HideInInspector] public float v1 = 0;
    [HideInInspector] public float x;
   [HideInInspector] public bool px;
    [HideInInspector] public bool py;
    [HideInInspector] public bool mx;
    [HideInInspector] public bool my;
    sc sc;
    bool pass;
    public void selfClear()
    {
        Destroy(this);
    }
    private void OnDrawGizmos()
    {


        if (!GetComponent<tringle>())
        {


            Gizmos.color = Color.blue + new Color(0.6f, 0.6f, 0.4f);
            Gizmos.DrawSphere(transform.position, 0.3f);

        }
        else
        {


            Gizmos.color = Color.green + new Color(0.4f, 0, 0.4f);
            Gizmos.DrawSphere(mposition, 0.3f);




        }
       
      if(  FindObjectsByType<Sphere>(sortmode.main)[FindObjectsByType<Sphere>(sortmode.main).Length-1] == this) Hyperbolicmovetool.mainEdit = null;
        // Hyperbolicmovetool.mainEdit = null;
    }
  
    // Start is called before the first frame update
    void Start()
    {

    }
    static public void ALLSpheresRot(float r)
    {
        for (int i = 0; i < ALLSpheres().Length;i++)
        {
            float ds = MathHyper.Facteur2(ALLSpheres()[i].gameObject, ALLSpheres()[i].transform.position);
            ALLSpheres()[i].transform.rotation = Quaternion.Euler(ALLSpheres()[i].transform.rotation.eulerAngles.x, ALLSpheres()[i].transform.rotation.eulerAngles.y - r / Time.deltaTime *3.14f * ds, ALLSpheres()[i].transform.rotation.eulerAngles.z);

        }
    }
    static public Sphere[] ALLSpheres()
    {
        return GameObject.FindObjectsByType<Sphere>(sortmode.main);
    }
   

    public void LateUpdate()
    {
        
    }
    public void edit()
    {
        transform.rotation = rotation;
    }
    // Update is called once per frame
    public void Update()
    {
        if (gameObject.GetComponent<sc>())
        {
            sc = gameObject.GetComponent<sc>();
        }
        if (sc == null)
        {
            gameObject.AddComponent<sc>().sp1 = this;
            sc = gameObject.GetComponent<sc>();
        }
        if (sc != null)
        {

          if(points.points1 != null)  sc.sp2 = points.points1;
            if (points.points2 != null) sc.sp3 = points.points2;
        }
        if (points.points1 != null && !pass && !GetComponent<tringle>())
        {
            if (points.points2 != null && !pass)
            {
                gameObject.AddComponent<MeshFilter>();
                gameObject.AddComponent<MeshRenderer>();
                gameObject.AddComponent<MeshCollider>();
                sc.tr = gameObject.AddComponent<tringle>();
                gameObject.GetComponent<tringle>().mc = GetComponent<MeshCollider>();
                gameObject.GetComponent<tringle>().mf = GetComponent<MeshFilter>();
                pass = true;
            }
        }
        if (points.points1 != null && !pass && GetComponent<tringle>())
        {
            if (points.points2 != null && !pass)
            {
               // gameObject.AddComponent<MeshFilter>();
              //  gameObject.AddComponent<MeshRenderer>();
               // gameObject.AddComponent<MeshCollider>();
                sc.tr = gameObject.GetComponent<tringle>();
                gameObject.GetComponent<tringle>().mc = GetComponent<MeshCollider>();
                gameObject.GetComponent<tringle>().mf = GetComponent<MeshFilter>();
                pass = true;
            }
        }
        if (points.points1 == null || points.points2 == null)
        {
            pass = false;
        }

            if (position != oldposition)
        {


            p2 = new Polar3(position.x, position.y, position.z);
            v1 = position.w;
        }
        position = new Vector4(p2.n, p2.s, p2.m, v1);
        
            PMatrix3D copytr = new PMatrix3D();
            copytr.set(p2.getMatrix());

            PVector prevPoint = new PVector();
            //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")
       
            PVector nextPoint = MathHyper.polarVector(0.1f, 1.255f);
            //Apply currentTransform on nextPoint and save the result in nextPoint 



            copytr.mult(nextPoint, nextPoint);
            HyperbolicCamera.Main().polarTransform.getMatrix().mult(nextPoint, nextPoint);

            nextPoint = MathHyper.projectOntoScreen(nextPoint);

            if (!GetComponent<tringle>())
            {
                
                    transform.position = new Vector3(prevPoint.x, v1, prevPoint.y);
                    mposition = new Vector3(prevPoint.x, v1, prevPoint.y);
               



              

            }
            else
            {
                mposition = new Vector3(prevPoint.x, v1, prevPoint.y);
            }

            prevPoint = nextPoint;


      
        if (GetComponent<tringle>())
        {
            transform.position = Vector3.zero;
        }
       
        oldposition = position;
    }
}
