using UnityEngine;

public class GladiatorSpawner : MonoBehaviour
{
    public GameObject[] Gladiators;
    public int Wave;
    public void OnWaveSpawn(int Wave)
    {
        if (Wave == this.Wave) 
        {
            foreach (GameObject item in Gladiators)
            {
                GameObject obj = Instantiate(item, transform.position, Quaternion.identity);
                ArenaManager.main().gadiators.Add(obj); 
            }
        }
    }
}
