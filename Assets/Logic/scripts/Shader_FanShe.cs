using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Shader_FanShe : MonoBehaviour
{
    Cubemap cubeMap;
     Camera cam;
    Material curmat;
    float tic; Cubemap generateCubemap()
    {
        Cubemap c = new Cubemap(256, TextureFormat.ARGB32, 1) { hideFlags = HideFlags.None };

        return c;
    }
    // Use this for initialization
    void Start()
    {
      cubeMap = generateCubemap();
       if (Camera.main) cam = Camera.main;
        if (GameObject.FindFirstObjectByType<Logic_tag_3>()) cam = GameObject.FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>();
        InvokeRepeating("change", 1, 0.05f);
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("Mirror");
        curmat = GetComponent<MeshRenderer>().material;
        if (curmat == null)
        {
            Debug.Log("cw");
        }

    }
    
    
    void change()
    {
        
        cam.RenderToCubemap(cubeMap);
        curmat.SetTexture("_Cubemap", cubeMap);
          curmat.SetTexture("_Cube", cubeMap);
    }

}
