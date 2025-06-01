using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AudioPoliticRightrAutaritarian : MonoBehaviour
{
    public AudioSource voiceSource;
    public AudioClip voiceResource; 
    void Start()
    {
        if (PolitDate.IsVersionE()==politiceconomic.right)
        {
            voiceSource.clip = voiceResource;
            voiceSource.loop = false;
            voiceSource.Play();
        }

        
        
    }
   
}
