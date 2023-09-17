using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Unity.Mathematics.math;

// ****************** Player Collision Detection through Raymarching ****************** 

namespace Unity.Mathematics
{
    [AddComponentMenu("Physics 4D/RayMarching Physics")]
    public class PlayerRayMarchCollider : MonoBehaviour
    {

        public float colliderOffset = 1.2f;
        public float maxDownMovement = 0f;
        [Tooltip ("The transforms from which the raymarcher will test the distances and apply the collision")]
        public Transform[] rayMarchTransforms;

        private DistanceFunctions Df;
        private RaymarchCam camScript;


        // Start is called before the first frame update
        void Start()
        {
            camScript = FindObjectOfType<RaymarchCam>();
            Df = GetComponent<DistanceFunctions>();
        }
        
        // Update is called once per frame
        void Update()
        {
            MoveToGround();
            RayMarch(rayMarchTransforms);
            
        }
        // the distancefunction for the shapes
        public float GetShapeDistance(Shape4D shape, float4 p4D)
        {
            p4D -= (float4)shape.Position();

            p4D.xz = mul(p4D.xz, float2x2(cos(shape.Rotation().y), sin(shape.Rotation().y), -sin(shape.Rotation().y), cos(shape.Rotation().y)));
            p4D.yz = mul(p4D.yz, float2x2(cos(shape.Rotation().x), -sin(shape.Rotation().x), sin(shape.Rotation().x), cos(shape.Rotation().x)));
            p4D.xy = mul(p4D.xy, float2x2(cos(shape.Rotation().z), -sin(shape.Rotation().z), sin(shape.Rotation().z), cos(shape.Rotation().z)));

            p4D.xw = mul(p4D.xw, float2x2(cos(shape.RotationW().x), sin(shape.RotationW().x), -sin(shape.RotationW().x), cos(shape.RotationW().x)));
            p4D.zw = mul(p4D.zw, float2x2(cos(shape.RotationW().z), -sin(shape.RotationW().z), sin(shape.RotationW().z), cos(shape.RotationW().z)));
            p4D.yw = mul(p4D.yw, float2x2(cos(shape.RotationW().y), -sin(shape.RotationW().y), sin(shape.RotationW().y), cos(shape.RotationW().y)));



            switch (shape.shapeType)
            {
                case Shape4D.ShapeType.HyperCube:
                    return Df.sdHypercube(p4D, shape.Scale());

                case Shape4D.ShapeType.HyperSphere:
                    return Df.sdHypersphere(p4D, shape.Scale().x);

                case Shape4D.ShapeType.DuoCylinder:
                    return Df.sdDuoCylinder(p4D, ((float4)shape.Scale()).xy);
                case Shape4D.ShapeType.plane:
                    return Df.sdPlane(p4D, shape.Scale());
                case Shape4D.ShapeType.Cone:
                    return Df.sdCone(p4D, shape.Scale());
                case Shape4D.ShapeType.FiveCell:
                    return Df.sd5Cell(p4D, shape.Scale());
                case Shape4D.ShapeType.SixteenCell:
                    return Df.sd16Cell(p4D, shape.Scale().x);
                case Shape4D.ShapeType.Mandelbrot:
                    return Df.sdMandelbulb(p4D);
                case Shape4D.ShapeType.ObjectN1:
                    return Df.GetDist2(p4D);
                case Shape4D.ShapeType.Pipis:
                    return Df.sdPipis(p4D, shape.Scale());
                case Shape4D.ShapeType.PipisN2:
                    return Df.sdPipis2(p4D, shape.Scale());
                case Shape4D.ShapeType.AbstractPlane:
                    return Df.sdAbstractPlane(p4D);
                case Shape4D.ShapeType.infinityCilinder:
                    return Df.sdCylinder2(p4D.xyz, ((float4)shape.Scale()).xyz);

            }

            return Camera.main.farClipPlane;
        }
        private void OnDisable()
        {
            enabled = !enabled;
        }
        public float GetShapeDistanceRenderer(Shape4D shape, float4 p4D)
        {
            p4D -= (float4)shape.Position();

            p4D.xz = mul(p4D.xz, float2x2(cos(shape.Rotation().y), sin(shape.Rotation().y), -sin(shape.Rotation().y), cos(shape.Rotation().y)));
            p4D.yz = mul(p4D.yz, float2x2(cos(shape.Rotation().x), -sin(shape.Rotation().x), sin(shape.Rotation().x), cos(shape.Rotation().x)));
            p4D.xy = mul(p4D.xy, float2x2(cos(shape.Rotation().z), -sin(shape.Rotation().z), sin(shape.Rotation().z), cos(shape.Rotation().z)));

            p4D.xw = mul(p4D.xw, float2x2(cos(shape.RotationW().x), sin(shape.RotationW().x), -sin(shape.RotationW().x), cos(shape.RotationW().x)));
            p4D.zw = mul(p4D.zw, float2x2(cos(shape.RotationW().z), -sin(shape.RotationW().z), sin(shape.RotationW().z), cos(shape.RotationW().z)));
            p4D.yw = mul(p4D.yw, float2x2(cos(shape.RotationW().y), -sin(shape.RotationW().y), sin(shape.RotationW().y), cos(shape.RotationW().y)));



            switch (shape.shapeType)
            {
                case Shape4D.ShapeType.HyperCube:
                    return Df.sdHypercube(p4D, shape.Scale());

                case Shape4D.ShapeType.HyperSphere:
                    return Df.sdHypersphere(p4D, shape.Scale().x);

                case Shape4D.ShapeType.DuoCylinder:
                    return Df.sdDuoCylinder(p4D, ((float4)shape.Scale()).xy);
                case Shape4D.ShapeType.plane:
                    return Df.sdPlane(p4D, shape.Scale());
                case Shape4D.ShapeType.Cone:
                    return Df.sdCone(p4D, shape.Scale());
                case Shape4D.ShapeType.FiveCell:
                    return Df.sd5Cell(p4D, shape.Scale());
                case Shape4D.ShapeType.SixteenCell:
                    return Df.sd16Cell(p4D, shape.Scale().x);
                case Shape4D.ShapeType.Mandelbrot:
                    return Df.sdMandelbulb(p4D);
                case Shape4D.ShapeType.ObjectN1:
                    return Df.GetDist2(p4D);
                case Shape4D.ShapeType.Pipis:
                    return Df.sdPipis(p4D, shape.Scale());
                case Shape4D.ShapeType.PipisN2:
                    return Df.sdPipis2(p4D, shape.Scale());
                case Shape4D.ShapeType.AbstractPlane:
                    return Df.sdAbstractPlane(p4D);
                case Shape4D.ShapeType.infinityCilinder:
                    return Df.sdCylinder2(p4D.xyz, ((float4)shape.Scale()).xyz);
                case Shape4D.ShapeType.none:
                    return Df.sdNull(p4D);

            }

            return Camera.main.farClipPlane;
        }

        public float DistanceField(float3 p)
        {
            float4 p4D = float4(p, camScript._wPosition);
            Vector3 wRot = camScript._wRotation * Mathf.Deg2Rad;

            if ((wRot).magnitude != 0)
            {
                p4D.xw = mul(p4D.xw, float2x2(cos(wRot.x), -sin(wRot.x), sin(wRot.x), cos(wRot.x)));
                p4D.yw = mul(p4D.yw, float2x2(cos(wRot.y), -sin(wRot.y), sin(wRot.y), cos(wRot.y)));
                p4D.zw = mul(p4D.zw, float2x2(cos(wRot.z), -sin(wRot.z), sin(wRot.z), cos(wRot.z)));

            }


            float globalDst = Camera.main.farClipPlane;


            for (int i = 0; i < camScript.orderedShapes.Count; i++)
            {
                Shape4D shape = camScript.orderedShapes[i];
                int numChildren = shape.numChildren;

                float localDst = GetShapeDistance(shape, p4D);


                for (int j = 0; j < numChildren; j++)
                {
                    Shape4D childShape = camScript.orderedShapes[i + j + 1];
                    float childDst = GetShapeDistance(childShape, p4D);

                    localDst = Df.Combine(localDst, childDst, childShape.operation, childShape.smoothRadius);

                }
                i += numChildren; // skip over children in outer loop

                globalDst = Df.Combine(globalDst, localDst, shape.operation, shape.smoothRadius);
            }

            return globalDst;

        }
        public float DistanceFieldRenderer(float3 p)
        {
            float4 p4D = float4(p, camScript._wPosition);
            Vector3 wRot = camScript._wRotation * Mathf.Deg2Rad;

            if ((wRot).magnitude != 0)
            {
                p4D.xw = mul(p4D.xw, float2x2(cos(wRot.x), -sin(wRot.x), sin(wRot.x), cos(wRot.x)));
                p4D.yw = mul(p4D.yw, float2x2(cos(wRot.y), -sin(wRot.y), sin(wRot.y), cos(wRot.y)));
                p4D.zw = mul(p4D.zw, float2x2(cos(wRot.z), -sin(wRot.z), sin(wRot.z), cos(wRot.z)));

            }


            float globalDst = Camera.main.farClipPlane;


            for (int i = 0; i < camScript.orderedShapes.Count; i++)
            {
                Shape4D shape = camScript.orderedShapes[i];
                int numChildren = shape.numChildren;

                float localDst = GetShapeDistanceRenderer(shape, p4D);


                for (int j = 0; j < numChildren; j++)
                {
                    Shape4D childShape = camScript.orderedShapes[i + j + 1];
                    float childDst = GetShapeDistanceRenderer(childShape, p4D);

                    localDst = Df.Combine(localDst, childDst, childShape.operation, childShape.smoothRadius);

                }
                i += numChildren; // skip over children in outer loop

                globalDst = Df.Combine(globalDst, localDst, shape.operation, shape.smoothRadius);
            }

            return globalDst;

        }
        bool r = true;

        float u = 0;
        // the raymarcher checks the distance to all the given transforms, if one is less than zero, the player is moved in the opposite direction
        void RayMarch(Transform[] ro)
        {
          //  MoveToGround();
            int nrHits = 0;

            for (int i = 0; i < ro.Length; i++)
            {
                Vector3 p = ro[i].position;
                //check hit
                float d = DistanceField(p);
                if (GetComponent<mover>())
                {


                    if (d < 0) //hit
                    {
                        GetComponent<mover>().physicsStop();
                        // Debug.Log("hit" + i);
                       // nrHits++;
                        //collision
                        // if(!Input.GetKey(KeyCode.F))  transform.Translate((-ro[i].up) * d * 1.5f, Space.World);
                         transform.Translate(ro[i].forward * d * 1.5f, Space.World);// transform.position += Vector3.up * 0.01f; 

                        //  GetComponent<Rigidbody>().MovePosition((ro[i].forward + (ro[i].up*2)) * d * 1f);

                        u = 1;
                    }
                    else
                    {

                        if (GetComponent<mover>().IsGraund) GetComponent<mover>().physicsStart();
                    }
                }
                else
                {
                    if (d < 0) //hit
                    {
                      //  if (GetComponent<Rigidbody>()) GetComponent<Rigidbody>().velocity = Vector3.zero;
                      //  if (GetComponent<Rigidbody>()) GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                        // Debug.Log("hit" + i); Vector3.zero;
                        nrHits++;
                        //collision
                        // if(!Input.GetKey(KeyCode.F))  transform.Translate((-ro[i].up) * d * 1.5f, Space.World);
                         transform.Translate(ro[i].forward * d * 1.5f, Space.World);// transform.position += Vector3.up * 0.01f; 

                        //  GetComponent<Rigidbody>().MovePosition((ro[i].forward + (ro[i].up*2)) * d * 1f);

                    }
                    

                }

            }
        }
        public float GetCameraDist()
        {

            Vector3 p = Globalprefs.camera.transform.position;
            //check hit

            float d = DistanceFieldRenderer(p);


            // Debug.Log(d);
            return d;

        }
        public float GetCenterDist()
        {

            Vector3 p = transform.position;
            //check hit

            float d = DistanceField(p);


            // Debug.Log(d);
            return d;

        }
        public bool CenterMarchCast(Vector3 origin, Vector3 direction)
        {
            Vector3 p = origin;
            float d = 0;
            bool castObeject = false;
            bool done = false;
            bool error = false;
            for (int t = 0; t < 40 && (!error || !done); t++)
            {

                p += (direction * d);
                d = DistanceField(p);

                float od = DistanceField(origin);
                //check hit
                if (d < 27.0f + (od / 80) && !done)
                {
                    castObeject = true;
                    //  Debug.Log(DistanceField(origin));
                    done = true;
                }
                if (Vector3.Distance(origin, p) > 500)
                {
                    error = true;

                }

            }
          

            //   Debug.Log(d);
            return castObeject;

        }
        public RaycastHit GetMarchCast(Vector3 origin, Vector3 direction)
        {
            RaycastHit hit = new RaycastHit();
            Vector3 p = origin;
            float d = 0;
            
            bool error = false;
            for (int t = 0; t < 40 && !error; t++)
            {

                p += (direction * d);
                d = DistanceField(p);

                
                if (Vector3.Distance(origin, p) > 500)
                {
                    error = true;

                }

            }
            if (Vector3.Distance(origin, p) < 500)
            {
                
                
                hit.point = p;
                hit.distance = Vector3.Distance(origin, p);
            }

            Globalprefs.RaymarchHitError = error;
            //   Debug.Log(d);
            return hit;

        }
        //moves the player to the ground
        void MoveToGround()
        {
            for (int i = 0;i<10;i++)
            {
                float a = i / 8;

                Vector3 p = transform.position - (Vector3.up * (a));
                //check hit

                float d = DistanceField(p);
                d = Mathf.Min(d, maxDownMovement); if (GetComponent<mover>())
                {
                    if (d < 0.0f)
                    {
                        if (!Input.GetKey(KeyCode.F)) GetComponent<mover>().physicsStop();
                        r = true;
                    }
                    else if (r)
                    {
                        if (!Input.GetKey(KeyCode.F)) GetComponent<mover>().physicsStart();
                        r = false;
                    }
                }
                if (d < 0.0f)
                {
                    if (GetComponent<spamton>()) GetComponent<spamton>().rayMarch = true;
                    r = true;
                }
                else if (r )
                {
                    r = false;
                }
                if (d < 0.0f)
                {
                    if (!GetComponent<mover>())
                    {
                        if (GetComponent<Rigidbody>()) GetComponent<Rigidbody>().velocity = Vector3.zero;
                        if (GetComponent<Rigidbody>()) GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    }
                }

                // Debug.Log(d);
                transform.Translate(Vector3.down * d, Space.World);
            }
        }

    }
}

