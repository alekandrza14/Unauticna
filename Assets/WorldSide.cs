using UnityEngine;

public class WorldSide : MonoBehaviour
{
    public Texture2D sprite;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DetectorAngle>())
        {
            //_EmissionMap
            other.GetComponent<DetectorAngle>().Renderer.material.SetTexture("_MainTex", sprite);
            other.GetComponent<DetectorAngle>().Renderer.material.SetTexture("_EmissionMap", sprite);
        }
    }
}
