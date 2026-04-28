using UnityEngine;
using UnityEngine.UI;

public class StartSite : MonoBehaviour
{
    public void Site(InputField ifd)
    {
        Acaunt.Spawn(ifd.name);
    }
}
