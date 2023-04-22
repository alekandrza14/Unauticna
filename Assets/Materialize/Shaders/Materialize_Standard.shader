Shader "Materialize/Materialize_Standard" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpTex("Normal", 2D) = "bump" {}
		_MetallicTex("Metallic", 2D) = "black" {}
		_SmoothnessTex("Smoothness", 2D) = "black" {}
		_EdgeTex("Edge", 2D) = "grey" {}
		_AOTex("Ambient Occlusion", 2D) = "white" {}	
		
		_Glossiness ("Smoothness", Range(0,5)) = 1.0
		_Metallic ("Metallic", Range(0,5)) = 1.0		
		_AOPower ("AO Power", Range(0,5) ) = 1.0
		_EdgePower ("Edge Power", Range(0,5) ) = 1.0
		
		[Toggle(FLIP_NORMAL)] _FlipNormal("Flip Normal Y", Float) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows
		
		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0
		
		#pragma shader_feature FLIP_NORMAL

		sampler2D _MainTex;
		sampler2D _NormalTex;
		sampler2D _SmoothnessTex;
		sampler2D _MetallicTex;
		sampler2D _AOTex;
		sampler2D _EdgeTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		half _AOPower;
		half _EdgePower;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 albedoTex = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			float4 normalTex = tex2D (_NormalTex, IN.uv_MainTex);
			float4 metallicTex = tex2D (_MetallicTex, IN.uv_MainTex);
			float4 smoothnessTex = tex2D (_SmoothnessTex, IN.uv_MainTex);
			float4 edgeTex = tex2D (_EdgeTex, IN.uv_MainTex);
			float4 aoTex = tex2D (_AOTex, IN.uv_MainTex);
			
			// flip the normal
			float3 localNormal = UnpackNormal( normalTex );
			#ifdef FLIP_NORMAL
			localNormal.y *= -1;
			#endif
			
			// Apply edge map to AO
			float ao = saturate( aoTex.x * ( edgeTex.x + 0.5 ) );
			
			// Apply edge map tp the diffuse
			albedoTex.xyz = saturate( albedoTex.xyz * ( ( edgeTex - 0.5 ) * _EdgePower + 1 ) );
			
			o.Albedo = albedoTex.rgb;
			o.Normal = localNormal;
			o.Metallic = saturate( metallicTex.x * _Metallic );
			o.Smoothness = saturate( smoothnessTex.x * _Glossiness );
			o.Occlusion = pow( ao, _AOPower );
			o.Alpha = albedoTex.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
