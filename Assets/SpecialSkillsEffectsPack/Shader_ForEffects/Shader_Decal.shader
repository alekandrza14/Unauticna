// GAPH Special Skills Effects Pack - Decal (Built-in / URP / HDRP)
// URP  : requires "Depth Texture" on the URP asset.
// HDRP : the decal object needs the GaphDecalProjector component.

Shader "GAPH/Special Skills Effects Pack/Decal" {
		Properties {
					[HDR]_TintColor("TintColor",Color) = (1,1,1,1)
					[Toggle(IS_USE_SECOND_COLOR)]_SecondColor("Is use second color",int) = 0
					[HDR]_TintColor2("Color2",Color) = (1,1,1,1)
					_MainTex("MainTexture",2D) = "white" {}
					_ColorFactor("Color Factor", float) = 1
					[Toggle(IS_TEXTURE_ANIMATE)]_TextureAnimate("Is Texture Animate",int) = 0
						_TextureAnimateSpeed("Texture Animate Speed",float) = 1.0
					[Toggle(IS_NORMAL_DISTORTION)]_NormalDistortion("Is Normal Distortion",int) = 0
						_NormalTex("Normal Tex",2D) = "white"{}
					_NormalDistortionFactor("Normal Distortion Factor",float) = 1.0
						// Unused
						[Toggle(IS_NORMAL_ANIMATE)]_NormalAnimate("Is Normal Animate",int) = 0
						_NormalAnimateSpeed("Normal Animate Speed",float) = 1.0
					[Toggle(IS_MASK_FADE)]_MaskFade("Is Mask Fade",int) = 0
						_MaskTex("Mask Tex",2D) = "white"{}
					_MaskCutOut("Mask CutOut",Range(0,1)) = 1
					[Toggle]_ZWrite("ZWrite On/Off", int) = 0
					[Enum(Culling Off,0, Culling Front, 1, Culling Back, 2)]_Culling("Culling",float) = 2
					[Enum(UnityEngine.Rendering.BlendMode)]_BlendSrc("BlendSrc", float) = 1
					[Enum(UnityEngine.Rendering.BlendMode)]_BlendDst("BlendDst", float) = 1
					[Enum(UnityEngine.Rendering.CompareFunction)]_ZTest1("_ZTest1", int) = 5
					[IntRange]_StencilRef("Stencil Ref", Range(0,255)) = 1
					[Enum(UnityEngine.Rendering.CompareFunction)]_StencilComp("Stencil Comp", int) = 8
		}

		// URP
		SubShader {
			Tags { "Queue" = "Transparent-100" "IgnoreProjector" = "True" "RenderType" = "Transparent" "RenderPipeline" = "UniversalPipeline" "DisableBatching" = "True" }
			Blend [_BlendSrc] [_BlendDst]
			Cull Front
			ZTest [_ZTest1]
			ZWrite Off
			Stencil {
				Ref [_StencilRef]
				Comp [_StencilComp]
			}

			Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 3.0
				#pragma multi_compile_instancing

				#pragma shader_feature_local IS_MASK_FADE
				#pragma shader_feature_local IS_USE_SECOND_COLOR
				#pragma shader_feature_local IS_TEXTURE_ANIMATE
				#pragma shader_feature_local IS_NORMAL_DISTORTION

				#define GAPH_URP 1
				#include "GAPH_DecalPass.cginc"
				ENDCG
			}
		}

		// HDRP
		SubShader {
			Tags { "Queue" = "Transparent-100" "IgnoreProjector" = "True" "RenderType" = "Transparent" "RenderPipeline" = "HDRenderPipeline" "DisableBatching" = "True" }
			Blend [_BlendSrc] [_BlendDst]
			Cull Front
			ZTest [_ZTest1]
			ZWrite Off
			Stencil {
				Ref [_StencilRef]
				Comp [_StencilComp]
			}

			Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 4.5
				#pragma multi_compile_instancing

				#pragma shader_feature_local IS_MASK_FADE
				#pragma shader_feature_local IS_USE_SECOND_COLOR
				#pragma shader_feature_local IS_TEXTURE_ANIMATE
				#pragma shader_feature_local IS_NORMAL_DISTORTION

				#define GAPH_HDRP 1
				#include "GAPH_DecalPass.cginc"
				ENDCG
			}
		}

		// Built-in
		SubShader {
			Tags { "Queue" = "Transparent-100" "IgnoreProjector" = "True" "RenderType" = "Transparent" "DisableBatching" = "True" }
			Blend [_BlendSrc] [_BlendDst]
			Cull Front
			ZTest [_ZTest1]
			ZWrite Off
			Stencil {
				Ref [_StencilRef]
				Comp [_StencilComp]
			}

			Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 3.0
				#pragma multi_compile_instancing

				#pragma shader_feature_local IS_MASK_FADE
				#pragma shader_feature_local IS_USE_SECOND_COLOR
				#pragma shader_feature_local IS_TEXTURE_ANIMATE
				#pragma shader_feature_local IS_NORMAL_DISTORTION

				#include "GAPH_DecalPass.cginc"
				ENDCG
			}
		}

		Fallback Off
		CustomEditor "GAPH_SpecialSkillsEffectsShaderGUI"
}
