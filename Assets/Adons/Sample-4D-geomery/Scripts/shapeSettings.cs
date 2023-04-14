using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "shapeSettings",menuName = "4D/shapeSettings")]
public class shapeSettings : ScriptableObject
{
    [Header("Scale")]
    public AnimationCurve WX_scale;
    public AnimationCurve WY_scale;
    public AnimationCurve WZ_scale;
    public AnimationCurve HX_scale;
    public AnimationCurve HY_scale;
    public AnimationCurve HZ_scale;
    [Header("Materials")]
    public Material[] W_materials;
}
