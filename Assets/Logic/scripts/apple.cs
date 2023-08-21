using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum StoryPoint
{
    eventer,awaker,trigger,booler
}
[System.Serializable]
public class eventun
{
    public string value;
    public string var;
    public bool isNo;
    public GameObject[] gameObjects;
}

public class apple : MonoBehaviour
{
    public GameObject[] gameObjects;
    public eventun[] events;
    private void Awake()
    {
        foreach (GameObject i in gameObjects)
        {
            i.SetActive(false);
        }
    }
    private void Start()
    {
        foreach (eventun i2 in events)
        {
            for (int i =0; i < i2.gameObjects.Length;i++)
            {
                if (i2.value == VarSave.GetString(i2.var,SaveType.local) && true == VarSave.ExistenceVar(i2.var,SaveType.local))
                {


                    i2.gameObjects[i].SetActive(true);
                }
                else if (i2.isNo && false == VarSave.ExistenceVar(i2.var, SaveType.local))
                {


                    i2.gameObjects[i].SetActive(true);
                }
            }
        }
    }

}
