using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NoscaleParentSettings
{
    noMove = 0, noRotate = 1, MoveandRotate = 2, palyerY = 3, PlayerRayEnd = 4, PayerCamera = 5
}

public class NoscaleParent : MonoBehaviour
{
    public Transform Obj;
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
        if (settings == NoscaleParentSettings.PlayerRayEnd)
        {
            transform.position = MainRay.MainHit.point;
        }
        if (settings == NoscaleParentSettings.PayerCamera)
        {
            transform.position = Globalprefs.camera.transform.position;
        }
    }
}
