using UnityEngine;
public enum povidПоплывок
{
    none,klyoet
}
public class Поплывок : MonoBehaviour
{
    public GameObject[] loadFish;
    public povidПоплывок povid;
    public float rIBA;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<notswiming>())
        {
            GetComponent<Rigidbody>().linearVelocity += new Vector3(
                0,
                .5f,
                0);
            if (!Global.Random.determindAll)
            {
                rIBA += Random.Range(0, 0.1f);
            }
            else
            {
                rIBA += 0.1f;
            }
            if (rIBA>=100)
            {
                povid = povidПоплывок.klyoet;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<notswiming>())
        {
            if (povid == povidПоплывок.klyoet)
            {
                GetComponent<Rigidbody>().linearVelocity -= new Vector3(
                   0,
                   2f,
                   0);
                GetComponent<Rigidbody>().linearVelocity *= 5;
            }
            GetComponent<Rigidbody>().linearDamping = 2.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<notswiming>())
        {
            GetComponent<Rigidbody>().linearVelocity /= 2;
            GetComponent<Rigidbody>().linearDamping = 1;
        }
    }
}
