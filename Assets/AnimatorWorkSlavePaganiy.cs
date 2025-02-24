using UnityEngine;

public class AnimatorWorkSlavePaganiy : MonoBehaviour
{
    public Animator Main;
    public int data;
    public string AnimationInt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Main.SetInteger(AnimationInt, data);
                }
            }
        }
    }
}
