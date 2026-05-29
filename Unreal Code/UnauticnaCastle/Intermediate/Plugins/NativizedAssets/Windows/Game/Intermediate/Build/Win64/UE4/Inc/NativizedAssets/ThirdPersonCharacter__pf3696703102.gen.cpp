// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "NativizedAssets/Public/ThirdPersonCharacter__pf3696703102.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeThirdPersonCharacter__pf3696703102() {}
// Cross Module References
	NATIVIZEDASSETS_API UClass* Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_NoRegister();
	NATIVIZEDASSETS_API UClass* Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
	ENGINE_API UClass* Z_Construct_UClass_ACharacter();
	INPUTCORE_API UScriptStruct* Z_Construct_UScriptStruct_FKey();
	INPUTCORE_API UEnum* Z_Construct_UEnum_InputCore_ETouchIndex();
	COREUOBJECT_API UScriptStruct* Z_Construct_UScriptStruct_FVector();
	ENGINE_API UClass* Z_Construct_UClass_USkeletalMeshComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UAudioComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UStaticMeshComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UCameraComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_USpringArmComponent_NoRegister();
	COREUOBJECT_API UScriptStruct* Z_Construct_UScriptStruct_FTransform();
// End Cross Module References
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpTchEvt_Released__pf)
	{
		P_GET_PROPERTY(FByteProperty,Z_Param_bpp__FingerIndex__pf);
		P_GET_STRUCT(FVector,Z_Param_bpp__Location__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpTchEvt_Released__pf(ETouchIndex::Type(Z_Param_bpp__FingerIndex__pf),Z_Param_bpp__Location__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpTchEvt_Pressed__pf)
	{
		P_GET_PROPERTY(FByteProperty,Z_Param_bpp__FingerIndex__pf);
		P_GET_STRUCT(FVector,Z_Param_bpp__Location__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpTchEvt_Pressed__pf(ETouchIndex::Type(Z_Param_bpp__FingerIndex__pf),Z_Param_bpp__Location__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf)
	{
		P_GET_STRUCT(FKey,Z_Param_bpp__Key__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf(Z_Param_bpp__Key__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf)
	{
		P_GET_STRUCT(FKey,Z_Param_bpp__Key__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf(Z_Param_bpp__Key__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf)
	{
		P_GET_STRUCT(FKey,Z_Param_bpp__Key__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf(Z_Param_bpp__Key__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf)
	{
		P_GET_STRUCT(FKey,Z_Param_bpp__Key__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf(Z_Param_bpp__Key__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf)
	{
		P_GET_PROPERTY(FFloatProperty,Z_Param_bpp__AxisValue__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf(Z_Param_bpp__AxisValue__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf)
	{
		P_GET_PROPERTY(FFloatProperty,Z_Param_bpp__AxisValue__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf(Z_Param_bpp__AxisValue__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf)
	{
		P_GET_PROPERTY(FFloatProperty,Z_Param_bpp__AxisValue__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf(Z_Param_bpp__AxisValue__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf)
	{
		P_GET_PROPERTY(FFloatProperty,Z_Param_bpp__AxisValue__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf(Z_Param_bpp__AxisValue__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf)
	{
		P_GET_PROPERTY(FFloatProperty,Z_Param_bpp__AxisValue__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf(Z_Param_bpp__AxisValue__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf)
	{
		P_GET_PROPERTY(FFloatProperty,Z_Param_bpp__AxisValue__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf(Z_Param_bpp__AxisValue__pf);
		P_NATIVE_END;
	}
	void AThirdPersonCharacter_C__pf3696703102::StaticRegisterNativesAThirdPersonCharacter_C__pf3696703102()
	{
		UClass* Class = AThirdPersonCharacter_C__pf3696703102::StaticClass();
		static const FNameNativePtrPair Funcs[] = {
			{ "InpActEvt_Jump_K2Node_InputActionEvent_1", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf },
			{ "InpActEvt_Jump_K2Node_InputActionEvent_2", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf },
			{ "InpActEvt_M_K2Node_InputKeyEvent_0", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf },
			{ "InpActEvt_ResetVR_K2Node_InputActionEvent_0", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf },
			{ "InpAxisEvt_LookUp_K2Node_InputAxisEvent_40", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf },
			{ "InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf },
			{ "InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf },
			{ "InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf },
			{ "InpAxisEvt_Turn_K2Node_InputAxisEvent_47", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf },
			{ "InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf },
			{ "InpTchEvt_Pressed", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpTchEvt_Pressed__pf },
			{ "InpTchEvt_Released", &AThirdPersonCharacter_C__pf3696703102::execbpf__InpTchEvt_Released__pf },
		};
		FNativeFunctionRegistrar::RegisterFunctions(Class, Funcs, UE_ARRAY_COUNT(Funcs));
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Parms
		{
			FKey bpp__Key__pf;
		};
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpp__Key__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Statics::NewProp_bpp__Key__pf = { "bpp__Key__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Parms, bpp__Key__pf), Z_Construct_UScriptStruct_FKey, METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Statics::NewProp_bpp__Key__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpActEvt_Jump_K2Node_InputActionEvent_1" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpActEvt_Jump_K2Node_InputActionEvent_1", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpActEvt_Jump_K2Node_InputActionEvent_1" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Parms
		{
			FKey bpp__Key__pf;
		};
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpp__Key__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Statics::NewProp_bpp__Key__pf = { "bpp__Key__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Parms, bpp__Key__pf), Z_Construct_UScriptStruct_FKey, METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Statics::NewProp_bpp__Key__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpActEvt_Jump_K2Node_InputActionEvent_2" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpActEvt_Jump_K2Node_InputActionEvent_2", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpActEvt_Jump_K2Node_InputActionEvent_2" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Parms
		{
			FKey bpp__Key__pf;
		};
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpp__Key__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Statics::NewProp_bpp__Key__pf = { "bpp__Key__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Parms, bpp__Key__pf), Z_Construct_UScriptStruct_FKey, METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Statics::NewProp_bpp__Key__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpActEvt_M_K2Node_InputKeyEvent_0" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpActEvt_M_K2Node_InputKeyEvent_0", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpActEvt_M_K2Node_InputKeyEvent_0" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Parms
		{
			FKey bpp__Key__pf;
		};
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpp__Key__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Statics::NewProp_bpp__Key__pf = { "bpp__Key__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Parms, bpp__Key__pf), Z_Construct_UScriptStruct_FKey, METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Statics::NewProp_bpp__Key__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpActEvt_ResetVR_K2Node_InputActionEvent_0" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpActEvt_ResetVR_K2Node_InputActionEvent_0", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpActEvt_ResetVR_K2Node_InputActionEvent_0" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Parms
		{
			float bpp__AxisValue__pf;
		};
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpp__AxisValue__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Statics::NewProp_bpp__AxisValue__pf = { "bpp__AxisValue__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Parms, bpp__AxisValue__pf), METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Statics::NewProp_bpp__AxisValue__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpAxisEvt_LookUp_K2Node_InputAxisEvent_40" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpAxisEvt_LookUp_K2Node_InputAxisEvent_40", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpAxisEvt_LookUp_K2Node_InputAxisEvent_40" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Parms
		{
			float bpp__AxisValue__pf;
		};
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpp__AxisValue__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Statics::NewProp_bpp__AxisValue__pf = { "bpp__AxisValue__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Parms, bpp__AxisValue__pf), METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Statics::NewProp_bpp__AxisValue__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Parms
		{
			float bpp__AxisValue__pf;
		};
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpp__AxisValue__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Statics::NewProp_bpp__AxisValue__pf = { "bpp__AxisValue__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Parms, bpp__AxisValue__pf), METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Statics::NewProp_bpp__AxisValue__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Parms
		{
			float bpp__AxisValue__pf;
		};
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpp__AxisValue__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Statics::NewProp_bpp__AxisValue__pf = { "bpp__AxisValue__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Parms, bpp__AxisValue__pf), METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Statics::NewProp_bpp__AxisValue__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Parms
		{
			float bpp__AxisValue__pf;
		};
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpp__AxisValue__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Statics::NewProp_bpp__AxisValue__pf = { "bpp__AxisValue__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Parms, bpp__AxisValue__pf), METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Statics::NewProp_bpp__AxisValue__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpAxisEvt_Turn_K2Node_InputAxisEvent_47" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpAxisEvt_Turn_K2Node_InputAxisEvent_47", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpAxisEvt_Turn_K2Node_InputAxisEvent_47" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Parms
		{
			float bpp__AxisValue__pf;
		};
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpp__AxisValue__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Statics::NewProp_bpp__AxisValue__pf = { "bpp__AxisValue__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Parms, bpp__AxisValue__pf), METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Statics::NewProp_bpp__AxisValue__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpTchEvt_Pressed__pf_Parms
		{
			TEnumAsByte<ETouchIndex::Type> bpp__FingerIndex__pf;
			FVector bpp__Location__pf;
		};
		static const UE4CodeGen_Private::FBytePropertyParams NewProp_bpp__FingerIndex__pf;
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpp__Location__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FBytePropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::NewProp_bpp__FingerIndex__pf = { "bpp__FingerIndex__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Byte, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpTchEvt_Pressed__pf_Parms, bpp__FingerIndex__pf), Z_Construct_UEnum_InputCore_ETouchIndex, METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::NewProp_bpp__Location__pf = { "bpp__Location__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpTchEvt_Pressed__pf_Parms, bpp__Location__pf), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::NewProp_bpp__FingerIndex__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::NewProp_bpp__Location__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpTchEvt_Pressed" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpTchEvt_Pressed", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpTchEvt_Pressed__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00820400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpTchEvt_Pressed" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics
	{
		struct ThirdPersonCharacter_C__pf3696703102_eventbpf__InpTchEvt_Released__pf_Parms
		{
			TEnumAsByte<ETouchIndex::Type> bpp__FingerIndex__pf;
			FVector bpp__Location__pf;
		};
		static const UE4CodeGen_Private::FBytePropertyParams NewProp_bpp__FingerIndex__pf;
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpp__Location__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FBytePropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::NewProp_bpp__FingerIndex__pf = { "bpp__FingerIndex__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Byte, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpTchEvt_Released__pf_Parms, bpp__FingerIndex__pf), Z_Construct_UEnum_InputCore_ETouchIndex, METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::NewProp_bpp__Location__pf = { "bpp__Location__pf", nullptr, (EPropertyFlags)0x0010000000000080, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient, 1, STRUCT_OFFSET(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpTchEvt_Released__pf_Parms, bpp__Location__pf), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::NewProp_bpp__FingerIndex__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::NewProp_bpp__Location__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "InpTchEvt_Released" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, nullptr, "InpTchEvt_Released", nullptr, nullptr, sizeof(ThirdPersonCharacter_C__pf3696703102_eventbpf__InpTchEvt_Released__pf_Parms), Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x00820400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf()
	{
		UObject* Outer = Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "InpTchEvt_Released" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	UClass* Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_NoRegister()
	{
		return AThirdPersonCharacter_C__pf3696703102::StaticClass();
	}
	struct Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics
	{
		static UObject* (*const DependentSingletons[])();
		static const FClassFunctionLinkInfo FuncInfo[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__SkeletalMesh1__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__SkeletalMesh1__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__SkeletalMesh__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__SkeletalMesh__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Audio__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Audio__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__nravix_x_xxxxxxx__pfwiJjkihimikihiti_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__nravix_x_xxxxxxx__pfwiJjkihimikihiti;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__FollowCamera__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__FollowCamera__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__CameraBoom__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__CameraBoom__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__BaseTurnRate__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__BaseTurnRate__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__BaseLookUpRate__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__BaseLookUpRate__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__Temp_byte_Variable__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FBytePropertyParams NewProp_b0l__Temp_byte_Variable__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__Temp_struct_Variable__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__Temp_struct_Variable__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputActionEvent_Key_2__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__K2Node_InputActionEvent_Key_2__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputActionEvent_Key_1__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__K2Node_InputActionEvent_Key_1__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__Temp_struct_Variable_1__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__Temp_struct_Variable_1__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputActionEvent_Key__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__K2Node_InputActionEvent_Key__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputKeyEvent_Key__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__K2Node_InputKeyEvent_Key__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__Temp_struct_Variable_2__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__Temp_struct_Variable_2__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputAxisEvent_AxisValue_5__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_b0l__K2Node_InputAxisEvent_AxisValue_5__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputAxisEvent_AxisValue_4__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_b0l__K2Node_InputAxisEvent_AxisValue_4__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputAxisEvent_AxisValue_3__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_b0l__K2Node_InputAxisEvent_AxisValue_3__pf;
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
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputAxisEvent_AxisValue_2__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_b0l__K2Node_InputAxisEvent_AxisValue_2__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputTouchEvent_FingerIndex__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FBytePropertyParams NewProp_b0l__K2Node_InputTouchEvent_FingerIndex__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputTouchEvent_Location__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__K2Node_InputTouchEvent_Location__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputTouchEvent_FingerIndex_1__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FBytePropertyParams NewProp_b0l__K2Node_InputTouchEvent_FingerIndex_1__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputTouchEvent_Location_1__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_b0l__K2Node_InputTouchEvent_Location_1__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputAxisEvent_AxisValue_1__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_b0l__K2Node_InputAxisEvent_AxisValue_1__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_b0l__K2Node_InputAxisEvent_AxisValue__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_b0l__K2Node_InputAxisEvent_AxisValue__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_ACharacter,
	};
	const FClassFunctionLinkInfo Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::FuncInfo[] = {
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_1__pf, "InpActEvt_Jump_K2Node_InputActionEvent_1" }, // 472651850
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_Jump_K2Node_InputActionEvent_2__pf, "InpActEvt_Jump_K2Node_InputActionEvent_2" }, // 910125296
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_M_K2Node_InputKeyEvent_0__pf, "InpActEvt_M_K2Node_InputKeyEvent_0" }, // 1734334111
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpActEvt_ResetVR_K2Node_InputActionEvent_0__pf, "InpActEvt_ResetVR_K2Node_InputActionEvent_0" }, // 1806406467
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUp_K2Node_InputAxisEvent_40__pf, "InpAxisEvt_LookUp_K2Node_InputAxisEvent_40" }, // 36767664
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53__pf, "InpAxisEvt_LookUpRate_K2Node_InputAxisEvent_53" }, // 1025095051
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79__pf, "InpAxisEvt_MoveForward_K2Node_InputAxisEvent_79" }, // 1069454129
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90__pf, "InpAxisEvt_MoveRight_K2Node_InputAxisEvent_90" }, // 72273263
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_Turn_K2Node_InputAxisEvent_47__pf, "InpAxisEvt_Turn_K2Node_InputAxisEvent_47" }, // 3921314324
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38__pf, "InpAxisEvt_TurnRate_K2Node_InputAxisEvent_38" }, // 3927793932
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Pressed__pf, "InpTchEvt_Pressed" }, // 1816376175
		{ &Z_Construct_UFunction_AThirdPersonCharacter_C__pf3696703102_bpf__InpTchEvt_Released__pf, "InpTchEvt_Released" }, // 654319460
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::Class_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "HideCategories", "Navigation" },
		{ "IncludePath", "ThirdPersonCharacter__pf3696703102.h" },
		{ "IsBlueprintBase", "true" },
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "ObjectInitializerConstructorDeclared", "" },
		{ "OverrideNativeName", "ThirdPersonCharacter_C" },
		{ "ReplaceConverted", "/Game/res/ThirdPersonCharacter.ThirdPersonCharacter_C,/Game/ThirdPersonBP/Blueprints/ThirdPersonCharacter.ThirdPersonCharacter_C" },
	};
#endif
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__SkeletalMesh1__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "SkeletalMesh1" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__SkeletalMesh1__pf = { "SkeletalMesh1", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, bpv__SkeletalMesh1__pf), Z_Construct_UClass_USkeletalMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__SkeletalMesh1__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__SkeletalMesh1__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__SkeletalMesh__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "SkeletalMesh" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__SkeletalMesh__pf = { "SkeletalMesh", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, bpv__SkeletalMesh__pf), Z_Construct_UClass_USkeletalMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__SkeletalMesh__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__SkeletalMesh__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__Audio__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "Audio" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__Audio__pf = { "Audio", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, bpv__Audio__pf), Z_Construct_UClass_UAudioComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__Audio__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__Audio__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__nravix_x_xxxxxxx__pfwiJjkihimikihiti_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "nravix_\xd0\xb2_\xd0\x9a\xd0\xbe\xd1\x81\xd0\xbc\xd0\xbe\xd1\x81\xd0\xb5" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__nravix_x_xxxxxxx__pfwiJjkihimikihiti = { "nravix_\xd0\xb2_\xd0\x9a\xd0\xbe\xd1\x81\xd0\xbc\xd0\xbe\xd1\x81\xd0\xb5", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, bpv__nravix_x_xxxxxxx__pfwiJjkihimikihiti), Z_Construct_UClass_UStaticMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__nravix_x_xxxxxxx__pfwiJjkihimikihiti_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__nravix_x_xxxxxxx__pfwiJjkihimikihiti_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__FollowCamera__pf_MetaData[] = {
		{ "Category", "MyCharacter" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "FollowCamera" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__FollowCamera__pf = { "FollowCamera", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, bpv__FollowCamera__pf), Z_Construct_UClass_UCameraComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__FollowCamera__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__FollowCamera__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__CameraBoom__pf_MetaData[] = {
		{ "Category", "MyCharacter" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "CameraBoom" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__CameraBoom__pf = { "CameraBoom", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, bpv__CameraBoom__pf), Z_Construct_UClass_USpringArmComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__CameraBoom__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__CameraBoom__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__BaseTurnRate__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Base Turn Rate" },
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "BaseTurnRate" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__BaseTurnRate__pf = { "BaseTurnRate", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, bpv__BaseTurnRate__pf), METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__BaseTurnRate__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__BaseTurnRate__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__BaseLookUpRate__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Base Look Up Rate" },
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "BaseLookUpRate" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__BaseLookUpRate__pf = { "BaseLookUpRate", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, bpv__BaseLookUpRate__pf), METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__BaseLookUpRate__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__BaseLookUpRate__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_byte_Variable__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "Temp_byte_Variable" },
	};
#endif
	const UE4CodeGen_Private::FBytePropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_byte_Variable__pf = { "Temp_byte_Variable", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Byte, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__Temp_byte_Variable__pf), Z_Construct_UEnum_InputCore_ETouchIndex, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_byte_Variable__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_byte_Variable__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "Temp_struct_Variable" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable__pf = { "Temp_struct_Variable", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__Temp_struct_Variable__pf), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key_2__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputActionEvent_Key_2" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key_2__pf = { "K2Node_InputActionEvent_Key_2", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputActionEvent_Key_2__pf), Z_Construct_UScriptStruct_FKey, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key_2__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key_2__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key_1__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputActionEvent_Key_1" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key_1__pf = { "K2Node_InputActionEvent_Key_1", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputActionEvent_Key_1__pf), Z_Construct_UScriptStruct_FKey, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key_1__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key_1__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable_1__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "Temp_struct_Variable_1" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable_1__pf = { "Temp_struct_Variable_1", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__Temp_struct_Variable_1__pf), Z_Construct_UScriptStruct_FKey, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable_1__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable_1__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputActionEvent_Key" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key__pf = { "K2Node_InputActionEvent_Key", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputActionEvent_Key__pf), Z_Construct_UScriptStruct_FKey, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputKeyEvent_Key__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputKeyEvent_Key" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputKeyEvent_Key__pf = { "K2Node_InputKeyEvent_Key", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputKeyEvent_Key__pf), Z_Construct_UScriptStruct_FKey, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputKeyEvent_Key__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputKeyEvent_Key__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable_2__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "Temp_struct_Variable_2" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable_2__pf = { "Temp_struct_Variable_2", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__Temp_struct_Variable_2__pf), Z_Construct_UScriptStruct_FTransform, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable_2__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable_2__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_5__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputAxisEvent_AxisValue_5" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_5__pf = { "K2Node_InputAxisEvent_AxisValue_5", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputAxisEvent_AxisValue_5__pf), METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_5__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_5__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_4__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputAxisEvent_AxisValue_4" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_4__pf = { "K2Node_InputAxisEvent_AxisValue_4", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputAxisEvent_AxisValue_4__pf), METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_4__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_4__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_3__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputAxisEvent_AxisValue_3" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_3__pf = { "K2Node_InputAxisEvent_AxisValue_3", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputAxisEvent_AxisValue_3__pf), METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_3__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_3__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Roll__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "CallFunc_BreakRotator_Roll" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Roll__pf = { "CallFunc_BreakRotator_Roll", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__CallFunc_BreakRotator_Roll__pf), METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Roll__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Roll__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Pitch__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "CallFunc_BreakRotator_Pitch" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Pitch__pf = { "CallFunc_BreakRotator_Pitch", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__CallFunc_BreakRotator_Pitch__pf), METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Pitch__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Pitch__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Yaw__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "CallFunc_BreakRotator_Yaw" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Yaw__pf = { "CallFunc_BreakRotator_Yaw", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__CallFunc_BreakRotator_Yaw__pf), METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Yaw__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Yaw__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_2__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputAxisEvent_AxisValue_2" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_2__pf = { "K2Node_InputAxisEvent_AxisValue_2", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputAxisEvent_AxisValue_2__pf), METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_2__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_2__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_FingerIndex__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputTouchEvent_FingerIndex" },
	};
#endif
	const UE4CodeGen_Private::FBytePropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_FingerIndex__pf = { "K2Node_InputTouchEvent_FingerIndex", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Byte, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputTouchEvent_FingerIndex__pf), Z_Construct_UEnum_InputCore_ETouchIndex, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_FingerIndex__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_FingerIndex__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_Location__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputTouchEvent_Location" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_Location__pf = { "K2Node_InputTouchEvent_Location", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputTouchEvent_Location__pf), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_Location__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_Location__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_FingerIndex_1__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputTouchEvent_FingerIndex_1" },
	};
#endif
	const UE4CodeGen_Private::FBytePropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_FingerIndex_1__pf = { "K2Node_InputTouchEvent_FingerIndex_1", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Byte, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputTouchEvent_FingerIndex_1__pf), Z_Construct_UEnum_InputCore_ETouchIndex, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_FingerIndex_1__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_FingerIndex_1__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_Location_1__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputTouchEvent_Location_1" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_Location_1__pf = { "K2Node_InputTouchEvent_Location_1", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputTouchEvent_Location_1__pf), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_Location_1__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_Location_1__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_1__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputAxisEvent_AxisValue_1" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_1__pf = { "K2Node_InputAxisEvent_AxisValue_1", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputAxisEvent_AxisValue_1__pf), METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_1__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_1__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue__pf_MetaData[] = {
		{ "ModuleRelativePath", "Public/ThirdPersonCharacter__pf3696703102.h" },
		{ "OverrideNativeName", "K2Node_InputAxisEvent_AxisValue" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue__pf = { "K2Node_InputAxisEvent_AxisValue", nullptr, (EPropertyFlags)0x0010000000202000, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AThirdPersonCharacter_C__pf3696703102, b0l__K2Node_InputAxisEvent_AxisValue__pf), METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue__pf_MetaData)) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__SkeletalMesh1__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__SkeletalMesh__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__Audio__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__nravix_x_xxxxxxx__pfwiJjkihimikihiti,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__FollowCamera__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__CameraBoom__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__BaseTurnRate__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_bpv__BaseLookUpRate__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_byte_Variable__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key_2__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key_1__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable_1__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputActionEvent_Key__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputKeyEvent_Key__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__Temp_struct_Variable_2__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_5__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_4__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_3__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Roll__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Pitch__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__CallFunc_BreakRotator_Yaw__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_2__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_FingerIndex__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_Location__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_FingerIndex_1__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputTouchEvent_Location_1__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue_1__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::NewProp_b0l__K2Node_InputAxisEvent_AxisValue__pf,
	};
	const FCppClassTypeInfoStatic Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<AThirdPersonCharacter_C__pf3696703102>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::ClassParams = {
		&AThirdPersonCharacter_C__pf3696703102::StaticClass,
		"Game",
		&StaticCppClassTypeInfo,
		DependentSingletons,
		FuncInfo,
		Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::PropPointers,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		UE_ARRAY_COUNT(FuncInfo),
		UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::PropPointers),
		0,
		0x008000A4u,
		METADATA_PARAMS(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102()
	{
		UPackage* OuterPackage = FindOrConstructDynamicTypePackage(TEXT("/Game/res/ThirdPersonCharacter"));
		UClass* OuterClass = Cast<UClass>(StaticFindObjectFast(UClass::StaticClass(), OuterPackage, TEXT("ThirdPersonCharacter_C")));
		if (!OuterClass || !(OuterClass->ClassFlags & CLASS_Constructed))
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_DYNAMIC_CLASS(AThirdPersonCharacter_C__pf3696703102, TEXT("ThirdPersonCharacter_C"), 1378734327);
	template<> NATIVIZEDASSETS_API UClass* StaticClass<AThirdPersonCharacter_C__pf3696703102>()
	{
		return AThirdPersonCharacter_C__pf3696703102::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_AThirdPersonCharacter_C__pf3696703102(Z_Construct_UClass_AThirdPersonCharacter_C__pf3696703102, &AThirdPersonCharacter_C__pf3696703102::StaticClass, TEXT("/Game/res/ThirdPersonCharacter"), TEXT("ThirdPersonCharacter_C"), true, TEXT("/Game/res/ThirdPersonCharacter"), TEXT("/Game/res/ThirdPersonCharacter.ThirdPersonCharacter_C"), nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(AThirdPersonCharacter_C__pf3696703102);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
