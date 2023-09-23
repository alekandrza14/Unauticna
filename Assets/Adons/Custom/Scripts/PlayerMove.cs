using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float lerpX;
    public float lerpY;
    public float snap = 25f;
    public float rotationX;
    public float rotationY;
    public float lookAngle = 90f;
    public float sensitivityX = 10f;
    public float sensitivityY = 10f;
    public float speed = 6f;
    public float jumpHeight = 8f;
    public float gravity = 20f;
    
    private CharacterController fpscontroller;
    
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        fpscontroller = GetComponent<CharacterController>();
    }

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetButton("Jump") && fpscontroller.isGrounded)
        {
            moveDirection.y = jumpHeight;
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -lookAngle, lookAngle);
        lerpX = Mathf.Lerp(lerpX, rotationX, snap * Time.deltaTime);
        lerpY = Mathf.Lerp(lerpY, rotationY, snap * Time.deltaTime);

        Camera.main.transform.rotation = Quaternion.Euler(lerpX, lerpY, 0);
        transform.rotation = Quaternion.Euler(0, lerpY, 0);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        fpscontroller.Move(move * speed * Time.deltaTime);
        fpscontroller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}