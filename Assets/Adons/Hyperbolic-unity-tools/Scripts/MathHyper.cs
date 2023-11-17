using UnityEngine;
using System;

public class MathHyper : MonoBehaviour
{


    
    public static double sqrRayon = 400;

    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {

    }
    public static double cosh(double x)
    {// formula for hyperbolic Mathf.Cosine
        return (Math.Exp(x) + Math.Exp(-x)) / 2f;
    }
    public static double arcosh(double a)
    {// inverse of hyperbolic Mathf.Cosine
        return Math.Log(a + Math.Sqrt(a * a - 1));
    }
    public static double sinh(double x)
    {// formula for hyperbolic sine
        return (Math.Exp(x) - Math.Exp(-x)) / 2f;
    }
    

    public static PVector projectOntoPoincareDisc(PVector point)
    {// Returns vector after projecting onto unit disc
     //Poincare disc
        double scale = 1f / (point.x + 1);
        return new PVector(point.y * scale, point.z * scale,0);
    }
    public static PVector PoincareDiscOntoParaboloid(PVector point)
    {
        double scale = 1f / (point.x + 1);
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
    public static PVector polarVector(double r, double theta)
    { //vector given polar coordinates in hyperbolic space
        return new PVector(MathHyper.cosh(r), MathHyper.sinh(r) * Math.Cos(theta), MathHyper.sinh(r) * Math.Sin(theta));
    }
    public static PMatrix3D TranslationMatrixZ(double yTrans)
    {
        PMatrix3D P = new PMatrix3D();
        P.set(cosh(yTrans), sinh(yTrans), 0f, 0f,
              sinh(yTrans), cosh(yTrans), 0f, 0f,
              0f, 0f, 1f, 0f,
              0f, 0f, 0f, 0f);
        return P;
    }
    public static PMatrix3D TranslationMatrixY(double yTrans)
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
    public static PMatrix3D TranslationMatrix(double translateX, double translateY)
    {
        PMatrix3D P = new PMatrix3D();
        P.set(TranslationMatrixY(translateX));
        P.apply(TranslationMatrixZ(translateY));
        return P;
    }


    public static PMatrix3D RotationMatrix(double theta)
    {
        PMatrix3D P = new PMatrix3D();
        P.set(1f, 0f, 0f, 0f,
              0f, Math. Cos(theta), -Math.Sin(theta), 0f,
              0f, Math.Sin(theta), Math.Cos(theta), 0f,
              0f, 0f, 0f, 0f);
        return P;
    }
    public static double Facteur(GameObject objet, Vector3 p)
    {

        double posX = objet.transform.position.x - Camera.main.transform.position.x;
        double posZ = objet.transform.position.z - Camera.main.transform.position.z;
        double posW = p.z;
        double sqrDistance = 399.99999f;
        if (posX * posX + posZ * posZ < 400)
        {


            sqrDistance = posX * posX + posZ * posZ + posW * posW;

        }
        double distance = Math.Sqrt(1 - sqrDistance / sqrRayon);


        //Debug.Log(distance, gameObject);

        return distance;

    }
    public static double Facteur2(GameObject objet, Vector3 p)
    {

        double posX = p.x;
        double posZ = p.z;
        double sqrDistance = 20f;
        if (posX * posX + posZ * posZ < 21)
        {


            sqrDistance = posX * posX + posZ * posZ;

        }

        double distance = Math.Sqrt(1 - sqrDistance / sqrRayon);

      
       
        //Debug.Log(distance, gameObject);

        return distance;

    }
    public static double Facteur3(GameObject objet, Vector3 p)
    {

        double posX = objet.transform.position.x -Camera.main.transform.position.x;
        double posZ = objet.transform.position.z -Camera.main.transform.position.z;
        double sqrDistance = 399.99999f;
        if (posX * posX + posZ * posZ < 400)
        {


            sqrDistance =  posX * posX + posZ * posZ;

        }

        double distance = Math.Sqrt(1 - sqrDistance / sqrRayon);


        //Debug.Log(distance, gameObject);

        return distance;

    }

}
