using System.IO;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class мясотекст : InventoryEvent
{

    [SerializeField] itemName itemName;
    [SerializeField] Text txt;
    string pichure;
    public string CO_VoxelModel;
    string oldpichure;
    // Start is called before the first frame update
    public void Load1()
    {

        if (GetComponent<itemName>())
        {

            pichure = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(pichure))
            {
                pichure = "Random()";


                while (pichure == "Random()")
                {
                    if (Map_saver.t3[UnityEngine.Random.Range(0, Map_saver.t3.Length)].GetComponent<Мясо>())
                    {
                        pichure = Map_saver.t3[UnityEngine.Random.Range(0, Map_saver.t3.Length)].name;
                    }
                }
                GetComponent<itemName>().ItemData = pichure;
            }


        }


        txt.text = "[" + pichure + "] был переработан у него может быть сложилась хорошая жизнь без вас хех на мясо от вашей ужасной растравы эта ужасная истина будет вам портить жизнь этого перснажа будут помнить любить а вас нет!";
    }
   
    

    bool i;
    private void Start()
    {
         if (GetComponent<itemName>())
            {

                pichure = GetComponent<itemName>().ItemData;

                if (string.IsNullOrEmpty(pichure))
                {
                    pichure = "Random()";
                    while (pichure == "Random()")
                    {
                        if (Map_saver.t3[UnityEngine.Random.Range(0, Map_saver.t3.Length)].GetComponent<Мясо>())
                        {
                            pichure = Map_saver.t3[UnityEngine.Random.Range(0, Map_saver.t3.Length)].name;
                        }
                    }
                    GetComponent<itemName>().ItemData = pichure;
                }


            }
        txt.text = "["+ pichure + "] был переработан у него может быть сложилась хорошая жизнь без вас хех на мясо от вашей ужасной растравы эта ужасная истина будет вам портить жизнь этого перснажа будут помнить любить а вас нет!";
    }
   
}