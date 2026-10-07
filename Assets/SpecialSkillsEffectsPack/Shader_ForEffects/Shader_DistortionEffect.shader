// GAPH Special Skills Effects Pack - Distortion Effect (Built-in / URP / HDRP)
// URP  : drawn by GaphURPDistortion.cs after transparents ("Depth Texture" for soft particles).
// HDRP : requires Distortion in the HDRP asset and camera Frame Settings (on by default).

Shader "GAPH/Special Skills Effects Pack/Distortion Effect" {
	Properties {
		_TintColor ("Tint Color", Color) = (1,1,1,1)
		_Mask ("Mask",2D) = "black"{}
		_NormalMap ("Normalmap", 2D) = "bump" {}
		_DistortFactor ("Distortion", Float) = 10
		// URP/HDRP only, 1 = same strength as Built-in
		_SRPDistortScale ("SRP Distortion Scale (URP/HDRP)", Range(0, 2)) = 1
		[Toggle(IS_SOFT_PARTICLES)]_SoftParticle("Is Soft Particles", int) = 1
		_InvFade ("Soft Particles Factor", Range(0,10)) = 1.0
	}

	// URP
	SubShader {
		Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "RenderPipeline" = "UniversalPipeline" }

		Pass {
			Name "Distortion"
			// Not drawn by URP itself; GaphURPDistortion.cs draws it over a copy of the camera color.
			Tags { "LightMode" = "GaphDistortion" }

			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask RGB
			Cull Off
			ZWrite Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment fragGrab
			#pragma target 3.0
			#pragma shader_feature_local IS_SOFT_PARTICLES

			#define GAPH_URP 1
			#include "GAPH_DistortionPass.cginc"
			ENDCG
		}
	}

	// HDRP
	SubShader {
		Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "RenderPipeline" = "HDRenderPipeline" }

		Pass {
			Name "DistortionVectors"
			Tags { "LightMode" = "DistortionVectors" }

			// StencilUsage.DistortionVectors
			Stencil {
				WriteMask 4
				Ref 4
				Comp Always
				Pass Replace
			}

			Blend SrcAlpha OneMinusSrcAlpha, Zero One
			Cull Off
			ZWrite Off
			ZTest LEqual

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment fragDistortionVectors
			#pragma target 4.5
			#pragma shader_feature_local IS_SOFT_PARTICLES
			// Keeps HDRP from stripping this pass in player builds
			#pragma multi_compile _SURFACE_TYPE_TRANSPARENT

			#define GAPH_HDRP 1
			#include "GAPH_DistortionPass.cginc"
			ENDCG
		}
	}

	// Built-in
	SubShader {
		GrabPass {
			"_GrabTexture"
		}

		Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Off
		ZWrite Off

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment fragGrab
			#pragma target 3.0
			#pragma multi_compile_particles
			#pragma shader_feature_local IS_SOFT_PARTICLES

			#include "GAPH_DistortionPass.cginc"
			ENDCG
		}
	}

	Fallback Off
	CustomEditor "GAPH_SpecialSkillsEffectsShaderGUI"
}
