using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire0DSphere3D : MonoBehaviour
{
   public List<GameObject> objs = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        objs.Add(other.gameObject);
    }
    // Update is called once per frame
   public void Activate()
    {
        foreach (GameObject obj in objs) 
        {
         if(obj!= null)   foreach (MonoBehaviour mb in obj.GetComponents<MonoBehaviour>())
            {
                mb.Invoke("OnSignal",0.01f);
            }
        }
    }
}
