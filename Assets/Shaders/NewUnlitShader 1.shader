Shader "Custom/FanShe" {
	Properties{
	_MainTex("Albedo",2D) = "white"{}
	_MainTint("Diffuse Color",Color) = (1,1,1,1)
	_Cubemap("Cubemap",CUBE) = ""{}
	_ReflAmount("Reflection Amount",Range(0.1,1.0)) = 0.5
	}
		SubShader{
		Tags{"RenderType" = "Opaque"}
		LOD 200


		CGPROGRAM
		#pragma surface surf Lambert
		#pragma target 3.0
		struct Input {
		float2 uv_MainTex;
		float3 worldRefl;
		};
		sampler2D _MainTex;
		samplerCUBE _Cubemap;
		fixed4 _MainTint;
		half _ReflAmount;
		void surf(Input IN, inout SurfaceOutput o)
		{
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _MainTint;
		o.Albedo = c.rgb;
		o.Emission = texCUBE(_Cubemap, IN.worldRefl) * _ReflAmount;
		o.Alpha = c.a;
		}
		ENDCG
	}

		FallBack "Diffuse"

}