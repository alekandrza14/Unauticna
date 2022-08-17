using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enginemanager : MonoBehaviour
{
    public GameObject create(GameObject gameObject,Vector3 v3,Quaternion q)
    {
        GameObject g = Instantiate(gameObject, v3, q);
        return g;
    }
}
