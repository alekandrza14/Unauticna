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
        if (VarSave.EnterFloat2("mus"))
        {


            s.value = VarSave.GetFloat2("mus");

        }
    }

        // Update is called once per frame
        void Update()
    {
        VarSave.SetFloat2("mus",s.value);
        for (int i=0;i<GameObject.FindGameObjectsWithTag("game musig").Length;i++)
        {
            GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().volume = VarSave.GetFloat2("mus");
        }
    }
}
