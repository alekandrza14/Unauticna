using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AniverseTrigger : MonoBehaviour
{
    public int Varible;

    public size s;
    // Start is called before the first frame update
    void Start()
    {
        if (Varible != Globalprefs.GetIdStars() && s == size.Stars)
        {
            Destroy(gameObject);
        }
       else if (Varible != Globalprefs.GetIdGalaxy() && s == size.Galaxy)
        {
            Destroy(gameObject);
        }
        else if (Varible != Globalprefs.GetIdUniverse() && s == size.Universe)
        {
            Destroy(gameObject);
        }
        else if (Varible != Globalprefs.GetIdMultiverse() && s == size.Multyverse)
        {
            Destroy(gameObject);
        }
    }

   
}
