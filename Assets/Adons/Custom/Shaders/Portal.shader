Shader "Custom/Portal"
{
    Properties
    {
        [IntRange] _PortalRef("Portal Ref Number", Range(0,255)) = 0
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" "Queue" = "Geometry-1"}
 
        Stencil
        {
            Ref[_PortalRef]
            Comp Always
            Pass Replace
        }
 
        Pass
        {
            Blend Zero One
            ZWrite Off
        }
    }
}