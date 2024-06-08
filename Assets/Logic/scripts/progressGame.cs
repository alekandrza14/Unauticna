using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum LogicEnum
{
    less,
    equals,
    geater

}

public class progressGame : MonoBehaviour
{
    [SerializeField] LogicEnum logicEnum = LogicEnum.equals;
    [SerializeField] int Value;
    void Start()
    {
        int i = 0;
        if (File.Exists("unsave/capterg/" + Globalprefs.GetTimeline()))
        {
            GameData g = JsonUtility.FromJson<GameData>(File.ReadAllText("unsave/capterg/" + Globalprefs.GetTimeline()));
            i = g.progressofthepassage;
        }
        if (logicEnum == LogicEnum.geater && Value < i)
        {
            Destroy(gameObject);
        }
        if (logicEnum == LogicEnum.less && Value > i)
        {

            Destroy(gameObject);
        }
        if (logicEnum == LogicEnum.equals && Value != i)
        {
            Destroy(gameObject);

        }
    }
}
