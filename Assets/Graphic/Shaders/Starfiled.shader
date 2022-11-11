Shader "Unlit/Starfiled"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Iterations("itr",Range(0,20)) = 16
        _Confitient("conf",Range(0,1)) = 0.53
        _VolumeSteps("vl",Range(0,20)) = 20
        _StepSize("ss", Range(0, 0.3)) = 0.1
        _Zoom("z", Range(0, 10)) = 0.8
        _DirectionX("dx", Range(-10, 10)) = 0
        _DirectionY("dz", Range(-10, 10)) = 0
        _Speed("seed", Range(-10, 10)) = 0
        
        _Brightness("Brig", Range(0, 0.03)) = 0.1
        _DistFading("fad", Range(0, 1)) = 0.73

    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
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
            float4 _MainTex_ST;
            
            float _Iterations;
            float _Confitient;
            float   _VolumeSteps;
            float  _StepSize;
            float  _Zoom;

            float _Brightness;
            float _DistFading;
            float  _DirectionX;
            float  _DirectionY;
            float  _Speed;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            float3 colorByDistance(float distance) {
                return float3(distance,0, distance*distance * distance * distance * distance
                    * distance * distance );
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                float3 pos = float3(i.uv / _Zoom ,1);
                float3 color = 0;
                float3 fade = 1;
                float time = _Time.y * _Speed;
                float3 dir = float3(time*_DirectionX,time*_DirectionY,0);
                 float distance = 0.1;
                 for (int s = 0; s < _VolumeSteps; s++)
                 {
                     float3 p = pos * distance + dir;
                     float a, prew_a = 0;


                     for (int i2 = 0; i2 < _Iterations; i2++) {


                         p = abs(p) / dot(p, p) - _Confitient;
                         a += abs(length(p) - prew_a);
                         prew_a = length(p);
                     }
                     a = pow(a, 3);
                     color += colorByDistance(distance) * a * _Brightness * fade;
                     distance += _StepSize;
                     fade *= _DistFading;
                 }
                color *= 0.001;
                return float4(color,1);
            }
            ENDCG
        }
    }
}
