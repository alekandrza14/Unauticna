using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class sity : MonoBehaviour
{
    public Vector3 campos; 
    public Vector3 ppos;
    public MeshRenderer m;
    
    void LateUpdate()
    {
        campos = Camera.main.transform.position;

        campos += ppos;
        transform.position = Camera.main.transform.position;
        m.material.SetFloat("P1", -campos.x / transform.localScale.x);
        m.material.SetFloat("P2", -campos.y / transform.localScale.y);
        m.material.SetFloat("P3", -campos.z / transform.localScale.z);
    }
    public void EditorUpdate( Vector3 cam)
    {
        campos = cam;
        campos += ppos;
        transform.position = cam;
        m.material.SetFloat("P1", -campos.x / transform.localScale.x);
        m.material.SetFloat("P2", -campos.y / transform.localScale.y);
        m.material.SetFloat("P3", -campos.z / transform.localScale.z);
    }
}
