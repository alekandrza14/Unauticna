using ObjParser;
using UnityEngine;

public class MoveKaravan : MonoBehaviour
{
    public float speedKaravan;
    void Start()
    {
        speedKaravan = Random.Range(0,15);
        obj = new GameObject("d");
        InvokeRepeating("RaotateKaravan", 0, 20);
    }
    GameObject obj;
    void RaotateKaravan()
    {
        obj.transform.Rotate(0, Random.Range(-360, 360), 0);
    }
    void Update()
    {
      if(obj)  transform.position += (obj.transform.forward * speedKaravan * Time.deltaTime); 
    }
}
