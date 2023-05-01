using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESSERACT_SETTINGS : MonoBehaviour
{
    public Tesseract tes;
    GameObject g;
    void Start()
    {
        tes.viewPoint = new GameObject("view").transform;
        g = tes.viewPoint.gameObject;
    }
    private void OnDestroy()
    {
        Destroy(g);
    }
}
