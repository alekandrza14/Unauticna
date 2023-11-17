using UnityEngine;
using System;

public class PMatrix2D
{

  public double m00, m01, m02;
public double m10, m11, m12;


/**
 * Create a new matrix, set to the identity matrix.
 */
public PMatrix2D()
{
    reset();
}


public PMatrix2D(double m00, double m01, double m02,
                 double m10, double m11, double m12)
{
    set(m00, m01, m02,
        m10, m11, m12);
}





public void reset()
{
    set(1, 0, 0,
        0, 1, 0);
}


/**
 * Returns a copy of this PMatrix.
 */



/**
 * Copies the matrix contents into a 6 entry double array.
 * If target is null (or not the correct size), a new array will be created.
 * Returned in the order {@code {m00, m01, m02, m10, m11, m12}}.
 */
public double[] get(double[] target)
{
    if ((target == null) || (target.Length != 6))
    {
        target = new double[6];
    }
    target[0] = m00;
    target[1] = m01;
    target[2] = m02;

    target[3] = m10;
    target[4] = m11;
    target[5] = m12;

    return target;
}


/**
 * If matrix is a PMatrix2D, sets this matrix to be a copy of it.
 * @throws IllegalArgumentException If <tt>matrix</tt> is not 2D.
 */



  /**
   * Unavailable in 2D. Does nothing.
   */
  public void set(PMatrix3D src)
{
}


public void set(double[] source)
{
    m00 = source[0];
    m01 = source[1];
    m02 = source[2];

    m10 = source[3];
    m11 = source[4];
    m12 = source[5];
}


/**
 * Sets the matrix content.
 */
public void set(double m00, double m01, double m02,
                double m10, double m11, double m12)
{
    this.m00 = m00; this.m01 = m01; this.m02 = m02;
    this.m10 = m10; this.m11 = m11; this.m12 = m12;
}


/**
 * Unavailable in 2D. Does nothing.
 */
public void set(double m00, double m01, double m02, double m03,
                double m10, double m11, double m12, double m13,
                double m20, double m21, double m22, double m23,
                double m30, double m31, double m32, double m33)
{

}


public void translate(double tx, double ty)
{
    m02 = tx * m00 + ty * m01 + m02;
    m12 = tx * m10 + ty * m11 + m12;
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void translate(double x, double y, double z)
{
    
}


// Implementation roughly based on AffineTransform.
public void rotate(double angle)
{
    double s = sin(angle);
    double c = cos(angle);

    double temp1 = m00;
    double temp2 = m01;
    m00 = c * temp1 + s * temp2;
    m01 = -s * temp1 + c * temp2;
    temp1 = m10;
    temp2 = m11;
    m10 = c * temp1 + s * temp2;
    m11 = -s * temp1 + c * temp2;
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void rotateX(double angle)
{
    
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void rotateY(double angle)
{
    
}


public void rotateZ(double angle)
{
    rotate(angle);
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void rotate(double angle, double v0, double v1, double v2)
{
    
}


public void scale(double s)
{
    scale(s, s);
}


public void scale(double sx, double sy)
{
    m00 *= sx; m01 *= sy;
    m10 *= sx; m11 *= sy;
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void scale(double x, double y, double z)
{
    
}


public void shearX(double angle)
{
    apply(1, 0, 1, tan(angle), 0, 0);
}


public void shearY(double angle)
{
    apply(1, 0, 1, 0, tan(angle), 0);
}




  public void apply(PMatrix2D source)
{
    apply(source.m00, source.m01, source.m02,
          source.m10, source.m11, source.m12);
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void apply(PMatrix3D source)
{
   
}


public void apply(double n00, double n01, double n02,
                  double n10, double n11, double n12)
{
    double t0 = m00;
    double t1 = m01;
    m00 = n00 * t0 + n10 * t1;
    m01 = n01 * t0 + n11 * t1;
    m02 += n02 * t0 + n12 * t1;

    t0 = m10;
    t1 = m11;
    m10 = n00 * t0 + n10 * t1;
    m11 = n01 * t0 + n11 * t1;
    m12 += n02 * t0 + n12 * t1;
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void apply(double n00, double n01, double n02, double n03,
                  double n10, double n11, double n12, double n13,
                  double n20, double n21, double n22, double n23,
                  double n30, double n31, double n32, double n33)
{
    
}


/**
 * Apply another matrix to the left of this one.
 */



  public void preApply(PMatrix2D left)
{
    preApply(left.m00, left.m01, left.m02,
             left.m10, left.m11, left.m12);
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */



public void preApply(double n00, double n01, double n02,
                     double n10, double n11, double n12)
{
    double t0 = m02;
    double t1 = m12;
    n02 += t0 * n00 + t1 * n01;
    n12 += t0 * n10 + t1 * n11;

    m02 = n02;
    m12 = n12;

    t0 = m00;
    t1 = m10;
    m00 = t0 * n00 + t1 * n01;
    m10 = t0 * n10 + t1 * n11;

    t0 = m01;
    t1 = m11;
    m01 = t0 * n00 + t1 * n01;
    m11 = t0 * n10 + t1 * n11;
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void preApply(double n00, double n01, double n02, double n03,
                     double n10, double n11, double n12, double n13,
                     double n20, double n21, double n22, double n23,
                     double n30, double n31, double n32, double n33)
{
    
}


//////////////////////////////////////////////////////////////


/**
 * {@inheritDoc}
 * Ignores any z component.
 */
public PVector mult(PVector source, PVector target)
{
    if (target == null)
    {
        target = new PVector();
    }
    target.x = m00 * source.x + m01 * source.y + m02;
    target.y = m10 * source.x + m11 * source.y + m12;
    return target;
}


/**
 * Multiply a two element vector against this matrix.
 * If out is null or not length four, a new double array will be returned.
 * The values for vec and out can be the same (though that's less efficient).
 */
public double[] mult(double[] vec, double[] out1)
{
    if (out1 == null || out1.Length != 2) {
      out1 = new double[2];
}

if (vec == out1) {
    double tx = m00 * vec[0] + m01 * vec[1] + m02;
    double ty = m10 * vec[0] + m11 * vec[1] + m12;

      out1[0] = tx;
      out1[1] = ty;

} else
{
      out1[0] = m00 * vec[0] + m01 * vec[1] + m02;
      out1[1] = m10 * vec[0] + m11 * vec[1] + m12;
}

return out1;
  }


  /**
   * Returns the x-coordinate of the result of multiplying the point (x, y)
   * by this matrix.
   */
  public double multX(double x, double y)
{
    return m00 * x + m01 * y + m02;
}


/**
 * Returns the y-coordinate of the result of multiplying the point (x, y)
 * by this matrix.
 */
public double multY(double x, double y)
{
    return m10 * x + m11 * y + m12;
}



/**
 * Unavailable in 2D. Does nothing.
 */
public void transpose()
{
}


/*
 * Implementation stolen from OpenJDK.
 */
public bool invert()
{
    double determinant1 = determinant();
    if (Mathf.Abs((float)determinant1) <= double.MinValue)
    {
        return false;
    }

    double t00 = m00;
    double t01 = m01;
    double t02 = m02;
    double t10 = m10;
    double t11 = m11;
    double t12 = m12;

    m00 = t11 / determinant1;
    m10 = -t10 / determinant1;
    m01 = -t01 / determinant1;
    m11 = t00 / determinant1;
    m02 = (t01 * t12 - t11 * t02) / determinant1;
    m12 = (t10 * t02 - t00 * t12) / determinant1;

    return true;
}


/**
 * @return the determinant of the matrix
 */
public double determinant()
{
    return m00 * m11 - m01 * m10;
}


//////////////////////////////////////////////////////////////





//////////////////////////////////////////////////////////////

// TODO these need to be added as regular API, but the naming and
// implementation needs to be improved first. (e.g. actually keeping track
// of whether the matrix is in fact identity internally.)


protected bool isIdentity()
{
    return ((m00 == 1) && (m01 == 0) && (m02 == 0) &&
            (m10 == 0) && (m11 == 1) && (m12 == 0));
}


// TODO make this more efficient, or move into PMatrix2D
protected bool isWarped()
{
    return ((m00 != 1) || (m01 != 0) &&
            (m10 != 0) || (m11 != 1));
}


//////////////////////////////////////////////////////////////


static private  double max(double a, double b)
{
    return (a > b) ? a : b;
}

static private  double abs(double a)
{
    return (a < 0) ? -a : a;
}

static private  double sin(double angle)
{
    return (double)Math.Sin(angle);
}

static private  double cos(double angle)
{
    return (double)Math.Cos(angle);
}

static private  double tan(double angle)
{
    return (double)Math.Tan(angle);
}
}
