using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class JevilKarusel : MonoBehaviour
{
    float vel;
    bool V;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject parent2;
    private void OnCollisionEnter(Collision collision)
    {
        vel = VarSave.GetFloat("karusel");
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
        vel = VarSave.GetFloat("karusel");
        if (!collision.gameObject.GetComponent<ProBuilderMesh>())
            if (!collision.gameObject.GetComponent<Terrain>()) collision.gameObject.transform.SetParent(parent.transform);
    }

    private void OnTriggerExit(Collider collision)
    {

         if (!collision.gameObject.GetComponent<ProBuilderMesh>())
            if (!collision.gameObject.GetComponent<Terrain>()) collision.gameObject.transform.SetParent(parent2.transform);
    }
    private void Start()
    {
        vel = VarSave.GetFloat("karusel");
        V = true;
    }
    void Update()
    {
        vel += Time.deltaTime*4;
        transform.rotation = Quaternion.Euler(-90,vel,0);
      if(V)  VarSave.SetFloat("karusel", vel);
    }
}
