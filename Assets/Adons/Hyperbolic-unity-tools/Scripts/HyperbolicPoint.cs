using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class points
{

    [SerializeField] public HyperbolicPoint points1;
    [SerializeField] public HyperbolicPoint points2;
}
[ExecuteAlways]
static public class Hyperbolicmovetool
{

    public static HyperbolicPoint mainEdit;
}
[ExecuteAlways]
[AddComponentMenu("Hyperbolic space/Hyperbolic Point")]
public class HyperbolicPoint : MonoBehaviour
{
    Vector4 oldposition;
    [HideInInspector] public Vector3 mposition;
    
    [HideInInspector] public Vector4 position;
    [Header("=============")]
    [Header("Tie")]
    [SerializeField] public points points = new points();

    [HideInInspector] public Quaternion rotation;
    public Hyperbolic2D HyperboilcPoistion = new Hyperbolic2D();
    public Hyperbolic2D HyperboilcOringe = new Hyperbolic2D();
    public Vector3 ScriptSacle = Vector3.one;
    [HideInInspector] public float v1 = 0;
    [HideInInspector] public float x;
   [HideInInspector] public bool px;
    [HideInInspector] public bool py;
    [HideInInspector] public bool mx;
    [HideInInspector] public bool my;
    HyperbolicTriangle sc;
    bool pass;
    public void selfClear()
    {
        Destroy(this);
    }
    private void OnDrawGizmos()
    {


        if (!GetComponent<HyperbolicTriangeRenederer>())
        {


            Gizmos.color = Color.blue + new Color(0.6f, 0.6f, 0.4f);
            Gizmos.DrawSphere(transform.position, 0.3f);

        }
        else
        {


            Gizmos.color = Color.green + new Color(0.4f, 0, 0.4f);
            Gizmos.DrawSphere(mposition, 0.3f);




        }
       
       // Hyperbolicmovetool.mainEdit = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ProjectionUpdate", 1, 0.05f);
        ProjectionUpdate();
    }
    static public void ALLSpheresRot(float r)
    {
        for (int i = 0; i < ALLSpheres().Length;i++)
        {
            float ds = MathHyper.Facteur2(ALLSpheres()[i].gameObject, ALLSpheres()[i].transform.position);
            ALLSpheres()[i].transform.rotation = Quaternion.Euler(ALLSpheres()[i].transform.rotation.eulerAngles.x, ALLSpheres()[i].transform.rotation.eulerAngles.y - r / Time.deltaTime *3.14f * ds, ALLSpheres()[i].transform.rotation.eulerAngles.z);

        }
    }
    static public HyperbolicPoint[] ALLSpheres()
    {
        return GameObject.FindObjectsByType<HyperbolicPoint>(sortmode.main);
    }
   

    public void LateUpdate()
    {
        
    }
    public void edit()
    {

        PMatrix3D copytr = new PMatrix3D();
        copytr.set(HyperboilcOringe.getMatrix());

        PVector nextPoint = MathHyper.polarVector(0, 1.255f);
        Vector3 v3 = new Vector3();
        //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")
       

            //Apply currentTransform on nextPoint and save the result in nextPoint 



            copytr.mult(nextPoint, nextPoint);
            if (FindObjectsByType<HyperbolicCamera>(sortmode.main).Length != 0) HyperbolicCamera.Main().RealtimeTransform.getMatrix().mult(nextPoint, nextPoint);

            nextPoint = MathHyper.projectOntoScreen(nextPoint);
            if (GetComponent<HyperbolicTriangeRenederer>())
            {
                transform.rotation = rotation;
            }
            if (!GetComponent<HyperbolicTriangeRenederer>())
            {

                v3 = new Vector3(nextPoint.x, 0, nextPoint.y);
               
                
                    transform.rotation = Quaternion.LookRotation(v3);
               





            }
            else
            {
            }


        
    }
    // Update is called once per frame
    public void ProjectionUpdate()
    {
        if (gameObject.GetComponent<HyperbolicTriangle>())
        {
            sc = gameObject.GetComponent<HyperbolicTriangle>();
        }
        if (sc == null)
        {
            gameObject.AddComponent<HyperbolicTriangle>().sp1 = this;
            sc = gameObject.GetComponent<HyperbolicTriangle>();
        }
        if (sc != null)
        {

          if(points.points1 != null)  sc.sp2 = points.points1;
            if (points.points2 != null) sc.sp3 = points.points2;
        }
        if (points.points1 != null && !pass && !GetComponent<HyperbolicTriangeRenederer>())
        {
            if (points.points2 != null && !pass)
            {
                gameObject.AddComponent<MeshFilter>();
                gameObject.AddComponent<MeshRenderer>();
                gameObject.AddComponent<MeshCollider>();
                sc.tr = gameObject.AddComponent<HyperbolicTriangeRenederer>();
                gameObject.GetComponent<HyperbolicTriangeRenederer>().mc = GetComponent<MeshCollider>();
                gameObject.GetComponent<HyperbolicTriangeRenederer>().mf = GetComponent<MeshFilter>();
                pass = true;
            }
        }
        if (points.points1 != null && !pass && GetComponent<HyperbolicTriangeRenederer>())
        {
            if (points.points2 != null && !pass)
            {
               // gameObject.AddComponent<MeshFilter>();
              //  gameObject.AddComponent<MeshRenderer>();
               // gameObject.AddComponent<MeshCollider>();
                sc.tr = gameObject.GetComponent<HyperbolicTriangeRenederer>();
                gameObject.GetComponent<HyperbolicTriangeRenederer>().mc = GetComponent<MeshCollider>();
                gameObject.GetComponent<HyperbolicTriangeRenederer>().mf = GetComponent<MeshFilter>();
                pass = true;
            }
        }
        if (points.points1 == null || points.points2 == null)
        {
            pass = false;
        }

     
            PMatrix3D copytr = new PMatrix3D();
            copytr.set(HyperboilcPoistion.getMatrix());


        PVector nextPoint = MathHyper.polarVector(0f, 1.255f);
        //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")
        

            //Apply currentTransform on nextPoint and save the result in nextPoint 



            copytr.mult(nextPoint, nextPoint);
           if(FindObjectsByType<HyperbolicCamera>(sortmode.main).Length!=0) HyperbolicCamera.Main().RealtimeTransform.getMatrix().mult(nextPoint, nextPoint);

            nextPoint = MathHyper.projectOntoScreen(nextPoint);

            if (!GetComponent<HyperbolicTriangeRenederer>())
            {

                transform.position = new Vector3(nextPoint.x, transform.position.y, nextPoint.y);
                mposition = new Vector3(nextPoint.x, transform.position.y, nextPoint.y);

              




            }
            else
            {
                mposition = new Vector3(nextPoint.x, transform.position.y, nextPoint.y);
            }

        float dist = (25f -MathHyper.sinh((new PVector().dist(nextPoint) * 0.2f)))/25;

        if (!GetComponent<HyperbolicTriangeRenederer>() && dist >= 0)
        {
            transform.localScale = ScriptSacle * dist;
        }else if (!GetComponent<HyperbolicTriangeRenederer>() && dist < 0)
        {
            transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
        }
            if (GetComponent<HyperbolicTriangeRenederer>())
            transform.localScale = Vector3.one;
        if (GetComponent<HyperbolicTriangeRenederer>())
        {
            transform.position = Vector3.zero;
        }
        edit();
        oldposition = position;
    }
}