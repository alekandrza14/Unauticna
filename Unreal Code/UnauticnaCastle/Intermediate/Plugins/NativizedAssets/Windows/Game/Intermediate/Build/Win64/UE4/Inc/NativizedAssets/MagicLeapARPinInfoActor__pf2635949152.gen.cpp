// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "NativizedAssets/Public/MagicLeapARPinInfoActor__pf2635949152.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeMagicLeapARPinInfoActor__pf2635949152() {}
// Cross Module References
	NATIVIZEDASSETS_API UClass* Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_NoRegister();
	NATIVIZEDASSETS_API UClass* Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152();
	MAGICLEAPARPIN_API UClass* Z_Construct_UClass_AMagicLeapARPinInfoActorBase();
	ENGINE_API UClass* Z_Construct_UClass_UStaticMeshComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_USphereComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_USceneComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UTextRenderComponent_NoRegister();
	COREUOBJECT_API UScriptStruct* Z_Construct_UScriptStruct_FVector();
	COREUOBJECT_API UScriptStruct* Z_Construct_UScriptStruct_FRotator();
	ENGINE_API UScriptStruct* Z_Construct_UScriptStruct_FHitResult();
	MAGICLEAPARPIN_API UScriptStruct* Z_Construct_UScriptStruct_FMagicLeapARPinState();
// End Cross Module References
	DEFINE_FUNCTION(AMagicLeapARPinInfoActor_C__pf2635949152::execbpf__UpdatePinState__pf)
	{
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__UpdatePinState__pf();
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AMagicLeapARPinInfoActor_C__pf2635949152::execbpf__UserConstructionScript__pf)
	{
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__UserConstructionScript__pf();
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AMagicLeapARPinInfoActor_C__pf2635949152::execbpf__OnUpdateARPinState__pf)
	{
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__OnUpdateARPinState__pf();
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AMagicLeapARPinInfoActor_C__pf2635949152::execbpf__ReceiveTick__pf)
	{
		P_GET_PROPERTY(FFloatProperty,Z_Param_bpp__DeltaSeconds__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__ReceiveTick__pf(Z_Param_bpp__DeltaSeconds__pf);
		P_NATIVE_END;
	}
	static FName NAME_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__OnUpdateARPinState__pf = FName(TEXT("OnUpdateARPinState"));
	void AMagicLeapARPinInfoActor_C__pf2635949152::eventbpf__OnUpdateARPinState__pf()
	{
		ProcessEvent(FindFunctionChecked(NAME_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__OnUpdateARPinState__pf),NULL);
	}
	static FName NAME_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf = FName(TEXT("ReceiveTick"));
	void AMagicLeapARPinInfoActor_C__pf2635949152::eventbpf__ReceiveTick__pf(float bpp__DeltaSeconds__pf)
	{
		MagicLeapARPinInfoActor_C__pf2635949152_eventbpf__ReceiveTick__pf_Parms Parms;
		Parms.bpp__DeltaSeconds__pf=bpp__DeltaSeconds__pf;
		ProcessEvent(FindFunctionChecked(NAME_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf),&Parms);
	}
	static FName NAME_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UserConstructionScript__pf = FName(TEXT("UserConstructionScript"));
	void AMagicLeapARPinInfoActor_C__pf2635949152::eventbpf__UserConstructionScript__pf()
	{
		ProcessEvent(FindFunctionChecked(NAME_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UserConstructionScript__pf),NULL);
	}
	void AMagicLeapARPinInfoActor_C__pf2635949152::StaticRegisterNativesAMagicLeapARPinInfoActor_C__pf2635949152()
	{
		UClass* Class = AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass();
		static const FNameNativePtrPair Funcs[] = {
			{ "OnUpdateARPinState", &AMagicLeapARPinInfoActor_C__pf2635949152::execbpf__OnUpdateARPinState__pf },
			{ "ReceiveTick", &AMagicLeapARPinInfoActor_C__pf2635949152::execbpf__ReceiveTick__pf },
			{ "UpdatePinState", &AMagicLeapARPinInfoActor_C__pf2635949152::execbpf__UpdatePinState__pf },
			{ "UserConstructionScript", &AMagicLeapARPinInfoActor_C__pf2635949152::execbpf__UserConstructionScript__pf },
		};
		FNativeFunctionRegistrar::RegisterFunctions(Class, Funcs, UE_ARRAY_COUNT(Funcs));
	}
	struct Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__OnUpdateARPinState__pf_Statics
	{
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__OnUpdateARPinState__pf_Statics::Function_MetaDataParams[] = {
		{ "Category", "ContentPersistence|MagicLeap" },
		{ "CppFromBpEvent", "" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "OnUpdateARPinState" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__OnUpdateARPinState__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152, nullptr, "OnUpdateARPinState", nullptr, nullptr, 0, nullptr, 0, RF_Public|RF_Transient, (EFunctionFlags)0x04020C00, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__OnUpdateARPinState__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__OnUpdateARPinState__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__OnUpdateARPinState__pf()
	{
		UObject* Outer = Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "OnUpdateARPinState" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__OnUpdateARPinState__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf_Statics
	{
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpp__DeltaSeconds__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf_Statics::NewProp_bpp__DeltaSeconds__pf = { "bpp__DeltaSeconds__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient, 1, STRUCT_OFFSET(MagicLeapARPinInfoActor_C__pf2635949152_eventbpf__ReceiveTick__pf_Parms, bpp__DeltaSeconds__pf), METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf_Statics::NewProp_bpp__DeltaSeconds__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf_Statics::Function_MetaDataParams[] = {
		{ "Comment", "/** Event called every frame, if ticking is enabled */" },
		{ "CppFromBpEvent", "" },
		{ "DisplayName", "Tick" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "ReceiveTick" },
		{ "ToolTip", "Event called every frame, if ticking is enabled" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152, nullptr, "ReceiveTick", nullptr, nullptr, sizeof(MagicLeapARPinInfoActor_C__pf2635949152_eventbpf__ReceiveTick__pf_Parms), Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00020C00, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf()
	{
		UObject* Outer = Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "ReceiveTick" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UpdatePinState__pf_Statics
	{
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UpdatePinState__pf_Statics::Function_MetaDataParams[] = {
		{ "Category", "" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "UpdatePinState" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UpdatePinState__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152, nullptr, "UpdatePinState", nullptr, nullptr, 0, nullptr, 0, RF_Public|RF_Transient, (EFunctionFlags)0x04020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UpdatePinState__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UpdatePinState__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UpdatePinState__pf()
	{
		UObject* Outer = Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "UpdatePinState" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UpdatePinState__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UserConstructionScript__pf_Statics
	{
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UserConstructionScript__pf_Statics::Function_MetaDataParams[] = {
		{ "BlueprintInternalUseOnly", "true" },
		{ "Category", "" },
		{ "Comment", "/**t * Construction script, the place to spawn components and do other setup.t * @note Name used in CreateBlueprint functiont */" },
		{ "CppFromBpEvent", "" },
		{ "DisplayName", "Construction Script" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "UserConstructionScript" },
		{ "ToolTip", "Construction script, the place to spawn components and do other setup.@note Name used in CreateBlueprint function" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UserConstructionScript__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152, nullptr, "UserConstructionScript", nullptr, nullptr, 0, nullptr, 0, RF_Public|RF_Transient, (EFunctionFlags)0x04020C00, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UserConstructionScript__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UserConstructionScript__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UserConstructionScript__pf()
	{
		UObject* Outer = Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "UserConstructionScript" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UserConstructionScript__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	UClass* Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_NoRegister()
	{
		return AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass();
	}
	struct Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics
	{
		static UObject* (*const DependentSingletons[])();
		static const FClassFunctionLinkInfo FuncInfo[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Right__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Right__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Forward__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Forward__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Up__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Up__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__ValidRadiusVisualizer__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__ValidRadiusVisualizer__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AxisRoot__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__AxisRoot__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__VisualizerRoot__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__VisualizerRoot__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__TypeValue__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__TypeValue__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__TransErrValue__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__TransErrValue__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__RotErrValue__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__RotErrValue__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__ConfidenceValue__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__ConfidenceValue__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__TransErrLabel__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__TransErrLabel__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__RotErrLabel__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__RotErrLabel__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__ConfidenceLabel__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__ConfidenceLabel__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__PinIDValue__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__PinIDValue__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__InfoRoot__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__InfoRoot__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Root__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Root__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__RotationSmoothSpeed__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__RotationSmoothSpeed__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Orientation__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Orientation__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf_MetaData[];
#endif
		static void NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__CallFunc_K2_SetWorldLocation_SweepHitResult__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__CallFunc_K2_SetWorldLocation_SweepHitResult__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_Event_DeltaSeconds__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_b0l__K2Node_Event_DeltaSeconds__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__CallFunc_BreakRotator_Roll__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_b0l__CallFunc_BreakRotator_Roll__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__CallFunc_BreakRotator_Pitch__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_b0l__CallFunc_BreakRotator_Pitch__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__CallFunc_BreakRotator_Yaw__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_b0l__CallFunc_BreakRotator_Yaw__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__CallFunc_K2_SetWorldRotation_SweepHitResult__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__CallFunc_K2_SetWorldRotation_SweepHitResult__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__CallFunc_GetARPinState_State__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__CallFunc_GetARPinState_State__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_AMagicLeapARPinInfoActorBase,
	};
	const FClassFunctionLinkInfo Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::FuncInfo[] = {
		{ &Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__OnUpdateARPinState__pf, "OnUpdateARPinState" }, // 3524041658
		{ &Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__ReceiveTick__pf, "ReceiveTick" }, // 362993022
		{ &Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UpdatePinState__pf, "UpdatePinState" }, // 1095581317
		{ &Z_Construct_UFunction_AMagicLeapARPinInfoActor_C__pf2635949152_bpf__UserConstructionScript__pf, "UserConstructionScript" }, // 4181288878
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::Class_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "IncludePath", "MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "IsBlueprintBase", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "ObjectInitializerConstructorDeclared", "" },
		{ "OverrideNativeName", "MagicLeapARPinInfoActor_C" },
		{ "ReplaceConverted", "/MagicLeapPassableWorld/MagicLeapARPinInfoActor.MagicLeapARPinInfoActor_C" },
	};
#endif
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Right__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "Right" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Right__pf = { "Right", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__Right__pf), Z_Construct_UClass_UStaticMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Right__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Right__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Forward__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "Forward" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Forward__pf = { "Forward", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__Forward__pf), Z_Construct_UClass_UStaticMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Forward__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Forward__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Up__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "Up" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Up__pf = { "Up", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__Up__pf), Z_Construct_UClass_UStaticMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Up__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Up__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ValidRadiusVisualizer__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "ValidRadiusVisualizer" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ValidRadiusVisualizer__pf = { "ValidRadiusVisualizer", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__ValidRadiusVisualizer__pf), Z_Construct_UClass_USphereComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ValidRadiusVisualizer__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ValidRadiusVisualizer__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__AxisRoot__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "AxisRoot" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__AxisRoot__pf = { "AxisRoot", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__AxisRoot__pf), Z_Construct_UClass_USceneComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__AxisRoot__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__AxisRoot__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__VisualizerRoot__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "VisualizerRoot" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__VisualizerRoot__pf = { "VisualizerRoot", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__VisualizerRoot__pf), Z_Construct_UClass_USceneComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__VisualizerRoot__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__VisualizerRoot__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TypeValue__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "TypeValue" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TypeValue__pf = { "TypeValue", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__TypeValue__pf), Z_Construct_UClass_UTextRenderComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TypeValue__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TypeValue__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TransErrValue__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "TransErrValue" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TransErrValue__pf = { "TransErrValue", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__TransErrValue__pf), Z_Construct_UClass_UTextRenderComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TransErrValue__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TransErrValue__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotErrValue__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "RotErrValue" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotErrValue__pf = { "RotErrValue", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__RotErrValue__pf), Z_Construct_UClass_UTextRenderComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotErrValue__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotErrValue__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ConfidenceValue__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "ConfidenceValue" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ConfidenceValue__pf = { "ConfidenceValue", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__ConfidenceValue__pf), Z_Construct_UClass_UTextRenderComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ConfidenceValue__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ConfidenceValue__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TransErrLabel__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "TransErrLabel" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TransErrLabel__pf = { "TransErrLabel", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__TransErrLabel__pf), Z_Construct_UClass_UTextRenderComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TransErrLabel__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TransErrLabel__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotErrLabel__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "RotErrLabel" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotErrLabel__pf = { "RotErrLabel", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__RotErrLabel__pf), Z_Construct_UClass_UTextRenderComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotErrLabel__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotErrLabel__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ConfidenceLabel__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "ConfidenceLabel" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ConfidenceLabel__pf = { "ConfidenceLabel", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__ConfidenceLabel__pf), Z_Construct_UClass_UTextRenderComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ConfidenceLabel__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ConfidenceLabel__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__PinIDValue__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "PinIDValue" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__PinIDValue__pf = { "PinIDValue", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__PinIDValue__pf), Z_Construct_UClass_UTextRenderComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__PinIDValue__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__PinIDValue__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__InfoRoot__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "InfoRoot" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__InfoRoot__pf = { "InfoRoot", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__InfoRoot__pf), Z_Construct_UClass_USceneComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__InfoRoot__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__InfoRoot__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Root__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "Root" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Root__pf = { "Root", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__Root__pf), Z_Construct_UClass_USceneComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Root__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Root__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotationSmoothSpeed__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Rotation Smooth Speed" },
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "MultiLine", "true" },
		{ "OverrideNativeName", "RotationSmoothSpeed" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotationSmoothSpeed__pf = { "RotationSmoothSpeed", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, bpv__RotationSmoothSpeed__pf), METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotationSmoothSpeed__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotationSmoothSpeed__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "CallFunc_GetARPinPositionAndOrientation_Position" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf = { "CallFunc_GetARPinPositionAndOrientation_Position", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Orientation__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "CallFunc_GetARPinPositionAndOrientation_Orientation" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Orientation__pf = { "CallFunc_GetARPinPositionAndOrientation_Orientation", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, b0l__CallFunc_GetARPinPositionAndOrientation_Orientation__pf), Z_Construct_UScriptStruct_FRotator, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Orientation__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Orientation__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment" },
	};
#endif
	void Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf_SetBit(void* Obj)
	{
		((AMagicLeapARPinInfoActor_C__pf2635949152*)Obj)->b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf = { "CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(AMagicLeapARPinInfoActor_C__pf2635949152), &Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult__pf = { "CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult", nullptr, (EPropertyFlags)0x0010008000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, b0l__CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult__pf), Z_Construct_UScriptStruct_FHitResult, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldLocation_SweepHitResult__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "CallFunc_K2_SetWorldLocation_SweepHitResult" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldLocation_SweepHitResult__pf = { "CallFunc_K2_SetWorldLocation_SweepHitResult", nullptr, (EPropertyFlags)0x0010008000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, b0l__CallFunc_K2_SetWorldLocation_SweepHitResult__pf), Z_Construct_UScriptStruct_FHitResult, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldLocation_SweepHitResult__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldLocation_SweepHitResult__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__K2Node_Event_DeltaSeconds__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "K2Node_Event_DeltaSeconds" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__K2Node_Event_DeltaSeconds__pf = { "K2Node_Event_DeltaSeconds", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, b0l__K2Node_Event_DeltaSeconds__pf), METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__K2Node_Event_DeltaSeconds__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__K2Node_Event_DeltaSeconds__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Roll__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "CallFunc_BreakRotator_Roll" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Roll__pf = { "CallFunc_BreakRotator_Roll", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, b0l__CallFunc_BreakRotator_Roll__pf), METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Roll__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Roll__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Pitch__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "CallFunc_BreakRotator_Pitch" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Pitch__pf = { "CallFunc_BreakRotator_Pitch", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, b0l__CallFunc_BreakRotator_Pitch__pf), METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Pitch__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Pitch__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Yaw__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "CallFunc_BreakRotator_Yaw" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Yaw__pf = { "CallFunc_BreakRotator_Yaw", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, b0l__CallFunc_BreakRotator_Yaw__pf), METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Yaw__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Yaw__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldRotation_SweepHitResult__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "CallFunc_K2_SetWorldRotation_SweepHitResult" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldRotation_SweepHitResult__pf = { "CallFunc_K2_SetWorldRotation_SweepHitResult", nullptr, (EPropertyFlags)0x0010008000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, b0l__CallFunc_K2_SetWorldRotation_SweepHitResult__pf), Z_Construct_UScriptStruct_FHitResult, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldRotation_SweepHitResult__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldRotation_SweepHitResult__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinState_State__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/MagicLeapARPinInfoActor__pf2635949152.h" },
		{ "OverrideNativeName", "CallFunc_GetARPinState_State" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinState_State__pf = { "CallFunc_GetARPinState_State", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMagicLeapARPinInfoActor_C__pf2635949152, b0l__CallFunc_GetARPinState_State__pf), Z_Construct_UScriptStruct_FMagicLeapARPinState, METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinState_State__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinState_State__pf_MetaData)) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Right__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Forward__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Up__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ValidRadiusVisualizer__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__AxisRoot__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__VisualizerRoot__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TypeValue__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TransErrValue__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotErrValue__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ConfidenceValue__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__TransErrLabel__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotErrLabel__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__ConfidenceLabel__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__PinIDValue__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__InfoRoot__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__Root__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_bpv__RotationSmoothSpeed__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Position__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_Orientation__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinPositionAndOrientation_PinFoundInEnvironment__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldLocationAndRotation_SweepHitResult__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldLocation_SweepHitResult__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__K2Node_Event_DeltaSeconds__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Roll__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Pitch__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_BreakRotator_Yaw__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_K2_SetWorldRotation_SweepHitResult__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::NewProp_b0l__CallFunc_GetARPinState_State__pf,
	};
	const FCppClassTypeInfoStatic Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<AMagicLeapARPinInfoActor_C__pf2635949152>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::ClassParams = {
		&AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass,
		"Engine",
		&StaticCppClassTypeInfo,
		DependentSingletons,
		FuncInfo,
		Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::PropPointers,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		UE_ARRAY_COUNT(FuncInfo),
		UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::PropPointers),
		0,
		0x008000A4u,
		METADATA_PARAMS(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152()
	{
		UPackage* OuterPackage = FindOrConstructDynamicTypePackage(TEXT("/MagicLeapPassableWorld/MagicLeapARPinInfoActor"));
		UClass* OuterClass = Cast<UClass>(StaticFindObjectFast(UClass::StaticClass(), OuterPackage, TEXT("MagicLeapARPinInfoActor_C")));
		if (!OuterClass || !(OuterClass->ClassFlags & CLASS_Constructed))
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_DYNAMIC_CLASS(AMagicLeapARPinInfoActor_C__pf2635949152, TEXT("MagicLeapARPinInfoActor_C"), 560895878);
	template<> NATIVIZEDASSETS_API UClass* StaticClass<AMagicLeapARPinInfoActor_C__pf2635949152>()
	{
		return AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_AMagicLeapARPinInfoActor_C__pf2635949152(Z_Construct_UClass_AMagicLeapARPinInfoActor_C__pf2635949152, &AMagicLeapARPinInfoActor_C__pf2635949152::StaticClass, TEXT("/MagicLeapPassableWorld/MagicLeapARPinInfoActor"), TEXT("MagicLeapARPinInfoActor_C"), true, TEXT("/MagicLeapPassableWorld/MagicLeapARPinInfoActor"), TEXT("/MagicLeapPassableWorld/MagicLeapARPinInfoActor.MagicLeapARPinInfoActor_C"), nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(AMagicLeapARPinInfoActor_C__pf2635949152);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
