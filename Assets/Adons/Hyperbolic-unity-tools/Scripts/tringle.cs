using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Mathematics;
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
}

public class tringle : MonoBehaviour
{
    float speed1 = 1;
    float constspeed = 1;
    float constdist = 4;
    public static float speed = 10.0f; public static float speed2 = 10.0f;
    public static float rotationSpeed = 10.0f;
    [HideInInspector] public float v1 = 0;
    [HideInInspector] public float v2 = 0;
    [HideInInspector] public float v3 = 0;
    [HideInInspector] public bool w;
    [HideInInspector] public Polar3 p2 = new Polar3();
    [HideInInspector] public Polar3 p3 = new Polar3();
    [HideInInspector] public Polar3 p4 = new Polar3();
    [Header("Polygon")]
    [Header("==============")]
    [Header("MeshFiller")] [SerializeField] public MeshFilter mf;
    [Header("MeshCollider")] [SerializeField] public MeshCollider mc;
    [Header("Flip Normals")] [SerializeField] public bool v;
  //  [Header("==============")] [HideInInspector] [SerializeField] public bool byUnauticna;

    Vector3 v31; Vector3 v32; Vector3 v33;
    [HideInInspector] public bool px;[HideInInspector] public bool py;[HideInInspector] public bool mx;[HideInInspector] public bool my;
    [HideInInspector] public bool px1;[HideInInspector] public bool py1;[HideInInspector] public bool mx1;[HideInInspector] public bool my1;
    [HideInInspector] public bool px2;[HideInInspector] public bool py2;[HideInInspector] public bool mx2;[HideInInspector] public bool my2;
   static public bool iseditor = false;
    float ods1 = 1;
    [HideInInspector] public float x;
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



    Polar3 polarTransform;
    
    public void up()
    {


        Deplacement();

    }
    public void up2( Polar3 v2)
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
        m.triangles = tranglse;
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
    public void Clearmath()
    {

        if (mf.sharedMesh != null)
        {


            






            mf.sharedMesh = null;
            mc.sharedMesh = null;
        }

    }


        void Deplacement()
    {
        float ds1 =1;
        PVector p = new PVector(0, 0, 0);








        //multiplication par le facteur hyperbolique





        if (ods1 > 0.4f)
        {
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
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint.x, 0, prevPoint.y));
                    ds1 = ds;
                    if (iseditor)
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
        }
        else if (UnityEngine.Random.Range(0, 2) == 1 && ods1 > 0.4f)
        {
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
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint.x, 0, prevPoint.y));
                    ds1 = ds;
                    if (iseditor)
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
        }
        else if (UnityEngine.Random.Range(0, 3) == 2 && ods1 > 0.3f)
        {
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
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint.x, 0, prevPoint.y));
                    ds1 = ds;
                    if (iseditor)
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
        }
        else if (UnityEngine.Random.Range(0, 4) == 3 && ods1 > 0.2f)
        {
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
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint.x, 0, prevPoint.y));
                    ds1 = ds;
                    if (iseditor)
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
        }
        else if (UnityEngine.Random.Range(0, 5) == 4 && ods1 > 0.1f)
        {
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
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint.x, 0, prevPoint.y));
                    ds1 = ds;
                    if (iseditor)
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
        }
        else if (UnityEngine.Random.Range(0, 6) == 5)
        {
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
                    float ds = MathHyper.Facteur2(gameObject, new Vector3(prevPoint.x, 0, prevPoint.y));
                    ds1 = ds;
                    if (iseditor)
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
        }
        if (ds1 > 0.4f) {
            PMatrix3D copytr1 = new PMatrix3D();
            copytr1.set(p3.getMatrix());

            PVector prevPoint1 = new PVector();
            //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")

            float inc1 = 0.1f;
            for (float i = 0; i < inc1 * 2; i += inc1)
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
            for (float i = 0; i < inc2 * 2; i += inc2)
            {
                PVector nextPoint3 = MathHyper.polarVector(i, 1.255f);
                //Apply currentTransform on nextPoint and save the result in nextPoint 



                copytr2.mult(nextPoint3, nextPoint3);
                Camd.Main().polarTransform.getMatrix().mult(nextPoint3, nextPoint3);

                nextPoint3 = MathHyper.projectOntoScreen(nextPoint3);
                if (i >= inc2)
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
        }
            //Apply currentTransform on nextPoint and save the result in nextPoint 
            if (ds1 > 0.4f)
        {
            Createmath(v31, v32, v33);
        }
        else
        {
            
            Clearmath();
        }
        ods1 = ds1;


        //sert pour baisser a la bonne hauteur












        //sert pour baisser a la bonne hauteur












    }


    // transform.Translate(0, (nouveauFacteur - ancienFacteur) / 2,0);

    void FixedUpdate()
    {
      
    }


    void LateUpdate()
    {
        up();
    }

    void Update()
    {

        
        


    }
}
