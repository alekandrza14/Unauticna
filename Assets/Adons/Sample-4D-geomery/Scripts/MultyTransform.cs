using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class MultyTransform : MonoBehaviour
{
    public float W_Position,H_Position;
    public Vector3 W_Rotation;
    private void Update()
    {
      if( Application.isPlaying)  W_Position = mover.main().W_position;
        MultyObject[] g = FindObjectsByType<MultyObject>(FindObjectsSortMode.InstanceID);
        if (Application.isPlaying) W_Rotation = mover.Get4DCam()._wRotation;
        foreach (MultyObject obj in g)
        {
            obj.Update();
        }
    }
    private void OnGUI()
    {
      //  GUI.Label(new Rect(0,0,600,60),"World Position x : " + transform.position.x + " y : " + transform.position.y + " z : " + transform.position.z + " w : " + W_Position + " h : " + H_Position);
    }
}
