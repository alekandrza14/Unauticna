Shader "Tex3D/URPSurface"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _BlickIndensity ("BlickIndensity", Float) = 1
        _MainTex ("Albedo (RGB)", 3D) = "white" {}
        _BlicsTex ("Blics (RGB)", 3D) = "black" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" "RenderPipeline"="UniversalPipeline" }
        LOD 200
        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode"="UniversalForwardOnly" }
            HLSLPROGRAM
            #pragma target 3.5
            #pragma vertex Vert
            #pragma fragment Frag
            #pragma multi_compile_instancing
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile_fragment _ _SHADOWS_SOFT
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
            #pragma multi_compile _ SHADOWS_SHADOWMASK
            #pragma multi_compile _ _FORWARD_PLUS
            #pragma multi_compile _ _CLUSTER_LIGHT_LOOP
            #pragma multi_compile_fog

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            TEXTURE3D(_MainTex); SAMPLER(sampler_MainTex);
            TEXTURE3D(_BlicsTex); SAMPLER(sampler_BlicsTex);
            CBUFFER_START(UnityPerMaterial)
                half4 _Color;
                float _BlickIndensity;
                half _Glossiness;
                half _Metallic;
            CBUFFER_END

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 lightmapUV : TEXCOORD1;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float3 positionWS : TEXCOORD0;
                half3 normalWS : TEXCOORD1;
                half4 fogAndVertexLight : TEXCOORD2;
                DECLARE_LIGHTMAP_OR_SH(lightmapUV, vertexSH, 3);
                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
            };
            Varyings Vert(Attributes input)
            {
                Varyings output = (Varyings)0;
                UNITY_SETUP_INSTANCE_ID(input);
                UNITY_TRANSFER_INSTANCE_ID(input, output);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);
                VertexPositionInputs position = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionCS = position.positionCS;
                output.positionWS = position.positionWS;
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                output.fogAndVertexLight = half4(ComputeFogFactor(position.positionCS.z),
                    VertexLighting(position.positionWS, output.normalWS));
                OUTPUT_LIGHTMAP_UV(input.lightmapUV, unity_LightmapST, output.lightmapUV);
                OUTPUT_SH(output.normalWS, output.vertexSH);
                return output;
            }
            half4 Frag(Varyings input) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(input);
                UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);
                float3 p = input.positionWS;
                float3 offset = float3(sin(p.y), sin(p.x), sin(p.y)) * 0.01;
                half4 baseColor = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, p + offset);
                half3 blinkColor = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, p).rgb;
                float blink = (sin(_Time.y + p.y) + 1.0) * 0.25 * _BlickIndensity;

                InputData lighting = (InputData)0;
                lighting.positionWS = p;
                lighting.normalWS = NormalizeNormalPerPixel(input.normalWS);
                lighting.viewDirectionWS = GetWorldSpaceNormalizeViewDir(p);
                #if defined(_MAIN_LIGHT_SHADOWS_SCREEN)
                    lighting.shadowCoord = ComputeScreenPos(TransformWorldToHClip(p));
                #else
                    lighting.shadowCoord = TransformWorldToShadowCoord(p);
                #endif
                lighting.fogCoord = input.fogAndVertexLight.x;
                lighting.vertexLighting = input.fogAndVertexLight.yzw;
                lighting.bakedGI = SAMPLE_GI(input.lightmapUV, input.vertexSH, lighting.normalWS);
                lighting.normalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(input.positionCS);
                lighting.shadowMask = SAMPLE_SHADOWMASK(input.lightmapUV);

                // Keep the original behavior: _Color is exposed but not applied.
                half3 albedo = baseColor.rgb + blinkColor * blink;
                half4 color = UniversalFragmentPBR(lighting, albedo, _Metallic,
                    half3(0,0,0), _Glossiness, 1.0h, half3(0,0,0), 1.0h);
                color.rgb = MixFog(color.rgb, lighting.fogCoord);
                return color;
            }
            ENDHLSL
        }
        // Opaque support passes; no alpha clipping is used by this shader.
        UsePass "Universal Render Pipeline/Lit/ShadowCaster"
        UsePass "Universal Render Pipeline/Lit/DepthOnly"
        UsePass "Universal Render Pipeline/Lit/DepthNormals"
    }
    FallBack Off
}
