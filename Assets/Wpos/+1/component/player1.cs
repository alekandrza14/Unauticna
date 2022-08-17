using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player1 : MonoBehaviour
{
    public bool b = false;
    public int speed;
    private void OnCollisionStay(Collision collision)
    {
        b = true;
    }
    private void Update()
    {
        if (transform.position.y <= -100)
        {
            Uxill_Engine.kill();

            SceneManager.LoadScene(0);
        }
        float i = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector4(0, 0, i, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector4(0, 0, -i, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector4(i, 0, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector4(-i, 0, 0, 0));
        }
    }
}
