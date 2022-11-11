using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materys : MonoBehaviour
{
    public string texture;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        WWW www = new WWW("file:///res/"+texture);
        mat = GetComponent<MeshRenderer>().material;
        mat.SetTexture("_MainTex",www.texture);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
