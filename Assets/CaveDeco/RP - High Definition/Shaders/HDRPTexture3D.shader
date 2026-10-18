// Tex3D/HDRPSurface - Unity 6000.0, HDRP 17.0.3.
// Self-contained adaptation of Unity HDRP Lit.shader, LitProperties.hlsl and LitData.hlsl.
// Upstream revision: 7c90867aae06bba50809d0cd901bd1109d837a01 (HDRP 17.0.3).
// Keep this file in Assets; package files must not be modified.
/*
Copyright © 2020 Unity Technologies ApS

Licensed under the Unity Companion License for Unity-dependent projects--see [Unity Companion License](http://www.unity3d.com/legal/licenses/Unity_Companion_License).

Unless expressly provided otherwise, the Software under this license is made available strictly on an “AS IS” BASIS WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED. Please review the license for details on these and other terms and conditions.

*/

Shader "Tex3D/HDRPSurface"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _BlickIndensity ("BlickIndensity", Float) = 1
        _MainTex ("Albedo (RGB)", 3D) = "white" {}
        _BlicsTex ("Blics (RGB)", 3D) = "black" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        // Following set of parameters represent the parameters node inside the MaterialGraph.
        // They are use to fill a SurfaceData. With a MaterialGraph this should not exist.

        // Reminder. Color here are in linear but the UI (color picker) do the conversion sRGB to linear
        [HideInInspector] [MainColor] _BaseColor("BaseColor", Color) = (1,1,1,1)
        [HideInInspector] [MainTexture] _BaseColorMap("BaseColorMap", 2D) = "white" {}

        _Metallic ("Metallic", Range(0,1)) = 0
        [HideInInspector] _Smoothness("Smoothness", Range(0.0, 1.0)) = 0.5
        [HideInInspector] _MaskMap("MaskMap", 2D) = "white" {}
        [HideInInspector] _MetallicRemapMin("MetallicRemapMin", Float) = 0.0
        [HideInInspector] _MetallicRemapMax("MetallicRemapMax", Float) = 1.0
        [HideInInspector] _SmoothnessRemapMin("SmoothnessRemapMin", Float) = 0.0
        [HideInInspector] _SmoothnessRemapMax("SmoothnessRemapMax", Float) = 1.0
        [HideInInspector] _AlphaRemapMin("AlphaRemapMin", Float) = 0.0
        [HideInInspector] _AlphaRemapMax("AlphaRemapMax", Float) = 1.0
        [HideInInspector] _AORemapMin("AORemapMin", Float) = 0.0
        [HideInInspector] _AORemapMax("AORemapMax", Float) = 1.0

        [HideInInspector] _NormalMap("NormalMap", 2D) = "bump" {}     // Tangent space normal map
        [HideInInspector] _NormalMapOS("NormalMapOS", 2D) = "white" {} // Object space normal map - no good default value
        [HideInInspector] _NormalScale("_NormalScale", Range(0.0, 8.0)) = 1

        [HideInInspector] _BentNormalMap("_BentNormalMap", 2D) = "bump" {}
        [HideInInspector] _BentNormalMapOS("_BentNormalMapOS", 2D) = "white" {}

        [HideInInspector] _HeightMap("HeightMap", 2D) = "black" {}
        // Caution: Default value of _HeightAmplitude must be (_HeightMax - _HeightMin) * 0.01
        // Those two properties are computed from the ones exposed in the UI and depends on the displaement mode so they are separate because we don't want to lose information upon displacement mode change.
        [HideInInspector] _HeightAmplitude("Height Amplitude", Float) = 0.02 // In world units. This will be computed in the UI.
        [HideInInspector] _HeightCenter("Height Center", Range(0.0, 1.0)) = 0.5 // In texture space

        [HideInInspector] [Enum(MinMax, 0, Amplitude, 1)] _HeightMapParametrization("Heightmap Parametrization", Int) = 0
        // These parameters are for vertex displacement/Tessellation
        [HideInInspector] _HeightOffset("Height Offset", Float) = 0
        // MinMax mode
        [HideInInspector] _HeightMin("Heightmap Min", Float) = -1
        [HideInInspector] _HeightMax("Heightmap Max", Float) = 1
        // Amplitude mode
        [HideInInspector] _HeightTessAmplitude("Amplitude", Float) = 2.0 // in Centimeters
        [HideInInspector] _HeightTessCenter("Height Center", Range(0.0, 1.0)) = 0.5 // In texture space

        // These parameters are for pixel displacement
        [HideInInspector] _HeightPoMAmplitude("Height Amplitude", Float) = 2.0 // In centimeters

        [HideInInspector] _DetailMap("DetailMap", 2D) = "linearGrey" {}
        [HideInInspector] _DetailAlbedoScale("_DetailAlbedoScale", Range(0.0, 2.0)) = 1
        [HideInInspector] _DetailNormalScale("_DetailNormalScale", Range(0.0, 2.0)) = 1
        [HideInInspector] _DetailSmoothnessScale("_DetailSmoothnessScale", Range(0.0, 2.0)) = 1

        [HideInInspector] _TangentMap("TangentMap", 2D) = "bump" {}
        [HideInInspector] _TangentMapOS("TangentMapOS", 2D) = "white" {}
        [HideInInspector] _Anisotropy("Anisotropy", Range(-1.0, 1.0)) = 0
        [HideInInspector] _AnisotropyMap("AnisotropyMap", 2D) = "white" {}

        [HideInInspector] _SubsurfaceMask("Subsurface Radius", Range(0.0, 1.0)) = 1.0
        [HideInInspector] _SubsurfaceMaskMap("Subsurface Radius Map", 2D) = "white" {}
        [HideInInspector] _TransmissionMask("Transmission Mask", Range(0.0, 1.0)) = 1.0
        [HideInInspector] _TransmissionMaskMap("Transmission Mask Map", 2D) = "white" {}
        [HideInInspector] _Thickness("Thickness", Float) = 1.0
        [HideInInspector] _ThicknessMap("Thickness Map", 2D) = "white" {}
        [HideInInspector] _ThicknessRemap("Thickness Remap", Vector) = (0, 1, 0, 0)

        [HideInInspector] _IridescenceThickness("Iridescence Thickness", Range(0.0, 1.0)) = 1.0
        [HideInInspector] _IridescenceThicknessMap("Iridescence Thickness Map", 2D) = "white" {}
        [HideInInspector] _IridescenceThicknessRemap("Iridescence Thickness Remap", Vector) = (0, 1, 0, 0)
        [HideInInspector] _IridescenceMask("Iridescence Mask", Range(0.0, 1.0)) = 1.0
        [HideInInspector] _IridescenceMaskMap("Iridescence Mask Map", 2D) = "white" {}

        [HideInInspector] _CoatMask("Coat Mask", Range(0.0, 1.0)) = 0.0
        [HideInInspector] _CoatMaskMap("CoatMaskMap", 2D) = "white" {}

        [HideInInspector] [ToggleUI] _EnergyConservingSpecularColor("_EnergyConservingSpecularColor", Float) = 1.0
        [HideInInspector] _SpecularColor("SpecularColor", Color) = (1, 1, 1, 1)
        [HideInInspector] _SpecularColorMap("SpecularColorMap", 2D) = "white" {}

        // Following options are for the GUI inspector and different from the input parameters above
        // These option below will cause different compilation flag.
        [HideInInspector] [Enum(Off, 0, From Ambient Occlusion, 1, From AO and Bent Normals, 2)]  _SpecularOcclusionMode("Specular Occlusion Mode", Int) = 1

        [HideInInspector] [HDR] _EmissiveColor("EmissiveColor", Color) = (0, 0, 0)
        // Used only to serialize the LDR and HDR emissive color in the material UI,
        // in the shader only the _EmissiveColor should be used
        [HideInInspector] _EmissiveColorLDR("EmissiveColor LDR", Color) = (0, 0, 0)
        [HideInInspector] _EmissiveColorMap("EmissiveColorMap", 2D) = "white" {}
        [HideInInspector] [ToggleUI] _AlbedoAffectEmissive("Albedo Affect Emissive", Float) = 0.0
        [HideInInspector] _EmissiveIntensityUnit("Emissive Mode", Int) = 0
        [HideInInspector] [ToggleUI] _UseEmissiveIntensity("Use Emissive Intensity", Int) = 0
        [HideInInspector] _EmissiveIntensity("Emissive Intensity", Float) = 1
        [HideInInspector] _EmissiveExposureWeight("Emissive Pre Exposure", Range(0.0, 1.0)) = 1.0

        [HideInInspector] [ToggleUI]  _UseShadowThreshold("_UseShadowThreshold", Float) = 0.0
        [HideInInspector] [ToggleUI]  _AlphaCutoffEnable("Alpha Cutoff Enable", Float) = 0.0
        [HideInInspector] _AlphaCutoff("Alpha Cutoff", Range(0.0, 1.0)) = 0.5
        [HideInInspector] _AlphaCutoffShadow("_AlphaCutoffShadow", Range(0.0, 1.0)) = 0.5
        [HideInInspector] _AlphaCutoffPrepass("_AlphaCutoffPrepass", Range(0.0, 1.0)) = 0.5
        [HideInInspector] _AlphaCutoffPostpass("_AlphaCutoffPostpass", Range(0.0, 1.0)) = 0.5
        [HideInInspector] [ToggleUI] _TransparentDepthPrepassEnable("_TransparentDepthPrepassEnable", Float) = 0.0
        [HideInInspector] [ToggleUI] _TransparentBackfaceEnable("_TransparentBackfaceEnable", Float) = 0.0
        [HideInInspector] [ToggleUI] _TransparentDepthPostpassEnable("_TransparentDepthPostpassEnable", Float) = 0.0
        [HideInInspector] _TransparentSortPriority("_TransparentSortPriority", Float) = 0

        // Transparency
        [HideInInspector] [Enum(None, 0, Planar, 1, Sphere, 2, Thin, 3)]_RefractionModel("Refraction Model", Int) = 0
        [HideInInspector] _Ior("Index Of Refraction", Range(1.0, 2.5)) = 1.5
        [HideInInspector] _TransmittanceColor("Transmittance Color", Color) = (1.0, 1.0, 1.0)
        [HideInInspector] _TransmittanceColorMap("TransmittanceColorMap", 2D) = "white" {}
        [HideInInspector] _ATDistance("Transmittance Absorption Distance", Float) = 1.0
        [HideInInspector] [ToggleUI] _TransparentWritingMotionVec("_TransparentWritingMotionVec", Float) = 0.0
        [HideInInspector] [ToggleUI] _PerPixelSorting("_PerPixelSorting", Float) = 0.0

        // Stencil state

        // Forward
        [HideInInspector] _StencilRef("_StencilRef", Int) = 0 // StencilUsage.Clear
        [HideInInspector] _StencilWriteMask("_StencilWriteMask", Int) = 3 // StencilUsage.RequiresDeferredLighting | StencilUsage.SubsurfaceScattering
        // GBuffer
        [HideInInspector] _StencilRefGBuffer("_StencilRefGBuffer", Int) = 2 // StencilUsage.RequiresDeferredLighting
        [HideInInspector] _StencilWriteMaskGBuffer("_StencilWriteMaskGBuffer", Int) = 3 // StencilUsage.RequiresDeferredLighting | StencilUsage.SubsurfaceScattering
        // Depth prepass
        [HideInInspector] _StencilRefDepth("_StencilRefDepth", Int) = 0 // Nothing
        [HideInInspector] _StencilWriteMaskDepth("_StencilWriteMaskDepth", Int) = 8 // StencilUsage.TraceReflectionRay
        // Motion vector pass
        [HideInInspector] _StencilRefMV("_StencilRefMV", Int) = 32 // StencilUsage.ObjectMotionVector
        [HideInInspector] _StencilWriteMaskMV("_StencilWriteMaskMV", Int) = 32 // StencilUsage.ObjectMotionVector

        // Blending state
        [HideInInspector] _SurfaceType("__surfacetype", Float) = 0.0
        [HideInInspector] _BlendMode("__blendmode", Float) = 0.0
        [HideInInspector] _SrcBlend("__src", Float) = 1.0
        [HideInInspector] _DstBlend("__dst", Float) = 0.0
        [HideInInspector] _DstBlend2("__dst2", Float) = 0.0
        [HideInInspector] _AlphaSrcBlend("__alphaSrc", Float) = 1.0
        [HideInInspector] _AlphaDstBlend("__alphaDst", Float) = 0.0
        [HideInInspector][ToggleUI] _ZWrite("__zw", Float) = 1.0
        [HideInInspector][ToggleUI] _TransparentZWrite("_TransparentZWrite", Float) = 0.0
        [HideInInspector] _CullMode("__cullmode", Float) = 2.0
        [HideInInspector] _CullModeForward("__cullmodeForward", Float) = 2.0 // This mode is dedicated to Forward to correctly handle backface then front face rendering thin transparent
        [HideInInspector] [Enum(UnityEngine.Rendering.HighDefinition.TransparentCullMode)] _TransparentCullMode("_TransparentCullMode", Int) = 2 // Back culling by default
        [HideInInspector] [Enum(UnityEngine.Rendering.HighDefinition.OpaqueCullMode)] _OpaqueCullMode("_OpaqueCullMode", Int) = 2 // Back culling by default
        [HideInInspector] _ZTestDepthEqualForOpaque("_ZTestDepthEqualForOpaque", Int) = 4 // Less equal
        [HideInInspector] _ZTestGBuffer("_ZTestGBuffer", Int) = 4
        [HideInInspector] [Enum(UnityEngine.Rendering.CompareFunction)] _ZTestTransparent("Transparent ZTest", Int) = 4 // Less equal

        [HideInInspector] [ToggleUI] _EnableFogOnTransparent("Enable Fog", Float) = 1.0
        [HideInInspector] [ToggleUI] _EnableBlendModePreserveSpecularLighting("Enable Blend Mode Preserve Specular Lighting", Float) = 1.0

        [HideInInspector] [ToggleUI] _DoubleSidedEnable("Double sided enable", Float) = 0.0
        [HideInInspector] [Enum(Flip, 0, Mirror, 1, None, 2)] _DoubleSidedNormalMode("Double sided normal mode", Float) = 1
        [HideInInspector] _DoubleSidedConstants("_DoubleSidedConstants", Vector) = (1, 1, -1, 0)
        [HideInInspector] [Enum(Auto, 0, On, 1, Off, 2)] _DoubleSidedGIMode("Double sided GI mode", Float) = 0

        [HideInInspector] [Enum(UV0, 0, UV1, 1, UV2, 2, UV3, 3, Planar, 4, Triplanar, 5)] _UVBase("UV Set for base", Float) = 0
        [HideInInspector] [Enum(WorldSpace, 0, ObjectSpace, 1)] _ObjectSpaceUVMapping("Mapping space", Float) = 0.0
        [HideInInspector] _TexWorldScale("Scale to apply on world coordinate", Float) = 1.0
        [HideInInspector] _InvTilingScale("Inverse tiling scale = 2 / (abs(_BaseColorMap_ST.x) + abs(_BaseColorMap_ST.y))", Float) = 1
        [HideInInspector] _UVMappingMask("_UVMappingMask", Color) = (1, 0, 0, 0)
        [HideInInspector] [Enum(TangentSpace, 0, ObjectSpace, 1)] _NormalMapSpace("NormalMap space", Float) = 0

        // Following enum should be material feature flags (i.e bitfield), however due to Gbuffer encoding constrain many combination exclude each other
        // so we use this enum as "material ID" which can be interpreted as preset of bitfield of material feature
        // The only material feature flag that can be added in all cases is clear coat
        [HideInInspector] [Enum(Subsurface Scattering, 0, Standard, 1, Anisotropy, 2, Iridescence, 3, Specular Color, 4, Translucent, 5)] _MaterialID("MaterialId", Int) = 1 // MaterialId.Standard
        [HideInInspector] [ToggleUI] _TransmissionEnable("_TransmissionEnable", Float) = 1.0

        [HideInInspector] _DisplacementMode("DisplacementMode", Int) = 0
        [HideInInspector] [ToggleUI] _DisplacementLockObjectScale("displacement lock object scale", Float) = 1.0
        [HideInInspector] [ToggleUI] _DisplacementLockTilingScale("displacement lock tiling scale", Float) = 1.0
        [HideInInspector] [ToggleUI] _DepthOffsetEnable("Depth Offset View space", Float) = 0.0

        [HideInInspector] [ToggleUI] _EnableGeometricSpecularAA("EnableGeometricSpecularAA", Float) = 0.0
        [HideInInspector] _SpecularAAScreenSpaceVariance("SpecularAAScreenSpaceVariance", Range(0.0, 1.0)) = 0.1
        [HideInInspector] _SpecularAAThreshold("SpecularAAThreshold", Range(0.0, 1.0)) = 0.2

        [HideInInspector] _PPDMinSamples("Min sample for POM", Range(1.0, 64.0)) = 5
        [HideInInspector] _PPDMaxSamples("Max sample for POM", Range(1.0, 64.0)) = 15
        [HideInInspector] _PPDLodThreshold("Start lod to fade out the POM effect", Range(0.0, 16.0)) = 5
        [HideInInspector] _PPDPrimitiveLength("Primitive length for POM", Float) = 1
        [HideInInspector] _PPDPrimitiveWidth("Primitive width for POM", Float) = 1
        [HideInInspector] _InvPrimScale("Inverse primitive scale for non-planar POM", Vector) = (1, 1, 0, 0)

        [HideInInspector] [Enum(UV0, 0, UV1, 1, UV2, 2, UV3, 3)] _UVDetail("UV Set for detail", Float) = 0
        [HideInInspector] _UVDetailsMappingMask("_UVDetailsMappingMask", Color) = (1, 0, 0, 0)
        [HideInInspector] [ToggleUI] _LinkDetailsWithBase("LinkDetailsWithBase", Float) = 1.0

        [HideInInspector] [Enum(Use Emissive Color, 0, Use Emissive Mask, 1)] _EmissiveColorMode("Emissive color mode", Float) = 1
        [HideInInspector] [Enum(UV0, 0, UV1, 1, UV2, 2, UV3, 3, Planar, 4, Triplanar, 5, Same as Base, 6)] _UVEmissive("UV Set for emissive", Float) = 0
        [HideInInspector] [Enum(WorldSpace, 0, ObjectSpace, 1)] _ObjectSpaceUVMappingEmissive("Mapping space", Float) = 0.0
        [HideInInspector] _TexWorldScaleEmissive("Scale to apply on world coordinate", Float) = 1.0
        [HideInInspector] _UVMappingMaskEmissive("_UVMappingMaskEmissive", Color) = (1, 0, 0, 0)

        // Caution: C# code in BaseLitUI.cs call LightmapEmissionFlagsProperty() which assume that there is an existing "_EmissionColor"
        // value that exist to identify if the GI emission need to be enabled.
        // In our case we don't use such a mechanism but need to keep the code quiet. We declare the value and always enable it.
        // TODO: Fix the code in legacy unity so we can customize the beahvior for GI
        [HideInInspector] _EmissionColor("Color", Color) = (1, 1, 1)

        // HACK: GI Baking system relies on some properties existing in the shader ("_MainTex", "_Cutoff" and "_Color") for opacity handling, so we need to store our version of those parameters in the hard-coded name the GI baking system recognizes.
        [HideInInspector] _Cutoff("Alpha Cutoff", Range(0.0, 1.0)) = 0.5

        [HideInInspector] [ToggleUI] _SupportDecals("Support Decals", Float) = 1.0
        [HideInInspector] [ToggleUI] _ReceivesSSR("Receives SSR", Float) = 1.0
        [HideInInspector] [ToggleUI] _ReceivesSSRTransparent("Receives SSR Transparent", Float) = 0.0
        [HideInInspector] [ToggleUI] _AddPrecomputedVelocity("AddPrecomputedVelocity", Float) = 0.0

        // Ray Tracing
        [HideInInspector] [ToggleUI] _RayTracing("Ray Tracing (Preview)", Float) = 0

        [HideInInspector] _DiffusionProfile("Obsolete, kept for migration purpose", Int) = 0
        [HideInInspector] _DiffusionProfileAsset("Diffusion Profile Asset", Vector) = (0, 0, 0, 0)
        [HideInInspector] _DiffusionProfileHash("Diffusion Profile Hash", Float) = 0

        [HideInInspector][NoScaleOffset]unity_Lightmaps("unity_Lightmaps", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset]unity_LightmapsInd("unity_LightmapsInd", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset]unity_ShadowMasks("unity_ShadowMasks", 2DArray) = "" {}
    }


    HLSLINCLUDE

    #pragma target 4.5
    //#pragma enable_d3d11_debug_symbols

    //-------------------------------------------------------------------------------------
    // Variant
    //-------------------------------------------------------------------------------------

    #pragma shader_feature_local _ALPHATEST_ON
    #pragma shader_feature_local _DEPTHOFFSET_ON
    #pragma shader_feature_local _DOUBLESIDED_ON
    #pragma shader_feature_local _ _VERTEX_DISPLACEMENT _PIXEL_DISPLACEMENT
    #pragma shader_feature_local_vertex _VERTEX_DISPLACEMENT_LOCK_OBJECT_SCALE
    #pragma shader_feature_local _DISPLACEMENT_LOCK_TILING_SCALE
    #pragma shader_feature_local_fragment _PIXEL_DISPLACEMENT_LOCK_OBJECT_SCALE
    #pragma shader_feature_local_fragment _ _REFRACTION_PLANE _REFRACTION_SPHERE _REFRACTION_THIN
    #pragma shader_feature_local_raytracing _ _REFRACTION_PLANE _REFRACTION_SPHERE _REFRACTION_THIN

    #pragma shader_feature_local_fragment _ _EMISSIVE_MAPPING_PLANAR _EMISSIVE_MAPPING_TRIPLANAR _EMISSIVE_MAPPING_BASE
    #pragma shader_feature_local _ _MAPPING_PLANAR _MAPPING_TRIPLANAR
    #pragma shader_feature_local_fragment _NORMALMAP_TANGENT_SPACE
    #pragma shader_feature_local_raytracing _ _EMISSIVE_MAPPING_PLANAR _EMISSIVE_MAPPING_TRIPLANAR _EMISSIVE_MAPPING_BASE
    #pragma shader_feature_local_raytracing _NORMALMAP_TANGENT_SPACE

    #pragma shader_feature_local _ _REQUIRE_UV2 _REQUIRE_UV3

    #pragma shader_feature_local _NORMALMAP
    #pragma shader_feature_local_fragment _MASKMAP
    #pragma shader_feature_local_fragment _BENTNORMALMAP
    #pragma shader_feature_local_fragment _EMISSIVE_COLOR_MAP
    #pragma shader_feature_local_raytracing _MASKMAP
    #pragma shader_feature_local_raytracing _BENTNORMALMAP
    #pragma shader_feature_local_raytracing _EMISSIVE_COLOR_MAP

    // _ENABLESPECULAROCCLUSION keyword is obsolete but keep here for compatibility. Do not used
    // _ENABLESPECULAROCCLUSION and _SPECULAR_OCCLUSION_X can't exist at the same time (the new _SPECULAR_OCCLUSION replace it)
    // When _ENABLESPECULAROCCLUSION is found we define _SPECULAR_OCCLUSION_X so new code to work
    #pragma shader_feature_local_fragment _ENABLESPECULAROCCLUSION
    #pragma shader_feature_local_fragment _ _SPECULAR_OCCLUSION_NONE _SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP
    #pragma shader_feature_local_raytracing _ENABLESPECULAROCCLUSION
    #pragma shader_feature_local_raytracing _ _SPECULAR_OCCLUSION_NONE _SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP

    #ifdef _ENABLESPECULAROCCLUSION
    #define _SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP
    #endif

    #pragma shader_feature_local _HEIGHTMAP
    #pragma shader_feature_local_fragment _TANGENTMAP
    #pragma shader_feature_local_fragment _ANISOTROPYMAP
    #pragma shader_feature_local_fragment _DETAIL_MAP
    #pragma shader_feature_local_fragment _SUBSURFACE_MASK_MAP
    #pragma shader_feature_local_fragment _TRANSMISSION_MASK_MAP
    #pragma shader_feature_local_fragment _THICKNESSMAP
    #pragma shader_feature_local_fragment _IRIDESCENCE_THICKNESSMAP
    #pragma shader_feature_local_fragment _SPECULARCOLORMAP
    #pragma shader_feature_local_fragment _TRANSMITTANCECOLORMAP
    #pragma shader_feature_local_raytracing _TANGENTMAP
    #pragma shader_feature_local_raytracing _ANISOTROPYMAP
    #pragma shader_feature_local_raytracing _DETAIL_MAP
    #pragma shader_feature_local_raytracing _SUBSURFACE_MASK_MAP
    #pragma shader_feature_local_raytracing _THICKNESSMAP
    #pragma shader_feature_local_raytracing _IRIDESCENCE_THICKNESSMAP
    #pragma shader_feature_local_raytracing _SPECULARCOLORMAP
    #pragma shader_feature_local_raytracing _TRANSMITTANCECOLORMAP

    #pragma shader_feature_local _DISABLE_DECALS
    #pragma shader_feature_local_fragment _DISABLE_SSR
    #pragma shader_feature_local_raytracing _DISABLE_SSR
    // Bit of a mystery why this is not possible to have frequency specific.
    #pragma shader_feature_local _DISABLE_SSR_TRANSPARENT

    #pragma shader_feature_local_fragment _ENABLE_GEOMETRIC_SPECULAR_AA

    // Keyword for transparent
    #pragma shader_feature _SURFACE_TYPE_TRANSPARENT

    #pragma shader_feature_local_fragment _ENABLE_FOG_ON_TRANSPARENT
    #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC _TRANSPARENT_REFRACTIVE_SORT

    // MaterialFeature are used as shader feature to allow compiler to optimize properly
    #pragma shader_feature_local_fragment _MATERIAL_FEATURE_SUBSURFACE_SCATTERING
    #pragma shader_feature_local_fragment _MATERIAL_FEATURE_TRANSMISSION
    #pragma shader_feature_local_fragment _MATERIAL_FEATURE_ANISOTROPY
    #pragma shader_feature_local_fragment _MATERIAL_FEATURE_CLEAR_COAT
    #pragma shader_feature_local_fragment _MATERIAL_FEATURE_IRIDESCENCE
    #pragma shader_feature_local_fragment _MATERIAL_FEATURE_SPECULAR_COLOR
    #pragma shader_feature_local_raytracing _MATERIAL_FEATURE_SUBSURFACE_SCATTERING
    #pragma shader_feature_local_raytracing _MATERIAL_FEATURE_TRANSMISSION
    #pragma shader_feature_local_raytracing _MATERIAL_FEATURE_ANISOTROPY
    #pragma shader_feature_local_raytracing _MATERIAL_FEATURE_CLEAR_COAT
    #pragma shader_feature_local_raytracing _MATERIAL_FEATURE_IRIDESCENCE
    #pragma shader_feature_local_raytracing _MATERIAL_FEATURE_SPECULAR_COLOR

    #pragma shader_feature_local _ADD_PRECOMPUTED_VELOCITY

    //-------------------------------------------------------------------------------------
    // Define
    //-------------------------------------------------------------------------------------

    // Enable the support of global mip bias in the shader.
    // Only has effect if the global mip bias is enabled in shader config and DRS is enabled.
    #define SUPPORT_GLOBAL_MIP_BIAS

    // This shader support recursive rendering for raytracing
    #define HAVE_RECURSIVE_RENDERING

    // This shader support vertex modification
    #define HAVE_VERTEX_MODIFICATION

    #define SUPPORT_BLENDMODE_PRESERVE_SPECULAR_LIGHTING

    // If we use subsurface scattering, enable output split lighting (for forward pass)
    #if defined(_MATERIAL_FEATURE_SUBSURFACE_SCATTERING) && !defined(_SURFACE_TYPE_TRANSPARENT)
    #define OUTPUT_SPLIT_LIGHTING
    #endif

    #if (defined(_TRANSPARENT_WRITES_MOTION_VEC) || defined(_TRANSPARENT_REFRACTIVE_SORT)) && defined(_SURFACE_TYPE_TRANSPARENT)
    #define _WRITE_TRANSPARENT_MOTION_VECTOR
    #endif

    // Define _DEFERRED_CAPABLE_MATERIAL for shader capable to run in deferred pass
    #ifndef _SURFACE_TYPE_TRANSPARENT
    #define _DEFERRED_CAPABLE_MATERIAL
    #endif

    // In this shader, the heightmap implies depth offsets away from the camera.
    #ifdef _HEIGHTMAP
    #define _CONSERVATIVE_DEPTH_OFFSET
    #endif

    //-------------------------------------------------------------------------------------
    // Include
    //-------------------------------------------------------------------------------------

    // Disable half-precision types in the lit shader since this causes visual corruption in some cases
    #define PREFER_HALF 0

    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

    //-------------------------------------------------------------------------------------
    // variable declaration
    //-------------------------------------------------------------------------------------

    // #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.cs.hlsl"
    TEXTURE3D(_MainTex);
SAMPLER(sampler_MainTex);
TEXTURE3D(_BlicsTex);
SAMPLER(sampler_BlicsTex);
// ===========================================================================
//                              WARNING:
// On PS4, texture/sampler declarations need to be outside of CBuffers
// Otherwise those parameters are not bound correctly at runtime.
// ===========================================================================

#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/DebugMipmapStreamingMacros.hlsl"

TEXTURE2D(_EmissiveColorMap);
SAMPLER(sampler_EmissiveColorMap);

#ifndef LAYERED_LIT_SHADER

TEXTURE2D(_DiffuseLightingMap);
SAMPLER(sampler_DiffuseLightingMap);

TEXTURE2D(_BaseColorMap);
SAMPLER(sampler_BaseColorMap);

TEXTURE2D(_MaskMap);
SAMPLER(sampler_MaskMap);
TEXTURE2D(_BentNormalMap); // Reuse sampler from normal map
SAMPLER(sampler_BentNormalMap);
TEXTURE2D(_BentNormalMapOS);
SAMPLER(sampler_BentNormalMapOS);

TEXTURE2D(_NormalMap);
SAMPLER(sampler_NormalMap);
TEXTURE2D(_NormalMapOS);
SAMPLER(sampler_NormalMapOS);

TEXTURE2D(_DetailMap);
SAMPLER(sampler_DetailMap);

TEXTURE2D(_HeightMap);
SAMPLER(sampler_HeightMap);

TEXTURE2D(_TangentMap);
SAMPLER(sampler_TangentMap);
TEXTURE2D(_TangentMapOS);
SAMPLER(sampler_TangentMapOS);

TEXTURE2D(_AnisotropyMap);
SAMPLER(sampler_AnisotropyMap);

TEXTURE2D(_SubsurfaceMaskMap);
SAMPLER(sampler_SubsurfaceMaskMap);
TEXTURE2D(_TransmissionMaskMap);
SAMPLER(sampler_TransmissionMaskMap);
TEXTURE2D(_ThicknessMap);
SAMPLER(sampler_ThicknessMap);

TEXTURE2D(_IridescenceThicknessMap);
SAMPLER(sampler_IridescenceThicknessMap);

TEXTURE2D(_IridescenceMaskMap);
SAMPLER(sampler_IridescenceMaskMap);

TEXTURE2D(_SpecularColorMap);
SAMPLER(sampler_SpecularColorMap);

TEXTURE2D(_TransmittanceColorMap);
SAMPLER(sampler_TransmittanceColorMap);

TEXTURE2D(_CoatMaskMap);
SAMPLER(sampler_CoatMaskMap);

#else

// Set of users variables
#define PROP_DECL(type, name) type name##0, name##1, name##2, name##3
// sampler are share by texture type inside a layered material but we need to support that a particualr layer have no texture, so we take the first sampler of available texture as the share one
// mean we must declare all sampler
#define PROP_DECL_TEX2D(name)\
    TEXTURE2D(CALL_MERGE_NAME(name, 0)); \
    SAMPLER(CALL_MERGE_NAME(CALL_MERGE_NAME(sampler, name), 0)); \
    TEXTURE2D(CALL_MERGE_NAME(name, 1)); \
    SAMPLER(CALL_MERGE_NAME(CALL_MERGE_NAME(sampler, name), 1)); \
    TEXTURE2D(CALL_MERGE_NAME(name, 2)); \
    SAMPLER(CALL_MERGE_NAME(CALL_MERGE_NAME(sampler, name), 2)); \
    TEXTURE2D(CALL_MERGE_NAME(name, 3)); \
    SAMPLER(CALL_MERGE_NAME(CALL_MERGE_NAME(sampler, name), 3))


PROP_DECL_TEX2D(_BaseColorMap);
PROP_DECL_TEX2D(_MaskMap);
PROP_DECL_TEX2D(_BentNormalMap);
PROP_DECL_TEX2D(_NormalMap);
PROP_DECL_TEX2D(_NormalMapOS);
PROP_DECL_TEX2D(_DetailMap);
PROP_DECL_TEX2D(_HeightMap);

PROP_DECL_TEX2D(_SubsurfaceMaskMap);
PROP_DECL_TEX2D(_TransmissionMaskMap);
PROP_DECL_TEX2D(_ThicknessMap);

TEXTURE2D(_LayerMaskMap);
SAMPLER(sampler_LayerMaskMap);
TEXTURE2D(_LayerInfluenceMaskMap);
SAMPLER(sampler_LayerInfluenceMaskMap);

#endif

CBUFFER_START(UnityPerMaterial)
float4 _Color;
float _BlickIndensity;
float _Glossiness;


// shared constant between lit and layered lit
float _AlphaCutoff;
float _UseShadowThreshold;
float _AlphaCutoffShadow;
float _AlphaCutoffPrepass;
float _AlphaCutoffPostpass;
float4 _DoubleSidedConstants;
float _BlendMode;
float _EnableBlendModePreserveSpecularLighting;

float _PPDMaxSamples;
float _PPDMinSamples;
float _PPDLodThreshold;

float3 _EmissiveColor;
float _AlbedoAffectEmissive;
float _EmissiveExposureWeight;

int  _SpecularOcclusionMode;

// Transparency
float3 _TransmittanceColor;
float _Ior;
float _ATDistance;

// Caution: C# code in BaseLitUI.cs call LightmapEmissionFlagsProperty() which assume that there is an existing "_EmissionColor"
// value that exist to identify if the GI emission need to be enabled.
// In our case we don't use such a mechanism but need to keep the code quiet. We declare the value and always enable it.
// TODO: Fix the code in legacy unity so we can customize the beahvior for GI
float3 _EmissionColor;
float4 _EmissiveColorMap_ST;
float _TexWorldScaleEmissive;
float4 _UVMappingMaskEmissive;
float _ObjectSpaceUVMappingEmissive;

float4 _InvPrimScale; // Only XY are used

// Specular AA
float _EnableGeometricSpecularAA;
float _SpecularAAScreenSpaceVariance;
float _SpecularAAThreshold;

// Raytracing
float _RayTracing;

#ifndef LAYERED_LIT_SHADER

// Set of users variables
float4 _BaseColor;
float4 _BaseColorMap_ST;
float4 _BaseColorMap_TexelSize;

float _Metallic;
float _MetallicRemapMin;
float _MetallicRemapMax;
float _Smoothness;
float _SmoothnessRemapMin;
float _SmoothnessRemapMax;
float _AlphaRemapMin;
float _AlphaRemapMax;
float _AORemapMin;
float _AORemapMax;

float _NormalScale;

float4 _DetailMap_ST;
float _DetailAlbedoScale;
float _DetailNormalScale;
float _DetailSmoothnessScale;

float4 _HeightMap_TexelSize; // Unity facility. This will provide the size of the heightmap to the shader

float _HeightAmplitude;
float _HeightCenter;

float _Anisotropy;

float _DiffusionProfileHash;
float _SubsurfaceMask;
float _TransmissionMask;
float _Thickness;
float4 _ThicknessRemap;


float _IridescenceThickness;
float4 _IridescenceThicknessRemap;
float _IridescenceMask;

float _CoatMask;

float4 _SpecularColor;
float _EnergyConservingSpecularColor;

float _TexWorldScale;
float _InvTilingScale;
float4 _UVMappingMask;
float4 _UVDetailsMappingMask;
float _LinkDetailsWithBase;
float _ObjectSpaceUVMapping;

#else // LAYERED_LIT_SHADER

// Set of users variables
PROP_DECL(float4, _BaseColor);
float4 _BaseColorMap0_ST;
float4 _BaseColorMap1_ST;
float4 _BaseColorMap2_ST;
float4 _BaseColorMap3_ST;

float4 _BaseColorMap0_TexelSize;

PROP_DECL(float, _Metallic);
PROP_DECL(float, _MetallicRemapMin);
PROP_DECL(float, _MetallicRemapMax);
PROP_DECL(float, _Smoothness);
PROP_DECL(float, _SmoothnessRemapMin);
PROP_DECL(float, _SmoothnessRemapMax);
PROP_DECL(float, _AlphaRemapMin);
PROP_DECL(float, _AlphaRemapMax);
PROP_DECL(float, _AORemapMin);
PROP_DECL(float, _AORemapMax);

PROP_DECL(float, _NormalScale);
float4 _NormalMap0_TexelSize; // Unity facility. This will provide the size of the base normal to the shader

float4 _HeightMap0_TexelSize;
float4 _HeightMap1_TexelSize;
float4 _HeightMap2_TexelSize;
float4 _HeightMap3_TexelSize;

float4 _DetailMap0_ST;
float4 _DetailMap1_ST;
float4 _DetailMap2_ST;
float4 _DetailMap3_ST;
PROP_DECL(float, _UVDetail);
PROP_DECL(float, _DetailAlbedoScale);
PROP_DECL(float, _DetailNormalScale);
PROP_DECL(float, _DetailSmoothnessScale);

PROP_DECL(float, _HeightAmplitude);
PROP_DECL(float, _HeightCenter);

PROP_DECL(float, _DiffusionProfileHash);
PROP_DECL(float, _SubsurfaceMask);
PROP_DECL(float, _TransmissionMask);
PROP_DECL(float, _Thickness);
PROP_DECL(float4, _ThicknessRemap);

PROP_DECL(float, _OpacityAsDensity);
float _InheritBaseNormal1;
float _InheritBaseNormal2;
float _InheritBaseNormal3;
float _InheritBaseHeight1;
float _InheritBaseHeight2;
float _InheritBaseHeight3;
float _InheritBaseColor1;
float _InheritBaseColor2;
float _InheritBaseColor3;
PROP_DECL(float, _HeightOffset);
float _HeightTransition;

float4 _LayerMaskMap_ST;
float _TexWorldScaleBlendMask;
PROP_DECL(float, _TexWorldScale);
PROP_DECL(float, _InvTilingScale);
float4 _UVMappingMaskBlendMask;
PROP_DECL(float4, _UVMappingMask);
PROP_DECL(float4, _UVDetailsMappingMask);
PROP_DECL(float, _LinkDetailsWithBase);

#endif // LAYERED_LIT_SHADER

// Tessellation specific

#ifdef TESSELLATION_ON
float _TessellationFactor;
float _TessellationFactorMinDistance;
float _TessellationFactorMaxDistance;
float _TessellationFactorTriangleSize;
float _TessellationShapeFactor;
float _TessellationBackFaceCullEpsilon;
#endif

// Mipmap Streaming Debug
UNITY_TEXTURE_STREAMING_DEBUG_VARS;

CBUFFER_END

// Following three variables are feeded by the C++ Editor for Scene selection
// It need to be outside the UnityPerMaterial buffer to have Material compatible with SRP Batcher
int _ObjectId;
int _PassValue;
float4 _SelectionID;

#if defined(UNITY_DOTS_INSTANCING_ENABLED)
#if defined(LAYERED_LIT_SHADER)

UNITY_DOTS_INSTANCING_START(MaterialPropertyMetadata)
    UNITY_DOTS_INSTANCED_PROP(float4, _BaseColor0)
    UNITY_DOTS_INSTANCED_PROP(float4, _BaseColor1)
    UNITY_DOTS_INSTANCED_PROP(float4, _BaseColor2)
    UNITY_DOTS_INSTANCED_PROP(float4, _BaseColor3)
    UNITY_DOTS_INSTANCED_PROP(float , _Metallic0)
    UNITY_DOTS_INSTANCED_PROP(float , _Metallic1)
    UNITY_DOTS_INSTANCED_PROP(float , _Metallic2)
    UNITY_DOTS_INSTANCED_PROP(float , _Metallic3)
    UNITY_DOTS_INSTANCED_PROP(float , _MetallicRemapMin0)
    UNITY_DOTS_INSTANCED_PROP(float , _MetallicRemapMin1)
    UNITY_DOTS_INSTANCED_PROP(float , _MetallicRemapMin2)
    UNITY_DOTS_INSTANCED_PROP(float , _MetallicRemapMin3)
    UNITY_DOTS_INSTANCED_PROP(float , _MetallicRemapMax0)
    UNITY_DOTS_INSTANCED_PROP(float , _MetallicRemapMax1)
    UNITY_DOTS_INSTANCED_PROP(float , _MetallicRemapMax2)
    UNITY_DOTS_INSTANCED_PROP(float , _MetallicRemapMax3)
    UNITY_DOTS_INSTANCED_PROP(float3, _EmissiveColor)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaCutoff)
    UNITY_DOTS_INSTANCED_PROP(float , _Smoothness0)
    UNITY_DOTS_INSTANCED_PROP(float , _Smoothness1)
    UNITY_DOTS_INSTANCED_PROP(float , _Smoothness2)
    UNITY_DOTS_INSTANCED_PROP(float , _Smoothness3)
    UNITY_DOTS_INSTANCED_PROP(float , _SmoothnessRemapMin0)
    UNITY_DOTS_INSTANCED_PROP(float , _SmoothnessRemapMin1)
    UNITY_DOTS_INSTANCED_PROP(float , _SmoothnessRemapMin2)
    UNITY_DOTS_INSTANCED_PROP(float , _SmoothnessRemapMin3)
    UNITY_DOTS_INSTANCED_PROP(float , _SmoothnessRemapMax0)
    UNITY_DOTS_INSTANCED_PROP(float , _SmoothnessRemapMax1)
    UNITY_DOTS_INSTANCED_PROP(float , _SmoothnessRemapMax2)
    UNITY_DOTS_INSTANCED_PROP(float , _SmoothnessRemapMax3)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaRemapMin0)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaRemapMin1)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaRemapMin2)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaRemapMin3)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaRemapMax0)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaRemapMax1)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaRemapMax2)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaRemapMax3)
    UNITY_DOTS_INSTANCED_PROP(float , _AORemapMin0)
    UNITY_DOTS_INSTANCED_PROP(float , _AORemapMin1)
    UNITY_DOTS_INSTANCED_PROP(float , _AORemapMin2)
    UNITY_DOTS_INSTANCED_PROP(float , _AORemapMin3)
    UNITY_DOTS_INSTANCED_PROP(float , _AORemapMax0)
    UNITY_DOTS_INSTANCED_PROP(float , _AORemapMax1)
    UNITY_DOTS_INSTANCED_PROP(float , _AORemapMax2)
    UNITY_DOTS_INSTANCED_PROP(float , _AORemapMax3)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailAlbedoScale0)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailAlbedoScale1)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailAlbedoScale2)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailAlbedoScale3)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailNormalScale0)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailNormalScale1)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailNormalScale2)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailNormalScale3)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailSmoothnessScale0)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailSmoothnessScale1)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailSmoothnessScale2)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailSmoothnessScale3)
    UNITY_DOTS_INSTANCED_PROP(float , _DiffusionProfileHash0)
    UNITY_DOTS_INSTANCED_PROP(float , _DiffusionProfileHash1)
    UNITY_DOTS_INSTANCED_PROP(float , _DiffusionProfileHash2)
    UNITY_DOTS_INSTANCED_PROP(float , _DiffusionProfileHash3)
    UNITY_DOTS_INSTANCED_PROP(float , _Thickness0)
    UNITY_DOTS_INSTANCED_PROP(float , _Thickness1)
    UNITY_DOTS_INSTANCED_PROP(float , _Thickness2)
    UNITY_DOTS_INSTANCED_PROP(float , _Thickness3)
    UNITY_DOTS_INSTANCED_PROP(float4, _ThicknessRemap0)
    UNITY_DOTS_INSTANCED_PROP(float4, _ThicknessRemap1)
    UNITY_DOTS_INSTANCED_PROP(float4, _ThicknessRemap2)
    UNITY_DOTS_INSTANCED_PROP(float4, _ThicknessRemap3)
UNITY_DOTS_INSTANCING_END(MaterialPropertyMetadata)

// Here, we want to avoid overriding a property like e.g. _BaseColor0 with something like this:
// #define _BaseColor0 UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _BaseColor0)
//
// It would be simpler, but it can cause the compiler to regenerate the property loading code for each use of _BaseColor0.
//
// To avoid this, the property loads are cached in some static values at the beginning of the shader.
// The properties such as _BaseColor0 are then overridden so that it expand directly to the static value like this:
// #define _BaseColor0 unity_DOTS_Sampled_BaseColor0
//
// This simple fix happened to improve GPU performances by ~10% on Meta Quest 2 with URP on some scenes.
static float4 unity_DOTS_Sampled_BaseColor0;
static float4 unity_DOTS_Sampled_BaseColor1;
static float4 unity_DOTS_Sampled_BaseColor2;
static float4 unity_DOTS_Sampled_BaseColor3;
static float  unity_DOTS_Sampled_Metallic0;
static float  unity_DOTS_Sampled_Metallic1;
static float  unity_DOTS_Sampled_Metallic2;
static float  unity_DOTS_Sampled_Metallic3;
static float  unity_DOTS_Sampled_MetallicRemapMin0;
static float  unity_DOTS_Sampled_MetallicRemapMin1;
static float  unity_DOTS_Sampled_MetallicRemapMin2;
static float  unity_DOTS_Sampled_MetallicRemapMin3;
static float  unity_DOTS_Sampled_MetallicRemapMax0;
static float  unity_DOTS_Sampled_MetallicRemapMax1;
static float  unity_DOTS_Sampled_MetallicRemapMax2;
static float  unity_DOTS_Sampled_MetallicRemapMax3;
static float3 unity_DOTS_Sampled_EmissiveColor;
static float  unity_DOTS_Sampled_AlphaCutoff;
static float  unity_DOTS_Sampled_Smoothness0;
static float  unity_DOTS_Sampled_Smoothness1;
static float  unity_DOTS_Sampled_Smoothness2;
static float  unity_DOTS_Sampled_Smoothness3;
static float  unity_DOTS_Sampled_SmoothnessRemapMin0;
static float  unity_DOTS_Sampled_SmoothnessRemapMin1;
static float  unity_DOTS_Sampled_SmoothnessRemapMin2;
static float  unity_DOTS_Sampled_SmoothnessRemapMin3;
static float  unity_DOTS_Sampled_SmoothnessRemapMax0;
static float  unity_DOTS_Sampled_SmoothnessRemapMax1;
static float  unity_DOTS_Sampled_SmoothnessRemapMax2;
static float  unity_DOTS_Sampled_SmoothnessRemapMax3;
static float  unity_DOTS_Sampled_AlphaRemapMin0;
static float  unity_DOTS_Sampled_AlphaRemapMin1;
static float  unity_DOTS_Sampled_AlphaRemapMin2;
static float  unity_DOTS_Sampled_AlphaRemapMin3;
static float  unity_DOTS_Sampled_AlphaRemapMax0;
static float  unity_DOTS_Sampled_AlphaRemapMax1;
static float  unity_DOTS_Sampled_AlphaRemapMax2;
static float  unity_DOTS_Sampled_AlphaRemapMax3;
static float  unity_DOTS_Sampled_AORemapMin0;
static float  unity_DOTS_Sampled_AORemapMin1;
static float  unity_DOTS_Sampled_AORemapMin2;
static float  unity_DOTS_Sampled_AORemapMin3;
static float  unity_DOTS_Sampled_AORemapMax0;
static float  unity_DOTS_Sampled_AORemapMax1;
static float  unity_DOTS_Sampled_AORemapMax2;
static float  unity_DOTS_Sampled_AORemapMax3;
static float  unity_DOTS_Sampled_DetailAlbedoScale0;
static float  unity_DOTS_Sampled_DetailAlbedoScale1;
static float  unity_DOTS_Sampled_DetailAlbedoScale2;
static float  unity_DOTS_Sampled_DetailAlbedoScale3;
static float  unity_DOTS_Sampled_DetailNormalScale0;
static float  unity_DOTS_Sampled_DetailNormalScale1;
static float  unity_DOTS_Sampled_DetailNormalScale2;
static float  unity_DOTS_Sampled_DetailNormalScale3;
static float  unity_DOTS_Sampled_DetailSmoothnessScale0;
static float  unity_DOTS_Sampled_DetailSmoothnessScale1;
static float  unity_DOTS_Sampled_DetailSmoothnessScale2;
static float  unity_DOTS_Sampled_DetailSmoothnessScale3;
static float  unity_DOTS_Sampled_DiffusionProfileHash0;
static float  unity_DOTS_Sampled_DiffusionProfileHash1;
static float  unity_DOTS_Sampled_DiffusionProfileHash2;
static float  unity_DOTS_Sampled_DiffusionProfileHash3;
static float  unity_DOTS_Sampled_Thickness0;
static float  unity_DOTS_Sampled_Thickness1;
static float  unity_DOTS_Sampled_Thickness2;
static float  unity_DOTS_Sampled_Thickness3;
static float4 unity_DOTS_Sampled_ThicknessRemap0;
static float4 unity_DOTS_Sampled_ThicknessRemap1;
static float4 unity_DOTS_Sampled_ThicknessRemap2;
static float4 unity_DOTS_Sampled_ThicknessRemap3;

void SetupDOTSLayeredLitMaterialPropertyCaches()
{
    unity_DOTS_Sampled_BaseColor0               = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _BaseColor0);
    unity_DOTS_Sampled_BaseColor1               = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _BaseColor1);
    unity_DOTS_Sampled_BaseColor2               = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _BaseColor2);
    unity_DOTS_Sampled_BaseColor3               = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _BaseColor3);
    unity_DOTS_Sampled_Metallic0                = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Metallic0);
    unity_DOTS_Sampled_Metallic1                = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Metallic1);
    unity_DOTS_Sampled_Metallic2                = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Metallic2);
    unity_DOTS_Sampled_Metallic3                = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Metallic3);
    unity_DOTS_Sampled_MetallicRemapMin0        = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _MetallicRemapMin0);
    unity_DOTS_Sampled_MetallicRemapMin1        = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _MetallicRemapMin1);
    unity_DOTS_Sampled_MetallicRemapMin2        = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _MetallicRemapMin2);
    unity_DOTS_Sampled_MetallicRemapMin3        = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _MetallicRemapMin3);
    unity_DOTS_Sampled_MetallicRemapMax0        = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _MetallicRemapMax0);
    unity_DOTS_Sampled_MetallicRemapMax1        = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _MetallicRemapMax1);
    unity_DOTS_Sampled_MetallicRemapMax2        = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _MetallicRemapMax2);
    unity_DOTS_Sampled_MetallicRemapMax3        = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _MetallicRemapMax3);
    unity_DOTS_Sampled_EmissiveColor            = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float3, _EmissiveColor);
    unity_DOTS_Sampled_AlphaCutoff              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaCutoff);
    unity_DOTS_Sampled_Smoothness0              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Smoothness0);
    unity_DOTS_Sampled_Smoothness1              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Smoothness1);
    unity_DOTS_Sampled_Smoothness2              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Smoothness2);
    unity_DOTS_Sampled_Smoothness3              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Smoothness3);
    unity_DOTS_Sampled_SmoothnessRemapMin0      = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _SmoothnessRemapMin0);
    unity_DOTS_Sampled_SmoothnessRemapMin1      = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _SmoothnessRemapMin1);
    unity_DOTS_Sampled_SmoothnessRemapMin2      = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _SmoothnessRemapMin2);
    unity_DOTS_Sampled_SmoothnessRemapMin3      = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _SmoothnessRemapMin3);
    unity_DOTS_Sampled_SmoothnessRemapMax0      = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _SmoothnessRemapMax0);
    unity_DOTS_Sampled_SmoothnessRemapMax1      = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _SmoothnessRemapMax1);
    unity_DOTS_Sampled_SmoothnessRemapMax2      = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _SmoothnessRemapMax2);
    unity_DOTS_Sampled_SmoothnessRemapMax3      = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _SmoothnessRemapMax3);
    unity_DOTS_Sampled_AlphaRemapMin0           = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaRemapMin0);
    unity_DOTS_Sampled_AlphaRemapMin1           = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaRemapMin1);
    unity_DOTS_Sampled_AlphaRemapMin2           = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaRemapMin2);
    unity_DOTS_Sampled_AlphaRemapMin3           = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaRemapMin3);
    unity_DOTS_Sampled_AlphaRemapMax0           = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaRemapMax0);
    unity_DOTS_Sampled_AlphaRemapMax1           = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaRemapMax1);
    unity_DOTS_Sampled_AlphaRemapMax2           = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaRemapMax2);
    unity_DOTS_Sampled_AlphaRemapMax3           = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaRemapMax3);
    unity_DOTS_Sampled_AORemapMin0              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AORemapMin0);
    unity_DOTS_Sampled_AORemapMin1              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AORemapMin1);
    unity_DOTS_Sampled_AORemapMin2              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AORemapMin2);
    unity_DOTS_Sampled_AORemapMin3              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AORemapMin3);
    unity_DOTS_Sampled_AORemapMax0              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AORemapMax0);
    unity_DOTS_Sampled_AORemapMax1              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AORemapMax1);
    unity_DOTS_Sampled_AORemapMax2              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AORemapMax2);
    unity_DOTS_Sampled_AORemapMax3              = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AORemapMax3);
    unity_DOTS_Sampled_DetailAlbedoScale0       = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailAlbedoScale0);
    unity_DOTS_Sampled_DetailAlbedoScale1       = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailAlbedoScale1);
    unity_DOTS_Sampled_DetailAlbedoScale2       = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailAlbedoScale2);
    unity_DOTS_Sampled_DetailAlbedoScale3       = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailAlbedoScale3);
    unity_DOTS_Sampled_DetailNormalScale0       = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailNormalScale0);
    unity_DOTS_Sampled_DetailNormalScale1       = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailNormalScale1);
    unity_DOTS_Sampled_DetailNormalScale2       = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailNormalScale2);
    unity_DOTS_Sampled_DetailNormalScale3       = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailNormalScale3);
    unity_DOTS_Sampled_DetailSmoothnessScale0   = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailSmoothnessScale0);
    unity_DOTS_Sampled_DetailSmoothnessScale1   = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailSmoothnessScale1);
    unity_DOTS_Sampled_DetailSmoothnessScale2   = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailSmoothnessScale2);
    unity_DOTS_Sampled_DetailSmoothnessScale3   = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailSmoothnessScale3);
    unity_DOTS_Sampled_DiffusionProfileHash0    = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DiffusionProfileHash0);
    unity_DOTS_Sampled_DiffusionProfileHash1    = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DiffusionProfileHash1);
    unity_DOTS_Sampled_DiffusionProfileHash2    = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DiffusionProfileHash2);
    unity_DOTS_Sampled_DiffusionProfileHash3    = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DiffusionProfileHash3);
    unity_DOTS_Sampled_Thickness0               = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Thickness0);
    unity_DOTS_Sampled_Thickness1               = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Thickness1);
    unity_DOTS_Sampled_Thickness2               = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Thickness2);
    unity_DOTS_Sampled_Thickness3               = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Thickness3);
    unity_DOTS_Sampled_ThicknessRemap0          = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _ThicknessRemap0);
    unity_DOTS_Sampled_ThicknessRemap1          = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _ThicknessRemap1);
    unity_DOTS_Sampled_ThicknessRemap2          = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _ThicknessRemap2);
    unity_DOTS_Sampled_ThicknessRemap3          = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _ThicknessRemap3);
}

#undef UNITY_SETUP_DOTS_MATERIAL_PROPERTY_CACHES
#define UNITY_SETUP_DOTS_MATERIAL_PROPERTY_CACHES() SetupDOTSLayeredLitMaterialPropertyCaches()

#define _BaseColor0              unity_DOTS_Sampled_BaseColor0
#define _BaseColor1              unity_DOTS_Sampled_BaseColor1
#define _BaseColor2              unity_DOTS_Sampled_BaseColor2
#define _BaseColor3              unity_DOTS_Sampled_BaseColor3
#define _Metallic0               unity_DOTS_Sampled_Metallic0
#define _Metallic1               unity_DOTS_Sampled_Metallic1
#define _Metallic2               unity_DOTS_Sampled_Metallic2
#define _Metallic3               unity_DOTS_Sampled_Metallic3
#define _MetallicRemapMin0       unity_DOTS_Sampled_MetallicRemapMin0
#define _MetallicRemapMin1       unity_DOTS_Sampled_MetallicRemapMin1
#define _MetallicRemapMin2       unity_DOTS_Sampled_MetallicRemapMin2
#define _MetallicRemapMin3       unity_DOTS_Sampled_MetallicRemapMin3
#define _MetallicRemapMax0       unity_DOTS_Sampled_MetallicRemapMax0
#define _MetallicRemapMax1       unity_DOTS_Sampled_MetallicRemapMax1
#define _MetallicRemapMax2       unity_DOTS_Sampled_MetallicRemapMax2
#define _MetallicRemapMax3       unity_DOTS_Sampled_MetallicRemapMax3
#define _EmissiveColor           unity_DOTS_Sampled_EmissiveColor
#define _AlphaCutoff             unity_DOTS_Sampled_AlphaCutoff
#define _Smoothness0             unity_DOTS_Sampled_Smoothness0
#define _Smoothness1             unity_DOTS_Sampled_Smoothness1
#define _Smoothness2             unity_DOTS_Sampled_Smoothness2
#define _Smoothness3             unity_DOTS_Sampled_Smoothness3
#define _SmoothnessRemapMin0     unity_DOTS_Sampled_SmoothnessRemapMin0
#define _SmoothnessRemapMin1     unity_DOTS_Sampled_SmoothnessRemapMin1
#define _SmoothnessRemapMin2     unity_DOTS_Sampled_SmoothnessRemapMin2
#define _SmoothnessRemapMin3     unity_DOTS_Sampled_SmoothnessRemapMin3
#define _SmoothnessRemapMax0     unity_DOTS_Sampled_SmoothnessRemapMax0
#define _SmoothnessRemapMax1     unity_DOTS_Sampled_SmoothnessRemapMax1
#define _SmoothnessRemapMax2     unity_DOTS_Sampled_SmoothnessRemapMax2
#define _SmoothnessRemapMax3     unity_DOTS_Sampled_SmoothnessRemapMax3
#define _AlphaRemapMin0          unity_DOTS_Sampled_AlphaRemapMin0
#define _AlphaRemapMin1          unity_DOTS_Sampled_AlphaRemapMin1
#define _AlphaRemapMin2          unity_DOTS_Sampled_AlphaRemapMin2
#define _AlphaRemapMin3          unity_DOTS_Sampled_AlphaRemapMin3
#define _AlphaRemapMax0          unity_DOTS_Sampled_AlphaRemapMax0
#define _AlphaRemapMax1          unity_DOTS_Sampled_AlphaRemapMax1
#define _AlphaRemapMax2          unity_DOTS_Sampled_AlphaRemapMax2
#define _AlphaRemapMax3          unity_DOTS_Sampled_AlphaRemapMax3
#define _AORemapMin0             unity_DOTS_Sampled_AORemapMin0
#define _AORemapMin1             unity_DOTS_Sampled_AORemapMin1
#define _AORemapMin2             unity_DOTS_Sampled_AORemapMin2
#define _AORemapMin3             unity_DOTS_Sampled_AORemapMin3
#define _AORemapMax0             unity_DOTS_Sampled_AORemapMax0
#define _AORemapMax1             unity_DOTS_Sampled_AORemapMax1
#define _AORemapMax2             unity_DOTS_Sampled_AORemapMax2
#define _AORemapMax3             unity_DOTS_Sampled_AORemapMax3
#define _DetailAlbedoScale0      unity_DOTS_Sampled_DetailAlbedoScale0
#define _DetailAlbedoScale1      unity_DOTS_Sampled_DetailAlbedoScale1
#define _DetailAlbedoScale2      unity_DOTS_Sampled_DetailAlbedoScale2
#define _DetailAlbedoScale3      unity_DOTS_Sampled_DetailAlbedoScale3
#define _DetailNormalScale0      unity_DOTS_Sampled_DetailNormalScale0
#define _DetailNormalScale1      unity_DOTS_Sampled_DetailNormalScale1
#define _DetailNormalScale2      unity_DOTS_Sampled_DetailNormalScale2
#define _DetailNormalScale3      unity_DOTS_Sampled_DetailNormalScale3
#define _DetailSmoothnessScale0  unity_DOTS_Sampled_DetailSmoothnessScale0
#define _DetailSmoothnessScale1  unity_DOTS_Sampled_DetailSmoothnessScale1
#define _DetailSmoothnessScale2  unity_DOTS_Sampled_DetailSmoothnessScale2
#define _DetailSmoothnessScale3  unity_DOTS_Sampled_DetailSmoothnessScale3
#define _DiffusionProfileHash0   unity_DOTS_Sampled_DiffusionProfileHash0
#define _DiffusionProfileHash1   unity_DOTS_Sampled_DiffusionProfileHash1
#define _DiffusionProfileHash2   unity_DOTS_Sampled_DiffusionProfileHash2
#define _DiffusionProfileHash3   unity_DOTS_Sampled_DiffusionProfileHash3
#define _Thickness0              unity_DOTS_Sampled_Thickness0
#define _Thickness1              unity_DOTS_Sampled_Thickness1
#define _Thickness2              unity_DOTS_Sampled_Thickness2
#define _Thickness3              unity_DOTS_Sampled_Thickness3
#define _ThicknessRemap0         unity_DOTS_Sampled_ThicknessRemap0
#define _ThicknessRemap1         unity_DOTS_Sampled_ThicknessRemap1
#define _ThicknessRemap2         unity_DOTS_Sampled_ThicknessRemap2
#define _ThicknessRemap3         unity_DOTS_Sampled_ThicknessRemap3

#else

UNITY_DOTS_INSTANCING_START(MaterialPropertyMetadata)
    UNITY_DOTS_INSTANCED_PROP(float4, _BaseColor)
    UNITY_DOTS_INSTANCED_PROP(float , _Metallic)
    UNITY_DOTS_INSTANCED_PROP(float , _MetallicRemapMin)
    UNITY_DOTS_INSTANCED_PROP(float , _MetallicRemapMax)
    UNITY_DOTS_INSTANCED_PROP(float3, _EmissiveColor)
    UNITY_DOTS_INSTANCED_PROP(float4, _SpecularColor)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaCutoff);
    UNITY_DOTS_INSTANCED_PROP(float , _Smoothness)
    UNITY_DOTS_INSTANCED_PROP(float , _SmoothnessRemapMin)
    UNITY_DOTS_INSTANCED_PROP(float , _SmoothnessRemapMax)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaRemapMin)
    UNITY_DOTS_INSTANCED_PROP(float , _AlphaRemapMax)
    UNITY_DOTS_INSTANCED_PROP(float , _AORemapMin)
    UNITY_DOTS_INSTANCED_PROP(float , _AORemapMax)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailAlbedoScale)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailNormalScale)
    UNITY_DOTS_INSTANCED_PROP(float , _DetailSmoothnessScale)
    UNITY_DOTS_INSTANCED_PROP(float , _DiffusionProfileHash)
    UNITY_DOTS_INSTANCED_PROP(float , _Thickness)
    UNITY_DOTS_INSTANCED_PROP(float4, _ThicknessRemap)
UNITY_DOTS_INSTANCING_END(MaterialPropertyMetadata)

// Here, we want to avoid overriding a property like e.g. _BaseColor with something like this:
// #define _BaseColor UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _BaseColor0)
//
// It would be simpler, but it can cause the compiler to regenerate the property loading code for each use of _BaseColor.
//
// To avoid this, the property loads are cached in some static values at the beginning of the shader.
// The properties such as _BaseColor are then overridden so that it expand directly to the static value like this:
// #define _BaseColor unity_DOTS_Sampled_BaseColor
//
// This simple fix happened to improve GPU performances by ~10% on Meta Quest 2 with URP on some scenes.
static float4 unity_DOTS_Sampled_BaseColor;
static float  unity_DOTS_Sampled_Metallic;
static float  unity_DOTS_Sampled_MetallicRemapMin;
static float  unity_DOTS_Sampled_MetallicRemapMax;
static float3 unity_DOTS_Sampled_EmissiveColor;
static float4 unity_DOTS_Sampled_SpecularColor;
static float  unity_DOTS_Sampled_AlphaCutoff;;
static float  unity_DOTS_Sampled_Smoothness;
static float  unity_DOTS_Sampled_SmoothnessRemapMin;
static float  unity_DOTS_Sampled_SmoothnessRemapMax;
static float  unity_DOTS_Sampled_AlphaRemapMin;
static float  unity_DOTS_Sampled_AlphaRemapMax;
static float  unity_DOTS_Sampled_AORemapMin;
static float  unity_DOTS_Sampled_AORemapMax;
static float  unity_DOTS_Sampled_DetailAlbedoScale;
static float  unity_DOTS_Sampled_DetailNormalScale;
static float  unity_DOTS_Sampled_DetailSmoothnessScale;
static float  unity_DOTS_Sampled_DiffusionProfileHash;
static float  unity_DOTS_Sampled_Thickness;
static float4 unity_DOTS_Sampled_ThicknessRemap;

void SetupDOTSLitMaterialPropertyCaches()
{
    unity_DOTS_Sampled_BaseColor = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _BaseColor);
    unity_DOTS_Sampled_Metallic = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Metallic);
    unity_DOTS_Sampled_MetallicRemapMin = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _MetallicRemapMin);
    unity_DOTS_Sampled_MetallicRemapMax = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _MetallicRemapMax);
    unity_DOTS_Sampled_Smoothness = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Smoothness);
    unity_DOTS_Sampled_EmissiveColor = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float3, _EmissiveColor);
    unity_DOTS_Sampled_SpecularColor = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _SpecularColor);
    unity_DOTS_Sampled_AlphaCutoff = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaCutoff);
    unity_DOTS_Sampled_Smoothness = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Smoothness);
    unity_DOTS_Sampled_SmoothnessRemapMin = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _SmoothnessRemapMin);
    unity_DOTS_Sampled_SmoothnessRemapMax = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _SmoothnessRemapMax);
    unity_DOTS_Sampled_AlphaRemapMin = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaRemapMin);
    unity_DOTS_Sampled_AlphaRemapMax = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AlphaRemapMax);
    unity_DOTS_Sampled_AORemapMin = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AORemapMin);
    unity_DOTS_Sampled_AORemapMax = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _AORemapMax);
    unity_DOTS_Sampled_DetailAlbedoScale = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailAlbedoScale);
    unity_DOTS_Sampled_DetailNormalScale = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailNormalScale);
    unity_DOTS_Sampled_DetailSmoothnessScale = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DetailSmoothnessScale);
    unity_DOTS_Sampled_DiffusionProfileHash = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _DiffusionProfileHash);
    unity_DOTS_Sampled_Thickness = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float , _Thickness);
    unity_DOTS_Sampled_ThicknessRemap = UNITY_ACCESS_DOTS_INSTANCED_PROP_WITH_DEFAULT(float4, _ThicknessRemap);
}

#undef UNITY_SETUP_DOTS_MATERIAL_PROPERTY_CACHES
#define UNITY_SETUP_DOTS_MATERIAL_PROPERTY_CACHES() SetupDOTSLitMaterialPropertyCaches()

#define _BaseColor             unity_DOTS_Sampled_BaseColor
#define _Metallic              unity_DOTS_Sampled_Metallic
#define _MetallicRemapMin      unity_DOTS_Sampled_MetallicRemapMin
#define _MetallicRemapMax      unity_DOTS_Sampled_MetallicRemapMax
#define _Smoothness            unity_DOTS_Sampled_Smoothness
#define _EmissiveColor         unity_DOTS_Sampled_EmissiveColor
#define _SpecularColor         unity_DOTS_Sampled_SpecularColor
#define _AlphaCutoff           unity_DOTS_Sampled_AlphaCutoff
#define _Smoothness            unity_DOTS_Sampled_Smoothness
#define _SmoothnessRemapMin    unity_DOTS_Sampled_SmoothnessRemapMin
#define _SmoothnessRemapMax    unity_DOTS_Sampled_SmoothnessRemapMax
#define _AlphaRemapMin         unity_DOTS_Sampled_AlphaRemapMin
#define _AlphaRemapMax         unity_DOTS_Sampled_AlphaRemapMax
#define _AORemapMin            unity_DOTS_Sampled_AORemapMin
#define _AORemapMax            unity_DOTS_Sampled_AORemapMax
#define _DetailAlbedoScale     unity_DOTS_Sampled_DetailAlbedoScale
#define _DetailNormalScale     unity_DOTS_Sampled_DetailNormalScale
#define _DetailSmoothnessScale unity_DOTS_Sampled_DetailSmoothnessScale
#define _DiffusionProfileHash  unity_DOTS_Sampled_DiffusionProfileHash
#define _Thickness             unity_DOTS_Sampled_Thickness
#define _ThicknessRemap        unity_DOTS_Sampled_ThicknessRemap

#endif
#endif


    // TODO:
    // Currently, Lit.hlsl and LitData.hlsl are included for every pass. Split Lit.hlsl in two:
    // LitData.hlsl and LitShading.hlsl (merge into the existing LitData.hlsl).
    // LitData.hlsl should be responsible for preparing shading parameters.
    // LitShading.hlsl implements the light loop API.
    // LitData.hlsl is included here, LitShading.hlsl is included below for shading passes only.

    ENDHLSL

    SubShader
    {
        // This tags allow to use the shader replacement features
        Tags{ "RenderPipeline"="HDRenderPipeline" "RenderType" = "HDLitShader" }

        Pass
        {
            Name "ScenePickingPass"
            Tags { "LightMode" = "Picking" }

            Cull [_CullMode]

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch

            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            // Note: Require _SelectionID variable

            // We reuse depth prepass for the scene selection, allow to handle alpha correctly as well as tessellation and vertex animation
            #define SHADERPASS SHADERPASS_DEPTH_ONLY
            #define SCENEPICKINGPASS
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/PickingSpaceTransforms.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitDepthPass.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            #pragma editor_sync_compilation

            ENDHLSL
        }

        Pass
        {
            Name "SceneSelectionPass"
            Tags { "LightMode" = "SceneSelectionPass" }

            Cull Off

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch

            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            // Note: Require _ObjectId and _PassValue variables

            // We reuse depth prepass for the scene selection, allow to handle alpha correctly as well as tessellation and vertex animation
            #define SHADERPASS SHADERPASS_DEPTH_ONLY
            #define SCENESELECTIONPASS // This will drive the output of the scene selection shader
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/PickingSpaceTransforms.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitDepthPass.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            #pragma editor_sync_compilation

            ENDHLSL
        }

        // Caution: The outline selection in the editor use the vertex shader/hull/domain shader of the first pass declare. So it should not bethe  meta pass.
        Pass
        {
            Name "GBuffer"
            Tags { "LightMode" = "GBuffer" } // This will be only for opaque object based on the RenderQueue index

            Cull [_CullMode]
            ZTest [_ZTestGBuffer]

            Stencil
            {
                WriteMask [_StencilWriteMaskGBuffer]
                Ref [_StencilRefGBuffer]
                Comp Always
                Pass Replace
            }

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            #pragma multi_compile _ DEBUG_DISPLAY
            // 'Optimize Mesh Data' strip away attribute uv1/uv2 without the keyword set on the vertex stage.
            #pragma multi_compile _ LIGHTMAP_ON
            // Both DIRLIGHTMAP_COMBINED and DYNAMICLIGHTMAP_ON must have vertex frequency to be able to include UV2 in player
            // If DIRLIGHTMAP_COMBINED isn't define, then DYNAMICLIGHTMAP_ON will not. This is hardcoded in C++
            // For ShaderGraph we don't have this issue as UV2 are always included.
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ DYNAMICLIGHTMAP_ON
            #pragma multi_compile _ USE_LEGACY_LIGHTMAPS
            #pragma multi_compile_fragment _ SHADOWS_SHADOWMASK
            #pragma multi_compile_fragment _ PROBE_VOLUMES_L1 PROBE_VOLUMES_L2
            // Setup DECALS_OFF so the shader stripper can remove variants
            #pragma multi_compile_fragment DECALS_OFF DECALS_3RT DECALS_4RT
            #pragma multi_compile_fragment _ DECAL_SURFACE_GRADIENT
            #pragma multi_compile_fragment _ RENDERING_LAYERS

        #ifndef DEBUG_DISPLAY
            // When we have alpha test, we will force a depth prepass so we always bypass the clip instruction in the GBuffer
            // Don't do it with debug display mode as it is possible there is no depth prepass in this case
            #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
        #endif

            #define SHADERPASS SHADERPASS_GBUFFER
            #ifdef DEBUG_DISPLAY
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
            #endif
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER


            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassGBuffer.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            ENDHLSL
        }

        // Extracts information for lightmapping, GI (emission, albedo, ...)
        // This pass is not used during regular rendering.
        Pass
        {
            Name "META"
            Tags{ "LightMode" = "META" }

            Cull Off

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma shader_feature EDITOR_VISUALIZATION
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            // Lightmap memo
            // DYNAMICLIGHTMAP_ON is used when we have an "enlighten lightmap" ie a lightmap updated at runtime by enlighten.This lightmap contain indirect lighting from realtime lights and realtime emissive material.Offline baked lighting(from baked material / light,
            // both direct and indirect lighting) will hand up in the "regular" lightmap->LIGHTMAP_ON.

            #define SHADERPASS SHADERPASS_LIGHT_TRANSPORT

            // Use Unity's built-in matrices for meta pass rendering
            #define SCENEPICKINGPASS
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/PickingSpaceTransforms.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassLightTransport.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            ENDHLSL
        }

        Pass
        {
            Name "ShadowCaster"
            Tags{ "LightMode" = "ShadowCaster" }

            Cull[_CullMode]

            ZClip [_ZClip]
            ZWrite On
            ZTest LEqual

            ColorMask 0

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            #define SHADERPASS SHADERPASS_SHADOWS
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitDepthPass.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            ENDHLSL
        }

        Pass
        {
            Name "DepthOnly"
            Tags{ "LightMode" = "DepthOnly" }

            Cull[_CullMode]
            AlphaToMask [_AlphaCutoffEnable]

            // To be able to tag stencil with disableSSR information for forward
            Stencil
            {
                WriteMask [_StencilWriteMaskDepth]
                Ref [_StencilRefDepth]
                Comp Always
                Pass Replace
            }

            ZWrite On

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            // In deferred, depth only pass don't output anything.
            // In forward it output the normal buffer
            #pragma multi_compile _ WRITE_NORMAL_BUFFER
            #pragma multi_compile_fragment _ WRITE_MSAA_DEPTH
            #pragma multi_compile _ WRITE_DECAL_BUFFER WRITE_RENDERING_LAYER

            #define SHADERPASS SHADERPASS_DEPTH_ONLY
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"

            #ifdef WRITE_NORMAL_BUFFER // If enabled we need all regular interpolator
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            #else
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitDepthPass.hlsl"
            #endif

            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            ENDHLSL
        }

        Pass
        {
            Name "MotionVectors"
            Tags{ "LightMode" = "MotionVectors" } // Caution, this need to be call like this to setup the correct parameters by C++ (legacy Unity)

            // If velocity pass (motion vectors) is enabled we tag the stencil so it don't perform CameraMotionVelocity
            Stencil
            {
                WriteMask [_StencilWriteMaskMV]
                Ref [_StencilRefMV]
                Comp Always
                Pass Replace
            }

            Cull[_CullMode]
            AlphaToMask [_AlphaCutoffEnable]

            ZWrite On

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            #pragma multi_compile _ WRITE_NORMAL_BUFFER
            #pragma multi_compile_fragment _ WRITE_MSAA_DEPTH
            #pragma multi_compile _ WRITE_DECAL_BUFFER_AND_RENDERING_LAYER

            // We can't name this keyword WRITE_DECAL_BUFFER directly because we want to enable it at a different
            // frequency than WRITE_DECAL_BUFFER defined in the DepthForwardOnly pass
            #ifdef WRITE_DECAL_BUFFER_AND_RENDERING_LAYER
            #define WRITE_DECAL_BUFFER
            #endif

            #define SHADERPASS SHADERPASS_MOTION_VECTORS
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #ifdef WRITE_NORMAL_BUFFER // If enabled we need all regular interpolator
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            #else
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitMotionVectorPass.hlsl"
            #endif
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassMotionVectors.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            ENDHLSL
        }

        Pass
        {
            Name "TransparentDepthPrepass"
            Tags{ "LightMode" = "TransparentDepthPrepass" }

            // To be able to tag stencil with disableSSR information for transparentObjects
            Stencil
            {
                WriteMask [_StencilWriteMaskDepth]
                Ref [_StencilRefDepth]
                Comp Always
                Pass Replace
            }

            Cull[_CullMode]
            ZWrite On

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            #define SHADERPASS SHADERPASS_TRANSPARENT_DEPTH_PREPASS

            // If the transparent surface should have reflections, then we should output normal
            #if !defined(_DISABLE_SSR_TRANSPARENT)
                #define WRITE_NORMAL_BUFFER
            #endif

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #ifdef WRITE_NORMAL_BUFFER // If enabled we need all regular interpolator
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            #else
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitDepthPass.hlsl"
            #endif
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            ENDHLSL
        }

        // Caution: Order is important: TransparentBackface, then Forward/ForwardOnly
        Pass
        {
            Name "TransparentBackface"
            Tags { "LightMode" = "TransparentBackface" }

            Blend [_SrcBlend] [_DstBlend], [_AlphaSrcBlend] [_AlphaDstBlend]
            Blend 1 One OneMinusSrcAlpha // target 1 alpha blend required for VT feedback. All other uses will pass 1.
            Blend 2 One OneMinusSrcAlpha // before refraction
            Blend 3 One OneMinusSrcAlpha // before refraction alpha
            Blend 4 One OneMinusSrcAlpha // all targets are shifted by 1 when using VT

            ZWrite [_ZWrite]
            Cull Front
            ColorMask [_ColorMaskTransparentVelOne] 1
            ColorMask [_ColorMaskTransparentVelTwo] 2
            ZTest [_ZTestTransparent]

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            #pragma multi_compile _ DEBUG_DISPLAY
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ DYNAMICLIGHTMAP_ON
            #pragma multi_compile _ USE_LEGACY_LIGHTMAPS
            #pragma multi_compile_fragment _ SHADOWS_SHADOWMASK
            #pragma multi_compile_fragment _ PROBE_VOLUMES_L1 PROBE_VOLUMES_L2
            #pragma multi_compile_fragment SCREEN_SPACE_SHADOWS_OFF SCREEN_SPACE_SHADOWS_ON
            // Setup DECALS_OFF so the shader stripper can remove variants
            #pragma multi_compile_fragment DECALS_OFF DECALS_3RT DECALS_4RT
            #pragma multi_compile_fragment _ DECAL_SURFACE_GRADIENT

            // Supported shadow modes per light type
	        #pragma multi_compile_fragment PUNCTUAL_SHADOW_LOW PUNCTUAL_SHADOW_MEDIUM PUNCTUAL_SHADOW_HIGH
	        #pragma multi_compile_fragment DIRECTIONAL_SHADOW_LOW DIRECTIONAL_SHADOW_MEDIUM DIRECTIONAL_SHADOW_HIGH
            #pragma multi_compile_fragment AREA_SHADOW_MEDIUM AREA_SHADOW_HIGH

            #ifndef SHADER_STAGE_FRAGMENT
            #define SHADOW_LOW
            #endif

            #define USE_CLUSTERED_LIGHTLIST // There is not FPTL lighting when using transparent

            #define SHADERPASS SHADERPASS_FORWARD
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

        #ifdef DEBUG_DISPLAY
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
        #endif

            // The light loop (or lighting architecture) is in charge to:
            // - Define light list
            // - Define the light loop
            // - Setup the constant/data
            // - Do the reflection hierarchy
            // - Provide sampling function for shadowmap, ies, cookie and reflection (depends on the specific use with the light loops like index array or atlas or single and texture format (cubemap/latlong))

            #define HAS_LIGHTLOOP

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoop.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassForward.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            ENDHLSL
        }

        Pass
        {
            Name "Forward"
            Tags { "LightMode" = "Forward" } // This will be only for transparent object based on the RenderQueue index

            Stencil
            {
                WriteMask [_StencilWriteMask]
                Ref [_StencilRef]
                Comp Always
                Pass Replace
            }

            Blend [_SrcBlend] [_DstBlend], [_AlphaSrcBlend] [_AlphaDstBlend]
                                         // ForwardOpaque      | ForwardTransparent
            Blend 1 One OneMinusSrcAlpha //  VT feedback       |  VT feedback        <- if VT is off, all targets below are shifted by 1
            Blend 2 One [_DstBlend2]     //  diffuse lighting  |  motion vector
            Blend 3 One [_DstBlend2]     //  SSS buffer        |  before refraction  <- This target (or the one above if VT off) needs blending in transparent but not in opaque
            Blend 4 One OneMinusSrcAlpha //                    |  before refraction alpha

            // In case of forward we want to have depth equal for opaque mesh
            ZTest [_ZTestDepthEqualForOpaque]
            ZWrite [_ZWrite]
            Cull [_CullModeForward]
            // Not possible to control the render target with a variable
            // Depending on virtual texturing, motion vector buffer can be bound on either SV_Target1 or SV_Target2
            ColorMask [_ColorMaskTransparentVelOne] 1
            ColorMask [_ColorMaskTransparentVelTwo] 2

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            #pragma multi_compile _ DEBUG_DISPLAY
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ DYNAMICLIGHTMAP_ON
            #pragma multi_compile _ USE_LEGACY_LIGHTMAPS
            #pragma multi_compile_fragment _ SHADOWS_SHADOWMASK
            #pragma multi_compile_fragment _ PROBE_VOLUMES_L1 PROBE_VOLUMES_L2
            #pragma multi_compile_fragment SCREEN_SPACE_SHADOWS_OFF SCREEN_SPACE_SHADOWS_ON
            // Setup DECALS_OFF so the shader stripper can remove variants
            #pragma multi_compile_fragment DECALS_OFF DECALS_3RT DECALS_4RT
            #pragma multi_compile_fragment _ DECAL_SURFACE_GRADIENT

            // Supported shadow modes per light type
	        #pragma multi_compile_fragment PUNCTUAL_SHADOW_LOW PUNCTUAL_SHADOW_MEDIUM PUNCTUAL_SHADOW_HIGH
	        #pragma multi_compile_fragment DIRECTIONAL_SHADOW_LOW DIRECTIONAL_SHADOW_MEDIUM DIRECTIONAL_SHADOW_HIGH
            #pragma multi_compile_fragment AREA_SHADOW_MEDIUM AREA_SHADOW_HIGH

            #pragma multi_compile_fragment USE_FPTL_LIGHTLIST USE_CLUSTERED_LIGHTLIST

            #ifndef SHADER_STAGE_FRAGMENT
            #define SHADOW_LOW
            #define USE_FPTL_LIGHTLIST
            #endif

            #define SHADERPASS SHADERPASS_FORWARD
            // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
            // Don't do it with debug display mode as it is possible there is no depth prepass in this case
            #if !defined(_SURFACE_TYPE_TRANSPARENT) && !defined(DEBUG_DISPLAY)
                #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
            #endif
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

        #ifdef DEBUG_DISPLAY
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
        #endif

            // The light loop (or lighting architecture) is in charge to:
            // - Define light list
            // - Define the light loop
            // - Setup the constant/data
            // - Do the reflection hierarchy
            // - Provide sampling function for shadowmap, ies, cookie and reflection (depends on the specific use with the light loops like index array or atlas or single and texture format (cubemap/latlong))

            #define HAS_LIGHTLOOP

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoop.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassForward.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            ENDHLSL
        }

        Pass
        {
            Name "TransparentDepthPostpass"
            Tags { "LightMode" = "TransparentDepthPostpass" }

            Cull[_CullMode]
            ZWrite On
            ColorMask 0

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            #define SHADERPASS SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitDepthPass.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            ENDHLSL
        }

        Pass
        {
            Name "RayTracingPrepass"
            Tags{ "LightMode" = "RayTracingPrepass" }

            Cull[_CullMode]

            ZWrite On
            ZTest LEqual // If the object have already been render in depth prepass, it will re-render to tag stencil

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            #define SHADERPASS SHADERPASS_CONSTANT
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitConstantPass.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassConstant.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            ENDHLSL
        }

        Pass
        {
            Name "FullScreenDebug"
            Tags{ "LightMode" = "FullScreenDebug" }

            Cull[_CullMode]

            ZWrite Off
            ZTest LEqual

            HLSLPROGRAM

            #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
            //enable GPU instancing support
            #pragma multi_compile_instancing
            #pragma instancing_options renderinglayer
            #pragma multi_compile _ DOTS_INSTANCING_ON
            // enable dithering LOD crossfade
            #pragma multi_compile _ LOD_FADE_CROSSFADE

            #define SHADERPASS SHADERPASS_FULL_SCREEN_DEBUG
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassFullScreenDebug.hlsl"

            #pragma vertex Vert
            #pragma fragment Frag

            ENDHLSL
        }
    }

    SubShader
    {
        Tags{ "RenderPipeline"="HDRenderPipeline" }
        Pass
        {
            Name "IndirectDXR"
            Tags{ "LightMode" = "IndirectDXR" }

            HLSLPROGRAM

            #pragma only_renderers d3d11 xboxseries ps5
            #pragma raytracing surface_shader

            #pragma multi_compile _ DEBUG_DISPLAY
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile _ DYNAMICLIGHTMAP_ON
            #pragma multi_compile _ PROBE_VOLUMES_L1 PROBE_VOLUMES_L2
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED

            #define SHADERPASS SHADERPASS_RAYTRACING_INDIRECT

            // multi compile that allows us to strip the recursive code
            #pragma multi_compile _ MULTI_BOUNCE_INDIRECT

            #pragma multi_compile DECALS_OFF DECALS_3RT DECALS_4RT
            #pragma multi_compile _ DECAL_SURFACE_GRADIENT

            // If you need to change this, be sure to read this comment.
            // For raytracing we decided to force the shadow quality to low.
            // - The performance is the first reason, given that it may happen during the ray tracing stage for indirect or in a non-tiled context for deferred
            // we want to save that cost as it may increase signfiicantly the cost..
            // - The second reason is that some filtering modes require the screen space position (at the moment you read this comment high and ultra high), which we cannot provide
            // in a ray tracing context.
            // In addition to that, we intentionally disabled dithering for the ray tracing case as it requires the screen space position.
            #define SHADOW_LOW

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracingLightLoop.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingIntersection.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
            #define HAS_LIGHTLOOP
            #define PATH_TRACING_CLUSTERED_DECALS
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitRayTracing.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingLightLoop.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RayTracingCommon.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassRaytracingIndirect.hlsl"

            ENDHLSL
        }

        Pass
        {
            Name "ForwardDXR"
            Tags{ "LightMode" = "ForwardDXR" }

            HLSLPROGRAM

            #pragma only_renderers d3d11 xboxseries ps5
            #pragma raytracing surface_shader

            #pragma multi_compile _ DEBUG_DISPLAY
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile _ DYNAMICLIGHTMAP_ON
            #pragma multi_compile _ PROBE_VOLUMES_L1 PROBE_VOLUMES_L2
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile DECALS_OFF DECALS_3RT DECALS_4RT
            #pragma multi_compile _ DECAL_SURFACE_GRADIENT

            #define SHADERPASS SHADERPASS_RAYTRACING_FORWARD

            // If you need to change this, be sure to read this comment.
            // For raytracing we decided to force the shadow quality to low.
            // - The performance is the first reason, given that it may happen during the ray tracing stage for indirect or in a non-tiled context for deferred
            // we want to save that cost as it may increase signfiicantly the cost..
            // - The second reason is that some filtering modes require the screen space position (at the moment you read this comment high and ultra high), which we cannot provide
            // in a ray tracing context.
            // In addition to that, we intentionally disabled dithering for the ray tracing case as it requires the screen space position.
            #define SHADOW_LOW

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracingLightLoop.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingIntersection.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
            #define HAS_LIGHTLOOP
            #define PATH_TRACING_CLUSTERED_DECALS
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitRayTracing.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingLightLoop.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RayTracingCommon.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassRaytracingForward.hlsl"

            ENDHLSL
        }

        Pass
        {
            Name "GBufferDXR"
            Tags{ "LightMode" = "GBufferDXR" }

            HLSLPROGRAM

            #pragma only_renderers d3d11 xboxseries ps5
            #pragma raytracing surface_shader

            #pragma multi_compile _ DEBUG_DISPLAY
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile _ DYNAMICLIGHTMAP_ON
            #pragma multi_compile _ PROBE_VOLUMES_L1 PROBE_VOLUMES_L2
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ MINIMAL_GBUFFER

            #pragma multi_compile DECALS_OFF DECALS_3RT DECALS_4RT
            #pragma multi_compile _ DECAL_SURFACE_GRADIENT

            #define SHADERPASS SHADERPASS_RAYTRACING_GBUFFER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracingLightLoop.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/Deferred/RaytracingIntersectonGBuffer.hlsl"

            #define PATH_TRACING_CLUSTERED_DECALS
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/StandardLit/StandardLit.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RayTracingCommon.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitRayTracing.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassRaytracingGBuffer.hlsl"

            ENDHLSL
        }

        Pass
        {
            Name "VisibilityDXR"
            Tags{ "LightMode" = "VisibilityDXR" }

            HLSLPROGRAM

            #pragma only_renderers d3d11 xboxseries ps5
            #pragma raytracing surface_shader

            #define SHADERPASS SHADERPASS_RAYTRACING_VISIBILITY
            #pragma multi_compile _ TRANSPARENT_COLOR_SHADOW

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingIntersection.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RayTracingCommon.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassRaytracingVisibility.hlsl"

            ENDHLSL
        }

        Pass
        {
            Name "SubSurfaceDXR"
            Tags{ "LightMode" = "SubSurfaceDXR" }

            HLSLPROGRAM

            #pragma only_renderers d3d11 xboxseries ps5
            #pragma raytracing surface_shader

            #pragma multi_compile _ DEBUG_DISPLAY
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile _ DYNAMICLIGHTMAP_ON
            #pragma multi_compile _ PROBE_VOLUMES_L1 PROBE_VOLUMES_L2
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED

            #define SHADERPASS SHADERPASS_RAYTRACING_SUB_SURFACE

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/SubSurface/RayTracingIntersectionSubSurface.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RayTracingCommon.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassRayTracingSubSurface.hlsl"

            ENDHLSL
        }

        Pass
        {
            Name "DebugDXR"
            Tags{ "LightMode" = "DebugDXR" }

            HLSLPROGRAM

            #pragma only_renderers d3d11 xboxseries ps5
            #pragma raytracing surface_shader

            #define SHADERPASS SHADERPASS_RAYTRACING_DEBUG

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingIntersection.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RayTracingCommon.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassRayTracingDebug.hlsl"

            ENDHLSL
        }

        Pass
        {
            Name "PathTracingDXR"
            Tags{ "LightMode" = "PathTracingDXR" }

            HLSLPROGRAM

            #pragma only_renderers d3d11 xboxseries ps5
            #pragma raytracing surface_shader

            #pragma multi_compile _ DEBUG_DISPLAY
            #pragma multi_compile _ SENSORSDK_OVERRIDE_REFLECTANCE

            #ifdef SENSORSDK_OVERRIDE_REFLECTANCE
                #define SENSORSDK_ENABLE_LIDAR
            #endif

            #define SHADERPASS SHADERPASS_PATH_TRACING

            #pragma multi_compile DECALS_OFF DECALS_3RT DECALS_4RT
            #pragma multi_compile _ DECAL_SURFACE_GRADIENT

            // This is just because it needs to be defined, shadow maps are not used.
            #define SHADOW_LOW

            // For all single-sided, refractive materials, we want to force a thin refraction model.
            #if !defined(_DOUBLESIDED_ON) && (defined(_REFRACTION_PLANE) || defined(_REFRACTION_SPHERE))
                #undef  _REFRACTION_PLANE
                #undef  _REFRACTION_SPHERE
                #define _REFRACTION_THIN
            #endif

            #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingIntersection.hlsl"

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
            #define HAS_LIGHTLOOP
            #define PATH_TRACING_CLUSTERED_DECALS
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracingLightLoop.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RayTracingLightCluster.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RayTracingCommon.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
            //-------------------------------------------------------------------------------------
// Defines
//-------------------------------------------------------------------------------------

// Use surface gradient normal mapping as it handle correctly triplanar normal mapping and multiple UVSet
// Not used in rtx as it requires derivatives
#ifndef SHADER_STAGE_RAY_TRACING
#define SURFACE_GRADIENT
#endif

//-------------------------------------------------------------------------------------
// Fill SurfaceData/Builtin data function
//-------------------------------------------------------------------------------------
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Sampling/SampleUVMapping.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
#if !defined(SHADER_STAGE_RAY_TRACING) || defined (PATH_TRACING_CLUSTERED_DECALS)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
#endif
#ifndef SURFACE_GRADIENT
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
#endif

//#define PROJECTED_SPACE_NDF_FILTERING

// Struct that gather UVMapping info of all layers + common calculation
// This is use to abstract the mapping that can differ on layers
struct LayerTexCoord
{
#ifndef LAYERED_LIT_SHADER
    UVMapping base;
    UVMapping details;
#else
    // Regular texcoord
    UVMapping base0;
    UVMapping base1;
    UVMapping base2;
    UVMapping base3;

    UVMapping details0;
    UVMapping details1;
    UVMapping details2;
    UVMapping details3;

    // Dedicated for blend mask
    UVMapping blendMask;
#endif

    // Store information that will be share by all UVMapping
    float3 vertexNormalWS; // TODO: store also object normal map for object triplanar
    float3 triplanarWeights;

#ifdef SURFACE_GRADIENT
    // tangent basis for each UVSet - up to 4 for now
    float3 vertexTangentWS0, vertexBitangentWS0;
    float3 vertexTangentWS1, vertexBitangentWS1;
    float3 vertexTangentWS2, vertexBitangentWS2;
    float3 vertexTangentWS3, vertexBitangentWS3;
#endif
};

#ifdef SURFACE_GRADIENT
void GenerateLayerTexCoordBasisTB(FragInputs input, inout LayerTexCoord layerTexCoord)
{
    float3 vertexNormalWS = input.tangentToWorld[2];

    layerTexCoord.vertexTangentWS0 = input.tangentToWorld[0];
    layerTexCoord.vertexBitangentWS0 = input.tangentToWorld[1];

    float3 dPdx = ddx_fine(input.positionRWS);
    float3 dPdy = ddy_fine(input.positionRWS);

    float3 sigmaX = dPdx - dot(dPdx, vertexNormalWS) * vertexNormalWS;
    float3 sigmaY = dPdy - dot(dPdy, vertexNormalWS) * vertexNormalWS;
    //float flipSign = dot(sigmaY, cross(vertexNormalWS, sigmaX) ) ? -1.0 : 1.0;
    float flipSign = dot(dPdy, cross(vertexNormalWS, dPdx)) < 0.0 ? -1.0 : 1.0; // gives same as the commented out line above

    // TODO: Optimize! The compiler will not be able to remove the tangent space that are not use because it can't know due to our UVMapping constant we use for both base and details
    // To solve this we should track which UVSet is use for normal mapping... Maybe not as simple as it sounds
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord1.xy, layerTexCoord.vertexTangentWS1, layerTexCoord.vertexBitangentWS1);
    #if defined(_REQUIRE_UV2) || defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord2.xy, layerTexCoord.vertexTangentWS2, layerTexCoord.vertexBitangentWS2);
    #endif
    #if defined(_REQUIRE_UV3)
    SurfaceGradientGenBasisTB(vertexNormalWS, sigmaX, sigmaY, flipSign, input.texCoord3.xy, layerTexCoord.vertexTangentWS3, layerTexCoord.vertexBitangentWS3);
    #endif
}
#endif

#ifndef LAYERED_LIT_SHADER

// Want to use only one sampler for normalmap/bentnormalmap either we use OS or TS. And either we have normal map or bent normal or both.
#ifdef _NORMALMAP_TANGENT_SPACE
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMap
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMap
    #endif
#else
    #if defined(_NORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_NormalMapOS
    #elif defined(_BENTNORMALMAP)
    #define SAMPLER_NORMALMAP_IDX sampler_BentNormalMapOS
    #endif
#endif

#define SAMPLER_DETAILMAP_IDX sampler_DetailMap
#define SAMPLER_MASKMAP_IDX sampler_MaskMap
#define SAMPLER_HEIGHTMAP_IDX sampler_HeightMap

#define SAMPLER_SUBSURFACE_MASK_MAP_IDX sampler_SubsurfaceMaskMap
#define SAMPLER_TRANSMISSION_MASK_MAP_IDX sampler_TransmissionMaskMap
#define SAMPLER_THICKNESSMAP_IDX sampler_ThicknessMap

// include LitDataIndividualLayer to define GetSurfaceData
#define LAYER_INDEX 0
#define ADD_IDX(Name) Name
#define ADD_ZERO_IDX(Name) Name
#ifdef _NORMALMAP
#define _NORMALMAP_IDX
#endif
#ifdef _NORMALMAP_TANGENT_SPACE
#define _NORMALMAP_TANGENT_SPACE_IDX
#endif
#ifdef _DETAIL_MAP
#define _DETAIL_MAP_IDX
#endif
#ifdef _SUBSURFACE_MASK_MAP
#define _SUBSURFACE_MASK_MAP_IDX
#endif
#ifdef _TRANSMISSION_MASK_MAP
#define _TRANSMISSION_MASK_MAP_IDX
#endif
#ifdef _THICKNESSMAP
#define _THICKNESSMAP_IDX
#endif
#ifdef _MASKMAP
#define _MASKMAP_IDX
#endif
#ifdef _BENTNORMALMAP
#define _BENTNORMALMAP_IDX
#endif
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataIndividualLayer.hlsl"

// This maybe call directly by tessellation (domain) shader, thus all part regarding surface gradient must be done
// in function with FragInputs input as parameters
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(float2 texCoord0, float2 texCoord1, float2 texCoord2, float2 texCoord3,
                      float3 positionRWS, float3 vertexNormalWS, inout LayerTexCoord layerTexCoord)
{
    layerTexCoord.vertexNormalWS = vertexNormalWS;
    float objectSpaceMapping = false;
    float3 normalToComputeWeights = layerTexCoord.vertexNormalWS;
#ifndef LAYERED_LIT_SHADER
    objectSpaceMapping = _ObjectSpaceUVMapping;
    if (objectSpaceMapping)
    {
        normalToComputeWeights = TransformWorldToObjectNormal(normalToComputeWeights);
    }
#endif

    layerTexCoord.triplanarWeights = ComputeTriplanarWeights(normalToComputeWeights);

    int mappingType = UV_MAPPING_UVSET;
#if defined(_MAPPING_PLANAR)
    mappingType = UV_MAPPING_PLANAR;
#elif defined(_MAPPING_TRIPLANAR)
    mappingType = UV_MAPPING_TRIPLANAR;
#endif


    // Be sure that the compiler is aware that we don't use UV1 to UV3 for main layer so it can optimize code
    ComputeLayerTexCoord(   texCoord0, texCoord1, texCoord2, texCoord3, _UVMappingMask, _UVDetailsMappingMask,
                            _BaseColorMap_ST.xy, _BaseColorMap_ST.zw, _DetailMap_ST.xy, _DetailMap_ST.zw, 1.0, _LinkDetailsWithBase,
                            positionRWS, _TexWorldScale,
                            mappingType, objectSpaceMapping, layerTexCoord);
}

// This is call only in this file
// layerTexCoord must have been initialize to 0 outside of this function
void GetLayerTexCoord(FragInputs input, inout LayerTexCoord layerTexCoord)
{
#ifdef SURFACE_GRADIENT
    GenerateLayerTexCoordBasisTB(input, layerTexCoord);
#endif

    GetLayerTexCoord(   input.texCoord0.xy, input.texCoord1.xy, input.texCoord2.xy, input.texCoord3.xy,
                        input.positionRWS, input.tangentToWorld[2].xyz, layerTexCoord);
}

#if !defined(SHADER_STAGE_RAY_TRACING)
#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataDisplacement.hlsl"
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitBuiltinData.hlsl"

void GetSurfaceAndBuiltinData(FragInputs input, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
{
    // Fix case 1210058. With Lit.shader / LayeredLit.shader we always have UV1. But in the case of some SpeedTree mesh, there is no stream sent
    // and UV1 is corrupt when we use surface gradient. In case UV1 aren't required we set them to 0, so we ensure there is no garbage.
    // When using lightmaps, the uv1 is always valid but we don't update _UVMappingMask.y to 1
    // So when we are using them, we just need to keep the UVs as is.
#if !defined(LIGHTMAP_ON) && defined(SURFACE_GRADIENT)
    input.texCoord1 = (_UVMappingMask.y + _UVDetailsMappingMask.y + _UVMappingMaskEmissive.y) > 0 ? input.texCoord1 : 0;
#endif

// Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
#if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
#ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
#endif
#endif

    float3 doubleSidedConstants = GetDoubleSidedConstants();

    ApplyDoubleSidedFlipOrMirror(input, doubleSidedConstants); // Apply double sided flip on the vertex normal

    LayerTexCoord layerTexCoord;
    ZERO_INITIALIZE(LayerTexCoord, layerTexCoord);
    GetLayerTexCoord(input, layerTexCoord);

#if !defined(SHADER_STAGE_RAY_TRACING)
    float depthOffset = ApplyPerPixelDisplacement(input, V, layerTexCoord);
    #ifdef _DEPTHOFFSET_ON
    ApplyDepthOffsetPositionInput(V, depthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
    #endif
#else
    float depthOffset = 0.0;
#endif

#if defined(_ALPHATEST_ON)
    float alphaTex = SAMPLE_UVMAPPING_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, layerTexCoord.base).a;
    alphaTex = lerp(_AlphaRemapMin, _AlphaRemapMax, alphaTex);
    float alphaValue = alphaTex * _BaseColor.a;

    // Perform alha test very early to save performance (a killed pixel will not sample textures)
    #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
    float alphaCutoff = _AlphaCutoffPrepass;
    #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
    float alphaCutoff = _AlphaCutoffPostpass;
    #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
    float alphaCutoff = _UseShadowThreshold ? _AlphaCutoffShadow : _AlphaCutoff;
    #else
    float alphaCutoff = _AlphaCutoff;
    #endif

    GENERIC_ALPHA_TEST(alphaValue, alphaCutoff);
#endif

    // We perform the conversion to world of the normalTS outside of the GetSurfaceData
    // so it allow us to correctly deal with detail normal map and optimize the code for the layered shaders
    float3 normalTS;
    float3 bentNormalTS;
    float3 bentNormalWS;
    float alpha = GetSurfaceData(input, layerTexCoord, surfaceData, normalTS, bentNormalTS);

    // Tex3D: HDRP positions are camera-relative; texture coordinates must be absolute.
    float3 tex3DWorldPos = GetAbsolutePositionWS(input.positionRWS);
    float3 tex3DOffset = float3(sin(tex3DWorldPos.y), sin(tex3DWorldPos.x), sin(tex3DWorldPos.y)) * 0.01;
#if defined(SHADER_STAGE_RAY_TRACING)
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D_LOD(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset, 0).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D_LOD(_BlicsTex, sampler_BlicsTex, tex3DWorldPos, 0).rgb;
#else
    float3 tex3DAlbedo = SAMPLE_TEXTURE3D(_MainTex, sampler_MainTex, tex3DWorldPos + tex3DOffset).rgb;
    float3 tex3DBlinks = SAMPLE_TEXTURE3D(_BlicsTex, sampler_BlicsTex, tex3DWorldPos).rgb;
#endif
    float tex3DBlink = (sin(_Time.y + tex3DWorldPos.y) + 1.0) * 0.25 * _BlickIndensity;
    // Preserve the original: blinking contributes to albedo; _Color is not applied.
    surfaceData.baseColor = tex3DAlbedo + tex3DBlinks * tex3DBlink;
    surfaceData.metallic = saturate(_Metallic);
    surfaceData.perceptualSmoothness = saturate(_Glossiness);
    alpha = 1.0; // Original material is opaque.


    // This need to be init here to quiet the compiler in case of decal, but can be override later.
    surfaceData.geomNormalWS = input.tangentToWorld[2];
    surfaceData.specularOcclusion = 1.0;

#ifdef DECAL_NORMAL_BLENDING
    if (_EnableDecals)
    {
        #ifndef SURFACE_GRADIENT
        normalTS = SurfaceGradientFromTangentSpaceNormalAndFromTBN(normalTS,
                input.tangentToWorld[0], input.tangentToWorld[1]);
        #endif

        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData, normalTS);
    }

    GetNormalWS_SG(input, normalTS, surfaceData.normalWS, doubleSidedConstants);
#else
    GetNormalWS(input, normalTS, surfaceData.normalWS, doubleSidedConstants);

    #if HAVE_DECALS
    if (_EnableDecals)
    {
        // Both uses and modifies 'surfaceData.normalWS'.
        DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, input, alpha);
        ApplyDecalToSurfaceData(decalSurfaceData, input.tangentToWorld[2], surfaceData);
    }
    #endif
#endif

    // Use bent normal to sample GI if available
#ifdef _BENTNORMALMAP
    GetNormalWS(input, bentNormalTS, bentNormalWS, doubleSidedConstants);
#else
    bentNormalWS = surfaceData.normalWS;
#endif

#if defined(DEBUG_DISPLAY)
#if !defined(SHADER_STAGE_RAY_TRACING)
    // Mipmap mode debugging isn't supported with ray tracing as it relies on derivatives
    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
    {
        surfaceData.baseColor = GET_TEXTURE_STREAMING_DEBUG(posInput.positionSS, input.texCoord0);
        surfaceData.metallic = 0;
    }
#endif

    // We need to call ApplyDebugToSurfaceData after filling the surfaceData and before filling builtinData
    // as it can modify attribute use for static lighting
    ApplyDebugToSurfaceData(input.tangentToWorld, surfaceData);
#endif

    // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion.
    // If user provide bent normal then we process a better term
#if defined(_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP)
    // If we have bent normal and ambient occlusion, process a specular occlusion
    surfaceData.specularOcclusion = GetSpecularOcclusionFromBentAO(V, bentNormalWS, surfaceData.normalWS, surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
    // Don't do spec occ from Ambient if there is no mask mask
#elif defined(_MASKMAP) && !defined(_SPECULAR_OCCLUSION_NONE)
    surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
#endif

    // This is use with anisotropic material
    surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

#if defined(_ENABLE_GEOMETRIC_SPECULAR_AA) && !defined(SHADER_STAGE_RAY_TRACING)
    // Specular AA
    #ifdef PROJECTED_SPACE_NDF_FILTERING
    surfaceData.perceptualSmoothness = ProjectedSpaceGeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #else
    surfaceData.perceptualSmoothness = GeometricNormalFiltering(surfaceData.perceptualSmoothness, input.tangentToWorld[2], _SpecularAAScreenSpaceVariance, _SpecularAAThreshold);
    #endif
#endif

    // Caution: surfaceData must be fully initialize before calling GetBuiltinData
    GetBuiltinData(input, V, posInput, surfaceData, alpha, bentNormalWS, depthOffset, layerTexCoord.base, builtinData);

#ifdef _ALPHATEST_ON
    // Used for sharpening by alpha to mask
    builtinData.alphaClipTreshold = alphaCutoff;
#endif

    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
}
#if !defined(SHADER_STAGE_RAY_TRACING)
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDataMeshModification.hlsl"
#endif
#endif // #ifndef LAYERED_LIT_SHADER

            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitPathTracing.hlsl"
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassPathTracing.hlsl"

            ENDHLSL
        }
    }

    FallBack "Hidden/HDRP/FallbackError"

}
