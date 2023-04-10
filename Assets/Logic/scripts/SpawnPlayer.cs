using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject mover;

    void Start()
    {
        Ray r = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(r,out hit))
        {
            Instantiate(mover,hit.point,Quaternion.identity);
        }
    }
    

}
