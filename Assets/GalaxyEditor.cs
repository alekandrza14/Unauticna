using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyEditor : MonoBehaviour
{
    public GameObject[] PaternPrefab;
    void Update()
    {
        if (Input.GetKeyDown("2"))
        {
            Transform t = Instantiate(PaternPrefab[0].gameObject, transform.position, Quaternion.identity).transform;

        }
        if (Input.GetKeyDown("3"))
        {
            Transform t = Instantiate(PaternPrefab[1].gameObject, transform.position, Quaternion.identity).transform;

        }
        if (Input.GetKeyDown("4"))
        {
            Transform t = Instantiate(PaternPrefab[2].gameObject, transform.position, Quaternion.identity).transform;

        }
        if (Input.GetKeyDown("5"))
        {
            Transform t = Instantiate(PaternPrefab[3].gameObject, transform.position, Quaternion.identity).transform;

        }
        if (Input.GetKeyDown("6"))
        {
            Transform t = Instantiate(PaternPrefab[4].gameObject, transform.position, Quaternion.identity).transform;

        }
        if (Input.GetKeyDown("7"))
        {
            Transform t = Instantiate(PaternPrefab[5].gameObject, transform.position, Quaternion.identity).transform;

        }
        if (Input.GetKeyDown("8"))
        {
            Transform t = Instantiate(PaternPrefab[6].gameObject, transform.position, Quaternion.identity).transform;

        }
        if (Input.GetKeyDown("9"))
        {
            Transform t = Instantiate(PaternPrefab[7].gameObject, transform.position, Quaternion.identity).transform;

        }
        if (Input.GetKeyDown("0"))
        {
            Transform t = Instantiate(PaternPrefab[8].gameObject, transform.position, Quaternion.identity).transform;

        }
    }
}
