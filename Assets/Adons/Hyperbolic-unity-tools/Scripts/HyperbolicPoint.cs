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

    [SerializeField] bool VertexOrPoint;
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
        if (!VertexOrPoint)
        {
            HyperboilcOringe.m = HyperboilcPoistion.m;
            HyperboilcOringe.s = HyperboilcPoistion.s;
            HyperboilcOringe.n = HyperboilcPoistion.n;
            HyperboilcOringe.applyTranslationZ(1);
            InvokeRepeating("ProjectionUpdate", 0, 0.05f + UnityEngine.Random.Range(0f, 0.02f));
            ProjectionUpdate(); 
        }
    }
  
   

    public void LateUpdate()
    {
        
    }
    public void edit()
    {
        PMatrix3D CamMatrix = new PMatrix3D();
        if (HyperbolicCamera.Main() != null) CamMatrix = HyperbolicCamera.Main().RealtimeTransform.getMatrix();

        PMatrix3D copytr = new PMatrix3D();
        copytr.set(HyperboilcOringe.getMatrix());

        PVector nextPoint = MathHyper.polarVector(0, 1.255f);
        Vector3 v3 = new Vector3();
        //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")
       

            //Apply currentTransform on nextPoint and Save the result in nextPoint 



            copytr.mult(nextPoint, nextPoint);
            CamMatrix.mult(nextPoint, nextPoint);

            nextPoint = MathHyper.projectOntoScreen(nextPoint);
            if (GetComponent<HyperbolicTriangeRenederer>())
            {
                transform.rotation = rotation;
            }
            if (!GetComponent<HyperbolicTriangeRenederer>())
            {

                v3 = new Vector3((float)nextPoint.x, 0, (float)nextPoint.y);
               
                
                    transform.rotation = Quaternion.LookRotation(v3);
               





            }
            else
            {
            }


        
    }
    // Update is called once per frame
    public void ProjectionUpdate()
    {
        PMatrix3D CamMatrix = new PMatrix3D();
        if (HyperbolicCamera.Main() != null) CamMatrix = HyperbolicCamera.Main().RealtimeTransform.getMatrix();

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
        

            //Apply currentTransform on nextPoint and Save the result in nextPoint 



            copytr.mult(nextPoint, nextPoint);
        CamMatrix.mult(nextPoint, nextPoint);

            nextPoint = MathHyper.projectOntoScreen(nextPoint);

            if (!GetComponent<HyperbolicTriangeRenederer>())
            {

                transform.position = new Vector3((float)nextPoint.x-1, transform.position.y, (float)nextPoint.y-1);
                mposition = new Vector3((float)nextPoint.x - 1, transform.position.y, (float)nextPoint.y - 1);

              




            }
            else
            {
                mposition = new Vector3((float)nextPoint.x - 1, transform.position.y, (float)nextPoint.y - 1);
            }

        float dist = (float)(25f -MathHyper.sinh((new PVector().dist(nextPoint) * 0.2f)))/25;

        if (!GetComponent<HyperbolicTriangeRenederer>() && dist >= 0)
        {
            transform.localScale = ScriptSacle * dist;
        }else if (!GetComponent<HyperbolicTriangeRenederer>() && dist < 0)
        {
            transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
        }
      if(GetComponent<Rigidbody>())  GetComponent<Rigidbody>().useGravity = false;
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
