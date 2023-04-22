
#ifdef UNITY_PASS_FORWARDBASE
// fragment shader
fixed4 frag_surf (v2f_surf IN) : SV_Target {
  // prepare and unpack data
  Input surfIN;
  UNITY_INITIALIZE_OUTPUT(Input,surfIN);
  surfIN.uv_MainTex = IN.pack0.xy;
  float3 worldPos = float3(IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w);
  #ifndef USING_DIRECTIONAL_LIGHT
    fixed3 lightDir = normalize(UnityWorldSpaceLightDir(worldPos));
  #else
    fixed3 lightDir = _WorldSpaceLightPos0.xyz;
  #endif
  fixed3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldPos));
  #ifdef UNITY_COMPILER_HLSL
  SurfaceOutputStandard o = (SurfaceOutputStandard)0;
  #else
  SurfaceOutputStandard o;
  #endif
  
	// Albedo comes from a texture tinted by color
	fixed4 albedoTex = tex2D (_MainTex, IN.pack0.xy) * _Color;
	float4 normalTex = tex2D (_BumpTex, IN.pack0.xy);
	
	float metallic = 0;
	float smoothness = 0;
	float ao = 0;
	
	#ifdef MATERIALIZE_PROPERTY
		float4 propertyTex = tex2D (_PropertyTex, IN.pack0.xy);
		metallic = propertyTex.x;
		smoothness = propertyTex.y;
		ao = propertyTex.z;
	#else
		float4 metallicTex = tex2D (_MetallicTex, IN.pack0.xy);
		float4 smoothnessTex = tex2D (_SmoothnessTex, IN.pack0.xy);
		float4 edgeTex = tex2D (_EdgeTex, IN.pack0.xy);
		float4 aoTex = tex2D (_AOTex, IN.pack0.xy);
		
		metallic = metallicTex.x;
		smoothness = smoothnessTex.x;
		ao = saturate( aoTex.x * ( edgeTex.x + 0.5 ) );
		
		// Apply edge map tp the diffuse
		albedoTex.xyz = saturate( albedoTex.xyz * ( ( edgeTex - 0.5 ) * _EdgePower + 1 ) );
	#endif

	// flip the normal
	float3 localNormal = UnpackNormal( normalTex );
	#ifdef FLIP_NORMAL
	localNormal.y *= -1;
	#endif


	o.Albedo = albedoTex.rgb;
	o.Normal = localNormal;
	o.Metallic = saturate( metallic * _Metallic );
	o.Smoothness = saturate( smoothness * _Glossiness );
	o.Occlusion = pow( ao, _AOPower );
	o.Alpha = albedoTex.a;

  fixed3 worldN;
  worldN.x = dot(IN.tSpace0.xyz, o.Normal);
  worldN.y = dot(IN.tSpace1.xyz, o.Normal);
  worldN.z = dot(IN.tSpace2.xyz, o.Normal);
  o.Normal = worldN;
  
  // compute lighting & shadowing factor
  UNITY_LIGHT_ATTENUATION(atten, IN, worldPos)
  fixed4 c = 0;

  // Setup lighting environment
  UnityGI gi;
  UNITY_INITIALIZE_OUTPUT(UnityGI, gi);
  gi.indirect.diffuse = 0;
  gi.indirect.specular = 0;
  #if !defined(LIGHTMAP_ON)
      gi.light.color = _LightColor0.rgb;
      gi.light.dir = lightDir;
      gi.light.ndotl = LambertTerm (o.Normal, gi.light.dir);
  #endif
  // Call GI (lightmaps/SH/reflections) lighting function
  UnityGIInput giInput;
  UNITY_INITIALIZE_OUTPUT(UnityGIInput, giInput);
  giInput.light = gi.light;
  giInput.worldPos = worldPos;
  giInput.worldViewDir = worldViewDir;
  giInput.atten = atten;
  #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
    giInput.lightmapUV = IN.lmap;
  #else
    giInput.lightmapUV = 0.0;
  #endif
  #if UNITY_SHOULD_SAMPLE_SH
    giInput.ambient = IN.sh;
  #else
    giInput.ambient.rgb = 0.0;
  #endif
  giInput.probeHDR[0] = unity_SpecCube0_HDR;
  giInput.probeHDR[1] = unity_SpecCube1_HDR;
  #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
    giInput.boxMin[0] = unity_SpecCube0_BoxMin; // .w holds lerp value for blending
  #endif
  #if UNITY_SPECCUBE_BOX_PROJECTION
    giInput.boxMax[0] = unity_SpecCube0_BoxMax;
    giInput.probePosition[0] = unity_SpecCube0_ProbePosition;
    giInput.boxMax[1] = unity_SpecCube1_BoxMax;
    giInput.boxMin[1] = unity_SpecCube1_BoxMin;
    giInput.probePosition[1] = unity_SpecCube1_ProbePosition;
  #endif
  LightingStandard_GI(o, giInput, gi);

  // realtime lighting: call lighting function
  c += LightingStandard (o, worldViewDir, gi);
  UNITY_APPLY_FOG(IN.fogCoord, c); // apply fog
  UNITY_OPAQUE_ALPHA(c.a);
  return c;
}
#endif

#ifdef UNITY_PASS_FORWARDADD
// fragment shader
fixed4 frag_surf (v2f_surf IN) : SV_Target {
  // prepare and unpack data
  Input surfIN;
  UNITY_INITIALIZE_OUTPUT(Input,surfIN);
  surfIN.uv_MainTex = IN.pack0.xy;
  float3 worldPos = IN.worldPos;
  #ifndef USING_DIRECTIONAL_LIGHT
    fixed3 lightDir = normalize(UnityWorldSpaceLightDir(worldPos));
  #else
    fixed3 lightDir = _WorldSpaceLightPos0.xyz;
  #endif
  fixed3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldPos));
  #ifdef UNITY_COMPILER_HLSL
  SurfaceOutputStandard o = (SurfaceOutputStandard)0;
  #else
  SurfaceOutputStandard o;
  #endif
  
	// Albedo comes from a texture tinted by color
	fixed4 albedoTex = tex2D (_MainTex, IN.pack0.xy) * _Color;
	float4 normalTex = tex2D (_BumpTex, IN.pack0.xy);
	
	float metallic = 0;
	float smoothness = 0;
	float ao = 0;
	
	#ifdef MATERIALIZE_PROPERTY
		float4 propertyTex = tex2D (_PropertyTex, IN.pack0.xy);
		metallic = propertyTex.x;
		smoothness = propertyTex.y;
		ao = propertyTex.z;
	#else
		float4 metallicTex = tex2D (_MetallicTex, IN.pack0.xy);
		float4 smoothnessTex = tex2D (_SmoothnessTex, IN.pack0.xy);
		float4 edgeTex = tex2D (_EdgeTex, IN.pack0.xy);
		float4 aoTex = tex2D (_AOTex, IN.pack0.xy);
		
		metallic = metallicTex.x;
		smoothness = smoothnessTex.x;
		ao = saturate( aoTex.x * ( edgeTex.x + 0.5 ) );
		
		// Apply edge map tp the diffuse
		albedoTex.xyz = saturate( albedoTex.xyz * ( ( edgeTex - 0.5 ) * _EdgePower + 1 ) );
	#endif

	// flip the normal
	float3 localNormal = UnpackNormal( normalTex );
	#ifdef FLIP_NORMAL
	localNormal.y *= -1;
	#endif


	o.Albedo = albedoTex.rgb;
	o.Normal = localNormal;
	o.Metallic = saturate( metallic * _Metallic );
	o.Smoothness = saturate( smoothness * _Glossiness );
	o.Occlusion = pow( ao, _AOPower );
	o.Alpha = albedoTex.a;

  fixed3 worldN;
  worldN.x = dot(IN.tSpace0.xyz, o.Normal);
  worldN.y = dot(IN.tSpace1.xyz, o.Normal);
  worldN.z = dot(IN.tSpace2.xyz, o.Normal);
  o.Normal = worldN;
  
  UNITY_LIGHT_ATTENUATION(atten, IN, worldPos)
  fixed4 c = 0;

  // Setup lighting environment
  UnityGI gi;
  UNITY_INITIALIZE_OUTPUT(UnityGI, gi);
  gi.indirect.diffuse = 0;
  gi.indirect.specular = 0;
  #if !defined(LIGHTMAP_ON)
      gi.light.color = _LightColor0.rgb;
      gi.light.dir = lightDir;
      gi.light.ndotl = LambertTerm (o.Normal, gi.light.dir);
  #endif
  gi.light.color *= atten;
  c += LightingStandard (o, worldViewDir, gi);
  c.a = 0.0;
  UNITY_APPLY_FOG(IN.fogCoord, c); // apply fog
  UNITY_OPAQUE_ALPHA(c.a);
  return c;
}
#endif

#ifdef UNITY_PASS_DEFERRED

#ifdef LIGHTMAP_ON
float4 unity_LightmapFade;
#endif
fixed4 unity_Ambient;

// fragment shader
void frag_surf (v2f_surf IN,
    out half4 outDiffuse : SV_Target0,
    out half4 outSpecSmoothness : SV_Target1,
    out half4 outNormal : SV_Target2,
    out half4 outEmission : SV_Target3) {
  // prepare and unpack data
  Input surfIN;
  UNITY_INITIALIZE_OUTPUT(Input,surfIN);
  surfIN.uv_MainTex = IN.pack0.xy;
  float3 worldPos = float3(IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w);
  #ifndef USING_DIRECTIONAL_LIGHT
    fixed3 lightDir = normalize(UnityWorldSpaceLightDir(worldPos));
  #else
    fixed3 lightDir = _WorldSpaceLightPos0.xyz;
  #endif
  fixed3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldPos));
  #ifdef UNITY_COMPILER_HLSL
  SurfaceOutputStandard o = (SurfaceOutputStandard)0;
  #else
  SurfaceOutputStandard o;
  #endif
  
	// Albedo comes from a texture tinted by color
	fixed4 albedoTex = tex2D (_MainTex, IN.pack0.xy) * _Color;
	float4 normalTex = tex2D (_BumpTex, IN.pack0.xy);
	
	float metallic = 0;
	float smoothness = 0;
	float ao = 0;
	
	#ifdef MATERIALIZE_PROPERTY
		float4 propertyTex = tex2D (_PropertyTex, IN.pack0.xy);
		metallic = propertyTex.x;
		smoothness = propertyTex.y;
		ao = propertyTex.z;
	#else
		float4 metallicTex = tex2D (_MetallicTex, IN.pack0.xy);
		float4 smoothnessTex = tex2D (_SmoothnessTex, IN.pack0.xy);
		float4 edgeTex = tex2D (_EdgeTex, IN.pack0.xy);
		float4 aoTex = tex2D (_AOTex, IN.pack0.xy);
		
		metallic = metallicTex.x;
		smoothness = smoothnessTex.x;
		ao = saturate( aoTex.x * ( edgeTex.x + 0.5 ) );
		
		// Apply edge map tp the diffuse
		albedoTex.xyz = saturate( albedoTex.xyz * ( ( edgeTex - 0.5 ) * _EdgePower + 1 ) );
	#endif

	// flip the normal
	float3 localNormal = UnpackNormal( normalTex );
	#ifdef FLIP_NORMAL
	localNormal.y *= -1;
	#endif


	o.Albedo = albedoTex.rgb;
	o.Normal = localNormal;
	o.Metallic = saturate( metallic * _Metallic );
	o.Smoothness = saturate( smoothness * _Glossiness );
	o.Occlusion = pow( ao, _AOPower );
	o.Alpha = albedoTex.a;
	
  fixed3 worldN;
  worldN.x = dot(IN.tSpace0.xyz, o.Normal);
  worldN.y = dot(IN.tSpace1.xyz, o.Normal);
  worldN.z = dot(IN.tSpace2.xyz, o.Normal);
  o.Normal = worldN;
  
  //fixed3 originalNormal = o.Normal;
  half atten = 1;

  // Setup lighting environment
  UnityGI gi;
  UNITY_INITIALIZE_OUTPUT(UnityGI, gi);
  gi.indirect.diffuse = 0;
  gi.indirect.specular = 0;
  gi.light.color = 0;
  gi.light.dir = half3(0,1,0);
  gi.light.ndotl = LambertTerm (o.Normal, gi.light.dir);
  // Call GI (lightmaps/SH/reflections) lighting function
  UnityGIInput giInput;
  UNITY_INITIALIZE_OUTPUT(UnityGIInput, giInput);
  giInput.light = gi.light;
  giInput.worldPos = worldPos;
  giInput.worldViewDir = worldViewDir;
  giInput.atten = atten;
  #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
    giInput.lightmapUV = IN.lmap;
  #else
    giInput.lightmapUV = 0.0;
  #endif
  #if UNITY_SHOULD_SAMPLE_SH
    giInput.ambient = IN.sh;
  #else
    giInput.ambient.rgb = 0.0;
  #endif
  giInput.probeHDR[0] = unity_SpecCube0_HDR;
  giInput.probeHDR[1] = unity_SpecCube1_HDR;
  #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
    giInput.boxMin[0] = unity_SpecCube0_BoxMin; // .w holds lerp value for blending
  #endif
  #if UNITY_SPECCUBE_BOX_PROJECTION
    giInput.boxMax[0] = unity_SpecCube0_BoxMax;
    giInput.probePosition[0] = unity_SpecCube0_ProbePosition;
    giInput.boxMax[1] = unity_SpecCube1_BoxMax;
    giInput.boxMin[1] = unity_SpecCube1_BoxMin;
    giInput.probePosition[1] = unity_SpecCube1_ProbePosition;
  #endif
  LightingStandard_GI(o, giInput, gi);

  // call lighting function to output g-buffer
  outEmission = LightingStandard_Deferred (o, worldViewDir, gi, outDiffuse, outSpecSmoothness, outNormal);
  #ifndef UNITY_HDR_ON
  outEmission.rgb = exp2(-outEmission.rgb);
  #endif
  //UNITY_OPAQUE_ALPHA(outDiffuse.a);
  outDiffuse.a = o.Occlusion;
  
}
#endif


#ifdef UNITY_PASS_SHADOWCASTER
// fragment shader
fixed4 frag_surf (v2f_surf IN) : SV_Target {
	// prepare and unpack data				
	SHADOW_CASTER_FRAGMENT(IN)
}
#endif


#ifdef UNITY_PASS_META
// fragment shader
fixed4 frag_surf (v2f_surf IN) : SV_Target {
  // prepare and unpack data
  Input surfIN;
  UNITY_INITIALIZE_OUTPUT(Input,surfIN);
  surfIN.uv_MainTex = IN.pack0.xy;
  float3 worldPos = IN.worldPos;
  #ifndef USING_DIRECTIONAL_LIGHT
    fixed3 lightDir = normalize(UnityWorldSpaceLightDir(worldPos));
  #else
    fixed3 lightDir = _WorldSpaceLightPos0.xyz;
  #endif
  #ifdef UNITY_COMPILER_HLSL
  SurfaceOutputStandard o = (SurfaceOutputStandard)0;
  #else
  SurfaceOutputStandard o;
  #endif

	fixed4 albedoTex = tex2D (_MainTex, IN.pack0.xy) * _Color;

	o.Albedo = albedoTex.rgb;
	o.Emission = 0.0;

  //fixed3 normalWorldVertex = fixed3(0,0,1);

  UnityMetaInput metaIN;
  UNITY_INITIALIZE_OUTPUT(UnityMetaInput, metaIN);
  metaIN.Albedo = o.Albedo;
  metaIN.Emission = o.Emission;
  return UnityMetaFragment(metaIN);
}
#endif
