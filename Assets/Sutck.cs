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
   static Seson seson;
    static UniverseSkyType skyType;
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
        skyType = (UniverseSkyType)VarSave.GetInt("UST");
        seson = (Seson)VarSave.GetInt("Seson");
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
            Temperature += 7;
            Temperature += Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 3;
        }
        if (day == 1)
        {
            Temperature += 25;
            Temperature += Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 10;
        }
        if (day == 2)
        {
            Temperature += 625;
            Temperature += Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 60;
        }
        if (seson == Seson.Лето)//1
        {
            Temperature += 7 * Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }
        if (seson == Seson.Глён)//2
        {
            Temperature += 200 * Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }
        if (seson == Seson.Осень)//3
        {
            Temperature -= 9 * Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }
        if (seson == Seson.Зима)//4
        {
            Temperature -= 20 * Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }
        if (seson == Seson.Мака)//5
        {
            Temperature -= 10 * Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }
        if (seson == Seson.Весна)//6
        {
            Temperature -= 2 * Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }
        if (skyType == UniverseSkyType.Default)
        {
            Temperature -= 2 * Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }
        if (skyType == UniverseSkyType.Arua)
        {
            Temperature += 2000 * Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }
        if (skyType == UniverseSkyType.Bright)
        {
            Temperature += 1500 * Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }
        if (skyType == UniverseSkyType.Darck)
        {
            Temperature -= 200 * Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }
        if (skyType == UniverseSkyType.AntyLight)
        {
            Temperature -= 2000* Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }
        if (skyType == UniverseSkyType.Litch)
        {
            Temperature -= 9000 * Globalprefs.Hash(new Vector2(DateTime.Now.Hour, -DateTime.Now.Hour * 2)) * 2;
        }

        return Temperature;
    }
   static void UpdateSutck()
    {
        if(VarSave.GetBool("Day",SaveType.computer))
        {
            day = 1;
        }
        day %= 3;
        if (seson != Seson.Глён)
        {
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
        }
        else
        {
            if (day == 0)
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
        }
        if (seson != Seson.Глён)
        {
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
        }
        else
        {
            if (day == 1)
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
        if (seson != Seson.Зима|| skyType != UniverseSkyType.Darck)
        {
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
        else
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
    }

    // Update is called once per frame
    void Update()
    {
        if (antinight)
        {
            mover m = mover.main();
            if(m!=null)
            if (main != null)
            {
                if (main.transform != null)
                {
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
    }
}
