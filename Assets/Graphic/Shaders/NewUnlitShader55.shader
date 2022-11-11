Shader "Unlit/NewUnlitShader55"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _posX("X",Range(-15,15)) = 1.0
        _posY("Y",Range(-15,15)) = 1.0
        _sX("scaleX",Range(-0,3)) = 1.0
        _sY("scaleY",Range(-0,3)) = 1.0
        _mc("indensity",Range(-0,0.1)) = 1.0
    }
    SubShader
    {
        Tags { "Queue" = "AlphaTest" "IgnoreProjector" = "True" "RenderType" = "Cutout" }
        LOD 1000
            ZWrite off
            Cull off
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
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _posX; float _posY;
            float _sX; float _sY; float _mc;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                
                return o;
            }
            float random(float2 uv)
            {
                return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453123);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                
                
                fixed4 col = tex2D(_MainTex, i.uv);
            float4 n = float4(0, 0, 0, 0);
                
            float dx = (i.uv.x - _posX) / 0.4 * _sX;
                      float dy = (i.uv.y - _posY) / 0.4 * _sY;
                      float a = dx;
                      float b = dy;
                      float indencity;
                        for (float z = 0; z < 18; z++) {
                          
                           

                              float d = (a * a) - (b * b) + dx;
                              b = 2 * (a * b) + dy;
                              a = d;
                              bool H = d < 2; 
                             
                              if (d <= -1.5) {




                                  discard;
                              }if (true) {

                                  indencity += 1000 * _mc;



                              }
                                if (H) {
                                    

                                  n = d / d / 2 * d / d + (0.45+indencity);

                                    
                              
                                }
                            
                                
                        }
                    
                
                col *= n;
                // apply fog
                
                
                return col;
            }
            ENDCG
        }
    }
}
