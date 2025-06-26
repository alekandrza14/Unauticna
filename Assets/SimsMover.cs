using UnityEngine;

public class SimsMover : MonoBehaviour
{
    void Start()
    {
        mover.main().PlayerCamera.SetActive(false);
    }
    private void OnDestroy()
    {
        mover.main().PlayerCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width - 4 < Input.mousePosition.x)
        {
            transform.position += new Vector3(20 * Time.deltaTime, 0, 0);
        }
        if (4 > Input.mousePosition.x)
        {
            transform.position -= new Vector3(20 * Time.deltaTime, 0, 0);
        }
        if (Screen.height - 4 < Input.mousePosition.y)
        {
            transform.position += new Vector3(0, 0, 20 * Time.deltaTime);
        }
        if (4 > Input.mousePosition.y)
        {
            transform.position -= new Vector3(0, 0, 20 * Time.deltaTime);
        }
    }
}
