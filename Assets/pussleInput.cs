using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pussleInput : MonoBehaviour
{
    [SerializeField] Transform FirstPosition,SecondPosition;
    [SerializeField] Transform LinePosition;
    [SerializeField] AnimationCurve lineMove;
    [SerializeField] Slider slider;
    
    void Update()
    {
        LinePosition.position = (FirstPosition.position * lineMove.Evaluate(slider.value))+ (SecondPosition.position * (1 -lineMove.Evaluate(slider.value)));
    }
}
