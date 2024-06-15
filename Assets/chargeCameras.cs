using NUnit;
using UnityEngine;

[System.Serializable]
public class OrtoCameras
{
    public GameObject[] ojs;
}
public enum ModeOrtoCameras
{
    None,first,second,third,fourth,fifth
}

public class chargeCameras : MonoBehaviour
{
    public OrtoCameras[] cameras;
    public void set_camaras(int camMode)
    {
        ModeOrtoCameras camerasMode = (ModeOrtoCameras)camMode;
        if (camerasMode == ModeOrtoCameras.None)
        {
            foreach (OrtoCameras inv in cameras)
            {
                foreach (GameObject item in inv.ojs)
                {
                    item.SetActive(false);
                }
            }
        }
        if (camerasMode == ModeOrtoCameras.first)
        {
            foreach (OrtoCameras inv in cameras)
            {
                foreach (GameObject item in inv.ojs)
                {
                    item.SetActive(false);
                }
            }
            foreach (GameObject item in cameras[0].ojs)
            {
                item.SetActive(true);
            }

        }
        if (camerasMode == ModeOrtoCameras.second)
        {
            foreach (OrtoCameras inv in cameras)
            {
                foreach (GameObject item in inv.ojs)
                {
                    item.SetActive(false);
                }
            }
            foreach (GameObject item in cameras[1].ojs)
            {
                item.SetActive(true);
            }

        }
        if (camerasMode == ModeOrtoCameras.third)
        {
            foreach (OrtoCameras inv in cameras)
            {
                foreach (GameObject item in inv.ojs)
                {
                    item.SetActive(false);
                }
            }
            foreach (GameObject item in cameras[2].ojs)
            {
                item.SetActive(true);
            }

        }
        if (camerasMode == ModeOrtoCameras.fourth)
        {
            foreach (OrtoCameras inv in cameras)
            {
                foreach (GameObject item in inv.ojs)
                {
                    item.SetActive(false);
                }
            }
            foreach (GameObject item in cameras[3].ojs)
            {
                item.SetActive(true);
            }

        }
        if (camerasMode == ModeOrtoCameras.fifth)
        {
            foreach (OrtoCameras inv in cameras)
            {
                foreach (GameObject item in inv.ojs)
                {
                    item.SetActive(false);
                }
            }
            foreach (GameObject item in cameras[4].ojs)
            {
                item.SetActive(true);
            }

        }
        
    }
}
