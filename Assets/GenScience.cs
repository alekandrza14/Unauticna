using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GenScience : MonoBehaviour
{
    public int reserch;
    public Text itemResearch;
    public void OnInteractive()
    {
        Research((int)((100 + (mover.main().CosProgress()) * 10)/100));
    }

    public void Research(int x)
    {
        reserch += x * Slave.resea.Count;
        reserch += x;
        if (reserch > 400)
        {
            string item = Map_saver.t3[Random.Range(0, Map_saver.t3.Length)].name;
            if (!VarSave.ExistenceVar("researchs/" + item))
            {
                Directory.CreateDirectory("unsave/var/researchs");


                VarSave.LoadMoney("research", 1);

                Globalprefs.research = VarSave.GetMoney("research");
                VarSave.SetInt("researchs/" + item, 0);

            }
            itemResearch.text = "Reserch item : " + item;
            reserch = 0;
        }
    }
}
