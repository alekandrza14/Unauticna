using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTerritory : MonoBehaviour
{
    public List<GameObject> Workers = new List<GameObject>();
    public List<GameObject> Directors = new List<GameObject>();
    public List<GameObject> Worckstatoins = new List<GameObject>();
    public List<GameObject> Dupers = new List<GameObject>();
    public List<GameObject> EctroStations = new List<GameObject>();
    public List<GameObject> Programs = new List<GameObject>();
    public List<GameObject> Magia = new List<GameObject>();
    public GameObject TableDirector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<itemName>()._Name == "Duper")
        {
            Dupers.Add(other.gameObject);
        }
        if (other.GetComponent<itemName>()._Name == "script")
        {
            Programs.Add(other.gameObject);
        }
        if (other.GetComponent<itemName>()._Name == "MltiverseMagicStick")
        {
            Magia.Add(other.gameObject);
        }
        if (other.GetComponent<GeneratorEnergy>())
        {
            EctroStations.Add(other.gameObject);
        }
    }
}
