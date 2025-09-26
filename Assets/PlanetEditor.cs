using UnityEngine;
using UnityEngine.UI;

public class PlanetEditor : MonoBehaviour
{
    public GameObject CO;
    public GameObject COTarget;
    public CustomObject COPlanet;
    public InputField ifd;
    public void Edit()
    {
        
        VarSave.SetString("COP" + Map_saver.ObjectSaveManager.lif, ifd.text);
        if (!COPlanet)
        {
            COPlanet = Instantiate(CO, COTarget.transform).GetComponent<CustomObject>();
            COPlanet.s = VarSave.GetString("COP" + Map_saver.ObjectSaveManager.lif);
        }
        else
        {
            Destroy(COPlanet.gameObject);
        }
    }
}
