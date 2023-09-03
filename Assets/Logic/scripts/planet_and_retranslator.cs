using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class planet_and_retranslator : MonoBehaviour
{
    [SerializeField] string Target;
    [SerializeField] float PlanetMin;
    [SerializeField] float PlanetMax;
    [SerializeField] bool _interface;
    [SerializeField] string namePlanet;
    [SerializeField] int IdButton;
    [SerializeField] Text LaiblePlanet;
    void Start()
    {
        Vector2 posPlanet = new Vector2 (-(float)Globalprefs.GetIdPlanet()+(IdButton*300), (float)Globalprefs.GetIdPlanet()*9);
        float Hash = Globalprefs.Hash(posPlanet);
        Hash = (Hash + 1) / 2;
        Hash *= 30; 
        float Hash2 = Globalprefs.Hash(posPlanet);
        Hash2 = (Hash2 + 1) / 2;
        Hash2 *= 3316;
        if (!_interface) if (((int)Hash) <= PlanetMin || ((int)Hash) >= PlanetMax)
        {
            Destroy(gameObject);
        }
        namePlanet = GetNamePlanet((int)Hash2);
        LaiblePlanet.text = namePlanet;
    }
    string GetNamePlanet(int Hash)
    {
        string AllNamesPlanetRaw = File.ReadAllText("res/Text/Planets.txt");
      string[] AllNamesPlanetArray = AllNamesPlanetRaw.Split('\n');


        return AllNamesPlanetArray[Hash];
    }
    public void Buttonclick()
    {
        SceneManager.LoadScene(Target);
    }
}
