using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadtrigger : MonoBehaviour
{
    public bool chervyash;
    public bool terratist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true); if (!chervyash && !terratist)
            {


                VarSave.SetBool("переломал кости и от правлен в больницу", true);
            }
            if (chervyash)
            {


                VarSave.SetBool("„≈–¬яЎ победил", true);
            }
            if (terratist)
            {


                VarSave.SetBool("терратскичикий корабль победил", true);
            }

          


                musave.chargescene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}
