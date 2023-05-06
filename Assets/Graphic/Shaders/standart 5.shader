Shader "Custom/standart"
{
    Properties
    {
        _Color ("Color", Color) = (0.7,0,0,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Color2 ("Color2", Color) = (0,0,0,1)
        _MainTex2 ("Albedo (RGB)2", 2D) = "white" {}
        _Color3 ("Color3", Color) = (1,1,1,1)
        _MainTex3 ("Albedo (RGB)3", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.1
        _posX("X",Range(-15,15)) = 0.5
        _posY("Y",Range(-15,15)) = 0.5
        _sX("scaleX",Range(-0,7)) = 2.0
        _sY("scaleY",Range(-0,7)) = 2.0
        _mc("indensity",Range(-0,100)) = 1.0
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
        sampler2D _MainTex2;
        sampler2D _MainTex3;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed4 _Color2;
        fixed4 _Color3;

        float _posX; float _posY;
        float _sX; float _sY; float _mc;
       
        UNITY_INSTANCING_BUFFER_START(Props)

        UNITY_INSTANCING_BUFFER_END(Props)
        
        float random(float2 uv)
        {
                return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453123);
        }

        fixed4 setcolor (float2 i) 
        {
            
            fixed4 col =1;
                
                
            float4 n = tex2D (_MainTex, i) * _Color;
                
            float dx = (i.x - _posX) / 0.4 * _sX;
            float dy = (i.y - _posY) / 0.4 * _sY;
            float a = dx;
            float b = dy;
                
                 for (float z = 0; z < 200; z++) 
                 {
                          
                           

                              
                              float d =  cos(a * a) - cosh(b * b) + dx;
                              b = 2 * (a * b) + dy;
                              a = d;
                              bool H = d > 2; 
                              bool H2 = d < 1; 
                             
                              
                                 if (H)
                                 {
                                    

                                  n = cos(d)+2;
                                // if(n.b >= 2){ n = (tex2D(_MainTex2, i) * _Color2); }
                                  }  

                                 if(n.r != n.r){
                                      n = float4(1, 0, 0, 0);
                                  n = (tex2D(_MainTex3, i) * _Color3); 

                                     }  if(n.r >= 0.8){
                                  n = (tex2D(_MainTex2, i) * _Color2); 

                                     }
                              
                                  
                            
                                
                 
                 }            
                    
                
                col = n;
                // apply fog
                
                
                return col;
        }
        
        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo =  setcolor(IN.uv_MainTex);
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
