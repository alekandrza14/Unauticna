using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(HyperbolicCamera))]
public class ED1 : Editor
{
    const string resourceFilename = "custom-editor-uie";
    public static bool load;
    public override void OnInspectorGUI()
    {
     

        
            


    HyperbolicCamera mp = (HyperbolicCamera)target;
        
       

      //  for (int i = 0; i < GameObject.FindObjectsOfType<tringle>().Length; i++)
      //  {
      //      GameObject.FindObjectsOfType<tringle>()[i].up2(HyperbolicCamera.Main().polarTransform);
      //  }
      
        base.OnInspectorGUI();
        
    }



}
