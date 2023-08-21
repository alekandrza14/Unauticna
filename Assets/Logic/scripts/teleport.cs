using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    public int sceneid; public int sceneid1; public int sceneid2;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {


            GameManager.chargescene(sceneid);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {


            GameManager.chargescene(sceneid1);
        }
        if (boxItem.getInventory("i3").inventory.Getitem("position_planet_seloria") && Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.chargescene(sceneid2);
        }
    }
}
