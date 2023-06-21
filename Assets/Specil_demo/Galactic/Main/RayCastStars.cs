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
public enum size
{
    Stars,Galaxy,Universe,Multyverse,Anyverse
}

public class RayCastStars : MonoBehaviour
{
    [SerializeField] Text text;
    SpaceSheepPosition scp = new SpaceSheepPosition();
    public string[] scenename;
    public size s;
    private void Start()
    {
        VarSave.SetString("scppos", SceneManager.GetActiveScene().name);
        VarSave.SetString("Universe_Position", SceneManager.GetActiveScene().name);
       if(s == size.Galaxy) VarSave.SetString("Universe_galaxy_Position", SceneManager.GetActiveScene().name);

        if (VarSave.ExistenceVar("scp"+SceneManager.GetActiveScene().name))
        {
            scp = JsonUtility.FromJson<SpaceSheepPosition>(VarSave.GetString("scp" + SceneManager.GetActiveScene().name));
            transform.position = scp.pos;
            transform.rotation = scp.rot;
        }
    }

    public decimal Fract(decimal value) { return value - decimal.Truncate(value); }
    public float Frac(float value)
    {
        return (float)Fract((decimal)value);
    }
    float Hash(Vector2 p)
    {
        float d = Vector2.Dot(-p, new Vector2(12.9898f, 78.233f));
        return Frac(Mathf.Sin(d) * 43758.5453123f);
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
                if (hit.collider.tag == "Star" && s == size.Stars)
                {
                    int o = (int)(hit.collider.transform.position.x - hit.collider.transform.position.y - hit.collider.transform.position.z);
                    text.text = "star : s" + o.ToString();
                    if (o == 0 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("dark1");
                        VarSave.DeleteKey("scppos");
                    }
                    else if (o == -11 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("dark2");
                        VarSave.DeleteKey("scppos");
                    }
                    else if (o == 186 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("dark3");
                        VarSave.DeleteKey("scppos");
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        VarSave.SetInt("planet", o);
                        SceneManager.LoadScene("dark4");
                        VarSave.DeleteKey("scppos");
                    }
                }
                else if (hit.collider.tag == "Cell" && s == size.Stars)
                {
                    text.text = "Галактический ретранслятор";
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("Galaxy full loader");
                        VarSave.DeleteKey("scppos");
                    }
                }
                else if (hit.collider.tag == "Cell" && s == size.Galaxy)
                {
                    text.text = "Вселенский ретранслятор";
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("Universe");
                        VarSave.DeleteKey("scppos");
                    }
                }
                else if (hit.collider.tag == "Star" && s == size.Galaxy)
                {
                    int o = (int)(hit.collider.transform.position.x - hit.collider.transform.position.y - hit.collider.transform.position.z);
                    int o2 = (int)(hit.collider.transform.position.x - hit.collider.transform.position.y - hit.collider.transform.position.z);
                    o = (int)(((Hash(new Vector2(o, -o)) + 1) / 2) * scenename.Length);

                    text.text = "stars : s" + o2.ToString();
                    if (o2 == 0 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("Galactic demo");
                        VarSave.SetInt("planetS", 0);
                        VarSave.DeleteKey("scppos");
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0))
                    {


                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));

                        VarSave.SetInt("planetS", o2);
                        SceneManager.LoadScene(scenename[o]);
                        VarSave.DeleteKey("scppos");
                    }
                }
                else if (hit.collider.tag == "Star" && s == size.Universe)
                {
                    int o = (int)(hit.collider.transform.position.x - hit.collider.transform.position.y - hit.collider.transform.position.z);
                    int o2 = (int)(hit.collider.transform.position.x - hit.collider.transform.position.y - hit.collider.transform.position.z);
                    o = (int)(((Hash(new Vector2(o, -o)) + 1) / 2) * scenename.Length);

                    text.text = "Galaxy : s" + o2.ToString();
                    if (o2 == 0 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("Galactic full");
                        VarSave.SetInt("planetG", 0);
                        VarSave.DeleteKey("scppos");
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0))
                    {


                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));

                        VarSave.SetInt("planetG", o2);
                        SceneManager.LoadScene(scenename[o]);
                        VarSave.DeleteKey("scppos");
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            VarSave.SetString("scppos", SceneManager.GetActiveScene().name);
            VarSave.SetString("Universe_Position", SceneManager.GetActiveScene().name);
            VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
            SceneManager.LoadScene("menu");
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (VarSave.ExistenceVar("scp" + SceneManager.GetActiveScene().name))
            {
                scp = JsonUtility.FromJson<SpaceSheepPosition>(VarSave.GetString("scp" + SceneManager.GetActiveScene().name));
                transform.position = scp.pos;
                transform.rotation = scp.rot;
            }
        }
    }
}
