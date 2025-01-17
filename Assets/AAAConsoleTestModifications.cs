using UnityEngine;
using UnityEngine.UI;

public class AAAConsoleTestModifications : MonoBehaviour
{
    public InputField Input;
    public InputField Output;
    public void ConsoleReturn()
    {
        if (Input.text.ToLower()=="help")
        {
            Output.text = "help - this empty console use dnspy for script AAAConsoleTestModifications.cs";
        }
    }
}
