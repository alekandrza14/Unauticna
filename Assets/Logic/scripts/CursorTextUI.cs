using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorTextUI : MonoBehaviour
{
   public Text text;
    void Update()
    {
        text.text = Globalprefs.selectitem;
        text.rectTransform.anchoredPosition3D = Input.mousePosition;
    }
    public static void SetText(string s)
    {
        Globalprefs.selectitem = s;


    }
}
