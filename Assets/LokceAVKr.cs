using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokceAVKr : MonoBehaviour
{
    public string help = "you need Use dnSpy";
    void Start()
    {
#if !UNITY_EDITOR
        Destroy(gameObject);
#endif
    }

}
