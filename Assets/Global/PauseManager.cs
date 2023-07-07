using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class PauseManager
    {
        public static void Pause()
        {
            Globalprefs.Pause = true;
            Time.timeScale = 0;
        }
        public static void Play()
        {
            Globalprefs.Pause = false;
            Time.timeScale = 1;
        }
    }
}
