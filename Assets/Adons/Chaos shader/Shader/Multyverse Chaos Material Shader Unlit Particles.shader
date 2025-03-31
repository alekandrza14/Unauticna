Shader "Unauticna Multiverse Customs/Low UnLit Shaders/Multyverse Chaos Material Shader/Particles"
{
    Properties
    {
        [Header(Base Settings)]
        _MainTex("Texture", 2D) = "white" {}
        _MainColor("Baze Color", Color) = (1,1,1,1)
        _LightColor("Lumin Color", Color) = (0,0,0,0)
        _BrightColor("Up Lumin Color", Color) = (0,0,0,0)
        _MainNoiseScale("Noise Scale", float) = 4
        _MainNoisePower("Noise Power", Range(-1,3)) = 0
        _Ambient("Ambient", Range(-0,1.5)) = 1.3
        _Metalic("Shine", Range(-0,1)) = 0

        [Header(Other Settings)]
        _UltraViolet ("Shine Indensity", Range(0,10)) = 0
        _ThoTex("Shine", 2D) = "white" {}
        _ThoColor("Shine Color", Color) = (1,1,1,1)
        _cet("cet", Range(-2,2)) = 1
    }

        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100
            Cull off
            Pass
            {
                 CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                 // make fog work
                 #pragma multi_compile_fog

                 #include "UnityCG.cginc" 
                 #include "UnityLightingCommon.cginc" 
                 fixed4 _MainColor;
                 fixed4 _ThoColor;   
                 float _cet;
                         float hash = 0.1; 
                         float _UltraViolet;
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };     float random(float2 uv)
        {
            return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453123);
        }
            float Hash(float2 p)
            {
                float d = dot(p, float2(12.9898f, 78.233f));
                return frac(sin(d) * 43758.5453123f);
            }
            float Noise(float2 p) {
                float2 i = floor(p);
                float2 f = frac(p);
                f = smoothstep(0.0f, 1.0f, f);
                float a = Hash(i + float2(0.0f, 0.0f));
                float b = Hash(i + float2(0.0f, 1.0f));
                float c = Hash(i + float2(1.0f, 0.0f));
                float d = Hash(i + float2(1.0f, 1.0f));

                return lerp(lerp(a, c, f.x), lerp(b, d, f.x), f.y);
            }
            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                fixed4 diffuse : COLOR0;
            };
            float _posX; float _posY;
            float _sX; float _sY; int _mc;
            float _Metalic;
            float _Ambient;
            float _MainNoisePower;
            float _MainNoiseScale;
            sampler2D _MainTex;
            sampler2D _ThoTex;
            float4 _MainTex_ST;
            fixed4 _LightColor;
            fixed4 _BrightColor;
          
           
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                half3 worldNormal = UnityObjectToWorldNormal(v.normal);
                half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                o.diffuse = nl * _LightColor0;
                
                if (o.diffuse.r + o.diffuse.g + o.diffuse.b + o.diffuse.a < _Ambient) o.diffuse = float4((_Ambient/3)*_LightColor0.r, (_Ambient / 3) * _LightColor0.g, (_Ambient / 3) * _LightColor0.b, 0)-.1;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
            fixed4 col1 = tex2D(_MainTex, i.uv);
           
               UNITY_APPLY_FOG(i.fogCoord, col);
               
               col -= Noise(i.uv * _MainNoiseScale) * _MainNoisePower;
               col -= Noise(i.uv * _MainNoiseScale * 2) * _MainNoisePower;
               col -= Noise(i.uv * _MainNoiseScale * 7) * _MainNoisePower;

               col -= Noise(i.uv * _MainNoiseScale * 8) * _MainNoisePower;

               col -= Noise(i.uv * _MainNoiseScale * 16) * _MainNoisePower;
              if(_LightColor.r + _LightColor.g + _LightColor.b <= 1.8) col *= (i.diffuse);
             
               col1.a -= random(i.uv)- _MainColor.a;
               if (col1.a < 1) {
                   discard;
               }
               float m = random(i.uv) / _Metalic;
               if (m < 0 + _Metalic) {
                   col += (i.diffuse / m)*10;
               }
               fixed4 c = (col * _MainColor.rgba ) + (_LightColor);
               if ((_BrightColor.r + _BrightColor.b + _BrightColor.g) != 0) { if ((_LightColor.r + _LightColor.b + _LightColor.g) > 0.5)  c *= _BrightColor * 10; }
             
             hash+=((random(mul(unity_WorldToObject, float4(_WorldSpaceCameraPos, 1) * _Time.y))/2)+1.25);
            hash += _cet;
            // Albedo comes from a texture tinted by color
            fixed4 c4 = float4(0,0,0,0);
            float uf = tex2D (_ThoTex, i.uv);
            hash -= c4.r/2.5;
            hash -= c4.g *2;
            hash -= c4.b * 1.2;
            c4.rgb += (float3(uf  *(1 + hash), uf  *(1 + hash), (uf  *(1 + hash)) * 0.5)/2.14)*_ThoColor;
            c4.rgb += (float3(uf * _UltraViolet* (1 + hash),uf * _UltraViolet* (1 + hash), (uf * _UltraViolet * (1 + hash))*0.5) / 3.14)*_ThoColor;
               return (c+c4);
            }
        ENDCG
    }
    }
}