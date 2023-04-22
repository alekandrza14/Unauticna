Shader "Materialize/Materialize_Property" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpTex("Normal", 2D) = "bump" {}
		_PropertyTex("Property R-Metallic G-Smoothness B-AO", 2D) = "black" {}
		
		_Glossiness ("Smoothness", Range(0,5)) = 1.0
		_Metallic ("Metallic", Range(0,5)) = 1.0		
		_AOPower ("AO Power", Range(0,5) ) = 1.0
		
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
		sampler2D _PropertyTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		half _AOPower;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 albedoTex = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			float4 normalTex = tex2D (_NormalTex, IN.uv_MainTex);
			float4 propertyTex = tex2D (_PropertyTex, IN.uv_MainTex);
			
			// flip the normal
			float3 localNormal = UnpackNormal( normalTex );
			#ifdef FLIP_NORMAL
			localNormal.y *= -1;
			#endif
			
			o.Albedo = albedoTex.rgb;
			o.Normal = localNormal;
			o.Metallic = saturate( propertyTex.x * _Metallic );
			o.Smoothness = saturate( propertyTex.y * _Glossiness );
			o.Occlusion = pow( propertyTex.z, _AOPower );
			o.Alpha = albedoTex.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
