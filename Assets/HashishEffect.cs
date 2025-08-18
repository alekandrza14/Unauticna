using UnityEngine;

public class HashishEffect : MonoBehaviour
{
    void Start()
    {
        if (playerdata.Geteffect("Trip") != null)
        {

        }
        else if (playerdata.Geteffect("Trin") != null)
        {

        }
        else if(VarSave.GetFloat("SevenSouls") > 0)
        {

        }
        else if (playerdata.Geteffect("Tripl2") != null)
        {

        }
        else if (playerdata.Geteffect("Tripl3") != null)
        {

        }
        else if (playerdata.Geteffect("meat") != null)
        {

        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
