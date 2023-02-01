using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGiveTrophy : MonoBehaviour
{
    public int trophy = 177824;
    // Start is called before the first frame update
    void Start()
    {
        if (Globalprefs.signedgamejolt == true)
        {
            GameJolt.API.Trophies.TryUnlock(trophy);
        }
    }

}
