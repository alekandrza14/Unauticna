using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class savetrigger : MonoBehaviour
{
    public string bol;
    public string ibool ="";
    public type1 type1 = type1.awaked;
    private void Start()
    {



        if (type1==type1.awaked)
        {
            VarSave.SetString(bol, ibool);
        }

    }
    public void OnTriggerEnter(Collider collision)
    {
        if (type1 == type1.triggered && !VarSave.EnterFloat(bol) && collision.tag == "Player")
        {
            VarSave.SetString(bol, ibool);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
