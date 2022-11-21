using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _4dphisic : MonoBehaviour
{
    public Tesseract tes;
    private void OnCollisionStay(Collision collision)
    {
        tes.rotationXW += Random.Range(0, 2);
        tes.rotationYW += Random.Range(0, 2);
        tes.rotationZW += Random.Range(0, 2);
        tes.rotationZX += Random.Range(0, 2);
        tes.rotationXY += Random.Range(0, 2);
        tes.rotationYZ += Random.Range(0, 2);
    }
   
}
