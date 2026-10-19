Shader "Unauticna/H3/Model" {
    Properties { _Color("Tint", Color)=(0.65,0.85,1,0.35) }
    CGINCLUDE
    #include "UnityCG.cginc"

        fixed4 _Color;
        struct appdata { float4 vertex:POSITION; float3 normal:NORMAL; };
        struct v2f { float4 pos:SV_POSITION; float3 normal:TEXCOORD0; };
        v2f vert(appdata v) { v2f o;o.pos=UnityObjectToClipPos(v.vertex);o.normal=UnityObjectToWorldNormal(v.normal);return o; }
        fixed4 frag(v2f i):SV_Target {
            float light=.3+.7*saturate(dot(normalize(i.normal),normalize(float3(.4,.8,-.5))));
            return fixed4(_Color.rgb*light,1);
        }
    ENDCG
    SubShader {
        Tags { "Queue"="Geometry" "RenderType"="Opaque" "RenderPipeline"="UniversalPipeline" }
        ZWrite On
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
        Tags { "Queue"="Geometry" "RenderType"="Opaque" }
        ZWrite On
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
