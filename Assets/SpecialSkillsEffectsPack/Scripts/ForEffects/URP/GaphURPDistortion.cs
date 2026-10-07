#if GAPH_URP
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
#if UNITY_6000_0_OR_NEWER
using UnityEngine.Rendering.RenderGraphModule;
#endif

/// <summary>
/// URP renderer for the Distortion Effect shader (the URP counterpart of GrabPass).
/// After transparents, copies the camera color once and draws every "GaphDistortion" pass over it,
/// so overlapping distortion particles and effects behind them render the same as on Built-in.
/// Registers itself automatically; no renderer feature or scene setup needed.
/// </summary>
public static class GaphURPDistortion
{
    static DistortionPass s_Pass;
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
        s_Pass = new DistortionPass();
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
    }

    static void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        var asset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
        if (asset == null)
            return;

        ScriptableRenderer renderer = camera.TryGetComponent(out UniversalAdditionalCameraData cameraData)
            ? cameraData.scriptableRenderer
            : asset.scriptableRenderer;
        if (renderer == null)
            return;

        s_Pass.Setup(context, camera);
        renderer.EnqueuePass(s_Pass);
    }

    sealed class DistortionPass : ScriptableRenderPass
    {
        // How long a camera keeps its forced intermediate texture after distortion leaves the screen.
        const float k_IntermediateHoldSeconds = 2f;

        static readonly ShaderTagId s_ShaderTagId = new ShaderTagId("GaphDistortion");
        static readonly int s_GrabTextureId = Shader.PropertyToID("_GaphGrabTexture");
        static readonly List<RendererList> s_StatusQuery = new List<RendererList>(1);
        static readonly List<Camera> s_ExpiredCameras = new List<Camera>();

        // Cameras that render straight to the back buffer need an intermediate texture to be copied.
        // They get one only while distortion is on screen.
        readonly Dictionary<Camera, float> m_IntermediateCameras = new Dictionary<Camera, float>();

        ScriptableRenderContext m_Context;
        Camera m_ContextCamera;

        public DistortionPass()
        {
            renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
            profilingSampler = new ProfilingSampler("GAPH Distortion");

            // Execute() switches render targets, which is not allowed inside a merged native render pass.
            typeof(ScriptableRenderPass)
                .GetProperty("useNativeRenderPass", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(this, false);
        }

        public void Setup(ScriptableRenderContext context, Camera camera)
        {
            m_Context = context;
            m_ContextCamera = camera;

            float now = Time.realtimeSinceStartup;
            foreach (var pair in m_IntermediateCameras)
            {
                if (pair.Key == null || now - pair.Value > k_IntermediateHoldSeconds)
                    s_ExpiredCameras.Add(pair.Key);
            }
            foreach (Camera expired in s_ExpiredCameras)
                m_IntermediateCameras.Remove(expired);
            s_ExpiredCameras.Clear();

            bool intermediate = m_IntermediateCameras.ContainsKey(camera);
#if UNITY_6000_0_OR_NEWER
            requiresIntermediateTexture = intermediate;
#else
            ConfigureInput(intermediate ? ScriptableRenderPassInput.Color : ScriptableRenderPassInput.None);
#endif
        }

        // False when there is nothing to draw, or the camera target cannot be copied this frame.
        bool PrepareDraw(ScriptableRenderContext context, bool hasContext, CullingResults cullResults, Camera camera,
            bool targetIsBackBuffer, out RendererListParams listParams, out RendererList rendererList)
        {
            var sorting = new SortingSettings(camera) { criteria = SortingCriteria.CommonTransparent };
            var drawing = new DrawingSettings(s_ShaderTagId, sorting);
            var filtering = new FilteringSettings(RenderQueueRange.all);
            listParams = new RendererListParams(cullResults, drawing, filtering);
            rendererList = default;

            if (hasContext)
            {
                rendererList = context.CreateRendererList(ref listParams);
                s_StatusQuery.Add(rendererList);
                context.PrepareRendererListsAsync(s_StatusQuery);
                s_StatusQuery.Clear();
                if (context.QueryRendererListStatus(rendererList) == RendererListStatus.kRendererListEmpty)
                    return false;
            }

            if (targetIsBackBuffer || m_IntermediateCameras.ContainsKey(camera))
                m_IntermediateCameras[camera] = Time.realtimeSinceStartup;

            return !targetIsBackBuffer;
        }

#if !UNITY_6000_3_OR_NEWER || URP_COMPATIBILITY_MODE
#pragma warning disable 618, 672
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var cameraData = renderingData.cameraData;
            RTHandle color = cameraData.renderer.cameraColorTargetHandle;
            RTHandle depth = cameraData.renderer.cameraDepthTargetHandle;
            if (!PrepareDraw(context, true, renderingData.cullResults, cameraData.camera, color.rt == null,
                    out _, out RendererList rendererList))
                return;

            RenderTextureDescriptor desc = cameraData.cameraTargetDescriptor;
            desc.msaaSamples = 1;
            desc.depthBufferBits = 0;
            desc.wrapMode = TextureWrapMode.Clamp;

            CommandBuffer cmd = CommandBufferPool.Get();
            using (new ProfilingScope(cmd, profilingSampler))
            {
                cmd.GetTemporaryRT(s_GrabTextureId, desc, FilterMode.Bilinear);
                Blitter.BlitCameraTexture(cmd, color, GrabTarget);
                CoreUtils.SetRenderTarget(cmd, color, depth);
                cmd.DrawRendererList(rendererList);
                cmd.ReleaseTemporaryRT(s_GrabTextureId);
            }
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
#pragma warning restore 618, 672

        static RTHandle s_GrabTarget;

        static RTHandle GrabTarget
        {
            get
            {
                if (s_GrabTarget == null)
                    s_GrabTarget = RTHandles.Alloc(new RenderTargetIdentifier(s_GrabTextureId, 0, CubemapFace.Unknown, -1));
                return s_GrabTarget;
            }
        }
#endif

#if UNITY_6000_0_OR_NEWER
        sealed class GrabPassData
        {
            public TextureHandle source;
        }

        sealed class DrawPassData
        {
            public RendererListHandle rendererList;
        }

        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            var cameraData = frameData.Get<UniversalCameraData>();
            var renderingData = frameData.Get<UniversalRenderingData>();
            var resourceData = frameData.Get<UniversalResourceData>();

            bool hasContext = m_ContextCamera == cameraData.camera;
            m_ContextCamera = null;
            if (!PrepareDraw(m_Context, hasContext, renderingData.cullResults, cameraData.camera,
                    resourceData.isActiveTargetBackBuffer, out RendererListParams listParams, out _))
                return;

            TextureDesc desc = renderGraph.GetTextureDesc(resourceData.activeColorTexture);
            desc.name = "_GaphGrabTexture";
            desc.msaaSamples = MSAASamples.None;
            desc.bindTextureMS = false;
            desc.clearBuffer = false;
            desc.filterMode = FilterMode.Bilinear;
            desc.wrapMode = TextureWrapMode.Clamp;
            TextureHandle grab = renderGraph.CreateTexture(desc);

            using (var builder = renderGraph.AddRasterRenderPass<GrabPassData>("GAPH Distortion Grab", out var passData, profilingSampler))
            {
                passData.source = resourceData.activeColorTexture;
                builder.UseTexture(passData.source);
                builder.SetRenderAttachment(grab, 0, AccessFlags.WriteAll);
                builder.SetGlobalTextureAfterPass(grab, s_GrabTextureId);
                builder.SetRenderFunc(static (GrabPassData data, RasterGraphContext context) =>
                    Blitter.BlitTexture(context.cmd, data.source, new Vector4(1f, 1f, 0f, 0f), 0f, false));
            }

            using (var builder = renderGraph.AddRasterRenderPass<DrawPassData>("GAPH Distortion", out var passData, profilingSampler))
            {
                passData.rendererList = renderGraph.CreateRendererList(listParams);
                builder.UseRendererList(passData.rendererList);
                builder.UseTexture(grab);
                if (resourceData.cameraDepthTexture.IsValid())
                    builder.UseTexture(resourceData.cameraDepthTexture);
                builder.SetRenderAttachment(resourceData.activeColorTexture, 0);
                builder.SetRenderAttachmentDepth(resourceData.activeDepthTexture, AccessFlags.Read);
                builder.SetRenderFunc(static (DrawPassData data, RasterGraphContext context) =>
                    context.cmd.DrawRendererList(data.rendererList));
            }
        }
#endif
    }
}
#endif
