using UnityEngine;

/// <summary>
/// Passes the world-to-local matrix to the decal shader (_InverseTransformMatrix).
/// Required on HDRP, ignored on Built-in and URP.
/// </summary>
[ExecuteAlways]
[DisallowMultipleComponent]
[RequireComponent(typeof(Renderer))]
public class GaphDecalProjector : MonoBehaviour
{
    static readonly int s_InverseTransformMatrixId = Shader.PropertyToID("_InverseTransformMatrix");

    Renderer m_Renderer;
    MaterialPropertyBlock m_PropertyBlock;

    void OnEnable()
    {
        m_Renderer = GetComponent<Renderer>();
        Apply();
    }

    void LateUpdate()
    {
        // Decals are moved and scaled by animations and scripts.
        Apply();
    }

    void Apply()
    {
        if (m_Renderer == null)
            return;

        if (m_PropertyBlock == null)
            m_PropertyBlock = new MaterialPropertyBlock();

        m_Renderer.GetPropertyBlock(m_PropertyBlock);
        m_PropertyBlock.SetMatrix(s_InverseTransformMatrixId, transform.worldToLocalMatrix);
        m_Renderer.SetPropertyBlock(m_PropertyBlock);
    }
}
