using UnityEngine;

public class ExitInterface : MonoBehaviour
{
    public GameObject[] childObject;
    public int oldChildCount = int.MaxValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void UpdateChlids()
    {
        childObject = new GameObject[transform.childCount];
        int a = transform.childCount;
        for (int i = 0;i<a;i++)
        {
            childObject[i]= transform.GetChild(i).gameObject;
            oldChildCount = transform.childCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oldChildCount != transform.childCount)
        {
            UpdateChlids();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            foreach (GameObject child in childObject)
            {
                child.SetActive(!child.activeSelf);
            }
        }
    }
}
