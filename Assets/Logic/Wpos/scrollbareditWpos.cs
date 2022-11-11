using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scrollbareditWpos : MonoBehaviour
{
    public Scrollbar Wpos;
    void Start()
    {
        
    }


        void FixedUpdate()
    {
        
        if (Wpos.value > 1)
        {
            Wpos.value = 1;
        }
        if (Wpos.value < 0)
        {
            Wpos.value = 0;
        }
        
    }
}
