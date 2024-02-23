using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NoscaleParentSettings
{
    noMove,noRotate,MoveandRotate,palyerY
}

public class NoscaleParent : MonoBehaviour
{
    [SerializeField] public Transform Obj;
    [SerializeField] NoscaleParentSettings settings;
    
    void Update()
    {
        if (settings == NoscaleParentSettings.noMove)
        {
            transform.rotation = Obj.rotation;
        }
        if (settings == NoscaleParentSettings.noRotate)
        {
            transform.position = Obj.position;
        }
        if (settings == NoscaleParentSettings.MoveandRotate)
        {
            transform.position = Obj.position;
            transform.rotation = Obj.rotation;
        }
        if (settings == NoscaleParentSettings.palyerY)
        {
            transform.position = new Vector3(transform.position.x, mover.main().transform.position.y, transform.position.z);
        }
    }
}
