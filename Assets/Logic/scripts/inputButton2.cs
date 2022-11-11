using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputButton2 : MonoBehaviour
{
    public Shop s;
    public int idbutton;
    public void click()
    {
        s.sell(idbutton);
    }
}
