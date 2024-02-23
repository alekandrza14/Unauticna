using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum environment
{
    vacun,air,water,palsma, Magic_environment,code,pain,pressure_gravity
}

public enum SFL
{
    no_gravity, never_ending_hacks, Spawn_Chaos_cube,nophing, Mind5D, Mind4D, MindND, AntiGravity, WorkInLitchUniverse, ChaosSpawn, none
}

public class SceneSettings : MonoBehaviour
{
    
    public environment environment_space;
    public SFL sfl;
    float timer;
    float timer2;
    float timer3;
    void Start()
    {
        if (sfl == SFL.Mind5D)
        {

            mover.main().nonnatureprogress += 2;
        }
        if (sfl == SFL.MindND)
        {

            mover.main().nonnatureprogress += 3;
        }
        if (sfl == SFL.Mind4D)
        {

            mover.main().nonnatureprogress += 1;
        }
        if (sfl == SFL.WorkInLitchUniverse)
        {

            mover.main().nonnatureprogress += 1;

        }
    }
    string si;
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (mover.main().transform.position.ToString() != si)
        {
            si = mover.main().transform.position.ToString();
            timer3 += Time.deltaTime; 
        }
        if (sfl == SFL.no_gravity)
        {

            mover.main().gravity = 0;
            mover.main().fly = true;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (sfl == SFL.Mind5D)
            {

                mover.main().nonnatureprogress -= 2;
            }
            if (sfl == SFL.MindND)
            {

                mover.main().nonnatureprogress -= 3;
            }
            if (sfl == SFL.Mind4D)
            {

                mover.main().nonnatureprogress -= 1;
            }
            if (sfl == SFL.WorkInLitchUniverse)
            {

                mover.main().nonnatureprogress -= 1;

            }
            Instantiate(gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (timer >= 1)
        {
            if (sfl == SFL.WorkInLitchUniverse)
            {

                mover.main().hp -= 1;
                VarSave.LoadMoney("tevro",0.01m);
            }
            if (environment_space == environment.pain)
            {
                mover.main().hp -= 1;
            }
            if (environment_space == environment.pressure_gravity)
            {
                mover.main().hp -= 1;
                mover.main().gravity = 20;
            }
            if (environment_space == environment.vacun || environment_space == environment.water)
            {
                mover.main().InWater = true;
            }
            if (environment_space == environment.Magic_environment)
            {
                mover.main().hp += 1;
            }
            timer = 0;
        }
        if (timer3 >= 7)
        {
            if (sfl == SFL.ChaosSpawn)
            {
                mover m = mover.main();
                Ray r = new Ray(m.transform.position, new Vector3(Random.rotation.x, Random.rotation.y, Random.rotation.z));
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        GameObject[] g = Resources.LoadAll<GameObject>("Items");
                        Instantiate(g[Random.Range(0,g.Length)], hit.point, Quaternion.identity);

                    }


                }
            }
            timer3 = 0;
        }
        if (timer2 >= 2* 60)
        {
            if (sfl == SFL.never_ending_hacks)
            {

                Instantiate(Resources.Load("events/hakers"));
            }
            if (sfl == SFL.ChaosSpawn)
            {
                mover m = mover.main();
                Ray r = new Ray(m.transform.position + (m.transform.up * 40), new Vector3(Random.rotation.x, Random.rotation.y, Random.rotation.z));
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        GameObject[] g = Resources.LoadAll<GameObject>("Items");
                        Instantiate(g[g.Length], hit.point, Quaternion.identity);
                        telo[] t = FindObjectsByType<telo>(sortmode.main);


                        for (int i = 0; i < t.Length; i++)
                        {


                            t[i].gameObject.AddComponent<deleter1>();
                        }
                        StandartObject[] so = FindObjectsByType<StandartObject>(sortmode.main);
                        for (int i = 0; i < so.Length; i++)
                        {


                            so[i].gameObject.AddComponent<deleter1>();
                        }
                        CustomObject[] co2 = FindObjectsByType<CustomObject>(sortmode.main);
                        for (int i = 0; i < co2.Length; i++)
                        {


                            co2[i].gameObject.AddComponent<deleter1>();
                        }
                        itemName[] items = FindObjectsByType<itemName>(sortmode.main);



                        if (items.Length != 0)
                        {



                            for (int i3 = 0; i3 < items.Length; i3++)
                            {

                             if (!items[i3].GetComponent<Logic_tag_UnDeleteing>())   items[i3].gameObject.AddComponent<deleter1>();


                            }



                        }
                    }
                }
            }
            if (sfl == SFL.Spawn_Chaos_cube)
            {

                Instantiate(Resources.Load("Items/Chaos_cube"),mover.main().transform.position+
                    new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)),Quaternion.identity);
            }
            timer2 = 0;
        }
    }
}
