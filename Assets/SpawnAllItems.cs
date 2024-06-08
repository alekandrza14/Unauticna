using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAllItems : MonoBehaviour
{
    int y;
    int x2;
    int x;
    int i;
    private void Start()
    {
        double sx1 = Math.Sqrt((double)Map_saver.t3.Length);
        x = (int)sx1;
    }
    void Update()
    {
        double sx1 = Math.Sqrt((double)Map_saver.t3.Length);
        int sx = (int)sx1;
        if (i< Map_saver.t3.Length)
        {
          if(Map_saver.t3[i].GetComponent<itemName>()._Name != "AnyphingItems")  Instantiate(Map_saver.t3[i],transform.position+new Vector3((i*20)+(x2*20),0,y*20),Quaternion.identity);
            if (i > x)
            {
                x2 -= sx;
                x += sx;
                y++;
            }
            i++;
        }
      if(i > Map_saver.t3.Length-1)  Destroy(gameObject);
    }

}
