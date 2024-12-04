using UnityEngine;

public class FractalSpace : MonoBehaviour
{
    public float ScaleOffset = 2;
    GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            other.transform.localScale /= ScaleOffset;
            other.GetComponent<mover>().PlayerCamera.GetComponent<Camera>().farClipPlane /= ScaleOffset;
            other.GetComponent<mover>().PlayerCamera.GetComponent<Camera>().nearClipPlane /= ScaleOffset;
            FindAnyObjectByType<Logic_tag_3>().GetComponent<Camera>().farClipPlane /= ScaleOffset;
            FindAnyObjectByType<Logic_tag_3>().GetComponent<Camera>().nearClipPlane /= ScaleOffset;
            player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            other.transform.localScale *= ScaleOffset;
            other.GetComponent<mover>().PlayerCamera.GetComponent<Camera>().farClipPlane *= ScaleOffset;
            other.GetComponent<mover>().PlayerCamera.GetComponent<Camera>().nearClipPlane *= ScaleOffset;
            FindAnyObjectByType<Logic_tag_3>().GetComponent<Camera>().farClipPlane *= ScaleOffset;
            FindAnyObjectByType<Logic_tag_3>().GetComponent<Camera>().nearClipPlane *= ScaleOffset;
            player = null;
        }
    }
    private void OnDestroy()
    {
        if (player) 
        {
            player.transform.localScale *= ScaleOffset;
            player.GetComponent<mover>().PlayerCamera.GetComponent<Camera>().farClipPlane *= ScaleOffset;
            player.GetComponent<mover>().PlayerCamera.GetComponent<Camera>().nearClipPlane *= ScaleOffset;
            FindAnyObjectByType<Logic_tag_3>().GetComponent<Camera>().farClipPlane *= ScaleOffset;
            FindAnyObjectByType<Logic_tag_3>().GetComponent<Camera>().nearClipPlane *= ScaleOffset;
        }
    }
}
