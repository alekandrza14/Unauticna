using UnityEngine;

public class FullFeminsaiton : MonoBehaviour
{
    public Animator animator;
    bool w;
    void Update()
    {
        if (Kisy.Hp<0&&!w)
        {
            animator.SetTrigger("2вход");
            w = true;
        }
    }
}
