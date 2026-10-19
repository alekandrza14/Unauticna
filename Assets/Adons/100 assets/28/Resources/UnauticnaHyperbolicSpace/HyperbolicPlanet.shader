Shader "Unauticna/H2/Planet" {
    Properties { _Color("Tint",Color)=(1,1,1,1) }
    CGINCLUDE
    #include "UnityCG.cginc"
    fixed4 _Color;
    struct appdata {float4 vertex:POSITION;fixed4 color:COLOR;};
    struct v2f {float4 pos:SV_POSITION;fixed4 color:COLOR;UNITY_FOG_COORDS(0)};
    v2f vert(appdata v){v2f o;o.pos=UnityObjectToClipPos(v.vertex);o.color=v.color*_Color;UNITY_TRANSFER_FOG(o,o.pos);return o;}
    fixed4 frag(v2f i):SV_Target{fixed4 c=i.color;UNITY_APPLY_FOG(i.fogCoord,c);return c;}
    ENDCG
    SubShader {
        Tags {"RenderType"="Opaque" "RenderPipeline"="UniversalPipeline"}
        Cull Off ZWrite On
        Pass {
            Tags {"LightMode"="SRPDefaultUnlit"}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog
            ENDCG
        }
    }
    SubShader {
        Tags {"RenderType"="Opaque"}
        Cull Off ZWrite On
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog
            ENDCG
        }
    }
    Fallback Off
}
