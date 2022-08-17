using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newScript", menuName = "script/.uns")]

public class UnsFormat : ScriptableObject
{
   [Multiline(200)]
    public string script;
    public GameObject[] gs; 
    public UnsFormat[] uns;
}
