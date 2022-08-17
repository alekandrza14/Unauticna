using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transport4 : MonoBehaviour
{
    public Transform cell;
    public Transform player;
    public bool sitplayer;

    void Update()
    {
        if (sitplayer)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.position = cell.position;
            player.rotation = cell.rotation;
            if (Input.GetKey(KeyCode.W))
            {


                GetComponent<Rigidbody>().velocity += transform.forward * 20;
            }
            if (Input.GetKey(KeyCode.S))
            {


                GetComponent<Rigidbody>().velocity += -transform.forward * 20;
            }
            if (Input.GetKey(KeyCode.Space))
            {


                GetComponent<Rigidbody>().velocity += transform.up * 20;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {


                GetComponent<Rigidbody>().velocity += -transform.up * 20;
            }
            if (Input.GetKey(KeyCode.D))
            {


                GetComponent<Rigidbody>().velocity += transform.right * 20;
            }
            if (Input.GetKey(KeyCode.A))
            {

                
                GetComponent<Rigidbody>().velocity += -transform.right * 20;
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
               
                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 5, 0));

            }
        }
    }
}
