using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class JevilKarusel : MonoBehaviour
{
    float vel;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject parent2;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent<ProBuilderMesh>())
            if (!collision.gameObject.GetComponent<Terrain>()) collision.gameObject.transform.SetParent(parent.transform);
    }

    private void OnCollisionExit(Collision collision)
    {

         if (!collision.gameObject.GetComponent<ProBuilderMesh>())
            if (!collision.gameObject.GetComponent<Terrain>()) collision.gameObject.transform.SetParent(parent2.transform);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.GetComponent<ProBuilderMesh>())
            if (!collision.gameObject.GetComponent<Terrain>()) collision.gameObject.transform.SetParent(parent.transform);
    }

    private void OnTriggerExit(Collider collision)
    {

         if (!collision.gameObject.GetComponent<ProBuilderMesh>())
            if (!collision.gameObject.GetComponent<Terrain>()) collision.gameObject.transform.SetParent(parent2.transform);
    }
  
    void Update()
    {
        vel += Time.deltaTime*4;
        transform.rotation = Quaternion.Euler(-90,vel,0);
    }
}
