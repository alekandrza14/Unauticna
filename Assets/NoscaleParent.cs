using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NoscaleParentSettings
{
    noMove = 0, noRotate = 1, MoveandRotate = 2, palyerY = 3, PlayerRayEnd = 4, PayerCamera = 5,rotateCameraP = 6, PlayerPos = 7, RotPlayer = 8, PatrulPlayer = 9, onlyScale = 10, Rand1MCube = 11, palyerXZ = 12
}

public class NoscaleParent : MonoBehaviour
{
    public Transform Obj;
    Vector3 target;
    Vector3 diretional;
    float timer;
    public NoscaleParentSettings settings;
    private void Start()
    {
        if (settings == NoscaleParentSettings.PatrulPlayer)
        {
            transform.SetParent(new GameObject().transform);
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
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
        if (settings == NoscaleParentSettings.palyerXZ)
        {
            transform.position = new Vector3(mover.main().transform.position.x, transform.position.y, mover.main().transform.position.z);
        }
        if (settings == NoscaleParentSettings.PlayerRayEnd)
        {
            transform.position = MainRay.MainHit.point;
        }
        if (settings == NoscaleParentSettings.PayerCamera)
        {
            transform.position = Globalprefs.camera.transform.position;
            transform.rotation = Globalprefs.camera.transform.rotation;
        }
        if (settings == NoscaleParentSettings.rotateCameraP)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Globalprefs.camera.transform.rotation, 0.1f);
        }
        if (settings == NoscaleParentSettings.PlayerPos)
        {
            transform.position = Globalprefs.camera.transform.position;
        }
        if (settings == NoscaleParentSettings.RotPlayer)
        {
            transform.rotation = mover.main().transform.rotation;
            transform.Rotate(0, 180, 0);
        }
        if (settings == NoscaleParentSettings.PatrulPlayer)
        {
            target = mover.main().transform.position + diretional;
            if (timer > 5) 
            {
                diretional = Global.math.randomCube(-50, 50);
                timer = 0;
            }
            transform.position = target;
            transform.Rotate(0, 180, 0);
        }
        if (settings == NoscaleParentSettings.onlyScale)
        {
            transform.localScale = Obj.localScale;
        }
        if (settings == NoscaleParentSettings.Rand1MCube)
        {
            transform.position = Obj.position+ Global.math.randomCube(-100, 100)/80;
        }
    }
}
