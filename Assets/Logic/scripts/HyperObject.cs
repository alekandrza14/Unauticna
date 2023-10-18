using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class selectedHyperObject
{
    public static HyperObject ho;
    public static bool isloader;
}

public class HyperObject : MonoBehaviour
{

    [SerializeField] public Shape4D obj;
    [SerializeField] public HyperObject MainHyperObject;
  public  Color c = Color.white;

    private void Update()
    {
        MainHyperObject = selectedHyperObject.ho;
       obj.colour = c;
    }

}
