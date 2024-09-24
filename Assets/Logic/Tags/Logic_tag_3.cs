using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("LogicTags/Tag-3")]
public class Logic_tag_3 : MonoBehaviour
{
    static Logic_tag_3 _main;
    static public Logic_tag_3 main()
    {
        if (_main == null)
        {
            _main = FindFirstObjectByType<Logic_tag_3>();
        }
        return _main;
    }
}
