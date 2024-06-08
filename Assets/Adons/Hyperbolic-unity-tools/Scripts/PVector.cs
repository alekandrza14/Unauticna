using UnityEngine;
using System;

[System.Serializable]
public class PVector
{
  /**
   * ( begin auto-generated from PVector_x.xml )
   *
   * The x component of the vector. This field (variable) can be used to both
   * TypeGenergy and set the value (see above example.)
   *
   * ( end auto-generated )
   *
   * @webref pvector:field
   * @usage web_application
   * @brief The x component of the vector
   */
  public double x;

/**
 * ( begin auto-generated from PVector_y.xml )
 *
 * The y component of the vector. This field (variable) can be used to both
 * TypeGenergy and set the value (see above example.)
 *
 * ( end auto-generated )
 *
 * @webref pvector:field
 * @usage web_application
 * @brief The y component of the vector
 */
public double y;

/**
 * ( begin auto-generated from PVector_z.xml )
 *
 * The z component of the vector. This field (variable) can be used to both
 * TypeGenergy and set the value (see above example.)
 *
 * ( end auto-generated )
 *
 * @webref pvector:field
 * @usage web_application
 * @brief The z component of the vector
 */
public double z;

/** Array so that this can be temporarily used in an array context */
protected double[] array;


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
public PVector(double x, double y, double z)
{
    this.x = x;
    this.y = y;
    this.z = z;
}


/**
 * Constructor for a 2D vector: z coordinate is set to 0.
 */
public PVector(double x, double y)
{
    this.x = x;
    this.y = y;
}


/**
 * ( begin auto-generated from PVector_set.xml )
 *
 * Sets the x, y, and z component of the vector using two or three separate
 * variables, the data from a PVector, or the values from a double array.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @param x the x component of the vector
 * @param y the y component of the vector
 * @param z the z component of the vector
 * @brief Set the components of the vector
 */
public PVector set(double x, double y, double z)
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
public PVector set(double x, double y)
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
 * Set the x, y (and maybe z) coordinates using a double[] array as the source.
 * @param source array to copy from
 */
public PVector set(double[] source)
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
static public PVector fromAngle(double angle)
{
    return fromAngle(angle, null);
}


/**
 * Make a new 2D unit vector from an angle
 *
 * @param target the target vector (if null, a new vector will be created)
 * @return the PVector
 */
static public PVector fromAngle(double angle, PVector target)
{
    if (target == null)
    {
        target = new PVector((double)Math.Cos(angle), (double)Math.Sin(angle), 0);
    }
    else
    {
        target.set((double)Math.Cos(angle), (double)Math.Sin(angle), 0);
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
public double[] get(double[] target)
{
    if (target == null)
    {
        return new double[] { x, y, z };
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
 * as a double (this is simply the equation <em>sqrt(x*x + y*y + z*z)</em>.)
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage web_application
 * @brief Calculate the magnitude of the vector
 * @return magnitude (length) of the vector
 * @see PVector#magSq()
 */
public double mag()
{
    return (double)Math.Sqrt(x * x + y * y + z * z);
}


/**
 * ( begin auto-generated from PVector_mag.xml )
 *
 * Calculates the squared magnitude of the vector and returns the result
 * as a double (this is simply the equation <em>(x*x + y*y + z*z)</em>.)
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
public double magSq()
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
public PVector add(double x, double y)
{
    this.x += x;
    this.y += y;
    return this;
}


/**
 * @param z z component of the vector
 */
public PVector add(double x, double y, double z)
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
public PVector sub(double x, double y)
{
    this.x -= x;
    this.y -= y;
    return this;
}


/**
 * @param z the z component of the vector
 */
public PVector sub(double x, double y, double z)
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
public PVector mult(double n)
{
    x *= n;
    y *= n;
    z *= n;
    return this;
}


/**
 * @param v the vector to multiply by the scalar
 */
static public PVector mult(PVector v, double n)
{
    return mult(v, n, null);
}


/**
 * Multiply a vector by a scalar, and write the result into a target PVector.
 * @param target PVector in which to store the result
 */
static public PVector mult(PVector v, double n, PVector target)
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
public PVector div(double n)
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
static public PVector div(PVector v, double n)
{
    return div(v, n, null);
}


/**
 * Divide a vector by a scalar and store the result in another vector.
 * @param target PVector in which to store the result
 */
static public PVector div(PVector v, double n, PVector target)
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
public double dist(PVector v)
{
    double dx = x - v.x;
    double dy = y - v.y;
    double dz = z - v.z;
    return (double)Math.Sqrt(dx * dx + dy * dy + dz * dz);
}


/**
 * @param v1 any variable of type PVector
 * @param v2 any variable of type PVector
 * @return the Euclidean distance between v1 and v2
 */
static public double dist(PVector v1, PVector v2)
{
    double dx = v1.x - v2.x;
    double dy = v1.y - v2.y;
    double dz = v1.z - v2.z;
    return (double)Math.Sqrt(dx * dx + dy * dy + dz * dz);
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
public double dot(PVector v)
{
    return x * v.x + y * v.y + z * v.z;
}


/**
 * @param x x component of the vector
 * @param y y component of the vector
 * @param z z component of the vector
 */
public double dot(double x, double y, double z)
{
    return this.x * x + this.y * y + this.z * z;
}


/**
 * @param v1 any variable of type PVector
 * @param v2 any variable of type PVector
 */
static public double dot(PVector v1, PVector v2)
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
    double crossX = y * v.z - v.y * z;
    double crossY = z * v.x - v.z * x;
    double crossZ = x * v.y - v.x * y;

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
    double crossX = v1.y * v2.z - v2.y * v1.z;
    double crossY = v1.z * v2.x - v2.z * v1.x;
    double crossZ = v1.x * v2.y - v2.x * v1.y;

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
    double m = mag();
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
    double m = mag();
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
public PVector limit(double max)
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
public PVector setMag(double len)
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
public PVector setMag(PVector target, double len)
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
public double heading()
{
    double angle = (double)Math.Atan2(y, x);
    return angle;
}



  public double heading2D()
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
 * @see PApplet#lerp(double, double, double)
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
 * Return a representation of this vector as a double array. This is only
 * for temporary use. If used in any other fashion, the contents should be
 * copied by using the <b>PVector.TypeGenergy()</b> method to copy into your own array.
 *
 * ( end auto-generated )
 *
 * @webref pvector:method
 * @usage: web_application
 * @brief Return a representation of the vector as a double array
 */







  
  public int hashCode()
{
    int result = 1;
    result = 31 * result + (int)x;
    result = 31 * result + (int)y;
    result = 31 * result + (int)z;
    return result;
}
}
