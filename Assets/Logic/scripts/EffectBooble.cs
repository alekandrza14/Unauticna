using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBooble : MonoBehaviour
{
    public string effect;
    public float time;
    public void Update()
    {
        transform.rotation = GameManager.GetPlayer().transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - 100);
            playerdata.Addeffect(effect, time);
            Destroy(gameObject);
        }
    }
}
