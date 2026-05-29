#include "NativizedAssets.h"
#include "BP_LightStudio__pf1079297466.h"
#include "GeneratedCodeHelpers.h"
#include "Runtime/Engine/Classes/Components/DirectionalLightComponent.h"
#include "Runtime/Engine/Classes/Atmosphere/AtmosphericFogComponent.h"
#include "Runtime/Engine/Classes/Engine/SimpleConstructionScript.h"
#include "Runtime/Engine/Classes/Engine/SCS_Node.h"
#include "Runtime/Engine/Classes/Components/SceneComponent.h"
#include "Runtime/Engine/Classes/Components/ActorComponent.h"
#include "Runtime/Engine/Classes/Engine/EngineBaseTypes.h"
#include "Runtime/Engine/Classes/Engine/EngineTypes.h"
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
#include "Runtime/Engine/Classes/Components/ExponentialHeightFogComponent.h"
#include "Runtime/Engine/Classes/Components/SkyLightComponent.h"
#include "Runtime/Engine/Classes/Components/LightComponentBase.h"
#include "Runtime/Engine/Classes/Kismet/KismetMathLibrary.h"
#include "Runtime/Engine/Classes/Kismet/BlueprintFunctionLibrary.h"
#include "Runtime/Engine/Classes/Components/LightComponent.h"
#include "Runtime/Engine/Classes/Engine/TextureLightProfile.h"
#include "Runtime/Engine/Classes/Kismet/KismetMaterialLibrary.h"
#include "Runtime/Engine/Classes/Materials/MaterialInstanceConstant.h"


#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
PRAGMA_DISABLE_OPTIMIZATION
ABP_LightStudio_C__pf1079297466::ABP_LightStudio_C__pf1079297466(const FObjectInitializer& ObjectInitializer) : Super(ObjectInitializer)
{
	
	bpv__Scene1__pf = CreateDefaultSubobject<USceneComponent>(TEXT("Scene1"));
	bpv__Skybox__pf = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("Skybox"));
	bpv__PrevisArrow__pf = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("PrevisArrow"));
	bpv__ExponentialHeightFog1__pf = CreateDefaultSubobject<UExponentialHeightFogComponent>(TEXT("ExponentialHeightFog1"));
	bpv__SkyLight1__pf = CreateDefaultSubobject<USkyLightComponent>(TEXT("SkyLight1"));
	RootComponent = bpv__Scene1__pf;
	bpv__Scene1__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__Scene1__pf->Mobility = EComponentMobility::Type::Static;
	static TWeakFieldPtr<FProperty> __Local__1{};
	const FProperty* __Local__0 = __Local__1.Get();
	if (nullptr == __Local__0)
	{
		__Local__0 = (UActorComponent::StaticClass())->FindPropertyByName(FName(TEXT("bCanEverAffectNavigation")));
		check(__Local__0);
		__Local__1 = __Local__0;
	}
	(((FBoolProperty*)__Local__0)->SetPropertyValue_InContainer((bpv__Scene1__pf), false, 0));
	bpv__Skybox__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__Skybox__pf->AttachToComponent(bpv__Scene1__pf, FAttachmentTransformRules::KeepRelativeTransform );
	auto& __Local__2 = (*(AccessPrivateProperty<UStaticMesh* >((bpv__Skybox__pf), UStaticMeshComponent::__PPO__StaticMesh() )));
	__Local__2 = CastChecked<UStaticMesh>(CastChecked<UDynamicClass>(ABP_LightStudio_C__pf1079297466::StaticClass())->UsedAssets[0], ECastCheckedType::NullAllowed);
	bpv__Skybox__pf->OverrideMaterials = TArray<UMaterialInterface*> ();
	bpv__Skybox__pf->OverrideMaterials.Reserve(1);
	bpv__Skybox__pf->OverrideMaterials.Add(CastChecked<UMaterialInterface>(CastChecked<UDynamicClass>(ABP_LightStudio_C__pf1079297466::StaticClass())->UsedAssets[1], ECastCheckedType::NullAllowed));
	bpv__Skybox__pf->CastShadow = false;
	bpv__Skybox__pf->bCastDynamicShadow = false;
	bpv__Skybox__pf->bCastStaticShadow = false;
	auto& __Local__3 = (*(AccessPrivateProperty<TEnumAsByte<ECollisionEnabled::Type> >(&(bpv__Skybox__pf->BodyInstance), FBodyInstance::__PPO__CollisionEnabled() )));
	__Local__3 = ECollisionEnabled::Type::NoCollision;
	auto& __Local__4 = (*(AccessPrivateProperty<FCollisionResponse >(&(bpv__Skybox__pf->BodyInstance), FBodyInstance::__PPO__CollisionResponses() )));
	auto& __Local__5 = (*(AccessPrivateProperty<TArray<FResponseChannel> >(&(__Local__4), FCollisionResponse::__PPO__ResponseArray() )));
	__Local__5 = TArray<FResponseChannel> ();
	__Local__5.AddUninitialized(8);
	FResponseChannel::StaticStruct()->InitializeStruct(__Local__5.GetData(), 8);
	auto& __Local__6 = __Local__5[0];
	__Local__6.Channel = FName(TEXT("WorldStatic"));
	__Local__6.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__7 = __Local__5[1];
	__Local__7.Channel = FName(TEXT("WorldDynamic"));
	__Local__7.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__8 = __Local__5[2];
	__Local__8.Channel = FName(TEXT("Pawn"));
	__Local__8.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__9 = __Local__5[3];
	__Local__9.Channel = FName(TEXT("Visibility"));
	__Local__9.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__10 = __Local__5[4];
	__Local__10.Channel = FName(TEXT("Camera"));
	__Local__10.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__11 = __Local__5[5];
	__Local__11.Channel = FName(TEXT("PhysicsBody"));
	__Local__11.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__12 = __Local__5[6];
	__Local__12.Channel = FName(TEXT("Vehicle"));
	__Local__12.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__13 = __Local__5[7];
	__Local__13.Channel = FName(TEXT("Destructible"));
	__Local__13.Response = ECollisionResponse::ECR_Ignore;
	bpv__Skybox__pf->BodyInstance.bAutoWeld = false;
	bpv__Skybox__pf->SetCollisionProfileName(FName(TEXT("Custom")));
	auto& __Local__14 = (*(AccessPrivateProperty<FVector >((bpv__Skybox__pf), USceneComponent::__PPO__RelativeScale3D() )));
	__Local__14 = FVector(50000.000000, 50000.000000, 50000.000000);
	bpv__Skybox__pf->Mobility = EComponentMobility::Type::Static;
	(((FBoolProperty*)__Local__0)->SetPropertyValue_InContainer((bpv__Skybox__pf), true, 0));
	bpv__PrevisArrow__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__PrevisArrow__pf->AttachToComponent(bpv__Scene1__pf, FAttachmentTransformRules::KeepRelativeTransform );
	auto& __Local__15 = (*(AccessPrivateProperty<UStaticMesh* >((bpv__PrevisArrow__pf), UStaticMeshComponent::__PPO__StaticMesh() )));
	__Local__15 = CastChecked<UStaticMesh>(CastChecked<UDynamicClass>(ABP_LightStudio_C__pf1079297466::StaticClass())->UsedAssets[2], ECastCheckedType::NullAllowed);
	bpv__PrevisArrow__pf->OverrideMaterials = TArray<UMaterialInterface*> ();
	bpv__PrevisArrow__pf->OverrideMaterials.Reserve(1);
	bpv__PrevisArrow__pf->OverrideMaterials.Add(CastChecked<UMaterialInterface>(CastChecked<UDynamicClass>(ABP_LightStudio_C__pf1079297466::StaticClass())->UsedAssets[3], ECastCheckedType::NullAllowed));
	bpv__PrevisArrow__pf->CastShadow = false;
	bpv__PrevisArrow__pf->bCastDynamicShadow = false;
	bpv__PrevisArrow__pf->bCastStaticShadow = false;
	auto& __Local__16 = (*(AccessPrivateProperty<TEnumAsByte<ECollisionEnabled::Type> >(&(bpv__PrevisArrow__pf->BodyInstance), FBodyInstance::__PPO__CollisionEnabled() )));
	__Local__16 = ECollisionEnabled::Type::NoCollision;
	auto& __Local__17 = (*(AccessPrivateProperty<FCollisionResponse >(&(bpv__PrevisArrow__pf->BodyInstance), FBodyInstance::__PPO__CollisionResponses() )));
	auto& __Local__18 = (*(AccessPrivateProperty<TArray<FResponseChannel> >(&(__Local__17), FCollisionResponse::__PPO__ResponseArray() )));
	__Local__18 = TArray<FResponseChannel> ();
	__Local__18.AddUninitialized(8);
	FResponseChannel::StaticStruct()->InitializeStruct(__Local__18.GetData(), 8);
	auto& __Local__19 = __Local__18[0];
	__Local__19.Channel = FName(TEXT("WorldStatic"));
	__Local__19.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__20 = __Local__18[1];
	__Local__20.Channel = FName(TEXT("WorldDynamic"));
	__Local__20.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__21 = __Local__18[2];
	__Local__21.Channel = FName(TEXT("Pawn"));
	__Local__21.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__22 = __Local__18[3];
	__Local__22.Channel = FName(TEXT("Visibility"));
	__Local__22.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__23 = __Local__18[4];
	__Local__23.Channel = FName(TEXT("Camera"));
	__Local__23.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__24 = __Local__18[5];
	__Local__24.Channel = FName(TEXT("PhysicsBody"));
	__Local__24.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__25 = __Local__18[6];
	__Local__25.Channel = FName(TEXT("Vehicle"));
	__Local__25.Response = ECollisionResponse::ECR_Ignore;
	auto& __Local__26 = __Local__18[7];
	__Local__26.Channel = FName(TEXT("Destructible"));
	__Local__26.Response = ECollisionResponse::ECR_Ignore;
	bpv__PrevisArrow__pf->BodyInstance.bAutoWeld = false;
	bpv__PrevisArrow__pf->SetCollisionProfileName(FName(TEXT("Custom")));
	auto& __Local__27 = (*(AccessPrivateProperty<FVector >((bpv__PrevisArrow__pf), USceneComponent::__PPO__RelativeScale3D() )));
	__Local__27 = FVector(0.500000, 0.500000, 0.500000);
	bpv__PrevisArrow__pf->bHiddenInGame = true;
	(((FBoolProperty*)__Local__0)->SetPropertyValue_InContainer((bpv__PrevisArrow__pf), true, 0));
	bpv__ExponentialHeightFog1__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__ExponentialHeightFog1__pf->AttachToComponent(bpv__Scene1__pf, FAttachmentTransformRules::KeepRelativeTransform );
	bpv__ExponentialHeightFog1__pf->DirectionalInscatteringColor = FLinearColor(1.000000, 0.000000, 0.633525, 1.000000);
	(((FBoolProperty*)__Local__0)->SetPropertyValue_InContainer((bpv__ExponentialHeightFog1__pf), false, 0));
	bpv__SkyLight1__pf->CreationMethod = EComponentCreationMethod::Native;
	bpv__SkyLight1__pf->AttachToComponent(bpv__Scene1__pf, FAttachmentTransformRules::KeepRelativeTransform );
	bpv__SkyLight1__pf->bLowerHemisphereIsBlack = false;
	(((FBoolProperty*)__Local__0)->SetPropertyValue_InContainer((bpv__SkyLight1__pf), false, 0));
	bpv__GlobalBrightness__pf = 1.000000f;
	bpv__Use_HDRI__pf = false;
	bpv__UseSunLight__pf = true;
	bpv__SunBrightness__pf = 1.000000f;
	bpv__SunTint__pf = FLinearColor(1.000000, 1.000000, 1.000000, 1.000000);
	bpv__StationaryLightForSun__pf = false;
	bpv__SunDirectionalLight__pf = nullptr;
	bpv__UseAtmosphere__pf = true;
	bpv__AtmosphereBrightness__pf = 1.000000f;
	bpv__AtmosphereTint__pf = FLinearColor(1.000000, 1.000000, 1.000000, 1.000000);
	bpv__PrevisArrowMaterial__pf = nullptr;
	bpv__LightColor__pf = FLinearColor(0.000000, 0.000000, 0.000000, 0.000000);
	bpv__SunColorCurve__pf = CastChecked<UCurveLinearColor>(CastChecked<UDynamicClass>(ABP_LightStudio_C__pf1079297466::StaticClass())->UsedAssets[4], ECastCheckedType::NullAllowed);
	bpv__OverrideSunColor__pf = false;
	bpv__AtmosphereDensityMultiplier__pf = 1.000000f;
	bpv__AtmosphereAltitude__pf = 100000.000000f;
	bpv__DisableSunDisk__pf = false;
	bpv__UseFog__pf = false;
	bpv__FogBrightness__pf = 1.000000f;
	bpv__FogTint__pf = FLinearColor(0.500000, 0.500000, 0.500000, 1.000000);
	bpv__FogAltitude__pf = 0.000000f;
	bpv__FogMaxOpacity__pf = 1.000000f;
	bpv__FogHeightFalloff__pf = 0.200000f;
	bpv__FogDensity__pf = 0.020000f;
	bpv__FogBrightnessCurve__pf = CastChecked<UCurveFloat>(CastChecked<UDynamicClass>(ABP_LightStudio_C__pf1079297466::StaticClass())->UsedAssets[5], ECastCheckedType::NullAllowed);
	bpv__FogStartDistance__pf = 3000.000000f;
	bpv__DisableGroundScattering__pf = false;
	bpv__AtmosphereDistanceScale__pf = 1.000000f;
	bpv__SkyboxMaterial__pf = nullptr;
	bpv__HDRI_Brightness__pf = 1.000000f;
	bpv__HDRI_Contrast__pf = 1.000000f;
	bpv__HDRI_Tint__pf = FLinearColor(1.000000, 1.000000, 1.000000, 1.000000);
	bpv__HDRI_Cubemap__pf = CastChecked<UTexture>(CastChecked<UDynamicClass>(ABP_LightStudio_C__pf1079297466::StaticClass())->UsedAssets[6], ECastCheckedType::NullAllowed);
	bpv__HDRI_Rotation__pf = 0.000000f;
	bpv__AtmosphereOpacityHorizon__pf = 1.000000f;
	bpv__AtmosphereOpacityZenith__pf = 1.000000f;
	bpv__HighDensityAtmosphere__pf = true;
	bpv__AtmosphericFog__pf = nullptr;
	bpv__UseSkylight__pf = true;
	bpv__Shadowdistance__pf = 0.000000f;
	bpv__LightShaftBloom__pf = false;
	bpv__LightShaftOcclusion__pf = false;
	bpv__OcclusionMaskDarkness__pf = 0.050000f;
	bpv__BloomScale__pf = 0.200000f;
	bpv__BloomThreshold__pf = 0.000000f;
	bpv__BloomTint__pf = FColor(255, 255, 255, 0);
	bpv__AtmosphereFogMultiplier__pf = 1.000000f;
	bpv__AtmosphereDensityHeight__pf = 0.500000f;
	bpv__AtmosphereMaxScatteringOrder__pf = 4;
	bpv__AtmosphereAltitudeSampleNumber__pf = 2;
	bpv__LightFunctionMaterial__pf = nullptr;
	bpv__MIC_Black__pf = CastChecked<UMaterialInstance>(CastChecked<UDynamicClass>(ABP_LightStudio_C__pf1079297466::StaticClass())->UsedAssets[7], ECastCheckedType::NullAllowed);
	bpv__MIC_HDRI__pf = CastChecked<UMaterialInstance>(CastChecked<UDynamicClass>(ABP_LightStudio_C__pf1079297466::StaticClass())->UsedAssets[8], ECastCheckedType::NullAllowed);
	auto& __Local__28 = (*(AccessPrivateProperty<EActorUpdateOverlapsMethod >((this), AActor::__PPO__DefaultUpdateOverlapsMethodDuringLevelStreaming() )));
	__Local__28 = EActorUpdateOverlapsMethod::OnlyUpdateMovable;
}
PRAGMA_ENABLE_OPTIMIZATION
void ABP_LightStudio_C__pf1079297466::PostLoadSubobjects(FObjectInstancingGraph* OuterInstanceGraph)
{
	Super::PostLoadSubobjects(OuterInstanceGraph);
	if(bpv__Scene1__pf)
	{
		bpv__Scene1__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__Skybox__pf)
	{
		bpv__Skybox__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__PrevisArrow__pf)
	{
		bpv__PrevisArrow__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__ExponentialHeightFog1__pf)
	{
		bpv__ExponentialHeightFog1__pf->CreationMethod = EComponentCreationMethod::Native;
	}
	if(bpv__SkyLight1__pf)
	{
		bpv__SkyLight1__pf->CreationMethod = EComponentCreationMethod::Native;
	}
}
PRAGMA_DISABLE_OPTIMIZATION
void ABP_LightStudio_C__pf1079297466::__CustomDynamicClassInitialization(UDynamicClass* InDynamicClass)
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
	auto __Local__29 = NewObject<UDirectionalLightComponent>(InDynamicClass, UDirectionalLightComponent::StaticClass(), TEXT("NODE_AddDirectionalLightComponent-0"), (EObjectFlags)0x00280029);
	InDynamicClass->ComponentTemplates.Add(__Local__29);
	auto __Local__30 = NewObject<UDirectionalLightComponent>(InDynamicClass, UDirectionalLightComponent::StaticClass(), TEXT("NODE_AddDirectionalLightComponent-1"), (EObjectFlags)0x00280029);
	InDynamicClass->ComponentTemplates.Add(__Local__30);
	auto __Local__31 = NewObject<UAtmosphericFogComponent>(InDynamicClass, UAtmosphericFogComponent::StaticClass(), TEXT("NODE_AddAtmosphericFogComponent-0"), (EObjectFlags)0x00280029);
	InDynamicClass->ComponentTemplates.Add(__Local__31);
	auto __Local__32 = NewObject<UAtmosphericFogComponent>(InDynamicClass, UAtmosphericFogComponent::StaticClass(), TEXT("NODE_AddAtmosphericFogComponent-1"), (EObjectFlags)0x00280029);
	InDynamicClass->ComponentTemplates.Add(__Local__32);
	auto __Local__33 = NewObject<USceneComponent>(InDynamicClass, USceneComponent::StaticClass(), TEXT("SceneComponent_22"), (EObjectFlags)0x00280029);
	InDynamicClass->ComponentTemplates.Add(__Local__33);
	__Local__29->DynamicShadowDistanceMovableLight = 200000.000000f;
	__Local__29->CascadeDistributionExponent = 4.000000f;
	__Local__29->bAffectDynamicIndirectLighting = true;
	__Local__29->Intensity = 3.141593f;
	static TWeakFieldPtr<FProperty> __Local__35{};
	const FProperty* __Local__34 = __Local__35.Get();
	if (nullptr == __Local__34)
	{
		__Local__34 = (UActorComponent::StaticClass())->FindPropertyByName(FName(TEXT("bCanEverAffectNavigation")));
		check(__Local__34);
		__Local__35 = __Local__34;
	}
	(((FBoolProperty*)__Local__34)->SetPropertyValue_InContainer((__Local__29), false, 0));
	__Local__30->bAffectDynamicIndirectLighting = true;
	__Local__30->Intensity = 3.141593f;
	__Local__30->Mobility = EComponentMobility::Type::Stationary;
	(((FBoolProperty*)__Local__34)->SetPropertyValue_InContainer((__Local__30), false, 0));
	auto& __Local__36 = (*(AccessPrivateProperty<FAtmospherePrecomputeParameters >((__Local__31), UAtmosphericFogComponent::__PPO__PrecomputeParams() )));
	__Local__36.DensityHeight = 0.800000f;
	(((FBoolProperty*)__Local__34)->SetPropertyValue_InContainer((__Local__31), false, 0));
	(((FBoolProperty*)__Local__34)->SetPropertyValue_InContainer((__Local__32), false, 0));
	(((FBoolProperty*)__Local__34)->SetPropertyValue_InContainer((__Local__33), false, 0));
}
PRAGMA_ENABLE_OPTIMIZATION
void ABP_LightStudio_C__pf1079297466::bpf__UserConstructionScript__pf()
{
	bool bpfv__Temp_bool_Variable__pf{};
	FVector bpfv__CallFunc_MakeVector_ReturnValue__pf(EForceInit::ForceInit);
	FRotator bpfv__CallFunc_K2_GetComponentRotation_ReturnValue__pf(EForceInit::ForceInit);
	float bpfv__CallFunc_BreakRotator_Roll__pf{};
	float bpfv__CallFunc_BreakRotator_Pitch__pf{};
	float bpfv__CallFunc_BreakRotator_Yaw__pf{};
	FVector bpfv__CallFunc_MakeVector_ReturnValue_1__pf(EForceInit::ForceInit);
	float bpfv__CallFunc_Divide_FloatFloat_ReturnValue__pf{};
	FHitResult bpfv__CallFunc_K2_SetWorldLocation_SweepHitResult__pf{};
	float bpfv__CallFunc_Add_FloatFloat_ReturnValue__pf{};
	float bpfv__CallFunc_Multiply_FloatFloat_ReturnValue__pf{};
	FHitResult bpfv__CallFunc_K2_SetWorldLocation_SweepHitResult_1__pf{};
	float bpfv__CallFunc_NormalizedSunAngle_Angle__pf{};
	float bpfv__CallFunc_GetFloatValue_ReturnValue__pf{};
	float bpfv__CallFunc_Multiply_FloatFloat_ReturnValue_1__pf{};
	float bpfv__CallFunc_Multiply_FloatFloat_ReturnValue_2__pf{};
	FLinearColor bpfv__CallFunc_Conv_FloatToLinearColor_ReturnValue__pf(EForceInit::ForceInit);
	FLinearColor bpfv__CallFunc_LinearColorLerp_ReturnValue__pf(EForceInit::ForceInit);
	FLinearColor bpfv__CallFunc_Multiply_LinearColorLinearColor_ReturnValue__pf(EForceInit::ForceInit);
	FLinearColor bpfv__CallFunc_Multiply_LinearColorLinearColor_ReturnValue_1__pf(EForceInit::ForceInit);
	float bpfv__CallFunc_Multiply_FloatFloat_ReturnValue_3__pf{};
	UMaterialInterface* bpfv__K2Node_Select_Default__pf{};
	UMaterialInstanceDynamic* bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue__pf{};
	UMaterialInstanceDynamic* bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue_1__pf{};
	FHitResult bpfv__CallFunc_K2_SetWorldRotation_SweepHitResult__pf{};
	TArray< int32, TInlineAllocator<8> > __StateStack;

	int32 __CurrentState = 1;
	do
	{
		switch( __CurrentState )
		{
		case 1:
			{
				__StateStack.Push(47);
				__StateStack.Push(40);
				__StateStack.Push(36);
				__StateStack.Push(22);
				__StateStack.Push(11);
			}
		case 2:
			{
				if(::IsValid(bpv__Skybox__pf))
				{
					bpv__Skybox__pf->USceneComponent::K2_SetWorldRotation(FRotator(0.000000,0.000000,0.000000), false, /*out*/ bpfv__CallFunc_K2_SetWorldRotation_SweepHitResult__pf, false);
				}
			}
		case 3:
			{
				bpfv__Temp_bool_Variable__pf = bpv__Use_HDRI__pf;
				bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue__pf = UKismetMaterialLibrary::CreateDynamicMaterialInstance(this, TSwitchValue<bool , UMaterialInterface* >(bpfv__Temp_bool_Variable__pf, bpfv__K2Node_Select_Default__pf, 2, TSwitchPair<bool , UMaterialInterface* >(false, *(UMaterialInterface**)(&(bpv__MIC_Black__pf))), TSwitchPair<bool , UMaterialInterface* >(true, *(UMaterialInterface**)(&(bpv__MIC_HDRI__pf)))), FName(TEXT("None")), EMIDCreationFlags::None);
			}
		case 4:
			{
				bpv__SkyboxMaterial__pf = bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue__pf;
			}
		case 5:
			{
				if(::IsValid(bpv__Skybox__pf))
				{
					bpv__Skybox__pf->SetMaterial(0, bpv__SkyboxMaterial__pf);
				}
			}
		case 6:
			{
				bpfv__CallFunc_Multiply_FloatFloat_ReturnValue__pf = UKismetMathLibrary::Multiply_FloatFloat(bpv__HDRI_Brightness__pf, bpv__GlobalBrightness__pf);
				if(::IsValid(bpv__SkyboxMaterial__pf))
				{
					bpv__SkyboxMaterial__pf->UMaterialInstanceDynamic::SetScalarParameterValue(FName(TEXT("HDRI_Brightness")), bpfv__CallFunc_Multiply_FloatFloat_ReturnValue__pf);
				}
			}
		case 7:
			{
				if(::IsValid(bpv__SkyboxMaterial__pf))
				{
					bpv__SkyboxMaterial__pf->UMaterialInstanceDynamic::SetVectorParameterValue(FName(TEXT("HDRI_Tint")), bpv__HDRI_Tint__pf);
				}
			}
		case 8:
			{
				if(::IsValid(bpv__SkyboxMaterial__pf))
				{
					bpv__SkyboxMaterial__pf->UMaterialInstanceDynamic::SetTextureParameterValue(FName(TEXT("HDRI_Cubemap")), bpv__HDRI_Cubemap__pf);
				}
			}
		case 9:
			{
				if(::IsValid(bpv__PrevisArrow__pf))
				{
					bpfv__CallFunc_K2_GetComponentRotation_ReturnValue__pf = bpv__PrevisArrow__pf->USceneComponent::K2_GetComponentRotation();
				}
				UKismetMathLibrary::BreakRotator(bpfv__CallFunc_K2_GetComponentRotation_ReturnValue__pf, /*out*/ bpfv__CallFunc_BreakRotator_Roll__pf, /*out*/ bpfv__CallFunc_BreakRotator_Pitch__pf, /*out*/ bpfv__CallFunc_BreakRotator_Yaw__pf);
				bpfv__CallFunc_Divide_FloatFloat_ReturnValue__pf = FCustomThunkTemplates::Divide_FloatFloat(bpfv__CallFunc_BreakRotator_Yaw__pf, -360.000000);
				bpfv__CallFunc_Add_FloatFloat_ReturnValue__pf = UKismetMathLibrary::Add_FloatFloat(bpfv__CallFunc_Divide_FloatFloat_ReturnValue__pf, bpv__HDRI_Rotation__pf);
				if(::IsValid(bpv__SkyboxMaterial__pf))
				{
					bpv__SkyboxMaterial__pf->UMaterialInstanceDynamic::SetScalarParameterValue(FName(TEXT("CubemapRotation")), bpfv__CallFunc_Add_FloatFloat_ReturnValue__pf);
				}
			}
		case 10:
			{
				if(::IsValid(bpv__SkyboxMaterial__pf))
				{
					bpv__SkyboxMaterial__pf->UMaterialInstanceDynamic::SetScalarParameterValue(FName(TEXT("HDRI_Contrast")), bpv__HDRI_Contrast__pf);
				}
				__CurrentState = (__StateStack.Num() > 0) ? __StateStack.Pop(/*bAllowShrinking=*/ false) : -1;
				break;
			}
		case 11:
			{
				bpf__AtmosphereDensity__pf();
			}
		case 12:
			{
				if(::IsValid(bpv__AtmosphericFog__pf))
				{
					bpv__AtmosphericFog__pf->USceneComponent::SetVisibility(bpv__UseAtmosphere__pf, false);
				}
			}
		case 13:
			{
				bpfv__CallFunc_MakeVector_ReturnValue_1__pf = UKismetMathLibrary::MakeVector(0.000000, 0.000000, bpv__AtmosphereAltitude__pf);
				if(::IsValid(bpv__AtmosphericFog__pf))
				{
					bpv__AtmosphericFog__pf->USceneComponent::K2_SetWorldLocation(bpfv__CallFunc_MakeVector_ReturnValue_1__pf, false, /*out*/ bpfv__CallFunc_K2_SetWorldLocation_SweepHitResult__pf, false);
				}
			}
		case 14:
			{
				bpfv__CallFunc_Multiply_FloatFloat_ReturnValue_3__pf = UKismetMathLibrary::Multiply_FloatFloat(bpv__GlobalBrightness__pf, bpv__AtmosphereBrightness__pf);
				if(::IsValid(bpv__AtmosphericFog__pf))
				{
					bpv__AtmosphericFog__pf->UAtmosphericFogComponent::SetDefaultBrightness(bpfv__CallFunc_Multiply_FloatFloat_ReturnValue_3__pf);
				}
			}
		case 15:
			{
				if(::IsValid(bpv__AtmosphericFog__pf))
				{
					bpv__AtmosphericFog__pf->UAtmosphericFogComponent::DisableSunDisk(bpv__DisableSunDisk__pf);
				}
			}
		case 16:
			{
				if(::IsValid(bpv__AtmosphericFog__pf))
				{
					bpv__AtmosphericFog__pf->UAtmosphericFogComponent::DisableGroundScattering(bpv__DisableGroundScattering__pf);
				}
			}
		case 17:
			{
				if(::IsValid(bpv__AtmosphericFog__pf))
				{
					bpv__AtmosphericFog__pf->UAtmosphericFogComponent::SetSunMultiplier(bpv__AtmosphereBrightness__pf);
				}
			}
		case 18:
			{
				if(::IsValid(bpv__AtmosphericFog__pf))
				{
					bpv__AtmosphericFog__pf->UAtmosphericFogComponent::SetDefaultLightColor(bpv__AtmosphereTint__pf);
				}
			}
		case 19:
			{
				if(::IsValid(bpv__AtmosphericFog__pf))
				{
					bpv__AtmosphericFog__pf->UAtmosphericFogComponent::SetDistanceScale(bpv__AtmosphereDistanceScale__pf);
				}
			}
		case 20:
			{
				if(::IsValid(bpv__AtmosphericFog__pf))
				{
					bpv__AtmosphericFog__pf->UAtmosphericFogComponent::SetDensityMultiplier(bpv__AtmosphereDensityMultiplier__pf);
				}
			}
		case 21:
			{
				if(::IsValid(bpv__AtmosphericFog__pf))
				{
					bpv__AtmosphericFog__pf->UAtmosphericFogComponent::SetFogMultiplier(bpv__AtmosphereFogMultiplier__pf);
				}
				__CurrentState = (__StateStack.Num() > 0) ? __StateStack.Pop(/*bAllowShrinking=*/ false) : -1;
				break;
			}
		case 22:
			{
				if (!bpv__UseSunLight__pf)
				{
					__CurrentState = (__StateStack.Num() > 0) ? __StateStack.Pop(/*bAllowShrinking=*/ false) : -1;
					break;
				}
			}
		case 23:
			{
				bpf__SunMobility__pf();
			}
		case 24:
			{
				bpf__CalculateSunColor__pf();
			}
		case 25:
			{
				if(::IsValid(bpv__SunDirectionalLight__pf))
				{
					bpv__SunDirectionalLight__pf->ULightComponent::SetIntensity(bpv__SunBrightness__pf);
				}
			}
		case 26:
			{
				if(::IsValid(bpv__SunDirectionalLight__pf))
				{
					bpv__SunDirectionalLight__pf->ULightComponent::SetLightColor(bpv__LightColor__pf, true);
				}
			}
		case 27:
			{
				if(::IsValid(bpv__SunDirectionalLight__pf))
				{
					bpv__SunDirectionalLight__pf->UDirectionalLightComponent::SetDynamicShadowDistanceMovableLight(bpv__Shadowdistance__pf);
				}
			}
		case 28:
			{
				if(::IsValid(bpv__SunDirectionalLight__pf))
				{
					bpv__SunDirectionalLight__pf->UDirectionalLightComponent::SetDynamicShadowDistanceStationaryLight(bpv__Shadowdistance__pf);
				}
			}
		case 29:
			{
				if(::IsValid(bpv__SunDirectionalLight__pf))
				{
					bpv__SunDirectionalLight__pf->ULightComponent::SetEnableLightShaftBloom(bpv__LightShaftBloom__pf);
				}
			}
		case 30:
			{
				if(::IsValid(bpv__SunDirectionalLight__pf))
				{
					bpv__SunDirectionalLight__pf->UDirectionalLightComponent::SetEnableLightShaftOcclusion(bpv__LightShaftOcclusion__pf);
				}
			}
		case 31:
			{
				if(::IsValid(bpv__SunDirectionalLight__pf))
				{
					bpv__SunDirectionalLight__pf->UDirectionalLightComponent::SetOcclusionMaskDarkness(bpv__OcclusionMaskDarkness__pf);
				}
			}
		case 32:
			{
				if(::IsValid(bpv__SunDirectionalLight__pf))
				{
					bpv__SunDirectionalLight__pf->ULightComponent::SetBloomScale(bpv__BloomScale__pf);
				}
			}
		case 33:
			{
				if(::IsValid(bpv__SunDirectionalLight__pf))
				{
					bpv__SunDirectionalLight__pf->ULightComponent::SetBloomThreshold(bpv__BloomThreshold__pf);
				}
			}
		case 34:
			{
				if(::IsValid(bpv__SunDirectionalLight__pf))
				{
					bpv__SunDirectionalLight__pf->ULightComponent::SetBloomTint(bpv__BloomTint__pf);
				}
			}
		case 35:
			{
				if(::IsValid(bpv__SunDirectionalLight__pf))
				{
					bpv__SunDirectionalLight__pf->ULightComponent::SetLightFunctionMaterial(bpv__LightFunctionMaterial__pf);
				}
				__CurrentState = (__StateStack.Num() > 0) ? __StateStack.Pop(/*bAllowShrinking=*/ false) : -1;
				break;
			}
		case 36:
			{
				bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue_1__pf = UKismetMaterialLibrary::CreateDynamicMaterialInstance(this, CastChecked<UMaterialInterface>(CastChecked<UDynamicClass>(ABP_LightStudio_C__pf1079297466::StaticClass())->UsedAssets[3], ECastCheckedType::NullAllowed), FName(TEXT("None")), EMIDCreationFlags::None);
			}
		case 37:
			{
				bpv__PrevisArrowMaterial__pf = bpfv__CallFunc_CreateDynamicMaterialInstance_ReturnValue_1__pf;
			}
		case 38:
			{
				if(::IsValid(bpv__PrevisArrow__pf))
				{
					bpv__PrevisArrow__pf->SetMaterial(0, bpv__PrevisArrowMaterial__pf);
				}
			}
		case 39:
			{
				if(::IsValid(bpv__PrevisArrowMaterial__pf))
				{
					bpv__PrevisArrowMaterial__pf->UMaterialInstanceDynamic::SetVectorParameterValue(FName(TEXT("SunColor")), bpv__LightColor__pf);
				}
				__CurrentState = (__StateStack.Num() > 0) ? __StateStack.Pop(/*bAllowShrinking=*/ false) : -1;
				break;
			}
		case 40:
			{
				if(::IsValid(bpv__ExponentialHeightFog1__pf))
				{
					bpv__ExponentialHeightFog1__pf->USceneComponent::SetVisibility(bpv__UseFog__pf, false);
				}
			}
		case 41:
			{
				bpf__NormalizedSunAngle__pf(/*out*/ bpfv__CallFunc_NormalizedSunAngle_Angle__pf);
				if(::IsValid(bpv__FogBrightnessCurve__pf))
				{
					bpfv__CallFunc_GetFloatValue_ReturnValue__pf = bpv__FogBrightnessCurve__pf->UCurveFloat::GetFloatValue(bpfv__CallFunc_NormalizedSunAngle_Angle__pf);
				}
				bpfv__CallFunc_Multiply_FloatFloat_ReturnValue_1__pf = UKismetMathLibrary::Multiply_FloatFloat(bpv__FogBrightness__pf, bpfv__CallFunc_GetFloatValue_ReturnValue__pf);
				bpfv__CallFunc_Multiply_FloatFloat_ReturnValue_2__pf = UKismetMathLibrary::Multiply_FloatFloat(bpv__GlobalBrightness__pf, bpfv__CallFunc_Multiply_FloatFloat_ReturnValue_1__pf);
				bpfv__CallFunc_Conv_FloatToLinearColor_ReturnValue__pf = UKismetMathLibrary::Conv_FloatToLinearColor(bpfv__CallFunc_Multiply_FloatFloat_ReturnValue_2__pf);
				bpfv__CallFunc_LinearColorLerp_ReturnValue__pf = UKismetMathLibrary::LinearColorLerp(bpv__LightColor__pf, FLinearColor(1.000000,1.000000,1.000000,1.000000), 0.500000);
				bpfv__CallFunc_Multiply_LinearColorLinearColor_ReturnValue__pf = UKismetMathLibrary::Multiply_LinearColorLinearColor(bpv__FogTint__pf, bpfv__CallFunc_Conv_FloatToLinearColor_ReturnValue__pf);
				bpfv__CallFunc_Multiply_LinearColorLinearColor_ReturnValue_1__pf = UKismetMathLibrary::Multiply_LinearColorLinearColor(bpfv__CallFunc_LinearColorLerp_ReturnValue__pf, bpfv__CallFunc_Multiply_LinearColorLinearColor_ReturnValue__pf);
				if(::IsValid(bpv__ExponentialHeightFog1__pf))
				{
					bpv__ExponentialHeightFog1__pf->UExponentialHeightFogComponent::SetFogInscatteringColor(bpfv__CallFunc_Multiply_LinearColorLinearColor_ReturnValue_1__pf);
				}
			}
		case 42:
			{
				if(::IsValid(bpv__ExponentialHeightFog1__pf))
				{
					bpv__ExponentialHeightFog1__pf->UExponentialHeightFogComponent::SetFogMaxOpacity(bpv__FogMaxOpacity__pf);
				}
			}
		case 43:
			{
				if(::IsValid(bpv__ExponentialHeightFog1__pf))
				{
					bpv__ExponentialHeightFog1__pf->UExponentialHeightFogComponent::SetFogHeightFalloff(bpv__FogHeightFalloff__pf);
				}
			}
		case 44:
			{
				if(::IsValid(bpv__ExponentialHeightFog1__pf))
				{
					bpv__ExponentialHeightFog1__pf->UExponentialHeightFogComponent::SetFogDensity(bpv__FogDensity__pf);
				}
			}
		case 45:
			{
				if(::IsValid(bpv__ExponentialHeightFog1__pf))
				{
					bpv__ExponentialHeightFog1__pf->UExponentialHeightFogComponent::SetStartDistance(bpv__FogStartDistance__pf);
				}
			}
		case 46:
			{
				bpfv__CallFunc_MakeVector_ReturnValue__pf = UKismetMathLibrary::MakeVector(0.000000, 0.000000, bpv__FogAltitude__pf);
				if(::IsValid(bpv__ExponentialHeightFog1__pf))
				{
					bpv__ExponentialHeightFog1__pf->USceneComponent::K2_SetWorldLocation(bpfv__CallFunc_MakeVector_ReturnValue__pf, false, /*out*/ bpfv__CallFunc_K2_SetWorldLocation_SweepHitResult_1__pf, false);
				}
				__CurrentState = (__StateStack.Num() > 0) ? __StateStack.Pop(/*bAllowShrinking=*/ false) : -1;
				break;
			}
		case 47:
			{
				if(::IsValid(bpv__SkyLight1__pf))
				{
					bpv__SkyLight1__pf->USkyLightComponent::RecaptureSky();
				}
			}
		case 48:
			{
				if (!bpv__UseSkylight__pf)
				{
					__CurrentState = 49;
					break;
				}
				__CurrentState = (__StateStack.Num() > 0) ? __StateStack.Pop(/*bAllowShrinking=*/ false) : -1;
				break;
			}
		case 49:
			{
				if(::IsValid(bpv__SkyLight1__pf))
				{
					bpv__SkyLight1__pf->UActorComponent::K2_DestroyComponent(this);
				}
				__CurrentState = (__StateStack.Num() > 0) ? __StateStack.Pop(/*bAllowShrinking=*/ false) : -1;
				break;
			}
		default:
			check(false); // Invalid state
			break;
		}
	} while( __CurrentState != -1 );
}
void ABP_LightStudio_C__pf1079297466::bpf__CalculateSunColor__pf()
{
	float bpfv__CallFunc_NormalizedSunAngle_Angle__pf{};
	FLinearColor bpfv__CallFunc_GetLinearColorValue_ReturnValue__pf(EForceInit::ForceInit);
	float bpfv__CallFunc_BreakColor_R__pf{};
	float bpfv__CallFunc_BreakColor_G__pf{};
	float bpfv__CallFunc_BreakColor_B__pf{};
	float bpfv__CallFunc_BreakColor_A__pf{};
	FLinearColor bpfv__CallFunc_MakeColor_ReturnValue__pf(EForceInit::ForceInit);
	FLinearColor bpfv__CallFunc_Multiply_LinearColorLinearColor_ReturnValue__pf(EForceInit::ForceInit);
	FLinearColor bpfv__CallFunc_SelectColor_ReturnValue__pf(EForceInit::ForceInit);
	bpf__NormalizedSunAngle__pf(/*out*/ bpfv__CallFunc_NormalizedSunAngle_Angle__pf);
	if(::IsValid(bpv__SunColorCurve__pf))
	{
		bpfv__CallFunc_GetLinearColorValue_ReturnValue__pf = bpv__SunColorCurve__pf->GetLinearColorValue(bpfv__CallFunc_NormalizedSunAngle_Angle__pf);
	}
	UKismetMathLibrary::BreakColor(bpfv__CallFunc_GetLinearColorValue_ReturnValue__pf, /*out*/ bpfv__CallFunc_BreakColor_R__pf, /*out*/ bpfv__CallFunc_BreakColor_G__pf, /*out*/ bpfv__CallFunc_BreakColor_B__pf, /*out*/ bpfv__CallFunc_BreakColor_A__pf);
	bpfv__CallFunc_MakeColor_ReturnValue__pf = UKismetMathLibrary::MakeColor(bpfv__CallFunc_BreakColor_R__pf, bpfv__CallFunc_BreakColor_G__pf, bpfv__CallFunc_BreakColor_B__pf, 1.000000);
	bpfv__CallFunc_Multiply_LinearColorLinearColor_ReturnValue__pf = UKismetMathLibrary::Multiply_LinearColorLinearColor(bpfv__CallFunc_MakeColor_ReturnValue__pf, bpv__SunTint__pf);
	bpfv__CallFunc_SelectColor_ReturnValue__pf = UKismetMathLibrary::SelectColor(bpv__SunTint__pf, bpfv__CallFunc_Multiply_LinearColorLinearColor_ReturnValue__pf, bpv__OverrideSunColor__pf);
	bpv__LightColor__pf = bpfv__CallFunc_SelectColor_ReturnValue__pf;
}
void ABP_LightStudio_C__pf1079297466::bpf__SunMobility__pf()
{
	FTransform bpfv__Temp_struct_Variable__pf{};
	FTransform bpfv__Temp_struct_Variable_1__pf{};
	UDirectionalLightComponent* bpfv__CallFunc_AddComponent_ReturnValue__pf{};
	UDirectionalLightComponent* bpfv__CallFunc_AddComponent_ReturnValue_1__pf{};
	int32 __CurrentState = 1;
	do
	{
		switch( __CurrentState )
		{
		case 1:
			{
				if (!bpv__StationaryLightForSun__pf)
				{
					__CurrentState = 4;
					break;
				}
			}
		case 2:
			{
				bpfv__Temp_struct_Variable__pf = FTransform( FQuat(0.000000,-0.000000,0.000000,1.000000), FVector(0.000000,0.000000,0.000000), FVector(1.000000,1.000000,1.000000) );
				bpfv__CallFunc_AddComponent_ReturnValue__pf = CastChecked<UDirectionalLightComponent>(AActor::AddComponent(FName(TEXT("NODE_AddDirectionalLightComponent-1")), false, bpfv__Temp_struct_Variable__pf, this, false), ECastCheckedType::NullAllowed);
			}
		case 3:
			{
				bpv__SunDirectionalLight__pf = bpfv__CallFunc_AddComponent_ReturnValue__pf;
				__CurrentState = -1;
				break;
			}
		case 4:
			{
				bpfv__Temp_struct_Variable_1__pf = FTransform( FQuat(0.000000,-0.000000,0.000000,1.000000), FVector(0.000000,0.000000,0.000000), FVector(1.000000,1.000000,1.000000) );
				bpfv__CallFunc_AddComponent_ReturnValue_1__pf = CastChecked<UDirectionalLightComponent>(AActor::AddComponent(FName(TEXT("NODE_AddDirectionalLightComponent-0")), false, bpfv__Temp_struct_Variable_1__pf, this, false), ECastCheckedType::NullAllowed);
			}
		case 5:
			{
				bpv__SunDirectionalLight__pf = bpfv__CallFunc_AddComponent_ReturnValue_1__pf;
				__CurrentState = -1;
				break;
			}
		default:
			break;
		}
	} while( __CurrentState != -1 );
}
void ABP_LightStudio_C__pf1079297466::bpf__NormalizedSunAngle__pf(/*out*/ float& bpp__Angle__pf)
{
	FRotator bpfv__CallFunc_K2_GetActorRotation_ReturnValue__pf(EForceInit::ForceInit);
	float bpfv__CallFunc_BreakRotator_Roll__pf{};
	float bpfv__CallFunc_BreakRotator_Pitch__pf{};
	float bpfv__CallFunc_BreakRotator_Yaw__pf{};
	float bpfv__CallFunc_Subtract_FloatFloat_ReturnValue__pf{};
	float bpfv__CallFunc_Abs_ReturnValue__pf{};
	float bpfv__CallFunc_Divide_FloatFloat_ReturnValue__pf{};
	float bpfv__CallFunc_Abs_ReturnValue_1__pf{};
	float bpfv__CallFunc_Add_FloatFloat_ReturnValue__pf{};
	bpfv__CallFunc_K2_GetActorRotation_ReturnValue__pf = AActor::K2_GetActorRotation();
	UKismetMathLibrary::BreakRotator(bpfv__CallFunc_K2_GetActorRotation_ReturnValue__pf, /*out*/ bpfv__CallFunc_BreakRotator_Roll__pf, /*out*/ bpfv__CallFunc_BreakRotator_Pitch__pf, /*out*/ bpfv__CallFunc_BreakRotator_Yaw__pf);
	bpfv__CallFunc_Subtract_FloatFloat_ReturnValue__pf = UKismetMathLibrary::Subtract_FloatFloat(bpfv__CallFunc_BreakRotator_Pitch__pf, 90.000000);
	bpfv__CallFunc_Abs_ReturnValue__pf = UKismetMathLibrary::Abs(bpfv__CallFunc_Subtract_FloatFloat_ReturnValue__pf);
	bpfv__CallFunc_Divide_FloatFloat_ReturnValue__pf = FCustomThunkTemplates::Divide_FloatFloat(bpfv__CallFunc_Abs_ReturnValue__pf, 90.000000);
	bpfv__CallFunc_Abs_ReturnValue_1__pf = UKismetMathLibrary::Abs(bpfv__CallFunc_Divide_FloatFloat_ReturnValue__pf);
	bpfv__CallFunc_Add_FloatFloat_ReturnValue__pf = UKismetMathLibrary::Add_FloatFloat(bpfv__CallFunc_Abs_ReturnValue_1__pf, -1.000000);
	bpp__Angle__pf = bpfv__CallFunc_Add_FloatFloat_ReturnValue__pf;
}
void ABP_LightStudio_C__pf1079297466::bpf__AtmosphereDensity__pf()
{
	FTransform bpfv__Temp_struct_Variable__pf{};
	FTransform bpfv__Temp_struct_Variable_1__pf{};
	UAtmosphericFogComponent* bpfv__CallFunc_AddComponent_ReturnValue__pf{};
	UAtmosphericFogComponent* bpfv__CallFunc_AddComponent_ReturnValue_1__pf{};
	int32 __CurrentState = 1;
	do
	{
		switch( __CurrentState )
		{
		case 1:
			{
				if (!bpv__HighDensityAtmosphere__pf)
				{
					__CurrentState = 5;
					break;
				}
			}
		case 2:
			{
				bpfv__Temp_struct_Variable_1__pf = FTransform( FQuat(0.000000,-0.000000,0.000000,1.000000), FVector(0.000000,0.000000,0.000000), FVector(1.000000,1.000000,1.000000) );
				bpfv__CallFunc_AddComponent_ReturnValue_1__pf = CastChecked<UAtmosphericFogComponent>(AActor::AddComponent(FName(TEXT("NODE_AddAtmosphericFogComponent-0")), false, bpfv__Temp_struct_Variable_1__pf, this, false), ECastCheckedType::NullAllowed);
			}
		case 3:
			{
				bpv__AtmosphericFog__pf = bpfv__CallFunc_AddComponent_ReturnValue_1__pf;
			}
		case 4:
			{
				if(::IsValid(bpv__AtmosphericFog__pf))
				{
					bpv__AtmosphericFog__pf->UAtmosphericFogComponent::SetPrecomputeParams(bpv__AtmosphereDensityHeight__pf, bpv__AtmosphereMaxScatteringOrder__pf, bpv__AtmosphereAltitudeSampleNumber__pf);
				}
				__CurrentState = -1;
				break;
			}
		case 5:
			{
				bpfv__Temp_struct_Variable__pf = FTransform( FQuat(0.000000,-0.000000,0.000000,1.000000), FVector(0.000000,0.000000,0.000000), FVector(1.000000,1.000000,1.000000) );
				bpfv__CallFunc_AddComponent_ReturnValue__pf = CastChecked<UAtmosphericFogComponent>(AActor::AddComponent(FName(TEXT("NODE_AddAtmosphericFogComponent-1")), false, bpfv__Temp_struct_Variable__pf, this, false), ECastCheckedType::NullAllowed);
			}
		case 6:
			{
				bpv__AtmosphericFog__pf = bpfv__CallFunc_AddComponent_ReturnValue__pf;
				__CurrentState = -1;
				break;
			}
		default:
			break;
		}
	} while( __CurrentState != -1 );
}
PRAGMA_DISABLE_OPTIMIZATION
void ABP_LightStudio_C__pf1079297466::__StaticDependencies_DirectlyUsedAssets(TArray<FBlueprintDependencyData>& AssetsToLoad)
{
	const FCompactBlueprintDependencyData LocCompactBlueprintDependencyData[] =
	{
		{86, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  StaticMesh /Game/StarterContent/Blueprints/Assets/Skybox.Skybox 
		{87, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Material /Game/StarterContent/Blueprints/Assets/M_LightStage_Skybox_Master.M_LightStage_Skybox_Master 
		{88, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  StaticMesh /Game/StarterContent/Blueprints/Assets/SM_Arrows.SM_Arrows 
		{89, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Material /Game/StarterContent/Blueprints/Assets/M_LightStage_Arrows.M_LightStage_Arrows 
		{90, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  CurveLinearColor /Game/StarterContent/Blueprints/Assets/SunlightColorLUT.SunlightColorLUT 
		{91, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  CurveFloat /Game/StarterContent/Blueprints/Assets/FogBrightnessLUT.FogBrightnessLUT 
		{92, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  TextureCube /Game/StarterContent/HDRI/HDRI_Epic_Courtyard_Daylight.HDRI_Epic_Courtyard_Daylight 
		{93, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  MaterialInstanceConstant /Game/StarterContent/Blueprints/Assets/M_LightStage_Skybox_Black.M_LightStage_Skybox_Black 
		{94, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  MaterialInstanceConstant /Game/StarterContent/Blueprints/Assets/M_LightStage_Skybox_HDRI.M_LightStage_Skybox_HDRI 
	};
	for(const FCompactBlueprintDependencyData& CompactData : LocCompactBlueprintDependencyData)
	{
		AssetsToLoad.Add(FBlueprintDependencyData(F__NativeDependencies::Get(CompactData.ObjectRefIndex), CompactData));
	}
}
PRAGMA_ENABLE_OPTIMIZATION
PRAGMA_DISABLE_OPTIMIZATION
void ABP_LightStudio_C__pf1079297466::__StaticDependenciesAssets(TArray<FBlueprintDependencyData>& AssetsToLoad)
{
	__StaticDependencies_DirectlyUsedAssets(AssetsToLoad);
	const FCompactBlueprintDependencyData LocCompactBlueprintDependencyData[] =
	{
		{3, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.SceneComponent 
		{7, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.StaticMeshComponent 
		{95, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.ExponentialHeightFogComponent 
		{96, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.SkyLightComponent 
		{20, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.Actor 
		{97, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.AtmosphericFogComponent 
		{15, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.KismetMathLibrary 
		{98, FBlueprintDependencyType(true, false, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.DirectionalLightComponent 
		{76, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.CurveLinearColor 
		{11, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  ScriptStruct /Script/Engine.HitResult 
		{99, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.MaterialInterface 
		{21, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.MaterialInstanceDynamic 
		{100, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.KismetMaterialLibrary 
		{101, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.MaterialInstance 
		{102, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.Texture 
		{65, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.LightComponent 
		{103, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.CurveFloat 
		{104, FBlueprintDependencyType(false, true, false, false), FBlueprintDependencyType(false, false, false, false)},  //  Class /Script/Engine.ActorComponent 
	};
	for(const FCompactBlueprintDependencyData& CompactData : LocCompactBlueprintDependencyData)
	{
		AssetsToLoad.Add(FBlueprintDependencyData(F__NativeDependencies::Get(CompactData.ObjectRefIndex), CompactData));
	}
}
PRAGMA_ENABLE_OPTIMIZATION
struct FRegisterHelper__ABP_LightStudio_C__pf1079297466
{
	FRegisterHelper__ABP_LightStudio_C__pf1079297466()
	{
		FConvertedBlueprintsDependencies::Get().RegisterConvertedClass(TEXT("/Game/StarterContent/Blueprints/BP_LightStudio"), &ABP_LightStudio_C__pf1079297466::__StaticDependenciesAssets);
	}
	static FRegisterHelper__ABP_LightStudio_C__pf1079297466 Instance;
};
FRegisterHelper__ABP_LightStudio_C__pf1079297466 FRegisterHelper__ABP_LightStudio_C__pf1079297466::Instance;
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
