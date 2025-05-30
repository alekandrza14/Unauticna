using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

	public bool atmosphereEnabled = true;
	public bool cloudsEnabled = true;
	public bool underwaterEnabled = true;
	public bool antiAliasingEnabled = true;
	public AtmosphereSettings atmosphereSettings;
	Water waterSettings;

	public Shader depthShader;
	public Shader underwaterShader;
	public Shader hudShader;

	public Camera waterDepthCam;

    UnityEngine.RenderTexture waterDepthTex;
	Material atmosphereMat;
	Material underwaterMat;
	Material hudMat;

    UnityEngine.RenderTexture blurredTexture;
	ComputeShaderUtility.GaussianBlur gaussianBlur;
	CloudManager cloudManager;
	FXAAEffect fxaa;
	static Transform sunTransform;

	void Awake()
	{
		sunTransform = GameObject.FindWithTag("Sun").transform;
		//Camera.main.depthTextureMode = DepthTextureMode.Depth;

		atmosphereSettings.FlagForUpdate();
		waterDepthCam.depthTextureMode = DepthTextureMode.Depth;

		gaussianBlur = new ComputeShaderUtility.GaussianBlur();

	}

	void RenderAtmosphere(UnityEngine.RenderTexture source, UnityEngine.RenderTexture target)
	{
		if (atmosphereEnabled)
		{
			waterDepthCam.RenderWithShader(depthShader, "");
			atmosphereSettings.SetProperties(atmosphereMat);
			Graphics.Blit(source, target, atmosphereMat);
		}
		else
		{
			Graphics.Blit(source, target);
		}
	}

	void RenderClouds(UnityEngine.RenderTexture source, UnityEngine.RenderTexture target)
	{
		if (cloudsEnabled)
		{
			cloudManager.Render(source, target);
		}
		else
		{
			Graphics.Blit(source, target);
		}
	}

	void RenderUnderwater(UnityEngine.RenderTexture source, UnityEngine.RenderTexture target)
	{
		if (underwaterEnabled)
		{
			ComputeHelper.CreateRenderTexture(ref blurredTexture, source);
			gaussianBlur.Blur(source, blurredTexture, waterSettings.blurSize, waterSettings.blurStrength);

			underwaterMat.SetTexture("_BlurredTexture", blurredTexture);
			Graphics.Blit(source, target, underwaterMat);
		}
		else
		{
			Graphics.Blit(source, target);
		}
	}


	public void HandleEffects(UnityEngine.RenderTexture source, UnityEngine.RenderTexture target)
	{
		Init();

        // -------- Atmosphere --------
        UnityEngine.RenderTexture atmosphereComposite = UnityEngine.RenderTexture.GetTemporary(source.descriptor);
		RenderAtmosphere(source, atmosphereComposite);

        // -------- Clouds ---------
        UnityEngine.RenderTexture cloudComposite = UnityEngine.RenderTexture.GetTemporary(source.descriptor);
		RenderClouds(atmosphereComposite, cloudComposite);

        // -------- Underwater --------
        UnityEngine.RenderTexture underwaterComposite = UnityEngine.RenderTexture.GetTemporary(source.descriptor);
		RenderUnderwater(cloudComposite, underwaterComposite);

        // -------- Anti-Aliasing --------
        UnityEngine.RenderTexture antiAliasedResult = UnityEngine.RenderTexture.GetTemporary(source.descriptor);
		if (antiAliasingEnabled)
		{
			fxaa.Render(underwaterComposite, antiAliasedResult);
		}
		else
		{
			Graphics.Blit(underwaterComposite, antiAliasedResult);
		}

		// -------- HUD --------
		Graphics.Blit(antiAliasedResult, target, hudMat);

        // -------- Release --------
        UnityEngine.RenderTexture.ReleaseTemporary(atmosphereComposite);
        UnityEngine.RenderTexture.ReleaseTemporary(cloudComposite);
        UnityEngine.RenderTexture.ReleaseTemporary(underwaterComposite);
        UnityEngine.RenderTexture.ReleaseTemporary(antiAliasedResult);

	}

	void Init()
	{
		CreateMaterial(ref atmosphereMat, atmosphereSettings.shader);
		CreateMaterial(ref underwaterMat, underwaterShader);
		CreateMaterial(ref hudMat, hudShader);

		if (waterDepthTex == null || waterDepthTex.width != Screen.width || waterDepthTex.height != Screen.height)
		{
			if (waterDepthTex)
			{
				waterDepthTex.Release();
			}
            waterDepthTex = new UnityEngine.RenderTexture(Screen.width, Screen.height, 32, UnityEngine.Experimental.Rendering.GraphicsFormat.R32G32B32A32_SFloat);
			waterDepthTex.Create();
			waterDepthCam.targetTexture = waterDepthTex;
		}

		if (waterSettings == null)
		{
			waterSettings = FindFirstObjectByType<Water>();
		}

		waterSettings?.SetUnderwaterProperties(underwaterMat);

		if (cloudManager == null)
		{
			cloudManager = FindFirstObjectByType<CloudManager>();
		}

		if (fxaa == null)
		{
			fxaa = FindFirstObjectByType<FXAAEffect>();
		}
	}


	public static void CreateMaterial(ref Material material, Shader shader)
	{
		if (material == null || material.shader != shader)
		{
			material = new Material(shader);
		}
	}

	void OnDestroy()
	{
		gaussianBlur.Release();
		ComputeHelper.Release(waterDepthTex, blurredTexture);
	}

	public static Vector3 DirToSun {
		get {
			return -sunTransform.forward;
		}
	}
}
