using UnityEngine;

public class RenderCubeMap : MonoBehaviour
{
    public Camera camera;
    public RenderTexture map;
    public RenderTexture tex;
    
    // Update is called once per frame
    void Update()
    {
        camera.stereoSeparation = 0.064f; // Eye separation (IPD) of 64mm.

        camera.RenderToCubemap(map, 63, Camera.MonoOrStereoscopicEye.Right);
        map.ConvertToEquirect(tex, Camera.MonoOrStereoscopicEye.Right);
    }
}
