using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class Scin
{
    public Vector3 pos;
    public Vector3 cum;
    public string CO_name;
    public bool isfemale;
}

public class ScinEditor : MonoBehaviour
{
    public InputField CO_name; 
    public InputField scin_name;
    public InputField X, Y, Z, X2, Y2, Z2;
    GameObject old;
    Scin scin = new();
    public GameObject PlayerCamera;
    private void Start()
    {
        LoadScin();
    }
    public void ActiveScin()
    {
        VarSave.SetString("ActiveScin", scin_name.text);
    }
    public void DeactiveScin()
    {
        VarSave.SetString("ActiveScin", "");
    }

    public void LoadCO()
    {
        if(old) Destroy(old);
        VarSave.SetString("Scin", CO_name.text);
        old = Instantiate(Resources.Load<GameObject>("Morfs/CustomObject"));
    }
    public void SaveScin()
    {
        scin.pos = new Vector3(float.Parse(X.text), float.Parse(Y.text), float.Parse(Z.text));
        scin.cum = new Vector3(float.Parse(X2.text), float.Parse(Y2.text), float.Parse(Z2.text));
        scin.CO_name = CO_name.text;
        File.WriteAllText("res/UserWorckspace/skins/" + scin_name.text + ".txt", JsonUtility.ToJson(scin));
    }
    public void LoadScin()
    {
        if (File.Exists("res/UserWorckspace/skins/" + scin_name.text + ".txt"))
        {
            scin = JsonUtility.FromJson<Scin>(File.ReadAllText("res/UserWorckspace/skins/" + scin_name.text + ".txt"));
            X.text = "" + scin.pos.x; Y.text = "" + scin.pos.y; Z.text = "" + scin.pos.z; 
           X2.text = "" + scin.cum.x; Y2.text = "" + scin.cum.y; Z2.text = "" + scin.cum.z;
            CO_name.text = scin.CO_name; 
            LoadCO();
        }
    }
    private void Update()
    {
      if(old) if (VarSave.isNumber(X.text) &&
            VarSave.isNumber(Y.text) &&
            VarSave.isNumber(Z.text)) old.transform.position = new Vector3(float.Parse(X.text), float.Parse(Y.text), float.Parse(Z.text));
        if (VarSave.isNumber(X2.text) &&
              VarSave.isNumber(Y2.text) &&
              VarSave.isNumber(Z2.text)) PlayerCamera.transform.position = new Vector3(float.Parse(X2.text), float.Parse(Y2.text), float.Parse(Z2.text));
    }
}
