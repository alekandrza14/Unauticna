using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewC : MonoBehaviour
{
    public Camera c;
   public static Camera getMainView()
    {
       return FindObjectOfType<ViewC>().c;
    }
}
