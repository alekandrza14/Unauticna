using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class osobenostiHappy : MonoBehaviour
{
    public AnimationCurve Happy;
    public AudioSource AudioSource;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        AudioSource.volume = (1 * Happy.Evaluate(timer))*musik.gameVolume;
    }
}
