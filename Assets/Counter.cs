using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] TextMeshPro _text;
    [SerializeField] Text _text1;
    [SerializeField] string VarKey;
    [SerializeField] string ��������;
    void Update()
    {
       if(_text != null) _text.text = �������� + VarSave.GetTrash(VarKey, 0);
        if(_text1 != null)  _text1.text = �������� + VarSave.GetTrash(VarKey, 0);
    }
}
