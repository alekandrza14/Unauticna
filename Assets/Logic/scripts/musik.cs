using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musik : MonoBehaviour
{
    public Scrollbar s;
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
        for (int i=0;i<GameObject.FindGameObjectsWithTag("game musig").Length;i++)
        {
            GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().volume = VarSave.GetGlobalFloat("mus");
        }
    }
}
