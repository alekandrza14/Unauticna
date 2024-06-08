using System;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Rigidbody body;
    public Transform[] sides;
    void Vin()
    {
        for(int i=0; i<sides.Length;i++)
        {
            var side = sides[i];
            if (side.up.y >0.6)
            {
                Globalprefs.LoadTevroPrise((decimal)Math.Cosh(i - 2 * 4));
            }
        }
    }
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameObject == hit.collider.gameObject)
            {
                body.AddForce(5 * mover.main().transform.forward, ForceMode.Impulse);
                body.AddRelativeForce(5 * mover.main().transform.forward, ForceMode.Impulse);
                Invoke(nameof(Vin),5);
            }
        }
    }
}
