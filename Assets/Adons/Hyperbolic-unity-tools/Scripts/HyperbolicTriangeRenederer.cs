using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Mathematics;


namespace un
{
}
[ExecuteAlways]
[ExecuteInEditMode]
public class HyperbolicTriangeRenederer : MonoBehaviour
{
    float speed1 = 1;
    float constspeed = 1;
    float constdist = 4;
    public static float speed = 10.0f; public static float speed2 = 10.0f;
    public static float rotationSpeed = 10.0f;
    [HideInInspector] public float v1 = 0;
    [HideInInspector] public float v2 = 0;
    [HideInInspector] public float v3 = 0;
    [HideInInspector] public bool w;
    [HideInInspector] public Hyperbolic2D p2 = new Hyperbolic2D();
    [HideInInspector] public Hyperbolic2D p3 = new Hyperbolic2D();
    [HideInInspector] public Hyperbolic2D p4 = new Hyperbolic2D();
    [Header("Polygon")]
    [Header("==============")]
    [Header("MeshFiller")] [SerializeField] public MeshFilter mf;
    [Header("MeshCollider")] [SerializeField] public MeshCollider mc;
    [Header("Flip Normals")] [SerializeField] public bool v;
    //  [Header("==============")] [HideInInspector] [SerializeField] public bool byUnauticna;

    [HideInInspector] public Vector3 v31; [HideInInspector] public Vector3 v32; [HideInInspector] public Vector3 v33;
    [HideInInspector] public float x;
    private void Awake()
    {
        ProjectionUpdate();
        InvokeRepeating("ProjectionUpdate", 1, 0.07f);
    }
  


    
    public void ProjectionUpdate()
    {


        Deplacement();

    }
   // public void up2( Polar3 v2)
  //  {


      //  Deplacement();

  // }
    
    public void Createmath(Vector3 v1, Vector3 v2, Vector3 v3)
    {

        var m = new Mesh();
        m.Clear();
        Vector3[] verticles = new Vector3[3]
       {
            v1,v2,v3
       }; Vector3[] n = new Vector3[3]
       {
            Vector3.up,Vector3.up,Vector3.up
       }; Vector2[] uv = new Vector2[3]
       {
          new Vector2(0,1) , new Vector2(0,0), new Vector2(1,0)
       }; int[] tranglse = new int[3]
       {
            0,1,2
       };
        if (v)
        {
            tranglse = new int[3]
       {
            0,2,1
       };
        }
        m.SetVertices(verticles);
        m.triangles = tranglse;
        m.uv = uv;
        m.normals = n;
       

            mf.sharedMesh = m;
            mc.sharedMesh = m;
            mc.enabled = true;
      
    }
    public void Clearmath()
    {

        if (mf.sharedMesh != null)
        {


            






          //  mf.sharedMesh = null;
        //    mc.sharedMesh = null;
        }

    }

    float ds1 = 1;
    void Deplacement()
    {









        //multiplication par le facteur hyperbolique




        if (p2 != null && p3 != null && p4 != null)
        {



            PMatrix3D copytr1 = new PMatrix3D();
            copytr1.set(p2.getMatrix());
            PMatrix3D copytr2 = new PMatrix3D();
            copytr2.set(p3.getMatrix());
            PMatrix3D copytr3 = new PMatrix3D();
            copytr3.set(p4.getMatrix());

            //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")

            PVector nextPoint = MathHyper.polarVector(0f, 1.255f);


            //Apply currentTransform on nextPoint and save the result in nextPoint 



            copytr1.mult(nextPoint, nextPoint);

            if (FindObjectsByType<HyperbolicCamera>(sortmode.main).Length != 0) HyperbolicCamera.Main().RealtimeTransform.getMatrix().mult(nextPoint, nextPoint);

            nextPoint = MathHyper.projectOntoScreen(nextPoint);



            v31 = new Vector3(nextPoint.x, 0, nextPoint.y);







            //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")

            PVector nextPoint2 = MathHyper.polarVector(0f, 1.255f);


            //Apply currentTransform on nextPoint and save the result in nextPoint 



            copytr2.mult(nextPoint2, nextPoint2);

            if (FindObjectsByType<HyperbolicCamera>(sortmode.main).Length != 0) HyperbolicCamera.Main().RealtimeTransform.getMatrix().mult(nextPoint2, nextPoint2);

            nextPoint2 = MathHyper.projectOntoScreen(nextPoint2);



            v32 = new Vector3(nextPoint2.x, 0, nextPoint2.y);






            PVector nextPoint3 = MathHyper.polarVector(0f, 1.255f);
            //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")



            //Apply currentTransform on nextPoint and save the result in nextPoint 


            copytr3.mult(nextPoint3, nextPoint3);

            if (FindObjectsByType<HyperbolicCamera>(sortmode.main).Length != 0) HyperbolicCamera.Main().RealtimeTransform.getMatrix().mult(nextPoint3, nextPoint3);

            nextPoint3 = MathHyper.projectOntoScreen(nextPoint3);



            v33 = new Vector3(nextPoint3.x, 0, nextPoint3.y);




            //Apply currentTransform on nextPoint and save the result in nextPoint 

            Createmath(v31, v32, v33);


            // Clearmath();


            //sert pour baisser a la bonne hauteur





        }






        //sert pour baisser a la bonne hauteur












    }


    // transform.Translate(0, (nouveauFacteur - ancienFacteur) / 2,0);

    

    void LateUpdate()
    {
        
    }

    void Update()
    {

        
        


    }
}