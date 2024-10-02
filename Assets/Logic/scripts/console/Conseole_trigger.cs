using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum ConsoleType
{
    Player,Computer
}

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
            FindFirstObjectByType<Map_saver>().ClearObjects();
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
            if (s[0] == "SaveMap")
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
            if (s[0] == "ExpTevro")
            {
                a = "37";
            }
            if (s[0] == "OverFlow")
            {
                a = "38";
            }
            if (s[0] == "MoreFlow")
            {
                a = "40";
            }
            if (s[0] == "Arkadilion")
            {
                a = "39";
            }
            if (s[0] == "Million")
            {
                a = "41";
            }
            if (s[0] == "Night")
            {
                a = "42";
            }
            if (s[0] == "AntiNight")
            {
                a = "43";
            }
            if (s[0] == "Day")
            {
                a = "44";
            }
            if (s[0] == "Refletion")
            {
                a = "45";
            }
            //OratographicCamera
            if (s[0] == "NiChance")
            {
                a = "46";
            }
            if (s[0] == "OrtoCam")
            {
                a = "47";
            }
            if (s[0] == "Ranall")
            {
                a = "48";
            }
            if (s[0] == "3D_Glass")
            {
                a = "49";
            }
            if (s[0] == "RespCam")
            {
                a = "50";
            }
            if (s[0] == "ActiveGaster")
            {
                a = "51";
            }
            if (s[0] == "summon")
            {
                a = "52";
            }
            if (s[0] == "new_social")
            {
                a = "53";
            }
            if (s[0] == "get_materials")
            {
                a = "54";
            }
            if (s[0] == "grid1_Item_by_name")
            {
                a = "55";
            }
            if (s[0] == "grid2_Item_by_name")
            {
                a = "56";
            }
            if (s[0] == "grid3_Item_by_name")
            {
                a = "57";
            }
            if (s[0] == "grid4_Item_by_name")
            {
                a = "58";
            }
            if (s[0] == "grid1_CustomObject_by_name")
            {
                a = "59";
            }
            if (s[0] == "grid2_CustomObject_by_name")
            {
                a = "60";
            }
            if (s[0] == "grid3_CustomObject_by_name")
            {
                a = "61";
            }
            if (s[0] == "grid4_CustomObject_by_name")
            {
                a = "62";
            }
            if (s[0] == "Give_Effect")
            {
                a = "63";
            }
            if (s[0].Length>0) if (s[0][0] =='/') a = s[0].Replace("/","");
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
                foreach (GameObject g in Map_saver.t3)
                {

                    if (!VarSave.ExistenceVar("researchs/" + g.name))
                    {
                        Directory.CreateDirectory("unsave/var/researchs");



                        Globalprefs.research = VarSave.GetMoney("research");
                        VarSave.SetInt("researchs/" + g.name, 0);

                    }
                }
                Globalprefs.knowlages = 1000;
                VarSave.SetMoney("research", decimal.MaxValue - 1000000);
                GameData gsave = JsonUtility.FromJson<GameData>(File.ReadAllText("unsave/capterg/" + Globalprefs.GetTimeline()));
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

                    Instantiate(Resources.Load<GameObject>("items/file_    "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/file_    "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/file_    "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/file_    "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
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
                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/4D-Glasses"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    //4D-Glasses
                    VarSave.SetString("ProfStatus", "Adventurer");
                    VarSave.LoadMoney("tevro", 500);
                }
                if (s[1] == "Warior")
                {

                    Instantiate(Resources.Load<GameObject>("items/Infinity_Gun"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    //4D-Glasses
                    VarSave.SetString("ProfStatus", "Warior");
                    VarSave.LoadMoney("tevro", 100);
                }
                if (s[1] == "Scientist")
                {

                    Instantiate(Resources.Load<GameObject>("items/Infinity_Gun"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
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

                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
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

                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
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

                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
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

                    Instantiate(Resources.Load<GameObject>("items/        "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
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
                    Instantiate(Resources.Load<GameObject>("items/                                "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/      _ _      _       "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/MltiverseMagicStick"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    VarSave.SetString("ProfStatus", "Cheter");
                    //      _ _      _       
                    //Gravity_board

                    VarSave.LoadMoney("tevro", 9999999);
                    Globalprefs.flowteuvro = VarSave.LoadMoney("CashFlow", 9999);
                }
                if (s[1] == "Witch")
                {

                    Instantiate(Resources.Load<GameObject>("items/                                "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/MltiverseMagicStick"),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/      _ _      _       "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
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
                    Instantiate(Resources.Load<GameObject>("items/       _  _             "),mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0),Quaternion.identity);
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
                    Instantiate(Resources.Load<GameObject>("items/            _      "), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/            _      "), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/            _      "), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/            _      "), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/            _      "), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/            _      "), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/            _      "), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/            _      "), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
                    Instantiate(Resources.Load<GameObject>("items/            _      "), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
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
                    Instantiate(Resources.Load<GameObject>("items/                          "), mover.main().transform.position+ PiratAttack.randomCube(6,6)+new Vector3(0,6,0), Quaternion.identity);
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
            if (i == 1 && a == "37")
            {

                VarSave.SetTrash("MOMU", double.Parse(s[1]));
            }
            if (i == 1 && a == "38")
            {

                VarSave.SetMoney("OverFlow", decimal.Parse(s[1]));
            }
            if (i == 1 && a == "40")
            {
              Globalprefs.flowteuvro = decimal.Parse(s[1]);

                VarSave.SetMoney("CashFlow", decimal.Parse(s[1]));
            }
            if (i == 1 && a == "39")
            {
                VarSave.SetTrash("MOMU", 30e15);
                VarSave.SetMoney("tevro", 1);
            }
            if (i == 1 && a == "41")
            {
                VarSave.SetTrash("MOMU", 0);
                VarSave.SetMoney("tevro", 1000000);
            }
            if (i == 1 && a == "42")
            {
                Sutck.SetSutck(0f);
            }
            if (i == 1 && a == "43")
            {
                Sutck.SetSutck(2f);
            }
            if (i == 1 && a == "44")
            {
                Sutck.SetSutck(1f);
            }
            if (i == 1 && a == "26")
            {
                VarSave.SetString("quest", s[1], SaveType.global);
            }
            if (i == 1 && a == "27")
            {
                Directory.CreateDirectory("res/UserWorckspace/maps");
                Map_saver.ObjectSaveManager.SaveMap("res/UserWorckspace/maps/_" + s[1]);
            }
            if (i == 1 && a == "28")
            {
                mover.main().transform.position = new Vector3(float.Parse(s[1]) + mover.new_offset.x, float.Parse(s[2]) + mover.new_offset.y, float.Parse(s[3]) + mover.new_offset.z);
            }
            if (i == 1 && a == "45")
            {
                GameObject g = Resources.Load<GameObject>("Reflection Probe");
                Instantiate(g, Vector3.zero, Quaternion.identity);
                //Reflection Probe
            }
            //OratographicCamera
            if (i == 1 && a == "46")
            {
                Global.Random.determindAll = true;
            }
            if (i == 1 && a == "47")
            {
                GameObject g = Resources.Load<GameObject>("OratographicCamera");
                Instantiate(g, Vector3.zero, Quaternion.identity);
            }
            if (i == 1 && a == "48")
            {
                GameObject g = Resources.Load<GameObject>("CameraRandomObject");
                Instantiate(g, Vector3.zero, Quaternion.identity);
            }
            if (i == 1 && a == "49")
            {
                GameObject g = Resources.Load<GameObject>("Glass3D");
                Instantiate(g, Vector3.zero, Quaternion.identity);
            }
            if (i == 1 && a == "50")
            {
                GameObject g = Resources.Load<GameObject>("Respcam");
                Instantiate(g, Vector3.zero, Quaternion.identity);
            }
            if (i == 1 && a == "51")
            {
                FindAnyObjectByType<ActiveGaster>().Gas();
            }
            if (i == 1 && a == "52")
            {
                GameObject g = Resources.Load<GameObject>(s[1]);
                Instantiate(g, mover.main().transform.position, Quaternion.identity);
            }
            if (i == 1 && a == "53")
            {
                Directory.CreateDirectory("res/UserWorckspace/Social");
                File.WriteAllText("res/UserWorckspace/Social/" + s[1] + ".json", JsonUtility.ToJson(new SocialTriggerData()));
            }
            if (i == 1 && a == "54")
            {
                Material[] m = Resources.LoadAll<Material>("CO_MainMaterials");
                string msg = "";
                int numMaterial = 0;
                foreach (Material item in m)
                {
                    msg += "         " + numMaterial.ToString() + " \"" + item.name + "\"\n";
                    numMaterial++;
                }
                Loger.Sand(msg);
            }
            if (i == 1 && a == "55")
            {
                for (int x = 0; x < float.Parse(s[2]); x++)
                {
                    GameObject g = Resources.Load<GameObject>("items/" + s[1]);
                    GameObject obj = Instantiate(g, mover.main().transform.position + new Vector3(x * float.Parse(s[3]), 0, 0), Quaternion.identity);
                }
            }
            if (i == 1 && a == "56")
            {
                for (int x = 0; x < float.Parse(s[2]); x++)
                {
                    for (int y = 0; y < float.Parse(s[3]); y++)
                    {
                        GameObject g = Resources.Load<GameObject>("items/" + s[1]);
                        GameObject obj = Instantiate(g, mover.main().transform.position + new Vector3(x * float.Parse(s[4]), y * float.Parse(s[4]), 0), Quaternion.identity);
                    }
                }
            }
            if (i == 1 && a == "57")
            {
                for (int x = 0; x < float.Parse(s[2]); x++)
                {
                    for (int y = 0; y < float.Parse(s[3]); y++)
                    {
                        for (int z = 0; z < float.Parse(s[4]); z++)
                        {
                            GameObject g = Resources.Load<GameObject>("items/" + s[1]);
                            GameObject obj = Instantiate(g, mover.main().transform.position + new Vector3(x * float.Parse(s[5]), y * float.Parse(s[5]), z * float.Parse(s[5])), Quaternion.identity);
                        }
                    }
                }
            }
            if (i == 1 && a == "58")
            {
                for (int x = 0; x < float.Parse(s[2]); x++)
                {
                    for (int y = 0; y < float.Parse(s[3]); y++)
                    {
                        for (int z = 0; z < float.Parse(s[4]); z++)
                        {
                            for (int w = 0; w < float.Parse(s[5]); w++)
                            {
                                GameObject g = Resources.Load<GameObject>("items/" + s[1]);
                                GameObject obj = Instantiate(g, mover.main().transform.position + new Vector3(x * float.Parse(s[6]), y * float.Parse(s[6]), z * float.Parse(s[6])), Quaternion.identity);
                                if (obj.GetComponent<MultyObject>())
                                {
                                    Vector3 v3 = mover.main().transform.position + new Vector3(x * float.Parse(s[6]), y * float.Parse(s[6]), z * float.Parse(s[6]));
                                    obj.GetComponent<MultyObject>().saved = true;
                                    obj.GetComponent<MultyObject>().shape = Shape.cube5D;
                                    obj.GetComponent<MultyObject>().startPosition = new Vector6(v3.x, v3.y, v3.z,
                                           mover.main().W_position + (w * float.Parse(s[6])),
                                           mover.main().H_position, 0);
                                    obj.GetComponent<MultyObject>().W_Position = mover.main().W_position + (w * float.Parse(s[6]));
                                }
                                else if (s.Count >= 7+1)
                                {
                                    if (s[7] == "1")
                                    {
                                        Vector3 v3 = mover.main().transform.position + new Vector3(x * float.Parse(s[6]), y * float.Parse(s[6]), z * float.Parse(s[6]));
                                        obj.AddComponent<MultyObject>().saved = true;
                                        obj.GetComponent<MultyObject>().shape = Shape.cube5D;
                                        obj.GetComponent<MultyObject>().startPosition = new Vector6(v3.x, v3.y, v3.z,
                                           mover.main().W_position + (w * float.Parse(s[6])),
                                           mover.main().H_position, 0);
                                        obj.GetComponent<MultyObject>().W_Position = mover.main().W_position + (w * float.Parse(s[6]));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (i == 1 && a == "59")
            {
                for (int x = 0; x < float.Parse(s[2]); x++)
                {
                    GameObject g = Resources.Load<GameObject>("CustomObject");
                    GameObject obj = Instantiate(g, mover.main().transform.position + new Vector3(x * float.Parse(s[3]), 0, 0), Quaternion.identity);
                    obj.GetComponent<CustomObject>().s = s[1];
                }
            }
            if (i == 1 && a == "60")
            {
                for (int x = 0; x < float.Parse(s[2]); x++)
                {
                    for (int y = 0; y < float.Parse(s[3]); y++)
                    {
                        GameObject g = Resources.Load<GameObject>("CustomObject");
                        GameObject obj = Instantiate(g, mover.main().transform.position + new Vector3(x * float.Parse(s[4]), y * float.Parse(s[4]), 0), Quaternion.identity);
                        obj.GetComponent<CustomObject>().s = s[1];
                    }
                }
            }
            if (i == 1 && a == "61")
            {
                for (int x = 0; x < float.Parse(s[2]); x++)
                {
                    for (int y = 0; y < float.Parse(s[3]); y++)
                    {
                        for (int z = 0; z < float.Parse(s[4]); z++)
                        {
                            GameObject g = Resources.Load<GameObject>("CustomObject");
                            GameObject obj = Instantiate(g, mover.main().transform.position + new Vector3(x * float.Parse(s[5]), y * float.Parse(s[5]), z * float.Parse(s[5])), Quaternion.identity);
                            obj.GetComponent<CustomObject>().s = s[1];
                        }
                    }
                }
            }
            if (i == 1 && a == "62")
            {
                for (int x = 0; x < float.Parse(s[2]); x++)
                {
                    for (int y = 0; y < float.Parse(s[3]); y++)
                    {
                        for (int z = 0; z < float.Parse(s[4]); z++)
                        {
                            for (int w = 0; w < float.Parse(s[5]); w++)
                            {
                                GameObject g = Resources.Load<GameObject>("CustomObject");
                                GameObject obj = Instantiate(g, mover.main().transform.position + new Vector3(x * float.Parse(s[6]), y * float.Parse(s[6]), z * float.Parse(s[6])), Quaternion.identity);
                                obj.GetComponent<CustomObject>().s = s[1];
                                if (obj.GetComponent<MultyObject>())
                                {
                                    Vector3 v3 = mover.main().transform.position + new Vector3(x * float.Parse(s[6]), y * float.Parse(s[6]), z * float.Parse(s[6]));
                                    obj.GetComponent<MultyObject>().saved = true;
                                    obj.GetComponent<MultyObject>().shape = Shape.cube5D; 
                                    obj.GetComponent<MultyObject>().startPosition = new Vector6(v3.x, v3.y, v3.z,
                                            mover.main().W_position + (w * float.Parse(s[6])),
                                            mover.main().H_position, 0);
                                    obj.GetComponent<MultyObject>().W_Position = mover.main().W_position + (w * float.Parse(s[6]));

                                }
                                else if (s.Count >= 7 + 1)
                                {
                                    if (s[7] == "1")
                                    {
                                        Vector3 v3 = mover.main().transform.position + new Vector3(x * float.Parse(s[6]), y * float.Parse(s[6]), z * float.Parse(s[6]));
                                        obj.AddComponent<MultyObject>().saved = true;
                                        obj.GetComponent<MultyObject>().shape = Shape.cube5D;
                                        obj.GetComponent<MultyObject>().startPosition = new Vector6(v3.x, v3.y, v3.z,
                                            mover.main().W_position + (w * float.Parse(s[6])),
                                            mover.main().H_position,0);
                                        obj.GetComponent<MultyObject>().W_Position = mover.main().W_position + (w * float.Parse(s[6]));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (i == 1 && a == "63")
            {
                if (s[1] == "@All")
                {
                    if (s[2] == "LSD")
                    {
                        playerdata.Addeffect("Tripl3", 120);
                        CharacterName[] CharacterNames = FindObjectsByType<CharacterName>(sortmode.main);
                        foreach (CharacterName item in CharacterNames)
                        {
                            item.gameObject.AddComponent<LSDMob>();
                        }
                        SocialObject[] CharacterNames2 = FindObjectsByType<SocialObject>(sortmode.main);
                        foreach (SocialObject item in CharacterNames2)
                        {
                            item.gameObject.AddComponent<LSDMob>();
                        }
                    }
                    if (s[2] == "Sigas")
                    {
                        Instantiate(Resources.Load<GameObject>("ƒым"), mover.main().transform);
                        CharacterName[] CharacterNames = FindObjectsByType<CharacterName>(sortmode.main);
                        foreach (CharacterName item in CharacterNames)
                        {
                            Instantiate(Resources.Load<GameObject>("ƒым"), item.transform);
                        }
                        SocialObject[] CharacterNames2 = FindObjectsByType<SocialObject>(sortmode.main);
                        foreach (SocialObject item in CharacterNames2)
                        {
                            Instantiate(Resources.Load<GameObject>("ƒым"), item.transform);
                        }
                    }
                }
                if (s[1] == "@Others")
                {
                    if (s[2] == "LSD")
                    {
                        CharacterName[] CharacterNames = FindObjectsByType<CharacterName>(sortmode.main);
                        foreach (CharacterName item in CharacterNames)
                        {
                            item.gameObject.AddComponent<LSDMob>();
                        }
                        SocialObject[] CharacterNames2 = FindObjectsByType<SocialObject>(sortmode.main);
                        foreach (SocialObject item in CharacterNames2)
                        {
                            item.gameObject.AddComponent<LSDMob>();
                        }
                    }
                    if (s[2] == "Sigas")
                    {
                        
                        CharacterName[] CharacterNames = FindObjectsByType<CharacterName>(sortmode.main);
                        foreach (CharacterName item in CharacterNames)
                        {
                            Instantiate(Resources.Load<GameObject>("ƒым"), item.transform);
                        }
                        SocialObject[] CharacterNames2 = FindObjectsByType<SocialObject>(sortmode.main);
                        foreach (SocialObject item in CharacterNames2)
                        {
                            Instantiate(Resources.Load<GameObject>("ƒым"), item.transform);
                        }
                    }
                }
                if (s[1] == "@Geniuses")
                {
                    if (s[2] == "LSD")
                    {
                        CharacterStats[] CharacterStatss = FindObjectsByType<CharacterStats>(sortmode.main);
                        foreach (CharacterStats item in CharacterStatss)
                        {
                            item.gameObject.AddComponent<LSDMob>();
                        }
                    }
                    if (s[2] == "Sigas")
                    {
                        CharacterStats[] CharacterStatss = FindObjectsByType<CharacterStats>(sortmode.main);
                        foreach (CharacterStats item in CharacterStatss)
                        {
                            Instantiate(Resources.Load<GameObject>("ƒым"), item.transform);
                        }
                      
                    }
                }
                if (s[1] == "@Self")
                {
                    int дым = 0;
                    дым += 1;
                    if (дым == 1)
                    {
                        дым += 1;
                    }
                    if (s[2] == "LSD")
                    {
                        playerdata.Addeffect("Tripl3", 120);
                    }
                    if (s[2] == "Sigas")
                    {
                        Instantiate(Resources.Load<GameObject>("ƒым"), mover.main().transform);
                    }
                }
            }
            if (i == 1 && a == "2")
            {
                mover.main().transform.position += Vector3.right * int.Parse(s[1]);

            }
            if (i == 1 && a == "3")
            {
                mover.main().transform.position += Vector3.up * int.Parse(s[1]);

            }
            if (i == 1 && a == "4")
            {
                mover.main().transform.position += Vector3.forward * int.Parse(s[1]);

            }
            if (i == 1 && a == "5")
            {
                mover.main().W_position += int.Parse(s[1]);

            }
            if (i == 1 && a == "14")
            {
                mover.main().H_position += int.Parse(s[1]);

            }
            if (i == 1 && a == "6")
            {
                GameObject[] g = Resources.LoadAll<GameObject>("Primetives");
                Instantiate(g[int.Parse(s[1])], mover.main().transform.position, Quaternion.identity);

            }
            if (i == 1 && a == "11")
            {
                GameObject g = Resources.Load<GameObject>("Primetives/E1/" + s[1]);
                Instantiate(g, mover.main().transform.position, Quaternion.identity);

            }
            if (i == 1 && a == "12")
            {
                GameObject g = Resources.Load<GameObject>("Primetives/E2/" + s[1]);
                Instantiate(g, mover.main().transform.position, Quaternion.identity);

            }
            if (i == 1 && a == "10")
            {
                GameObject g = Resources.Load<GameObject>("items/" + s[1]);
                Instantiate(g, mover.main().transform.position, Quaternion.identity);

            }
            if (i == 1 && a == "15")
            {

                GameObject g = Instantiate(Resources.Load<GameObject>("CustomObject"), mover.main().transform.position, Quaternion.identity);
                g.GetComponent<CustomObject>().s = s[1];
                // + s[1]

            }
            if (i == 1 && a == "9")
            {
                GameObject[] g = Resources.LoadAll<GameObject>("items");
                Instantiate(g[int.Parse(s[1])], mover.main().transform.position, Quaternion.identity);

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
    public ConsoleType ct;
    public InputField ifd;
    // Update is called once per frame
    void Update()
    {
        if (ct == ConsoleType.Player) 
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
              if(!string.IsNullOrEmpty(FindFirstObjectByType<Console_pointer>().text.text))  VarSave.SetString("console", FindFirstObjectByType<Console_pointer>().text.text);
                Destroy(GameObject.FindWithTag("console"));

                Global.PauseManager.Play();


            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && FindFirstObjectByType<Console_pointer>() != null)
            {
                FindFirstObjectByType<Console_pointer>().text.text = VarSave.GetString("console");


            }
        } 
    }
    public void Computer ()
    {
        if (ct == ConsoleType.Computer)
        {
            
            
                if (VarSave.GetFloat(
                "Freedomfil" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
                run(ifd.text);




        }
    }
}
