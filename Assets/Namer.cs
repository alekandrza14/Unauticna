using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Namer : MonoBehaviour
{
    public GameObject g;
    public InputField ifd;
    public void setName()
    {
        if (VarSave.GetFloat(
          "Creative" + "_gameSettings", SaveType.global) >= 10)
        {
            VarSave.LoadFloat("reason", 1);
        }
        File.WriteAllText("res/UserWorckspace/Items/" + ifd.text + ".txt", JsonUtility.ToJson(g.GetComponent<CustomObject>().Model));
        g.GetComponent<CustomObject>().s = ifd.text;
        g.GetComponent<CustomObject>().rcs();
       Destroy(gameObject);
        Global.PauseManager.Play();
    }
}
