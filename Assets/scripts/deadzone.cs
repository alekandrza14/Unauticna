using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadzone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("�������� � �� ������� � ��������", true); 
            VarSave.SetBool("cry", true);
            Uxill_Engine.kill();
            if (musave.player(other.gameObject))
            {

                
                musave.chargescene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
