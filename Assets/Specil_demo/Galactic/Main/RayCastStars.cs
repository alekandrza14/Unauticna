using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceSheepPosition
{
    public Vector3 pos;
    public Quaternion rot;
}

public class RayCastStars : MonoBehaviour
{
    [SerializeField] Text text;
    SpaceSheepPosition scp = new SpaceSheepPosition();
    private void Start()
    {
        if (VarSave.EnterFloat("scp"))
        {
            scp = JsonUtility.FromJson<SpaceSheepPosition>(VarSave.GetString("scp"));
            transform.position = scp.pos;
            transform.rotation = scp.rot;
        }
    }
    void Update()
    {
        scp.pos = transform.position;
        scp.rot = transform.rotation;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Star")
                {
                    int o = (int)(hit.collider.transform.position.x - hit.collider.transform.position.y - hit.collider.transform.position.z);
                    text.text = "star : s" + o.ToString();
                    if (o == 0 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp", JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("dark1");
                    }
                    else if (o == -11 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp", JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("dark2");
                    }
                    else if (o == 186 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp", JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("dark3");
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp", JsonUtility.ToJson(scp));
                        VarSave.SetInt("planet", o);
                        SceneManager.LoadScene("Standart-palnet");
                    }
                }
                else
                {
                    text.text = "";
                }
            }
            else
            {

                text.text = "";
            }
        }
        else
        {

            text.text = "";
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            VarSave.SetString("scp", JsonUtility.ToJson(scp));
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (VarSave.EnterFloat("scp"))
            {
                scp = JsonUtility.FromJson<SpaceSheepPosition>(VarSave.GetString("scp"));
                transform.position = scp.pos;
                transform.rotation = scp.rot;
            }
        }
    }
}
