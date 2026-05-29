#pragma once
#include "Blueprint/BlueprintSupport.h"
#include "Runtime/Engine/Classes/GameFramework/Character.h"
class UStaticMeshComponent;
#include "NewBlueprint6__pf3696703102.generated.h"
UCLASS(config=Game, Blueprintable, BlueprintType, meta=(ReplaceConverted="/Game/res/NewBlueprint6.NewBlueprint6_C,/Game/StarterContent/Props/NewBlueprint6.NewBlueprint6_C,/Game/StarterContent/Props/NewBlueprint2.NewBlueprint2_C", OverrideNativeName="NewBlueprint6_C"))
class ANewBlueprint6_C__pf3696703102 : public ACharacter
{
public:
	GENERATED_BODY()
	UPROPERTY(BlueprintReadWrite, NonTransactional, meta=(Category="Default", OverrideNativeName="SM_Couch"))
	UStaticMeshComponent* bpv__SM_Couch__pf;
	ANewBlueprint6_C__pf3696703102(const FObjectInitializer& ObjectInitializer = FObjectInitializer::Get());
	virtual void PostLoadSubobjects(FObjectInstancingGraph* OuterInstanceGraph) override;
	static void __CustomDynamicClassInitialization(UDynamicClass* InDynamicClass);
	static void __StaticDependenciesAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
	static void __StaticDependencies_DirectlyUsedAssets(TArray<FBlueprintDependencyData>& AssetsToLoad);
public:
};
