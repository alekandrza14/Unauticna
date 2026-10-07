// GAPH Special Skills Effects Pack - Integrated Effect (Built-in / URP / HDRP)
// URP soft particles require "Depth Texture" on the URP asset.

Shader "GAPH/Special Skills Effects Pack/Integrated Effect"
{
		Properties {
					[HDR]_TintColor("Color",Color) = (1,1,1,1)
					[Toggle(IS_USE_SECOND_COLOR)]_SecondColor("Is use second color",int) = 0
					[HDR]_TintColor2("Color2",Color) = (1,1,1,1)
					_MainTex ("Main Tex", 2D) = "white" {}
					_ColorFactor("Color Factor", float) = 1
					[Toggle(IS_TEXTURE_ANIMATE)]_TextureAnimate("Is Texture Animate",int) = 0
						_TextureAnimateSpeed("Texture Animate Speed",float) = 1.0
						_TextureAnimateStyle("Texture Animate Style", Range(0,2)) = 1
					[Toggle(IS_TEXTURE_ANIMATE_ADVANCED)]_TextureAnimateAdvanced("Is Texture Animate Advanced",int) = 0 //Need to check 'Is Texture Animate'
						_MaxIndex("Texture Mix Count",int) = 2
					[Toggle(IS_TEXTURE_BLEND)]_TextureBlend("Is Texture Blend",int) = 0
					[Toggle(IS_ALL_TEXTURE_STRAIGHT_MOVE)]_MixedMove("Is All Texture Straight Move",int) = 0
						_TexPosMove("xPosMove", Range(-1,1)) = 0
					[Toggle(IS_USE_ROTATE_UV)]_IsRotateAngle("Is Rotate Angle", int) = 0
						_RotateAngle("RotateAngle", Range(-1,1)) = 0
					[Toggle(IS_SOFT_PARTICLES)]_SoftParticle("Is Soft Particles",int) = 1
						_InvFade("Soft Particle Factor",float) = 1
					[Toggle(IS_NORMAL_DISTORTION)]_NormalDistortion("Is Normal Distortion",int) = 0
						_NormalTex("Normal Tex",2D) = "white"{}
						_NormalDistortionFactor("Normal Distortion Factor",float) = 1.0
					[Toggle(IS_NORMAL_ANIMATE)]_NormalAnimate("Is Normal Animate",int) = 0
						_NormalAnimateSpeed("Normal Animate Speed",float) = 1.0
					[Toggle(IS_TEXTURE_NOISE)]_TextureNoise("Is Texture Noise", int)= 0
						_NoiseNormal("Noise Normal",2D) = "white"{}
						_NoiseNormalFactor("NoiseNormalFactor",float) = 1.0
					[Toggle(IS_MASK_FADE)]_MaskFade("Is Mask Fade",int) = 0
					[Toggle(IS_USE_TEXANIMATION)]_UseTexAnimation("Is UseTexAnimation",int) = 0
						_FixedMaskTex("Fixed Mask Tex",2D) = "white"{}
						_MaskTex("Mask Tex",2D) = "white"{}
						_MaskOffsetFactor("Mask Offset Factor",float) = 1.0
						_MaskDistortion("Mask Distortion Tex",2D) = "white"{}
						_MaskAnimatedSpeed("_MaskAnimatedSpeed",float) = 1.0
						_MaskCutOut("Mask CutOut",Range(0,1)) = 1
					[Toggle]_ZWrite("ZWrite On/Off", int) = 0
					[Enum(Culling Off,0, Culling Front, 1, Culling Back, 2)]_Culling("Culling",float) = 2
					[Enum(UnityEngine.Rendering.BlendMode)]_BlendSrc("BlendSrc", float) = 1
					[Enum(UnityEngine.Rendering.BlendMode)]_BlendDst("BlendDst", float) = 1
					[Enum(UnityEngine.Rendering.CompareFunction)]_ZTest2("_ZTest2", int) = 2
					[Toggle(IS_VERTEXANIMATION)]_VertexAnimation("Is Vertex Animation", int) = 0
						_NoiseTex("Vertex Animation Noise Map",2D) = "black"{}
						_NoiseValue("Noise Value", Vector) = (1,1,1,0)
						_NoiseScale("Noise Scale", float) = 1
					[Toggle(IS_RIMLIGHT)]_RimLight("Is Rim Light",int) = 0
						[HDR]_RimColor("RimColor",Color) = (1,1,1,1)
						_RimScale("Rim Light Power",float) = 1
						_RimStrength("Rim Light Strength",float) = 1
					[Toggle(IS_IMPACT)]_Impact("Is Impact",int) = 0
						_ImpactSize("Impact Size",float) = 0.5
						_ImpactFactor("Impact Factor",float) = 1
						[Toggle(IS_TEXCOORD_MOVE)]_TexcoordMove("Is Texcoord Move",int) = 0
							_xTexcoordMove("xTexcoordMove", Range(-1,1)) = 0
							_yTexcoordMove("yTexcoordMove", Range(-1,1)) = 0
						_TexcoordMoveStrength("TexcoordMoveStrength",float) = 0
						[Toggle(IS_TEXCOORD_MOVE_USING_CUSTOM)]_TexcoordMoveUsingCustom("Is Texcoord Move Using Custom",int) = 0
					[Toggle(IS_LINEPASS)]_LinePass("Is LinePass", int) = 0
						_TexLength("TexLength",Range(0,1)) = 1.0
					_LinePassTex("LinePassTex", 2D) = "white" {}
		}

		// URP
		SubShader {
			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "RenderPipeline" = "UniversalPipeline" "PreviewType" = "Plane" }
			Blend [_BlendSrc] [_BlendDst]
			Cull [_Culling]
			ZWrite [_ZWrite]
			ZTest [_ZTest2]

			Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 3.0
				#pragma multi_compile_fog

				#pragma shader_feature_local IS_SOFT_PARTICLES
				#pragma shader_feature_local IS_USE_SECOND_COLOR
				#pragma shader_feature_local IS_NORMAL_DISTORTION
				#pragma shader_feature_local IS_TEXCOORD_MOVE_USING_CUSTOM
				#pragma shader_feature_local IS_TEXTURE_NOISE
				#pragma shader_feature_local IS_MASK_FADE
				#pragma shader_feature_local IS_TEXTURE_BLEND
				#pragma shader_feature_local IS_TEXTURE_ANIMATE
				#pragma shader_feature_local IS_TEXTURE_ANIMATE_ADVANCED
				#pragma shader_feature_local IS_ALL_TEXTURE_STRAIGHT_MOVE
				#pragma shader_feature_local IS_TEXCOORD_MOVE
				#pragma shader_feature_local IS_NORMAL_ANIMATE
				#pragma shader_feature_local IS_VERTEXANIMATION
				#pragma shader_feature_local IS_RIMLIGHT
				#pragma shader_feature_local IS_IMPACT
				#pragma shader_feature_local IS_LINEPASS
				#pragma shader_feature_local IS_USE_TEXANIMATION
				#pragma shader_feature_local IS_USE_ROTATE_UV

				#define GAPH_URP 1
				#include "GAPH_IntegratedEffectPass.cginc"
				ENDCG
			}
		}

		// HDRP
		SubShader {
			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "RenderPipeline" = "HDRenderPipeline" "PreviewType" = "Plane" }
			Blend [_BlendSrc] [_BlendDst]
			Cull [_Culling]
			ZWrite [_ZWrite]
			ZTest [_ZTest2]

			Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 4.5

				#pragma shader_feature_local IS_SOFT_PARTICLES
				#pragma shader_feature_local IS_USE_SECOND_COLOR
				#pragma shader_feature_local IS_NORMAL_DISTORTION
				#pragma shader_feature_local IS_TEXCOORD_MOVE_USING_CUSTOM
				#pragma shader_feature_local IS_TEXTURE_NOISE
				#pragma shader_feature_local IS_MASK_FADE
				#pragma shader_feature_local IS_TEXTURE_BLEND
				#pragma shader_feature_local IS_TEXTURE_ANIMATE
				#pragma shader_feature_local IS_TEXTURE_ANIMATE_ADVANCED
				#pragma shader_feature_local IS_ALL_TEXTURE_STRAIGHT_MOVE
				#pragma shader_feature_local IS_TEXCOORD_MOVE
				#pragma shader_feature_local IS_NORMAL_ANIMATE
				#pragma shader_feature_local IS_VERTEXANIMATION
				#pragma shader_feature_local IS_RIMLIGHT
				#pragma shader_feature_local IS_IMPACT
				#pragma shader_feature_local IS_LINEPASS
				#pragma shader_feature_local IS_USE_TEXANIMATION
				#pragma shader_feature_local IS_USE_ROTATE_UV

				#define GAPH_HDRP 1
				#include "GAPH_IntegratedEffectPass.cginc"
				ENDCG
			}
		}

		// Built-in
		SubShader {
			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "PreviewType" = "Plane" }
			Blend [_BlendSrc] [_BlendDst]
			Cull [_Culling]
			ZWrite [_ZWrite]
			ZTest [_ZTest2]

			Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 3.0
				#pragma multi_compile_particles
				#pragma multi_compile_fog

				#pragma shader_feature_local IS_SOFT_PARTICLES
				#pragma shader_feature_local IS_USE_SECOND_COLOR
				#pragma shader_feature_local IS_NORMAL_DISTORTION
				#pragma shader_feature_local IS_TEXCOORD_MOVE_USING_CUSTOM
				#pragma shader_feature_local IS_TEXTURE_NOISE
				#pragma shader_feature_local IS_MASK_FADE
				#pragma shader_feature_local IS_TEXTURE_BLEND
				#pragma shader_feature_local IS_TEXTURE_ANIMATE
				#pragma shader_feature_local IS_TEXTURE_ANIMATE_ADVANCED
				#pragma shader_feature_local IS_ALL_TEXTURE_STRAIGHT_MOVE
				#pragma shader_feature_local IS_TEXCOORD_MOVE
				#pragma shader_feature_local IS_NORMAL_ANIMATE
				#pragma shader_feature_local IS_VERTEXANIMATION
				#pragma shader_feature_local IS_RIMLIGHT
				#pragma shader_feature_local IS_IMPACT
				#pragma shader_feature_local IS_LINEPASS
				#pragma shader_feature_local IS_USE_TEXANIMATION
				#pragma shader_feature_local IS_USE_ROTATE_UV

				#include "GAPH_IntegratedEffectPass.cginc"
				ENDCG
			}
		}

		Fallback Off
		CustomEditor "GAPH_SpecialSkillsEffectsShaderGUI"
}
