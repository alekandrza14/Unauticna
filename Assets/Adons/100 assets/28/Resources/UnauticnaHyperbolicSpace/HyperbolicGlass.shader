Shader "Unauticna/H3/Glass" {
    Properties { _Color("Tint", Color)=(0.65,0.85,1,0.35) }
    CGINCLUDE
    #include "UnityCG.cginc"

        fixed4 _Color;
        struct appdata { float4 vertex:POSITION; float3 normal:NORMAL; };
        struct v2f { float4 pos:SV_POSITION; float3 normal:TEXCOORD0; float3 world:TEXCOORD1; };
        v2f vert(appdata v) { v2f o;o.pos=UnityObjectToClipPos(v.vertex);o.normal=UnityObjectToWorldNormal(v.normal);o.world=mul(unity_ObjectToWorld,v.vertex).xyz;return o; }
        fixed4 frag(v2f i):SV_Target {
            float3 n=normalize(i.normal),v=normalize(_WorldSpaceCameraPos.xyz-i.world);
            float rim=pow(1-abs(dot(n,v)),3);
            float shine=pow(saturate(dot(reflect(-normalize(float3(.4,.8,.5)),n),v)),64);
            return fixed4(_Color.rgb*(.3+rim*.7)+shine*.8,saturate(.025+rim*_Color.a+shine*.35));
        }
    ENDCG
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "RenderPipeline"="UniversalPipeline" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off
        Pass {
            Tags { "LightMode"="SRPDefaultUnlit" }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
            ENDCG
        }
    }
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off
        Pass {
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
            ENDCG
        }
    }
    Fallback Off
}
