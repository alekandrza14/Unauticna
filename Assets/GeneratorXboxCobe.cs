using UnityEngine;
using UnityEngine.UI;

public class GeneratorXboxCobe : MonoBehaviour
{
    public Text XboxLabel;
    public static int XboxCode;
    public static int GenCode()
    {
        GeneratorXboxCobe self = FindFirstObjectByType<GeneratorXboxCobe>();
        if (XboxCode == 0)
        {
            XboxCode = Random.Range(100000,999999);
        }
        self.XboxLabel.text = "Xbox Code : " + XboxCode;
        return XboxCode;
    }
}
