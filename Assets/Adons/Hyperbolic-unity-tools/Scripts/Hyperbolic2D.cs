using System;
using UnityEngine;

[System.Serializable]
public class Hyperbolic2D
{
    //A parametrisation SU2 that preserves hyperbolic space.
    //Starts with rotation of n rad, translation in z of s, and a rotation of m;
    public double n;
    public double s;
    public double m;
    
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
    public  Hyperbolic2D()
    {
    }
    public Hyperbolic2D(double dN, double dS, double dM)
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
    public  void applyTranslationZ(double l)
    {
        double N = Math.Atan2((cos(n) * sin(m) + cos(m) * sin(n) * cosh(s)) * sinh(l) + sin(n) * sinh(s) * cosh(l), ((cos(m) * cos(n) * cosh(s) - sin(m) * sin(n)) * sinh(l) + cos(n) * cosh(l) * sinh(s)));
        double S = arcosh(cosh(l) * cosh(s) + cos(m) * sinh(l) * sinh(s));
        double M = Math.Atan2((sin(m) * sinh(s)), (cosh(s) * sinh(l) + cosh(l) * sinh(s) * cos(m)));
        n = N;
        s = S;
        m = M;
    }
    public  void applyTranslationY(double l)
    {
        double N = Math.Atan2((cos(m) * cos(n) - cosh(s) * sin(m) * sin(n)) * sinh(l) + cosh(l) * sinh(s) * sin(n), (-cos(n) * cosh(s) * sin(m) - cos(m) * sin(n)) * sinh(l) + cosh(l) * sinh(s) * cos(n));
        double S = arcosh(cosh(l) * cosh(s) + sin(m) * sinh(l) * sinh(s));
        double M = Math.Atan2(-(cosh(s) * sinh(l) + cosh(l) * sinh(s) * sin(m)), (cos(m) * sinh(s)));
        n = N;
        s = S;
        m = M;
    }
    public  void applyRotation(double a)
    {
         m = m + a;
    }
    public  void applyPolarTransform(Hyperbolic2D pt)
    {
        applyRotation(pt.n);
        applyTranslationZ(pt.s);
        applyRotation(pt.m);
    }
    public  void preApplyTranslationY(double l)
    {
        double N = Math.Atan2(sin(n) * sinh(s), cosh(s) * sinh(l) + cos(n) * cosh(l) * sinh(s));
        double S = arcosh(cosh(l) * cosh(s) + cos(n) * sinh(l) * sinh(s));
        double M = Math.Atan2(cos(m) * sin(n) * sinh(l) + sin(m) * (cos(n) * sinh(l) * cosh(s) + cosh(l) * sinh(s)), cos(m) * (cos(n) * cosh(s) * sinh(l) + cosh(l) * sinh(s)) - sin(m) * sin(n) * sinh(l));

        n = N;
        s = S;
        m = M;
    }
    public  void preApplyTranslationZ(double l)
    {
        double N = Math.Atan2(cosh(s) * sinh(l) + cosh(l) * sinh(s) * sin(n), cos(n) * sinh(s));
        double S = arcosh(cosh(l) * cosh(s) + sin(n) * sinh(l) * sinh(s));
        double M = Math.Atan2(-cos(m) * cos(n) * sinh(l) + sin(m) * (cosh(s) * sinh(l) * sin(n) + cosh(l) * sinh(s)), cos(n) * sin(m) * sinh(l) + cos(m) * (cosh(s) * sinh(l) * sin(n) + cosh(l) * sinh(s)));
        n = N;
        s = S;
        m = M;
    }
    public  void preApplyRotation(double a)
    {
        n += a;
    }
    public  void preApplyPolarTransform(Hyperbolic2D pt)
    {
        preApplyRotation(pt.m);
        preApplyTranslationY(pt.s);
        preApplyRotation(pt.n);
    }

    static private double max(double a, double b)
    {
        return (a > b) ? a : b;
    }

    static private double abs(double a)
    {
        return (a < 0) ? -a : a;
    }

    static public double sin(double angle)
    {
        return (double)Math.Sin(angle);
    }

    static public double cos(double angle)
    {
        return (double)Math.Cos(angle);
    }
    public Hyperbolic2D inverse()
    {
        return new Hyperbolic2D(-m, -s, -n);
    }
    public double distanceTo(Hyperbolic2D p)
    {
        Hyperbolic2D c = copy();
        c.applyPolarTransform(p.inverse());
        return c.s;
    }
    public Hyperbolic2D copy()
    {
        return new Hyperbolic2D(n, s, m);
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
