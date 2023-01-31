using UnityEngine;

public class PMatrix2D
{

  public float m00, m01, m02;
public float m10, m11, m12;


/**
 * Create a new matrix, set to the identity matrix.
 */
public PMatrix2D()
{
    reset();
}


public PMatrix2D(float m00, float m01, float m02,
                 float m10, float m11, float m12)
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
 * Copies the matrix contents into a 6 entry float array.
 * If target is null (or not the correct size), a new array will be created.
 * Returned in the order {@code {m00, m01, m02, m10, m11, m12}}.
 */
public float[] get(float[] target)
{
    if ((target == null) || (target.Length != 6))
    {
        target = new float[6];
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


public void set(float[] source)
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
public void set(float m00, float m01, float m02,
                float m10, float m11, float m12)
{
    this.m00 = m00; this.m01 = m01; this.m02 = m02;
    this.m10 = m10; this.m11 = m11; this.m12 = m12;
}


/**
 * Unavailable in 2D. Does nothing.
 */
public void set(float m00, float m01, float m02, float m03,
                float m10, float m11, float m12, float m13,
                float m20, float m21, float m22, float m23,
                float m30, float m31, float m32, float m33)
{

}


public void translate(float tx, float ty)
{
    m02 = tx * m00 + ty * m01 + m02;
    m12 = tx * m10 + ty * m11 + m12;
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void translate(float x, float y, float z)
{
    
}


// Implementation roughly based on AffineTransform.
public void rotate(float angle)
{
    float s = sin(angle);
    float c = cos(angle);

    float temp1 = m00;
    float temp2 = m01;
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
public void rotateX(float angle)
{
    
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void rotateY(float angle)
{
    
}


public void rotateZ(float angle)
{
    rotate(angle);
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void rotate(float angle, float v0, float v1, float v2)
{
    
}


public void scale(float s)
{
    scale(s, s);
}


public void scale(float sx, float sy)
{
    m00 *= sx; m01 *= sy;
    m10 *= sx; m11 *= sy;
}


/**
 * Unavailable in 2D.
 * @throws IllegalArgumentException
 */
public void scale(float x, float y, float z)
{
    
}


public void shearX(float angle)
{
    apply(1, 0, 1, tan(angle), 0, 0);
}


public void shearY(float angle)
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


public void apply(float n00, float n01, float n02,
                  float n10, float n11, float n12)
{
    float t0 = m00;
    float t1 = m01;
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
public void apply(float n00, float n01, float n02, float n03,
                  float n10, float n11, float n12, float n13,
                  float n20, float n21, float n22, float n23,
                  float n30, float n31, float n32, float n33)
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



public void preApply(float n00, float n01, float n02,
                     float n10, float n11, float n12)
{
    float t0 = m02;
    float t1 = m12;
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
public void preApply(float n00, float n01, float n02, float n03,
                     float n10, float n11, float n12, float n13,
                     float n20, float n21, float n22, float n23,
                     float n30, float n31, float n32, float n33)
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
 * If out is null or not length four, a new float array will be returned.
 * The values for vec and out can be the same (though that's less efficient).
 */
public float[] mult(float[] vec, float[] out1)
{
    if (out1 == null || out1.Length != 2) {
      out1 = new float[2];
}

if (vec == out1) {
    float tx = m00 * vec[0] + m01 * vec[1] + m02;
    float ty = m10 * vec[0] + m11 * vec[1] + m12;

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
  public float multX(float x, float y)
{
    return m00 * x + m01 * y + m02;
}


/**
 * Returns the y-coordinate of the result of multiplying the point (x, y)
 * by this matrix.
 */
public float multY(float x, float y)
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
    float determinant1 = determinant();
    if (Mathf.Abs(determinant1) <= float.MinValue)
    {
        return false;
    }

    float t00 = m00;
    float t01 = m01;
    float t02 = m02;
    float t10 = m10;
    float t11 = m11;
    float t12 = m12;

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
public float determinant()
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


static private  float max(float a, float b)
{
    return (a > b) ? a : b;
}

static private  float abs(float a)
{
    return (a < 0) ? -a : a;
}

static private  float sin(float angle)
{
    return (float)Mathf.Sin(angle);
}

static private  float cos(float angle)
{
    return (float)Mathf.Cos(angle);
}

static private  float tan(float angle)
{
    return (float)Mathf.Tan(angle);
}
}
