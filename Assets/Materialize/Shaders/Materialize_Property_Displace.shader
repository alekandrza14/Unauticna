Shader "Materialize/Materialize_Property_Displace" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpTex("Normal", 2D) = "bump" {}
		_PropertyTex("Property R-Metallic G-Smoothness B-AO", 2D) = "black" {}
		
		_Glossiness ("Smoothness", Range(0,5)) = 1.0
		_Metallic ("Metallic", Range(0,5)) = 1.0		
		_AOPower ("AO Power", Range(0,5) ) = 1.0
		
		[Toggle(FLIP_NORMAL)] _FlipNormal("Flip Normal Y", Float) = 0
		
		_DisplacementTex("Displacement", 2D) = "grey" {}
		_Parallax ("Height", Range (0.0, 3.0)) = 0.5
		_ParallaxBias ("Height Bias", Range (0.0, 1.0)) = 0.5
		_EdgeLength ("Edge length", Range(3,50)) = 3
	}
	SubShader {
		Pass {
			Name "FORWARD"
			Tags { "LightMode" = "ForwardBase" }

			CGPROGRAM
			// compile directives
			#pragma vertex tessvert_surf
			#pragma fragment frag_surf
			#pragma hull hs_surf
			#pragma domain ds_surf
			#pragma target 5.0
			#pragma shader_feature FLIP_NORMAL
			#pragma multi_compile_fog
			#pragma multi_compile_fwdbase
			#define UNITY_PASS_FORWARDBASE
			#define MATERIALIZE_PROPERTY

			#include "Tessellation.cginc"
			#include "Struct.cginc"
			#include "Vert.cginc"
			#include "Tess.cginc"
			#include "Frag.cginc"
			ENDCG
		}
		
		Pass {
			Name "FORWARD"
			Tags { "LightMode" = "ForwardAdd" }
			ZWrite Off Blend One One

			CGPROGRAM
			// compile directives
			#pragma vertex tessvert_surf
			#pragma fragment frag_surf
			#pragma hull hs_surf
			#pragma domain ds_surf
			#pragma target 5.0
			#pragma shader_feature FLIP_NORMAL
			#pragma multi_compile_fog
			#pragma multi_compile_fwdadd_fullshadows
			#define UNITY_PASS_FORWARDADD
			#define MATERIALIZE_PROPERTY

			#include "Tessellation.cginc"
			#include "Struct.cginc"
			#include "Vert.cginc"
			#include "Tess.cginc"
			#include "Frag.cginc"
			ENDCG
		}
		
		Pass {
			Name "DEFERRED"
			Tags { "LightMode" = "Deferred" }


			CGPROGRAM
			// compile directives
			#pragma vertex tessvert_surf
			#pragma fragment frag_surf
			#pragma hull hs_surf
			#pragma domain ds_surf
			#pragma target 5.0
			#pragma shader_feature FLIP_NORMAL
			#pragma exclude_renderers nomrt
			#pragma multi_compile_prepassfinal
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#define UNITY_PASS_DEFERRED
			#define MATERIALIZE_PROPERTY

			#include "Tessellation.cginc"
			#include "Struct.cginc"
			#include "Vert.cginc"
			#include "Tess.cginc"
			#include "Frag.cginc"
			ENDCG
		}
		
		Pass {
			Name "ShadowCaster"
			Tags { "LightMode" = "ShadowCaster" }
			ZWrite On ZTest LEqual
			
			CGPROGRAM
			// compile directives
			#pragma vertex tessvert_surf
			
			#pragma fragment frag_surf
			#pragma hull hs_surf
			#pragma domain ds_surf
			#pragma target 5.0
			#pragma multi_compile_shadowcaster
			#define UNITY_PASS_SHADOWCASTER
			
			#include "Tessellation.cginc"
			#include "Struct.cginc"
			#include "Vert.cginc"
			#include "Tess.cginc"
			#include "Frag.cginc"
			ENDCG
		}
		
		Pass{
			Name "Meta"
			Tags { "LightMode" = "Meta" }
			Cull Off
		
			
			CGPROGRAM
			// compile directives
			#pragma vertex vert_surf
			#pragma fragment frag_surf
			#pragma target 3.0
			#pragma shader_feature FLIP_NORMAL
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#define UNITY_PASS_META

			#include "Struct.cginc"
			#include "UnityMetaPass.cginc"
			#include "Vert.cginc"
			#include "Frag.cginc"
			ENDCG
		}
		
	}
	FallBack "Materialize/Materialize_Standard"
}
