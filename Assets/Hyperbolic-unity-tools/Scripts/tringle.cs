using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

using Unity.Mathematics;
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
[System.Serializable]
public class PVector
{
  /**
   * ( begin auto-generated from PVector_x.xml )
   *
   * The x component of the vector. This field (variable) can be used to both
   * get and set the value (see above example.)
   *
   * ( end auto-generated )
   *
   * @webref pvector:field
   * @usage web_application
   * @brief The x component of the vector
   */
  public float x;

/**
 * ( begin auto-generated from PVector_y.xml )
 *
 * The y component of the vector. This field (variable) can be used to both
 * get and set the value (see above example.)
 *
 * ( end auto-generated )
 *
 * @webref pvector:field
 * @usage web_application
 * @brief The y component of the vector
 */
public float y;

/**
 * ( begin auto-generated from PVector_z.xml )
 *
 * The z component of the vector. This field (variable) can be used to both
 * get and set the value (see above example.)
 *
 * ( end auto-generated )
 *
 * @webref pvector:field
 * @usage web_application
 * @brief The z component of the vector
 */
public float z;

/** Array so that this can be temporarily used in an array context */
protected float[] array;


/**
 * Constructor for an empty vector: x, y, and z are set to 0.
 */
public PVector()
{
}


/**
 * Constructor for a 3D vector.
 *
 * @param  x the x coordinate.
 * @param  y the y coordinate.
 * @param  z the z coordinate.
 */
public PVector(float x, float y, float z)
{
    this.x = x;
    this.y = y;
    this.z = z;
}


/**
 * Constructor for a 2D vector: z coordinate is set to 0.
 */
public PVector(float x, float y)
{
    this.x = x;
    this.y = y;
}


/**
 * ( begin auto-generated from PVector_set.xml )
 *
 * Sets the x, y, and z component of the vector using two or three separate
 * variables, the data from a PVector, or the values from a float array.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @param x the x component of the vector
 * @param y the y component of the vector
 * @param z the z component of the vector
 * @brief Set the components of the vector
 */
public PVector set(float x, float y, float z)
{
    this.x = x;
    this.y = y;
    this.z = z;
    return this;
}


/**
 * @param x the x component of the vector
 * @param y the y component of the vector
 */
public PVector set(float x, float y)
{
    this.x = x;
    this.y = y;
    this.z = 0;
    return this;
}


/**
 * @param v any variable of type PVector
 */
public PVector set(PVector v)
{
    x = v.x;
    y = v.y;
    z = v.z;
    return this;
}


/**
 * Set the x, y (and maybe z) coordinates using a float[] array as the source.
 * @param source array to copy from
 */
public PVector set(float[] source)
{
    if (source.Length >= 2)
    {
        x = source[0];
        y = source[1];
    }
    if (source.Length >= 3)
    {
        z = source[2];
    }
    else
    {
        z = 0;
    }
    return this;
}


/**
 * ( begin auto-generated from PVector_random2D.xml )
 *
 * Make a new 2D unit vector with a random direction.  If you pass in "this"
 * as an argument, it will use the PApplet's random number generator.  You can
 * also pass in a target PVector to fill.
 *
 * @webref pvector:method
 * @usage web_application
 * @return the random PVector
 * @brief Make a new 2D unit vector with a random direction.
 * @see PVector#random3D()
 */



/**
 * Make a new 2D unit vector with a random direction
 * using Processing's current random number generator
 * @param parent current PApplet instance
 * @return the random PVector
 */

/**
 * Set a 2D vector to a random unit vector with a random direction
 * @param target the target vector (if null, a new vector will be created)
 * @return the random PVector
 */



/**
 * Make a new 2D unit vector with a random direction. Pass in the parent
 * PApplet if you want randomSeed() to work (and be predictable). Or leave
 * it null and be... random.
 * @return the random PVector
 */

/**
 * ( begin auto-generated from PVector_random3D.xml )
 *
 * Make a new 3D unit vector with a random direction.  If you pass in "this"
 * as an argument, it will use the PApplet's random number generator.  You can
 * also pass in a target PVector to fill.
 *
 * @webref pvector:method
 * @usage web_application
 * @return the random PVector
 * @brief Make a new 3D unit vector with a random direction.
 * @see PVector#random2D()
 */



/**
 * Make a new 3D unit vector with a random direction
 * using Processing's current random number generator
 * @param parent current PApplet instance
 * @return the random PVector
 */



/**
 * Set a 3D vector to a random unit vector with a random direction
 * @param target the target vector (if null, a new vector will be created)
 * @return the random PVector
 */



/**
 * Make a new 3D unit vector with a random direction
 * @return the random PVector
 */



/**
 * ( begin auto-generated from PVector_sub.xml )
 *
 * Make a new 2D unit vector from an angle.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @brief Make a new 2D unit vector from an angle
 * @param angle the angle in radians
 * @return the new unit PVector
 */
static public PVector fromAngle(float angle)
{
    return fromAngle(angle, null);
}


/**
 * Make a new 2D unit vector from an angle
 *
 * @param target the target vector (if null, a new vector will be created)
 * @return the PVector
 */
static public PVector fromAngle(float angle, PVector target)
{
    if (target == null)
    {
        target = new PVector((float)Mathf.Cos(angle), (float)Mathf.Sin(angle), 0);
    }
    else
    {
        target.set((float)Mathf.Cos(angle), (float)Mathf.Sin(angle), 0);
    }
    return target;
}


/**
 * ( begin auto-generated from PVector_copy.xml )
 *
 * Gets a copy of the vector, returns a PVector object.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @brief Get a copy of the vector
 */
public PVector copy()
{
    return new PVector(x, y, z);
}



  public PVector get()
{
    return copy();
}


/**
 * @param target
 */
public float[] get(float[] target)
{
    if (target == null)
    {
        return new float[] { x, y, z };
    }
    if (target.Length >= 2)
    {
        target[0] = x;
        target[1] = y;
    }
    if (target.Length >= 3)
    {
        target[2] = z;
    }
    return target;
}


/**
 * ( begin auto-generated from PVector_mag.xml )
 *
 * Calculates the magnitude (length) of the vector and returns the result
 * as a float (this is simply the equation <em>sqrt(x*x + y*y + z*z)</em>.)
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @brief Calculate the magnitude of the vector
 * @return magnitude (length) of the vector
 * @see PVector#magSq()
 */
public float mag()
{
    return (float)Mathf.Sqrt(x * x + y * y + z * z);
}


/**
 * ( begin auto-generated from PVector_mag.xml )
 *
 * Calculates the squared magnitude of the vector and returns the result
 * as a float (this is simply the equation <em>(x*x + y*y + z*z)</em>.)
 * Faster if the real length is not required in the
 * case of comparing vectors, etc.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @brief Calculate the magnitude of the vector, squared
 * @return squared magnitude of the vector
 * @see PVector#mag()
 */
public float magSq()
{
    return (x * x + y * y + z * z);
}


/**
 * ( begin auto-generated from PVector_add.xml )
 *
 * Adds x, y, and z components to a vector, adds one vector to another, or
 * adds two independent vectors together. The version of the method that
 * adds two vectors together is a static method and returns a PVector, the
 * others have no return value -- they act directly on the vector. See the
 * examples for more context.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @param v the vector to be added
 * @brief Adds x, y, and z components to a vector, one vector to another, or two independent vectors
 */
public PVector add(PVector v)
{
    x += v.x;
    y += v.y;
    z += v.z;
    return this;
}


/**
 * @param x x component of the vector
 * @param y y component of the vector
 */
public PVector add(float x, float y)
{
    this.x += x;
    this.y += y;
    return this;
}


/**
 * @param z z component of the vector
 */
public PVector add(float x, float y, float z)
{
    this.x += x;
    this.y += y;
    this.z += z;
    return this;
}


/**
 * Add two vectors
 * @param v1 a vector
 * @param v2 another vector
 */
static public PVector add(PVector v1, PVector v2)
{
    return add(v1, v2, null);
}


/**
 * Add two vectors into a target vector
 * @param target the target vector (if null, a new vector will be created)
 */
static public PVector add(PVector v1, PVector v2, PVector target)
{
    if (target == null)
    {
        target = new PVector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    }
    else
    {
        target.set(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    }
    return target;
}


/**
 * ( begin auto-generated from PVector_sub.xml )
 *
 * Subtracts x, y, and z components from a vector, subtracts one vector
 * from another, or subtracts two independent vectors. The version of the
 * method that subtracts two vectors is a static method and returns a
 * PVector, the others have no return value -- they act directly on the
 * vector. See the examples for more context.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @param v any variable of type PVector
 * @brief Subtract x, y, and z components from a vector, one vector from another, or two independent vectors
 */
public PVector sub(PVector v)
{
    x -= v.x;
    y -= v.y;
    z -= v.z;
    return this;
}


/**
 * @param x the x component of the vector
 * @param y the y component of the vector
 */
public PVector sub(float x, float y)
{
    this.x -= x;
    this.y -= y;
    return this;
}


/**
 * @param z the z component of the vector
 */
public PVector sub(float x, float y, float z)
{
    this.x -= x;
    this.y -= y;
    this.z -= z;
    return this;
}


/**
 * Subtract one vector from another
 * @param v1 the x, y, and z components of a PVector object
 * @param v2 the x, y, and z components of a PVector object
 */
static public PVector sub(PVector v1, PVector v2)
{
    return sub(v1, v2, null);
}


/**
 * Subtract one vector from another and store in another vector
 * @param target PVector in which to store the result
 */
static public PVector sub(PVector v1, PVector v2, PVector target)
{
    if (target == null)
    {
        target = new PVector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
    }
    else
    {
        target.set(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
    }
    return target;
}


/**
 * ( begin auto-generated from PVector_mult.xml )
 *
 * Multiplies a vector by a scalar or multiplies one vector by another.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @brief Multiply a vector by a scalar
 * @param n the number to multiply with the vector
 */
public PVector mult(float n)
{
    x *= n;
    y *= n;
    z *= n;
    return this;
}


/**
 * @param v the vector to multiply by the scalar
 */
static public PVector mult(PVector v, float n)
{
    return mult(v, n, null);
}


/**
 * Multiply a vector by a scalar, and write the result into a target PVector.
 * @param target PVector in which to store the result
 */
static public PVector mult(PVector v, float n, PVector target)
{
    if (target == null)
    {
        target = new PVector(v.x * n, v.y * n, v.z * n);
    }
    else
    {
        target.set(v.x * n, v.y * n, v.z * n);
    }
    return target;
}


/**
 * ( begin auto-generated from PVector_div.xml )
 *
 * Divides a vector by a scalar or divides one vector by another.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @brief Divide a vector by a scalar
 * @param n the number by which to divide the vector
 */
public PVector div(float n)
{
    x /= n;
    y /= n;
    z /= n;
    return this;
}


/**
 * Divide a vector by a scalar and return the result in a new vector.
 * @param v the vector to divide by the scalar
 * @return a new vector that is v1 / n
 */
static public PVector div(PVector v, float n)
{
    return div(v, n, null);
}


/**
 * Divide a vector by a scalar and store the result in another vector.
 * @param target PVector in which to store the result
 */
static public PVector div(PVector v, float n, PVector target)
{
    if (target == null)
    {
        target = new PVector(v.x / n, v.y / n, v.z / n);
    }
    else
    {
        target.set(v.x / n, v.y / n, v.z / n);
    }
    return target;
}


/**
 * ( begin auto-generated from PVector_dist.xml )
 *
 * Calculates the Euclidean distance between two points (considering a
 * point as a vector object).
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @param v the x, y, and z coordinates of a PVector
 * @brief Calculate the distance between two points
 */
public float dist(PVector v)
{
    float dx = x - v.x;
    float dy = y - v.y;
    float dz = z - v.z;
    return (float)Mathf.Sqrt(dx * dx + dy * dy + dz * dz);
}


/**
 * @param v1 any variable of type PVector
 * @param v2 any variable of type PVector
 * @return the Euclidean distance between v1 and v2
 */
static public float dist(PVector v1, PVector v2)
{
    float dx = v1.x - v2.x;
    float dy = v1.y - v2.y;
    float dz = v1.z - v2.z;
    return (float)Mathf.Sqrt(dx * dx + dy * dy + dz * dz);
}


/**
 * ( begin auto-generated from PVector_dot.xml )
 *
 * Calculates the dot product of two vectors.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @param v any variable of type PVector
 * @return the dot product
 * @brief Calculate the dot product of two vectors
 */
public float dot(PVector v)
{
    return x * v.x + y * v.y + z * v.z;
}


/**
 * @param x x component of the vector
 * @param y y component of the vector
 * @param z z component of the vector
 */
public float dot(float x, float y, float z)
{
    return this.x * x + this.y * y + this.z * z;
}


/**
 * @param v1 any variable of type PVector
 * @param v2 any variable of type PVector
 */
static public float dot(PVector v1, PVector v2)
{
    return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
}


/**
 * ( begin auto-generated from PVector_cross.xml )
 *
 * Calculates and returns a vector composed of the cross product between
 * two vectors.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @param v the vector to calculate the cross product
 * @brief Calculate and return the cross product
 */
public PVector cross(PVector v)
{
    return cross(v, null);
}


/**
 * @param v any variable of type PVector
 * @param target PVector to store the result
 */
public PVector cross(PVector v, PVector target)
{
    float crossX = y * v.z - v.y * z;
    float crossY = z * v.x - v.z * x;
    float crossZ = x * v.y - v.x * y;

    if (target == null)
    {
        target = new PVector(crossX, crossY, crossZ);
    }
    else
    {
        target.set(crossX, crossY, crossZ);
    }
    return target;
}


/**
 * @param v1 any variable of type PVector
 * @param v2 any variable of type PVector
 * @param target PVector to store the result
 */
static public PVector cross(PVector v1, PVector v2, PVector target)
{
    float crossX = v1.y * v2.z - v2.y * v1.z;
    float crossY = v1.z * v2.x - v2.z * v1.x;
    float crossZ = v1.x * v2.y - v2.x * v1.y;

    if (target == null)
    {
        target = new PVector(crossX, crossY, crossZ);
    }
    else
    {
        target.set(crossX, crossY, crossZ);
    }
    return target;
}


/**
 * ( begin auto-generated from PVector_normalize.xml )
 *
 * Normalize the vector to length 1 (make it a unit vector).
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @brief Normalize the vector to a length of 1
 */
public PVector normalize()
{
    float m = mag();
    if (m != 0 && m != 1)
    {
        div(m);
    }
    return this;
}


/**
 * @param target Set to null to create a new vector
 * @return a new vector (if target was null), or target
 */
public PVector normalize(PVector target)
{
    if (target == null)
    {
        target = new PVector();
    }
    float m = mag();
    if (m > 0)
    {
        target.set(x / m, y / m, z / m);
    }
    else
    {
        target.set(x, y, z);
    }
    return target;
}


/**
 * ( begin auto-generated from PVector_limit.xml )
 *
 * Limit the magnitude of this vector to the value used for the <b>max</b> parameter.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @param max the maximum magnitude for the vector
 * @brief Limit the magnitude of the vector
 */
public PVector limit(float max)
{
    if (magSq() > max * max)
    {
        normalize();
        mult(max);
    }
    return this;
}


/**
 * ( begin auto-generated from PVector_setMag.xml )
 *
 * Set the magnitude of this vector to the value used for the <b>len</b> parameter.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @param len the new length for this vector
 * @brief Set the magnitude of the vector
 */
public PVector setMag(float len)
{
    normalize();
    mult(len);
    return this;
}


/**
 * Sets the magnitude of this vector, storing the result in another vector.
 * @param target Set to null to create a new vector
 * @param len the new length for the new vector
 * @return a new vector (if target was null), or target
 */
public PVector setMag(PVector target, float len)
{
    target = normalize(target);
    target.mult(len);
    return target;
}


/**
 * ( begin auto-generated from PVector_setMag.xml )
 *
 * Calculate the angle of rotation for this vector (only 2D vectors)
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @return the angle of rotation
 * @brief Calculate the angle of rotation for this vector
 */
public float heading()
{
    float angle = (float)Mathf.Atan2(y, x);
    return angle;
}



  public float heading2D()
{
    return heading();
}


/**
 * ( begin auto-generated from PVector_rotate.xml )
 *
 * Rotate the vector by an angle (only 2D vectors), magnitude remains the same
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @brief Rotate the vector by an angle (2D only)
 * @param theta the angle of rotation
 */


/**
 * ( begin auto-generated from PVector_rotate.xml )
 *
 * Linear interpolate the vector to another vector
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @brief Linear interpolate the vector to another vector
 * @param v the vector to lerp to
 * @param amt  The amount of interpolation; some value between 0.0 (old vector) and 1.0 (new vector). 0.1 is very near the old vector; 0.5 is halfway in between.
 * @see PApplet#lerp(float, float, float)
 */



/**
 * Linear interpolate between two vectors (returns a new PVector object)
 * @param v1 the vector to start from
 * @param v2 the vector to lerp to
 */



/**
 * Linear interpolate the vector to x,y,z values
 * @param x the x component to lerp to
 * @param y the y component to lerp to
 * @param z the z component to lerp to
 */



/**
 * ( begin auto-generated from PVector_angleBetween.xml )
 *
 * Calculates and returns the angle (in radians) between two vectors.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @param v1 the x, y, and z components of a PVector
 * @param v2 the x, y, and z components of a PVector
 * @brief Calculate and return the angle between two vectors
 */




public string tostring()
{
    return "[ " + x + ", " + y + ", " + z + " ]";
}


/**
 * ( begin auto-generated from PVector_array.xml )
 *
 * Return a representation of this vector as a float array. This is only
 * for temporary use. If used in any other fashion, the contents should be
 * copied by using the <b>PVector.get()</b> method to copy into your own array.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage: web_application
 * @brief Return a representation of the vector as a float array
 */







  
  public int hashCode()
{
    int result = 1;
    result = 31 * result + Mathf.FloorToInt(x);
    result = 31 * result + Mathf.FloorToInt(y);
    result = 31 * result + Mathf.FloorToInt(z);
    return result;
}
}
public interface PConstants
{

    static public  int X = 0;
    static public  int Y = 1;
    static public  int Z = 2;


    // renderers known to processing.core

    /*
    // List of renderers used inside PdePreprocessor
    static  stringList rendererList = new stringList(new string[] {
      "JAVA2D", "JAVA2D_2X",
      "P2D", "P2D_2X", "P3D", "P3D_2X", "OPENGL",
      "E2D", "FX2D", "FX2D_2X",  // experimental
      "LWJGL.P2D", "LWJGL.P3D",  // hmm
      "PDF"  // no DXF because that's only for beginRaw()
    });
    */

    static  string JAVA2D = "processing.awt.PGraphicsJava2D";

  static  string P2D = "processing.opengl.PGraphics2D";
  static  string P3D = "processing.opengl.PGraphics3D";

  // When will it be time to remove this?
  
  static  string OPENGL = P3D;

  // Experimental, higher-performance Java 2D renderer (but no pixel ops)
//  static  string E2D = PGraphicsDanger2D.class.getName();

  // Experimental JavaFX renderer; even better 2D performance
  static  string FX2D = "processing.javafx.PGraphicsFX2D";

  static  string PDF = "processing.pdf.PGraphicsPDF";
  static  string SVG = "processing.svg.PGraphicsSVG";
  static  string DXF = "processing.dxf.RawDXF";

  // platform IDs for PApplet.platform

  static  int OTHER = 0;
    static  int WINDOWS = 1;
    static  int MACOSX = 2;
    static  int LINUX = 3;

    static  string[] platformNames = {
    "other", "windows", "macosx", "linux"
  };


  static  float EPSILON = 0.0001f;


    // max/min values for numbers

    /**
     * Same as Float.MAX_VALUE, but included for parity with MIN_VALUE,
     * and to avoid teaching static methods on the first day.
     */
    static  float MAX_FLOAT = float.MaxValue;
    /**
     * Note that Float.MIN_VALUE is the smallest <EM>positive</EM> value
     * for a floating point number, not actually the minimum (negative) value
     * for a float. This constant equals 0xFF7FFFFF, the smallest (farthest
     * negative) value a float can have before it hits NaN.
     */
    static  float MIN_FLOAT = -float.MaxValue;
    /** Largest possible (positive) integer value */
    static  int MAX_INT = int.MaxValue;
    /** Smallest possible (negative) integer value */
    static  int MIN_INT = int.MinValue;

    // shapes

    static public  int VERTEX = 0;
    static public  int BEZIER_VERTEX = 1;
    static public  int QUADRATIC_VERTEX = 2;
    static public  int CURVE_VERTEX = 3;
    static public  int BREAK = 4;

   
  static public  int QUAD_BEZIER_VERTEX = 2;  // should not have been exposed

    // useful goodness

    /**
     * ( begin auto-generated from PI.xml )
     *
     * PI is a mathematical constant with the value 3.14159265358979323846. It
     * is the ratio of the circumference of a circle to its diameter. It is
     * useful in combination with the trigonometric functions <b>sin()</b> and
     * <b>cos()</b>.
     *
     * ( end auto-generated )
     * @webref constants
     * @see PConstants#TWO_PI
     * @see PConstants#TAU
     * @see PConstants#HALF_PI
     * @see PConstants#QUARTER_PI
     *
     */
    static  float PI = (float)Mathf.PI;
    /**
     * ( begin auto-generated from HALF_PI.xml )
     *
     * HALF_PI is a mathematical constant with the value
     * 1.57079632679489661923. It is half the ratio of the circumference of a
     * circle to its diameter. It is useful in combination with the
     * trigonometric functions <b>sin()</b> and <b>cos()</b>.
     *
     * ( end auto-generated )
     * @webref constants
     * @see PConstants#PI
     * @see PConstants#TWO_PI
     * @see PConstants#TAU
     * @see PConstants#QUARTER_PI
     */
    static  float HALF_PI = (float)(Mathf.PI / 2.0);
    static  float THIRD_PI = (float)(Mathf.PI / 3.0);
    /**
     * ( begin auto-generated from QUARTER_PI.xml )
     *
     * QUARTER_PI is a mathematical constant with the value 0.7853982. It is
     * one quarter the ratio of the circumference of a circle to its diameter.
     * It is useful in combination with the trigonometric functions
     * <b>sin()</b> and <b>cos()</b>.
     *
     * ( end auto-generated )
     * @webref constants
     * @see PConstants#PI
     * @see PConstants#TWO_PI
     * @see PConstants#TAU
     * @see PConstants#HALF_PI
     */
    static  float QUARTER_PI = (float)(Mathf.PI / 4.0);
    /**
     * ( begin auto-generated from TWO_PI.xml )
     *
     * TWO_PI is a mathematical constant with the value 6.28318530717958647693.
     * It is twice the ratio of the circumference of a circle to its diameter.
     * It is useful in combination with the trigonometric functions
     * <b>sin()</b> and <b>cos()</b>.
     *
     * ( end auto-generated )
     * @webref constants
     * @see PConstants#PI
     * @see PConstants#TAU
     * @see PConstants#HALF_PI
     * @see PConstants#QUARTER_PI
     */
    static  float TWO_PI = (float)(2.0 * Mathf.PI);
    /**
     * ( begin auto-generated from TAU.xml )
     *
     * TAU is an alias for TWO_PI, a mathematical constant with the value
     * 6.28318530717958647693. It is twice the ratio of the circumference
     * of a circle to its diameter. It is useful in combination with the
     * trigonometric functions <b>sin()</b> and <b>cos()</b>.
     *
     * ( end auto-generated )
     * @webref constants
     * @see PConstants#PI
     * @see PConstants#TWO_PI
     * @see PConstants#HALF_PI
     * @see PConstants#QUARTER_PI
     */
    static  float TAU = (float)(2.0 * Mathf.PI);

    static  float DEG_TO_RAD = PI / 180.0f;
    static  float RAD_TO_DEG = 180.0f / PI;


    // angle modes

    //static  int RADIANS = 0;
    //static  int DEGREES = 1;


    // used by split, all the standard whitespace chars
    // (also includes unicode nbsp, that little bostage)

    static  string WHITESPACE = " \t\n\r\f\u00A0";


  // for colors and/or images

  static  int RGB = 1;  // image & color
    static  int ARGB = 2;  // image
    static  int HSB = 3;  // color
    static  int ALPHA = 4;  // image
                                 //  static  int CMYK  = 5;  // image & color (someday)


    // image file types

    static  int TIFF = 0;
    static  int TARGA = 1;
    static  int JPEG = 2;
    static  int GIF = 3;


    // filter/convert types

    static  int BLUR = 11;
    static  int GRAY = 12;
    static  int INVERT = 13;
    static  int OPAQUE = 14;
    static  int POSTERIZE = 15;
    static  int THRESHOLD = 16;
    static  int ERODE = 17;
    static  int DILATE = 18;


    // blend mode keyword definitions
    // @see processing.core.PImage#blendColor(int,int,int)

    public  static int REPLACE = 0;
    public  static int BLEND = 1 << 0;
    public  static int ADD = 1 << 1;
    public  static int SUBTRACT = 1 << 2;
    public  static int LIGHTEST = 1 << 3;
    public  static int DARKEST = 1 << 4;
    public  static int DIFFERENCE = 1 << 5;
    public  static int EXCLUSION = 1 << 6;
    public  static int MULTIPLY = 1 << 7;
    public  static int SCREEN = 1 << 8;
    public  static int OVERLAY = 1 << 9;
    public  static int HARD_LIGHT = 1 << 10;
    public  static int SOFT_LIGHT = 1 << 11;
    public  static int DODGE = 1 << 12;
    public  static int BURN = 1 << 13;

    // for messages

    static  int CHATTER = 0;
    static  int COMPLAINT = 1;
    static  int PROBLEM = 2;


    // types of transformation matrices

    static  int PROJECTION = 0;
    static  int MODELVIEW = 1;

    // types of projection matrices

    static  int CUSTOM = 0; // user-specified fanciness
    static  int ORTHOGRAPHIC = 2; // 2D isometric projection
    static  int PERSPECTIVE = 3; // perspective matrix


    // shapes

    // the low four bits set the variety,
    // higher bits set the specific shape type

    static  int GROUP = 0;   // createShape()

    static  int POINT = 2;   // primitive
    static  int POINTS = 3;   // vertices

    static  int LINE = 4;   // primitive
    static  int LINES = 5;   // beginShape(), createShape()
    static  int LINE_STRIP = 50;  // beginShape()
    static  int LINE_LOOP = 51;

    static  int TRIANGLE = 8;   // primitive
    static  int TRIANGLES = 9;   // vertices
    static  int TRIANGLE_STRIP = 10;  // vertices
    static  int TRIANGLE_FAN = 11;  // vertices

    static  int QUAD = 16;  // primitive
    static  int QUADS = 17;  // vertices
    static  int QUAD_STRIP = 18;  // vertices

    static  int POLYGON = 20;  // in the end, probably cannot
    static  int PATH = 21;  // separate these two

    static  int RECT = 30;  // primitive
    static  int ELLIPSE = 31;  // primitive
    static  int ARC = 32;  // primitive

    static  int SPHERE = 40;  // primitive
    static  int BOX = 41;  // primitive

    //  static public  int POINT_SPRITES = 52;
    //  static public  int NON_STROKED_SHAPE = 60;
    //  static public  int STROKED_SHAPE     = 61;


    // shape closing modes

    static  int OPEN = 1;
    static  int CLOSE = 2;


    // shape drawing modes

    /** Draw mode convention to use (x, y) to (width, height) */
    static  int CORNER = 0;
    /** Draw mode convention to use (x1, y1) to (x2, y2) coordinates */
    static  int CORNERS = 1;
    /** Draw mode from the center, and using the radius */
    static  int RADIUS = 2;
    /**
     * Draw from the center, using second pair of values as the diameter.
     * Formerly called CENTER_DIAMETER in alpha releases.
     */
    static  int CENTER = 3;
    /**
     * Synonym for the CENTER constant. Draw from the center,
     * using second pair of values as the diameter.
     */
    static  int DIAMETER = 3;


    // arc drawing modes

    //static  int OPEN = 1;  // shared
    static  int CHORD = 2;
    static  int PIE = 3;


    // vertically alignment modes for text

    /** Default vertical alignment for text placement */
    static  int BASELINE = 0;
    /** Align text to the top */
    static  int TOP = 101;
    /** Align text from the bottom, using the baseline. */
    static  int BOTTOM = 102;


    // uv texture orientation modes

    /** texture coordinates in 0..1 range */
    static  int NORMAL = 1;
    /** texture coordinates based on image width/height */
    static  int IMAGE = 2;


    // texture wrapping modes

    /** textures are clamped to their edges */
    public static  int CLAMP = 0;
    /** textures wrap around when uv values go outside 0..1 range */
    public static  int REPEAT = 1;


    // text placement modes

    /**
     * textMode(MODEL) is the default, meaning that characters
     * will be affected by transformations like any other shapes.
     * <p/>
     * Changed value in 0093 to not interfere with LEFT, CENTER, and RIGHT.
     */
    static  int MODEL = 4;

    /**
     * textMode(SHAPE) draws text using the the glyph outlines of
     * individual characters rather than as textures. If the outlines are
     * not available, then textMode(SHAPE) will be ignored and textMode(MODEL)
     * will be used instead. For this reason, be sure to call textMode()
     * <EM>after</EM> calling textFont().
     * <p/>
     * Currently, textMode(SHAPE) is only supported by OPENGL mode.
     * It also requires Java 1.2 or higher (OPENGL requires 1.4 anyway)
     */
    static  int SHAPE = 5;


    // text alignment modes
    // are inherited from LEFT, CENTER, RIGHT

    // stroke modes

    static  int SQUARE = 1 << 0;  // called 'butt' in the svg spec
    static  int ROUND = 1 << 1;
    static  int PROJECT = 1 << 2;  // called 'square' in the svg spec
    static  int MITER = 1 << 3;
    static  int BEVEL = 1 << 5;


    // lighting

    static  int AMBIENT = 0;
    static  int DIRECTIONAL = 1;
    //static  int POINT  = 2;  // shared with shape feature
    static  int SPOT = 3;


    // key constants

    // only including the most-used of these guys
    // if people need more esoteric keys, they can learn about
    // the esoteric java KeyEvent api and of virtual keys

    // both key and keyCode will equal these values
    // for 0125, these were changed to 'char' values, because they
    // can be upgraded to ints automatically by Java, but having them
    // as ints prevented split(blah, TAB) from working
    static  int BACKSPACE = 8;
    static int TAB = 9;
    static int ENTER = 10;
    static int RETURN = 13;
    static int ESC = 27;
    static int DELETE = 127;

    // i.e. if ((key == CODED) && (keyCode == UP))
    static  int CODED = 0xffff;

    // key will be CODED and keyCode will be this value
    static  int UP = 1;
    static  int DOWN = -1;
    static  int LEFT = -1;
    static int RIGHT = 1;

    // key will be CODED and keyCode will be this value
    static  int ALT = 1;
    static  int CONTROL = 1;
    static  int SHIFT = 1;


    // orientations (only used on Android, ignored on desktop)

    /** Screen orientation constant for portrait (the hamburger way). */
    static  int PORTRAIT = 1;
    /** Screen orientation constant for landscape (the hot dog way). */
    static  int LANDSCAPE = 2;

    /** Use with fullScreen() to indicate all available displays. */
    static  int SPAN = 0;

    // cursor types

    static  int ARROW = 0;
    static  int CROSS = 0;
    static  int HAND = 0;
    static  int MOVE = 0;
    static  int TEXT = 0;
    static  int WAIT = 0;


    // hints - hint values are positive for the alternate version,
    // negative of the same value returns to the normal/default state

    
  static  int ENABLE_NATIVE_FONTS = 1;
    
  static  int DISABLE_NATIVE_FONTS = -1;

    static  int DISABLE_DEPTH_TEST = 2;
    static  int ENABLE_DEPTH_TEST = -2;

    static  int ENABLE_DEPTH_SORT = 3;
    static  int DISABLE_DEPTH_SORT = -3;

    static  int DISABLE_OPENGL_ERRORS = 4;
    static  int ENABLE_OPENGL_ERRORS = -4;

    static  int DISABLE_DEPTH_MASK = 5;
    static  int ENABLE_DEPTH_MASK = -5;

    static  int DISABLE_OPTIMIZED_STROKE = 6;
    static  int ENABLE_OPTIMIZED_STROKE = -6;

    static  int ENABLE_STROKE_PERSPECTIVE = 7;
    static  int DISABLE_STROKE_PERSPECTIVE = -7;

    static  int DISABLE_TEXTURE_MIPMAPS = 8;
    static  int ENABLE_TEXTURE_MIPMAPS = -8;

    static  int ENABLE_STROKE_PURE = 9;
    static  int DISABLE_STROKE_PURE = -9;

    static  int ENABLE_BUFFER_READING = 10;
    static  int DISABLE_BUFFER_READING = -10;

    static  int DISABLE_KEY_REPEAT = 11;
    static  int ENABLE_KEY_REPEAT = -11;

    static  int DISABLE_ASYNC_SAVEFRAME = 12;
    static  int ENABLE_ASYNC_SAVEFRAME = -12;

    static  int HINT_COUNT = 13;
}


[System.Serializable]
public class PolarTransform
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
    public  PolarTransform()
    {
    }
    public PolarTransform(float dN, float dS, float dM)
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
    public  void applyPolarTransform(PolarTransform pt)
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
    public  void preApplyPolarTransform(PolarTransform pt)
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
    public PolarTransform inverse()
    {
        return new PolarTransform(-m, -s, -n);
    }
    public  float distanceTo(PolarTransform p)
    {
        PolarTransform c = copy();
        c.applyPolarTransform(p.inverse());
        return c.s;
    }
    public PolarTransform copy()
    {
        return new PolarTransform(n, s, m);
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
#region Header

/*
 * Copyright (c) 2003-2004, University of Maryland
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided
 * that the following conditions are met:
 *
 *		Redistributions of source code must retain the above copyright notice, this list of conditions
 *		and the following disclaimer.
 *
 *		Redistributions in binary form must reproduce the above copyright notice, this list of conditions
 *		and the following disclaimer in the documentation and/or other materials provided with the
 *		distribution.
 *
 *		Neither the name of the University of Maryland nor the names of its contributors may be used to
 *		endorse or promote products derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 * PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR
 * TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 * Piccolo was written at the Human-Computer Interaction Laboratory www.cs.umd.edu/hcil by Jesse Grosjean
 * and ported to C# by Aaron Clamage under the supervision of Ben Bederson.  The Piccolo website is
 * www.cs.umd.edu/hcil/piccolo.
 */

#endregion Header

namespace un
{
    using System;
    using System.Drawing;

    /// <summary>
    /// <b>PMatrix</b> defines an affine transform.  The compact .NET framework does not provide
    /// a matrix class.  This class is implemented by storing the scale and offsets rather than
    /// the actual matrix values.  It does not currently support rotation.  And it does not
    /// currently support all of the methods provided by PMatrix in Piccolo.NET.
    /// </summary>
    public class PMatrix : ICloneable
    {
        #region Fields

        private float offsetX;
        private float offsetY;

        //private float scale;
        private float scaleX;
        private float scaleY;

        #endregion Fields

        #region Constructors

        public PMatrix()
        {
            //scale = 1;
            scaleX = 1;
            scaleY = 1;
            offsetX = 0;
            offsetY = 0;
        }

        #endregion Constructors

        #region Properties

        public bool IsInvertible
        {
            //get { return scale != 0; }
            get { return scaleX != 0 && scaleY != 0; }
        }

        public float OffsetX
        {
            get { return offsetX; }
            set { offsetX = value; }
        }

        public float OffsetY
        {
            get { return offsetY; }
            set { offsetY = value; }
        }

        public float Scale
        {
            //get { return scale; }
            //set { scale = value; }
            get
            {
                return scaleX;
                //PointF[] pts = {new PointF(0, 0), new PointF(1, 0)};
                //TransformPoints(pts);
                //return PUtil.DistanceBetweenPoints(pts[0], pts[1]);
            }
            set
            {
                scaleX = value;
                scaleY = value;
                //ScaleBy(value / Scale);
            }
        }

        #endregion Properties

        #region Methods

        public Object Clone()
        {
            PMatrix r = new PMatrix();
            r.Multiply(this);
            return r;
        }

        public override bool Equals(object obj)
        {
            PMatrix otherMatrix = (PMatrix)obj;
            return (offsetX == otherMatrix.offsetX &&
                offsetY == otherMatrix.offsetY &&
                //scale == otherMatrix.scale);
                scaleX == otherMatrix.scaleX &&
                scaleY == otherMatrix.scaleY);
        }

        public override int GetHashCode()
        {
            //return offsetX.GetHashCode() ^ offsetY.GetHashCode() ^ scale.GetHashCode();
            return offsetX.GetHashCode() ^ offsetY.GetHashCode() ^ scaleX.GetHashCode() ^ scaleY.GetHashCode();
        }

        public PointF InverseTransform(PointF point)
        {
            point.X = (1 / scaleX) * (point.X - offsetX);
            point.Y = (1 / scaleY) * (point.Y - offsetY);

            //point.X = (1/scale) * (point.X - offsetX);
            //point.Y = (1/scale) * (point.Y - offsetY);
            return point;
        }

        public SizeF InverseTransform(SizeF size)
        {
            size.Width = (1 / scaleX) * size.Width;
            size.Height = (1 / scaleY) * size.Height;

            //size.Width = (1/scale) * size.Width;
            //size.Height = (1/scale) * size.Height;
            return size;
        }

        public RectangleF InverseTransform(RectangleF rect)
        {
            rect.X = (1 / scaleX) * (rect.X - offsetX);
            rect.Y = (1 / scaleY) * (rect.Y - offsetY);
            rect.Width = (1 / scaleX) * rect.Width;
            rect.Height = (1 / scaleY) * rect.Height;

            //rect.X = (1/scale) * (rect.X - offsetX);
            //rect.Y = (1/scale) * (rect.Y - offsetY);
            //rect.Width = (1/scale) * rect.Width;
            //rect.Height = (1/scale) * rect.Height;
            return rect;
        }

        public void Invert()
        {
            if (IsInvertible)
            {
                //scale = 1 / scale;
                //offsetX = -offsetX * scale;
                //offsetY = -offsetY * scale;

                scaleX = 1 / scaleX;
                scaleY = 1 / scaleY;
                offsetX = -offsetX * scaleX;
                offsetY = -offsetY * scaleY;
            }
        }

        public void Multiply(PMatrix aTransform)
        {
            ScaleBy(aTransform.scaleX, aTransform.scaleY);
            offsetX = aTransform.scaleX * offsetX + aTransform.OffsetX;
            offsetY = aTransform.scaleY * offsetY + aTransform.OffsetY;

            //ScaleBy(aTransform.scale);
            //offsetX = aTransform.scale * offsetX + aTransform.OffsetX;
            //offsetY = aTransform.scale * offsetY + aTransform.OffsetY;
        }

        public void Reset()
        {
            scaleX = 1;
            scaleY = 1;
            //scale = 1;
            offsetX = 0;
            offsetY = 0;
        }

        public void ScaleBy(float scale)
        {
            //this.scale *= scale;
            ScaleBy(scale, scale);
        }

        public void ScaleBy(float scale, float x, float y)
        {
            TranslateBy(x, y);
            //this.scale *= scale;
            ScaleBy(scale);
            TranslateBy(-x, -y);
        }

        public PointF Transform(PointF point)
        {
            point.X = scaleX * point.X + offsetX;
            point.Y = scaleY * point.Y + offsetY;

            //point.X = scale * point.X + offsetX;
            //point.Y = scale * point.Y + offsetY;
            return point;
        }

        public SizeF Transform(SizeF size)
        {
            size.Width = scaleX * size.Width;
            size.Height = scaleY * size.Height;

            //size.Width = scale * size.Width;
            //size.Height = scale * size.Height;
            return size;
        }

        public RectangleF Transform(RectangleF rect)
        {
            rect.X = scaleX * rect.X + offsetX;
            rect.Y = scaleY * rect.Y + offsetY;
            rect.Width = scaleX * rect.Width;
            rect.Height = scaleY * rect.Height;

            //rect.X = scale * rect.X + offsetX;
            //rect.Y = scale * rect.Y + offsetY;
            //rect.Width = scale * rect.Width;
            //rect.Height = scale * rect.Height;
            return rect;
        }

        /// <summary>
        /// Applies the geometric transform represented by this <see cref="PMatrix"/> object to all
        /// of the points in the given array.
        /// <see cref="PMatrix"/>.
        /// </summary>
        /// <param name="pts">The array of points to transform.</param>
        public virtual void TransformPoints(PointF[] pts)
        {
            int count = pts.Length;
            for (int i = 0; i < count; i++)
            {
                pts[i] = this.Transform(pts[i]);
            }
        }

        public void TranslateBy(float dx, float dy)
        {
            offsetX += (scaleX * dx);
            offsetY += (scaleY * dy);

            //offsetX += (scale * dx);
            //offsetY += (scale * dy);
        }

        internal void ScaleBy(float scaleX, float scaleY)
        {
            this.scaleX *= scaleX;
            this.scaleY *= scaleY;
        }

        #endregion Methods
    }
}
public class PMatrix3D  /*, PConstants*/
{

  public float m00, m01, m02, m03;
public float m10, m11, m12, m13;
public float m20, m21, m22, m23;
public float m30, m31, m32, m33;


// locally allocated version to avoid creating new memory
protected PMatrix3D inverseCopy;


public PMatrix3D()
{
    reset();
}


public PMatrix3D(float m00, float m01, float m02,
                 float m10, float m11, float m12)
{
    set(m00, m01, m02, 0,
        m10, m11, m12, 0,
        0, 0, 1, 0,
        0, 0, 0, 1);
}


public PMatrix3D(float m00, float m01, float m02, float m03,
                 float m10, float m11, float m12, float m13,
                 float m20, float m21, float m22, float m23,
                 float m30, float m31, float m32, float m33)
{
    set(m00, m01, m02, m03,
        m10, m11, m12, m13,
        m20, m21, m22, m23,
        m30, m31, m32, m33);
}




public void reset()
{
    set(1, 0, 0, 0,
        0, 1, 0, 0,
        0, 0, 1, 0,
        0, 0, 0, 1);
}


/**
 * Returns a copy of this PMatrix.
 */



/**
 * Copies the matrix contents into a 16 entry float array.
 * If target is null (or not the correct size), a new array will be created.
 */
public float[] get(float[] target)
{
    if ((target == null) || (target.Length != 16))
    {
        target = new float[16];
    }
    target[0] = m00;
    target[1] = m01;
    target[2] = m02;
    target[3] = m03;

    target[4] = m10;
    target[5] = m11;
    target[6] = m12;
    target[7] = m13;

    target[8] = m20;
    target[9] = m21;
    target[10] = m22;
    target[11] = m23;

    target[12] = m30;
    target[13] = m31;
    target[14] = m32;
    target[15] = m33;

    return target;
}




    public void set(PMatrix3D matrix)
    {
        
            PMatrix3D src = (PMatrix3D)matrix;
            set(src.m00, src.m01, src.m02, src.m03,
                src.m10, src.m11, src.m12, src.m13,
                src.m20, src.m21, src.m22, src.m23,
                src.m30, src.m31, src.m32, src.m33);
        
    }
    public void set(float[] source)
{
    if (source.Length == 6)
    {
        set(source[0], source[1], source[2],
            source[3], source[4], source[5]);

    }
    else if (source.Length == 16)
    {
        m00 = source[0];
        m01 = source[1];
        m02 = source[2];
        m03 = source[3];

        m10 = source[4];
        m11 = source[5];
        m12 = source[6];
        m13 = source[7];

        m20 = source[8];
        m21 = source[9];
        m22 = source[10];
        m23 = source[11];

        m30 = source[12];
        m31 = source[13];
        m32 = source[14];
        m33 = source[15];
    }
}


public void set(float m00, float m01, float m02,
                float m10, float m11, float m12)
{
    set(m00, m01, 0, m02,
        m10, m11, 0, m12,
        0, 0, 1, 0,
        0, 0, 0, 1);
}


public void set(float m00, float m01, float m02, float m03,
                float m10, float m11, float m12, float m13,
                float m20, float m21, float m22, float m23,
                float m30, float m31, float m32, float m33)
{
    this.m00 = m00; this.m01 = m01; this.m02 = m02; this.m03 = m03;
    this.m10 = m10; this.m11 = m11; this.m12 = m12; this.m13 = m13;
    this.m20 = m20; this.m21 = m21; this.m22 = m22; this.m23 = m23;
    this.m30 = m30; this.m31 = m31; this.m32 = m32; this.m33 = m33;
}


public void translate(float tx, float ty)
{
    translate(tx, ty, 0);
}

//  public void invTranslate(float tx, float ty) {
//    invTranslate(tx, ty, 0);
//  }


public void translate(float tx, float ty, float tz)
{
    m03 += tx * m00 + ty * m01 + tz * m02;
    m13 += tx * m10 + ty * m11 + tz * m12;
    m23 += tx * m20 + ty * m21 + tz * m22;
    m33 += tx * m30 + ty * m31 + tz * m32;
}


public void rotate(float angle)
{
    rotateZ(angle);
}


public void rotateX(float angle)
{
    float c = cos(angle);
    float s = sin(angle);
    apply(1, 0, 0, 0, 0, c, -s, 0, 0, s, c, 0, 0, 0, 0, 1);
}


public void rotateY(float angle)
{
    float c = cos(angle);
    float s = sin(angle);
    apply(c, 0, s, 0, 0, 1, 0, 0, -s, 0, c, 0, 0, 0, 0, 1);
}


public void rotateZ(float angle)
{
    float c = cos(angle);
    float s = sin(angle);
    apply(c, -s, 0, 0, s, c, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
}


public void rotate(float angle, float v0, float v1, float v2)
{
    float norm2 = v0 * v0 + v1 * v1 + v2 * v2;
    if (norm2 < PConstants.EPSILON)
    {
        // The vector is zero, cannot apply rotation.
        return;
    }

    if (Mathf.Abs(norm2 - 1) > PConstants.EPSILON)
    {
        // The rotation vector is not normalized.
        float norm = Mathf.Sqrt(norm2);
        v0 /= norm;
        v1 /= norm;
        v2 /= norm;
    }

    float c = cos(angle);
    float s = sin(angle);
    float t = 1.0f - c;

    apply((t * v0 * v0) + c, (t * v0 * v1) - (s * v2), (t * v0 * v2) + (s * v1), 0,
          (t * v0 * v1) + (s * v2), (t * v1 * v1) + c, (t * v1 * v2) - (s * v0), 0,
          (t * v0 * v2) - (s * v1), (t * v1 * v2) + (s * v0), (t * v2 * v2) + c, 0,
          0, 0, 0, 1);
}


public void scale(float s)
{
    //apply(s, 0, 0, 0,  0, s, 0, 0,  0, 0, s, 0,  0, 0, 0, 1);
    scale(s, s, s);
}


public void scale(float sx, float sy)
{
    //apply(sx, 0, 0, 0,  0, sy, 0, 0,  0, 0, 1, 0,  0, 0, 0, 1);
    scale(sx, sy, 1);
}


public void scale(float x, float y, float z)
{
    //apply(x, 0, 0, 0,  0, y, 0, 0,  0, 0, z, 0,  0, 0, 0, 1);
    m00 *= x; m01 *= y; m02 *= z;
    m10 *= x; m11 *= y; m12 *= z;
    m20 *= x; m21 *= y; m22 *= z;
    m30 *= x; m31 *= y; m32 *= z;
}


public void shearX(float angle)
{
    float t = (float)Mathf.Tan(angle);
    apply(1, t, 0, 0,
          0, 1, 0, 0,
          0, 0, 1, 0,
          0, 0, 0, 1);
}


public void shearY(float angle)
{
    float t = (float)Mathf.Tan(angle);
    apply(1, 0, 0, 0,
          t, 1, 0, 0,
          0, 0, 1, 0,
          0, 0, 0, 1);
}





  public void apply(PMatrix2D source)
{
    apply(source.m00, source.m01, 0, source.m02,
          source.m10, source.m11, 0, source.m12,
          0, 0, 1, 0,
          0, 0, 0, 1);
}


public void apply(PMatrix3D source)
{
    apply(source.m00, source.m01, source.m02, source.m03,
          source.m10, source.m11, source.m12, source.m13,
          source.m20, source.m21, source.m22, source.m23,
          source.m30, source.m31, source.m32, source.m33);
}


public void apply(float n00, float n01, float n02,
                  float n10, float n11, float n12)
{
    apply(n00, n01, 0, n02,
          n10, n11, 0, n12,
          0, 0, 1, 0,
          0, 0, 0, 1);
}


public void apply(float n00, float n01, float n02, float n03,
                  float n10, float n11, float n12, float n13,
                  float n20, float n21, float n22, float n23,
                  float n30, float n31, float n32, float n33)
{

    float r00 = m00 * n00 + m01 * n10 + m02 * n20 + m03 * n30;
    float r01 = m00 * n01 + m01 * n11 + m02 * n21 + m03 * n31;
    float r02 = m00 * n02 + m01 * n12 + m02 * n22 + m03 * n32;
    float r03 = m00 * n03 + m01 * n13 + m02 * n23 + m03 * n33;

    float r10 = m10 * n00 + m11 * n10 + m12 * n20 + m13 * n30;
    float r11 = m10 * n01 + m11 * n11 + m12 * n21 + m13 * n31;
    float r12 = m10 * n02 + m11 * n12 + m12 * n22 + m13 * n32;
    float r13 = m10 * n03 + m11 * n13 + m12 * n23 + m13 * n33;

    float r20 = m20 * n00 + m21 * n10 + m22 * n20 + m23 * n30;
    float r21 = m20 * n01 + m21 * n11 + m22 * n21 + m23 * n31;
    float r22 = m20 * n02 + m21 * n12 + m22 * n22 + m23 * n32;
    float r23 = m20 * n03 + m21 * n13 + m22 * n23 + m23 * n33;

    float r30 = m30 * n00 + m31 * n10 + m32 * n20 + m33 * n30;
    float r31 = m30 * n01 + m31 * n11 + m32 * n21 + m33 * n31;
    float r32 = m30 * n02 + m31 * n12 + m32 * n22 + m33 * n32;
    float r33 = m30 * n03 + m31 * n13 + m32 * n23 + m33 * n33;

    m00 = r00; m01 = r01; m02 = r02; m03 = r03;
    m10 = r10; m11 = r11; m12 = r12; m13 = r13;
    m20 = r20; m21 = r21; m22 = r22; m23 = r23;
    m30 = r30; m31 = r31; m32 = r32; m33 = r33;
}


/**
 * Apply the 3D equivalent of the 2D matrix supplied to the left of this one.
 */
public void preApply(PMatrix2D left)
{
    preApply(left.m00, left.m01, 0, left.m02,
             left.m10, left.m11, 0, left.m12,
             0, 0, 1, 0,
             0, 0, 0, 1);
}


/**
 * Apply another matrix to the left of this one.
 */



  /**
   * Apply another matrix to the left of this one.
   */
  public void preApply(PMatrix3D left)
{
    preApply(left.m00, left.m01, left.m02, left.m03,
             left.m10, left.m11, left.m12, left.m13,
             left.m20, left.m21, left.m22, left.m23,
             left.m30, left.m31, left.m32, left.m33);
}


/**
 * Apply the 3D equivalent of the 2D matrix supplied to the left of this one.
 */
public void preApply(float n00, float n01, float n02,
                     float n10, float n11, float n12)
{
    preApply(n00, n01, 0, n02,
             n10, n11, 0, n12,
             0, 0, 1, 0,
             0, 0, 0, 1);
}


/**
 * Apply another matrix to the left of this one.
 */
public void preApply(float n00, float n01, float n02, float n03,
                     float n10, float n11, float n12, float n13,
                     float n20, float n21, float n22, float n23,
                     float n30, float n31, float n32, float n33)
{

    float r00 = n00 * m00 + n01 * m10 + n02 * m20 + n03 * m30;
    float r01 = n00 * m01 + n01 * m11 + n02 * m21 + n03 * m31;
    float r02 = n00 * m02 + n01 * m12 + n02 * m22 + n03 * m32;
    float r03 = n00 * m03 + n01 * m13 + n02 * m23 + n03 * m33;

    float r10 = n10 * m00 + n11 * m10 + n12 * m20 + n13 * m30;
    float r11 = n10 * m01 + n11 * m11 + n12 * m21 + n13 * m31;
    float r12 = n10 * m02 + n11 * m12 + n12 * m22 + n13 * m32;
    float r13 = n10 * m03 + n11 * m13 + n12 * m23 + n13 * m33;

    float r20 = n20 * m00 + n21 * m10 + n22 * m20 + n23 * m30;
    float r21 = n20 * m01 + n21 * m11 + n22 * m21 + n23 * m31;
    float r22 = n20 * m02 + n21 * m12 + n22 * m22 + n23 * m32;
    float r23 = n20 * m03 + n21 * m13 + n22 * m23 + n23 * m33;

    float r30 = n30 * m00 + n31 * m10 + n32 * m20 + n33 * m30;
    float r31 = n30 * m01 + n31 * m11 + n32 * m21 + n33 * m31;
    float r32 = n30 * m02 + n31 * m12 + n32 * m22 + n33 * m32;
    float r33 = n30 * m03 + n31 * m13 + n32 * m23 + n33 * m33;

    m00 = r00; m01 = r01; m02 = r02; m03 = r03;
    m10 = r10; m11 = r11; m12 = r12; m13 = r13;
    m20 = r20; m21 = r21; m22 = r22; m23 = r23;
    m30 = r30; m31 = r31; m32 = r32; m33 = r33;
}


//////////////////////////////////////////////////////////////


/**
 * Multiply source by this matrix, and return the result.
 * The result will be stored in target if target is non-null, and target
 * will then be the matrix returned. This improves performance if you reuse
 * target, so it's recommended if you call this many times in draw().
 */
public PVector mult(PVector source, PVector target)
{
    if (target == null)
    {
        target = new PVector();
    }
    target.set(m00 * source.x + m01 * source.y + m02 * source.z + m03,
               m10 * source.x + m11 * source.y + m12 * source.z + m13,
               m20 * source.x + m21 * source.y + m22 * source.z + m23);
    //    float tw = m30*source.x + m31*source.y + m32*source.z + m33;
    //    if (tw != 0 && tw != 1) {
    //      target.div(tw);
    //    }
    return target;
}


/*
public PVector cmult(PVector source, PVector target) {
  if (target == null) {
    target = new PVector();
  }
  target.x = m00*source.x + m10*source.y + m20*source.z + m30;
  target.y = m01*source.x + m11*source.y + m21*source.z + m31;
  target.z = m02*source.x + m12*source.y + m22*source.z + m32;
  float tw = m03*source.x + m13*source.y + m23*source.z + m33;
  if (tw != 0 && tw != 1) {
    target.div(tw);
  }
  return target;
}
*/


/**
 * Multiply a three or four element vector against this matrix. If out is
 * null or not length 3 or 4, a new float array (length 3) will be returned.
 * Supplying and recycling a target array improves performance, so it's
 * recommended if you call this many times in draw.
 */
public float[] mult(float[] source, float[] target)
{
    if (target == null || target.Length < 3)
    {
        target = new float[3];
    }
    
    if (target.Length == 3)
    {
        target[0] = m00 * source[0] + m01 * source[1] + m02 * source[2] + m03;
        target[1] = m10 * source[0] + m11 * source[1] + m12 * source[2] + m13;
        target[2] = m20 * source[0] + m21 * source[1] + m22 * source[2] + m23;
        //float w = m30*source[0] + m31*source[1] + m32*source[2] + m33;
        //if (w != 0 && w != 1) {
        //  target[0] /= w; target[1] /= w; target[2] /= w;
        //}
    }
    else if (target.Length > 3)
    {
        target[0] = m00 * source[0] + m01 * source[1] + m02 * source[2] + m03 * source[3];
        target[1] = m10 * source[0] + m11 * source[1] + m12 * source[2] + m13 * source[3];
        target[2] = m20 * source[0] + m21 * source[1] + m22 * source[2] + m23 * source[3];
        target[3] = m30 * source[0] + m31 * source[1] + m32 * source[2] + m33 * source[3];
    }
    return target;
}


/**
 * Returns the x-coordinate of the result of multiplying the point (x, y)
 * by this matrix.
 */
public float multX(float x, float y)
{
    return m00 * x + m01 * y + m03;
}


/**
 * Returns the y-coordinate of the result of multiplying the point (x, y)
 * by this matrix.
 */
public float multY(float x, float y)
{
    return m10 * x + m11 * y + m13;
}


/**
 * Returns the x-coordinate of the result of multiplying the point (x, y, z)
 * by this matrix.
 */
public float multX(float x, float y, float z)
{
    return m00 * x + m01 * y + m02 * z + m03;
}


/**
 * Returns the y-coordinate of the result of multiplying the point (x, y, z)
 * by this matrix.
 */
public float multY(float x, float y, float z)
{
    return m10 * x + m11 * y + m12 * z + m13;
}


/**
 * Returns the z-coordinate of the result of multiplying the point (x, y, z)
 * by this matrix.
 */
public float multZ(float x, float y, float z)
{
    return m20 * x + m21 * y + m22 * z + m23;
}


/**
 * Returns the fourth element of the result of multiplying the vector
 * (x, y, z) by this matrix. (Acts as if w = 1 was supplied.)
 */
public float multW(float x, float y, float z)
{
    return m30 * x + m31 * y + m32 * z + m33;
}


/**
 * Returns the x-coordinate of the result of multiplying the vector
 * (x, y, z, w) by this matrix.
 */
public float multX(float x, float y, float z, float w)
{
    return m00 * x + m01 * y + m02 * z + m03 * w;
}


/**
 * Returns the y-coordinate of the result of multiplying the vector
 * (x, y, z, w) by this matrix.
 */
public float multY(float x, float y, float z, float w)
{
    return m10 * x + m11 * y + m12 * z + m13 * w;
}


/**
 * Returns the z-coordinate of the result of multiplying the vector
 * (x, y, z, w) by this matrix.
 */
public float multZ(float x, float y, float z, float w)
{
    return m20 * x + m21 * y + m22 * z + m23 * w;
}


/**
 * Returns the w-coordinate of the result of multiplying the vector
 * (x, y, z, w) by this matrix.
 */
public float multW(float x, float y, float z, float w)
{
    return m30 * x + m31 * y + m32 * z + m33 * w;
}


/**
 * Transpose this matrix; rows become columns and columns rows.
 */
public void transpose()
{
    float temp;
    temp = m01; m01 = m10; m10 = temp;
    temp = m02; m02 = m20; m20 = temp;
    temp = m03; m03 = m30; m30 = temp;
    temp = m12; m12 = m21; m21 = temp;
    temp = m13; m13 = m31; m31 = temp;
    temp = m23; m23 = m32; m32 = temp;
}


/**
 * Invert this matrix. Will not necessarily succeed, because some matrices
 * map more than one point to the same image point, and so are irreversible.
 * @return true if successful
 */
public bool invert()
{
    float determinant1 = determinant();
    if (determinant1 == 0)
    {
        return false;
    }

    // first row
    float t00 = determinant3x3(m11, m12, m13, m21, m22, m23, m31, m32, m33);
    float t01 = -determinant3x3(m10, m12, m13, m20, m22, m23, m30, m32, m33);
    float t02 = determinant3x3(m10, m11, m13, m20, m21, m23, m30, m31, m33);
    float t03 = -determinant3x3(m10, m11, m12, m20, m21, m22, m30, m31, m32);

    // second row
    float t10 = -determinant3x3(m01, m02, m03, m21, m22, m23, m31, m32, m33);
    float t11 = determinant3x3(m00, m02, m03, m20, m22, m23, m30, m32, m33);
    float t12 = -determinant3x3(m00, m01, m03, m20, m21, m23, m30, m31, m33);
    float t13 = determinant3x3(m00, m01, m02, m20, m21, m22, m30, m31, m32);

    // third row
    float t20 = determinant3x3(m01, m02, m03, m11, m12, m13, m31, m32, m33);
    float t21 = -determinant3x3(m00, m02, m03, m10, m12, m13, m30, m32, m33);
    float t22 = determinant3x3(m00, m01, m03, m10, m11, m13, m30, m31, m33);
    float t23 = -determinant3x3(m00, m01, m02, m10, m11, m12, m30, m31, m32);

    // fourth row
    float t30 = -determinant3x3(m01, m02, m03, m11, m12, m13, m21, m22, m23);
    float t31 = determinant3x3(m00, m02, m03, m10, m12, m13, m20, m22, m23);
    float t32 = -determinant3x3(m00, m01, m03, m10, m11, m13, m20, m21, m23);
    float t33 = determinant3x3(m00, m01, m02, m10, m11, m12, m20, m21, m22);

    // transpose and divide by the determinant
    m00 = t00 / determinant1;
    m01 = t10 / determinant1;
    m02 = t20 / determinant1;
    m03 = t30 / determinant1;

    m10 = t01 / determinant1;
    m11 = t11 / determinant1;
    m12 = t21 / determinant1;
    m13 = t31 / determinant1;

    m20 = t02 / determinant1;
    m21 = t12 / determinant1;
    m22 = t22 / determinant1;
    m23 = t32 / determinant1;

    m30 = t03 / determinant1;
    m31 = t13 / determinant1;
    m32 = t23 / determinant1;
    m33 = t33 / determinant1;

    return true;
}


/**
 * Calculate the determinant of a 3x3 matrix.
 * @return result
 */
private float determinant3x3(float t00, float t01, float t02,
                             float t10, float t11, float t12,
                             float t20, float t21, float t22)
{
    return (t00 * (t11 * t22 - t12 * t21) +
            t01 * (t12 * t20 - t10 * t22) +
            t02 * (t10 * t21 - t11 * t20));
}


/**
 * @return the determinant of the matrix
 */
public float determinant()
{
    float f =
      m00
      * ((m11 * m22 * m33 + m12 * m23 * m31 + m13 * m21 * m32)
         - m13 * m22 * m31
         - m11 * m23 * m32
         - m12 * m21 * m33);
    f -= m01
      * ((m10 * m22 * m33 + m12 * m23 * m30 + m13 * m20 * m32)
         - m13 * m22 * m30
         - m10 * m23 * m32
         - m12 * m20 * m33);
    f += m02
      * ((m10 * m21 * m33 + m11 * m23 * m30 + m13 * m20 * m31)
         - m13 * m21 * m30
         - m10 * m23 * m31
         - m11 * m20 * m33);
    f -= m03
      * ((m10 * m21 * m32 + m11 * m22 * m30 + m12 * m20 * m31)
         - m12 * m21 * m30
         - m10 * m22 * m31
         - m11 * m20 * m32);
    return f;
}


//////////////////////////////////////////////////////////////

// REVERSE VERSIONS OF MATRIX OPERATIONS

// These functions should not be used, as they will be removed in the future.


protected void invTranslate(float tx, float ty, float tz)
{
    preApply(1, 0, 0, -tx,
             0, 1, 0, -ty,
             0, 0, 1, -tz,
             0, 0, 0, 1);
}


protected void invRotateX(float angle)
{
    float c = cos(-angle);
    float s = sin(-angle);
    preApply(1, 0, 0, 0, 0, c, -s, 0, 0, s, c, 0, 0, 0, 0, 1);
}


protected void invRotateY(float angle)
{
    float c = cos(-angle);
    float s = sin(-angle);
    preApply(c, 0, s, 0, 0, 1, 0, 0, -s, 0, c, 0, 0, 0, 0, 1);
}


protected void invRotateZ(float angle)
{
    float c = cos(-angle);
    float s = sin(-angle);
    preApply(c, -s, 0, 0, s, c, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
}


protected void invRotate(float angle, float v0, float v1, float v2)
{
    //TODO should make sure this vector is normalized

    float c = cos(-angle);
    float s = sin(-angle);
    float t = 1.0f - c;

    preApply((t * v0 * v0) + c, (t * v0 * v1) - (s * v2), (t * v0 * v2) + (s * v1), 0,
             (t * v0 * v1) + (s * v2), (t * v1 * v1) + c, (t * v1 * v2) - (s * v0), 0,
             (t * v0 * v2) - (s * v1), (t * v1 * v2) + (s * v0), (t * v2 * v2) + c, 0,
             0, 0, 0, 1);
}


protected void invScale(float x, float y, float z)
{
    preApply(1 / x, 0, 0, 0, 0, 1 / y, 0, 0, 0, 0, 1 / z, 0, 0, 0, 0, 1);
}


protected bool invApply(float n00, float n01, float n02, float n03,
                           float n10, float n11, float n12, float n13,
                           float n20, float n21, float n22, float n23,
                           float n30, float n31, float n32, float n33)
{
    if (inverseCopy == null)
    {
        inverseCopy = new PMatrix3D();
    }
    inverseCopy.set(n00, n01, n02, n03,
                    n10, n11, n12, n13,
                    n20, n21, n22, n23,
                    n30, n31, n32, n33);
    if (!inverseCopy.invert())
    {
        return false;
    }
    preApply(inverseCopy);
    return true;
}


//////////////////////////////////////////////////////////////





//////////////////////////////////////////////////////////////


static private  float max(float a, float b)
{
    return (a > b) ? a : b;
}

static private  float abs(float a)
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
}


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
        float sqrDistance = 399.99999f;
        if (posX * posX + posZ * posZ < 400)
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

public class tringle : MonoBehaviour
{
    float speed1 = 1;
    float constspeed = 1; 
    float constdist = 4;
    public static float speed = 10.0f; public static float speed2 = 10.0f;
    public static float rotationSpeed = 10.0f;
    public float v1 = 0;
    public float v2 = 0;
    public float v3 = 0;
    public bool w;
    public PolarTransform p2 = new PolarTransform(); 
    public PolarTransform p3 = new PolarTransform();
    public PolarTransform p4 = new PolarTransform();
    public MeshFilter mf;
    public MeshCollider mc;
    public bool v;
    Vector3 v31; Vector3 v32; Vector3 v33;
    public bool px; public bool py; public bool mx; public bool my;
    public bool px1; public bool py1; public bool mx1; public bool my1;
    public bool px2; public bool py2; public bool mx2; public bool my2;
   static public bool iseditor = false;
    public float x;
    public void move()
    {
        if (px)
        {
            p2.preApplyTranslationY(-1 * x * 0.02f);
            px = !px;
        }
        if (mx)
        {
            p2.preApplyTranslationY(1 * x * 0.02f);
            mx = !mx;
        }
        if (py)
        {
            p2.preApplyTranslationZ(-1 * x * 0.02f);
            py = !py;
        }
        if (my)
        {
            p2.preApplyTranslationZ(1 * x * 0.02f);
            my = !my;
        }
        if (px1)
        {
            p3.preApplyTranslationY(-1 * x * 0.02f);
            px1 = !px1;
        }
        if (mx1)
        {
            p3.preApplyTranslationY(1 * x * 0.02f);
            mx1 = !mx1;
        }
        if (py1)
        {
            p3.preApplyTranslationZ(-1 * x * 0.02f);
            py1 = !py1;
        }
        if (my1)
        {
            p3.preApplyTranslationZ(1 * x * 0.02f);
            my1 = !my1;
        }
        if (px2)
        {
            p4.preApplyTranslationY(-1 * x * 0.02f);
            px2 = !px2;
        }
        if (mx2)
        {
            p4.preApplyTranslationY(1 * x * 0.02f);
            mx2 = !mx2;
        }
        if (py2)
        {
            p4.preApplyTranslationZ(-1 * x * 0.02f);
            py2 = !py2;
        }
        if (my2)
        {
            p4.preApplyTranslationZ(1 * x * 0.02f);
            my2 = !my2;
        }
    }



    PolarTransform polarTransform;
    
    public void up()
    {


        Deplacement();

    }
    public void up2( PolarTransform v2)
    {


        Deplacement();

    }
    
    public void Createmath(Vector3 v1, Vector3 v2, Vector3 v3)
    {

        float ds = MathHyper.Facteur2(gameObject, Vector3.zero);
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
        m.triangles=tranglse;
        m.uv = uv;
        m.normals = n;
        if (ds >= 0)
        {

            mf.sharedMesh = m;
            mc.sharedMesh = m;
        }
        if (ds < 0.1)
        {

            mf.sharedMesh = null;
            mc.sharedMesh = null;
        }
    }


    void Deplacement()
    {
        PVector p = new PVector(0, 0, 0); 
        if (w)
        {







            //multiplication par le facteur hyperbolique

            


            PMatrix3D copytr = new PMatrix3D();
            copytr.set(p2.getMatrix());

            PVector prevPoint = new PVector();
            //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")

            float inc = 0.1f;
            for (float i = 0; i < inc * 2; i += inc)
            {
                PVector nextPoint = MathHyper.polarVector(i, 1.255f);
                //Apply currentTransform on nextPoint and save the result in nextPoint 



                copytr.mult(nextPoint, nextPoint);
                Camd.Main().polarTransform.getMatrix().mult(nextPoint, nextPoint);

                nextPoint = MathHyper.projectOntoScreen(nextPoint);
                if (i >= inc)
                {
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint.x,0 ,prevPoint.y)); if (iseditor)
                    {
                        v31 = new Vector3(prevPoint.x, v1 * ds, prevPoint.y - 0.001f);
                    }
                    if (!iseditor)
                    {
                        v31 = new Vector3(prevPoint.x, v1 * ds, prevPoint.y );
                    }
                }

                    prevPoint = nextPoint;


            }
            PMatrix3D copytr1 = new PMatrix3D();
            copytr1.set(p3.getMatrix());

            PVector prevPoint1 = new PVector();
            //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")

            float inc1 = 0.1f;
            for (float i = 0; i < inc1 * 2; i += inc)
            {
                PVector nextPoint2 = MathHyper.polarVector(i, 1.255f);
                //Apply currentTransform on nextPoint and save the result in nextPoint 



                copytr1.mult(nextPoint2, nextPoint2);
                Camd.Main().polarTransform.getMatrix().mult(nextPoint2, nextPoint2);

                nextPoint2 = MathHyper.projectOntoScreen(nextPoint2); 
                    if (i >= inc1)
                    {
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint1.x, 0, prevPoint1.y));
                    if (iseditor)
                    {


                        v32 = new Vector3(prevPoint1.x, v2 * ds - 0.001f, prevPoint1.y);
                    }
                    if (!iseditor)
                    {


                        v32 = new Vector3(prevPoint1.x, v2 * ds, prevPoint1.y);
                    }
                }


                    prevPoint1 = nextPoint2;


            }
            PMatrix3D copytr2 = new PMatrix3D();
            copytr2.set(p4.getMatrix());

            PVector prevPoint2 = new PVector();
            //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")
            
            float inc2 = 0.1f;
            for (float i = 0; i < inc2 * 2; i += inc)
            {
                PVector nextPoint3 = MathHyper.polarVector(i, 1.255f);
                //Apply currentTransform on nextPoint and save the result in nextPoint 



                copytr2.mult(nextPoint3, nextPoint3);
                Camd.Main().polarTransform.getMatrix().mult(nextPoint3, nextPoint3);

                nextPoint3 = MathHyper.projectOntoScreen(nextPoint3); 
                    if (i >= inc)
                    {
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint2.x, 0, prevPoint2.y)); if (iseditor)
                    {
                        v33 = new Vector3(prevPoint2.x - 0.001f, v3 * ds, prevPoint2.y);
                    }
                    if (!iseditor)
                    {
                        v33 = new Vector3(prevPoint2.x, v3 * ds, prevPoint2.y);
                    }
                }


                    prevPoint2 = nextPoint3;


            }
            //Apply currentTransform on nextPoint and save the result in nextPoint 

            Createmath(v31, v32, v33);



            //sert pour baisser a la bonne hauteur







        }
        
        if (!w)
        {



            //multiplication par le facteur hyperbolique




            PMatrix3D copytr = new PMatrix3D();
            copytr.set(p2.getMatrix());

            PVector prevPoint = new PVector();
            //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")

            float inc = 0.1f;
            for (float i = 0; i < inc * 2; i += inc)
            {
                PVector nextPoint = MathHyper.polarVector(i, 1.255f);
                //Apply currentTransform on nextPoint and save the result in nextPoint 



                copytr.mult(nextPoint, nextPoint);
                Camd.Main().polarTransform.getMatrix().mult(nextPoint, nextPoint);

                nextPoint = MathHyper.projectOntoScreen(nextPoint);
                if (i >= inc)
                {
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint.x, 0, prevPoint.y)); if (iseditor)
                    {
                        v31 = new Vector3(prevPoint.x, v1 * ds, prevPoint.y - 0.001f);
                    }
                    if (!iseditor)
                    {
                        v31 = new Vector3(prevPoint.x, v1 * ds, prevPoint.y);
                    }
                }

                prevPoint = nextPoint;


            }
            PMatrix3D copytr1 = new PMatrix3D();
            copytr1.set(p3.getMatrix());

            PVector prevPoint1 = new PVector();
            //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")

            float inc1 = 0.1f;
            for (float i = 0; i < inc1 * 2; i += inc)
            {
                PVector nextPoint2 = MathHyper.polarVector(i, 1.255f);
                //Apply currentTransform on nextPoint and save the result in nextPoint 



                copytr1.mult(nextPoint2, nextPoint2);
                Camd.Main().polarTransform.getMatrix().mult(nextPoint2, nextPoint2);

                nextPoint2 = MathHyper.projectOntoScreen(nextPoint2);
                if (i >= inc1)
                {
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint1.x, 0, prevPoint1.y));
                    if (iseditor)
                    {


                        v32 = new Vector3(prevPoint1.x, v2 * ds - 0.001f, prevPoint1.y);
                    }
                    if (!iseditor)
                    {


                        v32 = new Vector3(prevPoint1.x, v2 * ds, prevPoint1.y);
                    }
                }


                prevPoint1 = nextPoint2;


            }
            PMatrix3D copytr2 = new PMatrix3D();
            copytr2.set(p4.getMatrix());

            PVector prevPoint2 = new PVector();
            //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")

            float inc2 = 0.1f;
            for (float i = 0; i < inc2 * 2; i += inc)
            {
                PVector nextPoint3 = MathHyper.polarVector(i, 1.255f);
                //Apply currentTransform on nextPoint and save the result in nextPoint 



                copytr2.mult(nextPoint3, nextPoint3);
                Camd.Main().polarTransform.getMatrix().mult(nextPoint3, nextPoint3);

                nextPoint3 = MathHyper.projectOntoScreen(nextPoint3);
                if (i >= inc)
                {
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint2.x, 0, prevPoint2.y)); if (iseditor)
                    {
                        v33 = new Vector3(prevPoint2.x - 0.001f, v3 * ds, prevPoint2.y);
                    }
                    if (!iseditor)
                    {
                        v33 = new Vector3(prevPoint2.x, v3 * ds, prevPoint2.y);
                    }
                }


                prevPoint2 = nextPoint3;


            }

            //sert pour baisser a la bonne hauteur












        }


        // transform.Translate(0, (nouveauFacteur - ancienFacteur) / 2,0);


    }

    private void Update()
    {
        
        
        


    }
}
