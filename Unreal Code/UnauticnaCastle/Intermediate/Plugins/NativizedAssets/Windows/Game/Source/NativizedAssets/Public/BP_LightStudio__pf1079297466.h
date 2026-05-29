#pragma once
#include "Blueprint/BlueprintSupport.h"
#include "Runtime/CoreUObject/Public/UObject/NoExportTypes.h"
#include "Runtime/Engine/Classes/GameFramework/Actor.h"
class USkyLightComponent;
class UExponentialHeightFogComponent;
class UStaticMeshComponent;
class USceneComponent;
class UDirectionalLightComponent;
class UMaterialInstanceDynamic;
class UCurveLinearColor;
class UCurveFloat;
class UTexture;
class UAtmosphericFogComponent;
class UMaterialInterface;
class UMaterialInstance;
#include "BP_LightStudio__pf1079297466.generated.h"
UCLASS(config=Engine, Blueprintable, BlueprintType, meta=(ReplaceConverted="/Game/StarterContent/Blueprints/BP_LightStudio.BP_LightStudio_C", OverrideNativeName="BP_LightStudio_C"))
class ABP_LightStudio_C__pf1079297466 : public AActor
{
public:
	GENERATED_BODY()
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="BP_DayLight", OverrideNativeName="SkyLight1"))
	USkyLightComponent* bpv__SkyLight1__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="BP_DayLight", OverrideNativeName="ExponentialHeightFog1"))
	UExponentialHeightFogComponent* bpv__ExponentialHeightFog1__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="BP_DayLight", OverrideNativeName="PrevisArrow"))
	UStaticMeshComponent* bpv__PrevisArrow__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="Skybox"))
	UStaticMeshComponent* bpv__Skybox__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="Scene1"))
	USceneComponent* bpv__Scene1__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Global Brightness", Category="Global", OverrideNativeName="GlobalBrightness"))
	float bpv__GlobalBrightness__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Use HDRI", Category="HDRI", OverrideNativeName="Use_HDRI"))
	bool bpv__Use_HDRI__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Use Sun Light", Category="Sun", OverrideNativeName="UseSunLight"))
	bool bpv__UseSunLight__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Sun Brightness", Category="Sun", OverrideNativeName="SunBrightness"))
	float bpv__SunBrightness__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Sun Tint", Category="Sun", OverrideNativeName="SunTint"))
	FLinearColor bpv__SunTint__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Stationary Light for Sun", Category="Sun", OverrideNativeName="StationaryLightForSun"))
	bool bpv__StationaryLightForSun__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Sun Directional Light", Category="Default", OverrideNativeName="SunDirectionalLight"))
	UDirectionalLightComponent* bpv__SunDirectionalLight__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Use Atmosphere", Category="Atmosphere", OverrideNativeName="UseAtmosphere"))
	bool bpv__UseAtmosphere__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Atmosphere Brightness", Category="Atmosphere", OverrideNativeName="AtmosphereBrightness"))
	float bpv__AtmosphereBrightness__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Atmosphere Tint", Category="Atmosphere", OverrideNativeName="AtmosphereTint"))
	FLinearColor bpv__AtmosphereTint__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Previs Arrow Material", Category="Default", OverrideNativeName="PrevisArrowMaterial"))
	UMaterialInstanceDynamic* bpv__PrevisArrowMaterial__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Light Color", Category="Default", OverrideNativeName="LightColor"))
	FLinearColor bpv__LightColor__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Sun Color Curve", Category="Default", OverrideNativeName="SunColorCurve"))
	UCurveLinearColor* bpv__SunColorCurve__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Override Sun Color", Category="Sun", OverrideNativeName="OverrideSunColor"))
	bool bpv__OverrideSunColor__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Atmosphere Density Multiplier", Category="Atmosphere", OverrideNativeName="AtmosphereDensityMultiplier"))
	float bpv__AtmosphereDensityMultiplier__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Atmosphere Altitude", Category="Atmosphere", OverrideNativeName="AtmosphereAltitude"))
	float bpv__AtmosphereAltitude__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Disable Sun Disk", Category="Sun", OverrideNativeName="DisableSunDisk"))
	bool bpv__DisableSunDisk__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Use Fog", Category="Fog", OverrideNativeName="UseFog"))
	bool bpv__UseFog__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Fog Brightness", Category="Fog", OverrideNativeName="FogBrightness"))
	float bpv__FogBrightness__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Fog Tint", Category="Fog", OverrideNativeName="FogTint"))
	FLinearColor bpv__FogTint__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Fog Altitude", Category="Fog", OverrideNativeName="FogAltitude"))
	float bpv__FogAltitude__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Fog Max Opacity", Category="Fog", OverrideNativeName="FogMaxOpacity"))
	float bpv__FogMaxOpacity__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Fog Height Falloff", Category="Fog", OverrideNativeName="FogHeightFalloff"))
	float bpv__FogHeightFalloff__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Fog Density", Category="Fog", OverrideNativeName="FogDensity"))
	float bpv__FogDensity__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Fog Brightness Curve", Category="Default", OverrideNativeName="FogBrightnessCurve"))
	UCurveFloat* bpv__FogBrightnessCurve__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Fog Start Distance", Category="Fog", OverrideNativeName="FogStartDistance"))
	float bpv__FogStartDistance__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Disable Ground Scattering", Category="Atmosphere", OverrideNativeName="DisableGroundScattering"))
	bool bpv__DisableGroundScattering__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Atmosphere Distance Scale", Category="Atmosphere", OverrideNativeName="AtmosphereDistanceScale"))
	float bpv__AtmosphereDistanceScale__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Skybox Material", Category="Default", OverrideNativeName="SkyboxMaterial"))
	UMaterialInstanceDynamic* bpv__SkyboxMaterial__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="HDRI Brightness", Category="HDRI", OverrideNativeName="HDRI_Brightness"))
	float bpv__HDRI_Brightness__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="HDRI Contrast", Category="HDRI", OverrideNativeName="HDRI_Contrast"))
	float bpv__HDRI_Contrast__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="HDRI Tint", Category="HDRI", OverrideNativeName="HDRI_Tint"))
	FLinearColor bpv__HDRI_Tint__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="HDRI Cubemap", Category="HDRI", OverrideNativeName="HDRI_Cubemap"))
	UTexture* bpv__HDRI_Cubemap__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="HDRI Rotation", Category="HDRI", OverrideNativeName="HDRI_Rotation"))
	float bpv__HDRI_Rotation__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Atmosphere Opacity Horizon", Category="HDRI", OverrideNativeName="AtmosphereOpacityHorizon"))
	float bpv__AtmosphereOpacityHorizon__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Atmosphere Opacity Zenith", Category="HDRI", OverrideNativeName="AtmosphereOpacityZenith"))
	float bpv__AtmosphereOpacityZenith__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="High Density Atmosphere", Category="Atmosphere", OverrideNativeName="HighDensityAtmosphere"))
	bool bpv__HighDensityAtmosphere__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Atmospheric Fog", Category="Default", OverrideNativeName="AtmosphericFog"))
	UAtmosphericFogComponent* bpv__AtmosphericFog__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Use Skylight", Category="SkyLight", OverrideNativeName="UseSkylight"))
	bool bpv__UseSkylight__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Shadowdistance", Category="Sun", OverrideNativeName="Shadowdistance"))
	float bpv__Shadowdistance__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Light Shaft Bloom", Category="LightShafts", OverrideNativeName="LightShaftBloom"))
	bool bpv__LightShaftBloom__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Light Shaft Occlusion", Category="LightShafts", OverrideNativeName="LightShaftOcclusion"))
	bool bpv__LightShaftOcclusion__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Occlusion Mask Darkness", Category="LightShafts", OverrideNativeName="OcclusionMaskDarkness"))
	float bpv__OcclusionMaskDarkness__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Bloom Scale", Category="LightShafts", OverrideNativeName="BloomScale"))
	float bpv__BloomScale__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Bloom Threshold", Category="LightShafts", OverrideNativeName="BloomThreshold"))
	float bpv__BloomThreshold__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Bloom Tint", Category="LightShafts", OverrideNativeName="BloomTint"))
	FColor bpv__BloomTint__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Atmosphere Fog Multiplier", Category="Atmosphere", OverrideNativeName="AtmosphereFogMultiplier"))
	float bpv__AtmosphereFogMultiplier__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Atmosphere Density Height", Category="Atmosphere", OverrideNativeName="AtmosphereDensityHeight"))
	float bpv__AtmosphereDensityHeight__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Atmosphere Max Scattering Order", Category="Atmosphere", OverrideNativeName="AtmosphereMaxScatteringOrder"))
	int32 bpv__AtmosphereMaxScatteringOrder__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Atmosphere Altitude Sample Number", Category="Atmosphere", OverrideNativeName="AtmosphereAltitudeSampleNumber"))
	int32 bpv__AtmosphereAltitudeSampleNumber__pf;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Light Function Material", Category="Sun", OverrideNativeName="LightFunctionMaterial"))
	UMaterialInterface* bpv__LightFunctionMaterial__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="MIC Black", Category="Default", OverrideNativeName="MIC_Black"))
	UMaterialInstance* bpv__MIC_Black__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="MIC HDRI", Category="Default", OverrideNativeName="MIC_HDRI"))
	UMaterialInstance* bpv__MIC_HDRI__pf;
	ABP_LightStudio_C__pf1079297466(const FObjectInitializer& ObjectInitializer = FObjectInitializer::Get());
	virtual void PostLoadSubobjects(FObjectInstancingGraph* OuterInstanceGraph) override;
	static void __CustomDynamicClassInitialization(UDynamicClass* InDynamicClass);
	static void __StaticDependenciesAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
	static void __StaticDependencies_DirectlyUsedAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
	UFUNCTION(BlueprintCallable, meta=(BlueprintInternalUseOnly="true", Comment="/**\t * Construction script, the place to spawn components and do other setup.\t * @note Name used in CreateBlueprint function\t */", DisplayName="Construction Script", ToolTip="Construction script, the place to spawn components and do other setup.@note Name used in CreateBlueprint function", Category, CppFromBpEvent, OverrideNativeName="UserConstructionScript"))
	virtual void bpf__UserConstructionScript__pf();
	UFUNCTION(BlueprintCallable, meta=(Category, OverrideNativeName="CalculateSunColor"))
	virtual void bpf__CalculateSunColor__pf();
	UFUNCTION(BlueprintCallable, meta=(Category, OverrideNativeName="SunMobility"))
	virtual void bpf__SunMobility__pf();
	UFUNCTION(BlueprintCallable, BlueprintPure, meta=(Category, OverrideNativeName="NormalizedSunAngle"))
	virtual void bpf__NormalizedSunAngle__pf(/*out*/ float& bpp__Angle__pf);
	UFUNCTION(BlueprintCallable, meta=(Category, OverrideNativeName="AtmosphereDensity"))
	virtual void bpf__AtmosphereDensity__pf();
public:
};
