Shader "Custom/NewSurfaceShader 2"
{
    Properties
        {
            _Color("Color", Color) = (1, 1, 1, 1)
            _Color2("Color2", Color) = (0, 0, 0, 0)
        _Color3("Color3", Color) = (1, 1, 1, 1)
        _Color4("Color4", Color) = (1, 1, 1, 1)
                _MainTex("Texture", 2D) = "white" {}
            _Cutoff("Alpha Cutoff", Range(0, 1)) = 0.5
                
        }
   SubShader
   {
    Tags { "Queue" = "AlphaTest" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout" }

        Pass
        {
            Tags { "LightMode" = "ForwardBase" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct a2v
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
            };
            
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color; fixed4 _Color2; fixed4 _Color3; fixed4 _Color4;
 // Используется для определения условий оценки, используемых в тесте на прозрачность, когда вызывается функция отсечения
            fixed _Cutoff;

            v2f vert(a2v v)
            {
                v2f o;

                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed3 worldNormal = normalize(i.worldNormal);
                fixed3 worldPos = normalize(i.worldPos);
                fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(worldPos));
 // значение текселя
                fixed4 texColor = tex2D(_MainTex, i.uv) * -1;
                texColor += 1;
 // Принцип
                // if ((texColor.a - _Cutoff) < 0.0) { discard; }
 // Если результат меньше 0, отбрасываем фрагмент
                clip(texColor.a - _Cutoff);
 // отражательная способность
                fixed3 albedo = texColor.rgb * _Color.rgb;
                
 // Окружающий свет
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo;
 // диффузный
                fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, worldLightDir));

                diffuse *= -_Color2 - _Color3 + 1;
                diffuse += _Color4;
                
                return fixed4(ambient + diffuse, 1.0);
                
            }
             ENDCG
        }
 
   }
    FallBack "Diffuse"
}
