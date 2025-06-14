using System.IO;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class PolitNode
{
    public string Rejime = "DEM";
}

public class OCPolitNode : MonoBehaviour
{
    public Text CustomObject;
    public string IdCustomObject;
    public Image AvtoritarianButton;
    public Image LidrtatianButton;
    public Image StupidButton;
    public Image DemoratianButton;
    public Image AntiPoliticalButton;
    public PolitNode newPolitNode = new PolitNode();
    public void Start()
    {
        if (File.Exists("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json")) 
        {
            newPolitNode = JsonUtility.FromJson<PolitNode>(File.ReadAllText("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json"));
        }
        Update2();
    }
    public void Update2()
    {
        CustomObject.text = IdCustomObject;
        if (newPolitNode != null) 
        { if (newPolitNode.Rejime != "AV" && newPolitNode.Rejime != "LIB" && newPolitNode.Rejime != "ST" && newPolitNode.Rejime != "AP")
            {
                AvtoritarianButton.color = Color.white;
                LidrtatianButton.color = Color.white;
                DemoratianButton.color = Color.yellow;
                StupidButton.color = Color.white;
                AntiPoliticalButton.color = Color.white;
            }
            else if (newPolitNode.Rejime == "AV")
            {
                AvtoritarianButton.color = Color.red;
                LidrtatianButton.color = Color.white;
                DemoratianButton.color = Color.white;
                StupidButton.color = Color.white;
                AntiPoliticalButton.color = Color.white;
            }
            else if (newPolitNode.Rejime == "LIB")
            {
                AvtoritarianButton.color = Color.white;
                LidrtatianButton.color = Color.green;
                DemoratianButton.color = Color.white;
                StupidButton.color = Color.white;
                AntiPoliticalButton.color = Color.white;
            }
            else if (newPolitNode.Rejime == "AP")
            {
                AvtoritarianButton.color = Color.white;
                LidrtatianButton.color = Color.white;
                DemoratianButton.color = Color.white;
                StupidButton.color = Color.white;
                AntiPoliticalButton.color = Color.black;
            }
            else if (newPolitNode.Rejime == "ST")
            {
                AvtoritarianButton.color = Color.white;
                LidrtatianButton.color = Color.white;
                DemoratianButton.color = Color.white;
                StupidButton.color = new Color(1,0,5,1);
                AntiPoliticalButton.color = Color.white;
            }
        }
        else
        {
            AvtoritarianButton.color = Color.white;
            LidrtatianButton.color = Color.white;
            DemoratianButton.color = Color.yellow;
            StupidButton.color = Color.white;
            AntiPoliticalButton.color = Color.white;
        }
    }
    public void AV()
    {
        newPolitNode.Rejime = "AV";
        File.WriteAllText("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json",JsonUtility.ToJson(newPolitNode));
        if (File.Exists("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json"))
        {
            newPolitNode = JsonUtility.FromJson<PolitNode>(File.ReadAllText("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json"));
        }
        Update2();
    }
    public void LIB()
    {
        newPolitNode.Rejime = "LIB";
        File.WriteAllText("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json", JsonUtility.ToJson(newPolitNode));
        if (File.Exists("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json"))
        {
            newPolitNode = JsonUtility.FromJson<PolitNode>(File.ReadAllText("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json"));
        }
        Update2();
    }
    public void ST()
    {
        newPolitNode.Rejime = "ST";
        File.WriteAllText("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json", JsonUtility.ToJson(newPolitNode));
        if (File.Exists("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json"))
        {
            newPolitNode = JsonUtility.FromJson<PolitNode>(File.ReadAllText("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json"));
        }
        Update2();
    }
    public void DEM()
    {
        newPolitNode.Rejime = "DEM";
        File.WriteAllText("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json", JsonUtility.ToJson(newPolitNode));
        if (File.Exists("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json"))
        {
            newPolitNode = JsonUtility.FromJson<PolitNode>(File.ReadAllText("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json"));
        }
        Update2();
    }
    public void AP()
    {
        newPolitNode.Rejime = "AP";
        File.WriteAllText("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json", JsonUtility.ToJson(newPolitNode));
        if (File.Exists("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json"))
        {
            newPolitNode = JsonUtility.FromJson<PolitNode>(File.ReadAllText("res/UserWorckspace/PolitNodesCO/" + IdCustomObject + ".json"));
        }
        Update2();
    }
}
