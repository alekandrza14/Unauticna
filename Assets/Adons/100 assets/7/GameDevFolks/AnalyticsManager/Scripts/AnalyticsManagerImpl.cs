using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevFolks.Analytics
{
    public class AnalyticsManagerImpl : MonoBehaviour
    {
        public bool _EnableConsole;

        // Start is called before the first frame update
        void Awake()
        {
            AnalyticManager.Init();
            AnalyticManager.pInstance.SetLogCallbacks(Debug.Log, Debug.LogWarning, Debug.LogError);

            AnalyticManager.pInstance.EnableConsoleLog(_EnableConsole);
        }        
    }
}