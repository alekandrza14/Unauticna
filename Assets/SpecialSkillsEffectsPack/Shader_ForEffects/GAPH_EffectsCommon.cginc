// GAPH Special Skills Effects Pack - shared code for Built-in / URP / HDRP.
// Each SubShader defines GAPH_URP or GAPH_HDRP; no define means Built-in.
// Does not include SRP package files.

#ifndef GAPH_EFFECTS_COMMON_INCLUDED
#define GAPH_EFFECTS_COMMON_INCLUDED

#include "UnityCG.cginc"

#if !defined(GAPH_URP) && !defined(GAPH_HDRP)
    #define GAPH_BUILTIN 1
#endif

// HDRP screen textures (TEXTURE2D_X).
// Same platform condition as UNITY_TEXTURE2D_X_ARRAY_SUPPORTED in HDRP's TextureXR.hlsl.
#if defined(GAPH_HDRP)
    #if (defined(SHADER_API_D3D11) && !defined(SHADER_API_XBOXONE) && !defined(SHADER_API_GAMECORE)) || defined(SHADER_API_PSSL) || defined(SHADER_API_VULKAN) || defined(SHADER_API_METAL)
        #define GAPH_DECLARE_HDRP_SCREEN_TEXTURE(type, name) Texture2DArray<type> name
        #if defined(UNITY_STEREO_INSTANCING_ENABLED)
            #define GAPH_LOAD_HDRP_SCREEN_TEXTURE(name, pixel) name.Load(int4(int2(pixel), unity_StereoEyeIndex, 0))
        #else
            #define GAPH_LOAD_HDRP_SCREEN_TEXTURE(name, pixel) name.Load(int4(int2(pixel), 0, 0))
        #endif
    #else
        #define GAPH_DECLARE_HDRP_SCREEN_TEXTURE(type, name) Texture2D<type> name
        #define GAPH_LOAD_HDRP_SCREEN_TEXTURE(name, pixel) name.Load(int3(int2(pixel), 0))
    #endif
#endif

// Scene depth
#if defined(GAPH_HDRP)
    GAPH_DECLARE_HDRP_SCREEN_TEXTURE(float, _CameraDepthTexture);

    inline float GaphSampleRawSceneDepth(float4 screenPos, float2 pixelPos)
    {
        return GAPH_LOAD_HDRP_SCREEN_TEXTURE(_CameraDepthTexture, pixelPos).x;
    }
#else
    UNITY_DECLARE_DEPTH_TEXTURE(_CameraDepthTexture);

    inline float GaphSampleRawSceneDepth(float4 screenPos, float2 pixelPos)
    {
        return SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(screenPos));
    }
#endif

inline float GaphSceneEyeDepth(float4 screenPos, float2 pixelPos)
{
    return LinearEyeDepth(GaphSampleRawSceneDepth(screenPos, pixelPos));
}

// projPos: xy/w = screen position, z = eye depth (COMPUTE_EYEDEPTH)
inline half GaphSoftParticleFade(half invFade, float4 projPos, float2 pixelPos)
{
    float sceneZ = GaphSceneEyeDepth(projPos, pixelPos);
    float partZ  = projPos.z;
    return saturate(invFade * (sceneZ - partZ));
}

// Clip depth in reversed-Z form (near = w, far = 0) on every graphics API.
inline float GaphReversedClipZ(float4 clipPos)
{
    #if defined(UNITY_REVERSED_Z)
        return clipPos.z;
    #else
        return 0.5 * (clipPos.w - clipPos.z);
    #endif
}

#if defined(GAPH_HDRP)
    // Set per camera by GaphEffectsPipelineBridge.cs (HDRP renders camera-relative).
    float4x4 _GaphInvViewProjAbs;

    inline float3 GaphReconstructAbsoluteWorldPos(float2 screenUV01, float rawDepth)
    {
        float4 ndc = float4(screenUV01 * 2.0 - 1.0, rawDepth, 1.0);
        #if UNITY_UV_STARTS_AT_TOP
            ndc.y = -ndc.y;
        #endif
        float4 wpos = mul(_GaphInvViewProjAbs, ndc);
        return wpos.xyz / wpos.w;
    }
#endif

#endif // GAPH_EFFECTS_COMMON_INCLUDED
