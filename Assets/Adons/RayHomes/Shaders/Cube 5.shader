Shader "Ray Marching/Cube_0"
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
        float P1; float P2; float P3; float P4;
        float _Scale;
            float fmod2(float a, float b)
        {
            float c = frac(abs(a / b)) * abs(b);
        
            return c;

        }
        

        
        float SDF(float3 pos)
        {
             float c = 150.5f;
     
     
            
           
         pos.x-= P1;
         pos.y-= P2;
         pos.z-= P3;
         pos.x = fmod2(pos.x+0.5f*c,c)-0.5f*c;
         pos.z = fmod2(pos.z+0.5f*c,c)-0.5f*c;
            float3 q = abs(pos) - P4;
            q -= float3(10,5000000,10);
            return length(max(q, 0)) + min(max(q.x, max(q.y, q.z)), 0);
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

