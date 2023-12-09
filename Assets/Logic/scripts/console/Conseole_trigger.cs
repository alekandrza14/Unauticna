using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conseole_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void run(string console)
    {
        if(console == "Xray")
        {
            ((mover)FindFirstObjectByType(typeof(mover))).xray();
        }
        if (console == "Next")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (console == "Back")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (console == "ClearObject")
        {
            FindFirstObjectByType<complsave>().clear();
        }


        List<string> s = new List<string>();
        string pre ="" ;
        for (int i = 0; i < console.Length; i++)
        {
            if (console[i]==' ')
            {
                s.Add(pre);
                pre = "";
            }else 
            {
                pre += console[i];
            }
        }
        s.Add(pre);
        string a = "";
        for (int i = 0; i < 2; i++)
        {
            if (s[0] == "scene")
            {
                a = "1";
            }
            if (s[0] == "scene_by_name")
            {
                a = "13";
            }
            if (s[0] == "iddqd")
            {
                a = "16";
            }
            if (s[0] == "no_kapitalizm")
            {
                a = "17";
            }
            if (s[0] == "yes_kapitalizm")
            {
                a = "18";
            }
            if (s[0] == "Kill_Economic")
            {
                a = "20";
            }
            if (s[0] == "Kill_Knowmic")
            {
                a = "21";
            }
            if (s[0] == "Unyverseium_money_cart")
            {
                a = "22";
            }
            if (s[0] == "newVolute")
            {
                a = "19";
            }
            if (s[0] == "Gamemode")
            {
                a = "7";
            }
            if (s[0] == "Obj")
            {
                a = "6";
            }
            if (s[0] == "Obj_E1_by_name")
            {
                a = "11";
            }
            if (s[0] == "Obj_E2_by_name")
            {
                a = "12";
            }
            if (s[0] == "Item")
            {
                a = "9";
            }
            if (s[0] == "Item_by_name")
            {
                a = "10";
            }
            if (s[0] == "CustomObject_by_name")
            {
                a = "15";
            }
            if (s[0] == "moremoney")
            {
                a = "8";
            }
            if (s[0] == "movex")
            {
                a = "2";
            }
            if (s[0] == "movey")
            {
                a = "3";
            }
            if (s[0] == "movez")
            {
                a = "4";
            }
            if (s[0] == "movew")
            {
                a = "5";
            }
            if (s[0] == "moveh")
            {
                a = "14";
            }
            if (i == 1 && a == "1")
            {
                SceneManager.LoadScene(int.Parse(s[1]));

            }
            if (i == 1 && a == "13")
            {
                SceneManager.LoadScene(s[1]);

            }
            if (i == 1 && a == "16")
            {
                playerdata.Addeffect("Undyning", float.PositiveInfinity);

            }
            if (i == 1 && a == "17")
            {
                playerdata.Addeffect("No kapitalism", float.PositiveInfinity);

                VarSave.SetMoney("Inflation", 200000, SaveType.global);

            }
            if (i == 1 && a == "18")
            {
                VarSave.SetMoney("Inflation", 200000, SaveType.global);
                VarSave.SetMoney("tevro", 2000);

                playerdata.hasClearEffect("No kapitalism");

            }
            if (i == 1 && a == "19")
            {
                Globalprefs.flowteuvro /= (decimal)((Globalprefs.GetProcentInflitiuon() + 1));
                VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                VarSave.SetMoney("Inflation", 0, SaveType.global);
                VarSave.SetMoney("tevro", 0);

            }
            if (i == 1 && a == "20")
            {

                playerdata.Addeffect("No kapitalism", float.PositiveInfinity);
                VarSave.SetMoney("Inflation", 0, SaveType.global);

            }
            if (i == 1 && a == "21")
            {
                foreach (GameObject g in complsave.t3)
                {

                    if (!VarSave.ExistenceVar("researchs/" + g.name))
                    {
                        Directory.CreateDirectory("unsave/var/researchs");



                        Globalprefs.research = VarSave.GetMoney("research");
                        VarSave.SetInt("researchs/" + g.name, 0);

                    }
                }
                Globalprefs.knowlages = 1000;
                VarSave.SetMoney("research", decimal.MaxValue);
                gsave gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + Globalprefs.GetTimeline()));
                mover.main().gsave.progressofthepassage = int.MaxValue - 1000;
                gsave.progressofthepassage = int.MaxValue-1000;
                File.WriteAllText("unsave/capterg/" + Globalprefs.GetTimeline(), JsonUtility.ToJson(gsave));
                GameManager.save();

            }
            //Unyverseium_money_cart
            if (i == 1 && a == "22")
            {
                playerdata.Addeffect("Unyverseium_money_cart", float.PositiveInfinity);
                Globalprefs.Infinitysteuvro += double.Parse(s[1]);
                VarSave.LoadTrash("inftevro", double.Parse(s[1]));
            }
            if (i == 1 && a == "2")
            {
                mover.FindFirstObjectByType<mover>().transform.position += Vector3.right * int.Parse(s[1]);

            }
            if (i == 1 && a == "3")
            {
                mover.FindFirstObjectByType<mover>().transform.position += Vector3.up * int.Parse(s[1]);

            }
            if (i == 1 && a == "4")
            {
                mover.FindFirstObjectByType<mover>().transform.position += Vector3.forward * int.Parse(s[1]);

            }
            if (i == 1 && a == "5")
            {
                mover.FindFirstObjectByType<mover>().W_position += int.Parse(s[1]);

            }
            if (i == 1 && a == "14")
            {
                mover.FindFirstObjectByType<mover>().H_position += int.Parse(s[1]);

            }
            if (i == 1 && a == "6")
            {
                GameObject[] g = Resources.LoadAll<GameObject>("Primetives");
                Instantiate(g[int.Parse(s[1])], mover.FindFirstObjectByType<mover>().transform.position, Quaternion.identity);

            }
            if (i == 1 && a == "11")
            {
                GameObject g = Resources.Load<GameObject>("Primetives/E1/" + s[1]);
                Instantiate(g, mover.FindFirstObjectByType<mover>().transform.position, Quaternion.identity);

            }
            if (i == 1 && a == "12")
            {
                GameObject g = Resources.Load<GameObject>("Primetives/E2/" + s[1]);
                Instantiate(g, mover.FindFirstObjectByType<mover>().transform.position, Quaternion.identity);

            }
            if (i == 1 && a == "10")
            {
                GameObject g = Resources.Load<GameObject>("items/" + s[1]);
                Instantiate(g, mover.FindFirstObjectByType<mover>().transform.position, Quaternion.identity);

            }
            if (i == 1 && a == "15")
            {

                GameObject g = Instantiate(Resources.Load<GameObject>("CustomObject"), mover.FindFirstObjectByType<mover>().transform.position, Quaternion.identity);
                g.GetComponent<CustomObject>().s = s[1];
                // + s[1]

            }
            if (i == 1 && a == "9")
            {
                GameObject[] g = Resources.LoadAll<GameObject>("items");
                Instantiate(g[int.Parse(s[1])], mover.FindFirstObjectByType<mover>().transform.position, Quaternion.identity);

            }
            if (i == 1 && a == "8")
            {
                VarSave.LoadMoney("Inflation", int.Parse(s[1]) / 2000, SaveType.global);
              VarSave.SetMoney("tevro", VarSave.GetMoney("tevro")+  int.Parse(s[1]));
            }
            if (i == 1 && a == "7")
            {
                if (s[1] == "0" || s[1] == "Adventure")
                {
                    Directory.Delete("debug");
                
                }
                if (s[1] == "1" || s[1] == "Debug")
                {
                    Directory.CreateDirectory("debug");
                }
                

            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9) && !GameObject.FindWithTag("console"))
        {
            Instantiate(Resources.Load<GameObject>("ui/console/Console").gameObject, transform.position, Quaternion.identity);
            Global.PauseManager.Pause();

        }
        if (Input.GetKeyDown(KeyCode.Return) && FindObjectsByType<Console_pointer>(sortmode.main).Length > 0)
        {
            run(FindFirstObjectByType<Console_pointer>().text.text);
            VarSave.SetString("console", FindFirstObjectByType<Console_pointer>().text.text);
            Destroy(GameObject.FindWithTag("console"));

            Global.PauseManager.Play();


        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && FindFirstObjectByType<Console_pointer>() != null)
        {
            FindFirstObjectByType<Console_pointer>().text.text = VarSave.GetString("console");


        }
    }
}
