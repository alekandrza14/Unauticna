using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityDebugScript : MonoBehaviour
{

    [SerializeField] private string guid;
    public string Guid => guid;
    void Start()
    {
        GetComponent<Text>().text = Guid;
    }
}

