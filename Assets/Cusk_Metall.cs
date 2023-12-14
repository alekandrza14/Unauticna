using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cusk_Metall : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }

}
