using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musik : MonoBehaviour
{
    public Scrollbar s;
    static public float gameVolume;
    // Start is called before the first frame update
    void Start()
    {
        if (VarSave.ExistenceGlobalVar("mus"))
        {


            s.value = VarSave.GetGlobalFloat("mus");

        }
    }

        // Update is called once per frame
        void Update()
    {
        VarSave.SetGlobalFloat("mus",s.value);

        gameVolume = VarSave.GetGlobalFloat("mus");
        
    }
}
