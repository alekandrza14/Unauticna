using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBooble : MonoBehaviour
{
    public string effect;
    public float time;
    public void Update()
    {
        transform.rotation = musave.GetPlayer().transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerdata.Addeffect(effect, time);
            Destroy(gameObject);
        }
    }
}
