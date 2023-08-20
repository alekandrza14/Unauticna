using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provod : MonoBehaviour
{
    public float tic;
    public bool s;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameObject.FindObjectsByType<provod>(sortmode.main).Length; i++)
        {
            GameObject.FindObjectsByType<provod>(sortmode.main)[i].GetComponent<MeshRenderer>().material.SetColor("Color4", new Color(0, 1, 0.9811893f, 0));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindFirstObjectByType<provod>().gameObject == gameObject && GameObject.FindObjectsByType<provod>(sortmode.main).Length <= 20) {
            tic += Time.deltaTime;
            RaycastHit hit = MainRay.MainHit;
            
                if (hit.collider.GetComponent<provod>() && Input.GetKeyDown(KeyCode.Tab) && tic >= 1)
                {
                    Instantiate(Resources.Load<GameObject>("provod").gameObject, hit.point, Quaternion.identity);
                    tic = 0;
                }

            
        }
        if (GameObject.FindFirstObjectByType<provod>().gameObject == gameObject && GameObject.FindObjectsByType<provod>(sortmode.main).Length >= 20 &&!s)
        {
            for (int i=0;i< GameObject.FindObjectsByType<provod>(sortmode.main).Length;i++)
            {
                GameObject.FindObjectsByType<provod>(sortmode.main)[i].GetComponent<MeshRenderer>().material.SetColor("_Color4",Color.red);
                
            }
            s = true;
            for (int i = 0; i < GameObject.FindObjectsByType<provod>(sortmode.main).Length; i++)
            {
                GameObject.FindObjectsByType<provod>(sortmode.main)[i].GetComponent<MeshRenderer>().material.SetColor("_Color4", Color.red);

            }
        }
    }
}
