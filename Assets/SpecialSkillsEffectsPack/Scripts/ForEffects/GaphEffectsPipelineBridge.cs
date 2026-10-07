using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// Sets _GaphInvViewProjAbs (absolute world inverse view-projection) for every SRP camera.
/// Used by the HDRP decal shader. Registers itself automatically; no scene setup needed.
/// </summary>
public static class GaphEffectsPipelineBridge
{
    static readonly int s_InvViewProjAbsId = Shader.PropertyToID("_GaphInvViewProjAbs");
    static bool s_Hooked;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    static void InitializeOnLoad()
    {
        Hook();
    }

#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoadMethod]
    static void InitializeOnEditorLoad()
    {
        Hook();
    }
#endif

    static void Hook()
    {
        if (s_Hooked)
            return;
        s_Hooked = true;
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
    }

    static void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        Matrix4x4 gpuProj = GL.GetGPUProjectionMatrix(camera.projectionMatrix, true);
        Matrix4x4 viewProj = gpuProj * camera.worldToCameraMatrix;
        Shader.SetGlobalMatrix(s_InvViewProjAbsId, viewProj.inverse);
    }
}
