using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "socialSysetem/socialTrrigerArray")]
public class SocialTriggerArray : ScriptableObject
{
    public SocialTrigger[] array;
    public string profesion;
}
