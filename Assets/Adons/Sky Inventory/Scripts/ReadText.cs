using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadText : MonoBehaviour
{
    public Text text;
    public void SelectItem()
    {
        for (int i = 0; i < text.text.Length; i++)
        {


            if (text.text[i] != '_')
            {


                Globalprefs.selectitem += text.text[i];

            }
            if (text.text[i] == '_')
            {


                Globalprefs.selectitem += " ";

            }


        }
    }
    public void DeselectItem()
    {


        Globalprefs.selectitem = "";




    }
}
