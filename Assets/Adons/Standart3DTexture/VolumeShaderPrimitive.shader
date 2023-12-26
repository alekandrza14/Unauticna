Shader "Unlit/VolumeShaderPrimitive"
{
    Properties
    {
        _MainTex ("Texture", 3D) = "white" {}
        _Alpha ("Alpha", float) = 0.02
        _StepSize ("Step Size", float) = 0.01
    }
    SubShader
    {
    
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        Cull off
        Blend One OneMinusSrcAlpha
        

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            // Maximum amount of raymarching samples
            #define MAX_STEP_COUNT 128

            // Allowed floating point inaccuracy
            #define EPSILON 0.00001f

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 objectVertex : TEXCOORD0;
                float3 vectorToSurface : TEXCOORD1;
                float3 hitPos : TEXCOORD2;
            };
            
            sampler3D _MainTex;
            float4 _MainTex_ST;
            float _Alpha;
            float _StepSize;
            
        int _Depth;
            v2f vert (appdata v)
            {
                v2f o;

                // Vertex in object space this will be the starting point of raymarching
                o.objectVertex = v.vertex;

                // Calculate vector from camera to vertex in world space
                float3 worldVertex = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.vectorToSurface = worldVertex - _WorldSpaceCameraPos;
                
                o.hitPos =  v.vertex;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            float4 BlendUnder(float4 color, float4 newColor)
            {
                color.rgb += (1.0 - color.a) * newColor.a * newColor.rgb;
                color.a += (1.0 - color.a) * newColor.a;
                return color;
            }
            bool i3;
            float Depth(float3 pos)
{
    float4 clipPos = UnityObjectToClipPos(pos);
    float z = clipPos.z;
    float w = clipPos.w;
    return z / w;
}
            fixed4 frag(v2f i,out float outDepth : SV_Depth) : SV_Target
            {
                // Start raymarching at the front surface of the object
                float3 rayOrigin2 = mul(unity_WorldToObject, float4( _WorldSpaceCameraPos,1));
                   float3 rayOrigin = i.objectVertex;
                   float3 trayOrigin = mul(rayOrigin, -rayOrigin2);
                   
               
                // Use vector from camera to object surface to get ray direction
                
                float3 rayDirection = mul(unity_WorldToObject, float4(i.vectorToSurface, 0));
                // Use vector from camera to object surface to get ray direction
                
                float3 rayDirection2 = i.hitPos- rayOrigin;
                 float3 trayDirection = mul(rayDirection, -rayDirection2);

                float4 color = float4(0, 0, 0, 0);
                float3 samplePosition = rayOrigin;
                float3 samplePosition2 = rayOrigin;
                // Raymarch through object space
                for (int i = 0; i < MAX_STEP_COUNT && !i3; i++)
                {
                    // Accumulate color only within unit cube bounds
                    if(max(abs(samplePosition.x), max(abs(samplePosition.y), abs(samplePosition.z))) < 0.5f + EPSILON)
                    {
                        float4 sampledColor = tex3D(_MainTex, samplePosition + float3(0.5f, 0.5f, 0.5f));
                          if( sampledColor.a > 0.01)
                         {
                      
                            outDepth =  Depth(samplePosition);
                             
                         }
                        sampledColor.a *= _Alpha;
                        
                        
                        color = BlendUnder(color, sampledColor);
                        samplePosition -= rayDirection * _StepSize;
                    } 
                  
                }
               
                return color;
            }
            ENDCG
        }
    }
}