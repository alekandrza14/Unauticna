Shader "Ray Marching/Cube-2"
{
    Properties
    {
        [Header(Main Maps)] [Space]
        _Tint("Albedo", Color) = (1.0, 1.0, 1.0)
        [Gamma] _Metallic("Metallic", Range(0, 1)) = 0.0
        _Smoothness("Smoothness", Range(0, 1)) = 0.5

        [Header(Mandelbulb Parameters)][Space]
        _Iterations("Iterations", Int) = 10
        _Power("Power", Int) = 8
        _EscapeRadius("Escape Radius", Float) = 2.0
        _Scale("Scale", Float) = 0.4
        P1("1", float) = 0
        P2("2", float) = 0
        P3("3", float) = 0
        P4("4", float) = 0
        P5("5", int) = 0

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
        float P1; float P2; float P3; float P4; int P5;
        float _Scale;
        
        float Hash(float2 p)
        {
            float d = dot(p, float2(12.9898f, 78.233f));
            return frac(sin(d) * 43758.5453123f);
        }
        float Noise(float2 p) {
            float2 i = floor(p);
            float2 f = frac(p);
            f = smoothstep(0.0f, 1.0f, f);
            float a = Hash(i + float2(0.0f, 0.0f));
            float b = Hash(i + float2(0.0f, 1.0f));
            float c = Hash(i + float2(1.0f, 0.0f));
            float d = Hash(i + float2(1.0f, 1.0f));

            return lerp(lerp(a, c, f.x), lerp(b, d, f.x), f.y);
        }
        float fbn1(float2 p) {
            float v = 0.0f;
            v += Noise(p * 1) * 0.35f;

            
            return v;
        }

        float SDF(float3 pos)
        {
            float f = 0;
            if (P5 == 0) {


                if (pos.x - P1 > 0 && pos.z - P3 > 0) {


                   
                    f = (pos.y - P2) - fbn1(float2((-pos.x) + P1, (-pos.z) + P3)) * P4;
                }
                if (pos.x - P1 < 0 && pos.z - P3 < 0)
                {
                    f = (pos.y - P2) - fbn1(float2(pos.x - P1, pos.z - P3)) * P4;

                }if (pos.x - P1 > 0 && pos.z - P3 < 0) {

                    f = (pos.y - P2) - fbn1(float2((-pos.x) + P1, pos.z - P3)) * P4;
                }
                if (pos.x - P1 < 0 && pos.z - P3 > 0)
                {

                    f = (pos.y - P2) - fbn1(float2(pos.x - P1, (-pos.z) + P3)) * P4;


                }
            }if (P5 == 1) {


                if (pos.x - P1 > 0 && pos.z - P3 > 0) {

                    f = (pos.y - P2) - fbn1(float2((-pos.x) + P1, pos.z - P3)) * P4;

                }
                if (pos.x - P1 < 0 && pos.z - P3 < 0)
                {
                    
                    f = (pos.y - P2) - fbn1(float2(pos.x - P1, (-pos.z) + P3)) * P4;
                }if (pos.x - P1 > 0 && pos.z - P3 < 0) {


                    
                    f = (pos.y - P2) - fbn1(float2((-pos.x) + P1, (-pos.z) + P3)) * P4;
                }
                if (pos.x - P1 < 0 && pos.z - P3 > 0)
                {


                    
                    

                    f = (pos.y - P2) - fbn1(float2(pos.x - P1, pos.z - P3)) * P4;

                }
            }if (P5 == 2) {


                if (pos.x - P1 > 0 && pos.z - P3 > 0) {

                    f = (pos.y - P2) - fbn1(float2(pos.x - P1, pos.z - P3)) * P4;
                }
                if (pos.x - P1 < 0 && pos.z - P3 < 0)
                {
                    f = (pos.y - P2) - fbn1(float2((-pos.x) + P1, (-pos.z) + P3)) * P4;

                }if (pos.x - P1 > 0 && pos.z - P3 < 0) {

                    f = (pos.y - P2) - fbn1(float2(pos.x - P1, (-pos.z) + P3)) * P4;
                }
                if (pos.x - P1 < 0 && pos.z - P3 > 0)
                {

                    
                    f = (pos.y - P2) - fbn1(float2((-pos.x) + P1, pos.z - P3)) * P4;


                }
            }if (P5 == 3) {


                if (pos.x - P1 > 0 && pos.z - P3 > 0) {


                    f = (pos.y - P2) - fbn1(float2(pos.x - P1, (-pos.z) + P3)) * P4;
                }
                if (pos.x - P1 < 0 && pos.z - P3 < 0)
                {
                    f = (pos.y - P2) - fbn1(float2((-pos.x) + P1, pos.z - P3)) * P4;

                }if (pos.x - P1 > 0 && pos.z - P3 < 0) {

                    f = (pos.y - P2) - fbn1(float2(pos.x - P1, pos.z - P3)) * P4;
                }
                if (pos.x - P1 < 0 && pos.z - P3 > 0)
                {

                    f = (pos.y - P2) - fbn1(float2((-pos.x) + P1, (-pos.z) + P3)) * P4;


                }
            }
            
            if (pos.x - P1 > 40) {
                f = 1;
            }if (pos.x - P1 < -40) {
                f = 1;
            }if (pos.z - P3 > 40) {
                f = 1;
            }if (pos.z - P3 < -40) {
                f = 1;
            }
            /*
            if (pos.x - P1 < 0) {
                f = (pos.y - P2) - fbn1(float2((-pos.x) + P1, 0)) * P4;
            }
            if (pos.x - P1 > 0)
            {
                f = (pos.y - P2) - fbn1(float2(pos.x - P1, 0)) * P4;

            }
            */

            return f;
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

