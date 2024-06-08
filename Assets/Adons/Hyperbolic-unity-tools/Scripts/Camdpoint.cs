using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camdpoint : MonoBehaviour
{
    [Header("=============")]
    [Header("Hyperbolic")]
    [SerializeField] Vector4 position;

    [HideInInspector] public Hyperbolic2D p2 = new Hyperbolic2D();

    [HideInInspector] public Hyperbolic2D p3 = new Hyperbolic2D();
    public Vector3 ls;
    public float v1 = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Vector3 newrot()
    {
        Vector3 v6 = new Vector3();
        
        PMatrix3D copytr = new PMatrix3D();
        copytr.set(p3.inverse().getMatrix());

        PVector prevPoint = new PVector();
        float ds = (float)MathHyper.Facteur2(gameObject, transform.position);
        float inc = 0.1f;
        for (float i = 0; i < inc * 2; i += inc)
        {
            PVector nextPoint = MathHyper.polarVector(i, 1.255f);



            copytr.mult(nextPoint, nextPoint);
            HyperbolicCamera.Main().RealtimeTransform.getMatrix().mult(nextPoint, nextPoint);

            nextPoint = MathHyper.projectOntoScreen(nextPoint);

            if (i >= inc)
            {
                v6 = new Vector3((float)prevPoint.x, v1 * ds, (float)prevPoint.y);

            }




            prevPoint = nextPoint;


        }
        return v6;
    }

    // Update is called once per frame
    void Update()
    {
        PMatrix3D copytr = new PMatrix3D();
        copytr.set(p2.inverse().getMatrix());

        PVector prevPoint = new PVector();
        //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")
        float ds = (float)MathHyper.Facteur2(gameObject, transform.position);
        float inc = 0.1f;
        for (float i = 0; i < inc * 2; i += inc)
        {
            PVector nextPoint = MathHyper.polarVector(i, 1.255f);
            //Apply currentTransform on nextPoint and Save the result in nextPoint 



            copytr.mult(nextPoint, nextPoint);
            HyperbolicCamera.Main().RealtimeTransform.getMatrix().mult(nextPoint, nextPoint);

            nextPoint = MathHyper.projectOntoScreen(nextPoint);

            if (i >= inc)
            {
                transform.position = new Vector3((float)prevPoint.x, v1 * ds, (float)prevPoint.y);

            }


            var look_dir = newrot() - transform.position;
            look_dir.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look_dir), 1000 * Time.deltaTime);

            prevPoint = nextPoint;


        }

        transform.localScale = ls * (float)MathHyper.Facteur2(gameObject, transform.position);
    }
}
