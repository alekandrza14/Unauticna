using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
   
    public class Main_EquepmentManager : MonoBehaviour
    {
        public static void UpdateEquepment()
        {
            SkinContoler[] sc = FindObjectsByType<SkinContoler>(sortmode.main);
            foreach (SkinContoler item in sc)
            {
                item.SkinUpdate();
            }
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
            Main_EquepmentManager.UpdateEquepment();
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
