Shader "Ray Marching/cube loop21"
{
    Properties
    {
        [Header(Main Maps)] [Space]
        _MainTexture ("Texture",2D) = "white" {}
        _Tint("Albedo", Color) = (1.0, 1.0, 1.0)
        [Gamma] _Metallic("Metallic", Range(0, 1)) = 0.0
        _Smoothness("Smoothness", Range(0, 1)) = 0.5

        [Header(Mandelbulb Parameters)][Space]
        _Iterations("Iterations", Int) = 10
        _Power("Power", Int) = 8
        _EscapeRadius("Escape Radius", Float) = 2.0
        _Scale("Scale", Float) = 0.4
        _ScaleX("ScaleX", Float) = 0.4
        _ScaleY("ScaleY", Float) = 0.4
        _ScaleZ("ScaleZ", Float) = 0.4
        _ScaleX2("ScaleX2", Float) = 0.4
        _ScaleY2("ScaleY2", Float) = 0.4
        _ScaleZ2("ScaleZ2", Float) = 0.4
        _ScaleLoop("ScaleLoop", Float) = 0.4
        _ScaleNoise("ScaleNoise", Float) = 0.4
        P1("1", float) = 0
        P2("2", float) = 0
        P3("3", float) = 0
        P12("13", float) = 0
        P22("23", float) = 0
        P32("33", float) = 0
        P4("4", float) = 0
        P5("5", float) = 0

        Pos1("*", float) = 0
        Pos2("*", float) = 0
        Pos3("*", float) = 0
        Pos4("*", float) = 0
        [Header(Ray Marching Options)][Space]
        _Tolerance("Tolerance", Float) = 0.001
        [Toggle] _RelativeTolerance("Relative Tolerance", Float) = 1.0
        _MaxDistance("Max. Distance", Float) = 1000.0
        _MaxSteps("Max. Steps", Int) = 100

        [Space]
        [KeywordEnum(Fast, Forward, Centered, Tetrahedron)] _NormalApproxMode("Normal Approx. Mode", Float) = 0.0
        _NormalApproxStep("Normal Approx. Step", Float) = 0.001
        [Toggle] _NormalFiltering("Normal Filtering", Float) = 1.0

        [Space]
        [Toggle] _AmbientOcclusion("Ambient Occlusion", Float) = 1.0
        _AmbientOcclusionMultiplier("Ambient Occlusion Multiplier", Float) = 1.0
        _AmbientOcclusionStep("Ambient Occlusion Step", Float) = 0.1
        _AmbientOcclusionSamples("Ambient Occlusion Samples", Int) = 5

        [Space]
        [KeywordEnum(None, Hard, Soft)] _ShadowMode("Shadow Mode", Float) = 0.0
        _SoftShadowFactor("Soft Shadow Factor", Float) = 1.0
    }

        CGINCLUDE
#include "RayMarchingSDF.cginc"

            int _Iterations;
        int _Power;
        float _EscapeRadius;
        float P1; float P2; float P3;
        float P12; float P22; float P32; float P4; float P5;
        float _Scale;
        float _ScaleX2;   float _ScaleY2;   float _ScaleZ2;
        float _ScaleX;   float _ScaleY;   float _ScaleZ; float _ScaleLoop; float _ScaleNoise;
        float Hash(float2 p)
        {
            float d = dot(p, float2(12.9898f, 78.233f));
            return frac(sin(d) * 43758.5453123f);
        }
        float fmod2(float a, float b)
        {
            float c = frac(abs(a / b)) * abs(b);

            return c;

        }
        float SDF(float3 pos)
        {

            float c = _ScaleLoop;
            int sFix = (Hash(float2((int)(pos.x), (int)pos.z))*_ScaleNoise) == 0 ? 2 : 1;
            pos.y -= (Hash(float2((int)(pos.x), (int)pos.z))*_ScaleNoise)+sFix;
            pos.x -= P1;
            pos.y -= P2;
            pos.z -= P3;
            pos.x -= P12;
            pos.y -= P22;
            pos.z -= P32;
            pos.x = fmod2(pos.x + 0.5f * c, c) - 0.5f * c;
            pos.z = fmod2(pos.z + 0.5f * c, c) - 0.5f * c;
            float3 q = abs(pos);
            q -= float3(_ScaleX,_ScaleY,_ScaleZ);
            return min(length(max(q, 0)) + min(max(q.x, max(q.y, q.z)), 0),pos.y+2);
            
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

