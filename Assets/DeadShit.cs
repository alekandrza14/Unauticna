using System.Collections.Generic;
using UnityEngine;

public class DeadShit : MonoBehaviour
{
    public static List<GameObject> obj = new();
    private void Start()
    {
       if(!obj.Contains(gameObject))
        {
            obj.Add(gameObject);
        }
    }
    public static void Spawn(Vector3 pos)
    {
       if(obj.Count<250) obj.Add(Instantiate(Resources.Load<GameObject>("deathparticles"), pos, Quaternion.identity));
        else
        {
           GameObject pref = obj[(int)Global.Random.Range(0, obj.Count)];
            pref.transform.position = pos;
            pref.GetComponent<Rigidbody>().MovePosition(pos);
        }
    }
    private void OnDestroy()
    {
        obj.Remove(gameObject);
    }
}
