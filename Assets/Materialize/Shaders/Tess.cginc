		
#ifdef UNITY_CAN_COMPILE_TESSELLATION

// tessellation data struct
struct InternalTessInterp_appdata {
  float4 vertex : INTERNALTESSPOS;
  float4 tangent : TANGENT;
  float3 normal : NORMAL;
  float4 texcoord : TEXCOORD0;
  float4 texcoord1 : TEXCOORD1;
  float4 texcoord2 : TEXCOORD2;
  float4 texcoord3 : TEXCOORD3;
#if defined(SHADER_API_XBOX360)
	half4 texcoord4 : TEXCOORD4;
	half4 texcoord5 : TEXCOORD5;
#endif
  float4 color : COLOR;
};

// tessellation vertex shader
InternalTessInterp_appdata tessvert_surf (appdata_full v) {
  InternalTessInterp_appdata o;
  o.vertex = v.vertex;
  o.tangent = v.tangent;
  o.normal = v.normal;
  o.texcoord = v.texcoord;
  o.texcoord1 = v.texcoord1;
  o.texcoord2 = v.texcoord2;
  o.texcoord3 = v.texcoord3;
#if defined(SHADER_API_XBOX360)
	o.texcoord4 = v.texcoord4;
	o.texcoord5 = v.texcoord5;
#endif
  o.color = v.color;
  return o;
}

// tessellation hull constant shader
UnityTessellationFactors hsconst_surf (InputPatch<InternalTessInterp_appdata,3> v) {  
  float4 tf = UnityEdgeLengthBasedTessCull (v[0].vertex, v[1].vertex, v[2].vertex, _EdgeLength, _Parallax * 1.5 );
  UnityTessellationFactors o;
  o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
  return o;
}

// tessellation hull shader
[UNITY_domain("tri")]
[UNITY_partitioning("fractional_odd")]
[UNITY_outputtopology("triangle_cw")]
[UNITY_patchconstantfunc("hsconst_surf")]
[UNITY_outputcontrolpoints(3)]
InternalTessInterp_appdata hs_surf (InputPatch<InternalTessInterp_appdata,3> v, uint id : SV_OutputControlPointID) {
  return v[id];
}

// tessellation domain shader
[UNITY_domain("tri")]
v2f_surf ds_surf (UnityTessellationFactors tessFactors, const OutputPatch<InternalTessInterp_appdata,3> vi, float3 bary : SV_DomainLocation) {
  //appdata v;
  appdata_full v;
  v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
  v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
  v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
  v.texcoord = vi[0].texcoord*bary.x + vi[1].texcoord*bary.y + vi[2].texcoord*bary.z;
  v.texcoord1 = vi[0].texcoord1*bary.x + vi[1].texcoord1*bary.y + vi[2].texcoord1*bary.z;
  v.texcoord2 = vi[0].texcoord2*bary.x + vi[1].texcoord2*bary.y + vi[2].texcoord2*bary.z;
  v.texcoord3 = vi[0].texcoord3*bary.x + vi[1].texcoord3*bary.y + vi[2].texcoord3*bary.z;
#if defined(SHADER_API_XBOX360)
	v.texcoord4 = vi[0].texcoord4*bary.x + vi[1].texcoord4*bary.y + vi[2].texcoord4*bary.z;
	v.texcoord5 = vi[0].texcoord5*bary.x + vi[1].texcoord5*bary.y + vi[2].texcoord5*bary.z;
#endif
  v.color = vi[0].color*bary.x + vi[1].color*bary.y + vi[2].color*bary.z;
  v2f_surf o = vert_surf (v);
  return o;
}

#endif // UNITY_CAN_COMPILE_TESSELLATION