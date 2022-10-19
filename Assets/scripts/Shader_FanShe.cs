using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Shader_FanShe : MonoBehaviour
{
    public Cubemap cubeMap;
    public Camera cam;
    Material curmat;
    float tic;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("change", 1, 0.1f);
        curmat = gameObject.GetComponent<Renderer>().material;
        
        if (curmat == null)
        {
            Debug.Log("cw");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void change()
    {
        cam.transform.rotation = Camera.main.transform.rotation;
        cam.RenderToCubemap(cubeMap);
        curmat.SetTexture("_Cubemap", cubeMap);
    }

}
