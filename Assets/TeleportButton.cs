using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    public Transform body;
    public bool UpdateCreature;
    private void Start()
    {
        transform.SetParent(FindAnyObjectByType<TeamParrent>().transform);
    }
    private void Update()
    {
        if (!body && !UpdateCreature)
        {
            Destroy(gameObject);
        }
        if (!body && UpdateCreature)
        {
            body = ObjenieCreatureEtap.curcreature.transform;
            UpdateCreature = false;
        }
    }
    public void Teleport()
    {
        body.position = mover.main().transform.position;
    }
}
