using UnityEngine;

public class modEditor : MonoBehaviour
{
    public static itemName item;
    public static GameObject obj;
    public string mod;
    public void SpawnMod()
    {
        item = FindFirstObjectByType<itemName>();
        obj = item.modSpawn(mod);

    }
    public void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W))
            {
                obj.transform.position += Vector3.forward * 0.01f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                obj.transform.position -= Vector3.forward * 0.01f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                obj.transform.position += Vector3.right * 0.01f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                obj.transform.position -= Vector3.right * 0.01f;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                obj.transform.position += Vector3.up * 0.01f;
            }
            if (Input.GetKey(KeyCode.E))
            {
                obj.transform.position -= Vector3.up * 0.01f;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W))
            {
                obj.transform.position += Vector3.forward * 0.001f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                obj.transform.position -= Vector3.forward * 0.001f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                obj.transform.position += Vector3.right * 0.001f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                obj.transform.position -= Vector3.right * 0.001f;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                obj.transform.position += Vector3.up * 0.01f;
            }
            if (Input.GetKey(KeyCode.E))
            {
                obj.transform.position -= Vector3.up * 0.01f;
            }
        }
        item.modsStats.modposition[item.modsStats.modposition.Count-1] = obj.transform.position;

    }
}
