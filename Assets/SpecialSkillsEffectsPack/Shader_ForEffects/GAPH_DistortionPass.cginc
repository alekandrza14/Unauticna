// GAPH Special Skills Effects Pack - Distortion Effect pass
//  Built-in : fragGrab (GrabPass)
//  URP      : fragGrab (_GaphGrabTexture, copied by GaphURPDistortion.cs)
//  HDRP     : fragDistortionVectors (HDRP distortion buffer)

#ifndef GAPH_DISTORTION_PASS_INCLUDED
#define GAPH_DISTORTION_PASS_INCLUDED

#include "GAPH_EffectsCommon.cginc"

#if defined(IS_SOFT_PARTICLES) && (defined(SOFTPARTICLES_ON) || defined(GAPH_URP) || defined(GAPH_HDRP))
    #define GAPH_SOFT_PARTICLES 1
#endif

struct appdata_t {
    float4 vertex : POSITION;
    float2 texcoord : TEXCOORD0;
    half4 color : COLOR;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct v2f {
    float4 vertex : SV_POSITION;
    float4 screenPos : TEXCOORD0; // xy/w = screen uv, z = reversed-Z clip depth
    float4 uv : TEXCOORD1;        // xy = normal map, zw = mask
    half4 color : COLOR;
    #ifdef GAPH_SOFT_PARTICLES
        float4 projPos : TEXCOORD2;
    #endif
    UNITY_VERTEX_OUTPUT_STEREO
};

half4 _TintColor;

sampler2D _Mask;
sampler2D _NormalMap;
float4 _NormalMap_ST;
float4 _Mask_ST;

float _DistortFactor;
float _SRPDistortScale;
float _InvFade;

#if defined(GAPH_BUILTIN)
    UNITY_DECLARE_SCREENSPACE_TEXTURE(_GrabTexture);
    float4 _GrabTexture_TexelSize;
    #define GAPH_GRAB_TEXTURE _GrabTexture
    #define GAPH_GRAB_TEXEL_SCALE _GrabTexture_TexelSize.xy
#elif defined(GAPH_URP)
    // Same size as the camera target
    UNITY_DECLARE_SCREENSPACE_TEXTURE(_GaphGrabTexture);
    #define GAPH_GRAB_TEXTURE _GaphGrabTexture
    #define GAPH_GRAB_TEXEL_SCALE ((_ScreenParams.zw - 1.0) * _SRPDistortScale)
#endif

v2f vert(appdata_t v)
{
    v2f o;
    UNITY_SETUP_INSTANCE_ID(v);
    UNITY_INITIALIZE_OUTPUT(v2f, o);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

    o.vertex = UnityObjectToClipPos(v.vertex);

    #ifdef GAPH_BUILTIN
        o.screenPos = ComputeGrabScreenPos(o.vertex);
    #else
        o.screenPos = ComputeScreenPos(o.vertex);
    #endif
    o.screenPos.z = GaphReversedClipZ(o.vertex);

    #ifdef GAPH_SOFT_PARTICLES
        o.projPos = ComputeScreenPos(o.vertex);
        COMPUTE_EYEDEPTH(o.projPos.z);
    #endif

    o.uv.xy = TRANSFORM_TEX(v.texcoord, _NormalMap);
    o.uv.zw = TRANSFORM_TEX(v.texcoord, _Mask);
    o.color = v.color;
    return o;
}

// Distortion offset in pixels
inline float2 GaphDistortionPixels(v2f i)
{
    half2 normal = UnpackNormal(tex2D(_NormalMap, i.uv.xy)).rg;
    return normal * (_DistortFactor * 10.0 * i.screenPos.z / i.screenPos.w);
}

inline half GaphDistortionAlpha(v2f i)
{
    half alpha = _TintColor.a * i.color.a * tex2D(_Mask, i.uv.zw).a;
    #ifdef GAPH_SOFT_PARTICLES
        alpha *= GaphSoftParticleFade(_InvFade, i.projPos, i.vertex.xy);
    #endif
    return alpha;
}

#ifdef GAPH_GRAB_TEXTURE
half4 fragGrab(v2f i) : SV_Target
{
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

    // Clamped here because the grab texture's wrap mode depends on the pipeline path.
    float2 uv = saturate(i.screenPos.xy / i.screenPos.w + GaphDistortionPixels(i) * GAPH_GRAB_TEXEL_SCALE);
    half4 res = UNITY_SAMPLE_SCREENSPACE_TEXTURE(GAPH_GRAB_TEXTURE, uv);
    res.a = GaphDistortionAlpha(i);
    return res;
}
#endif

#ifdef GAPH_HDRP
// HDRP distortion buffer: xy = offset in pixels, z = valid flag, w = blur (kept by the blend state)
float4 fragDistortionVectors(v2f i) : SV_Target
{
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

    half alpha = GaphDistortionAlpha(i);
    clip(alpha - 0.001);
    return float4(GaphDistortionPixels(i) * _SRPDistortScale, 1.0, alpha);
}
#endif

#endif // GAPH_DISTORTION_PASS_INCLUDED
