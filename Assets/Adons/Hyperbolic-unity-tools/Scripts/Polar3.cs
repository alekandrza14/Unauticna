using UnityEngine;

[System.Serializable]
public class Polar3
{
    //A parametrisation SU2 that preserves hyperbolic space.
    //Starts with rotation of n rad, translation in z of s, and a rotation of m;
    public float n;
    public float s;
    public float m;
    
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
    public  Polar3()
    {
    }
    public Polar3(float dN, float dS, float dM)
    {
        n = dN; s = dS; m = dM;
    }
    public PMatrix3D getMatrix()
    {
        PMatrix3D startTransform = MathHyper.RotationMatrix(n);
        startTransform.apply(MathHyper.TranslationMatrix(0, s));
        startTransform.apply(MathHyper.RotationMatrix(m));
        return startTransform;
    }
    public  void applyTranslationZ(float l)
    {
        float N = Mathf.Atan2((cos(n) * sin(m) + cos(m) * sin(n) * cosh(s)) * sinh(l) + sin(n) * sinh(s) * cosh(l), ((cos(m) * cos(n) * cosh(s) - sin(m) * sin(n)) * sinh(l) + cos(n) * cosh(l) * sinh(s)));
        float S = arcosh(cosh(l) * cosh(s) + cos(m) * sinh(l) * sinh(s));
        float M = Mathf.Atan2((sin(m) * sinh(s)), (cosh(s) * sinh(l) + cosh(l) * sinh(s) * cos(m)));
        n = N;
        s = S;
        m = M;
    }
    public  void applyTranslationY(float l)
    {
        float N = Mathf.Atan2((cos(m) * cos(n) - cosh(s) * sin(m) * sin(n)) * sinh(l) + cosh(l) * sinh(s) * sin(n), (-cos(n) * cosh(s) * sin(m) - cos(m) * sin(n)) * sinh(l) + cosh(l) * sinh(s) * cos(n));
        float S = arcosh(cosh(l) * cosh(s) + sin(m) * sinh(l) * sinh(s));
        float M = Mathf.Atan2(-(cosh(s) * sinh(l) + cosh(l) * sinh(s) * sin(m)), (cos(m) * sinh(s)));
        n = N;
        s = S;
        m = M;
    }
    public  void applyRotation(float a)
    {
         m = m + a;
    }
    public  void applyPolarTransform(Polar3 pt)
    {
        applyRotation(pt.n);
        applyTranslationZ(pt.s);
        applyRotation(pt.m);
    }
    public  void preApplyTranslationY(float l)
    {
        float N = Mathf.Atan2(sin(n) * sinh(s), cosh(s) * sinh(l) + cos(n) * cosh(l) * sinh(s));
        float S = arcosh(cosh(l) * cosh(s) + cos(n) * sinh(l) * sinh(s));
        float M = Mathf.Atan2(cos(m) * sin(n) * sinh(l) + sin(m) * (cos(n) * sinh(l) * cosh(s) + cosh(l) * sinh(s)), cos(m) * (cos(n) * cosh(s) * sinh(l) + cosh(l) * sinh(s)) - sin(m) * sin(n) * sinh(l));

        n = N;
        s = S;
        m = M;
    }
    public  void preApplyTranslationZ(float l)
    {
        float N = Mathf.Atan2(cosh(s) * sinh(l) + cosh(l) * sinh(s) * sin(n), cos(n) * sinh(s));
        float S = arcosh(cosh(l) * cosh(s) + sin(n) * sinh(l) * sinh(s));
        float M = Mathf.Atan2(-cos(m) * cos(n) * sinh(l) + sin(m) * (cosh(s) * sinh(l) * sin(n) + cosh(l) * sinh(s)), cos(n) * sin(m) * sinh(l) + cos(m) * (cosh(s) * sinh(l) * sin(n) + cosh(l) * sinh(s)));
        n = N;
        s = S;
        m = M;
    }
    public  void preApplyRotation(float a)
    {
        n += a;
    }
    public  void preApplyPolarTransform(Polar3 pt)
    {
        preApplyRotation(pt.m);
        preApplyTranslationY(pt.s);
        preApplyRotation(pt.n);
    }

    static private float max(float a, float b)
    {
        return (a > b) ? a : b;
    }

    static private float abs(float a)
    {
        return (a < 0) ? -a : a;
    }

    static public float sin(float angle)
    {
        return (float)Mathf.Sin(angle);
    }

    static public float cos(float angle)
    {
        return (float)Mathf.Cos(angle);
    }
    public Polar3 inverse()
    {
        return new Polar3(-m, -s, -n);
    }
    public  float distanceTo(Polar3 p)
    {
        Polar3 c = copy();
        c.applyPolarTransform(p.inverse());
        return c.s;
    }
    public Polar3 copy()
    {
        return new Polar3(n, s, m);
    }
    public string toString()
    {
        return "<n-" + n + ",s-" + s + ",m-" + m + ">";
    }
    public  PVector posOnScreen()
    {
        PMatrix3D transform = getMatrix();
        PVector p = new PVector(1, 0, 0);
        transform.mult(p, p);
        p = MathHyper.projectOntoScreen(p);
        return p;
    }
}
