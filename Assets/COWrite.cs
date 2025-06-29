using UnityEngine;
using UnityEngine.UI;

public class COWrite : MonoBehaviour
{
    public InputField ifd;
    void Update()
    {
       mover.item = ifd.text;
    }
}
