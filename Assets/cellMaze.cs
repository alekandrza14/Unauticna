using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellMaze : MonoBehaviour
{
    public GameObject[] walls;
    public void randomSetActive(int seed)
    {
        System.Random random = new System.Random((int)Globalprefs.GetIdPlanet()+seed);
        foreach (var wall in walls)
        {
            wall.SetActive(true);
            wall.SetActive(random.Next(0,3)==1);
        }
    }
}
