using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class sity : MonoBehaviour
{
    public Vector3 campos; 
    public Vector3 ppos;
    public MeshRenderer m;
    public bool issnow;
    [Range(0,3)]
    public int p5;
    
    void LateUpdate()
    {
        if (FindObjectsOfType<Logic_tag_3>().Length == 0) campos = Camera.main.transform.position;
        if (FindObjectsOfType<Logic_tag_3>().Length != 0)
        {
            campos = FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().transform.position;
        }
        campos += ppos;
        if (FindObjectsOfType<Logic_tag_3>().Length == 0) transform.position = Camera.main.transform.position;
        if (FindObjectsOfType<Logic_tag_3>().Length != 0)
        {
            transform.position = FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().transform.position;
        }
        
        m.material.SetFloat("P1", -campos.x / transform.localScale.x);
        m.material.SetFloat("P2", -campos.y / transform.localScale.y);
        m.material.SetFloat("P3", -campos.z / transform.localScale.z);
        m.material.SetFloat("Pos1", -campos.x / transform.localScale.x);
        m.material.SetFloat("Pos2", -campos.y / transform.localScale.y);
        m.material.SetFloat("Pos3", -campos.z / transform.localScale.z);
        if (issnow)
        {


            m.material.SetFloat("P5", p5);
        }
    }
    public void EditorUpdate( Vector3 cam)
    {
        campos = cam;
        campos += ppos;
        transform.position = cam;
        m.material.SetFloat("P1", -campos.x / transform.localScale.x);
        m.material.SetFloat("P2", -campos.y / transform.localScale.y);
        m.material.SetFloat("P3", -campos.z / transform.localScale.z);
        m.material.SetFloat("Pos1", -campos.x / transform.localScale.x);
        m.material.SetFloat("Pos2", -campos.y / transform.localScale.y);
        m.material.SetFloat("Pos3", -campos.z / transform.localScale.z);
        if (issnow)
        {


            m.material.SetFloat("P5", p5);
        }
    }
}
