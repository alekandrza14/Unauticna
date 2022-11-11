using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator anim;
    public void function1()
    {
        anim.SetTrigger("salo");
    }
}
