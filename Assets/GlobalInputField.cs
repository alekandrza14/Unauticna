using UnityEngine;
using UnityEngine.UI;

public class GlobalInputField : MonoBehaviour
{
    public InputField text;
    public static InputField g_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        g_text = text;
    }
}
