Shader "Unauticna/H3/Star" {
    Properties { _Color("Tint", Color)=(0.65,0.85,1,0.35) }
    CGINCLUDE
    #include "UnityCG.cginc"

        struct appdata { float4 vertex:POSITION; float2 uv:TEXCOORD0; fixed4 color:COLOR; };
        struct v2f { float4 pos:SV_POSITION; float2 uv:TEXCOORD0; fixed4 color:COLOR; };
        v2f vert(appdata v) { v2f o; o.pos=UnityObjectToClipPos(v.vertex);o.uv=v.uv;o.color=v.color;return o; }
        fixed4 frag(v2f i):SV_Target {
            float r=length(i.uv*2-1);
            float glow=pow(saturate(1-r),2.5);
            return fixed4(i.color.rgb,i.color.a*glow);
        }
    ENDCG
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "RenderPipeline"="UniversalPipeline" }
        Blend SrcAlpha One
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
        Blend SrcAlpha One
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
