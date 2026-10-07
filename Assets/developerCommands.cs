using UnityEngine;using UnityEngine.UI;using System.IO;

public class developerCommands : MonoBehaviour
{
	public InputField ConsoleMemory;
	public InputField ConsoleLabel;
    public void SendOnEndEdit()
    {
        ConsoleMemory.text += ConsoleLabel.text.Replace("\n","\\n\n")+"\n";
		if(ConsoleLabel.text == "help"){
			ConsoleMemory.text += "\"help\" it is im\n";
			ConsoleMemory.text += "\"getRvash\" check file \"C:/data/MoneyVerify\"\n";
			ConsoleMemory.text += "\"pingRvash\" Creare file \"C:/data/Unauticna.command\"\n";
		}
		if(ConsoleLabel.text == "getRvash"){
			ConsoleMemory.text += "File: is " + (File.Exists("C:/data/MoneyVerify") ? "Exists" : "Not Exists") + "\n";
			if(!File.Exists("C:/data/MoneyVerify"))return;
			ConsoleMemory.text += "File: Wish data: " + File.ReadAllText("C:/data/MoneyVerify").Split(',')[1]+"\n";
			if(!File.Exists("C:/data/MoneyOldTest")){
				File.WriteAllText("C:/data/MoneyOldTest",File.ReadAllText("C:/data/MoneyVerify").Split(',')[1]);
				ConsoleMemory.text += "Rvash: +" + File.ReadAllText("C:/data/MoneyVerify").Split(',')[1]+"\n";
				VarSave.LoadInt("Rvash",int.Parse(File.ReadAllText("C:/data/MoneyVerify").Split(',')[1]));
				ConsoleMemory.text += "Rvash Count: " + VarSave.LoadInt("Rvash",0)+"\n";

				}
				else
				{
					for(int i = 0;i<2;i++){
				if(i==0){	ConsoleMemory.text += "Rvash: +" + ""+(int.Parse(File.ReadAllText("C:/data/MoneyVerify").Split(',')[1])-int.Parse(File.ReadAllText("C:/data/MoneyOldTest")))+"\n";
					VarSave.LoadInt("Rvash",(int.Parse(File.ReadAllText("C:/data/MoneyVerify").Split(',')[1])-int.Parse(File.ReadAllText("C:/data/MoneyOldTest"))));
				ConsoleMemory.text += "Rvash Count: " + VarSave.LoadInt("Rvash",0)+"\n";}
				if(i==1){		File.WriteAllText("C:/data/MoneyOldTest",""+(int.Parse(File.ReadAllText("C:/data/MoneyVerify").Split(',')[1])));}
					}
				}
		}
		if(ConsoleLabel.text == "pingRvash"){
			File.WriteAllText("C:/data/Unauticna.command","Ya");
			ConsoleMemory.text += "Ping:{\n YG: Hello Nuta\n Y++ Rights level: 1\n}\n";
			
		}
    }
}
