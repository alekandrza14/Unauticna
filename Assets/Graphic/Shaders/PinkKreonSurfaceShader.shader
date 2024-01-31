Shader "Custom/PinkKreonSurfaceShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _PinkKreon ("PinkKreonAColor", Range(0,1)) = 0
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _ThoTex("Albedo (UVA)", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _cut("cut", Range(-1.5,1)) = 1.0
        _cet("cet", Range(-2,2)) = 1
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 200
            Cull off
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _ThoTex;
        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        float hash = 0.1;
        float _cut;
        float _cet;
        fixed4 _Color;  
        float _PinkKreon;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)
            float random(float2 uv)
        {
            return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453123);
        }
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            hash+=((sin(mul(unity_WorldToObject, float4(_WorldSpaceCameraPos, 1) * _Time.y))/2)+1.25);
            hash += _cet;
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            float uf = tex2D (_ThoTex, IN.uv_MainTex);

          //  c.rgb += float3(0, uf  *(1 + hash), (uf  *(1 + hash)) * 0.5)/2.14;
            c.rgb += uf * _PinkKreon* (1 + hash), (uf * _PinkKreon * (1 + hash))*0.5 / 3.14;
            if(c.r + c.g + c.b > 5)
            {
            c.rgb = float3(1,0.5,1);
            }
           else if(c.r + c.g + c.b < 5)
           {
            c.rgb = float3(0,1,0);
            }
            o.Albedo = c.rgb* _Color;
            // Metallic and smoothness come from slider variables
            //discard;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
            fixed4 cl = c.a;
            cl.a +=  random(IN.uv_MainTex)/2;
            cl.a += _cut;
            if (cl.a<0.5) {
                discard;
            }
        }
        ENDCG
    }
    FallBack "Diffuse"
}
