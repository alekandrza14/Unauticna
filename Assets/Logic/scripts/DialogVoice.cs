using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogVoice : MonoBehaviour
{
    public Animator ƒилогјнимаци€;
    public AudioSource «вукЌастройка;
    public AudioClip[] –усскиий√олос;
    public AudioClip[] јнгийский√олос;
    public AudioClip[] јнархический√олос;
    public float ¬рем€¬—екундах;
    public bool Ќачатьѕри—тарте;
    public void Start()
    {
        if (Ќачатьѕри—тарте)
        {
            StartCoroutine(Wait(¬рем€¬—екундах));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<fristPersonControler>())
        {
            StartCoroutine(Wait(¬рем€¬—екундах));
        }
    }
    IEnumerator Wait(float sconds)
    {
        yield return new WaitForSeconds(sconds);

        if (File.Exists("язык"))
        {
            if (File.ReadAllText("язык") == "–усский") «вукЌастройка.clip = –усскиий√олос[Random.Range(0, –усскиий√олос.Length)];
            if (File.ReadAllText("язык") == "јнагийский") «вукЌастройка.clip = јнгийский√олос[Random.Range(0, јнгийский√олос.Length)];
            if (File.ReadAllText("язык") == "јнархический") «вукЌастройка.clip = јнархический√олос[Random.Range(0, јнархический√олос.Length)];
        }
        «вукЌастройка.Play();
    }
    private void Update()
    {
      if(ƒилогјнимаци€ != null)  ƒилогјнимаци€.SetBool("IsPlaying", «вукЌастройка.isPlaying);
    }
}
