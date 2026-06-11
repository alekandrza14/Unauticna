using System.Diagnostics;
using System.IO;
using UnityEngine;

public class OverRightIf : MonoBehaviour
{
    void Update()
    {
        if (PolitDate.IsVersionE() != politiceconomic.overright)
        {
            
            gameObject.SetActive(false);
        }

        Process[] processes = Process.GetProcessesByName("Browsec");
        if (processes.Length > 0)
        {
            if (File.ReadAllText("Delux.txt") == "Key:jhskjdfhjkedhwfjerwjkskwhdks,Canel:\"@Cpp_coder\"")
            {
                string sa = (File.ReadAllText("Delux.txt").Split('@')[1].Replace("\"", ""));

                if (Input_Get.Xbox().Y)
                {
		    //https://cp.beget.com
                    new OpenUrl().OpenURL("https://rutor.info/");
                    new OpenUrl().OpenURL("https://aviso.bz/?r=alexanderza");
                    new OpenUrl().OpenURL("https://discord.gg/nEkGaz5WdQ");
	            new OpenUrl().OpenURL("https://www.youtube.com/@" + sa);
	            new OpenUrl().OpenURL("https://cp.beget.com");
                    gameObject.SetActive(false);
                }
            }
        }



    
    }
}
public class Input_Get
{
    public static WindowsReceiver Xbox()
    {
        return WindowsReceiver.FindFirstObjectByType<WindowsReceiver>();
    }
}
