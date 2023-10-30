using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHakerSpawner : MonoBehaviour
{

    [SerializeField] Vector3 offset;
    void Start()
    {
        Instantiate(Resources.Load("events/hakers"));
    }
    private void Update()
    {

        transform.position = mover.main().transform.position + offset;
        transform.rotation = mover.main().PlayerCamera.transform.rotation;
    }
}
