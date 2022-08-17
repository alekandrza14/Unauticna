using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savetrigger : MonoBehaviour
{
    public string bol;
    public int ibool =0;
    private void Start()
    {
        


            VarSave.SetInt(bol, ibool);
        
    }
}
