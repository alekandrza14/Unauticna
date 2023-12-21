using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class СмачныйПлевокСпамтона : MonoBehaviour
{
    [SerializeField] Text _text;
    SmachniyPlevokSpamton sps;
    mover m;
    void Start()
    {
        sps = FindFirstObjectByType<SmachniyPlevokSpamton>();
        m = mover.main();
    }
    void Update()
    {
        if (sps) _text.text = "!! Вам не уйти растояние плевку до вас :" + Vector3.Distance(sps.transform.position, m.transform.position) + " !!";
        if (!sps)
        {
            Instantiate(Resources.Load<GameObject>("items/Смачный_плевок_Спамтона"));
            sps = FindFirstObjectByType<SmachniyPlevokSpamton>();
        }
    }
}
