using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
[CreateAssetMenu(fileName ="Multimate Pipline Render",menuName = "Main/Multimate PipleneSetings")]
public class StanadartMaterials : ScriptableObject
{
    public Material[] build;
    public Material[] univesal;
}
