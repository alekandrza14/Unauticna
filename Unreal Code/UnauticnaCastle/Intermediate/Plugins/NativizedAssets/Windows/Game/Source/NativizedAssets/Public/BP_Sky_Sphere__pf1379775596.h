#pragma once
#include "Blueprint/BlueprintSupport.h"
#include "Runtime/CoreUObject/Public/UObject/NoExportTypes.h"
#include "Runtime/Engine/Classes/GameFramework/Actor.h"
class UStaticMeshComponent;
class USceneComponent;
class UMaterialInstanceDynamic;
class ADirectionalLight;
class UCurveLinearColor;
#include "BP_Sky_Sphere__pf1379775596.generated.h"
UCLASS(config=Engine, Blueprintable, BlueprintType, meta=(ReplaceConverted="/Engine/EngineSky/BP_Sky_Sphere.BP_Sky_Sphere_C", OverrideNativeName="BP_Sky_Sphere_C"))
class ABP_Sky_Sphere_C__pf1379775596 : public AActor
{
public:
	GENERATED_BODY()
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="BP_Skydome", OverrideNativeName="SkySphereMesh"))
	UStaticMeshComponent* bpv__SkySphereMesh__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="BP_Skydome", OverrideNativeName="Base"))
	USceneComponent* bpv__Base__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Sky Material", Category="Default", OverrideNativeName="Sky material"))
	UMaterialInstanceDynamic* bpv__Skyxmaterial__pfT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Refresh Material", Category="Default", Tooltip="Use this to update the sky material after moving  a directional light", OverrideNativeName="Refresh material"))
	bool bpv__Refreshxmaterial__pfT;
	UPROPERTY(EditInstanceOnly, BlueprintReadWrite, meta=(DisplayName="Directional Light Actor", Category="Default", Tooltip="Assign your level\'s directional light actor to this variable to  match the sky\'s sun position and color", OverrideNativeName="Directional light actor"))
	ADirectionalLight* bpv__Directionalxlightxactor__pfTT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Colors Determined By Sun Position", Category="Default", Tooltip="If enabled, sky colors will change according to the sun\'s position", OverrideNativeName="Colors determined by sun position"))
	bool bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Sun Height", Category="Override settings", UIMin="-1", UIMax="1", Tooltip="If no directional light is assigned, this value determines the height of the sun", OverrideNativeName="Sun height"))
	float bpv__Sunxheight__pfT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Sun Brightness", Category="Default", Tooltip="Brightness multiplier for the sun disk", OverrideNativeName="Sun brightness"))
	float bpv__Sunxbrightness__pfT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Horizon Falloff", Category="Override settings", Tooltip="Affects the size of the gradient from zenith color to horizon color", OverrideNativeName="Horizon Falloff"))
	float bpv__HorizonxFalloff__pfT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Zenith Color", Category="Override settings", OverrideNativeName="Zenith Color"))
	FLinearColor bpv__ZenithxColor__pfT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Horizon Color", Category="Override settings", OverrideNativeName="Horizon color"))
	FLinearColor bpv__Horizonxcolor__pfT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Cloud Color", Category="Override settings", OverrideNativeName="Cloud color"))
	FLinearColor bpv__Cloudxcolor__pfT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Overall Color", Category="Override settings", OverrideNativeName="Overall Color"))
	FLinearColor bpv__OverallxColor__pfT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Cloud Speed", Category="Default", Tooltip="Panning speed for the clouds", OverrideNativeName="Cloud speed"))
	float bpv__Cloudxspeed__pfT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Cloud Opacity", Category="Default", Tooltip="Opacity of the panning clouds", OverrideNativeName="Cloud opacity"))
	float bpv__Cloudxopacity__pfT;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta=(DisplayName="Stars Brightness", Category="Default", Tooltip="Multiplier for the brightness of the stars when the sun is below the horizon", OverrideNativeName="Stars brightness"))
	float bpv__Starsxbrightness__pfT;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Horizon Color Curve", Category="Default", OverrideNativeName="Horizon color curve"))
	UCurveLinearColor* bpv__Horizonxcolorxcurve__pfTT;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Zenith Color Curve", Category="Default", OverrideNativeName="Zenith color curve"))
	UCurveLinearColor* bpv__Zenithxcolorxcurve__pfTT;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Cloud Color Curve", Category="Default", OverrideNativeName="Cloud color curve"))
	UCurveLinearColor* bpv__Cloudxcolorxcurve__pfTT;
	ABP_Sky_Sphere_C__pf1379775596(const FObjectInitializer& ObjectInitializer = FObjectInitializer::Get());
	virtual void PostLoadSubobjects(FObjectInstancingGraph* OuterInstanceGraph) override;
	static void __CustomDynamicClassInitialization(UDynamicClass* InDynamicClass);
	static void __StaticDependenciesAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
	static void __StaticDependencies_DirectlyUsedAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
	UFUNCTION(BlueprintCallable, meta=(BlueprintInternalUseOnly="true", Comment="/**\t * Construction script, the place to spawn components and do other setup.\t * @note Name used in CreateBlueprint function\t */", DisplayName="Construction Script", ToolTip="Construction script, the place to spawn components and do other setup.@note Name used in CreateBlueprint function", Category, CppFromBpEvent, OverrideNativeName="UserConstructionScript"))
	virtual void bpf__UserConstructionScript__pf();
	UFUNCTION(BlueprintCallable, meta=(Category, OverrideNativeName="UpdateSunDirection"))
	virtual void bpf__UpdateSunDirection__pf();
	UFUNCTION(BlueprintCallable, meta=(Category, OverrideNativeName="RefreshMaterial"))
	virtual void bpf__RefreshMaterial__pf();
public:
};
