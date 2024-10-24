using UnityEngine;

public class AVarton : MonoBehaviour
{
    public GameObject spam;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>()) Instantiate(spam, mover.main().transform.position, Quaternion.identity);
        if (other.GetComponent<SocialObject>()) Instantiate(spam, mover.main().transform.position, Quaternion.identity);
        if (other.GetComponent<CharacterName>()) Instantiate(spam, mover.main().transform.position, Quaternion.identity);
    }
}
