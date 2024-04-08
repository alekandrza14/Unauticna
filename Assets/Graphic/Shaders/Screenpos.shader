// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "selectedFace"
{   Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert 
			#pragma fragment frag
            
            
        sampler2D _MainTex;
		
            float4 vert(float4 vertexPosition:POSITION):POSITION
            {
                return UnityObjectToClipPos(vertexPosition);
            }

            //Mapping SV_Target(D3D10) to COLOR(Direct3D 9)
            float4 frag(UNITY_VPOS_TYPE screenPos : VPOS):SV_Target
            {
                 //screenPos.x - x position on Screen
                 //screenPos.y - y position on Screen

                float4 c =  tex2D(_MainTex, float2(screenPos.x/32,screenPos.y/32));
                return c;
            }
			ENDCG
		}
	}
}