using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalMaterish : MonoBehaviour
{
    public void spawnMatrs(string matr)
    {
        Instantiate(Resources.Load<GameObject>("ui/mats/"+matr).gameObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
