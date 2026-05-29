#pragma once
#include "Blueprint/BlueprintSupport.h"
#include "Runtime/Engine/Classes/GameFramework/Actor.h"
class UAudioComponent;
class UParticleSystemComponent;
#include "Blueprint_Effect_Smoke__pf1079297466.generated.h"
UCLASS(config=Engine, Blueprintable, BlueprintType, meta=(ReplaceConverted="/Game/StarterContent/Blueprints/Blueprint_Effect_Smoke.Blueprint_Effect_Smoke_C", OverrideNativeName="Blueprint_Effect_Smoke_C"))
class ABlueprint_Effect_Smoke_C__pf1079297466 : public AActor
{
public:
	GENERATED_BODY()
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Audio", OverrideNativeName="Smoke Audio"))
	UAudioComponent* bpv__SmokexAudio__pfT;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="P_Smoke"))
	UParticleSystemComponent* bpv__P_Smoke__pf;
	ABlueprint_Effect_Smoke_C__pf1079297466(const FObjectInitializer& ObjectInitializer = FObjectInitializer::Get());
	virtual void PostLoadSubobjects(FObjectInstancingGraph* OuterInstanceGraph) override;
	static void __CustomDynamicClassInitialization(UDynamicClass* InDynamicClass);
	static void __StaticDependenciesAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
	static void __StaticDependencies_DirectlyUsedAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
public:
};
