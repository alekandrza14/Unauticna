using UnityEngine;
using UnityEngine.UI;

public class CheatEngineLoca : MonoBehaviour
{
    static public int value;
    static public int value1;
    static public int value2;
    static public int value3;
    public int value4;
    [SerializeField] Text text;
    float timer;
    [SerializeField] Button knopka;
    bool y;
    int val;
    void Update()
    {
        if (value4 == 1)
        {
            timer += Time.deltaTime;
            text.text = "CheatEngine Взлом" + value + " : 3 ?= 1";
            if (timer > 1)
            {
                val = Global.Random.Range(0, 5);
                if (val != 3)
                {
                    value = val;
                }

                timer = 0;
            }
            if (value == 3 && !y)
            {
                knopka.interactable = true;
                y = true;
            }
        }
        if (value4 == 2)
        {
            timer += Time.deltaTime;
            text.text = "CheatEngine Взлом" + value1 + " : 3 ?= 1";
            if (timer > 1)
            {
                val = Global.Random.Range(0, 5);
                if (val != 3)
                {
                    value1 = val;
                }

                timer = 0;
            }
            if (value1 == 3 && !y)
            {
                knopka.interactable = true;
                y = true;
            }
        }
        if (value4 == 3)
        {
            timer += Time.deltaTime;
            text.text = "CheatEngine Взлом" + value2 + " : 3 ?= 1";
            if (timer > 1)
            {
                val = Global.Random.Range(0, 5);
                if (val != 3)
                {
                    value2 = val;
                }

                timer = 0;
            }
            if (value2 == 3 && !y)
            {
                knopka.interactable = true;
                y = true;
            }
        }
        if (value4 == 4)
        {
            timer += Time.deltaTime;
            text.text = "CheatEngine Взлом" + value3 + " : 3 ?= 1";
            if (timer > 1)
            {
                val = Global.Random.Range(0, 5);
                if (val != 3)
                {
                    value3 = val;
                }

                timer = 0;
            }
            if (value3 == 3 && !y)
            {
                knopka.interactable = true;
                y = true;
            }
        }
      
    }
}
