using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogVoice : MonoBehaviour
{
    public Animator �������������;
    public AudioSource �������������;
    public AudioClip[] �������������;
    public AudioClip[] ��������������;
    public AudioClip[] �����������������;
    public float ��������������;
    public bool ���������������;
    public void Start()
    {
        if (���������������)
        {
            StartCoroutine(Wait(��������������));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<fristPersonControler>())
        {
            StartCoroutine(Wait(��������������));
        }
    }
    IEnumerator Wait(float sconds)
    {
        yield return new WaitForSeconds(sconds);

        if (File.Exists("����"))
        {
            if (File.ReadAllText("����") == "�������") �������������.clip = �������������[Random.Range(0, �������������.Length)];
            if (File.ReadAllText("����") == "����������") �������������.clip = ��������������[Random.Range(0, ��������������.Length)];
            if (File.ReadAllText("����") == "������������") �������������.clip = �����������������[Random.Range(0, �����������������.Length)];
        }
        �������������.Play();
    }
    private void Update()
    {
      if(������������� != null)  �������������.SetBool("IsPlaying", �������������.isPlaying);
    }
}
