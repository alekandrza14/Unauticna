using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[ExecuteAlways]
public class show4D : MonoBehaviour
{
    public float w_pos;
    float w;
    public float w_scale;
    RaymarchCam r;
    public Vector3 scale = Vector3.one;
    public Vector3 pos;
  public  bool atx;
    public bool aty;
    public bool atz;
    Vector3 p;
    [SerializeField] GameObject[] g;
    [SerializeField] MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        r = mover.Get4DCam();
    }

    void swap()
    {



        Quaternion quaternion = Quaternion.Euler(r._wRotation.x, r._wRotation.y, r._wRotation.z);
  
            w = w_pos;
        w += transform.position.x * quaternion.x;
        w += transform.position.y * quaternion.y;
        w += transform.position.z * quaternion.z;



    }

    // Update is called once per frame
    void Update()
    {
        swap();
        r = mover.Get4DCam();
        if (w-w_scale < r._wPosition && w + w_scale > r._wPosition)
        {
         float poectscale = w_scale - ( w  - r._wPosition);
            if (poectscale > w_scale)
            {
                poectscale = w_scale + (w - r._wPosition);
            }
           transform.localScale = scale * poectscale; 
            mr.enabled = true;
            
        }
        else
        {
            mr.enabled = false;
            transform.localScale = Vector3.one * .0001f;
        }
    }
}
