using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class MultyTransform : MonoBehaviour
{
    public float W_Position,H_Position;
    public Vector3 W_Rotation;
    public float HX_Rotation;
    private void Update()
    {
        if (Application.isPlaying) W_Position = mover.main().W_position;
        if (Application.isPlaying) H_Position = mover.main().H_position;
        if (Application.isPlaying) HX_Rotation = mover.main().HX_Rotation;
        MultyObject[] g = FindObjectsByType<MultyObject>(FindObjectsSortMode.InstanceID);
        if (Application.isPlaying) W_Rotation = mover.Get4DCam()._wRotation;
        if (!Application.isPlaying) foreach (MultyObject obj in g)
        {
            obj.ProjectionUpdate();
        }
        
    }
    private void OnGUI()
    {
      //  GUI.Label(new Rect(0,0,600,60),"World Position x : " + transform.position.x + " y : " + transform.position.y + " z : " + transform.position.z + " w : " + W_Position + " h : " + H_Position);
    }
}
