using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MagicString : MonoBehaviour
{
    public TMP_Text Sample_text;
    public void SetText(string s)
    {
        Sample_text.text = s;

    }
}
