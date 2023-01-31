using UnityEngine;

public class MathHyper : MonoBehaviour
{


    
    public static float sqrRayon = 400;

    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {

    }
    public static float cosh(float x)
    {// formula for hyperbolic Mathf.Cosine
        return (Mathf.Exp(x) + Mathf.Exp(-x)) / 2f;
    }
    public static float arcosh(float a)
    {// inverse of hyperbolic Mathf.Cosine
        return Mathf.Log(a + Mathf.Sqrt(a * a - 1));
    }
    public static float sinh(float x)
    {// formula for hyperbolic sine
        return (Mathf.Exp(x) - Mathf.Exp(-x)) / 2f;
    }
    

    public static PVector projectOntoPoincareDisc(PVector point)
    {// Returns vector after projecting onto unit disc
     //Poincare disc
        float scale = 1f / (point.x + 1);
        return new PVector(point.y * scale, point.z * scale,0);
    }
    public static PVector PoincareDiscOntoParaboloid(PVector point)
    {
        float scale = 1f / (point.x + 1);
        return new PVector( point.y * scale, point.z * scale, 0);
    }
    public static PVector scaleToScreen(PVector point)
    {
        return new PVector(point.x * 20 + 1, point.y * 20 + 1, 0);
    }
    public static PVector projectOntoScreen(PVector point)
    {
        return scaleToScreen(projectOntoPoincareDisc(point));
    }
    public static PVector polarVector(float r, float theta)
    { //vector given polar coordinates in hyperbolic space
        return new PVector(MathHyper.cosh(r), MathHyper.sinh(r) * Mathf.Cos(theta), MathHyper.sinh(r) * Mathf.Sin(theta));
    }
    public static PMatrix3D TranslationMatrixZ(float yTrans)
    {
        PMatrix3D P = new PMatrix3D();
        P.set(cosh(yTrans), sinh(yTrans), 0f, 0f,
              sinh(yTrans), cosh(yTrans), 0f, 0f,
              0f, 0f, 1f, 0f,
              0f, 0f, 0f, 0f);
        return P;
    }
    public static PMatrix3D TranslationMatrixY(float yTrans)
    {
        PMatrix3D P = new PMatrix3D();
        P.set(cosh(yTrans), 0f, sinh(yTrans), 0f,
             0f, 1f, 0f, 0f,
             sinh(yTrans), 0f, cosh(yTrans), 0f,
             0f, 0f, 0f, 0f);
        return P;
    }
    public static PMatrix3D TranslationMatrix(PVector Translate)
    {
        PMatrix3D P = new PMatrix3D();
        P.set(TranslationMatrixY(Translate.x));
        P.apply(TranslationMatrixZ(Translate.y));
        return P;
    }
    public static PMatrix3D TranslationMatrix(float translateX, float translateY)
    {
        PMatrix3D P = new PMatrix3D();
        P.set(TranslationMatrixY(translateX));
        P.apply(TranslationMatrixZ(translateY));
        return P;
    }


    public static PMatrix3D RotationMatrix(float theta)
    {
        PMatrix3D P = new PMatrix3D();
        P.set(1f, 0f, 0f, 0f,
              0f, Mathf. Cos(theta), -Mathf.Sin(theta), 0f,
              0f, Mathf.Sin(theta), Mathf.Cos(theta), 0f,
              0f, 0f, 0f, 0f);
        return P;
    }
    public static float Facteur(GameObject objet, Vector3 p)
    {

        float posX = objet.transform.position.x - Camera.main.transform.position.x;
        float posZ = objet.transform.position.z - Camera.main.transform.position.z;
        float posW = p.z;
        float sqrDistance = 399.99999f;
        if (posX * posX + posZ * posZ < 400)
        {


            sqrDistance = posX * posX + posZ * posZ + posW * posW;

        }
        float distance = Mathf.Sqrt(1 - sqrDistance / sqrRayon);


        //Debug.Log(distance, gameObject);

        return distance;

    }
    public static float Facteur2(GameObject objet, Vector3 p)
    {

        float posX = p.x;
        float posZ = p.z;
        float sqrDistance = 20f;
        if (posX * posX + posZ * posZ < 21)
        {


            sqrDistance = posX * posX + posZ * posZ;

        }

        float distance = Mathf.Sqrt(1 - sqrDistance / sqrRayon);

      
       
        //Debug.Log(distance, gameObject);

        return distance;

    }
    public static float Facteur3(GameObject objet, Vector3 p)
    {

        float posX = objet.transform.position.x -Camera.main.transform.position.x;
        float posZ = objet.transform.position.z -Camera.main.transform.position.z;
        float sqrDistance = 399.99999f;
        if (posX * posX + posZ * posZ < 400)
        {


            sqrDistance =  posX * posX + posZ * posZ;

        }

        float distance = Mathf.Sqrt(1 - sqrDistance / sqrRayon);


        //Debug.Log(distance, gameObject);

        return distance;

    }

}
