using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCube : MonoBehaviour
{
    public float jumpForce = 5f; // Сила прыжка
    public float jumpInterval = 3f; // Интервал между прыжками

    private Rigidbody rb;
    private float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer += Time.deltaTime; // Увеличиваем таймер на время прошедшее с прошлого кадра

        if (timer >= jumpInterval) // Если прошло достаточно времени
        {
            Jump(); // Вызываем метод прыжка
            timer = 0f; // Сбрасываем таймер
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Применяем силу прыжка вверх
    }
}
