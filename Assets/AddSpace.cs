using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AddSpace : MonoBehaviour
{
    public InputField name_space;
    public InputField vaule_space;
    public void AddNewSpace()
    {
        Directory.CreateDirectory(VarSave.path+ "/datasurface");
        VarSave.SetMoney("datasurface/"+name_space.text, decimal.Parse(vaule_space.text));
    }
    public void ToSpace()
    {
        VarSave.SetString("CurrentSpace", name_space.text);
    }
    public void MoveInSpaceUpt()
    {
        VarSave.LoadMoney("datasurface/" + VarSave.GetString("CurrentSpace"),-0.5m);
    }
    public void MoveInSpaceBown()
    {
        VarSave.LoadMoney("datasurface/" + VarSave.GetString("CurrentSpace"), 0.5m);
    }
    //VarSave.GetMoney("datasurface/" + VarSave.GetString("CurrentSpace"))
}
