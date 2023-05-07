Shader "Unauticna Multiverse Customs/Low UnLit Shaders/Multyverse Chaos Raymarching-Material Shader/World"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _MainColor("Color", Color) =(1,1,1,1)
        MAX_STEPS ("MAX_STEPS", int) = 100
        MAX_DIST ("MAX_DIST", int) = 100
        SURF_DIST  ("SURF_DIST", float) = 0.001
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }
ZWrite off
            Cull off
        LOD 100

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            int  MAX_STEPS ;
            int  MAX_DIST ;
            float SURF_DIST ;
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 ro : TEXCOORD1;
                float3 hitPos : TEXCOORD2;
            };

            sampler2D _MainTex; 
            fixed4 _MainColor;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.ro = mul(unity_WorldToObject, float4( _WorldSpaceCameraPos,1));
                o.hitPos =  v.vertex;
                return o;
            }

            float GetDist(float3 p) {
                p.y += 0.5;
                float p2 = -p.z;
             p.x+=1000;
                float c = 0.5f;
                p.x = fmod(p.x+0.5f*c,c)-0.5f*c;
               
              p.z += 0.5;
                 
                p.z = -fmod(p.z+0.5f*c,c)-0.5f*c;

            
            return max( min(length(p )- 0.125,p.y+0.125),(-p2));
               
            }
            float Raymarch(float3 ro, float3 rd) {
                float dO = 0;
                float ds;
                for (int i = 0; i < MAX_STEPS;i++) {
                    float3 p = ro + dO * rd;
                    ds = GetDist(p);
                    dO += ds;
                    if (ds<SURF_DIST || dO> MAX_DIST) break;
                }
                return dO;
            }
            float3 GetNormal(float3 p) {
                float2 e = float2(1e-2, 0);
                float3 n = GetDist(p) - float3(
                    GetDist(p - e.xyy),
                    GetDist(p - e.yxy),
                    GetDist(p - e.yyx)

                    );
                return normalize(n);
            }
            fixed4 frag(v2f i) : SV_Target
            {
               
                float2 uv = i.uv ;
                float3 ro = i.ro;
                float3 rd = normalize(i.hitPos-ro); //normalize(float3(uv.x, uv.y, 1));
                
                float d = Raymarch(ro, rd);
                fixed4 col = 0;
                float3 p = ro + rd * d;
                fixed4 tex = tex2D(_MainTex, float3(p.x, p.y, 0)+float3(p.z, p.y, 0)+float3(p.x, p.z, 0));
                float m = dot(uv,uv);
                tex *= _MainColor;
                if (d < MAX_DIST) {

                    float3 n = GetNormal(p);
                    col.rgb = n;
                }
                else discard;
                
                if (tex.a != 0) {

                    if(dot(col, _WorldSpaceLightPos0.xyz)*2 > 0.1)
                       {
                            col = dot(col, _WorldSpaceLightPos0.xyz)*2;
                       }
                       else
                       {
                            col = 0.1;
                       }
                    col = lerp(col, tex, 0.6);
                }
                else discard;
                if(p.y > -.6)
                {
                    col*=fixed4(1,0,0,0);
                    }else{
                        col*=_MainColor;
                        }
                return col;
            }
            ENDCG
        }
    }
}
