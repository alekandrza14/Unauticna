using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class E3CustomCenter : MonoBehaviour
{
    static int index;
    private void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider != null)
        {
            if (gameObject == hit.collider.gameObject)
            {
              mover.main().transform.position = FindObjectsByType<E3CustomCenter>(sortmode.main)[index].transform.position;
                if (FindObjectsByType<E3CustomCenter>(sortmode.main).Length-1>index)
                {
                    index++;
                }
                else
                {
                    index=0;
                }
            }
        }
    }
}
