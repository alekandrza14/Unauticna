using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonAl2 : MonoBehaviour
{
    [SerializeField] GameObject GetObjectInterface;
    [SerializeField] Text NameObjectText;
    [SerializeField] Text PositionText;
    [SerializeField] Text FreedomPositionText;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            PositionText.text = Globalprefs.PlayerPositionInfo;
            FreedomPositionText.text = Globalprefs.AnyversePlayerPositionInfo;
            if (!string.IsNullOrEmpty(Globalprefs.selectitem))
            {
                NameObjectText.text = "Last Object Item : (" + Globalprefs.selectitem + ")";
            }
            else if (!string.IsNullOrEmpty(Globalprefs.selectcharacter))
            {
                NameObjectText.text = "Last Object Creature : (" + Globalprefs.selectcharacter + ")";
            }
            else
            {
                NameObjectText.text = "Last Object Is Null";
            }
            GetObjectInterface.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            GetObjectInterface.SetActive(false);
        }
    }
}
