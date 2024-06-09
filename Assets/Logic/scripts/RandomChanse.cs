using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChanse : MonoBehaviour
{
    private void Start()
    {
        if (Global.Random.Chance(2))
        {
            Destroy(gameObject);
        }
    }
}
