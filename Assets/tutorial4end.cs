using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial4end : MonoBehaviour
{
    [SerializeField] Transform point;
    [SerializeField] GameObject item;
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag == "jk")
        {
            StartCoroutine(vin());
        }
    }
    public IEnumerator vin()
    {

        Instantiate(item, point.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(9f);
        musave.Dest();
        musave.chargescene(0);

    }
}
