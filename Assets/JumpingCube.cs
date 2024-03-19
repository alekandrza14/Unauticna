using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCube : MonoBehaviour
{
    public float jumpForce = 5f; // ���� ������
    public float jumpInterval = 3f; // �������� ����� ��������

    private Rigidbody rb;
    private float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer += Time.deltaTime; // ����������� ������ �� ����� ��������� � �������� �����

        if (timer >= jumpInterval) // ���� ������ ���������� �������
        {
            Jump(); // �������� ����� ������
            timer = 0f; // ���������� ������
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // ��������� ���� ������ �����
    }
}
