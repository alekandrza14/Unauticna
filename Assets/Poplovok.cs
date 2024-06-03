using UnityEngine;

public class Poplovok : MonoBehaviour
{
    GameObject[] RibaPrefab;
    private void Awake()
    {
        RibaPrefab = gameObject.GetComponent<Поплывок>().loadFish;
        GameObject obj = Instantiate(RibaPrefab[Random.Range(0, RibaPrefab.Length)], mover.main().transform.position + (mover.main().PlayerCamera.transform.forward*10),Quaternion.identity);
        obj.GetComponent<Rigidbody>().AddForce(-mover.main().PlayerCamera.transform.forward * 20, ForceMode.Impulse);
        Destroy(gameObject);
    }
}
