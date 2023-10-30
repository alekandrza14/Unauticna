using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HakerAttack : MonoBehaviour
{
    float timer; float timer2;

    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer >= 1)
        {
            VarSave.LoadMoney("tevro", -1);
            timer = 0;
        }
        if (timer2 >= 3*60)
        {
            VarSave.SetMoney("tevro", 0);
            Destroy(gameObject);
            timer2 = 0;
        }
    }
}
