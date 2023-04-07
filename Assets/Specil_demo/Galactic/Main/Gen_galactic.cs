using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen_galactic : MonoBehaviour
{
    [SerializeField] GameObject star;
    void Start()
    {
        for (int i =0 ; i < 2000 ; i++)
        {


            Vector3 v3 = new Vector3(Random.Range(-150, 150), Random.Range(-70, 70), Random.Range(-150, 150));
            Instantiate(star, transform.position + v3, Quaternion.identity);
        }
    }

}
