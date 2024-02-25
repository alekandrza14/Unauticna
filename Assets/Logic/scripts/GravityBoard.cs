using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityBoard : MonoBehaviour
{
    public Transform cell;
    public Transform player;
    public float speed = 1f;
    public bool sitplayer;
    public Slider slider;
    public Canvas canvas;
    public HyperbolicCamera camera;
    private void Start()
    {
        camera = HyperbolicCamera.Main();
    }

    void LateUpdate()
    {
        
            canvas.enabled = sitplayer;
            speed = (slider.value * 20) + 1;
        
        if (sitplayer)
        {
            Globalprefs.sit_player = player.gameObject;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
          if(!camera)  player.position = cell.position;
            else player.position = new Vector3(0, cell.position.y,0);
            if (camera) cell.position = new Vector3(0, cell.position.y, 0);
            if (GetComponent<HyperbolicPoint>())
            {
                GetComponent<HyperbolicPoint>().HyperboilcPoistion = camera.RealtimeTransform.copy().inverse();
            }
            if (!camera) player.rotation = cell.rotation;
            if (Input.GetKey(KeyCode.W))
            {


                GetComponent<Rigidbody>().velocity += transform.forward * 20f*speed;
            }
            if (Input.GetKey(KeyCode.S))
            {


                GetComponent<Rigidbody>().velocity += -transform.forward * 20f * speed;
            }
            if (Input.GetKey(KeyCode.Space))
            {


                GetComponent<Rigidbody>().velocity += transform.up * 20f * speed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {


                GetComponent<Rigidbody>().velocity += -transform.up * 20f * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {


                GetComponent<Rigidbody>().velocity += transform.right * 20f * speed;
            }
            if (Input.GetKey(KeyCode.A))
            {


                GetComponent<Rigidbody>().velocity += -transform.right * 20f * speed;
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {

                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 5, 0));

            }
        }
    }
}
