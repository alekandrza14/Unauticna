using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class Main_EquepmentManager : MonoBehaviour
    {
        public static void UpdateEquepment()
        {
            Logic_tag_Equepment[] lte = FindObjectsByType<Logic_tag_Equepment>(sortmode.main);
            foreach (Logic_tag_Equepment item in lte)
            {
                item.UpdateEquepment();
            }
        }
    }
    public class MEM : MonoBehaviour
    {
        public static void UE()
        {
            Logic_tag_Equepment[] lte = FindObjectsByType<Logic_tag_Equepment>(sortmode.main);
            foreach (Logic_tag_Equepment item in lte)
            {
                item.UpdateEquepment();
            }
        }
    }
    public class PauseManager
    {
        public static void Pause()
        {
            Globalprefs.Pause = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        public static void Play()
        {
            Globalprefs.Pause = false;
            Time.timeScale = 1;
        }
    }
}
