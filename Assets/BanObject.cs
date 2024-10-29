using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
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
        GameObject select = collision.collider.gameObject;
        if (select.GetComponent<itemName>())
        {
            if (select.GetComponent<itemName>().ItemDangerLiberty != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty2 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty2, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty3 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty3, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty4 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty4, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty5 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty5, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty6 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty6, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty7 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty7, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty8 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty8, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty9 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty9, 1);

            }
        }
        if (select.GetComponent<CustomObject>())
        {
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty2 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty2, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty3 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty3, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty4 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty4, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty5 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty5, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty6 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty6, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty7 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty7, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty8 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty8, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty9 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty9, 1);

            }
        }
    }

    public void OnSignal()
    {
        VarSave.SetBool("lol you Banned", true);
        SceneManager.LoadSceneAsync("Banned forever");
    }
}