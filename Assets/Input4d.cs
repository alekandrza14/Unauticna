using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input4d : MonoBehaviour
{
    public Scrollbar rotateX;
    public Scrollbar rotateY;
    public Scrollbar rotateZ;
    public Scrollbar rotateXW;
    public Scrollbar rotateYW;
    public Scrollbar rotateZW;
    [SerializeField] Shape4D shape;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shape.rotationW = new Vector3(
            rotateXW.value,
            rotateYW.value,
            rotateZW.value)*360;
        shape.transform.rotation = Quaternion.Euler(rotateX.value * 360,
            rotateY.value * 360,
            rotateZ.value * 360);
    }
}
