Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex("Texture1D32", 2D) = "white" {}
        _Tex("Texture3D16", 2D) = "white" {}
        _null("null", 2D) = "white" {}
        grad("gadient-1",Range(0,2)) = 1.23
        grad2("gadient-2",Range(0,2)) = 1.3
        center("center",Range(0,1)) = 0.61
        indensity("indensity",Range(0,1)) = 1
        size("size",Range(0,3)) = 1
            x("x",Range(-1,1)) = 0
            y("y",Range(-1,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _Tex;
            sampler2D _null;
            float4 _MainTex_ST;
            float grad;
            float grad2;
            float center;
            float indensity;
            float size;
            float x,y;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(float2((v.uv * size).x + x, (v.uv * size).y + y), _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
            fixed4 texturecolor = tex2D(_Tex, i.uv);
            fixed4 col2 = tex2D(_null, i.uv);
            if (col.b == 1) {
                col = (float4(grad2 -col.g, grad2 - col.g, grad2 - col.g,0)+1)/2;
            }
            else if (col.b == 0&& col.g == 0) {
                col = float4((grad - col.r) / 2, (grad - col.r) / 2, (grad - col.r) / 2, 1)+0.005;
            }
            else if (col.r == 0 && col.b == 0&& col.g == 0) {
                col = float4(0, 0, 0, 1);
            }
            else if (col.g == 1) {
                col = float4(center, center, center, 1);
            }
            else if (col.g == 1 && col.b == 1) {
                col = float4(1, 1, 1, 1);
            }
            else if (col.g == 1 && col.b == 1 && col.r == 1) {
                col = float4(center, center, center, 1);
            }
            if (col2.r == 0) {
                col = float4(0, 0, 0, 0);
                discard;
            }
            col *= (texturecolor+0.5)* indensity;
            col *= 2 - indensity;
            col *= 2 - indensity;
            col *= 2 - indensity;

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
