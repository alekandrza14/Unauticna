using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperbolicBuilderDev : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            GameObject g = Instantiate(Resources.Load<GameObject>("items/" + "FasthyperbolicBlock"), transform.position, transform.rotation);
           
                g.gameObject.AddComponent<HyperbolicPoint>().HyperboilcPoistion = HyperbolicCamera.Main().RealtimeTransform.copy().inverse();
                g.transform.position = new Vector3(
                    0,
                    mover.main().transform.position.y,
                    0
                    );
                g.gameObject.GetComponent<HyperbolicPoint>().ScriptSacle = g.gameObject.transform.localScale;

            
        }
        }
    }
