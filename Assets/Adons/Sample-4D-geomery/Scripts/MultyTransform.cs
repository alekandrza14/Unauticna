using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class MultyTransform : MonoBehaviour
{
    public float W_Position,H_Position;
    private void Update()
    {
      if( Application.isPlaying)  W_Position = mover.main().w;
        MultyObject[] g = FindObjectsByType<MultyObject>(FindObjectsSortMode.InstanceID);
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
