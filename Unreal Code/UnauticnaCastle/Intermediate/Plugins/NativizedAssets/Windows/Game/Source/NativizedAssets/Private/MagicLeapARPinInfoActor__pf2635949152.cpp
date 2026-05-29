#include "NativizedAssets.h"
#include "MagicLeapARPinInfoActor__pf2635949152.h"
#include "GeneratedCodeHelpers.h"
#include "Runtime/Engine/Classes/Engine/SimpleConstructionScript.h"
#include "Runtime/Engine/Classes/Engine/SCS_Node.h"
#include "Runtime/Engine/Classes/Components/SceneComponent.h"
#include "Runtime/Engine/Classes/Components/ActorComponent.h"
#include "Runtime/Engine/Classes/Engine/EngineBaseTypes.h"
#include "Runtime/Engine/Classes/GameFramework/Actor.h"
#include "Runtime/Engine/Classes/GameFramework/DamageType.h"
#include "Runtime/Engine/Classes/Engine/NetSerialization.h"
#include "Runtime/PhysicsCore/Public/PhysicalMaterials/PhysicalMaterial.h"
#include "Runtime/PhysicsCore/Public/PhysicsSettingsEnums.h"
#include "Runtime/PhysicsCore/Public/PhysicalMaterials/PhysicalMaterialPropertyBase.h"
#include "Runtime/PhysicsCore/Public/Chaos/ChaosEngineInterface.h"
#include "Runtime/Engine/Classes/Components/PrimitiveComponent.h"
#include "Runtime/Engine/Classes/Materials/MaterialInterface.h"
#include "Runtime/Engine/Classes/PhysicalMaterials/PhysicalMaterialMask.h"
#include "Runtime/Engine/Classes/Engine/Texture.h"
#include "Runtime/Engine/Classes/EditorFramework/AssetImportData.h"
#include "Runtime/Engine/Classes/Engine/StreamableRenderAsset.h"
#include "Runtime/Engine/Classes/Engine/TextureDefines.h"
#include "Runtime/Engine/Public/PerPlatformProperties.h"
#include "Runtime/Engine/Classes/Engine/AssetUserData.h"
#include "Runtime/Engine/Classes/Interfaces/Interface_AssetUserData.h"
#include "Runtime/Engine/Classes/Materials/MaterialLayersFunctions.h"
#include "Runtime/Engine/Classes/Materials/MaterialFunctionInterface.h"
#include "Runtime/Engine/Classes/EditorFramework/ThumbnailInfo.h"
#include "Runtime/Engine/Classes/Materials/Material.h"
#include "Runtime/Engine/Classes/Materials/MaterialExpression.h"
#include "Runtime/Engine/Classes/Materials/MaterialFunction.h"
#include "Runtime/Engine/Classes/Materials/MaterialExpressionComment.h"
#include "Runtime/Engine/Classes/Materials/MaterialExpressionMaterialFunctionCall.h"
#include "Runtime/Engine/Classes/Materials/MaterialExpressionFunctionInput.h"
#include "Runtime/Engine/Classes/Materials/MaterialExpressionFunctionOutput.h"
#include "Runtime/Engine/Classes/EdGraph/EdGraphNode.h"
#include "Runtime/Engine/Classes/EdGraph/EdGraphPin.h"
#include "Runtime/Engine/Public/MaterialShared.h"
#include "Runtime/Engine/Classes/Engine/BlendableInterface.h"
#include "Runtime/Engine/Public/MaterialCachedData.h"
#include "Runtime/Engine/Classes/Engine/Font.h"
#include "Runtime/Engine/Classes/Engine/Texture2D.h"
#include "Runtime/Engine/Classes/Engine/FontImportOptions.h"
#include "Runtime/SlateCore/Public/Fonts/CompositeFont.h"
#include "Runtime/SlateCore/Public/Fonts/FontBulkData.h"
#include "Runtime/SlateCore/Public/Fonts/FontProviderInterface.h"
#include "Runtime/Engine/Classes/VT/RuntimeVirtualTexture.h"
#include "Runtime/Engine/Public/VT/RuntimeVirtualTextureEnum.h"
#include "Runtime/Engine/Classes/VT/VirtualTexture.h"
#include "Runtime/Engine/Classes/Curves/CurveLinearColor.h"
#include "Runtime/Engine/Classes/Curves/CurveBase.h"
#include "Runtime/Engine/Classes/Curves/RichCurve.h"
#include "Runtime/Engine/Classes/Curves/RealCurve.h"
#include "Runtime/Engine/Classes/Curves/IndexedCurve.h"
#include "Runtime/Engine/Classes/Curves/KeyHandle.h"
#include "Runtime/Engine/Classes/Curves/CurveLinearColorAtlas.h"
#include "Runtime/Engine/Classes/Materials/MaterialParameterCollection.h"
#include "Runtime/Landscape/Classes/LandscapeGrassType.h"
#include "Runtime/Engine/Classes/Engine/StaticMesh.h"
#include "Runtime/Engine/Public/Components.h"
#include "Runtime/Engine/Classes/Engine/StaticMeshSocket.h"
#include "Runtime/StaticMeshDescription/Public/StaticMeshDescription.h"
#include "Runtime/MeshDescription/Public/MeshDescriptionBase.h"
#include "Runtime/MeshDescription/Public/MeshTypes.h"
#include "Runtime/Engine/Classes/PhysicsEngine/BodySetup.h"
#include "Runtime/PhysicsCore/Public/BodySetupCore.h"
#include "Runtime/PhysicsCore/Public/BodySetupEnums.h"
#include "Runtime/Engine/Classes/PhysicsEngine/AggregateGeom.h"
#include "Runtime/Engine/Classes/PhysicsEngine/SphereElem.h"
#include "Runtime/Engine/Classes/PhysicsEngine/ShapeElem.h"
#include "Runtime/Engine/Classes/PhysicsEngine/BoxElem.h"
#include "Runtime/Engine/Classes/PhysicsEngine/SphylElem.h"
#include "Runtime/Engine/Classes/PhysicsEngine/ConvexElem.h"
#include "Runtime/Engine/Classes/PhysicsEngine/TaperedCapsuleElem.h"
#include "Runtime/Engine/Classes/PhysicsEngine/BodyInstance.h"
#include "Runtime/PhysicsCore/Public/BodyInstanceCore.h"
#include "Runtime/Engine/Classes/AI/Navigation/NavCollisionBase.h"
#include "Runtime/Engine/Classes/Interfaces/Interface_CollisionDataProvider.h"
#include "Runtime/Engine/Classes/Engine/MeshMerging.h"
#include "Runtime/Engine/Classes/Engine/SubsurfaceProfile.h"
#include "Runtime/Engine/Classes/Materials/MaterialInstanceDynamic.h"
#include "Runtime/Engine/Classes/Materials/MaterialInstance.h"
#include "Runtime/Engine/Classes/Materials/MaterialInstanceBasePropertyOverrides.h"
#include "Runtime/Engine/Public/StaticParameterSet.h"
#include "Runtime/Engine/Classes/GameFramework/Pawn.h"
#include "Runtime/Engine/Classes/GameFramework/Controller.h"
#include "Runtime/Engine/Classes/GameFramework/PlayerController.h"
#include "Runtime/InputCore/Classes/InputCoreTypes.h"
#include "Runtime/Engine/Classes/Camera/PlayerCameraManager.h"
#include "Runtime/UMG/Public/Blueprint/UserWidget.h"
#include "Runtime/UMG/Public/Components/Widget.h"
#include "Runtime/UMG/Public/Components/Visual.h"
#include "Runtime/UMG/Public/Components/SlateWrapperTypes.h"
#include "Runtime/UMG/Public/Slate/WidgetTransform.h"
#include "Runtime/SlateCore/Public/Types/SlateEnums.h"
#include "Runtime/SlateCore/Public/Input/NavigationReply.h"
#include "Runtime/SlateCore/Public/Layout/Clipping.h"
#include "Runtime/SlateCore/Public/Layout/Geometry.h"
#include "Runtime/SlateCore/Public/Input/Events.h"
#include "Runtime/SlateCore/Public/Styling/SlateColor.h"
#include "Runtime/SlateCore/Public/Styling/SlateBrush.h"
#include "Runtime/SlateCore/Public/Layout/Margin.h"
#include "Runtime/UMG/Public/Components/PanelWidget.h"
#include "Runtime/UMG/Public/Components/PanelSlot.h"
#include "Runtime/Engine/Classes/Engine/LocalPlayer.h"
#include "Runtime/Engine/Classes/Engine/Player.h"
#include "Runtime/Engine/Classes/Engine/GameViewportClient.h"
#include "Runtime/Engine/Classes/Engine/ScriptViewportClient.h"
#include "Runtime/Engine/Classes/Engine/Console.h"
#include "Runtime/Engine/Classes/Engine/DebugDisplayProperty.h"
#include "Runtime/Engine/Classes/Engine/World.h"
#include "Runtime/Engine/Classes/GameFramework/WorldSettings.h"
#include "Runtime/Engine/Classes/GameFramework/Info.h"
#include "Runtime/Engine/Classes/Components/BillboardComponent.h"
#include "Runtime/Engine/Classes/AI/NavigationSystemConfig.h"
#include "Runtime/Engine/Classes/AI/Navigation/NavigationTypes.h"
#include "Runtime/Engine/Classes/GameFramework/DefaultPhysicsVolume.h"
#include "Runtime/Engine/Classes/GameFramework/PhysicsVolume.h"
#include "Runtime/Engine/Classes/GameFramework/Volume.h"
#include "Runtime/Engine/Classes/Engine/Brush.h"
#include "Runtime/Engine/Classes/Components/BrushComponent.h"
#include "Runtime/Engine/Classes/Engine/BrushBuilder.h"
#include "Runtime/Engine/Classes/PhysicsEngine/PhysicsCollisionHandler.h"
#include "Runtime/Engine/Classes/Sound/SoundBase.h"
#include "Runtime/Engine/Classes/Sound/SoundClass.h"
#include "Runtime/Engine/Classes/Sound/SoundModulationDestination.h"
#include "Runtime/AudioExtensions/Public/IAudioModulation.h"
#include "Runtime/Engine/Classes/Sound/AudioOutputTarget.h"
#include "Runtime/Engine/Classes/Sound/SoundWaveLoadingBehavior.h"
#include "Runtime/Engine/Classes/Sound/SoundSubmix.h"
#include "Runtime/Engine/Classes/Sound/SoundSubmixSend.h"
#include "Runtime/Engine/Classes/Sound/SoundWave.h"
#include "Runtime/AudioPlatformConfiguration/Public/AudioCompressionSettings.h"
#include "Runtime/Engine/Classes/Sound/SoundGroups.h"
#include "Runtime/Engine/Classes/Engine/CurveTable.h"
#include "Runtime/Engine/Classes/Sound/SoundEffectSubmix.h"
#include "Runtime/Engine/Classes/Sound/SoundEffectPreset.h"
#include "Runtime/AudioExtensions/Public/ISoundfieldFormat.h"
#include "Runtime/Engine/Classes/Sound/SoundMix.h"
#include "Runtime/Engine/Classes/Sound/SoundConcurrency.h"
#include "Runtime/Engine/Classes/Sound/SoundAttenuation.h"
#include "Runtime/Engine/Classes/Engine/Attenuation.h"
#include "Runtime/Engine/Classes/Curves/CurveFloat.h"
#include "Runtime/AudioExtensions/Public/IAudioExtensionPlugin.h"
#include "Runtime/Engine/Classes/Sound/SoundEffectSource.h"
#include "Runtime/Engine/Classes/Sound/SoundSourceBusSend.h"
#include "Runtime/Engine/Classes/Sound/SoundSourceBus.h"
#include "Runtime/Engine/Classes/Sound/AudioBus.h"
#include "Runtime/Engine/Classes/GameFramework/GameModeBase.h"
#include "Runtime/Engine/Classes/GameFramework/PlayerState.h"
#include "Runtime/Engine/Classes/GameFramework/LocalMessage.h"
#include "Runtime/Engine/Classes/GameFramework/OnlineReplStructs.h"
#include "Runtime/CoreUObject/Public/UObject/CoreOnline.h"
#include "Runtime/Engine/Classes/GameFramework/EngineMessage.h"
#include "Runtime/Engine/Classes/GameFramework/GameSession.h"
#include "Runtime/Engine/Classes/GameFramework/GameStateBase.h"
#include "Runtime/Engine/Classes/GameFramework/SpectatorPawn.h"
#include "Runtime/Engine/Classes/GameFramework/DefaultPawn.h"
#include "Runtime/Engine/Classes/GameFramework/PawnMovementComponent.h"
#include "Runtime/Engine/Classes/GameFramework/NavMovementComponent.h"
#include "Runtime/Engine/Classes/GameFramework/MovementComponent.h"
#include "Runtime/Engine/Classes/Components/SphereComponent.h"
#include "Runtime/Engine/Classes/Components/ShapeComponent.h"
#include "Runtime/Engine/Classes/AI/Navigation/NavAreaBase.h"
#include "Runtime/Engine/Classes/Components/StaticMeshComponent.h"
#include "Runtime/Engine/Classes/Components/MeshComponent.h"
#include "Runtime/Engine/Classes/Engine/TextureStreamingTypes.h"
#include "Runtime/Engine/Classes/GameFramework/FloatingPawnMovement.h"
#include "Runtime/AIModule/Classes/AIController.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BlackboardData.h"
#include "Runtime/Engine/Classes/Engine/DataAsset.h"
#include "Runtime/AIModule/Classes/BehaviorTree/Blackboard/BlackboardKeyType.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BlackboardComponent.h"
#include "Runtime/AIModule/Classes/BrainComponent.h"
#include "Runtime/AIModule/Classes/AIResourceInterface.h"
#include "Runtime/GameplayTasks/Classes/GameplayTaskResource.h"
#include "Runtime/AIModule/Classes/Navigation/PathFollowingComponent.h"
#include "Runtime/NavigationSystem/Public/NavigationData.h"
#include "Runtime/Engine/Classes/AI/Navigation/NavigationDataInterface.h"
#include "Runtime/Engine/Classes/AI/Navigation/PathFollowingAgentInterface.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BehaviorTree.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BTCompositeNode.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BTNode.h"
#include "Runtime/GameplayTasks/Classes/GameplayTaskOwnerInterface.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BTTaskNode.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BTService.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BTAuxiliaryNode.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BTDecorator.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BehaviorTreeTypes.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BlackboardAssetProvider.h"
#include "Runtime/Engine/Classes/EdGraph/EdGraph.h"
#include "Runtime/Engine/Classes/EdGraph/EdGraphSchema.h"
#include "Runtime/Engine/Classes/Engine/Blueprint.h"
#include "Runtime/GameplayTasks/Classes/GameplayTask.h"
#include "Runtime/NavigationSystem/Public/NavFilters/NavigationQueryFilter.h"
#include "Runtime/NavigationSystem/Public/NavAreas/NavArea.h"
#include "Runtime/AIModule/Classes/Perception/AIPerceptionComponent.h"
#include "Runtime/AIModule/Classes/Perception/AISense.h"
#include "Runtime/AIModule/Classes/Perception/AIPerceptionTypes.h"
#include "Runtime/AIModule/Classes/Perception/AIPerceptionSystem.h"
#include "Runtime/AIModule/Classes/AISubsystem.h"
#include "Runtime/AIModule/Classes/AISystem.h"
#include "Runtime/Engine/Classes/AI/AISystemBase.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BehaviorTreeManager.h"
#include "Runtime/AIModule/Classes/BehaviorTree/BehaviorTreeComponent.h"
#include "Runtime/GameplayTags/Classes/GameplayTagContainer.h"
#include "Runtime/AIModule/Classes/EnvironmentQuery/EnvQueryManager.h"
#include "Runtime/AIModule/Classes/EnvironmentQuery/EnvQuery.h"
#include "Runtime/AIModule/Classes/EnvironmentQuery/EnvQueryOption.h"
#include "Runtime/AIModule/Classes/EnvironmentQuery/EnvQueryGenerator.h"
#include "Runtime/AIModule/Classes/EnvironmentQuery/EnvQueryNode.h"
#include "Runtime/AIModule/Classes/EnvironmentQuery/Items/EnvQueryItemType.h"
#include "Runtime/AIModule/Classes/EnvironmentQuery/EnvQueryTest.h"
#include "Runtime/AIModule/Classes/EnvironmentQuery/EnvQueryTypes.h"
#include "Runtime/AIModule/Classes/DataProviders/AIDataProvider.h"
#include "Runtime/AIModule/Classes/EnvironmentQuery/EnvQueryInstanceBlueprintWrapper.h"
#include "Runtime/AIModule/Classes/EnvironmentQuery/EQSQueryResultSourceInterface.h"
#include "Runtime/AIModule/Classes/EnvironmentQuery/EnvQueryContext.h"
#include "Runtime/AIModule/Classes/Blueprint/AIAsyncTaskBlueprintProxy.h"
#include "Runtime/AIModule/Classes/AITypes.h"
#include "Runtime/AIModule/Classes/HotSpots/AIHotSpotManager.h"
#include "Runtime/AIModule/Classes/Navigation/NavLocalGridManager.h"
#include "Runtime/AIModule/Classes/Perception/AISenseEvent.h"
#include "Runtime/AIModule/Classes/Perception/AISenseConfig.h"
#include "Runtime/AIModule/Classes/Actions/PawnActionsComponent.h"
#include "Runtime/AIModule/Classes/Actions/PawnAction.h"
#include "Runtime/GameplayTasks/Classes/GameplayTasksComponent.h"
#include "Runtime/AIModule/Classes/Perception/AIPerceptionListenerInterface.h"
#include "Runtime/AIModule/Classes/GenericTeamAgentInterface.h"
#include "Runtime/Engine/Public/VisualLogger/VisualLoggerDebugSnapshotInterface.h"
#include "Runtime/Engine/Classes/GameFramework/SpectatorPawnMovement.h"
#include "Runtime/Engine/Classes/GameFramework/HUD.h"
#include "Runtime/Engine/Classes/Engine/Canvas.h"
#include "Runtime/Engine/Classes/Debug/ReporterGraph.h"
#include "Runtime/Engine/Classes/Debug/ReporterBase.h"
#include "Runtime/Engine/Classes/GameFramework/DebugTextInfo.h"
#include "Runtime/Engine/Classes/Engine/ServerStatReplicator.h"
#include "Runtime/Engine/Classes/GameFramework/GameNetworkManager.h"
#include "Runtime/Engine/Classes/Sound/ReverbSettings.h"
#include "Runtime/Engine/Classes/Sound/ReverbEffect.h"
#include "Runtime/Engine/Classes/Sound/AudioVolume.h"
#include "Runtime/Engine/Classes/Engine/NetConnection.h"
#include "Runtime/Engine/Classes/Engine/ChildConnection.h"
#include "Runtime/Engine/Classes/Engine/PackageMapClient.h"
#include "Runtime/Engine/Classes/Engine/NetDriver.h"
#include "Runtime/Engine/Classes/Engine/Channel.h"
#include "Runtime/Engine/Classes/Engine/ReplicationDriver.h"
#include "Runtime/Engine/Classes/Engine/BookmarkBase.h"
#include "Runtime/Engine/Classes/Engine/BookMark.h"
#include "Runtime/Engine/Classes/Engine/MaterialMerging.h"
#include "Runtime/Engine/Classes/Engine/Level.h"
#include "Runtime/Engine/Classes/Components/ModelComponent.h"
#include "Runtime/Engine/Classes/Engine/LevelActorContainer.h"
#include "Runtime/Engine/Classes/Engine/LevelScriptActor.h"
#include "Runtime/Engine/Classes/Engine/NavigationObjectBase.h"
#include "Runtime/Engine/Classes/Components/CapsuleComponent.h"
#include "Runtime/Engine/Classes/AI/Navigation/NavAgentInterface.h"
#include "Runtime/Engine/Classes/AI/Navigation/NavigationDataChunk.h"
#include "Runtime/Engine/Classes/Engine/MapBuildDataRegistry.h"
#include "Runtime/Engine/Classes/Engine/LevelScriptBlueprint.h"
#include "Runtime/Engine/Classes/Engine/BlueprintCore.h"
#include "Runtime/Engine/Classes/Engine/BlueprintGeneratedClass.h"
#include "Runtime/Engine/Classes/Engine/TimelineTemplate.h"
#include "Runtime/Engine/Classes/Components/TimelineComponent.h"
#include "Runtime/Engine/Classes/Curves/CurveVector.h"
#include "Runtime/Engine/Classes/Engine/InheritableComponentHandler.h"
#include "Runtime/CoreUObject/Public/UObject/CoreNetTypes.h"
#include "Runtime/Engine/Classes/Engine/Breakpoint.h"
#include "Runtime/Engine/Public/Blueprint/BlueprintExtension.h"
#include "Runtime/Engine/Classes/Components/LineBatchComponent.h"
#include "Runtime/Engine/Classes/Engine/LevelStreaming.h"
#include "Runtime/Engine/Classes/Engine/LevelStreamingVolume.h"
#include "Runtime/Engine/Classes/Engine/DemoNetDriver.h"
#include "Runtime/Engine/Classes/Particles/ParticleEventManager.h"
#include "Runtime/Engine/Classes/AI/NavigationSystemBase.h"
#include "Runtime/Engine/Classes/AI/Navigation/AvoidanceManager.h"
#include "Runtime/Engine/Classes/Engine/GameInstance.h"
#include "Runtime/Engine/Classes/GameFramework/OnlineSession.h"
#include "Runtime/Engine/Classes/Materials/MaterialParameterCollectionInstance.h"
#include "Runtime/Engine/Classes/PhysicsField/PhysicsFieldComponent.h"
#include "Runtime/Engine/Classes/Engine/WorldComposition.h"
#include "Runtime/Engine/Classes/Particles/WorldPSCPool.h"
#include "Runtime/Engine/Classes/Particles/ParticleSystem.h"
#include "Runtime/Engine/Classes/Particles/ParticleEmitter.h"
#include "Runtime/Engine/Public/ParticleHelper.h"
#include "Runtime/Engine/Classes/Particles/ParticleLODLevel.h"
#include "Runtime/Engine/Classes/Particles/ParticleModuleRequired.h"
#include "Runtime/Engine/Classes/Particles/ParticleModule.h"
#include "Runtime/Engine/Classes/Particles/ParticleSpriteEmitter.h"
#include "Runtime/Engine/Classes/Distributions/DistributionFloat.h"
#include "Runtime/Engine/Classes/Distributions/Distribution.h"
#include "Runtime/Engine/Classes/Particles/SubUVAnimation.h"
#include "Runtime/Engine/Classes/Particles/TypeData/ParticleModuleTypeDataBase.h"
#include "Runtime/Engine/Classes/Particles/Spawn/ParticleModuleSpawn.h"
#include "Runtime/Engine/Classes/Particles/Spawn/ParticleModuleSpawnBase.h"
#include "Runtime/Engine/Classes/Particles/Event/ParticleModuleEventGenerator.h"
#include "Runtime/Engine/Classes/Particles/Event/ParticleModuleEventBase.h"
#include "Runtime/Engine/Classes/Particles/ParticleSystemComponent.h"
#include "Runtime/Engine/Classes/Particles/Event/ParticleModuleEventSendToGame.h"
#include "Runtime/Engine/Classes/Particles/Orbit/ParticleModuleOrbit.h"
#include "Runtime/Engine/Classes/Particles/Orbit/ParticleModuleOrbitBase.h"
#include "Runtime/Engine/Classes/Distributions/DistributionVector.h"
#include "Runtime/Engine/Classes/Particles/Event/ParticleModuleEventReceiverBase.h"
#include "Runtime/Engine/Classes/Components/SkeletalMeshComponent.h"
#include "Runtime/Engine/Classes/Components/SkinnedMeshComponent.h"
#include "Runtime/Engine/Classes/Engine/SkeletalMesh.h"
#include "Runtime/Engine/Classes/Animation/MorphTarget.h"
#include "Runtime/ClothingSystemRuntimeInterface/Public/ClothingAssetBase.h"
#include "Runtime/Engine/Classes/Engine/SkeletalMeshLODSettings.h"
#include "Runtime/Engine/Classes/Animation/AnimSequence.h"
#include "Runtime/Engine/Classes/Animation/AnimSequenceBase.h"
#include "Runtime/Engine/Classes/Animation/AnimationAsset.h"
#include "Runtime/Engine/Classes/Animation/Skeleton.h"
#include "Runtime/Engine/Classes/Engine/SkeletalMeshSocket.h"
#include "Runtime/Engine/Classes/Animation/SmartName.h"
#include "Runtime/Engine/Classes/Animation/BlendProfile.h"
#include "Runtime/Engine/Public/BoneContainer.h"
#include "Runtime/Engine/Classes/Interfaces/Interface_PreviewMeshProvider.h"
#include "Runtime/Engine/Classes/Animation/Rig.h"
#include "Runtime/Engine/Public/Animation/NodeMappingProviderInterface.h"
#include "Runtime/Engine/Classes/Animation/PreviewAssetAttachComponent.h"
#include "Runtime/Engine/Classes/Animation/AnimMetaData.h"
#include "Runtime/Engine/Classes/Animation/AssetMappingTable.h"
#include "Runtime/Engine/Classes/Animation/PoseAsset.h"
#include "Runtime/Engine/Public/Animation/AnimCurveTypes.h"
#include "Runtime/Engine/Public/Animation/AnimTypes.h"
#include "Runtime/Engine/Classes/Animation/AnimLinkableElement.h"
#include "Runtime/Engine/Classes/Animation/AnimMontage.h"
#include "Runtime/Engine/Classes/Animation/AnimCompositeBase.h"
#include "Runtime/Engine/Public/AlphaBlend.h"
#include "Runtime/Engine/Classes/Animation/AnimEnums.h"
#include "Runtime/Engine/Classes/Animation/TimeStretchCurve.h"
#include "Runtime/Engine/Classes/Animation/AnimNotifies/AnimNotify.h"
#include "Runtime/Engine/Classes/Animation/AnimNotifies/AnimNotifyState.h"
#include "Runtime/Engine/Classes/Animation/AnimBoneCompressionSettings.h"
#include "Runtime/Engine/Classes/Animation/AnimBoneCompressionCodec.h"
#include "Runtime/Engine/Classes/Animation/AnimCurveCompressionSettings.h"
#include "Runtime/Engine/Classes/Animation/AnimCurveCompressionCodec.h"
#include "Runtime/Engine/Classes/Animation/AnimCurveCompressionCodec_CompressedRichCurve.h"
#include "Runtime/Engine/Classes/Animation/CustomAttributes.h"
#include "Runtime/Engine/Classes/Curves/StringCurve.h"
#include "Runtime/Engine/Classes/Curves/IntegralCurve.h"
#include "Runtime/Engine/Classes/Curves/SimpleCurve.h"
#include "Runtime/Engine/Public/SkeletalMeshReductionSettings.h"
#include "Runtime/Engine/Classes/PhysicsEngine/PhysicsAsset.h"
#include "Runtime/Engine/Classes/PhysicsEngine/PhysicalAnimationComponent.h"
#include "Runtime/Engine/Classes/PhysicsEngine/PhysicsConstraintTemplate.h"
#include "Runtime/Engine/Classes/PhysicsEngine/ConstraintInstance.h"
#include "Runtime/Engine/Classes/PhysicsEngine/ConstraintTypes.h"
#include "Runtime/Engine/Classes/PhysicsEngine/ConstraintDrives.h"
#include "Runtime/Engine/Public/Animation/NodeMappingContainer.h"
#include "Runtime/Engine/Classes/Animation/AnimInstance.h"
#include "Runtime/Engine/Public/Animation/PoseSnapshot.h"
#include "Runtime/Engine/Public/Animation/AnimNotifyQueue.h"
#include "Runtime/Engine/Classes/Engine/SkeletalMeshSampling.h"
#include "Runtime/Engine/Public/Animation/SkinWeightProfile.h"
#include "Runtime/Engine/Classes/Engine/SkeletalMeshEditorData.h"
#include "Runtime/Engine/Public/LODSyncInterface.h"
#include "Runtime/ClothingSystemRuntimeInterface/Public/ClothingSimulationInteractor.h"
#include "Runtime/Engine/Classes/Animation/AnimBlueprintGeneratedClass.h"
#include "Runtime/Engine/Classes/Engine/DynamicBlueprintBinding.h"
#include "Runtime/Engine/Classes/Animation/AnimStateMachineTypes.h"
#include "Runtime/Engine/Classes/Animation/AnimClassInterface.h"
#include "Runtime/Engine/Classes/Animation/AnimNodeBase.h"
#include "Runtime/PropertyAccess/Public/PropertyAccess.h"
#include "Runtime/Engine/Public/SingleAnimationPlayData.h"
#include "Runtime/ClothingSystemRuntimeInterface/Public/ClothingSimulationFactory.h"
#include "Runtime/Engine/Classes/Animation/AnimBlueprint.h"
#include "Runtime/Engine/Classes/Engine/PoseWatch.h"
#include "Runtime/Engine/Classes/Particles/ParticleSystemReplay.h"
#include "Runtime/Engine/Classes/Engine/InterpCurveEdSetup.h"
#include "Runtime/Engine/Classes/Layers/Layer.h"
#include "Runtime/Engine/Classes/Engine/Engine.h"
#include "Runtime/Engine/Classes/GameFramework/GameUserSettings.h"
#include "Runtime/Engine/Classes/Engine/AssetManager.h"
#include "Runtime/Engine/Classes/Engine/EngineCustomTimeStep.h"
#include "Runtime/Engine/Classes/Engine/TimecodeProvider.h"
#include "Runtime/SlateCore/Public/Styling/SlateTypes.h"
#include "Runtime/UMG/Public/Blueprint/WidgetNavigation.h"
#include "Runtime/SlateCore/Public/Layout/FlowDirection.h"
#include "Runtime/UMG/Public/Binding/PropertyBinding.h"
#include "Runtime/UMG/Public/Binding/DynamicPropertyPath.h"
#include "Runtime/PropertyPath/Public/PropertyPathHelpers.h"
#include "Runtime/UMG/Public/Animation/WidgetAnimation.h"
#include "Runtime/MovieScene/Public/MovieSceneSequence.h"
#include "Runtime/MovieScene/Public/MovieSceneSignedObject.h"
#include "Runtime/MovieScene/Public/MovieSceneObjectBindingID.h"
#include "Runtime/MovieScene/Public/Compilation/MovieSceneCompiledDataManager.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneEvaluationTemplate.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneTrackIdentifier.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneEvaluationTrack.h"
#include "Runtime/MovieScene/Public/MovieSceneTrack.h"
#include "Runtime/MovieScene/Public/MovieSceneTrackEvaluationField.h"
#include "Runtime/MovieScene/Public/MovieSceneSection.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneCompletionMode.h"
#include "Runtime/MovieScene/Public/Evaluation/Blending/MovieSceneBlendType.h"
#include "Runtime/MovieScene/Public/Generators/MovieSceneEasingFunction.h"
#include "Runtime/MovieScene/Public/MovieSceneFrameMigration.h"
#include "Runtime/MovieScene/Public/Generators/MovieSceneEasingCurves.h"
#include "Runtime/MovieScene/Public/MovieScene.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneSegment.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneEvalTemplate.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneTrackImplementation.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneSequenceHierarchy.h"
#include "Runtime/MovieScene/Public/MovieSceneSequenceID.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneSequenceTransform.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneTimeTransform.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneTimeWarping.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneSequenceInstanceData.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneEvaluationField.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneEvaluationKey.h"
#include "Runtime/MovieScene/Public/MovieSceneFwd.h"
#include "Runtime/MovieScene/Public/MovieSceneSpawnable.h"
#include "Runtime/MovieScene/Public/MovieScenePossessable.h"
#include "Runtime/MovieScene/Public/MovieSceneBinding.h"
#include "Runtime/MovieScene/Public/MovieSceneFolder.h"
#include "Runtime/UMG/Public/Animation/WidgetAnimationBinding.h"
#include "Runtime/Slate/Public/Widgets/Layout/Anchors.h"
#include "Runtime/UMG/Public/Animation/UMGSequencePlayer.h"
#include "Runtime/MovieScene/Public/Evaluation/MovieSceneEvaluationTemplateInstance.h"
#include "Runtime/MovieScene/Public/EntitySystem/MovieSceneEntitySystemLinker.h"
#include "Runtime/MovieScene/Public/EntitySystem/MovieSceneEntitySystemGraphs.h"
#include "Runtime/UMG/Public/Blueprint/DragDropOperation.h"
#include "Runtime/Engine/Classes/Camera/CameraShakeBase.h"
#include "Runtime/Engine/Classes/Camera/CameraAnimInst.h"
#include "Runtime/Engine/Classes/Camera/CameraAnim.h"
#include "Runtime/Engine/Classes/Matinee/InterpGroup.h"
#include "Runtime/Engine/Classes/Matinee/InterpTrack.h"
#include "Runtime/Engine/Classes/Matinee/InterpTrackInst.h"
#include "Runtime/Engine/Classes/Engine/Scene.h"
#include "Runtime/Engine/Classes/Engine/TextureCube.h"
#include "Runtime/Engine/Classes/Matinee/InterpGroupInst.h"
#include "Runtime/Engine/Classes/Matinee/InterpTrackMove.h"
#include "Runtime/Engine/Classes/Matinee/InterpTrackInstMove.h"
#include "Runtime/Engine/Classes/Camera/CameraTypes.h"
#include "Runtime/Engine/Classes/Camera/CameraShakeSourceComponent.h"
#include "Runtime/Engine/Classes/Camera/CameraModifier.h"
#include "Runtime/Engine/Classes/Particles/EmitterCameraLensEffectBase.h"
#include "Runtime/Engine/Classes/Particles/Emitter.h"
#include "Runtime/Engine/Classes/Components/ArrowComponent.h"
#include "Runtime/Engine/Classes/Camera/CameraModifier_CameraShake.h"
#include "Runtime/Engine/Classes/Camera/CameraActor.h"
#include "Runtime/Engine/Classes/Camera/CameraComponent.h"
#include "Runtime/UMG/Public/Animation/UMGSequenceTickManager.h"
#include "Runtime/UMG/Public/Blueprint/WidgetTree.h"
#include "Runtime/Engine/Classes/Components/InputComponent.h"
#include "Runtime/Engine/Classes/GameFramework/PlayerInput.h"
#include "Runtime/UMG/Public/Components/NamedSlotInterface.h"
#include "Runtime/Engine/Classes/GameFramework/UpdateLevelVisibilityLevelInfo.h"
#include "Runtime/Engine/Classes/Haptics/HapticFeedbackEffect_Base.h"
#include "Runtime/Engine/Classes/Engine/LatentActionManager.h"
#include "Runtime/Engine/Classes/GameFramework/ForceFeedbackEffect.h"
#include "Runtime/Engine/Classes/GameFramework/TouchInterface.h"
#include "Runtime/Engine/Classes/Matinee/InterpTrackInstDirector.h"
#include "Runtime/Engine/Classes/GameFramework/CheatManager.h"
#include "Runtime/Engine/Classes/Engine/DebugCameraController.h"
#include "Runtime/Engine/Classes/Components/DrawFrustumComponent.h"
#include "Runtime/Engine/Classes/GameFramework/Character.h"
#include "Runtime/Engine/Classes/GameFramework/CharacterMovementReplication.h"
#include "Runtime/Engine/Classes/GameFramework/RootMotionSource.h"
#include "Runtime/Engine/Classes/GameFramework/CharacterMovementComponent.h"
#include "Runtime/Engine/Classes/AI/Navigation/NavigationAvoidanceTypes.h"
#include "Runtime/Engine/Public/AI/RVOAvoidanceInterface.h"
#include "Runtime/Engine/Classes/Interfaces/NetworkPredictionInterface.h"
#include "Runtime/Engine/Public/SceneTypes.h"
#include "Runtime/Engine/Classes/AI/Navigation/NavRelevantInterface.h"
#include "Runtime/Engine/Public/HitProxies.h"
#include "Runtime/Engine/Classes/Components/ChildActorComponent.h"
#include "Runtime/Engine/Classes/Matinee/MatineeActor.h"
#include "Runtime/Engine/Classes/Matinee/InterpData.h"
#include "Runtime/Engine/Classes/Matinee/InterpGroupDirector.h"
#include "Runtime/Engine/Classes/Matinee/InterpFilter.h"
#include "Runtime/Engine/Public/ComponentInstanceDataCache.h"
#include "Runtime/Engine/Classes/Components/TextRenderComponent.h"
#include "Runtime/NavigationSystem/Public/NavAreas/NavArea_Obstacle.h"
#include "Runtime/Engine/Classes/Kismet/GameplayStatics.h"
#include "Runtime/Engine/Classes/Kismet/BlueprintFunctionLibrary.h"
#include "Runtime/Engine/Classes/Components/AudioComponent.h"
#include "Runtime/AudioMixer/Public/Quartz/AudioMixerClockHandle.h"
#include "Runtime/Engine/Classes/Sound/QuartzQuantizationUtilities.h"
#include "Runtime/AudioMixer/Public/Quartz/QuartzSubsystem.h"
#include "Runtime/Engine/Public/Subsystems/WorldSubsystem.h"
#include "Runtime/Engine/Public/Subsystems/Subsystem.h"
#include "Runtime/Engine/Classes/GameFramework/ForceFeedbackAttenuation.h"
#include "Runtime/Engine/Classes/Components/ForceFeedbackComponent.h"
#include "Runtime/Engine/Classes/Sound/DialogueWave.h"
#include "Runtime/Engine/Classes/Sound/DialogueTypes.h"
#include "Runtime/Engine/Classes/Sound/DialogueVoice.h"
#include "Runtime/Engine/Classes/Sound/DialogueSoundWaveProxy.h"
#include "Runtime/Engine/Classes/Components/DecalComponent.h"
#include "Runtime/Engine/Classes/GameFramework/SaveGame.h"
#include "Runtime/Engine/Classes/Kismet/GameplayStaticsTypes.h"
#include "Runtime/Engine/Classes/Kismet/KismetSystemLibrary.h"
#include "Runtime/Engine/Classes/Kismet/KismetMathLibrary.h"
#include "../Plugins/Lumin/MagicLeapPassableWorld/Source/MagicLeapARPin/Public/MagicLeapARPinFunctionLibrary.h"
#include "Runtime/Engine/Classes/Kismet/KismetTextLibrary.h"
#include "Runtime/Engine/Classes/Kismet/KismetNodeHelperLibrary.h"


#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
PRAGMA_DISABLE_OPTIMIZATION
AMagicLeapARPinInfoActor_C__pf2635949152::AMagicLeapARPinInfoActor_C__pf2635949152(const FObjectInitializer& ObjectInitializer) : Super()
{
	
	auto __Local__0 = CastChecked<USceneComponent>(this->GetDefaultSubobjectByName(TEXT("RootComponent")), ECastCheckedType::NullAllowed);
	if(__Local__0)
	{
		// --- Default subobject 'RootComponent' //
		static TWeakFieldPtr<FProperty> __Local__2{};
		const FProperty* __Local__1 = __Local__2.Get();
		if (nullptr == __Local__1)
		{
			__Local__1 = (UActorComponent::StaticClass())->FindPropertyByName(FName(TEXT("bCanEverAffectNavigation")));
			check(__Local__1);
			__Local__2 = __Local__1;
		}
		(((FBoolProperty*)__Local__1)->SetPropertyValue_InContainer((__Local__0), false, 0));
		// --- END default subobject 'RootComponent' //
	}
	bpv__Root__pf = CreateDefaultSubobject<USceneComponent>(TEXT("Root"));
	bpv__InfoRoot__pf = CreateDefaultSubobject<USceneComponent>(TEXT("InfoRoot"));
	bpv__PinIDValue__pf = CreateDefaultSubobject<UTextRenderComponent>(TEXT("PinIDValue"));
	bpv__ConfidenceLabel__pf = CreateDefaultSubobject<UTextRenderComponent>(TEXT("ConfidenceLabel"));
	bpv__RotErrLabel__pf = CreateDefaultSubobject<UTextRenderComponent>(TEXT("RotErrLabel"));
	bpv__TransErrLabel__pf = CreateDefaultSubobject<UTextRenderComponent>(TEXT("TransErrLabel"));
	bpv__ConfidenceValue__pf = CreateDefaultSubobject<UTextRenderComponent>(TEXT("ConfidenceValue"));
	bpv__RotErrValue__pf = CreateDefaultSubobject<UTextRenderComponent>(TEXT("RotErrValue"));
	bpv__TransErrValue__pf = CreateDefaultSubobject<UTextRenderComponent>(TEXT("TransErrValue"));
	bpv__TypeValue__pf = CreateDefaultSubobject<UTextRenderComponent>(TEXT("TypeValue"));
	bpv__VisualizerRoot__pf = CreateDefaultSubobject<USceneComponent>(TEXT("VisualizerRoot"));
	bpv__AxisRoot__pf = CreateDefaultSubobject<USceneComponent>(TEXT("AxisRoot"));
	bpv__Up__pf = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("Up"));
	bpv__Forward__pf = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("Forward"));
	bpv__Right__pf = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("Right"));
	bpv__ValidRadiusVisualizer__pf = CreateDefaultSubobject<USphereComponent>(TEXT("ValidRadiusVisualizer"));
	bpv__Root__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__Root__pf->AttachToComponent(__Local__0, FAttachmentTransformRules::KeepRelativeTransform );
	static TWeakFieldPtr<FProperty> __Local__4{};
	const FProperty* __Local__3 = __Local__4.Get();
	if (nullptr == __Local__3)
	{
		__Local__3 = (UActorComponent::StaticClass())->FindPropertyByName(FName(TEXT("bCanEverAffectNavigation")));
		check(__Local__3);
		__Local__4 = __Local__3;
	}
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__Root__pf), false, 0));
	bpv__InfoRoot__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__InfoRoot__pf->AttachToComponent(bpv__Root__pf, FAttachmentTransformRules::KeepRelativeTransform );
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__InfoRoot__pf), false, 0));
	bpv__PinIDValue__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__PinIDValue__pf->AttachToComponent(bpv__InfoRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	bpv__PinIDValue__pf->Text = FTextStringHelper::CreateFromBuffer(
TEXT("NSLOCTEXT(\"[A29B5640476C96BA9730579D0D9C51D6]\", \"75D84E42475D99C377A90599F8F8BBB4\", \"PinID\")")	);
	bpv__PinIDValue__pf->HorizontalAlignment = EHorizTextAligment::EHTA_Center;
	bpv__PinIDValue__pf->VerticalAlignment = EVerticalTextAligment::EVRTA_TextTop;
	bpv__PinIDValue__pf->WorldSize = 6.000000f;
	auto& __Local__5 = (*(AccessPrivateProperty<FVector >((bpv__PinIDValue__pf), USceneComponent::__PPO__RelativeLocation() )));
	__Local__5 = FVector(0.000000, 0.000000, 17.000000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__PinIDValue__pf), false, 0));
	bpv__ConfidenceLabel__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__ConfidenceLabel__pf->AttachToComponent(bpv__InfoRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	bpv__ConfidenceLabel__pf->Text = FTextStringHelper::CreateFromBuffer(
TEXT("NSLOCTEXT(\"[A29B5640476C96BA9730579D0D9C51D6]\", \"9F5F735D42F3D45B75BCDD8B5F3D0658\", \"Confidence:\")")	);
	bpv__ConfidenceLabel__pf->HorizontalAlignment = EHorizTextAligment::EHTA_Right;
	bpv__ConfidenceLabel__pf->VerticalAlignment = EVerticalTextAligment::EVRTA_TextTop;
	bpv__ConfidenceLabel__pf->WorldSize = 6.000000f;
	auto& __Local__6 = (*(AccessPrivateProperty<FVector >((bpv__ConfidenceLabel__pf), USceneComponent::__PPO__RelativeLocation() )));
	__Local__6 = FVector(0.000000, 0.000000, -9.000000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__ConfidenceLabel__pf), false, 0));
	bpv__RotErrLabel__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__RotErrLabel__pf->AttachToComponent(bpv__InfoRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	bpv__RotErrLabel__pf->Text = FTextStringHelper::CreateFromBuffer(
TEXT("NSLOCTEXT(\"[A29B5640476C96BA9730579D0D9C51D6]\", \"548A48C34DE857825092DBA4B5E7C594\", \"Rot Err:\")")	);
	bpv__RotErrLabel__pf->HorizontalAlignment = EHorizTextAligment::EHTA_Right;
	bpv__RotErrLabel__pf->VerticalAlignment = EVerticalTextAligment::EVRTA_TextTop;
	bpv__RotErrLabel__pf->WorldSize = 6.000000f;
	auto& __Local__7 = (*(AccessPrivateProperty<FVector >((bpv__RotErrLabel__pf), USceneComponent::__PPO__RelativeLocation() )));
	__Local__7 = FVector(0.000000, 0.000000, -15.000000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__RotErrLabel__pf), false, 0));
	bpv__TransErrLabel__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__TransErrLabel__pf->AttachToComponent(bpv__InfoRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	bpv__TransErrLabel__pf->Text = FTextStringHelper::CreateFromBuffer(
TEXT("NSLOCTEXT(\"[A29B5640476C96BA9730579D0D9C51D6]\", \"0186CEAF4604FCE5FD1522B3E481B24E\", \"Trans Err:\")")	);
	bpv__TransErrLabel__pf->HorizontalAlignment = EHorizTextAligment::EHTA_Right;
	bpv__TransErrLabel__pf->VerticalAlignment = EVerticalTextAligment::EVRTA_TextTop;
	bpv__TransErrLabel__pf->WorldSize = 6.000000f;
	auto& __Local__8 = (*(AccessPrivateProperty<FVector >((bpv__TransErrLabel__pf), USceneComponent::__PPO__RelativeLocation() )));
	__Local__8 = FVector(0.000000, 0.000000, -21.000000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__TransErrLabel__pf), false, 0));
	bpv__ConfidenceValue__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__ConfidenceValue__pf->AttachToComponent(bpv__InfoRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	bpv__ConfidenceValue__pf->Text = FTextStringHelper::CreateFromBuffer(
TEXT("NSLOCTEXT(\"[A29B5640476C96BA9730579D0D9C51D6]\", \"8E5E84EA446D054ED1D67089AD2435F9\", \"0\")")	);
	bpv__ConfidenceValue__pf->VerticalAlignment = EVerticalTextAligment::EVRTA_TextTop;
	bpv__ConfidenceValue__pf->WorldSize = 6.000000f;
	auto& __Local__9 = (*(AccessPrivateProperty<FVector >((bpv__ConfidenceValue__pf), USceneComponent::__PPO__RelativeLocation() )));
	__Local__9 = FVector(0.000000, -2.000000, -9.000000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__ConfidenceValue__pf), false, 0));
	bpv__RotErrValue__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__RotErrValue__pf->AttachToComponent(bpv__InfoRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	bpv__RotErrValue__pf->Text = FTextStringHelper::CreateFromBuffer(
TEXT("NSLOCTEXT(\"[A29B5640476C96BA9730579D0D9C51D6]\", \"8E5E84EA446D054ED1D67089AD2435F9\", \"0\")")	);
	bpv__RotErrValue__pf->VerticalAlignment = EVerticalTextAligment::EVRTA_TextTop;
	bpv__RotErrValue__pf->WorldSize = 6.000000f;
	auto& __Local__10 = (*(AccessPrivateProperty<FVector >((bpv__RotErrValue__pf), USceneComponent::__PPO__RelativeLocation() )));
	__Local__10 = FVector(0.000000, -2.000000, -15.000000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__RotErrValue__pf), false, 0));
	bpv__TransErrValue__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__TransErrValue__pf->AttachToComponent(bpv__InfoRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	bpv__TransErrValue__pf->Text = FTextStringHelper::CreateFromBuffer(
TEXT("NSLOCTEXT(\"[A29B5640476C96BA9730579D0D9C51D6]\", \"8E5E84EA446D054ED1D67089AD2435F9\", \"0\")")	);
	bpv__TransErrValue__pf->VerticalAlignment = EVerticalTextAligment::EVRTA_TextTop;
	bpv__TransErrValue__pf->WorldSize = 6.000000f;
	auto& __Local__11 = (*(AccessPrivateProperty<FVector >((bpv__TransErrValue__pf), USceneComponent::__PPO__RelativeLocation() )));
	__Local__11 = FVector(0.000000, -2.000000, -21.000000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__TransErrValue__pf), false, 0));
	bpv__TypeValue__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__TypeValue__pf->AttachToComponent(bpv__InfoRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	bpv__TypeValue__pf->Text = FTextStringHelper::CreateFromBuffer(
TEXT("NSLOCTEXT(\"[A29B5640476C96BA9730579D0D9C51D6]\", \"7879EC2A4FE0C01908BE86B972BB39B8\", \"Unknown\")")	);
	bpv__TypeValue__pf->HorizontalAlignment = EHorizTextAligment::EHTA_Center;
	bpv__TypeValue__pf->VerticalAlignment = EVerticalTextAligment::EVRTA_TextTop;
	bpv__TypeValue__pf->WorldSize = 6.000000f;
	auto& __Local__12 = (*(AccessPrivateProperty<FVector >((bpv__TypeValue__pf), USceneComponent::__PPO__RelativeLocation() )));
	__Local__12 = FVector(0.000000, 0.000000, -3.000000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__TypeValue__pf), false, 0));
	bpv__VisualizerRoot__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__VisualizerRoot__pf->AttachToComponent(bpv__Root__pf, FAttachmentTransformRules::KeepRelativeTransform );
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__VisualizerRoot__pf), false, 0));
	bpv__AxisRoot__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__AxisRoot__pf->AttachToComponent(bpv__VisualizerRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	auto& __Local__13 = (*(AccessPrivateProperty<FVector >((bpv__AxisRoot__pf), USceneComponent::__PPO__RelativeScale3D() )));
	__Local__13 = FVector(0.200000, 0.200000, 0.200000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__AxisRoot__pf), false, 0));
	bpv__Up__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__Up__pf->AttachToComponent(bpv__AxisRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	auto& __Local__14 = (*(AccessPrivateProperty<UStaticMesh* >((bpv__Up__pf), UStaticMeshComponent::__PPO__StaticMesh() )));
	__Local__14 = CastChecked<UStaticMesh>(CastChecked<UDynamicClass>(AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass())->UsedAssets[0], ECastCheckedType::NullAllowed);
	bpv__Up__pf->OverrideMaterials = TArray<UMaterialInterface*> ();
	bpv__Up__pf->OverrideMaterials.Reserve(1);
	bpv__Up__pf->OverrideMaterials.Add(CastChecked<UMaterialInterface>(CastChecked<UDynamicClass>(AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass())->UsedAssets[1], ECastCheckedType::NullAllowed));
	static TWeakFieldPtr<FProperty> __Local__16{};
	const FProperty* __Local__15 = __Local__16.Get();
	if (nullptr == __Local__15)
	{
		__Local__15 = (UPrimitiveComponent::StaticClass())->FindPropertyByName(FName(TEXT("bGenerateOverlapEvents")));
		check(__Local__15);
		__Local__16 = __Local__15;
	}
	(((FBoolProperty*)__Local__15)->SetPropertyValue_InContainer((bpv__Up__pf), false, 0));
	bpv__Up__pf->CanCharacterStepUpOn = ECanBeCharacterBase::ECB_No;
	bpv__Up__pf->SetCollisionProfileName(FName(TEXT("NoCollision")));
	auto& __Local__17 = (*(AccessPrivateProperty<FVector >((bpv__Up__pf), USceneComponent::__PPO__RelativeLocation() )));
	__Local__17 = FVector(0.000000, 0.000000, 25.000000);
	auto& __Local__18 = (*(AccessPrivateProperty<FVector >((bpv__Up__pf), USceneComponent::__PPO__RelativeScale3D() )));
	__Local__18 = FVector(0.030000, 0.030000, 0.500000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__Up__pf), true, 0));
	bpv__Forward__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__Forward__pf->AttachToComponent(bpv__AxisRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	auto& __Local__19 = (*(AccessPrivateProperty<UStaticMesh* >((bpv__Forward__pf), UStaticMeshComponent::__PPO__StaticMesh() )));
	__Local__19 = CastChecked<UStaticMesh>(CastChecked<UDynamicClass>(AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass())->UsedAssets[0], ECastCheckedType::NullAllowed);
	bpv__Forward__pf->OverrideMaterials = TArray<UMaterialInterface*> ();
	bpv__Forward__pf->OverrideMaterials.Reserve(1);
	bpv__Forward__pf->OverrideMaterials.Add(CastChecked<UMaterialInterface>(CastChecked<UDynamicClass>(AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass())->UsedAssets[1], ECastCheckedType::NullAllowed));
	(((FBoolProperty*)__Local__15)->SetPropertyValue_InContainer((bpv__Forward__pf), false, 0));
	bpv__Forward__pf->CanCharacterStepUpOn = ECanBeCharacterBase::ECB_No;
	bpv__Forward__pf->SetCollisionProfileName(FName(TEXT("NoCollision")));
	auto& __Local__20 = (*(AccessPrivateProperty<FVector >((bpv__Forward__pf), USceneComponent::__PPO__RelativeLocation() )));
	__Local__20 = FVector(25.000000, 0.000000, 0.000000);
	auto& __Local__21 = (*(AccessPrivateProperty<FRotator >((bpv__Forward__pf), USceneComponent::__PPO__RelativeRotation() )));
	__Local__21 = FRotator(90.000000, 0.000000, 0.000000);
	auto& __Local__22 = (*(AccessPrivateProperty<FVector >((bpv__Forward__pf), USceneComponent::__PPO__RelativeScale3D() )));
	__Local__22 = FVector(0.030000, 0.030000, 0.500000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__Forward__pf), true, 0));
	bpv__Right__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__Right__pf->AttachToComponent(bpv__AxisRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	auto& __Local__23 = (*(AccessPrivateProperty<UStaticMesh* >((bpv__Right__pf), UStaticMeshComponent::__PPO__StaticMesh() )));
	__Local__23 = CastChecked<UStaticMesh>(CastChecked<UDynamicClass>(AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass())->UsedAssets[0], ECastCheckedType::NullAllowed);
	bpv__Right__pf->OverrideMaterials = TArray<UMaterialInterface*> ();
	bpv__Right__pf->OverrideMaterials.Reserve(1);
	bpv__Right__pf->OverrideMaterials.Add(CastChecked<UMaterialInterface>(CastChecked<UDynamicClass>(AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass())->UsedAssets[1], ECastCheckedType::NullAllowed));
	(((FBoolProperty*)__Local__15)->SetPropertyValue_InContainer((bpv__Right__pf), false, 0));
	bpv__Right__pf->CanCharacterStepUpOn = ECanBeCharacterBase::ECB_No;
	bpv__Right__pf->SetCollisionProfileName(FName(TEXT("NoCollision")));
	auto& __Local__24 = (*(AccessPrivateProperty<FVector >((bpv__Right__pf), USceneComponent::__PPO__RelativeLocation() )));
	__Local__24 = FVector(0.000000, 25.000000, 0.000000);
	auto& __Local__25 = (*(AccessPrivateProperty<FRotator >((bpv__Right__pf), USceneComponent::__PPO__RelativeRotation() )));
	__Local__25 = FRotator(0.000000, 0.000000, 89.999962);
	auto& __Local__26 = (*(AccessPrivateProperty<FVector >((bpv__Right__pf), USceneComponent::__PPO__RelativeScale3D() )));
	__Local__26 = FVector(0.030000, 0.030000, 0.500000);
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__Right__pf), true, 0));
	bpv__ValidRadiusVisualizer__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__ValidRadiusVisualizer__pf->AttachToComponent(bpv__VisualizerRoot__pf, FAttachmentTransformRules::KeepRelativeTransform );
	bpv__ValidRadiusVisualizer__pf->AreaClass = UNavArea_Obstacle::StaticClass();
	(((FBoolProperty*)__Local__15)->SetPropertyValue_InContainer((bpv__ValidRadiusVisualizer__pf), false, 0));
	bpv__ValidRadiusVisualizer__pf->CanCharacterStepUpOn = ECanBeCharacterBase::ECB_No;
	bpv__ValidRadiusVisualizer__pf->SetCollisionProfileName(FName(TEXT("NoCollision")));
	bpv__ValidRadiusVisualizer__pf->bHiddenInGame = false;
	(((FBoolProperty*)__Local__3)->SetPropertyValue_InContainer((bpv__ValidRadiusVisualizer__pf), false, 0));
	bpv__RotationSmoothSpeed__pf = 2.000000f;
	auto& __Local__27 = (*(AccessPrivateProperty<EActorUpdateOverlapsMethod >((this), AActor::__PPO__DefaultUpdateOverlapsMethodDuringLevelStreaming() )));
	__Local__27 = EActorUpdateOverlapsMethod::OnlyUpdateMovable;
}
PRAGMA_ENABLE_OPTIMIZATION
void AMagicLeapARPinInfoActor_C__pf2635949152::PostLoadSubobjects(FObjectInstancingGraph* OuterInstanceGraph)
{
	Super::PostLoadSubobjects(OuterInstanceGraph);
	if(bpv__Root__pf)
	{
		bpv__Root__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__InfoRoot__pf)
	{
		bpv__InfoRoot__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__PinIDValue__pf)
	{
		bpv__PinIDValue__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__ConfidenceLabel__pf)
	{
		bpv__ConfidenceLabel__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__RotErrLabel__pf)
	{
		bpv__RotErrLabel__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__TransErrLabel__pf)
	{
		bpv__TransErrLabel__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__ConfidenceValue__pf)
	{
		bpv__ConfidenceValue__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__RotErrValue__pf)
	{
		bpv__RotErrValue__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__TransErrValue__pf)
	{
		bpv__TransErrValue__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__TypeValue__pf)
	{
		bpv__TypeValue__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__VisualizerRoot__pf)
	{
		bpv__VisualizerRoot__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__AxisRoot__pf)
	{
		bpv__AxisRoot__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__Up__pf)
	{
		bpv__Up__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__Forward__pf)
	{
		bpv__Forward__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__Right__pf)
	{
		bpv__Right__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__ValidRadiusVisualizer__pf)
	{
		bpv__ValidRadiusVisualizer__pf->CreationMethod = EComponentCreationMethod::Native;
	}
}
PRAGMA_DISABLE_OPTIMIZATION
void AMagicLeapARPinInfoActor_C__pf2635949152::__CustomDynamicClassInitialization(UDynamicClass* InDynamicClass)
{
	ensure(0 == InDynamicClass->ReferencedConvertedFields.Num());
	ensure(0 == InDynamicClass->MiscConvertedSubobjects.Num());
	ensure(0 == InDynamicClass->DynamicBindingObjects.Num());
	ensure(0 == InDynamicClass->ComponentTemplates.Num());
	ensure(0 == InDynamicClass->Timelines.Num());
	ensure(0 == InDynamicClass->ComponentClassOverrides.Num());
	ensure(nullptr == InDynamicClass->AnimClassImplementation);
	InDynamicClass->AssembleReferenceTokenStream();
	FConvertedBlueprintsDependencies::FillUsedAssetsInDynamicClass(InDynamicClass, &__StaticDependencies_DirectlyUsedAssets);
	auto __Local__28 = NewObject<USceneComponent>(InDynamicClass, USceneComponent::StaticClass(), TEXT("DefaultSceneRoot_GEN_VARIABLE"), (EObjectFlags)0x00280029);
	InDynamicClass->ComponentTemplates.Add(__Local__28);
	static TWeakFieldPtr<FProperty> __Local__30{};
	const FProperty* __Local__29 = __Local__30.Get();
	if (nullptr == __Local__29)
	{
		__Local__29 = (UActorComponent::StaticClass())->FindPropertyByName(FName(TEXT("bCanEverAffectNavigation")));
		check(__Local__29);
		__Local__30 = __Local__29;
	}
	(((FBoolProperty*)__Local__29)->SetPropertyValue_InContainer((__Local__28), false, 0));
}
PRAGMA_ENABLE_OPTIMIZATION
void AMagicLeapARPinInfoActor_C__pf2635949152::bpf__ExecuteUbergraph_MagicLeapARPinInfoActor__pf_0(int32 bpp__EntryPoint__pf)
{
	FString bpfv__CallFunc_ARPinIdToString_ReturnValue__pf{};
	FText bpfv__CallFunc_Conv_StringToText_ReturnValue__pf{};
	EMagicLeapPassableWorldError bpfv__CallFunc_GetARPinState_ReturnValue__pf{};
	bool bpfv__CallFunc_EqualEqual_ByteByte_ReturnValue__pf{};
	FString bpfv__CallFunc_GetEnumeratorUserFriendlyName_ReturnValue__pf{};
	FText bpfv__CallFunc_Conv_FloatToText_ReturnValue__pf{};
	FText bpfv__CallFunc_Conv_StringToText_ReturnValue_1__pf{};
	FText bpfv__CallFunc_Conv_FloatToText_ReturnValue_1__pf{};
	FText bpfv__CallFunc_Conv_FloatToText_ReturnValue_2__pf{};
	check(bpp__EntryPoint__pf == 10);
	// optimized KCST_UnconditionalGoto
	bpfv__CallFunc_GetARPinState_ReturnValue__pf = UMagicLeapARPinFunctionLibrary::GetARPinState(PinID, /*out*/ b0l__CallFunc_GetARPinState_State__pf);
	bpfv__CallFunc_EqualEqual_ByteByte_ReturnValue__pf = UKismetMathLibrary::EqualEqual_ByteByte(static_cast<uint8>(bpfv__CallFunc_GetARPinState_ReturnValue__pf), static_cast<uint8>(EMagicLeapPassableWorldError::None));
	if (!bpfv__CallFunc_EqualEqual_ByteByte_ReturnValue__pf)
	{
		return; //KCST_GotoReturnIfNot
	}
	bpfv__CallFunc_Conv_FloatToText_ReturnValue_2__pf = UKismetTextLibrary::Conv_FloatToText(b0l__CallFunc_GetARPinState_State__pf.Confidence, ERoundingMode::HalfToEven, false, true, 1, 324, 0, 3);
	if(::IsValid(bpv__ConfidenceValue__pf))
	{
		bpv__ConfidenceValue__pf->UTextRenderComponent::K2_SetText(bpfv__CallFunc_Conv_FloatToText_ReturnValue_2__pf);
	}
	bpfv__CallFunc_Conv_FloatToText_ReturnValue_1__pf = UKismetTextLibrary::Conv_FloatToText(b0l__CallFunc_GetARPinState_State__pf.RotationError, ERoundingMode::HalfToEven, false, true, 1, 324, 0, 3);
	if(::IsValid(bpv__RotErrValue__pf))
	{
		bpv__RotErrValue__pf->UTextRenderComponent::K2_SetText(bpfv__CallFunc_Conv_FloatToText_ReturnValue_1__pf);
	}
	bpfv__CallFunc_Conv_FloatToText_ReturnValue__pf = UKismetTextLibrary::Conv_FloatToText(b0l__CallFunc_GetARPinState_State__pf.TranslationError, ERoundingMode::HalfToEven, false, true, 1, 324, 0, 3);
	if(::IsValid(bpv__TransErrValue__pf))
	{
		bpv__TransErrValue__pf->UTextRenderComponent::K2_SetText(bpfv__CallFunc_Conv_FloatToText_ReturnValue__pf);
	}
	if(::IsValid(bpv__ValidRadiusVisualizer__pf))
	{
		bpv__ValidRadiusVisualizer__pf->USphereComponent::SetSphereRadius(b0l__CallFunc_GetARPinState_State__pf.ValidRadius, false);
	}
	bpfv__CallFunc_GetEnumeratorUserFriendlyName_ReturnValue__pf = UKismetNodeHelperLibrary::GetEnumeratorUserFriendlyName(CastChecked<UEnum>(CastChecked<UDynamicClass>(AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass())->UsedAssets[2], ECastCheckedType::NullAllowed), static_cast<uint8>(b0l__CallFunc_GetARPinState_State__pf.PinType));
	bpfv__CallFunc_Conv_StringToText_ReturnValue_1__pf = UKismetTextLibrary::Conv_StringToText(bpfv__CallFunc_GetEnumeratorUserFriendlyName_ReturnValue__pf);
	if(::IsValid(bpv__TypeValue__pf))
	{
		bpv__TypeValue__pf->UTextRenderComponent::K2_SetText(bpfv__CallFunc_Conv_StringToText_ReturnValue_1__pf);
	}
	bpfv__CallFunc_ARPinIdToString_ReturnValue__pf = UMagicLeapARPinFunctionLibrary::ARPinIdToString(PinID);
	bpfv__CallFunc_Conv_StringToText_ReturnValue__pf = UKismetTextLibrary::Conv_StringToText(bpfv__CallFunc_ARPinIdToString_ReturnValue__pf);
	if(::IsValid(bpv__PinIDValue__pf))
	{
		bpv__PinIDValue__pf->UTextRenderComponent::K2_SetText(bpfv__CallFunc_Conv_StringToText_ReturnValue__pf);
	}
	return; // KCST_GotoReturn
}
void AMagicLeapARPinInfoActor_C__pf2635949152::bpf__ExecuteUbergraph_MagicLeapARPinInfoActor__pf_1(int32 bpp__EntryPoint__pf)
{
	APlayerCameraManager* bpfv__CallFunc_GetPlayerCameraManager_ReturnValue__pf{};
	FVector bpfv__CallFunc_GetCameraLocation_ReturnValue__pf(EForceInit::ForceInit);
	FRotator bpfv__CallFunc_K2_GetComponentRotation_ReturnValue__pf(EForceInit::ForceInit);
	FVector bpfv__CallFunc_K2_GetComponentLocation_ReturnValue__pf(EForceInit::ForceInit);
	FRotator bpfv__CallFunc_FindLookAtRotation_ReturnValue__pf(EForceInit::ForceInit);
	bool bpfv__CallFunc_GetARPinPositionAndOrientation_ReturnValue__pf{};
	FRotator bpfv__CallFunc_RInterpTo_ReturnValue__pf(EForceInit::ForceInit);
	FRotator bpfv__CallFunc_MakeRotator_ReturnValue__pf(EForceInit::ForceInit);
	int32 __CurrentState = bpp__EntryPoint__pf;
	do
	{
		switch( __CurrentState )
		{
		case 1:
			{
				SetActorHiddenInGame(false);
			}
		case 2:
			{
				if(::IsValid(bpv__VisualizerRoot__pf))
				{
					bpv__VisualizerRoot__pf->USceneComponent::K2_SetWorldLocationAndRotation(b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf, b0l__CallFunc_GetARPinPositionAndOrientation_Orientation__pf, false, /*out*/ b0l__CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult__pf, false);
				}
			}
		case 3:
			{
				if(::IsValid(bpv__InfoRoot__pf))
				{
					bpv__InfoRoot__pf->USceneComponent::K2_SetWorldLocation(b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf, false, /*out*/ b0l__CallFunc_K2_SetWorldLocation_SweepHitResult__pf, false);
				}
			}
		case 4:
			{
				bpfv__CallFunc_GetPlayerCameraManager_ReturnValue__pf = UGameplayStatics::GetPlayerCameraManager(this, 0);
				if(::IsValid(bpfv__CallFunc_GetPlayerCameraManager_ReturnValue__pf))
				{
					bpfv__CallFunc_GetCameraLocation_ReturnValue__pf = bpfv__CallFunc_GetPlayerCameraManager_ReturnValue__pf->GetCameraLocation();
				}
				if(::IsValid(bpv__InfoRoot__pf))
				{
					bpfv__CallFunc_K2_GetComponentRotation_ReturnValue__pf = bpv__InfoRoot__pf->USceneComponent::K2_GetComponentRotation();
				}
				if(::IsValid(bpv__InfoRoot__pf))
				{
					bpfv__CallFunc_K2_GetComponentLocation_ReturnValue__pf = bpv__InfoRoot__pf->USceneComponent::K2_GetComponentLocation();
				}
				bpfv__CallFunc_FindLookAtRotation_ReturnValue__pf = UKismetMathLibrary::FindLookAtRotation(bpfv__CallFunc_K2_GetComponentLocation_ReturnValue__pf, bpfv__CallFunc_GetCameraLocation_ReturnValue__pf);
				bpfv__CallFunc_RInterpTo_ReturnValue__pf = UKismetMathLibrary::RInterpTo(bpfv__CallFunc_K2_GetComponentRotation_ReturnValue__pf, bpfv__CallFunc_FindLookAtRotation_ReturnValue__pf, b0l__K2Node_Event_DeltaSeconds__pf, bpv__RotationSmoothSpeed__pf);
				UKismetMathLibrary::BreakRotator(bpfv__CallFunc_RInterpTo_ReturnValue__pf, /*out*/ b0l__CallFunc_BreakRotator_Roll__pf, /*out*/ b0l__CallFunc_BreakRotator_Pitch__pf, /*out*/ b0l__CallFunc_BreakRotator_Yaw__pf);
				bpfv__CallFunc_MakeRotator_ReturnValue__pf = UKismetMathLibrary::MakeRotator(0.000000, b0l__CallFunc_BreakRotator_Pitch__pf, b0l__CallFunc_BreakRotator_Yaw__pf);
				if(::IsValid(bpv__InfoRoot__pf))
				{
					bpv__InfoRoot__pf->USceneComponent::K2_SetWorldRotation(bpfv__CallFunc_MakeRotator_ReturnValue__pf, false, /*out*/ b0l__CallFunc_K2_SetWorldRotation_SweepHitResult__pf, false);
				}
				__CurrentState = -1;
				break;
			}
		case 5:
			{
				if (!bVisibilityOverride)
				{
					__CurrentState = 8;
					break;
				}
			}
		case 6:
			{
				bpfv__CallFunc_GetARPinPositionAndOrientation_ReturnValue__pf = UMagicLeapARPinFunctionLibrary::GetARPinPositionAndOrientation(PinID, /*out*/ b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf, /*out*/ b0l__CallFunc_GetARPinPositionAndOrientation_Orientation__pf, /*out*/ b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf);
			}
		case 7:
			{
				if (!bpfv__CallFunc_GetARPinPositionAndOrientation_ReturnValue__pf)
				{
					__CurrentState = 9;
					break;
				}
				__CurrentState = 1;
				break;
			}
		case 8:
			{
				SetActorHiddenInGame(true);
				__CurrentState = -1;
				break;
			}
		case 9:
			{
				SetActorHiddenInGame(true);
				__CurrentState = -1;
				break;
			}
		case 19:
			{
				__CurrentState = 5;
				break;
			}
		default:
			break;
		}
	} while( __CurrentState != -1 );
}
void AMagicLeapARPinInfoActor_C__pf2635949152::bpf__ReceiveTick__pf(float bpp__DeltaSeconds__pf)
{
	b0l__K2Node_Event_DeltaSeconds__pf = bpp__DeltaSeconds__pf;
	bpf__ExecuteUbergraph_MagicLeapARPinInfoActor__pf_1(19);
}
void AMagicLeapARPinInfoActor_C__pf2635949152::bpf__OnUpdateARPinState__pf()
{
	bpf__ExecuteUbergraph_MagicLeapARPinInfoActor__pf_0(10);
}
void AMagicLeapARPinInfoActor_C__pf2635949152::bpf__UserConstructionScript__pf()
{
	UMaterialInstanceDynamic* bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue__pf{};
	UMaterialInstanceDynamic* bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue_1__pf{};
	UMaterialInstanceDynamic* bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue_2__pf{};
	if(::IsValid(bpv__Forward__pf))
	{
		bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue_2__pf = bpv__Forward__pf->CreateDynamicMaterialInstance(0, CastChecked<UMaterialInterface>(CastChecked<UDynamicClass>(AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass())->UsedAssets[1], ECastCheckedType::NullAllowed), FName(TEXT("None")));
	}
	if(::IsValid(bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue_2__pf))
	{
		bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue_2__pf->UMaterialInstanceDynamic::SetVectorParameterValue(FName(TEXT("Color")), FLinearColor(1.000000,0.000000,0.000000,1.000000));
	}
	if(::IsValid(bpv__Right__pf))
	{
		bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue_1__pf = bpv__Right__pf->CreateDynamicMaterialInstance(0, CastChecked<UMaterialInterface>(CastChecked<UDynamicClass>(AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass())->UsedAssets[1], ECastCheckedType::NullAllowed), FName(TEXT("None")));
	}
	if(::IsValid(bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue_1__pf))
	{
		bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue_1__pf->UMaterialInstanceDynamic::SetVectorParameterValue(FName(TEXT("Color")), FLinearColor(0.000000,1.000000,0.000000,1.000000));
	}
	if(::IsValid(bpv__Up__pf))
	{
		bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue__pf = bpv__Up__pf->CreateDynamicMaterialInstance(0, CastChecked<UMaterialInterface>(CastChecked<UDynamicClass>(AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass())->UsedAssets[1], ECastCheckedType::NullAllowed), FName(TEXT("None")));
	}
	if(::IsValid(bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue__pf))
	{
		bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue__pf->UMaterialInstanceDynamic::SetVectorParameterValue(FName(TEXT("Color")), FLinearColor(0.000000,0.000000,1.000000,1.000000));
	}
}
void AMagicLeapARPinInfoActor_C__pf2635949152::bpf__UpdatePinState__pf()
{
}
PRAGMA_DISABLE_OPTIMIZATION
void AMagicLeapARPinInfoActor_C__pf2635949152::__StaticDependencies_DirectlyUsedAssets(TArray<FBlueprintDependencyData>& AssetsToLoad)
{
	const FCompactBlueprintDependencyData LocCompactBlueprintDependencyData[] =
	{
		{0, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  StaticMesh /Engine/BasicShapes/Cylinder.Cylinder 
		{1, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Material /Engine/ArtTools/RenderToTexture/Materials/Debug/M_Emissive_Color.M_Emissive_Color 
		{2, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Enum /Script/MagicLeapARPin.EMagicLeapARPinType 
	};
	for(const FCompactBlueprintDependencyData& CompactData : LocCompactBlueprintDependencyData)
	{
		AssetsToLoad.Add(FBlueprintDependencyData(F__NativeDependencies::Get(CompactData.ObjectRefIndex), CompactData));
	}
}
PRAGMA_ENABLE_OPTIMIZATION
PRAGMA_DISABLE_OPTIMIZATION
void AMagicLeapARPinInfoActor_C__pf2635949152::__StaticDependenciesAssets(TArray<FBlueprintDependencyData>& AssetsToLoad)
{
	__StaticDependencies_DirectlyUsedAssets(AssetsToLoad);
	const FCompactBlueprintDependencyData LocCompactBlueprintDependencyData[] =
	{
		{3, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.SceneComponent 
		{4, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.TextRenderComponent 
		{5, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Material /Engine/EngineMaterials/DefaultTextMaterialOpaque.DefaultTextMaterialOpaque 
		{6, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Font /Engine/EngineFonts/RobotoDistanceField.RobotoDistanceField 
		{7, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.StaticMeshComponent 
		{8, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.SphereComponent 
		{9, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/NavigationSystem.NavArea_Obstacle 
		{10, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.PlayerCameraManager 
		{11, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  ScriptStruct /Script/Engine.HitResult 
		{12, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  ScriptStruct /Script/MagicLeapARPin.MagicLeapARPinState 
		{13, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Enum /Script/MagicLeapARPin.EMagicLeapPassableWorldError 
		{14, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.GameplayStatics 
		{15, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.KismetMathLibrary 
		{16, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/MagicLeapARPin.MagicLeapARPinInfoActorBase 
		{17, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/MagicLeapARPin.MagicLeapARPinFunctionLibrary 
		{18, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.KismetTextLibrary 
		{19, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.KismetNodeHelperLibrary 
		{20, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.Actor 
		{21, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.MaterialInstanceDynamic 
		{22, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  ScriptStruct /Script/Engine.PointerToUberGraphFrame 
	};
	for(const FCompactBlueprintDependencyData& CompactData : LocCompactBlueprintDependencyData)
	{
		AssetsToLoad.Add(FBlueprintDependencyData(F__NativeDependencies::Get(CompactData.ObjectRefIndex), CompactData));
	}
}
PRAGMA_ENABLE_OPTIMIZATION
struct FRegisterHelper__AMagicLeapARPinInfoActor_C__pf2635949152
{
	FRegisterHelper__AMagicLeapARPinInfoActor_C__pf2635949152()
	{
		FConvertedBlueprintsDependencies::Get().RegisterConvertedClass(TEXT("/MagicLeapPassableWorld/MagicLeapARPinInfoActor"), &AMagicLeapARPinInfoActor_C__pf2635949152::__StaticDependenciesAssets);
	}
	static FRegisterHelper__AMagicLeapARPinInfoActor_C__pf2635949152 Instance;
};
FRegisterHelper__AMagicLeapARPinInfoActor_C__pf2635949152 FRegisterHelper__AMagicLeapARPinInfoActor_C__pf2635949152::Instance;
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
