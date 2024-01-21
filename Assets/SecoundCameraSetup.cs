using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[ExecuteAlways]
public class SecoundCameraSetup : InventoryEvent
{
    public Color color;
    public RawImage image;
    public Camera _camera;
    public Camera new_camera;
    public Vector2Int grafic_1;
    RenderTexture grafic_2;
    bool Swich = true;
    public UnityEngine.Experimental.Rendering.GraphicsFormat format;
    public Camera getmain()
    {
        return Camera.main;
    }
    private void Awake()
    {
        grafic_1.x = Screen.width;
        grafic_1.y = Screen.height;
      
    }
    void Start()
    {
        grafic_1.x = Screen.width;
        grafic_1.y = Screen.height;
        

        grafic_2 = RenderTexture.GetTemporary(grafic_1.x, grafic_1.y);

        grafic_2.filterMode = FilterMode.Point;
        _camera = getmain();
        grafic_2.graphicsFormat = format;
        new_camera.targetTexture = grafic_2;
        image.texture = grafic_2;

    }
    private void Update()
    {
        new_camera.fieldOfView = mover.main().PlayerCamera.GetComponent<Camera>().fieldOfView;
        new_camera.fieldOfView += 0.01f;


    }
}
