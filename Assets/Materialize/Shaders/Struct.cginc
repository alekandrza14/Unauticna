#include "HLSLSupport.cginc"
#include "UnityShaderVariables.cginc"

#include "UnityCG.cginc"
#include "Lighting.cginc"
#include "UnityPBSLighting.cginc"
#include "AutoLight.cginc"

#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
#define WorldNormalVector(data,normal) fixed3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))

sampler2D _MainTex;
float4 _MainTex_ST;
sampler2D _BumpTex;
sampler2D _MetallicTex;
sampler2D _SmoothnessTex;
sampler2D _EdgeTex;
sampler2D _AOTex;
sampler2D _PropertyTex;

struct Input {
	float2 uv_MainTex;
};

half _Glossiness;
half _Metallic;
half _EdgePower;
half _AOPower;
fixed4 _Color;

sampler2D _DisplacementTex;
float _EdgeLength;
float _Parallax;
float _ParallaxBias;
float _TessDisplacement;


#ifdef UNITY_PASS_FORWARDBASE
// vertex-to-fragment interpolation data
// no lightmaps:
#ifdef LIGHTMAP_OFF
struct v2f_surf {
  float4 pos : SV_POSITION;
  float2 pack0 : TEXCOORD0; // _MainTex
  float4 tSpace0 : TEXCOORD1;
  float4 tSpace1 : TEXCOORD2;
  float4 tSpace2 : TEXCOORD3;
  #if UNITY_SHOULD_SAMPLE_SH
  half3 sh : TEXCOORD4; // SH
  #endif
  SHADOW_COORDS(5)
  UNITY_FOG_COORDS(6)
  #if SHADER_TARGET >= 30
  float4 lmap : TEXCOORD7;
  #endif
};
#endif
// with lightmaps:
#ifndef LIGHTMAP_OFF
struct v2f_surf {
  float4 pos : SV_POSITION;
  float2 pack0 : TEXCOORD0; // _MainTex
  float4 tSpace0 : TEXCOORD1;
  float4 tSpace1 : TEXCOORD2;
  float4 tSpace2 : TEXCOORD3;
  float4 lmap : TEXCOORD4;
  SHADOW_COORDS(5)
  UNITY_FOG_COORDS(6)
};
#endif
#endif


#ifdef UNITY_PASS_FORWARDADD
// vertex-to-fragment interpolation data
struct v2f_surf {
  float4 pos : SV_POSITION;
  float2 pack0 : TEXCOORD0; // _MainTex
  fixed3 tSpace0 : TEXCOORD1;
  fixed3 tSpace1 : TEXCOORD2;
  fixed3 tSpace2 : TEXCOORD3;
  float3 worldPos : TEXCOORD4;
  SHADOW_COORDS(5)
  UNITY_FOG_COORDS(6)
};
#endif


#ifdef UNITY_PASS_DEFERRED
// vertex-to-fragment interpolation data
struct v2f_surf {
  float4 pos : SV_POSITION;
  float2 pack0 : TEXCOORD0; // _MainTex
  float4 tSpace0 : TEXCOORD1;
  float4 tSpace1 : TEXCOORD2;
  float4 tSpace2 : TEXCOORD3;
#ifndef DIRLIGHTMAP_OFF
  half3 viewDir : TEXCOORD4;
#endif
  float4 lmap : TEXCOORD5;
#ifdef LIGHTMAP_OFF
  #if UNITY_SHOULD_SAMPLE_SH
    half3 sh : TEXCOORD6; // SH
  #endif
#else
  #ifdef DIRLIGHTMAP_OFF
    float4 lmapFadePos : TEXCOORD7;
  #endif
#endif
};
#endif


#ifdef UNITY_PASS_SHADOWCASTER
// vertex-to-fragment interpolation data
struct v2f_surf {
	V2F_SHADOW_CASTER;
	float3 worldPos : TEXCOORD1;
};
#endif


#ifdef UNITY_PASS_META
struct v2f_surf {
  float4 pos : SV_POSITION;
  float2 pack0 : TEXCOORD0; // _MainTex
  float3 worldPos : TEXCOORD1;
};
#endif
