// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'


#ifdef UNITY_PASS_FORWARDBASE
// vertex shader
v2f_surf vert_surf (appdata_full v) {
  v2f_surf o;
  UNITY_INITIALIZE_OUTPUT(v2f_surf,o);
  //o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
  o.pack0.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
  float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
  fixed3 worldNormal = UnityObjectToWorldNormal(v.normal);
  fixed3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
  fixed tangentSign = v.tangent.w * unity_WorldTransformParams.w;
  fixed3 worldBinormal = cross(worldNormal, worldTangent) * tangentSign;
  
  //Displacement
  float4 displacementTex = tex2Dlod (_DisplacementTex, float4(o.pack0.xy,0,0));
  worldPos += worldNormal * ( displacementTex - _ParallaxBias ) * _Parallax;
  o.pos = mul (UNITY_MATRIX_VP, float4( worldPos,1));
  
  o.tSpace0 = float4(worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x);
  o.tSpace1 = float4(worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y);
  o.tSpace2 = float4(worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z);
  #ifndef DYNAMICLIGHTMAP_OFF
  o.lmap.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
  #endif
  #ifndef LIGHTMAP_OFF
  o.lmap.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
  #endif

  // SH/ambient and vertex lights
  #ifdef LIGHTMAP_OFF
    #if UNITY_SHOULD_SAMPLE_SH
      #if UNITY_SAMPLE_FULL_SH_PER_PIXEL
        o.sh = 0;
      #elif (SHADER_TARGET < 30)
        o.sh = ShadeSH9 (float4(worldNormal,1.0));
      #else
        o.sh = ShadeSH3Order (half4(worldNormal, 1.0));
      #endif
      // Add approximated illumination from non-important point lights
      #ifdef VERTEXLIGHT_ON
        o.sh += Shade4PointLights (
          unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
          unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
          unity_4LightAtten0, worldPos, worldNormal);
      #endif
    #endif
  #endif // LIGHTMAP_OFF

  TRANSFER_SHADOW(o); // pass shadow coordinates to pixel shader
  UNITY_TRANSFER_FOG(o,o.pos); // pass fog coordinates to pixel shader
  return o;
}
#endif


#ifdef UNITY_PASS_FORWARDADD
// vertex shader
v2f_surf vert_surf (appdata_full v) {
  v2f_surf o;
  UNITY_INITIALIZE_OUTPUT(v2f_surf,o);
  //o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
  o.pack0.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
  float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
  fixed3 worldNormal = UnityObjectToWorldNormal(v.normal);
  fixed3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
  fixed tangentSign = v.tangent.w * unity_WorldTransformParams.w;
  fixed3 worldBinormal = cross(worldNormal, worldTangent) * tangentSign;
  
  //Displacement
  float4 displacementTex = tex2Dlod (_DisplacementTex, float4(o.pack0.xy,0,0));
  worldPos += worldNormal * ( displacementTex - _ParallaxBias ) * _Parallax;
  o.pos = mul (UNITY_MATRIX_VP, float4( worldPos,1));
  
  o.tSpace0 = fixed3(worldTangent.x, worldBinormal.x, worldNormal.x);
  o.tSpace1 = fixed3(worldTangent.y, worldBinormal.y, worldNormal.y);
  o.tSpace2 = fixed3(worldTangent.z, worldBinormal.z, worldNormal.z);
  o.worldPos = worldPos;

  TRANSFER_SHADOW(o); // pass shadow coordinates to pixel shader
  UNITY_TRANSFER_FOG(o,o.pos); // pass fog coordinates to pixel shader
  return o;
}
#endif


#ifdef UNITY_PASS_DEFERRED
// vertex shader
v2f_surf vert_surf (appdata_full v) {
  v2f_surf o;
  UNITY_INITIALIZE_OUTPUT(v2f_surf,o);
  //o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
  o.pack0.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
  float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
  fixed3 worldNormal = UnityObjectToWorldNormal(v.normal);
  fixed3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
  fixed tangentSign = v.tangent.w * unity_WorldTransformParams.w;
  fixed3 worldBinormal = cross(worldNormal, worldTangent) * tangentSign;
  
  //Displacement
  float4 displacementTex = tex2Dlod (_DisplacementTex, float4(o.pack0.xy,0,0));
  worldPos += worldNormal * ( displacementTex - _ParallaxBias ) * _Parallax;
  o.pos = mul (UNITY_MATRIX_VP, float4( worldPos,1));
  
  o.tSpace0 = float4(worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x);
  o.tSpace1 = float4(worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y);
  o.tSpace2 = float4(worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z);
  float3 viewDirForLight = UnityWorldSpaceViewDir(worldPos);
  #ifndef DIRLIGHTMAP_OFF
  o.viewDir.x = dot(viewDirForLight, worldTangent);
  o.viewDir.y = dot(viewDirForLight, worldBinormal);
  o.viewDir.z = dot(viewDirForLight, worldNormal);
  #endif
#ifndef DYNAMICLIGHTMAP_OFF
  o.lmap.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
#else
  o.lmap.zw = 0;
#endif
#ifndef LIGHTMAP_OFF
  o.lmap.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
  #ifdef DIRLIGHTMAP_OFF
    o.lmapFadePos.xyz = (mul(unity_ObjectToWorld, v.vertex).xyz - unity_ShadowFadeCenterAndType.xyz) * unity_ShadowFadeCenterAndType.w;
    o.lmapFadePos.w = (-mul(UNITY_MATRIX_MV, v.vertex).z) * (1.0 - unity_ShadowFadeCenterAndType.w);
  #endif
#else
  o.lmap.xy = 0;
  #if UNITY_SHOULD_SAMPLE_SH
    #if UNITY_SAMPLE_FULL_SH_PER_PIXEL
      o.sh = 0;
    #elif (SHADER_TARGET < 30)
      o.sh = ShadeSH9 (float4(worldNormal,1.0));
    #else
      o.sh = ShadeSH3Order (half4(worldNormal, 1.0));
    #endif
  #endif
#endif
  return o;
}
#endif


#ifdef UNITY_PASS_SHADOWCASTER
// vertex shader
v2f_surf vert_surf (appdata_full v) {
	v2f_surf o;
	UNITY_INITIALIZE_OUTPUT(v2f_surf,o);
  
	float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
	fixed3 worldNormal = UnityObjectToWorldNormal(v.normal);
	
	float2 uv = TRANSFORM_TEX(v.texcoord, _MainTex);
	//Displacement
  	float4 displacementTex = tex2Dlod (_DisplacementTex, float4(uv,0,0));
  	worldPos += worldNormal * ( displacementTex - _ParallaxBias ) * _Parallax;

	o.worldPos = worldPos;
	
	v.vertex = mul(unity_WorldToObject, float4(worldPos,1));
	TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
	return o;
}
#endif

#ifdef UNITY_PASS_META
// vertex shader
v2f_surf vert_surf (appdata_full v) {
  v2f_surf o;
  UNITY_INITIALIZE_OUTPUT(v2f_surf,o);
  o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST);
  o.pack0.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
  float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
  fixed3 worldNormal = UnityObjectToWorldNormal(v.normal);
  o.worldPos = worldPos;
  return o;
}
#endif