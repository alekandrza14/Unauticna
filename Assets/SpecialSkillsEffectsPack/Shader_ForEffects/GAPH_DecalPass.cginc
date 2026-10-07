// GAPH Special Skills Effects Pack - Decal pass
// HDRP renders camera-relative, so it uses _GaphInvViewProjAbs (GaphEffectsPipelineBridge.cs)
// and _InverseTransformMatrix (GaphDecalProjector.cs) instead of the built-in matrices.

#ifndef GAPH_DECAL_PASS_INCLUDED
#define GAPH_DECAL_PASS_INCLUDED

#include "GAPH_EffectsCommon.cginc"

sampler2D _MainTex;
sampler2D _NormalTex;
sampler2D _MaskTex;

float4 _MainTex_ST;
float4 _NormalTex_ST;
float4 _MaskTex_ST;
float _MaskCutOut;

UNITY_INSTANCING_BUFFER_START(data)
    UNITY_DEFINE_INSTANCED_PROP(float4x4, _InverseTransformMatrix)
#define _InverseTransformMatrix_arr data
    UNITY_DEFINE_INSTANCED_PROP(half4, _TintColor)
#define _TintColor_arr data
#ifdef IS_USE_SECOND_COLOR
        UNITY_DEFINE_INSTANCED_PROP(half4, _TintColor2)
    #define _TintColor2_arr data
#endif
    UNITY_DEFINE_INSTANCED_PROP(half, _NormalAnimateSpeed)
#define _NormalAnimateSpeed_arr data
    UNITY_DEFINE_INSTANCED_PROP(half, _TextureAnimateSpeed)
#define _TextureAnimateSpeed_arr data
    UNITY_DEFINE_INSTANCED_PROP(half, _NormalDistortionFactor)
#define _NormalDistortionFactor_arr data
    UNITY_DEFINE_INSTANCED_PROP(half, _ColorFactor)
#define _ColorFactor_arr data
UNITY_INSTANCING_BUFFER_END(data)

struct appdata_t {
    float4 vertex : POSITION;
    half4 color : COLOR;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct v2f {
    float4 vertex : SV_POSITION;
    half4 color : COLOR;
    float4 screenUV : TEXCOORD0;
    #ifndef GAPH_HDRP
        float3 ray : TEXCOORD1;
    #endif
    UNITY_VERTEX_INPUT_INSTANCE_ID
    UNITY_VERTEX_OUTPUT_STEREO
};

v2f vert(appdata_t v)
{
    v2f o;
    UNITY_INITIALIZE_OUTPUT(v2f, o);
    UNITY_SETUP_INSTANCE_ID(v);
    UNITY_TRANSFER_INSTANCE_ID(v, o);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

    o.vertex = UnityObjectToClipPos(v.vertex);
    o.color = v.color;
    o.screenUV = ComputeScreenPos(o.vertex);

    #ifndef GAPH_HDRP
        o.ray = UnityObjectToViewPos(v.vertex) * float3(-1, -1, 1);
    #endif

    return o;
}

half4 frag(v2f i) : SV_Target
{
    UNITY_SETUP_INSTANCE_ID(i);
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

    // Scene position in decal object space
    float3 opos;
    #ifdef GAPH_HDRP
        float rawDepth = GaphSampleRawSceneDepth(i.screenUV, i.vertex.xy);
        // Viewport uv from SV_Position (top-left origin)
        float2 uv01 = i.vertex.xy / _ScreenParams.xy;
        float3 wpos = GaphReconstructAbsoluteWorldPos(uv01, rawDepth);
        opos = mul(UNITY_ACCESS_INSTANCED_PROP(_InverseTransformMatrix_arr, _InverseTransformMatrix), float4(wpos, 1)).xyz;
    #else
        i.ray = i.ray * (_ProjectionParams.z / i.ray.z);
        float depth = Linear01Depth(GaphSampleRawSceneDepth(i.screenUV, i.vertex.xy));
        float3 vpos = i.ray * depth;
        // Equivalent to unity_CameraToWorld, which URP does not set per eye in XR
        float3 wpos = mul(unity_MatrixInvV, float4(vpos.xy, -vpos.z, 1)).xyz;
        opos = mul(unity_WorldToObject, float4(wpos, 1)).xyz;
    #endif

    clip(0.5f - abs(opos));

    float2 baseUV = saturate(opos.xz + 0.5);
    float2 texcoord = baseUV * _MainTex_ST.xy + _MainTex_ST.zw;
    float2 texcoord2 = baseUV * _NormalTex_ST.xy + _NormalTex_ST.zw;
    float2 texcoord3 = baseUV * _MaskTex_ST.xy + _MaskTex_ST.zw;

    #ifdef IS_NORMAL_DISTORTION
    float normalTime = UNITY_ACCESS_INSTANCED_PROP(_NormalAnimateSpeed_arr, _NormalAnimateSpeed);
    half2 distort = UnpackNormal(tex2D(_NormalTex, texcoord2 * 1.0f + (normalTime * _Time.xy / 20))).rg;
    distort += UnpackNormal(tex2D(_NormalTex, texcoord2 * 1.0f - (normalTime * _Time.xy / 20) + float2(0.5f, 0.15f))).rg;
    distort += UnpackNormal(tex2D(_NormalTex, texcoord2 * 0.5f - (normalTime * _Time.xy / 10) + float2(0.15f, 0.5f))).rg;
    distort += UnpackNormal(tex2D(_NormalTex, texcoord2 * 0.5f - (normalTime * _Time.xy / 10) + float2(-0.5f, -0.15f))).rg;
    texcoord.xy += distort.xy * UNITY_ACCESS_INSTANCED_PROP(_NormalDistortionFactor_arr, _NormalDistortionFactor);
    #endif

    #ifdef IS_TEXTURE_ANIMATE
    float texTime = UNITY_ACCESS_INSTANCED_PROP(_TextureAnimateSpeed_arr, _TextureAnimateSpeed);
    half4 tex = tex2D(_MainTex, texcoord.xy - (texTime * _Time.xy / 10));
    tex *= tex2D(_MainTex, texcoord.xy - (texTime * _Time.xy / 10) + float2(0.25f, -0.25f));
    half4 tex2 = tex2D(_MainTex, texcoord.xy + (texTime * _Time.xy / 10));
    tex2 *= tex2D(_MainTex, texcoord.xy + (texTime * _Time.xy / 10) + float2(0.15f, -0.15f));
    tex = (tex + tex2) / 1.5f;
    #else
    half4 tex = tex2D(_MainTex, texcoord);
    #endif

    #ifdef IS_MASK_FADE
    half mask_a = pow( saturate(tex2D(_MaskTex, texcoord3).r - (1-_MaskCutOut)),1.5f);
    #else
    half mask_a = tex.a * _MaskCutOut;
    #endif
    #ifdef IS_USE_SECOND_COLOR
        half4 res = tex * UNITY_ACCESS_INSTANCED_PROP(_TintColor2_arr, _TintColor2) *  UNITY_ACCESS_INSTANCED_PROP(_ColorFactor_arr, _ColorFactor);
        half alpha = res.a * i.color.a * mask_a *  UNITY_ACCESS_INSTANCED_PROP(_ColorFactor_arr, _ColorFactor)  * UNITY_ACCESS_INSTANCED_PROP(_TintColor2_arr, _TintColor2).a;
    #else
        half4 res = tex * UNITY_ACCESS_INSTANCED_PROP(_TintColor_arr, _TintColor) *  UNITY_ACCESS_INSTANCED_PROP(_ColorFactor_arr, _ColorFactor);
        half alpha = res.a * i.color.a * mask_a *  UNITY_ACCESS_INSTANCED_PROP(_ColorFactor_arr, _ColorFactor)  * UNITY_ACCESS_INSTANCED_PROP(_TintColor_arr, _TintColor).a;
    #endif
    res.a = alpha;

    return res;
}

#endif // GAPH_DECAL_PASS_INCLUDED
