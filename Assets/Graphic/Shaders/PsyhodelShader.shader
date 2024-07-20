Shader "Custom/randomBlockTexture"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Tex2 ("Albedo (RGB)", 2D) = "white" {}
        _Tex3 ("Albedo (RGB)", 2D) = "white" {}
        _Tex4 ("Albedo (RGB)", 2D) = "white" {}
        _Tex5 ("Albedo (RGB)", 2D) = "white" {}
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
        
        sampler2D _MainTex;
        sampler2D _Tex2;
        sampler2D _Tex3;
        sampler2D _Tex4;
        sampler2D _Tex5;

        struct Input
        {
            float2 uv_MainTex;
            
            float3 worldPos;
        };
                  void Unity_Hue_Radians_float(float3 In, float Offset, out float3 Out)
{
    float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
    float4 P = lerp(float4(In.bg, K.wz), float4(In.gb, K.xy), step(In.b, In.g));
    float4 Q = lerp(float4(P.xyw, In.r), float4(In.r, P.yzx), step(P.x, In.r));
    float D = Q.x - min(Q.w, Q.y);
    float E = 1e-10;
    float3 hsv = float3(abs(Q.z + (Q.w - Q.y)/(6.0 * D + E)), D / (Q.x + E), Q.x);

    float hue = hsv.x + Offset;
    hsv.x = (hue < 0)
            ? hue + 1
            : (hue > 1)
                ? hue - 1
                : hue;

    // HSV to RGB
    float4 K2 = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    float3 P2 = abs(frac(hsv.xxx + K2.xyz) * 6.0 - K2.www);
    Out = hsv.z * lerp(K2.xxx, saturate(P2 - K2.xxx), hsv.y);
}
        half _Glossiness;
        float _hue;
        half _Metallic;
        fixed4 _Color;
         float Hash(float3 p)
        {
            float d = dot(p, float3(12.9898f, 78.233f,88.5756846f));
            return abs(frac(sin(d) * 43758.5453123f));
        }
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 c2 = tex2D (_Tex2, IN.uv_MainTex) * _Color;
            fixed4 c3 = tex2D (_Tex3, IN.uv_MainTex) * _Color;
            fixed4 c4 = tex2D (_Tex4, IN.uv_MainTex) * _Color;
            fixed4 c5 = tex2D (_Tex5, IN.uv_MainTex) * _Color;
            float Noise =Hash(float3( (int)IN.worldPos.x,(int)IN.worldPos.y,(int)IN.worldPos.z));
            Noise *=5;
             float3 fin;
            if((int)Noise == 0)  fin = c.rgb;
            if((int)Noise == 1)  fin = c2.rgb;
            if((int)Noise == 2)  fin = c3.rgb;
            if((int)Noise == 3)  fin = c4.rgb;
            if((int)Noise == 4)  fin = c5.rgb;
            Unity_Hue_Radians_float(fin, _Time.y,fin);
            o.Albedo = fin;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
