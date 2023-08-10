using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

namespace Unity.Mathematics
{
    [AddComponentMenu("Physics 4D/RayMarching Collider")]
    public class DistanceFunctions : MonoBehaviour
    {
        // ****************** Distance Functions ****************** 

        // HyperbolicPoint
        // s: radius
        public float sdSphere(float3 p, float s)
        {
            return length(p) - s;
        }
        public float GetDist2(float4 p)
        {
            p.y += 0.5f;
            p.x += 100000;
            p.y -= 100000;
            p.z -= 100000;
            p.w -= 100000;
            float c = 14.5f;


            p.x = fmod(p.x + 0.5f * c, c) - 0.5f * c;
            p.y = -fmod(p.y + 0.5f * c, c) - 0.5f * c;

            p.z += 0.5f;

            p.z = -fmod(p.z + 0.5f * c, c) - 0.5f * c;
            p.w = -fmod(p.w + 0.5f * c, c) - 0.5f * c;


            return max(-(length(p) - 12), -10000);

        }
        // Box
        // b: size of box in x/y/z
        public float sdBox(float3 p, float3 b)
        {
            float3 d = abs(p) - b;
            return min(max(d.x, max(d.y, d.z)), 0.0f) + length(max(d, 0.0f));
        }

        // 4D HyperCube
        // b: size of box in x/y/z
        public float sdHypercube(float4 p, float4 b)
        {
            float4 d = abs(p) - b;
            return min(max(d.x, max(d.y, max(d.z, d.w))), 0.0f) + length(max(d, 0.0f));
        }

        // 4D HyperSphere
        // s: radius
        public float sdHypersphere(float4 p, float s)
        {
            return length(p) - s;
        }

        // http://eusebeia.dyndns.org/4d/duocylinder
        public float sdDuoCylinder(float4 p, float2 r1r2)
        {
            float2 d = abs(float2(length(p.xz), length(p.yw))) - r1r2;
            return min(max(d.x, d.y), 0.0f) + length(max(d, 0.0f));
        }
        public float sdCone(float4 p,float4 h)
        {
            return max(length(p.xzw) - h.x, abs(p.y) - h.y) - h.x * p.y;
        }
        public float sd16Cell(float4 p, float s)
        {
            p = abs(p);
            return (p.x + p.y + p.z + p.w - s) * 0.57735027f;
        }
        public float sd5Cell(float4 p, float4 a)
        {
            return (max(max(max(abs(p.x + p.y + (p.w / a.w)) - p.z, abs(p.x - p.y + (p.w / a.w)) + p.z), abs(p.x - p.y - (p.w / a.w)) + p.z), abs(p.x + p.y - (p.w / a.w)) - p.z) - a.x) / sqrt(3.0f);
        }
        public float sdNull(float4 p)
        {
            return 1000;
        }
        float Sphere(float4 p, float4 c, float r)
        {
            return length(p - c) - r;
        }
       public float sdMandelbulb(float4 pos)
        {

          if (length(pos) > 982.3f)
          {
              return Sphere(pos, float4.zero, 982.3f);
          }

            pos /= 422.3f;
            float4 z = pos;
            float dr = 1.0f;
            float r = 0.0f;

            for (int i = 0; i < 9.14f; ++i)
            {
                // Convert to polar coordinates
                r = length(z);
                if (r > 2)
                    break;

                float theta = acos(z.y / r);
                float phi = atan2(z.z, z.x);
                dr = pow(r, 8 - 0.5f) * 8 * dr + 0.5f;

                // Scale and rotate the point
                float zr = pow(r, 8);
                theta *= 8;
                phi *= 8;

                // Convert back to cartesian coordinates
                z = zr * float4(sin(theta) * cos(phi), cos(theta), sin(phi) * sin(theta), 0);

                z += pos;
            }

            float d = 422.3f * 0.5f * log(r) * r / dr;
            return d;
        }
        // plane
        public float sdPlane(float4 p, float4 s)
        {

            float plane = dot(p, normalize(float4(0, 1, 0, 0))) - (sin(p.x * s.x + p.w) + sin(p.z * s.z) + sin((p.x * 0.34f + p.z * 0.21f) * s.w)) / s.y;
            return plane;

        }

        public float Blend(float a, float b, float k)
        {
            float h = clamp(0.5f + 0.5f * (b - a) / k, 0.0f, 1.0f);
            return lerp(b, a, h) - (k * h * (1.0f - h));

        }

        public float Combine(float dstA, float dstB, Shape4D.Operation operation, float blendStrength)
        {
            float dst = dstA;

            switch (operation)
            {
                case Shape4D.Operation.Union:

                    if (dstB < dstA)
                    {
                        dst = dstB;
                    }
                    break;
                case Shape4D.Operation.Blend:
                    dst = Blend(dstA, dstB, blendStrength);
                    break;

                case Shape4D.Operation.Substract:
                    // max(a,-b)
                    if (-dstB > dst)
                    {
                        dst = -dstB;
                    }
                    break;

                case Shape4D.Operation.Intersect:
                    // max(a,b)
                    if (dstB > dst)
                    {
                        dst = dstB;
                    }
                    break;
            }

            return dst;
        }




        //returs the absolute value of a vector
        public Vector3 Abs(Vector3 vec)
        {
            return new Vector3(Mathf.Abs(vec.x), Mathf.Abs(vec.y), Mathf.Abs(vec.z));
        }
        //returs the absolute value of a vector
        public Vector4 Abs4(Vector4 vec)
        {
            return new Vector4(Mathf.Abs(vec.x), Mathf.Abs(vec.y), Mathf.Abs(vec.z), Mathf.Abs(vec.w));
        }

        //returs the absolute value of a vector
        public Vector2 Abs2(Vector2 vec)
        {
            return new Vector2(Mathf.Abs(vec.x), Mathf.Abs(vec.y));
        }

        //returns the Largest Vector
        public Vector3 Max(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(Mathf.Max(vec1.x, vec2.x), Mathf.Max(vec1.y, vec2.y), Mathf.Max(vec1.z, vec2.z));
        }

        //returns the Smallest Vector
        public Vector3 Min(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(Mathf.Max(vec1.x, vec2.x), Mathf.Max(vec1.y, vec2.y), Mathf.Max(vec1.z, vec2.z));
        }

        //returns the Largest Vector
        public Vector2 Max2(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2(Mathf.Max(vec1.x, vec2.x), Mathf.Max(vec1.y, vec2.y));
        }

        //returns the Smallest Vector
        public Vector2 Min2(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2(Mathf.Max(vec1.x, vec2.x), Mathf.Max(vec1.y, vec2.y));
        }
        public Vector4 Max4(Vector4 vec1, Vector4 vec2)
        {
            return new Vector4(Mathf.Max(vec1.x, vec2.x), Mathf.Max(vec1.y, vec2.y), Mathf.Max(vec1.z, vec2.z), Mathf.Max(vec1.w, vec2.w));
        }


    }
}

