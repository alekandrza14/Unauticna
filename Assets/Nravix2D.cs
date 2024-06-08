using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Position
{
    public Vector2 position;
}

public class Nravix2D : MonoBehaviour
{
    [SerializeField] Vector2 resolution;
    bool onDrag;
    public void Drag()
    {
        onDrag = true;
    }
    public void Drop()
    {
        onDrag = false;
    }
    // Start is called before the first frame update
    [SerializeField] itemName itemName;
    string energy;
    UI_Position up = new UI_Position();
    private void Start()
    {
        energy = itemName.ItemData;

        if (string.IsNullOrEmpty(energy))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                up.position = transform.position;
                energy = JsonUtility.ToJson(up);
                itemName.ItemData = energy;
            }
        }
        transform.position = JsonUtility.FromJson<UI_Position>(energy).position;
    }
    public void Load1()
    {
        energy = itemName.ItemData;

        if (string.IsNullOrEmpty(energy))
        {
            // time = JsonUtility.ToJson(Random.ColorHSV());
            up.position = transform.position;
            energy = JsonUtility.ToJson(up);
            GetComponent<itemName>().ItemData = energy;

        }
        transform.position = JsonUtility.FromJson<UI_Position>(energy).position;
    }
    public void Button()
    {
        wire0DSphere3D[] w0s3 = FindObjectsByType<wire0DSphere3D>(sortmode.main);
        foreach (wire0DSphere3D wire in w0s3)
        {
            wire.Invoke("Activate", 0.01f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (onDrag)
        {
            up.position = transform.position;
            energy = JsonUtility.ToJson(up);
            itemName.ItemData = energy;
            Vector2 mouse = Input.mousePosition;
            Vector2 orientation = new Vector2(Screen.width , Screen.height);
            Vector2 orientationmouse = new Vector2(mouse.x / Screen.width, mouse.y / Screen.height);
            orientationmouse *= orientation;
            transform.position = orientationmouse;
        }
    }
}
