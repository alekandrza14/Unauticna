using UnityEngine;
using UnityEngine.UI;

public class DataName : MonoBehaviour
{
    public InputField data;
    public Text load;
    public string var;
    private void Start()
    {
        if (VarSave.ExistenceVar(var))
        {
            if (data != null) data.text = VarSave.GetString(var);
        }
        if (VarSave.ExistenceVar(var))
        {
            if (load != null) load.text = VarSave.GetString(var);
        }
        if (data != null)
        {
            VarSave.SetString(var, data.text);
        }
    }
    public void write()
    {
        if (data != null) 
        {
            VarSave.SetString(var, data.text);
        }
    }
}
