using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transport4 : MonoBehaviour
{
    public Transform cell;
    public Transform player;
    public float speed = 1f;
    public bool sitplayer;
    public Slider slider;
    public Canvas canvas;

    void Update()
    {
        if (canvas)
        {


            canvas.enabled = sitplayer;
            speed = (slider.value * 40) + 1;

        }
        if (sitplayer)
        {
            Globalprefs.sit_player = player.gameObject;
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            player.position = cell.position;
            player.rotation = cell.rotation;
            if (Input.GetKey(KeyCode.W))
            {


                GetComponent<Rigidbody>().linearVelocity += transform.forward * 20f * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {


                GetComponent<Rigidbody>().linearVelocity += -transform.forward * 20f * speed;
            }
            if (Input.GetKey(KeyCode.Space))
            {


                GetComponent<Rigidbody>().linearVelocity += transform.up * 20f * speed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {


                GetComponent<Rigidbody>().linearVelocity += -transform.up * 20f * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {


                GetComponent<Rigidbody>().linearVelocity += transform.right * 20f * speed;
            }
            if (Input.GetKey(KeyCode.A))
            {

                
                GetComponent<Rigidbody>().linearVelocity += -transform.right * 20f * speed;
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
               
                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 5, 0));

            }
        }
    }
}
