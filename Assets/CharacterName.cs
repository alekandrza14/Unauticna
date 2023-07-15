using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterName : MonoBehaviour
{
    public string CharactorName;
  [HideInInspector]  public string CharactorHpInterface = "Hitpoint : ~/~";
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Globalprefs.selectcharacter = CharactorName;
                    }
                    else if(!hit.collider.gameObject.GetComponent<CharacterName>())
                    {

                        Globalprefs.selectcharacter = null;
                    }
                }
                if (hit.collider == null)
                {
                    Globalprefs.selectcharacter = null;
                }

            }
        }
    }
    private void OnDestroy()
    {
        Globalprefs.selectcharacter = null;
    }
}
