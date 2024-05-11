using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public enum TimeOfGame
{
    Night,Day,AntiNight
}

public class Sutck : MonoBehaviour
{
    public static bool antinight;
    public Light main;
    public static Sutck Instance;
    public static float day { get; private set; }
    public static float offset;
    // Start is called before the first frame update
    public static void SetSutck(float x)
    {
        day = x;
        UpdateSutck();
    }
    void Start()
    {
        Instance = this;
        DateTime now = DateTime.Now;
        day = now.DayOfYear;
        foreach (Light light in FindObjectsByType<Light>(sortmode.main))
        {
            if (light.type == LightType.Directional)
            {
                main = light;
            }
        }
        UpdateSutck();

    }
    static public float Temperature()
    {
        float Temperature =0;
        if (day == 0)
        {
            Temperature = 7;
            Temperature += Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 3;
        }
        if (day == 1)
        {
            Temperature = 25;
            Temperature += Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 10;
        }
        if (day == 2)
        {
            Temperature = 625;
            Temperature += Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 60;
        }
        return Temperature;
    }
   static void UpdateSutck()
    {
     
        day %= 3;
        if (day == 0)
        {
            foreach (Light light in FindObjectsByType<Light>(sortmode.main))
            {
                if (light.type == LightType.Directional)
                {
                    antinight = false;
                    light.intensity = 0.1f;
                    RenderSettings.ambientLight = new Color(0.2f, 0.2f, 0.2f, 0);
                    RenderSettings.ambientMode = AmbientMode.Flat;
                    RenderSettings.fog = true;
                    RenderSettings.fogStartDistance = 1;
                    RenderSettings.fogEndDistance = 120;

                    RenderSettings.fogColor = Color.black;
                    RenderSettings.fogMode = FogMode.Linear;
                }
            }
        }
        if (day == 1)
        {
            foreach (Light light in FindObjectsByType<Light>(sortmode.main))
            {
                if (light.type == LightType.Directional)
                {
                    antinight = false;
                    light.intensity = 1f;
                    RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f, 0);
                    RenderSettings.ambientMode = AmbientMode.Skybox;
                    RenderSettings.fog = false;
                }
            }
        }
        if (day == 2)
        {
            foreach (Light light in FindObjectsByType<Light>(sortmode.main))
            {
                if (light.type == LightType.Directional)
                {
                    antinight = true;

                    light.intensity = 50f;
                    RenderSettings.ambientLight = new Color(0f, 0f, 0f, 0);
                    RenderSettings.ambientMode = AmbientMode.Skybox;
                    RenderSettings.fog = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (antinight)
        {
            mover m = mover.main();
            Ray r = new Ray(m.transform.position, -main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider == null)
                {
                    m.hp -= 1;
                }
                if (hit.collider != null)
                {
                    if (hit.distance > 60)
                    {
                        m.hp -= 1;
                    }
                }
            }
            else
            {
                m.hp -= 1;
            }

        }
    }
}
