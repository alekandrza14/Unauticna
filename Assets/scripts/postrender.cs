using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class postrender : MonoBehaviour
{
    public Color color;
    public RawImage image;
    [HideInInspector]
    public Camera _camera;
    public Camera new_camera;
    public Vector2Int grafic_1;
    RenderTexture grafic_2;
    public UnityEngine.Experimental.Rendering.GraphicsFormat format;
    public Camera getmain()
    {
        return Camera.main;
    }
    private void Awake()
    {
        grafic_1.x = VarSave.GetInt("res1");
        grafic_1.y = VarSave.GetInt("res2"); if (VarSave.GetString("postrender_color") != "")
        {


            color = JsonUtility.FromJson<Color>(VarSave.GetString("postrender_color"));
        }
        else
        {
            color = Color.white;
        }
    }
    void Start()
    {
        _camera = getmain();

        grafic_2 = RenderTexture.GetTemporary(grafic_1.x, grafic_1.y);
        grafic_2.filterMode = FilterMode.Point;

        grafic_2.graphicsFormat = format;
        _camera.targetTexture = grafic_2;
        image.texture = grafic_2;
        image.color = color;
        _camera.gameObject.tag = new_camera.gameObject.tag;
        new_camera.gameObject.tag = "MainCamera";

    }
    void Update()
    {
        //1
        image.color = color;
        _camera.targetTexture = grafic_2;
        image.texture = grafic_2;
    }
}
