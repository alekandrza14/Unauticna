Shader "Ray Marching/torus Loop"
{
    Properties
    {
        [Header(Main Maps)] [Space]
        _MainTexture ("Texture",2D) = "white" {}
        _Tint ("Albedo", Color) = (1.0, 1.0, 1.0)
        [Gamma] _Metallic ("Metallic", Range(0, 1)) = 0.0
        _Smoothness ("Smoothness", Range(0, 1)) = 0.5

        [Header(Ray Marching Options)] [Space]
        _Tolerance ("Tolerance", Float) = 0.001
        [Toggle] _RelativeTolerance ("Relative Tolerance", Float) = 1.0
        _MaxDistance ("Max. Distance", Float) = 1000.0
        _MaxSteps ("Max. Steps", Int) = 100

        [Space]
        [KeywordEnum(Fast, Forward, Centered, Tetrahedron)] _NormalApproxMode ("Normal Approx. Mode", Float) = 0.0
        _NormalApproxStep ("Normal Approx. Step", Float) = 0.001
        [Toggle] _NormalFiltering ("Normal Filtering", Float) = 1.0

        _Heigth("Heigth", float) = 1
        _Length("Length", float) = 1
        [Space]
        [Toggle] _AmbientOcclusion ("Ambient Occlusion", Float) = 1.0
        _AmbientOcclusionMultiplier ("Ambient Occlusion Multiplier", Float) = 1.0
        _AmbientOcclusionStep ("Ambient Occlusion Step", Float) = 0.1
        _AmbientOcclusionSamples ("Ambient Occlusion Samples", Int) = 5

        [Space]
        [KeywordEnum(None, Hard, Soft)] _ShadowMode ("Shadow Mode", Float) = 0.0
        _SoftShadowFactor ("Soft Shadow Factor", Float) = 1.0
    }

    CGINCLUDE
        #include "RayMarchingSDF.cginc"
        
        float P1; float P2; float P3; float P4; float P5;
            float _Heigth;
        float _Length;  
        float fmod2(float a, float b)
        {
            float c = frac(abs(a / b)) * abs(b);

            return c;

        }
        float Hash(float3 p)
        {
            float d = dot(p, float3(12.9898f, 78.233f,2.5756846f));
            return frac(sin(d) * 43758.5453123f);
        }
        float sdTorus(float3 p, float2 t)
        {
            float2 q = float2(length(p.xz) - t.x, p.y);
            return length(q) - t.y;
        }

        float SDF(float3 pos)
        { 
            float c = 250;
            pos.x -= P1;
            pos.y -= P2;
            pos.z -= P3;
            float3 alt = 0;
           alt.x = Hash((int)((pos+float3(2,0,0)+2)/10))*5;
           alt.y = Hash((int)((pos+float3(2,0,0)+5)/10))*5;
           alt.z = Hash((int)((pos+float3(2,0,0)+6)/10))*5;
         //   alt.x += (int)(Hash(pos/10))*10;
         //  alt.y += (int)(Hash(pos)/10)*10;
         //   alt.z += (int)(Hash(pos)/10)*10; 
            pos.x = fmod2(pos.x + 0.5f * c, c) - 0.5f * c;
            pos.y = fmod2(pos.y + 0.5f * c, c) - 0.5f * c;
            pos.z = fmod2(pos.z + 0.5f * c, c) - 0.5f * c;
            pos+=alt;
            float dist = sdTorus(pos, float2(_Heigth, _Length));
            return dist;
        }
    ENDCG

        SubShader
    {
        Tags { "Queue" = "AlphaTest" }

        Pass
        {
            Tags { "LightMode" = "ForwardBase" }
            Cull Front

            CGPROGRAM
            #pragma target 3.0

            #pragma shader_feature_local _RELATIVETOLERANCE_ON
            #pragma shader_feature_local _NORMALFILTERING_ON
            #pragma shader_feature_local _AMBIENTOCCLUSION_ON
            #pragma shader_feature_local _SELFSHADOWS_ON

            #pragma multi_compile_local _NORMALAPPROXMODE_FAST _NORMALAPPROXMODE_FORWARD _NORMALAPPROXMODE_CENTERED _NORMALAPPROXMODE_TETRAHEDRON
            #pragma multi_compile_local _SHADOWMODE_NONE _SHADOWMODE_HARD _SHADOWMODE_SOFT

            #pragma vertex vert
            #pragma fragment fragBase
            #include "RayMarching.cginc"
            ENDCG
        }

        Pass
        {
            Tags { "LightMode" = "ForwardAdd" }
            Cull Front
            ZWrite Off
            Blend One One

            CGPROGRAM
            #pragma target 3.0

            #pragma shader_feature_local _RELATIVETOLERANCE_ON
            #pragma shader_feature_local _NORMALFILTERING_ON
            #pragma shader_feature_local _AMBIENTOCCLUSION_ON
            #pragma shader_feature_local _SELFSHADOWS_ON

            #pragma multi_compile_local _NORMALAPPROXMODE_FAST _NORMALAPPROXMODE_FORWARD _NORMALAPPROXMODE_CENTERED _NORMALAPPROXMODE_TETRAHEDRON
            #pragma multi_compile_local _SHADOWMODE_NONE _SHADOWMODE_HARD _SHADOWMODE_SOFT

            #pragma multi_compile_fwdadd

            #pragma vertex vert
            #pragma fragment fragAdd
            #include "RayMarching.cginc"
            ENDCG
        }

        Pass
        {
            Tags { "LightMode" = "ShadowCaster" }
            Cull Front

            CGPROGRAM
            #pragma target 3.0

            #pragma shader_feature_local _RELATIVETOLERANCE_ON
            #pragma shader_feature_local _NORMALFILTERING_ON
            #pragma shader_feature_local _AMBIENTOCCLUSION_ON
            #pragma shader_feature_local _SELFSHADOWS_ON

            #pragma multi_compile_local _NORMALAPPROXMODE_FAST _NORMALAPPROXMODE_FORWARD _NORMALAPPROXMODE_CENTERED _NORMALAPPROXMODE_TETRAHEDRON
            #pragma multi_compile_local _SHADOWMODE_NONE _SHADOWMODE_HARD _SHADOWMODE_SOFT

            #pragma multi_compile_fwdadd

            #pragma vertex vert
            #pragma fragment fragShadowCaster
            #include "RayMarching.cginc"
            ENDCG
        }
    }
}
