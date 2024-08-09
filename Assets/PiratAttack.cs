using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiratAttack : MonoBehaviour
{
    float timer; float timer2;
    [SerializeField] GameObject pirat;
    [SerializeField] GameObject piratSheap;
    [SerializeField] Text txt;

    static public Vector3 randomCube(int min , int max)
    {
        return new Vector3(Random.Range(-min, max), Random.Range(-min, max), Random.Range(-min, max));
    }
    void Start()
    {
        VarSave.SetString("Player_On_Pirat_Attack", "Please don't destroy this file be a man");
        Instantiate(piratSheap, mover.main().transform.position + randomCube(-500, 500) + (Vector3.up * 500), Quaternion.identity);
        if (Global.Random.Range(0, 5) == 1)
        {
            timer2 = 7 * 60;
        }
        if (VarSave.GetFloat(
         "Конец" + "_gameSettings", SaveType.global) >= 0.5f)
        {
            timer2 -= 2 * 60;
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        float timer3 = 8 * 60 - timer2;
        txt.text = "бей или беги " + (int)(  timer3 / 60) + " : " + (int)(  timer3 % 60);
        if (timer >= 12)
        {
            Instantiate(pirat,mover.main().transform.position + randomCube(-100, 100), Quaternion.identity);
            timer = 0;
        }
        if (timer2 >= 8 * 60)
        {
            VarSave.DeleteKey("Player_On_Pirat_Attack");

            Destroy(gameObject);
            timer2 = 0;
        }
    }
}
