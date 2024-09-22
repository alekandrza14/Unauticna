using UnityEngine;

public class SwithGeometry : MonoBehaviour
{
    public GameObject[] PlayerContolers;
    public GameObject[] PlayerPoints;

    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null && Input.GetKeyDown(KeyCode.E)) if (hit.collider.gameObject == gameObject)
            {
                PlayerContolers[0].SetActive(!PlayerContolers[0].activeSelf);
                PlayerContolers[1].SetActive(!PlayerContolers[1].activeSelf);
                PlayerPoints[0].SetActive(!PlayerPoints[0].activeSelf);
                PlayerPoints[1].SetActive(!PlayerPoints[1].activeSelf);
            }
        PlayerPoints[1].transform.position = PlayerContolers[0].transform.position;
        PlayerPoints[0].transform.position = PlayerContolers[1].transform.position;
    }
}
