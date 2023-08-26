using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planet_and_retranslator : MonoBehaviour
{
    [SerializeField] string Target;
    [SerializeField] float PlanetMin;
    [SerializeField] float PlanetMax;
    [SerializeField] bool _interface;
    void Start()
    {
        Vector2 posPlanet = new Vector2 (-(float)Globalprefs.GetIdPlanet(), (float)Globalprefs.GetIdPlanet()*9);
        float Hash = Globalprefs.Hash(posPlanet);
        Hash = ( Hash + 1)/2;
        Hash *= 30;
       if(!_interface) if (((int)Hash) <= PlanetMin || ((int)Hash) >= PlanetMax)
        {
            Destroy(gameObject);
        }
    }
    public void Buttonclick()
    {
        SceneManager.LoadScene(Target);
    }
}
