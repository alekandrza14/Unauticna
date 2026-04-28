using UnityEngine;
using System;
public class TimeRealTime : MonoBehaviour
{
    public Animator animator;
    public bool a;
    void Update()
    {
        animator.SetFloat("Blend", (((DateTime.Now.Minute*60) + (DateTime.Now.Second + (DateTime.Now.Millisecond * 0.001f))) /600f)% 1f);
        if (!a) transform.localScale = new Vector3(((int)((DateTime.Now.Minute) / 10) % 2 == 0 ? -1 : 1), 1, ((int)((DateTime.Now.Minute) / 10) % 2 == 0 ? -1 : 1));
        if (a) transform.localScale = new Vector3(1,((int)((DateTime.Now.Minute) / 10) % 2 == 0 ? -1 : 1), ((int)((DateTime.Now.Minute) / 10) % 2 == 0 ? -1 : 1));
    }
}
