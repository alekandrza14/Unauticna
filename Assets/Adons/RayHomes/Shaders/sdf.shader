Shader "Unlit/sdf"
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
        P11("1", float) = 0.0001
        P21("2", float) = 0.0001
        P31("3", float) = 0.0001
        P4("4", float) = 1 
        obj1id("shape", float) = 0
		obj2_P1("1", float) = 0
        obj2_P2("2", float) = 0
        obj2_P3("3", float) = 0
        obj2_P11("1", float) = 0.0001
        obj2_P21("2", float) = 0.0001
        obj2_P31("3", float) = 0.0001
        obj2_P4("4", float) = 1
        obj2id("shape", float) = 0
        appForm("appForm", float) = 0
        appEff("appEff", float) = 1
        obj1_sinXEff (" sinXEff", float) = 0
        obj1_sinYEff (" sinYEff", float) = 0
        obj1_sinZEff (" sinZEff", float) = 0
        obj1_sin3DEff("sin3Eff", float) = 0
		obj2_sinXEff (" sinXEff", float) = 0
        obj2_sinYEff (" sinYEff", float) = 0
        obj2_sinZEff (" sinZEff", float) = 0
        obj2_sin3DEff("sin3Eff", float) = 0
        obj1_sinXEff2 (" sinXEff2", float) =      300000
        obj1_sinYEff2 (" sinYEff2", float) =      300000
        obj1_sinZEff2 (" sinZEff2", float) =      300000
        obj1_sin3DEff2("sin3Eff2", float) =       300000
		obj2_sinXEff2 (" sinXEff2", float) =      300000
        obj2_sinYEff2 (" sinYEff2", float) =      300000
        obj2_sinZEff2 (" sinZEff2", float) =      300000
        obj2_sin3DEff2("sin3Eff2", float) =       300000
		
        [Header(Ray Marching Options)][Space]
        _Tolerance("Tolerance", Float) = 0.001
        [Toggle] _RelativeTolerance("Relative Tolerance", Float) = 1.0
        _MaxDistance("Max. Distance", Float) = 1000.0
        _MaxSteps("Max. Steps", Int) = 100

        [Space]
        [KeywordEnum(Fast, Forward, Centered, Tetrahedron)] _NormalApproxMode("Normal Approx. Mode", Float) = 1.0
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
        float P1;
		float P2;
		float P3;
		float P11;
		float P21;
		float P31;
		float P4;
		float obj2_P1;
		float obj2_P2;
		float obj2_P3;
		float obj2_P11;
		float obj2_P21;
		float obj2_P31;
		float obj2_P4;
		float obj2id;
		float obj1id;
		float appForm;
		float appEff;
        float _Scale;
		float obj1_sinXEff ;
		float obj1_sinYEff ;
		float obj1_sinZEff ;
		float obj1_sin3DEff;
		float obj2_sinXEff ;
		float obj2_sinYEff ;
		float obj2_sinZEff ;
		float obj2_sin3DEff;
		float obj1_sinXEff2 ;
		float obj1_sinYEff2 ;
		float obj1_sinZEff2 ;
		float obj1_sin3DEff2;
		float obj2_sinXEff2 ;
		float obj2_sinYEff2 ;
		float obj2_sinZEff2 ;
		float obj2_sin3DEff2;
		
		
        float Hash(float2 p)
        {
            float d = dot(p, float2(12.9898f, 78.233f));
            return frac(sin(d) * 43758.5453123f);
        }
		float MathPocessing(float3 pos,float map,float id)
		{
		if(id>-0.01&&id<0.99)
		{
		    map -= sin(pos.x*obj1_sinXEff)/obj1_sinXEff2;
		    map -= sin(pos.y*obj1_sinYEff)/obj1_sinYEff2;
		    map -= sin(pos.z*obj1_sinZEff)/obj1_sinZEff2;
		    map -= sin(length(pos)*obj1_sin3DEff)/obj1_sin3DEff2;
		}
		if(id>0.99&&id<1.99)
		{
			map -= sin(pos.x*obj2_sinXEff)/obj2_sinXEff2;
			map -= sin(pos.y*obj2_sinYEff)/obj2_sinYEff2;
		    map -= sin(pos.z*obj2_sinZEff)/obj2_sinZEff2;
		    map -= sin(length(pos)*obj2_sin3DEff)/obj2_sin3DEff2;
		}
		
			return map;
		}
		float curShape(float3 pos,float idShape)
		{
			float shape;
			if(idShape>-0.01&&idShape<0.99) shape = (length(pos) - 0.1);//Elipce
			if(idShape>0.99&&idShape<1.99)
			{
			float3 q = abs(pos) - 0.1;//Cube
			shape = length(max(q, 0.0)) + min(max(q.x, max(q.y, q.z)), 0.0);
			}
			return shape;
		}
		float Apposition(float shape1,float shape2,float shape3,float shape4,float shape5,float idAppForm)
		{
			float shape = 0;
			if(idAppForm>-0.01&&idAppForm<0.99) shape = min(shape1,shape2);
			if(idAppForm>0.99&&idAppForm<1.99) shape = SmoothUnion(shape1,shape2,appEff);
			if(idAppForm>1.99&&idAppForm<2.99) shape = max(-shape1,shape2);
			return shape;
		}
        float SDF(float3 pos)
        {	
			if (length(pos) > 3) {
                return Sphere(pos, 0, 1.5);
            }

            float3 vec1 = pos;
            vec1.x -= P1;
            vec1.y -= P2;
            vec1.z -= P3;
            vec1.x /= P11;
            vec1.y /= P21;
            vec1.z /= P31;
            float f = curShape(vec1,obj1id);
			f = MathPocessing(vec1,f,0);
			f*=  P4;
			float3 vec2 = pos;
			vec2.x -= obj2_P1;
            vec2.y -= obj2_P2;
            vec2.z -= obj2_P3;
            vec2.x /= obj2_P11;
            vec2.y /= obj2_P21;
            vec2.z /= obj2_P31;
            float f2 = curShape(vec2,obj2id);
			f2 = MathPocessing(vec2,f2,1);
			f2*=  obj2_P4;
			
            return Apposition(f,f2,0,0,0,appForm);
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

