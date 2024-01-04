using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[ExecuteInEditMode]
public class ItemTrigger : MonoBehaviour
{
    [SerializeField] string ItemName;
    [SerializeField] string variblbe;
    private void Update()
    {
        variblbe = ItemName + "triggered" + ((int)transform.position.x).ToString() +
            ((int)transform.position.y).ToString() +
            ((int)transform.position.z).ToString() +
            SceneManager.GetActiveScene().name +
            Globalprefs.GetIdPlanet().ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<itemName>()._Name == ItemName)
        {
            VarSave.SetBool(ItemName+"triggered"+ ((int)transform.position.x).ToString() +
            ((int)transform.position.y).ToString() +
            ((int)transform.position.z).ToString() +
            SceneManager.GetActiveScene().name +
            Globalprefs.GetIdPlanet().ToString(), true);
        }
    }
}
