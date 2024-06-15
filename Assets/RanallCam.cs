using UnityEngine;

public class RanallCam : MonoBehaviour
{
    private Transform[] allobj;
    private void Update()
    {
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            allobj = FindObjectsByType<Transform>(sortmode.main);

            transform.position = allobj[Random.Range(0, allobj.Length)].position;
            transform.rotation = Random.rotation;
        }
      
    }
}
