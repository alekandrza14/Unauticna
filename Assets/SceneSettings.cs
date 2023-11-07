using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum environment
{
    vacun,air,water,palsma, Magic_environment,code,pain,pressure_gravity
}

public enum SFL
{
    no_gravity, never_ending_hacks, Spawn_Chaos_cube
}

public class SceneSettings : MonoBehaviour
{
    public environment environment_space;
    public SFL sfl;
    float timer;
    float timer2;
    void Start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (sfl == SFL.no_gravity)
        {
            
            mover.main().gravity = 0;
            mover.main().fly = true;
        }
        if (timer >= 1)
        {
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
            timer = 0;
        }
        if (timer2 >= 2* 60)
        {
            if (sfl == SFL.never_ending_hacks)
            {

                Instantiate(Resources.Load("events/hakers"));
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
