using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

[AddComponentMenu("Physics/SphereChunkCollider")]
public class SphereChunkCollider : MonoBehaviour
{
    [SerializeField] Transform tragetObject;




    float fmod2(float a, float b)
    {
        float c = frac(abs(a / b)) * abs(b);
        if (a < 0)
        {
            c = -c + b;
        }
        return c;
    }
    float inv(float a,float b)
    {
        float c = a;
        if (b < 0)
        {
            c = -c;
        }
        return c;
    }

    void Update()
    {
        int c = 10;




        Transform player = mover.main().transform;



        Vector3 v3 = tragetObject.position;
        Vector3 v33 = tragetObject.position;
          v33 = new Vector3(fmod2(v33.x + 1f * c, c) - 0f * c, 0, fmod2(v33.z + 1f * c, c) - 0f * c);
        transform.position = new Vector3(
           ( ((int)(((int)player.position.x + inv(5, player.position.x) - (v33.x)) / (int)c)) * (int)c),
            v3.y,
            (((int)(((int)player.position.z + inv(5, player.position.z) - (v33.z)) / (int)c)) * (int)c)
            )+v33;
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
