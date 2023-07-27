
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResearchObject : MonoBehaviour
{
    [SerializeField] string SiObject;

    private void Start()
    {

        InvokeRepeating("RaycastUpdate", 1, 0.1f);
    }

    void RaycastUpdate()
    {

        if (Input.GetKey(KeyCode.Mouse0) && !VarSave.ExistenceVar("researchs/" + SiObject))
        {
            Directory.CreateDirectory("unsave/var/researchs");
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        VarSave.SetMoney("research", VarSave.GetMoney("research") + 1);

                        Globalprefs.research = VarSave.GetMoney("research");
                        VarSave.SetInt("researchs/" + SiObject, 0);
                    }
                }
            }
        }
    }
} 
