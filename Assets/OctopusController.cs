using UnityEngine;

public class OctopusController : MonoBehaviour
{
    public float swimForce = 10f; // ���� �������� ���������
    public float maxSpeed = 5f; // ������������ �������� ��������
    public float maxDepth = -5f; // ������������ �������, �� ������� �������� ����� ����������
    public float ocean = 0f; // ������������ �������, �� ������� �������� ����� ����������
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
        // ����������� �� �������
       
        timer += Time.deltaTime; // ����������� ������ �� ����� ��������� � �������� �����

        if (timer >= 3) // ���� ������ ���������� �������
        {
            GetRandomDirection(); timer = 0f;
        }
    }

    void FixedUpdate()
    {
        // ��������� ���� ��������
        if (inWater)
        {
            rb.AddForce(transform.forward * swimForce * Time.fixedDeltaTime);

            // ����������� ��������
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }

    void GetRandomDirection()
    {
        // ���������� ��������� �����������
        transform.rotation = Random.rotation;
    }
}