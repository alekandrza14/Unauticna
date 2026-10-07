// GAPH Special Skills Effects Pack - Integrated Effect pass
// UVs are float: scrolling UVs lose precision in half over time on mobile.

#ifndef GAPH_INTEGRATED_EFFECT_PASS_INCLUDED
#define GAPH_INTEGRATED_EFFECT_PASS_INCLUDED

#include "GAPH_EffectsCommon.cginc"

// Built-in uses SOFTPARTICLES_ON (Quality Settings), URP/HDRP only the material toggle.
#if defined(IS_SOFT_PARTICLES) && (defined(SOFTPARTICLES_ON) || defined(GAPH_URP) || defined(GAPH_HDRP))
    #define GAPH_SOFT_PARTICLES 1
#endif

sampler2D _MainTex;
float4 _MainTex_ST;

#ifdef IS_TEXTURE_ANIMATE_ADVANCED
            int _MaxIndex;
#endif

#ifdef IS_NORMAL_DISTORTION
            sampler2D _NormalTex;
            float4 _NormalTex_ST;
            half _NormalDistortionFactor;
#endif

#ifdef IS_TEXTURE_NOISE
            sampler2D _NoiseNormal;
            float4 _NoiseNormal_ST;
            half _NoiseNormalFactor;
#endif

#ifdef IS_MASK_FADE
            sampler2D _FixedMaskTex;
            float4 _FixedMaskTex_ST;
            sampler2D _MaskTex;
            float4 _MaskTex_ST;
            half _MaskOffsetFactor;
            sampler2D _MaskDistortion;
            float4 _MaskDistortion_ST;
#endif
half _MaskCutOut;

#ifdef IS_ALL_TEXTURE_STRAIGHT_MOVE
            half _TexPosMove;
#endif

#ifdef IS_VERTEXANIMATION
            sampler2D _NoiseTex;
            float4 _NoiseTex_ST;
            half _NoiseScale;
#endif

#ifdef IS_RIMLIGHT
            half _RimScale;
            half _RimStrength;
#endif

#ifdef IS_IMPACT
            half _ImpactSize;
            half _ImpactFactor;
            float4 _Points[30];
#endif

#ifdef IS_TEXCOORD_MOVE
            half _xTexcoordMove;
            half _yTexcoordMove;
            half _TexcoordMoveStrength;
#endif

#ifdef IS_LINEPASS
            sampler2D _LinePassTex;
            float4 _LinePassTex_ST;
            half _TexLength;
#endif

#ifdef IS_USE_ROTATE_UV
            half _RotateAngle;
#endif

UNITY_INSTANCING_BUFFER_START(data)
    UNITY_DEFINE_INSTANCED_PROP(half4, _TintColor)
#define _TintColor_arr data
#ifdef IS_USE_SECOND_COLOR
        UNITY_DEFINE_INSTANCED_PROP(half4, _TintColor2)
    #define _TintColor2_arr data
#endif
        UNITY_DEFINE_INSTANCED_PROP(half, _ColorFactor)
    #define _ColorFactor_arr data
#ifdef IS_RIMLIGHT
        UNITY_DEFINE_INSTANCED_PROP(half4, _RimColor)
    #define _RimColor_arr data
#endif
#ifdef IS_VERTEXANIMATION
        UNITY_DEFINE_INSTANCED_PROP(half4, _NoiseValue)
    #define _NoiseValue_arr data
#endif
#ifdef IS_TEXTURE_ANIMATE
        UNITY_DEFINE_INSTANCED_PROP(half, _TextureAnimateSpeed)
    #define _TextureAnimateSpeed_arr data
        UNITY_DEFINE_INSTANCED_PROP(int, _TextureAnimateStyle)
    #define _TextureAnimateStyle_arr data
#endif
#ifdef IS_NORMAL_ANIMATE
        UNITY_DEFINE_INSTANCED_PROP(half, _NormalAnimateSpeed)
    #define _NormalAnimateSpeed_arr data
#endif
#ifdef IS_MASK_FADE
        UNITY_DEFINE_INSTANCED_PROP(half, _MaskAnimatedSpeed)
    #define _MaskAnimatedSpeed_arr data
#endif
UNITY_INSTANCING_BUFFER_END(data)

half _InvFade;

struct appdata_t {
    float4 vertex : POSITION;
    float3 normal : NORMAL;
    half4 color : COLOR;
    #ifdef IS_TEXTURE_BLEND
        float4 texcoord : TEXCOORD0;
        float texcoordBlend : TEXCOORD1;
    #else
        float4 texcoord : TEXCOORD0;
        #ifdef IS_TEXCOORD_MOVE_USING_CUSTOM
        float2 texcoord2 : TEXCOORD1;
        #endif
    #endif
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct v2f {
    float4 vertex : SV_POSITION;
    half4 color : COLOR;
    float2 maintex : TEXCOORD0;
    #ifdef IS_TEXTURE_BLEND
        float3 maintexBlend : TEXCOORD1;
    #endif
    #ifdef IS_NORMAL_DISTORTION
        float2 normaltex : TEXCOORD2;
    #endif
    #ifdef IS_MASK_FADE
        float2 fixedmasktex : TEXCOORD3;
        float2 masktex : TEXCOORD4;
        float2 masknormaltex: TEXCOORD5;
    #endif
    #ifdef IS_TEXTURE_NOISE
        float2 noisetex : TEXCOORD6;
    #endif
    #ifdef GAPH_SOFT_PARTICLES
        float4 projPos : TEXCOORD7;
    #endif
    UNITY_FOG_COORDS(8)
    #ifdef IS_RIMLIGHT
        half3 viewDir : TEXCOORD9;
        half3 normal : TEXCOORD10;
    #endif
    #ifdef IS_IMPACT
        float3 worldPos : TEXCOORD11;
    #endif
    #ifdef IS_LINEPASS
        float2 linepasscoord : TEXCOORD12;
    #endif

    UNITY_VERTEX_INPUT_INSTANCE_ID
    UNITY_VERTEX_OUTPUT_STEREO
};

v2f vert (appdata_t i)
{
    v2f o;
    UNITY_SETUP_INSTANCE_ID(i);
    UNITY_INITIALIZE_OUTPUT(v2f, o);
    UNITY_TRANSFER_INSTANCE_ID(i, o);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

    #ifdef IS_VERTEXANIMATION
    float4 Noise = mul(UNITY_MATRIX_M, i.vertex) * UNITY_ACCESS_INSTANCED_PROP(_NoiseValue_arr, _NoiseValue) * float4(0.1f, 0.1f, 1.5f, 1);
    //Set noiseTex with normal tex using time & scale info. time is for animate vertex
    float4 NoiseTex = tex2Dlod(_NoiseTex, Noise + float4(float3(_Time.x / 2, _Time.y / 2, _Time.z * 2) * _NoiseScale * 10, 0));
    i.vertex = i.vertex * UNITY_ACCESS_INSTANCED_PROP(_NoiseValue_arr, _NoiseValue).w +
        //Add changed noise info with normal value to original object vertex.
        (saturate(NoiseTex) - 0.5f) * (
            //Additionally trigonometric value to original object vertex.
            sin((i.vertex.x + _Time * UNITY_ACCESS_INSTANCED_PROP(_NoiseValue_arr, _NoiseValue).x)* UNITY_ACCESS_INSTANCED_PROP(_NoiseValue_arr, _NoiseValue).y) +
            cos((i.vertex.y + _Time * UNITY_ACCESS_INSTANCED_PROP(_NoiseValue_arr, _NoiseValue).x)* UNITY_ACCESS_INSTANCED_PROP(_NoiseValue_arr, _NoiseValue).y) +
            sin((i.vertex.z + _Time * UNITY_ACCESS_INSTANCED_PROP(_NoiseValue_arr, _NoiseValue).x)* UNITY_ACCESS_INSTANCED_PROP(_NoiseValue_arr, _NoiseValue).y)
            )* UNITY_ACCESS_INSTANCED_PROP(_NoiseValue_arr, _NoiseValue).z*_NoiseScale * 10;
    #endif

    o.vertex = UnityObjectToClipPos(i.vertex);

    float4 originaltex = i.texcoord;

    #ifdef IS_TEXCOORD_MOVE
            #ifdef IS_TEXCOORD_MOVE_USING_CUSTOM
                i.texcoord.y += i.texcoord2.y;
            #else
                i.texcoord.x += _Time.x * _xTexcoordMove * _TexcoordMoveStrength;
                i.texcoord.y += _Time.x * _yTexcoordMove * _TexcoordMoveStrength;
            #endif
    #endif

    #ifdef IS_TEXTURE_BLEND
        o.maintex = i.texcoord.xy;
        o.maintexBlend.xy = i.texcoord.zw;
        o.maintexBlend.z = i.texcoordBlend;
    #else
        o.maintex = TRANSFORM_TEX(i.texcoord, _MainTex);
    #endif

    #ifdef IS_NORMAL_DISTORTION
        o.normaltex = TRANSFORM_TEX(i.texcoord, _NormalTex);
    #endif
    #ifdef IS_MASK_FADE
        float4 masktexcoord;
        #ifdef IS_USE_TEXANIMATION
            masktexcoord = i.texcoord;
        #else
            masktexcoord = originaltex;
        #endif
        o.fixedmasktex = TRANSFORM_TEX(masktexcoord, _FixedMaskTex);
        o.masktex = TRANSFORM_TEX(masktexcoord, _MaskTex);
        o.masknormaltex = TRANSFORM_TEX(masktexcoord, _MaskDistortion);
    #endif
    #ifdef IS_TEXTURE_NOISE
        o.noisetex = TRANSFORM_TEX(i.texcoord, _NoiseNormal);
    #endif

    #ifdef GAPH_SOFT_PARTICLES
        o.projPos = ComputeScreenPos(o.vertex);
        // Same as COMPUTE_EYEDEPTH (input is "i" here)
        o.projPos.z = -UnityObjectToViewPos(i.vertex).z;
    #endif

    #ifdef IS_RIMLIGHT
            o.viewDir = WorldSpaceViewDir(i.vertex);
            o.normal = UnityObjectToWorldNormal(i.vertex.xyz);
    #endif

    #ifdef IS_IMPACT
            o.worldPos = i.vertex.xyz;
    #endif

    #ifdef IS_LINEPASS
            float4 originaltexcoord = i.texcoord;
            float lineLength = lerp(1.0f, 3.0f, i.texcoord.z);
            i.texcoord.x *= lineLength;

            float lineOffset = i.texcoord.w * _TexLength * 2;
            lineOffset = lerp(1, 0, lineOffset);

            i.texcoord.x -= lineOffset;

            i.texcoord.x = clamp(i.texcoord.x, 0, 1);
            i.texcoord.y = clamp(i.texcoord.y, 0, 1);

            o.linepasscoord = TRANSFORM_TEX(i.texcoord, _LinePassTex);
            i.texcoord = originaltexcoord;
    #endif

    #ifdef IS_USE_ROTATE_UV
            float2 center = float2(0.5, 0.5);
            float cosA = cos(_RotateAngle);
            float sinA = sin(_RotateAngle);
            float2x2 rt = float2x2(cosA, -sinA, sinA, cosA);

            //main_tex uv
            float2 uv = o.maintex - center;
            o.maintex = mul(rt, uv);
            o.maintex += uv;
    #endif

    o.color = i.color;

    UNITY_TRANSFER_FOG(o, o.vertex);
    return o;
}

half4 frag(v2f i): SV_Target
{
    UNITY_SETUP_INSTANCE_ID(i);
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

    #ifdef GAPH_SOFT_PARTICLES
        i.color.a *= GaphSoftParticleFade(_InvFade, i.projPos, i.vertex.xy);
    #endif

    #ifdef IS_TEXTURE_NOISE
        half2 noiseTex = tex2D(_NoiseNormal, i.noisetex).rg;
        half2 offset = (noiseTex * 2 - 1) * _NoiseNormalFactor;
        i.maintex.xy += offset;
    #endif

    #ifdef IS_NORMAL_DISTORTION
        #ifdef IS_NORMAL_ANIMATE
            float normalTime = float(UNITY_ACCESS_INSTANCED_PROP(_NormalAnimateSpeed_arr, _NormalAnimateSpeed));
            //Mixed Distort Move
            #ifdef IS_ALL_TEXTURE_STRAIGHT_MOVE
                half2 distort = UnpackNormal(tex2D(_NormalTex, i.normaltex +(normalTime * _Time.xy / 10)*_TexPosMove)).rg;
                distort *= UnpackNormal(tex2D(_NormalTex, i.normaltex +((normalTime*_Time.xy / 10) + float2(0.5f, 0.15f))*_TexPosMove)).rg;
                distort *= UnpackNormal(tex2D(_NormalTex, i.normaltex +((normalTime*_Time.xy / 10) + float2(0.15f, 0.5f))*_TexPosMove)).rg;
            #else
                half2 distort = UnpackNormal(tex2D(_NormalTex, i.normaltex - (normalTime * _Time.xy / 10))).rg;
                distort *= UnpackNormal(tex2D(_NormalTex, i.normaltex + (normalTime*_Time.xy / 10) - float2(-0.25f, -0.15f))).rg;
            #endif
        #else
            half2 distort = UnpackNormal(tex2D(_NormalTex, i.normaltex)).rg;
        #endif
        #ifdef IS_TEXTURE_BLEND
        i.maintex.xy += distort.xy* _NormalDistortionFactor;
        i.maintexBlend.xy += distort.xy* _NormalDistortionFactor;
        #else
        i.maintex.xy += distort.xy* _NormalDistortionFactor;
        #endif
    #endif

    #ifdef IS_TEXTURE_ANIMATE
        float texTime = float(UNITY_ACCESS_INSTANCED_PROP(_TextureAnimateSpeed_arr, _TextureAnimateSpeed));
        #ifdef IS_ALL_TEXTURE_STRAIGHT_MOVE
            half4 tex = tex2D(_MainTex, i.maintex.xy + (texTime * _Time.xy / 10)*_TexPosMove);
            tex *= tex2D(_MainTex, i.maintex.xy + ((texTime * _Time.xy / 10) + float2(0.25f, -0.25f))*_TexPosMove);
            tex = (tex) / 1.5f;
        #else
            #ifdef IS_TEXTURE_ANIMATE_ADVANCED
                half4 tex = half4(1, 1, 1, 1);
                half reversefactor = -1;

                for (uint j = 1; j < uint(_MaxIndex); j++) {
                    half movefactor = (half)(j / uint(_MaxIndex));
                    half timefactor;

                    reversefactor *= -1;
                    timefactor = (_Time.x + movefactor) *reversefactor;
                    tex *= tex2D(_MainTex, i.maintex + movefactor + texTime * float2(timefactor, 0) );
                    tex *= tex2D(_MainTex, i.maintex + movefactor + texTime * float2(0, timefactor));
                }
                tex = saturate(pow(tex, 1.0f/_MaxIndex));
            #else
                half4 tex = half4(0, 0, 0, 0);
                if (UNITY_ACCESS_INSTANCED_PROP(_TextureAnimateStyle_arr, _TextureAnimateStyle) == 0)
                {
                    tex = tex2D(_MainTex, i.maintex.xy - (texTime * _Time.xy / 10));
                    tex *= tex2D(_MainTex, i.maintex.xy - (texTime * _Time.xy / 10) + float2(0.25f, -0.25f));
                    half4 tex2 = tex2D(_MainTex, i.maintex.xy + (texTime * _Time.xy / 10));
                    tex2 *= tex2D(_MainTex, i.maintex.xy + (texTime * _Time.xy / 10) + float2(0.15f, -0.15f));
                    tex = (tex + tex2) / 1.5f;
                }
                else if (UNITY_ACCESS_INSTANCED_PROP(_TextureAnimateStyle_arr, _TextureAnimateStyle) == 1)
                {
                    tex = tex2D(_MainTex, i.maintex.xy - (texTime * _Time.xy / 10));
                    tex *= tex2D(_MainTex, i.maintex.xy - (texTime * _Time.xy / 10) + float2(-0.25f, -0.25f));
                    half4 tex2 = tex2D(_MainTex, i.maintex.xy + (texTime * _Time.xy / 10));
                    tex2 *= tex2D(_MainTex, i.maintex.xy + (texTime * _Time.xy / 10) + float2(0.15f, -0.15f));
                    tex *= tex2 * 3.5f;
                }
                else
                {
                    tex = tex2D(_MainTex, i.maintex.xy - (texTime * _Time.xy / 10) + float2(0.25f, -0.25f));
                    half4 tex2 = tex2D(_MainTex, i.maintex.xy + (texTime * _Time.xy / 10) + float2(0.15f, -0.15f));
                    tex = (tex * tex2)*1.25f + (tex + tex2)*0.5f;
                }
            #endif
        #endif
    #else
        half4 tex = tex2D(_MainTex, i.maintex);
        #ifdef IS_TEXTURE_BLEND
            half4 tex2 = tex2D(_MainTex, i.maintexBlend.xy);
            tex = lerp(tex, tex2, i.maintexBlend.z);
        #endif
    #endif

    #ifdef IS_MASK_FADE
            float maskTime = float(UNITY_ACCESS_INSTANCED_PROP(_MaskAnimatedSpeed_arr, _MaskAnimatedSpeed));
            half fixed_mask = tex2D(_FixedMaskTex, i.fixedmasktex).r;
            #ifdef IS_ALL_TEXTURE_STRAIGHT_MOVE
                half2 mask_noise = tex2D(_MaskDistortion, i.masknormaltex.xy + ((maskTime * _Time.xy / 5) + float2(0.25f, 0.25f))*_TexPosMove).rg;
                mask_noise *= tex2D(_MaskDistortion, i.masknormaltex.xy + ((maskTime * _Time.xy / 4) - float2(0.25f, 0.25f))*_TexPosMove).rg;
                mask_noise *= tex2D(_MaskDistortion, i.masknormaltex.xy + ((maskTime * _Time.xy / 20) - float2(0.25f, 0.25f))*_TexPosMove).rg;
                half2 mask_offset = mask_noise * _MaskOffsetFactor;
            #else
                half2 mask_noise = tex2D(_MaskDistortion, i.masknormaltex.xy - (maskTime * _Time.xy / 10) + float2(0.25f, 0.25f)).rg;
                mask_noise *= tex2D(_MaskDistortion, i.masknormaltex.xy + (maskTime * _Time.xy / 10) - float2(0.5f, 0.5f)).rg;
                half2 mask_offset = mask_noise * _MaskOffsetFactor;
            #endif
            i.masktex.xy += mask_offset;
            #ifdef IS_USE_SECOND_COLOR
                half mask_a = saturate(tex2D(_MaskTex, i.masktex).r - (1- saturate(i.color.a*_MaskCutOut))) * fixed_mask * (float(UNITY_ACCESS_INSTANCED_PROP(_TintColor2_arr, _TintColor2).a));
            #else
                half mask_a = saturate(tex2D(_MaskTex, i.masktex).r - (1 - saturate(i.color.a*_MaskCutOut))) * fixed_mask * (float(UNITY_ACCESS_INSTANCED_PROP(_TintColor_arr, _TintColor).a));
            #endif
    #else
        #ifdef IS_USE_SECOND_COLOR
            half mask_a = tex.a *_MaskCutOut * i.color.a * float(UNITY_ACCESS_INSTANCED_PROP(_TintColor2_arr, _TintColor2).a);
        #else
            half mask_a = tex.a *_MaskCutOut * i.color.a * float(UNITY_ACCESS_INSTANCED_PROP(_TintColor_arr, _TintColor).a);
        #endif
    #endif

    #ifdef IS_USE_SECOND_COLOR
        half4 res = tex * float4(i.color.rgb, 1) * float4(UNITY_ACCESS_INSTANCED_PROP(_TintColor2_arr, _TintColor2).rgb, 1) * float(UNITY_ACCESS_INSTANCED_PROP(_ColorFactor_arr, _ColorFactor));
    #else
        half4 res = tex * float4(i.color.rgb,1) * float4(UNITY_ACCESS_INSTANCED_PROP(_TintColor_arr, _TintColor).rgb,1) * float(UNITY_ACCESS_INSTANCED_PROP(_ColorFactor_arr, _ColorFactor));
    #endif
    half alpha = mask_a *  float(UNITY_ACCESS_INSTANCED_PROP(_ColorFactor_arr, _ColorFactor));
    res.a = saturate(alpha * alpha);

    #ifdef IS_RIMLIGHT
        half rim = 1.0 - saturate(dot(normalize(i.viewDir), i.normal));
        res.rgb += float3(UNITY_ACCESS_INSTANCED_PROP(_RimColor_arr, _RimColor).rgb * pow(rim, _RimScale) * _RimStrength);
    #endif

    #ifdef IS_IMPACT
        float3 objPos = i.worldPos;
        float Impact_alpha = 0.0f;
        for (uint index = 0; index < 30; ++index)
        {
            float Impact = pow(saturate(frac(1.0 - saturate((_Points[index].w*_ImpactSize) - distance(_Points[index].xyz, objPos.xyz))))*saturate(1.0 - _Points[index].w),2);
            Impact_alpha += Impact * _ImpactFactor;
            Impact_alpha = pow(Impact_alpha, 1.1f);
        }

        res.a += Impact_alpha * 5.0f;
    #endif

    #ifdef IS_LINEPASS
        half4 linepasstex = tex2D(_LinePassTex, i.linepasscoord.xy);
        return res *= linepasstex;
    #endif
    UNITY_APPLY_FOG_COLOR(i.fogCoord, res, half4(0, 0, 0, 0));
    return res;
}

#endif // GAPH_INTEGRATED_EFFECT_PASS_INCLUDED
