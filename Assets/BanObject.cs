using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BanObject : MonoBehaviour
{
    ItemDemake Demake = new ItemDemake();
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {

            VarSave.SetBool("lol you Banned", true);
            SceneManager.LoadSceneAsync("Banned forever");
        }
        if (collision.collider.GetComponent<itemName>())
        {
            if (VarSave.GetString("Demake" + Globalprefs.Reality) != "") Demake = JsonUtility.FromJson<ItemDemake>(VarSave.GetString("Demake" + Globalprefs.Reality));
            if (collision.collider.GetComponent<itemName>()) Demake.item.Add(collision.collider.GetComponents<itemName>()[0]._Name);
            VarSave.SetString("Demake" + Globalprefs.Reality, JsonUtility.ToJson(Demake));
        }
        if (collision.collider.GetComponent<CustomObject>())
        {
            if (VarSave.GetString("Demake" + Globalprefs.Reality) != "") Demake = JsonUtility.FromJson<ItemDemake>(VarSave.GetString("Demake" + Globalprefs.Reality));

            if (collision.collider.GetComponent<CustomObject>()) Demake.co.Add(collision.collider.GetComponent<CustomObject>().s);
            VarSave.SetString("Demake" + Globalprefs.Reality, JsonUtility.ToJson(Demake));
        }
    }

    public void OnSignal()
    {
        VarSave.SetBool("lol you Banned", true);
        SceneManager.LoadSceneAsync("Banned forever");
    }
}