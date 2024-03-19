using UnityEngine;

public class OctopusController : MonoBehaviour
{
    public float swimForce = 10f; // Сила плавания осьминога
    public float maxSpeed = 5f; // Максимальная скорость движения
    public float maxDepth = -5f; // Максимальная глубина, на которую осьминог может опуститься
    public float ocean = 0f; // Максимальная глубина, на которую осьминог может опуститься
    float timer;
    private Rigidbody rb;
    bool inWater;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetRandomDirection();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<notswiming>())
        {
            rb.useGravity = false;
            inWater = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<notswiming>())
        {

            rb.useGravity = true;
            inWater = false;
        }
        
    }

    void Update()
    {
        // Ограничение по глубине
       
        timer += Time.deltaTime; // Увеличиваем таймер на время прошедшее с прошлого кадра

        if (timer >= 3) // Если прошло достаточно времени
        {
            GetRandomDirection(); timer = 0f;
        }
    }

    void FixedUpdate()
    {
        // Применяем силу плавания
        if (inWater)
        {
            rb.AddForce(transform.forward * swimForce * Time.fixedDeltaTime);

            // Ограничение скорости
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
    }

    void GetRandomDirection()
    {
        // Генерируем случайное направление
        transform.rotation = Random.rotation;
    }
}