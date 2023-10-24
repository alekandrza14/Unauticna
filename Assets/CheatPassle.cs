using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheatPassle : MonoBehaviour
{
    static public int value;
    [SerializeField] TextMeshPro text;
    float timer;
    [SerializeField] GameObject item;
    [SerializeField] Transform spawnObject;
    bool y;

    void Update()
    {
        timer += Time.deltaTime;
        text.text = value + " : 3 ?= 1";
        if (timer > 1)
        {
            if (Random.Range(0, 2) == 0)
            {
                value = 2;
            }
            else
            {

                value = 4;
            }
            timer = 0;
        }
        if (value == 3 && !y)
        {
            Instantiate(item, spawnObject.position,Quaternion.identity);
            y = true;
        }
    }
}
