using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    public Transform body;
    private void Start()
    {
        transform.SetParent(FindAnyObjectByType<TeamParrent>().transform);
    }
    private void Update()
    {
        if (!body)
        {
            Destroy(gameObject);
        }
    }
    public void Teleport()
    {
        body.position = mover.main().transform.position;
    }
}
