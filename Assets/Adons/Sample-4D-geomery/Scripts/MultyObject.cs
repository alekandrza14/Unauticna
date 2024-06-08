using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum Shape
{
   shape3D, cube5D,clone5D, plane3D, shape4D, shapecube5D, hyperbola5D, hyperCurveCube5D, cubeND, slice4Dcube
}
[ExecuteAlways]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class MultyObject : MonoBehaviour
{

    MultyTransform instance;
    MeshCollider meshCollider;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    SphereCollider sphereCollider;
    [Header("Transform W")]
    public float W_Position;
    public float W_Count_Slice;
    public float W_Scale = 1;
    [Header("Transform H")]
    public float H_Position;
    public float H_Scale = 1;
    [Header("Transforms N")]
    public float[] N_Positions;
    public float[] N_Scales;
    [Header("Shape")]
    public Shape shape;
    public Mesh[] shapes3D;
    [SerializeField] Mesh[] shapes3Dcol;
    public shapeSettings shapeSettings;
    [SerializeField] GameObject[] Slices;
    [Header("Save prametrs")]
    public Vector3 scale3D = Vector3.one;
    GameObject[] childs;
    mover m;
   

    int w;
    void Start()
    {
        if (FindObjectsByType<MultyTransform>(sortmode.main).Length == 0)
        {


            GameObject g = new("4D Controler")
            {

            };


            g.AddComponent<MultyTransform>();
        }
        if (scale3D.x == 0 || scale3D.y == 0 || scale3D.z == 0) scale3D = Vector3.one;
        startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, W_Position, H_Position, 0);
        startScale = new Vector6(scale3D.x, scale3D.y, scale3D.z, W_Scale, H_Scale, 0);
        List<GameObject> countcild = new();
        float c = transform.childCount;
        for (int i = 0; i < c; i++)
        {
            countcild.Add(transform.GetChild(i).gameObject);
        }
        childs = countcild.ToArray();

        if (shape == Shape.shapecube5D)
        {
            shapes3Dcol = new Mesh[shapes3D.Length];
            for (int i = 0; i < shapes3D.Length; i++)
            {
                shapes3Dcol[i] = new()
                {
                    vertices = shapes3D[i].vertices,
                    triangles = shapes3D[i].triangles,
                    normals = shapes3D[i].normals,
                    uv = shapes3D[i].uv,
                    name = i.ToString()
                };

            }
        }
        if (!instance)
        {
            instance = FindFirstObjectByType<MultyTransform>();

        }
        meshCollider = GetComponent<MeshCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        sphereCollider = GetComponent<SphereCollider>();
        InvokeRepeating(nameof(ProjectionUpdate), 0.001f, 0.02f + Random.Range(0.01f, 0.02f));
        m = mover.main();

        //  if (mover.Get4DCam())   if (mover.Get4DCam()._wRotation.x != 0) Swap();
        // if (VarSave.GetBool("H_Roataton")) SwapH();
    }
    private void Update()
    {
        if (instance) if (GetComponent<StandartObject>() && !saved && Application.isPlaying)
            {
                W_Position = instance.W_Position;
                H_Position = instance.H_Position;
                N_Positions = m.N_position.ToArray();
                saved = true;
            }
        if (instance) if (GetComponent<itemName>() && !saved && Application.isPlaying)
            {
                W_Position = instance.W_Position;
                H_Position = instance.H_Position;
                N_Positions = m.N_position.ToArray();
                saved = true;
            }


    }
        // Update is called once per frame\
        [Header("Debug prametrs")]
    public Vector6 startPosition;
    public Vector6 startScale;
    public float w5 = 0;
    public float w6 = 0;
    public float h5 = 0;
    public float h6 = 0;

  public  Vector3 testScale;
   public bool saved;
    public void ProjectionUpdate()
    {
        if (instance)
        {
            if (instance && !GetComponent<HyperbolicPoint>())
            {
                Vector3 r = instance.W_Rotation;
                Quaternion quaternion = Quaternion.Euler(-r.x, r.y, r.z);

                w5 = Mathf.Lerp(W_Position, -startPosition.x, quaternion.x * 2);
                if(Move4DAxis.GetSelect != gameObject)  transform.position = Vector3.Lerp(new Vector3(startPosition.x, startPosition.y, startPosition.z), new Vector3(W_Position, startPosition.y, startPosition.z), quaternion.x * 2);
                w6 = Mathf.Lerp(W_Scale, scale3D.x, quaternion.x * 2);

                testScale = Vector3.Lerp(new Vector3(scale3D.x, scale3D.y, scale3D.z), new Vector3(W_Scale, scale3D.y, scale3D.z), quaternion.x * 2);

              if (w5 == float.PositiveInfinity || w5 == float.NegativeInfinity || w5 == float.NaN || w5 == 0)
                {
                    w5 = 0;
                }
                if (w6 == float.PositiveInfinity || w6 == float.NegativeInfinity || w6 == float.NaN || w6 == 0)
                {
                    w6 = 0.001f;
                }
                Quaternion quaternionh = Quaternion.Euler(-instance.HX_Rotation, 0, 0);

                h5 = Mathf.Lerp(H_Position, -transform.position.x, quaternionh.x * 2);
                if (Move4DAxis.GetSelect != gameObject) transform.position = Vector3.Lerp(new Vector3(transform.position.x, startPosition.y, startPosition.z), new Vector3(H_Position, startPosition.y, startPosition.z), quaternionh.x * 2);
                h6 = Mathf.Lerp(H_Scale, testScale.x, quaternionh.x * 2);
                testScale = Vector3.Lerp(new Vector3(testScale.x, scale3D.y, scale3D.z), new Vector3(H_Scale, scale3D.y, scale3D.z), quaternionh.x * 2);

               if (h5 == float.PositiveInfinity || h5 == float.NegativeInfinity || h5 == float.NaN || h5 == 0)
                {
                    h5 = 0;
                }
                if (h6 == float.PositiveInfinity || h6 == float.NegativeInfinity || h6 == float.NaN || h6 == 0)
                {
                    h6 = 0.001f;
                }
            }
            if (instance && GetComponent<HyperbolicPoint>())
            {


                w5 = W_Position;
                w6 = W_Scale; 
                h5 = H_Position;
                h6 = H_Scale;

                testScale  = new Vector3(scale3D.x, scale3D.y, scale3D.z);

             
               
            }
        }
        if (shape == Shape.plane3D)
        {
          if (!GetComponent<HyperbolicPoint>())  transform.localScale = new Vector3(100000, testScale.y, 100000);
        }
        if (shape == Shape.shape3D)
        {

            if (!GetComponent<HyperbolicPoint>()) transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
        }
        if (instance)
        {
            if (shape == Shape.cube5D)
            {

                if (!GetComponent<HyperbolicPoint>()) transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
            }
            if (shape == Shape.cube5D)
            {
                if (shapeSettings != null)
                {
                    if (shapeSettings.W_materials.Length != 0)
                    {



                        int w2 = (int)((((instance.W_Position - w5) * shapeSettings.W_materials.Length) / (w6 / 2)) - (w6 / 2));

                        if (w2 > -1 && w2 < shapeSettings.W_materials.Length)
                        {

                            if (meshRenderer)
                            {
                                meshRenderer.material = shapeSettings.W_materials[w2];
                            }


                        }
                    }
                }
                if (!GetComponent<HyperbolicPoint>()) transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
                if (instance.W_Position + w6 > w5 && instance.W_Position - w6 < w5 &&
                    instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = true;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                    if (childs.Length > 0) foreach (GameObject child in childs)
                    {
                            if (child != null) child.SetActive(true);
                    }
                }
                else
                {
                  if(childs.Length > 0)  foreach (GameObject child in childs)
                    {
                       if(child!=null) if (!child.GetComponent<Metka>()) child.SetActive(false);
                    }
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                }

            }
          
            if (shape == Shape.slice4Dcube)
            {
                for (int i =0; i< Slices.Length; i++) {
                   
                    if (instance.W_Position + w6 > w5 + (i*W_Count_Slice) && instance.W_Position - w6 < w5 + (i * W_Count_Slice) &&
                        instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                    {
                        GameObject slice = Slices[i];
                            slice.SetActive(true);
                      
                     
                    }
                    else
                    {
                        GameObject slice = Slices[i];
                        slice.SetActive(false);
                       
                    }
                }
            }
            if (shape == Shape.cubeND)
            {

                if (!GetComponent<HyperbolicPoint>()) transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
                bool s1 = false;
                for (int i =0;i< m.N_position.Count&& s1 != true;i++)
                {
                    if (N_Positions.Length -1<i)
                    {
                        List<float> n = N_Positions.ToList();
                        n.Add(0);

                        N_Positions = n.ToArray();

                        List<float> n2 = N_Scales.ToList();
                        n2.Add(1);

                        N_Scales = n2.ToArray();
                    }
                    if (N_Positions.Length != N_Scales.Length)
                    {
                        for (int i2 = 0; i2 < N_Positions.Length - N_Scales.Length; i2++)
                        {
                            List<float> n2 = N_Scales.ToList();
                            n2.Add(1);

                            N_Scales = n2.ToArray();
                        }
                    }
                    if (!GetComponent<HyperbolicPoint>()) transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
                    if (instance.W_Position + w6 > w5 && instance.W_Position - w6 < w5 &&
                        instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5 &&
                         m.N_position[i] + N_Scales[i] > N_Positions[i] && m.N_position[i] - N_Scales[i] < N_Positions[i])
                    {
                        if (meshRenderer)
                        {
                            meshRenderer.enabled = true;
                        }
                        if (meshCollider)
                        {
                            meshCollider.enabled = true;
                        }
                        if (boxCollider)
                        {
                            boxCollider.enabled = true;
                        }
                        if (sphereCollider)
                        {
                            sphereCollider.enabled = true;
                        }
                        foreach (GameObject child in childs)
                        {
                            child.SetActive(true);
                        }
                    }
                    else if(Map_saver.LoadADone)
                    {

                        foreach (GameObject child in childs)
                        {
                            if (!child.GetComponent<Metka>()) child.SetActive(false);
                        }
                        if (meshRenderer)
                        {
                            meshRenderer.enabled = false;
                        }
                        if (meshCollider)
                        {
                            meshCollider.enabled = false;
                        }
                        if (boxCollider)
                        {
                            boxCollider.enabled = false;
                        }
                        if (sphereCollider)
                        {
                            sphereCollider.enabled = false;
                        }
                        s1 = true;
                    }
                }
            }
            if (shape == Shape.shapecube5D)
            {
                if (shapeSettings != null)
                {
                    if (shapeSettings.W_materials.Length != 0)
                    {



                        int w2 = (int)((((instance.W_Position - w5) * shapeSettings.W_materials.Length) / (w6 / 2)) - (w6 / 2));

                        if (w2 > -1 && w2 < shapeSettings.W_materials.Length)
                        {

                            if (meshRenderer)
                            {
                                meshRenderer.material = shapeSettings.W_materials[w2];
                            }


                        }
                    }
                }
                transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
                w = (int)(((instance.W_Position - w5) * shapes3D.Length) / (w6 / 2));




                if (w > -1 && w < shapes3Dcol.Length)
                {

                    if (GetComponent<MeshFilter>())
                    {
                        GetComponent<MeshFilter>().sharedMesh = shapes3Dcol[w];
                    }


                }



                if (instance.W_Position > w5 && instance.W_Position - w6 < w5 &&
                    instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = true;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                }
                else
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                }

            }
            if (shape == Shape.shape4D)
            {
                if (shapeSettings != null)
                {
                    if (shapeSettings.W_materials.Length != 0)
                    {



                        int w2 = (int)((((instance.W_Position - w5) * shapeSettings.W_materials.Length) / (w6 / 2)) - (w6 / 2));

                        if (w2 > -1 && w2 < shapeSettings.W_materials.Length)
                        {

                            if (meshRenderer)
                            {
                                meshRenderer.material = shapeSettings.W_materials[w2];
                            }


                        }
                    }
                }
                transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
                w = (int)(((instance.W_Position - w5) * shapes3D.Length) / (w6 / 2));




                if (w > -1 && w < shapes3D.Length)
                {

                    if (GetComponent<MeshFilter>())
                    {
                        GetComponent<MeshFilter>().sharedMesh = shapes3D[w];
                    }


                }



                if (instance.W_Position > w5 && instance.W_Position - w6 < w5)
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = true;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                }
                else
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                }

            }
            if (shape == Shape.clone5D)
            {
                if (shapeSettings != null)
                {
                    if (shapeSettings.W_materials.Length != 0)
                    {



                        int w2 = (int)((((instance.W_Position - w5) * shapeSettings.W_materials.Length) / (w6 / 2)) - (w6 / 2));

                        if (w2 > -1 && w2 < shapeSettings.W_materials.Length)
                        {

                            if (meshRenderer)
                            {
                                meshRenderer.material = shapeSettings.W_materials[w2];
                            }


                        }
                    }
                }
                float h = h6 - Mathf.Abs(H_Position - instance.H_Position);
             //   Vector3 v3 = testScale;

                float w = w6 - Mathf.Abs(w5 - instance.W_Position);
                float s = ((w / w6) + (h / h6)) / 2;
                transform.localScale = new Vector3(s * testScale.x, s * testScale.y, s * testScale.z);
                if (instance.W_Position + w6 > w5 && instance.W_Position - w6 < w5 &&
                   instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = true;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                    foreach (GameObject child in childs)
                    {
                        child.SetActive(true);
                    }
                }
                else
                {
                    foreach (GameObject child in childs)
                    {
                        if (!child.GetComponent<Metka>()) child.SetActive(false);
                    }
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                }
            }
            if (shape == Shape.hyperbola5D)
            {
                if (shapeSettings != null)
                {
                    if (shapeSettings.W_materials.Length != 0)
                    {



                        int w2 = (int)((((instance.W_Position - w5) * shapeSettings.W_materials.Length) / (w6 / 2)) - (w6 / 2));

                        if (w2 > -1 && w2 < shapeSettings.W_materials.Length)
                        {

                            if (meshRenderer)
                            {
                                meshRenderer.material = shapeSettings.W_materials[w2];
                            }


                        }
                    }
                }
                float h = h6 + Mathf.Abs(H_Position - instance.H_Position) * Mathf.Abs(H_Position - instance.H_Position);
              //  Vector3 v3 = testScale;

                float w = w6 + Mathf.Abs(w5 - instance.W_Position) * Mathf.Abs(W_Position - instance.W_Position);
                float s = ((w / w6) + (h / h6)) / 2;
                transform.localScale = new Vector3(s * testScale.x, s * testScale.y, s * testScale.z);
                if (instance.W_Position + w6 > w5 && instance.W_Position - w6 < w5 &&
                    instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = true;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                }
                else
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                }
            }
            if (shape == Shape.hyperCurveCube5D && shapeSettings != null)
            {
                float h = (h6 - Mathf.Abs(H_Position - instance.H_Position)) / h6;
              //  Vector3 v3 = testScale;

                float w = (w6 - Mathf.Abs(w5 - instance.W_Position)) / w6;
                transform.localScale = new Vector3(
                     testScale.x * shapeSettings.WX_scale.Evaluate(w) * shapeSettings.HX_scale.Evaluate(h),
                     testScale.y * shapeSettings.WY_scale.Evaluate(w) * shapeSettings.HY_scale.Evaluate(h),
                     testScale.z * shapeSettings.WZ_scale.Evaluate(w) * shapeSettings.HZ_scale.Evaluate(h));
                if (instance.W_Position + w6 > w5 && instance.W_Position - w6 < w5 &&
                    instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = true;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                }
                else
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                }
            }
            if (meshCollider)
            {

                meshCollider.sharedMesh = GetComponent<MeshFilter>().sharedMesh;

            }
        }
    }
}
