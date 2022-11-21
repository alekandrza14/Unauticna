using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESSERACT_SETTINGS : MonoBehaviour
{
    public Tesseract tes;
    void Start()
    {
        tes.viewPoint = new GameObject("view").transform;
    }
}
