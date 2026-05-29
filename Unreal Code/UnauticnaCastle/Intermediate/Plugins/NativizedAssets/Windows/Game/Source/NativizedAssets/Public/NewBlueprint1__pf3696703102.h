#pragma once
#include "Blueprint/BlueprintSupport.h"
#include "Runtime/Engine/Classes/GameFramework/Character.h"
class UAudioComponent;
class UStaticMeshComponent;
#include "NewBlueprint1__pf3696703102.generated.h"
UCLASS(config=Game, Blueprintable, BlueprintType, meta=(ReplaceConverted="/Game/res/NewBlueprint1.NewBlueprint1_C,/Game/ThirdPersonBP/Blueprints/NewBlueprint1.NewBlueprint1_C", OverrideNativeName="NewBlueprint1_C"))
class ANewBlueprint1_C__pf3696703102 : public ACharacter
{
public:
	GENERATED_BODY()
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="Audio"))
	UAudioComponent* bpv__Audio__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="untitled_Cube"))
	UStaticMeshComponent* bpv__untitled_Cube__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="untitled_Cube_001"))
	UStaticMeshComponent* bpv__untitled_Cube_001__pf;
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="untitled_Cylinder"))
	UStaticMeshComponent* bpv__untitled_Cylinder__pf;
	ANewBlueprint1_C__pf3696703102(const FObjectInitializer& ObjectInitializer = FObjectInitializer::Get());
	virtual void PostLoadSubobjects(FObjectInstancingGraph* OuterInstanceGraph) override;
	static void __CustomDynamicClassInitialization(UDynamicClass* InDynamicClass);
	static void __StaticDependenciesAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
	static void __StaticDependencies_DirectlyUsedAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
public:
};
