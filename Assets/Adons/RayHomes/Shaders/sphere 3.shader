Shader "Ray Marching/Sphere 1"
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
        P1("1", float) = 0
        P2("2", float) = 0
        P3("3", float) = 0
        P4("4", float) = 0

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
        float P1; float P2; float P3; float P4;
        float _Scale;
        float Hash(float3 p)
        {
            float d = dot(p, float3(12.9898f, 78.233f,88.5756846f));
            return frac(sin(d) * 43758.5453123f);
        }
        float SDF(float3 pos)
        {
            float f = (length(pos) - 0.2);
            float f2 = length(pos+float3(P1,P2,P3))- 0.2;
           
            f+= cos(pos.y*350)/300;
            f+= cos(pos.x*350)/300;
            f+= cos(pos.z*350)/300;
            
            f += Hash((int)(pos.x*500))/100;
            f += Hash((int)(pos.y*500))/100;
            f += Hash((int)(pos.z*500))/100;

            f2+= cos(pos.y*350)/300;
            f2+= cos(pos.x*350)/300;
            f2+= cos(pos.z*350)/300;
            
            f2 += Hash((int)(pos.x*500))/100;
            f2 += Hash((int)(pos.y*500))/100;
            f2 += Hash((int)(pos.z*500))/100;
          f = max(-f2,f);

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

