using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPhisycs : MonoBehaviour
{
    List<GameObject> g = new List<GameObject>();
    List<Vector3> v3 = new List<Vector3>();
    private void Update()
    {
        for (int i =0;i<g.Count&& i < v3.Count;i++)
        {
            if (g[i] != null) 
            {
                g[i].transform.position = v3[i]; 
            }
            else
            {
                g.RemoveAt(i);
                v3.RemoveAt(i);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            if (!other.GetComponent<StaticPoisition>())
            {
                g.Add(other.gameObject);
                v3.Add(other.transform.position);
                other.gameObject.AddComponent<StaticPoisition>();
            }
        }
        else
        {
            if (!other.GetComponent<StaticPoisition>())
            {
                g.Add(other.gameObject);
                v3.Add(other.transform.position);
                other.gameObject.AddComponent<StaticPoisition>();
            }
        }
    }
}
