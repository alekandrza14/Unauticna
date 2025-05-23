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
    [Range(0, 3)]
    public int p5;
    public bool Prefab;
    public Transform PrefabPosition;
    private void Start()
    {
        if (Application.isPlaying) 
        {
            Prefab = true;
        }
    }

    void LateUpdate()
    {
        if (Prefab)
        {
            if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length == 0) campos = Camera.main.transform.position;
            if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
            {
                campos = FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().transform.position;
            }
            campos += ppos;
            if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length == 0) transform.position = Camera.main.transform.position;
            if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
            {
                transform.position = FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().transform.position;
            }
            if (PrefabPosition)
            {
                campos -= PrefabPosition.position;
            }
            if (m.material)
            {
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
    }
    public void EditorUpdate(Vector3 cam)
    {
        if (Prefab)
        {
            campos = cam;
            campos += ppos;
            if (PrefabPosition)
            {
                campos -= PrefabPosition.position;
            }
            transform.position = cam;
            if (m.material)
            {
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
    }
}
