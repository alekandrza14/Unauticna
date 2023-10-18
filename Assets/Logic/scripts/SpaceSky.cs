using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSky : MonoBehaviour
{
    public Material[] material;
    void Start()
    {
      UniverseSkyType skyType = (UniverseSkyType)VarSave.GetInt("UST");
        RenderSettings.skybox = material[(int)skyType];
    }
}
