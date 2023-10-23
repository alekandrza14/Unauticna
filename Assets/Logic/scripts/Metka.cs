using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metka : MonoBehaviour
{
    public Vector3 scale;
    void Update()
    {
      //  gameObject.transform.localScale= scale * Vector3.Distance(gameObject.transform.position,GameManager.GetPlayer().position);
      //  gameObject.transform.rotation = Quaternion.LookRotation(gameObject.transform.position- GameManager.GetPlayer().position, GameManager.GetPlayer().position);
    }
}
