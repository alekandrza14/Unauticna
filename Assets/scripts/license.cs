using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

[CreateAssetMenu(fileName = "license", menuName = "licenses/license delux")]
public class license : ScriptableObject
{
    public string code = "000-000";
    public string version = "0.1";
}
