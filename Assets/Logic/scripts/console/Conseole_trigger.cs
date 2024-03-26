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
        if (console == "MyPills")
        {
            playerdata.Cleareffect();
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
            if (s[0] == "Pirati_sasut")
            {
                a = "23";
            }
            if (s[0] == "Quest")
            {
                a = "26";
            }
            if (s[0] == "saveMap")
            {
                a = "27";
            }
            if (s[0] == "Teleport")
            {
                a = "28";
            }
            if (s[0] == "StartPoket")
            {
                a = "24";
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
            if (s[0] == "right_to_dig")
            {
                a = "25";
            }
            if (s[0] == "AutoRun")
            {
                a = "29";
            }
            if (s[0] == "AutoRotate")
            {
                a = "30";
            }
            if (s[0] == "AutoJump")
            {
                a = "31";
            }
            if (s[0] == "AutoDown")
            {
                a = "32";
            }
            if (s[0] == "AutoRight")
            {
                a = "33";
            }
            if (s[0] == "AutoLeft")
            {
                a = "34";
            }
            if (s[0] == "AutoDimenshonal")
            {
                a = "35";
            }
            if (s[0] == "-AutoDimenshonal")
            {
                a = "36";
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

                playerdata.hasClearEffect("No kapitalism");
                playerdata.hasClearEffect("Unyverseium_money_cart");
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
            if (i == 1 && a == "23")
            {
                Instantiate(Resources.Load<GameObject>("events/Pirats"));
            }
            if (i == 1 && a == "24")
            {
                if (s[1] == "Pirat")
                {
                    Instantiate(Resources.Load<GameObject>("items/Gold"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Gold"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Gold"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Gold"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Gold"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Gold"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Gold"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);

                    Instantiate(Resources.Load<GameObject>("items/infinity_gun"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/infinity_gun"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);

                    Instantiate(Resources.Load<GameObject>("items/file_рыбы"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/file_рыбы"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/file_рыбы"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/file_рыбы"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    VarSave.LoadMoney("tevro", 5000); VarSave.SetString("ProfStatus", "Pirat");
                }

                if (s[1] == "Programer")
                {
                    Instantiate(Resources.Load<GameObject>("items/Script"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Script"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Script"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Script"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Script"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);

                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    VarSave.SetString("ProfStatus", "Programer");
                    VarSave.LoadMoney("tevro", 2000);
                }
                if (s[1] == "Farmer")
                {
                    Instantiate(Resources.Load<GameObject>("items/Belock"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);

                    Instantiate(Resources.Load<GameObject>("items/MiniChest"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/MiniChest"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    VarSave.SetString("ProfStatus", "Farmer");
                    VarSave.LoadMoney("tevro", 200);
                }
                if (s[1] == "Traider")
                {
                    VarSave.SetString("ProfStatus", "Traider");
                    GameObject[] res = Resources.LoadAll<GameObject>("items");
                    for (int i2 = 0; i2 < 30; i2++)
                    {
                        Instantiate(res[Random.Range(0, res.Length)], mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    }
                    VarSave.LoadMoney("tevro", 5000);
                }
                if (s[1] == "Adventurer")
                {

                    Instantiate(Resources.Load<GameObject>("items/Infinity_Gun"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/4D-Glasses"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    //4D-Glasses
                    VarSave.SetString("ProfStatus", "Adventurer");
                    VarSave.LoadMoney("tevro", 500);
                }
                if (s[1] == "Warior")
                {

                    Instantiate(Resources.Load<GameObject>("items/Infinity_Gun"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    //4D-Glasses
                    VarSave.SetString("ProfStatus", "Warior");
                    VarSave.LoadMoney("tevro", 100);
                }
                if (s[1] == "Scientist")
                {

                    Instantiate(Resources.Load<GameObject>("items/Infinity_Gun"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/4D-Glasses"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Kley"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/accumulator"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    //Kley
                    //4D-Glasses
                    VarSave.SetString("ProfStatus", "Scientist");
                    VarSave.LoadMoney("tevro", 10000);
                }
                if (s[1] == "Astronom")
                {

                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/4D-Glasses"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Kley"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/accumulator"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/accumulator"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/accumulator"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/GravityAx"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Gravity_board"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    //GravityAx
                    //Gravity_board
                    VarSave.SetString("ProfStatus", "Astronom");
                    VarSave.LoadMoney("tevro", 1000);
                }
                if (s[1] == "Astronaft")
                {

                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/4D-Glasses"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Kley"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/accumulator"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/GravityAx"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Gravity_board"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/WarpEngine"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    //GravityAx
                    //Gravity_board
                    VarSave.SetString("ProfStatus", "Astronaft");
                    VarSave.LoadMoney("tevro", 1000);
                }
                if (s[1] == "Economist")
                {

                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("Primetives/E2/stocks"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("Primetives/E2/stocks2"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("Primetives/E2/stocks3"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("Primetives/E2/stocks4"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("Primetives/E2/stocks5"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    //GravityAx
                    //Gravity_board
                    VarSave.SetString("ProfStatus", "Economist");
                    VarSave.LoadMoney("tevro", 20000);
                  Globalprefs.flowteuvro =  VarSave.LoadMoney("CashFlow", 10);
                }
                if (s[1] == "PlanetMaster")
                {

                    Instantiate(Resources.Load<GameObject>("items/Infinity_Gun"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);

                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Gravity_board"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/WarpEngine"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);

                    Instantiate(Resources.Load<GameObject>("items/RayGun"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    VarSave.SetString("ProfStatus", "PlanetMaster");
                    //GravityAx
                    //Gravity_board

                    VarSave.LoadMoney("tevro", 2000000);
                    Globalprefs.flowteuvro = VarSave.LoadMoney("CashFlow", 1000);
                }
                if (s[1] == "Fashist")
                {

                    Instantiate(Resources.Load<GameObject>("items/пильмени"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Infinity_Gun"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Kley"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/accumulator"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Kley"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/accumulator"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    VarSave.SetString("ProfStatus", "Fashist");
                    //GravityAx
                    //Gravity_board

                    VarSave.LoadMoney("tevro", 2000);
                }
                if (s[1] == "Cheter")
                {

                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Duper"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/СамоучительПоНероазрушимымСтенам"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Портал_в_логово_читеров"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/MltiverseMagicStick"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    VarSave.SetString("ProfStatus", "Cheter");
                    //Портал_в_логово_читеров
                    //Gravity_board

                    VarSave.LoadMoney("tevro", 9999999);
                    Globalprefs.flowteuvro = VarSave.LoadMoney("CashFlow", 9999);
                }
                if (s[1] == "Witch")
                {

                    Instantiate(Resources.Load<GameObject>("items/СамоучительПоНероазрушимымСтенам"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/MltiverseMagicStick"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Портал_в_логово_читеров"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/BlueMetka"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/BlueMetka"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/BlueMetka"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/BlueMetka"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/BlueMetka"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/RedMetka"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/RedMetka"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/RedMetka"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/RedMetka"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/RedMetka"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Учебник_по_Всемогуществу"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/KsenoMorfin"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Absolute_poison"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    VarSave.SetString("ProfStatus", "Witch");
                    //KsenoMorfin
                    //Absolute_poison

                    VarSave.LoadMoney("tevro", 1000);
                }
                if (s[1] == "Bankcrot")
                {

                    VarSave.SetString("ProfStatus", "Bankcrot");

                    //KsenoMorfin
                    //Absolute_poison
                    VarSave.SetBool("Bunkrot", true);
                    VarSave.LoadMoney("tevro", -10000);
                    Globalprefs.flowteuvro = VarSave.LoadMoney("CashFlow", -10);
                }
                if (s[1] == "BisnessMen")
                {

                    Instantiate(Resources.Load<GameObject>("items/Infinity_Gun"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);

                    Instantiate(Resources.Load<GameObject>("items/Worker"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Worker"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Worker"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Worker"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Worker"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Worker"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);

                    Instantiate(Resources.Load<GameObject>("items/DirectorTable"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    VarSave.SetString("ProfStatus", "BisnessMen");
                    //KsenoMorfin
                    //Absolute_poison
                    VarSave.LoadMoney("tevro", 1000);
                    Globalprefs.flowteuvro = VarSave.LoadMoney("CashFlow", 5);
                }
                if (s[1] == "StoneBraker")
                {

                    Instantiate(Resources.Load<GameObject>("items/Worker"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Каменьщикоый_камень"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Каменьщикоый_камень"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Каменьщикоый_камень"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Каменьщикоый_камень"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Каменьщикоый_камень"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Каменьщикоый_камень"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Каменьщикоый_камень"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Каменьщикоый_камень"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/Каменьщикоый_камень"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    VarSave.SetString("ProfStatus", "StoneBraker");
                    //KsenoMorfin
                    //Absolute_poison
                    VarSave.LoadMoney("tevro", 10);
                }
                if (s[1] == "BlackHoleScientist")
                {

                    Instantiate(Resources.Load<GameObject>("items/MiniHole"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    VarSave.SetString("ProfStatus", "BlackHoleScientist");
                    //KsenoMorfin
                    //Absolute_poison
                    VarSave.LoadMoney("tevro", 1000000);
                }
                if (s[1] == "King")
                {

                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/SampleCrown"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    VarSave.SetString("ProfStatus", "King");
                    //SampleCrown
                    //Absolute_poison
                    VarSave.LoadMoney("tevro", 2500000000);
                    cistalenemy.dies -= 10000;
                    Globalprefs.flowteuvro = VarSave.LoadMoney("CashFlow", 5500);
                }
                if (s[1] == "Watchman")
                {
                    Instantiate(Resources.Load<GameObject>("items/Kley"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/4D-Glasses"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/CraftStantion"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/AppleJuice"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    VarSave.SetString("ProfStatus", "Watchman");
                    //SampleCrown
                    //Absolute_poison
                    VarSave.LoadMoney("tevro", 250);
                }
                if (s[1] == "Builder")
                {
                    Instantiate(Resources.Load<GameObject>("items/Kley"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/builder"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/ItemKey"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/СамоучительПоСтраительству"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    VarSave.SetString("ProfStatus", "Builder");
                    //SampleCrown
                    //Absolute_poison
                    VarSave.LoadMoney("tevro", 2500);
                }
                if (s[1] == "Electric")
                {
                    Instantiate(Resources.Load<GameObject>("items/Kley"), mover.main().transform.position + PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/builder"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/ItemKey"), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/accumulator"), mover.main().transform.position + PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/battery"), mover.main().transform.position + PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/BioElectrostation"), mover.main().transform.position + PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/ButtonGenerator"), mover.main().transform.position + PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/SunPanel"), mover.main().transform.position + PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/LightStick"), mover.main().transform.position + PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/mathimatic_battery"), mover.main().transform.position + PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    VarSave.SetString("ProfStatus", "Electric");
                    //SampleCrown
                    //Absolute_poison
                    VarSave.LoadMoney("tevro", 2500);
                }
            }
            if (i == 1 && a == "25")
            {
                if (s.Count == 1) playerdata.Addeffect("Right_to_dig", float.PositiveInfinity);
                if (s.Count == 2) if (s[1] == "on") playerdata.Addeffect("Right_to_dig", float.PositiveInfinity);
                if (s.Count == 2) if (s[1] == "off")
                    {
                        playerdata.hasClearEffect("Right_to_dig");
                        playerdata.hasClearEffect("Right_to_dig");
                        playerdata.hasClearEffect("Right_to_dig");
                        playerdata.hasClearEffect("Right_to_dig");
                        playerdata.hasClearEffect("Right_to_dig");
                        playerdata.hasClearEffect("Right_to_dig");
                    }
            }
            if (i == 1 && a == "29")
            {
                playerdata.hasClearEffect("AutoRun");
                playerdata.Addeffect("AutoRun", float.Parse(s[1]));
            }
            if (i == 1 && a == "30")
            {
                playerdata.hasClearEffect("AutoRotate");
                playerdata.Addeffect("AutoRotate", float.Parse(s[1]));
            }
            if (i == 1 && a == "31")
            {
                playerdata.hasClearEffect("AutoJump");
                playerdata.Addeffect("AutoJump", float.Parse(s[1]));
            }
            if (i == 1 && a == "32")
            {
                playerdata.hasClearEffect("AutoDown");
                playerdata.Addeffect("AutoDown", float.Parse(s[1]));
            }
            if (i == 1 && a == "33")
            {
                playerdata.hasClearEffect("AutoRight");
                playerdata.Addeffect("AutoRight", float.Parse(s[1]));
            }
            if (i == 1 && a == "34")
            {
                playerdata.hasClearEffect("AutoLeft");
                playerdata.Addeffect("AutoLeft", float.Parse(s[1]));
            }
            if (i == 1 && a == "35")
            {
                playerdata.hasClearEffect("AutoDimenshonal");
                playerdata.hasClearEffect("-AutoDimenshonal");
                VarSave.SetFloat("Dimenshonal", float.Parse(s[2]));
                playerdata.Addeffect("AutoDimenshonal", float.Parse(s[1]));
            }
            if (i == 1 && a == "36")
            {
                playerdata.hasClearEffect("AutoDimenshonal");
                playerdata.hasClearEffect("-AutoDimenshonal");
                VarSave.SetFloat("Dimenshonal", float.Parse(s[2]));
                playerdata.Addeffect("-AutoDimenshonal", float.Parse(s[1]));
            }
            if (i == 1 && a == "26")
            {
                VarSave.SetString("quest", s[1], SaveType.global);
            }
            if (i == 1 && a == "27")
            {
                Directory.CreateDirectory("res/UserWorckspace/maps");
                complsave.ObjectSaveManager.saveMap("res/UserWorckspace/maps/_" + s[1]);
            }
            if (i == 1 && a == "28")
            {
                mover.main().transform.position = new Vector3(float.Parse(s[1])+mover.new_offset.x, float.Parse(s[2]) + mover.new_offset.y, float.Parse( s[3]) + mover.new_offset.z);
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
            if (VarSave.GetFloat(
            "Freedomfil" + "_gameSettings", SaveType.global) >= .1f)
            {
                VarSave.LoadFloat("reason", 1);
            }
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
