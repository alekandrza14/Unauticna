using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn1 : MonoBehaviour
{
    public float tic, time = 2000;
    public GameObject ob;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = musave.GetPlayer().position;

        if (tic > time)
        {
            VarSave.SetBool("djevil_attack", false);
            VarSave.SetBool("победа над djevil", true);
            tic = 0;
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("game musig").Length && VarSave.GetBool("djevil_attack") == false; i++)
        {
            GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().volume = VarSave.GetFloat("mus");

        }
        if (VarSave.GetBool("djevil_attack") == true)
        {
            tic += Time.deltaTime * 20;
            if (VarSave.ExistenceVar("mus"))
            {
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("game musig").Length; i++)
                {
                    GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().volume = 0;

                }
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("battlemusic").Length; i++)
                {
                    GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().volume = 0;
                    GameObject.FindGameObjectsWithTag("battlemusic")[i].GetComponent<AudioSource>().volume = VarSave.GetFloat("mus");
                    if (GameObject.FindGameObjectsWithTag("battlemusic")[i].GetComponent<AudioSource>().isPlaying == false)
                    {


                        GameObject.FindGameObjectsWithTag("battlemusic")[i].GetComponent<AudioSource>().Play();
                    }
                }
            }
            Instantiate(ob.gameObject, new Vector3(Random.Range(-100, -101), Random.Range(-20, 21), Random.Range(-100, 101)) + v3, Quaternion.identity);
            
        }

    }
    
}
