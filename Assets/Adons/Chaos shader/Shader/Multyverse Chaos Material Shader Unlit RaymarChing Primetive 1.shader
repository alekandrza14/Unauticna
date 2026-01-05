// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unauticna Multiverse Customs/Low UnLit Shaders/Multyverse Chaos Raymarching-Material Shader/Nalojenie"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _MainColor("Color", Color) = (1,1,1,1)
        _WVector("Wpos", int) = 0
        _Depth ("Depth", int) = 0
        _Radius("Wscale", Range(0,.49)) = .49
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
            
        int _Depth;
uniform float4 _MainTex_TexelSize;
uniform float4x4 _CameraInvViewMatrix;
float3 poshit;
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
                float3 hitPos1 : TEXCOORD3;
            };

            sampler2D _MainTex; 
            fixed4 _MainColor;
            float4 _MainTex_ST; 
            float _WVector;
            float _Radius;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.ro = mul(unity_WorldToObject, float4( _WorldSpaceCameraPos,1));
                o.hitPos =  v.vertex;
                o.hitPos1 =  v.vertex;
                
                return o;
            }
            float GetDist(float3 p) {
                float d = length(p)- _Radius;
                d += length(_WVector);
                
                return d;
            }
           
            float Raymarch(float3 ro, float3 rd) {
                float dO = 0;
                float ds;
                for (int i = 0; i < MAX_STEPS;i++) {
                    

                            
                    float3 p = (ro + dO * rd);
                
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
            }float Depth(float3 pos)
{
    float4 clipPos = UnityObjectToClipPos(pos);
    return clipPos.z / clipPos.w;
}
            fixed4 frag(v2f i,out float outDepth : SV_Depth) : SV_Target
            {
                float2 uv = i.uv ;
                float3 ro = i.ro;
                float3 rd = normalize(i.hitPos1-ro); //normalize(float3(uv.x, uv.y, 1));
                
                float d = Raymarch(ro, rd);
                fixed4 col = 0;
                float3 p = ro + rd * d;
                float3 p2 = ro + rd * d;
               
                fixed4 tex = tex2D(_MainTex, float3(p.x+_WVector, p.y+_WVector, 0)+float3(p.z, p.y+_WVector, 0)+float3(p.x+_WVector, p.z+_WVector, 0));
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
                          //  col = dot(col, _WorldSpaceLightPos0.xyz)*2;
                              col = 0.1; 
                       }
                       else
                       {
                             col = 0.1; 
                       }
                    col = lerp(col+fixed4(0,0,0,0), tex, 0.6);
                }
                else discard;if(_Depth == 0) {  outDepth = Depth(p2);}else{
                       outDepth = Depth(float3(0,0,0));
                      }
                return col*_MainColor;
            }
            ENDCG
        }
    }
}
