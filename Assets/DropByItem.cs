using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropByItem : MonoBehaviour
{
    public GameObject[] DropItems;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {



            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Instantiate(DropItems[Random.Range(0, DropItems.Length)], transform.position, Quaternion.identity);
                    gameObject.AddComponent<deleter1>();
                    GameManager.save();
                }
            }
        }
    }
}
