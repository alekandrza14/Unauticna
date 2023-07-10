using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Surface4D
{
    public class Rotate4DInput : MonoBehaviour
    {
        public Scrollbar rotateX;
        public Scrollbar rotateY;
        public Scrollbar rotateZ;
        public Scrollbar rotateXW;
        public Scrollbar rotateYW;
        public Scrollbar rotateZW;

        private void OnEnable()
        {
            var tempMaterial = GetComponent<Renderer>().material;
            GetComponent<Renderer>().sharedMaterial = tempMaterial;
        }

        // Update is called once per frame
        void Update()
        {
            float cX = Mathf.Cos(rotateX.value * 6.28f), sX = Mathf.Sin(rotateX.value * 6.28f);
            float cY = Mathf.Cos(rotateY.value * 6.28f), sY = Mathf.Sin(rotateY.value * 6.28f);
            float cZ = Mathf.Cos(rotateZ.value * 6.28f), sZ = Mathf.Sin(rotateZ.value * 6.28f);
            float cXW = Mathf.Cos(rotateXW.value * 6.28f ), sXW = Mathf.Sin(rotateXW.value * 6.28f);
            float cYW = Mathf.Cos(rotateYW.value * 6.28f ), sYW = Mathf.Sin(rotateYW.value * 6.28f);
            float cZW = Mathf.Cos(rotateZW.value* 6.28f ), sZW = Mathf.Sin(rotateZW.value * 6.28f);
            /*
           Matrix4x4 _rotation4D = new Matrix4x4(
               new Vector4(1 * cYW * cZW, sZW, -sYW, 0),
               new Vector4(-sZW, 1 * cXW *cZW, sXW, 0),
               new Vector4(sYW, -sXW,1 * cXW*cYW, 0),
               new Vector4(0, 0, 0, 1));
           */
            /*
            Matrix4x4 _rotation4D = new Matrix4x4(
                new Vector4(0, -sYW, sZW, 1 * cYW * cZW),
                new Vector4(0, sXW, 1 * cXW * cZW, -sZW),
                new Vector4(0, 1 * cXW * cYW, -sXW, sYW),
                new Vector4(1, 0, 0, 0));
            */
            //2
            /*Matrix4x4 _rotation4D = new Matrix4x4(
                new Vector4(-sYW, 0, 1 * cYW * cZW, sZW),
                new Vector4(sXW, 0, -sZW, 1 * cXW * cZW),
                new Vector4(1 * cXW * cYW, 0, sYW, -sXW),
                new Vector4(0, 1, 0, 0));
            */
            //3
            /*Matrix4x4 _rotation4D = new Matrix4x4(
                new Vector4(1 * cYW * cZW, 0, -sYW, sZW),
                new Vector4(-sZW, 0, sXW, 1 * cXW * cZW),
                new Vector4(sYW, 0, 1 * cXW * cYW, -sXW),
                new Vector4(0, 1, 0, 0));
            */
            //1+2
            /*
            Matrix4x4 _rotation4D = new Matrix4x4(
               new Vector4(sZW, 1 * cYW * cZW, 0, -sYW),
               new Vector4(1 * cXW * cZW, -sZW, 0, sXW),
               new Vector4(-sXW, sYW, 0, 1 * cXW * cYW),
               new Vector4(0, 0, 1, 0));
            */
            /*
            Matrix4x4 _rotation4D = new Matrix4x4(
               new Vector4(-sXW, sYW, 0, 1 * cXW * cYW),
               new Vector4(1 * cXW * cZW, -sZW, 0, sXW),
               new Vector4(sZW, 1 * cYW * cZW, 0, -sYW),
               new Vector4(0, 0, 1, 0));
            */
            //X
            // Matrix4x4 _rotation4D = new Matrix4x4(
            //     new Vector4(0,cYW, sYW,  0),
            //     new Vector4(0,-sYW, cYW,  0),
            //     new Vector4(cYW, 0, 0, -sYW),
            //     new Vector4(sYW, 0, 0, cYW));
            //Y
            //  Matrix4x4 _rotation4D = new Matrix4x4(
            //    new Vector4(cZW, 0, sZW, 0),
            //    new Vector4(-sZW, 0, cZW, 0),
            //    new Vector4(0, cZW, 0, -sZW),
            // new Vector4(0, sZW, 0, cZW));
            //Z
            //  Matrix4x4 _rotation4D = new Matrix4x4(
            //      new Vector4(cXW, sXW, 0, 0),
            //      new Vector4(-sXW, cXW, 0, 0),
            //      new Vector4(0, 0, cXW, -sXW),
            //      new Vector4(0, 0, sXW, cXW));

            //Nature X And XW
            // Matrix4x4 _rotation4D = new Matrix4x4(
            //      new Vector4(0,cX, sX,  0),
            //      new Vector4(0,-sX, cX,  0),
            //      new Vector4(cXW, 0, 0, -sXW),
            //      new Vector4(sXW, 0, 0, cXW));
            //Nature Y And YW
            // Matrix4x4 _rotation4D = new Matrix4x4(
            // new Vector4(cY, 0, sY, 0),
            // new Vector4(-sY, 0, -cY, 0),
            // new Vector4(0, cYW, 0, -sYW),
            // new Vector4(0, sYW, 0, cYW));

            //Nature Z And ZW
            //Matrix4x4 _rotation4D = new Matrix4x4(
            //      new Vector4(cZ, sZ, 0, 0),
            //      new Vector4(-sZ, cZ, 0, 0),
            //      new Vector4(0, 0, cZW, -sZW),
            //   new Vector4(0, 0, sZW, cZW));

            //Matrix4x4 _rotation4D = new Matrix4x4(
            //      new Vector4(cZ+ cY, sZ+ cX+ cY, sX, 0),
            //      new Vector4(-sZ+ -sY, cZ+ -sX, cX + cY, 0),
            //      new Vector4(cXW, cYW, cXW, -sXW - sYW),
            //      new Vector4(sXW, sYW, sXW, cXW+ cYW));
            //
            Matrix4x4 _rotation4D = new Matrix4x4(
            new Vector4(-1, 0, 0, 0),
                 new Vector4(0, 1, 0, 0),
                 new Vector4(0, 0, 1, 0),
                 new Vector4(0, 0, 0, 1));
            Matrix4x4 _rotation4DYZ = new Matrix4x4(
                 new Vector4( 1, 0, 0,0),
                 new Vector4( 0, cX, sX, 0),
                 new Vector4(0, -sX, cX, 0),
                 new Vector4(0, 0, 0, 1));

            Matrix4x4 _rotation4DXZ = new Matrix4x4(
            new Vector4(cY, 0, sY, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(-sY, 0, cY, 0),
            new Vector4(0, 0, 0, 1));



            Matrix4x4 _rotation4DXY = new Matrix4x4(
                  new Vector4(cZ, -sZ, 0, 0),
                  new Vector4(sZ, cZ, 0, 0),
                  new Vector4(0, 0, 1, 0),
                  new Vector4(0, 0, 0, 1));
            
            //cur
            Matrix4x4 _rotation4DXW = new Matrix4x4(
                 new Vector4(cXW, 0, 0, -sXW),
                 new Vector4(0, 1, 0, 0),
                 new Vector4(0, 0, 1, 0),
                 new Vector4(sXW, 0, 0, cXW));

            Matrix4x4 _rotation4DYW = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, cYW, 0, -sYW),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, sYW, 0, cYW));



            Matrix4x4 _rotation4DZW = new Matrix4x4(
                  new Vector4(1, 0, 0, 0),
                  new Vector4(0, 1, 0, 0),
                  new Vector4(0, 0, cZW, -sZW),
               new Vector4(0, 0, sZW, cZW));
            _rotation4D *= _rotation4DZW;
            _rotation4D *= _rotation4DYW;
            _rotation4D *= _rotation4DYZ;
            _rotation4D *= _rotation4DXW;
            _rotation4D *= _rotation4DXZ;
            _rotation4D *= _rotation4DXY;
            /*
            Matrix4x4 _rotation4D = new Matrix4x4(
              new Vector4(cXW, sXW, -sXW, cXW),
              new Vector4(cYW, -sYW, sYW, cYW),
              new Vector4(cZW, -sZW, sZW, cZW),
              new Vector4(1, 1, 1, 1));
            */
            GetComponent<Renderer>().sharedMaterial.SetMatrix("_Rotation4D", _rotation4D);

          //  transform.rotation = Quaternion.Euler(rotateX.value * 360,
            //   rotateY.value * 360,
              //  rotateZ.value * 360);
        }
    }
}
/* [MI(O.AggressiveInlining)] public static void CreateRotationX (ref Double radians, out Matrix44 r) {
            Double cos = Maths.Cos (radians), sin = Maths.Sin (radians);
            r.R0C0 = 1;          r.R0C1 = 0;          r.R0C2 = 0;          r.R0C3 = 0;
            r.R1C0 = 0;          r.R1C1 = cos;        r.R1C2 = sin;        r.R1C3 = 0;
            r.R2C0 = 0;          r.R2C1 = -sin;       r.R2C2 = cos;        r.R2C3 = 0;
            r.R3C0 = 0;          r.R3C1 = 0;          r.R3C2 = 0;          r.R3C3 = 1;
        }

        [MI(O.AggressiveInlining)] public static void CreateRotationY (ref Double radians, out Matrix44 r) {
            Double cos = Maths.Cos (radians), sin = Maths.Sin (radians);
            r.R0C0 = cos;        r.R0C1 = 0;          r.R0C2 = -sin;       r.R0C3 = 0;
            r.R1C0 = 0;          r.R1C1 = 1;          r.R1C2 = 0;          r.R1C3 = 0;
            r.R2C0 = sin;        r.R2C1 = 0;          r.R2C2 = cos;        r.R2C3 = 0;
            r.R3C0 = 0;          r.R3C1 = 0;          r.R3C2 = 0;          r.R3C3 = 1;
        }

        [MI(O.AggressiveInlining)] public static void CreateRotationZ (ref Double radians, out Matrix44 r) {
            Double cos = Maths.Cos (radians), sin = Maths.Sin (radians);
            r.R0C0 = cos;       r.R0C1 = sin;         r.R0C2 = 0;          r.R0C3 = 0;
            r.R1C0 = -sin;      r.R1C1 = cos;         r.R1C2 = 0;          r.R1C3 = 0;
            r.R2C0 = 0;         r.R2C1 = 0;           r.R2C2 = 1;          r.R2C3 = 0;
            r.R3C0 = 0;         r.R3C1 = 0;           r.R3C2 = 0;          r.R3C3 = 1;
        }


p4D.xw = mul(p4D.xw, float2x2(cos(shape.rotationW.x), sin(shape.rotationW.x), -sin(shape.rotationW.x), cos(shape.rotationW.x)));
p4D.zw = mul(p4D.zw, float2x2(cos(shape.rotationW.z), -sin(shape.rotationW.z), sin(shape.rotationW.z), cos(shape.rotationW.z)));
p4D.yw = mul(p4D.yw, float2x2(cos(shape.rotationW.y), -sin(shape.rotationW.y), sin(shape.rotationW.y), cos(shape.rotationW.y)));
*/
