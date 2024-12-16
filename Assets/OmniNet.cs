using UnityEngine;
using UnityEngine.UI;

public class OmniNet : MonoBehaviour
{
    public InputField SiteDomain;
    public void Find()
    {
        Instantiate(Resources.Load<GameObject>("ui/sites/"+SiteDomain.text.Replace("/","!")));
        Debug.Log(SiteDomain.text.Replace("/", "!"));
    }
}
