using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.1f;
    public float timeToChangeDirection = 5f;
    float timer = 5f;
    private Rigidbody rb;
    Vector3 randomDirection;
    public bool up, down, right, left;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        gameObject.transform.position = musave.GetPlayer().position;
                    }
                }
            }
        }
        timer += Time.deltaTime;
        if (timer >= timeToChangeDirection)
        {


            randomDirection = Random.insideUnitSphere;
            randomDirection.Normalize();
            timer = 0;

            transform.rotation = Quaternion.LookRotation(randomDirection);
            if (GameObject.FindAnyObjectByType<PlanetGravity>())
            {
            }
            else
            {
                transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            }
        }
        if (true)
        {


            up = false;
            down = false;
            right = false;
            left = false;
        }
        Ray r7 = new Ray(transform.position + (transform.right * 2), (transform.right * 2) - transform.up);
        Debug.DrawRay(transform.position + (transform.right * 2), (transform.right * 2) + (-transform.up * 80));
        RaycastHit hit7;
        if (Physics.Raycast(r7, out hit7))
        {
            if (hit7.collider != null)
            {
                right = true;
            }
        }
        Ray r2 = new Ray(transform.position + (-transform.right * 2), (-transform.right * 2) - transform.up);
        RaycastHit hit2;
        if (Physics.Raycast(r2, out hit2))
        {
            if (hit2.collider != null)
            {
                left = true;
            }
        }
        Ray r3 = new Ray(transform.position + (transform.forward * 2), (transform.forward * 2) - transform.up);
        RaycastHit hit3;
        if (Physics.Raycast(r3, out hit3))
        {
            if (hit3.collider != null)
            {
                up = true;
            }
        }
        Ray r4 = new Ray(transform.position + (-transform.forward * 2), (-transform.forward * 2) - transform.up);
        RaycastHit hit4;
        if (Physics.Raycast(r4, out hit4))
        {
            if (hit4.collider != null)
            {
                down = true;
            }
        }
        if (!up)
        {
            transform.position -= transform.forward * 5 * Time.deltaTime;
        }
        if (!down)
        {
            transform.position -= -transform.forward * 5 * Time.deltaTime;
        }
        if (!right)
        {
            transform.position -= transform.right * 5 * Time.deltaTime;
        }
        if (!left)
        {
            transform.position -= -transform.right * 5 * Time.deltaTime;
        }
        Vector3 velocity = randomDirection * speed;
        rb.MovePosition(transform.position+ velocity);
        //
    }
}

