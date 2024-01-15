using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBehaviour : MonoBehaviour
{

    [SerializeField] itemName itemName;
    [SerializeField] string customInterface;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    // itemName.ItemData
                    if (string.IsNullOrEmpty(customInterface))
                    {
                        GameObject g = Instantiate(Resources.Load<GameObject>("ui/script/ui"), Vector3.zero, Quaternion.identity);
                        g.GetComponent<script>().itemName = itemName;
                        Global.PauseManager.Pause();
                    }
                    if (!string.IsNullOrEmpty(customInterface))
                    {
                        GameObject g = Instantiate(Resources.Load<GameObject>("ui/script/"+ customInterface), Vector3.zero, Quaternion.identity);
                        g.GetComponent<script>().itemName = itemName;
                        Global.PauseManager.Pause();
                    }
                }
            }
        }
    }
}
