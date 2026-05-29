#pragma once
#include "Blueprint/BlueprintSupport.h"
#include "Runtime/Engine/Classes/GameFramework/Character.h"
class UStaticMeshComponent;
#include "NewBlueprint8__pf3696703102.generated.h"
UCLASS(config=Game, Blueprintable, BlueprintType, meta=(ReplaceConverted="/Game/res/NewBlueprint8.NewBlueprint8_C,/Game/StarterContent/Shapes/NewBlueprint8.NewBlueprint8_C,/Game/StarterContent/Shapes/NewBlueprint.NewBlueprint_C", OverrideNativeName="NewBlueprint8_C"))
class ANewBlueprint8_C__pf3696703102 : public ACharacter
{
public:
	GENERATED_BODY()
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="Shape_Cube"))
	UStaticMeshComponent* bpv__Shape_Cube__pf;
	ANewBlueprint8_C__pf3696703102(const FObjectInitializer& ObjectInitializer = FObjectInitializer::Get());
	virtual void PostLoadSubobjects(FObjectInstancingGraph* OuterInstanceGraph) override;
	static void __CustomDynamicClassInitialization(UDynamicClass* InDynamicClass);
	static void __StaticDependenciesAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
	static void __StaticDependencies_DirectlyUsedAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
public:
};
