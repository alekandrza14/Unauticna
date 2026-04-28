using UnityEngine;

public class randomObjects : MonoBehaviour
{
    public GameObject[] pos;
    void Start()
    {
        pos[Random.Range(0, pos.Length)].SetActive(true);
    }
}
