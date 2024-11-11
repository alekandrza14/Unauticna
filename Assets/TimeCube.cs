using System.Collections.Generic;
using UnityEngine;

public class TimeCube : MonoBehaviour
{
    public Rigidbody body;
    public List<Vector3> pos = new();
    public List<Quaternion> rot = new();
    bool reversed;
    
    void Update()
    {
        reversed = Input.GetKey(KeyCode.Q);
        if(!reversed)
        {
            body.isKinematic = false;
            pos.Add(transform.position);
            rot.Add(transform.rotation);
        }
        else
        {
            body.isKinematic = true;
            if (pos.Count>0)
            {


                transform.position = pos[pos.Count - 1];
                pos.Remove(pos[pos.Count - 1]);
                transform.rotation = rot[rot.Count - 1];
                rot.Remove(rot[rot.Count - 1]);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
