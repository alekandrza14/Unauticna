using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public RenderTextureDescriptor s;
    public GameObject cam; 
    public GameObject texture;
    // Start is called before the first frame update
    void Start()
    {
        s = new RenderTextureDescriptor(1000, 1000, RenderTextureFormat.ARGB32);
        UnityEngine.RenderTexture r = new UnityEngine.RenderTexture(s);
        cam.GetComponent<Camera>().targetTexture = r;
        texture.GetComponents<MeshRenderer>()[0].material.SetTexture("_MainTex",r);
    }

   
}
