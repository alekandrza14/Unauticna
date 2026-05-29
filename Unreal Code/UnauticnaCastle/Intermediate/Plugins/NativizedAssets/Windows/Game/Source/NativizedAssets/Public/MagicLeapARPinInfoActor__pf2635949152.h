#pragma once
#include "Blueprint/BlueprintSupport.h"
#include "Runtime/CoreUObject/Public/UObject/NoExportTypes.h"
#include "Runtime/Engine/Classes/Engine/EngineTypes.h"
#include "../Plugins/Lumin/MagicLeapPassableWorld/Source/MagicLeapARPin/Public/MagicLeapARPinTypes.h"
#include "../Plugins/Lumin/MagicLeapPassableWorld/Source/MagicLeapARPin/Public/Debug/MagicLeapARPinInfoActorBase.h"
class UStaticMeshComponent;
class USphereComponent;
class USceneComponent;
class UTextRenderComponent;
#include "MagicLeapARPinInfoActor__pf2635949152.generated.h"
UCLASS(config=Engine, Blueprintable, BlueprintType, meta=(ReplaceConverted="/MagicLeapPassableWorld/MagicLeapARPinInfoActor.MagicLeapARPinInfoActor_C", OverrideNativeName="MagicLeapARPinInfoActor_C"))
class AMagicLeapARPinInfoActor_C__pf2635949152 : public AMagicLeapARPinInfoActorBase
{
public:
	GENERATED_BODY()
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="Right"))
	UStaticMeshComponent* bpv__Right__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="Forward"))
	UStaticMeshComponent* bpv__Forward__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="Up"))
	UStaticMeshComponent* bpv__Up__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="ValidRadiusVisualizer"))
	USphereComponent* bpv__ValidRadiusVisualizer__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="AxisRoot"))
	USceneComponent* bpv__AxisRoot__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="VisualizerRoot"))
	USceneComponent* bpv__VisualizerRoot__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="TypeValue"))
	UTextRenderComponent* bpv__TypeValue__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="TransErrValue"))
	UTextRenderComponent* bpv__TransErrValue__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="RotErrValue"))
	UTextRenderComponent* bpv__RotErrValue__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="ConfidenceValue"))
	UTextRenderComponent* bpv__ConfidenceValue__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="TransErrLabel"))
	UTextRenderComponent* bpv__TransErrLabel__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="RotErrLabel"))
	UTextRenderComponent* bpv__RotErrLabel__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="ConfidenceLabel"))
	UTextRenderComponent* bpv__ConfidenceLabel__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="PinIDValue"))
	UTextRenderComponent* bpv__PinIDValue__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="InfoRoot"))
	USceneComponent* bpv__InfoRoot__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="Root"))
	USceneComponent* bpv__Root__pf;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, meta=(DisplayName="Rotation Smooth Speed", Category="Default", MultiLine="true", OverrideNativeName="RotationSmoothSpeed"))
	float bpv__RotationSmoothSpeed__pf;
	UPROPERTY(Transient, DuplicateTransient, meta=(OverrideNativeName="CallFunc_GetARPinPositionAndOrientation_Position"))
	FVector b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf;
	UPROPERTY(Transient, DuplicateTransient, meta=(OverrideNativeName="CallFunc_GetARPinPositionAndOrientation_Orientation"))
	FRotator b0l__CallFunc_GetARPinPositionAndOrientation_Orientation__pf;
	UPROPERTY(Transient, DuplicateTransient, meta=(OverrideNativeName="CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment"))
	bool b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf;
	UPROPERTY(Transient, DuplicateTransient, meta=(OverrideNativeName="CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult"))
	FHitResult b0l__CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult__pf;
	UPROPERTY(Transient, DuplicateTransient, meta=(OverrideNativeName="CallFunc_K2_SetWorldLocation_SweepHitResult"))
	FHitResult b0l__CallFunc_K2_SetWorldLocation_SweepHitResult__pf;
	UPROPERTY(Transient, DuplicateTransient, meta=(OverrideNativeName="K2Node_Event_DeltaSeconds"))
	float b0l__K2Node_Event_DeltaSeconds__pf;
	UPROPERTY(Transient, DuplicateTransient, meta=(OverrideNativeName="CallFunc_BreakRotator_Roll"))
	float b0l__CallFunc_BreakRotator_Roll__pf;
	UPROPERTY(Transient, DuplicateTransient, meta=(OverrideNativeName="CallFunc_BreakRotator_Pitch"))
	float b0l__CallFunc_BreakRotator_Pitch__pf;
	UPROPERTY(Transient, DuplicateTransient, meta=(OverrideNativeName="CallFunc_BreakRotator_Yaw"))
	float b0l__CallFunc_BreakRotator_Yaw__pf;
	UPROPERTY(Transient, DuplicateTransient, meta=(OverrideNativeName="CallFunc_K2_SetWorldRotation_SweepHitResult"))
	FHitResult b0l__CallFunc_K2_SetWorldRotation_SweepHitResult__pf;
	UPROPERTY(Transient, DuplicateTransient, meta=(OverrideNativeName="CallFunc_GetARPinState_State"))
	FMagicLeapARPinState b0l__CallFunc_GetARPinState_State__pf;
	AMagicLeapARPinInfoActor_C__pf2635949152(const FObjectInitializer& ObjectInitializer = FObjectInitializer::Get());
	virtual void PostLoadSubobjects(FObjectInstancingGraph* OuterInstanceGraph) override;
	static void __CustomDynamicClassInitialization(UDynamicClass* InDynamicClass);
	static void __StaticDependenciesAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
	static void __StaticDependencies_DirectlyUsedAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
	void bpf__ExecuteUbergraph_MagicLeapARPinInfoActor__pf_0(int32 bpp__EntryPoint__pf);
	void bpf__ExecuteUbergraph_MagicLeapARPinInfoActor__pf_1(int32 bpp__EntryPoint__pf);
	UFUNCTION(meta=(Comment="/** Event called every frame, if ticking is enabled */", DisplayName="Tick", ToolTip="Event called every frame, if ticking is enabled", CppFromBpEvent, OverrideNativeName="ReceiveTick"))
	virtual void bpf__ReceiveTick__pf(float bpp__DeltaSeconds__pf);
	UFUNCTION(BlueprintCallable, meta=(Category="ContentPersistence|MagicLeap", CppFromBpEvent, OverrideNativeName="OnUpdateARPinState"))
	virtual void bpf__OnUpdateARPinState__pf();
	UFUNCTION(BlueprintCallable, meta=(BlueprintInternalUseOnly="true", Comment="/**\t * Construction script, the place to spawn components and do other setup.\t * @note Name used in CreateBlueprint function\t */", DisplayName="Construction Script", ToolTip="Construction script, the place to spawn components and do other setup.@note Name used in CreateBlueprint function", Category, CppFromBpEvent, OverrideNativeName="UserConstructionScript"))
	virtual void bpf__UserConstructionScript__pf();
	UFUNCTION(BlueprintCallable, meta=(Category, OverrideNativeName="UpdatePinState"))
	virtual void bpf__UpdatePinState__pf();
public:
};
