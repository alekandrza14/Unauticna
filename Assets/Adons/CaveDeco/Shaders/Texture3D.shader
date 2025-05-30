Shader "Tex3D/StandartSurface"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _BlickIndensity ("BlickIndensity", float) = 1
        _MainTex ("Albedo (RGB)", 3D) = "white" {}
        _BlicsTex ("Blics (RGB)", 3D) = "black" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM


        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
        
        sampler3D _MainTex;
        float _BlickIndensity;
        sampler3D _BlicsTex;

        struct Input
        {              
            float4 vertex : POSITION;         
            float3 worldPos;
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        { 
           
            float3 rayOrigin = IN.worldPos;

            // Albedo comes from a texture tinted by color
            fixed4 c = tex3D(_MainTex, rayOrigin);
            float mirc = ((sin(_Time.y+IN.worldPos.y)+1)/4)*_BlickIndensity;
            o.Albedo = c.rgb+(tex3D(_BlicsTex, rayOrigin)*mirc);
;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
