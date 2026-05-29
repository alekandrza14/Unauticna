// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "NativizedAssets/Public/BP_LightStudio__pf1079297466.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeBP_LightStudio__pf1079297466() {}
// Cross Module References
	NATIVIZEDASSETS_API UClass* Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_NoRegister();
	NATIVIZEDASSETS_API UClass* Z_Construct_UClass_ABP_LightStudio_C__pf1079297466();
	ENGINE_API UClass* Z_Construct_UClass_AActor();
	ENGINE_API UClass* Z_Construct_UClass_USkyLightComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UExponentialHeightFogComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UStaticMeshComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_USceneComponent_NoRegister();
	COREUOBJECT_API UScriptStruct* Z_Construct_UScriptStruct_FLinearColor();
	ENGINE_API UClass* Z_Construct_UClass_UDirectionalLightComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UMaterialInstanceDynamic_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UCurveLinearColor_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UCurveFloat_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UTexture_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UAtmosphericFogComponent_NoRegister();
	COREUOBJECT_API UScriptStruct* Z_Construct_UScriptStruct_FColor();
	ENGINE_API UClass* Z_Construct_UClass_UMaterialInterface_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UMaterialInstance_NoRegister();
// End Cross Module References
	DEFINE_FUNCTION(ABP_LightStudio_C__pf1079297466::execbpf__AtmosphereDensity__pf)
	{
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__AtmosphereDensity__pf();
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(ABP_LightStudio_C__pf1079297466::execbpf__NormalizedSunAngle__pf)
	{
		P_GET_PROPERTY_REF(FFloatProperty,Z_Param_Out_bpp__Angle__pf);
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__NormalizedSunAngle__pf(Z_Param_Out_bpp__Angle__pf);
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(ABP_LightStudio_C__pf1079297466::execbpf__SunMobility__pf)
	{
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__SunMobility__pf();
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(ABP_LightStudio_C__pf1079297466::execbpf__CalculateSunColor__pf)
	{
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__CalculateSunColor__pf();
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(ABP_LightStudio_C__pf1079297466::execbpf__UserConstructionScript__pf)
	{
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__UserConstructionScript__pf();
		P_NATIVE_END;
	}
	static FName NAME_ABP_LightStudio_C__pf1079297466_bpf__UserConstructionScript__pf = FName(TEXT("UserConstructionScript"));
	void ABP_LightStudio_C__pf1079297466::eventbpf__UserConstructionScript__pf()
	{
		ProcessEvent(FindFunctionChecked(NAME_ABP_LightStudio_C__pf1079297466_bpf__UserConstructionScript__pf),NULL);
	}
	void ABP_LightStudio_C__pf1079297466::StaticRegisterNativesABP_LightStudio_C__pf1079297466()
	{
		UClass* Class = ABP_LightStudio_C__pf1079297466::StaticClass();
		static const FNameNativePtrPair Funcs[] = {
			{ "AtmosphereDensity", &ABP_LightStudio_C__pf1079297466::execbpf__AtmosphereDensity__pf },
			{ "CalculateSunColor", &ABP_LightStudio_C__pf1079297466::execbpf__CalculateSunColor__pf },
			{ "NormalizedSunAngle", &ABP_LightStudio_C__pf1079297466::execbpf__NormalizedSunAngle__pf },
			{ "SunMobility", &ABP_LightStudio_C__pf1079297466::execbpf__SunMobility__pf },
			{ "UserConstructionScript", &ABP_LightStudio_C__pf1079297466::execbpf__UserConstructionScript__pf },
		};
		FNativeFunctionRegistrar::RegisterFunctions(Class, Funcs, UE_ARRAY_COUNT(Funcs));
	}
	struct Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__AtmosphereDensity__pf_Statics
	{
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__AtmosphereDensity__pf_Statics::Function_MetaDataParams[] = {
		{ "Category", "" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereDensity" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__AtmosphereDensity__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_ABP_LightStudio_C__pf1079297466, nullptr, "AtmosphereDensity", nullptr, nullptr, 0, nullptr, 0, RF_Public|RF_Transient, (EFunctionFlags)0x04020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__AtmosphereDensity__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__AtmosphereDensity__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__AtmosphereDensity__pf()
	{
		UObject* Outer = Z_Construct_UClass_ABP_LightStudio_C__pf1079297466();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "AtmosphereDensity" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__AtmosphereDensity__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__CalculateSunColor__pf_Statics
	{
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__CalculateSunColor__pf_Statics::Function_MetaDataParams[] = {
		{ "Category", "" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "CalculateSunColor" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__CalculateSunColor__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_ABP_LightStudio_C__pf1079297466, nullptr, "CalculateSunColor", nullptr, nullptr, 0, nullptr, 0, RF_Public|RF_Transient, (EFunctionFlags)0x04020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__CalculateSunColor__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__CalculateSunColor__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__CalculateSunColor__pf()
	{
		UObject* Outer = Z_Construct_UClass_ABP_LightStudio_C__pf1079297466();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "CalculateSunColor" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__CalculateSunColor__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf_Statics
	{
		struct BP_LightStudio_C__pf1079297466_eventbpf__NormalizedSunAngle__pf_Parms
		{
			float bpp__Angle__pf;
		};
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpp__Angle__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf_Statics::NewProp_bpp__Angle__pf = { "bpp__Angle__pf", nullptr, (EPropertyFlags)0x0010000000000180, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient, 1, STRUCT_OFFSET(BP_LightStudio_C__pf1079297466_eventbpf__NormalizedSunAngle__pf_Parms, bpp__Angle__pf), METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf_Statics::NewProp_bpp__Angle__pf,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf_Statics::Function_MetaDataParams[] = {
		{ "Category", "" },
		{ "Comment", "/*out*/" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "NormalizedSunAngle" },
		{ "ToolTip", "out" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_ABP_LightStudio_C__pf1079297466, nullptr, "NormalizedSunAngle", nullptr, nullptr, sizeof(BP_LightStudio_C__pf1079297466_eventbpf__NormalizedSunAngle__pf_Parms), Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf_Statics::PropPointers, UE_ARRAY_COUNT(Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf_Statics::PropPointers), RF_Public|RF_Transient, (EFunctionFlags)0x14420400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf()
	{
		UObject* Outer = Z_Construct_UClass_ABP_LightStudio_C__pf1079297466();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "NormalizedSunAngle" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__SunMobility__pf_Statics
	{
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__SunMobility__pf_Statics::Function_MetaDataParams[] = {
		{ "Category", "" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "SunMobility" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__SunMobility__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_ABP_LightStudio_C__pf1079297466, nullptr, "SunMobility", nullptr, nullptr, 0, nullptr, 0, RF_Public|RF_Transient, (EFunctionFlags)0x04020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__SunMobility__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__SunMobility__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__SunMobility__pf()
	{
		UObject* Outer = Z_Construct_UClass_ABP_LightStudio_C__pf1079297466();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "SunMobility" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__SunMobility__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__UserConstructionScript__pf_Statics
	{
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__UserConstructionScript__pf_Statics::Function_MetaDataParams[] = {
		{ "BlueprintInternalUseOnly", "true" },
		{ "Category", "" },
		{ "Comment", "/**t * Construction script, the place to spawn components and do other setup.t * @note Name used in CreateBlueprint functiont */" },
		{ "CppFromBpEvent", "" },
		{ "DisplayName", "Construction Script" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "UserConstructionScript" },
		{ "ToolTip", "Construction script, the place to spawn components and do other setup.@note Name used in CreateBlueprint function" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__UserConstructionScript__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_ABP_LightStudio_C__pf1079297466, nullptr, "UserConstructionScript", nullptr, nullptr, 0, nullptr, 0, RF_Public|RF_Transient, (EFunctionFlags)0x04020C00, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__UserConstructionScript__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__UserConstructionScript__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__UserConstructionScript__pf()
	{
		UObject* Outer = Z_Construct_UClass_ABP_LightStudio_C__pf1079297466();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "UserConstructionScript" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__UserConstructionScript__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	UClass* Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_NoRegister()
	{
		return ABP_LightStudio_C__pf1079297466::StaticClass();
	}
	struct Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics
	{
		static UObject* (*const DependentSingletons[])();
		static const FClassFunctionLinkInfo FuncInfo[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__SkyLight1__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__SkyLight1__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__ExponentialHeightFog1__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__ExponentialHeightFog1__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__PrevisArrow__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__PrevisArrow__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Skybox__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Skybox__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Scene1__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Scene1__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__GlobalBrightness__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__GlobalBrightness__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Use_HDRI__pf_MetaData[];
#endif
		static void NewProp_bpv__Use_HDRI__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__Use_HDRI__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__UseSunLight__pf_MetaData[];
#endif
		static void NewProp_bpv__UseSunLight__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__UseSunLight__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__SunBrightness__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__SunBrightness__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__SunTint__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpv__SunTint__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__StationaryLightForSun__pf_MetaData[];
#endif
		static void NewProp_bpv__StationaryLightForSun__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__StationaryLightForSun__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__SunDirectionalLight__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__SunDirectionalLight__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__UseAtmosphere__pf_MetaData[];
#endif
		static void NewProp_bpv__UseAtmosphere__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__UseAtmosphere__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphereBrightness__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__AtmosphereBrightness__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphereTint__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpv__AtmosphereTint__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__PrevisArrowMaterial__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__PrevisArrowMaterial__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__LightColor__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpv__LightColor__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__SunColorCurve__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__SunColorCurve__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__OverrideSunColor__pf_MetaData[];
#endif
		static void NewProp_bpv__OverrideSunColor__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__OverrideSunColor__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphereDensityMultiplier__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__AtmosphereDensityMultiplier__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphereAltitude__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__AtmosphereAltitude__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__DisableSunDisk__pf_MetaData[];
#endif
		static void NewProp_bpv__DisableSunDisk__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__DisableSunDisk__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__UseFog__pf_MetaData[];
#endif
		static void NewProp_bpv__UseFog__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__UseFog__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__FogBrightness__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__FogBrightness__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__FogTint__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpv__FogTint__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__FogAltitude__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__FogAltitude__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__FogMaxOpacity__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__FogMaxOpacity__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__FogHeightFalloff__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__FogHeightFalloff__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__FogDensity__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__FogDensity__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__FogBrightnessCurve__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__FogBrightnessCurve__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__FogStartDistance__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__FogStartDistance__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__DisableGroundScattering__pf_MetaData[];
#endif
		static void NewProp_bpv__DisableGroundScattering__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__DisableGroundScattering__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphereDistanceScale__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__AtmosphereDistanceScale__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__SkyboxMaterial__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__SkyboxMaterial__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__HDRI_Brightness__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__HDRI_Brightness__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__HDRI_Contrast__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__HDRI_Contrast__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__HDRI_Tint__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpv__HDRI_Tint__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__HDRI_Cubemap__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__HDRI_Cubemap__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__HDRI_Rotation__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__HDRI_Rotation__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphereOpacityHorizon__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__AtmosphereOpacityHorizon__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphereOpacityZenith__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__AtmosphereOpacityZenith__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__HighDensityAtmosphere__pf_MetaData[];
#endif
		static void NewProp_bpv__HighDensityAtmosphere__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__HighDensityAtmosphere__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphericFog__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__AtmosphericFog__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__UseSkylight__pf_MetaData[];
#endif
		static void NewProp_bpv__UseSkylight__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__UseSkylight__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Shadowdistance__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__Shadowdistance__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__LightShaftBloom__pf_MetaData[];
#endif
		static void NewProp_bpv__LightShaftBloom__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__LightShaftBloom__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__LightShaftOcclusion__pf_MetaData[];
#endif
		static void NewProp_bpv__LightShaftOcclusion__pf_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__LightShaftOcclusion__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__OcclusionMaskDarkness__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__OcclusionMaskDarkness__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__BloomScale__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__BloomScale__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__BloomThreshold__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__BloomThreshold__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__BloomTint__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpv__BloomTint__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphereFogMultiplier__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__AtmosphereFogMultiplier__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphereDensityHeight__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__AtmosphereDensityHeight__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphereMaxScatteringOrder__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FIntPropertyParams NewProp_bpv__AtmosphereMaxScatteringOrder__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__AtmosphereAltitudeSampleNumber__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FIntPropertyParams NewProp_bpv__AtmosphereAltitudeSampleNumber__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__LightFunctionMaterial__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__LightFunctionMaterial__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__MIC_Black__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__MIC_Black__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__MIC_HDRI__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__MIC_HDRI__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_AActor,
	};
	const FClassFunctionLinkInfo Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::FuncInfo[] = {
		{ &Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__AtmosphereDensity__pf, "AtmosphereDensity" }, // 2781119823
		{ &Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__CalculateSunColor__pf, "CalculateSunColor" }, // 2619079974
		{ &Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__NormalizedSunAngle__pf, "NormalizedSunAngle" }, // 3233745202
		{ &Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__SunMobility__pf, "SunMobility" }, // 2364556878
		{ &Z_Construct_UFunction_ABP_LightStudio_C__pf1079297466_bpf__UserConstructionScript__pf, "UserConstructionScript" }, // 3952235419
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::Class_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "IncludePath", "BP_LightStudio__pf1079297466.h" },
		{ "IsBlueprintBase", "true" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "ObjectInitializerConstructorDeclared", "" },
		{ "OverrideNativeName", "BP_LightStudio_C" },
		{ "ReplaceConverted", "/Game/StarterContent/Blueprints/BP_LightStudio.BP_LightStudio_C" },
	};
#endif
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SkyLight1__pf_MetaData[] = {
		{ "Category", "BP_DayLight" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "SkyLight1" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SkyLight1__pf = { "SkyLight1", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__SkyLight1__pf), Z_Construct_UClass_USkyLightComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SkyLight1__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SkyLight1__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__ExponentialHeightFog1__pf_MetaData[] = {
		{ "Category", "BP_DayLight" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "ExponentialHeightFog1" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__ExponentialHeightFog1__pf = { "ExponentialHeightFog1", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__ExponentialHeightFog1__pf), Z_Construct_UClass_UExponentialHeightFogComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__ExponentialHeightFog1__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__ExponentialHeightFog1__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__PrevisArrow__pf_MetaData[] = {
		{ "Category", "BP_DayLight" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "PrevisArrow" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__PrevisArrow__pf = { "PrevisArrow", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__PrevisArrow__pf), Z_Construct_UClass_UStaticMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__PrevisArrow__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__PrevisArrow__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Skybox__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "Skybox" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Skybox__pf = { "Skybox", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__Skybox__pf), Z_Construct_UClass_UStaticMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Skybox__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Skybox__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Scene1__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "Scene1" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Scene1__pf = { "Scene1", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__Scene1__pf), Z_Construct_UClass_USceneComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Scene1__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Scene1__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__GlobalBrightness__pf_MetaData[] = {
		{ "Category", "Global" },
		{ "DisplayName", "Global Brightness" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "GlobalBrightness" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__GlobalBrightness__pf = { "GlobalBrightness", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__GlobalBrightness__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__GlobalBrightness__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__GlobalBrightness__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Use_HDRI__pf_MetaData[] = {
		{ "Category", "HDRI" },
		{ "DisplayName", "Use HDRI" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "Use_HDRI" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Use_HDRI__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__Use_HDRI__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Use_HDRI__pf = { "Use_HDRI", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Use_HDRI__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Use_HDRI__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Use_HDRI__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSunLight__pf_MetaData[] = {
		{ "Category", "Sun" },
		{ "DisplayName", "Use Sun Light" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "UseSunLight" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSunLight__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__UseSunLight__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSunLight__pf = { "UseSunLight", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSunLight__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSunLight__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSunLight__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunBrightness__pf_MetaData[] = {
		{ "Category", "Sun" },
		{ "DisplayName", "Sun Brightness" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "SunBrightness" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunBrightness__pf = { "SunBrightness", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__SunBrightness__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunBrightness__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunBrightness__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunTint__pf_MetaData[] = {
		{ "Category", "Sun" },
		{ "DisplayName", "Sun Tint" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "SunTint" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunTint__pf = { "SunTint", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__SunTint__pf), Z_Construct_UScriptStruct_FLinearColor, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunTint__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunTint__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__StationaryLightForSun__pf_MetaData[] = {
		{ "Category", "Sun" },
		{ "DisplayName", "Stationary Light for Sun" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "StationaryLightForSun" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__StationaryLightForSun__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__StationaryLightForSun__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__StationaryLightForSun__pf = { "StationaryLightForSun", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__StationaryLightForSun__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__StationaryLightForSun__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__StationaryLightForSun__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunDirectionalLight__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Sun Directional Light" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "SunDirectionalLight" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunDirectionalLight__pf = { "SunDirectionalLight", nullptr, (EPropertyFlags)0x001000000009000d, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__SunDirectionalLight__pf), Z_Construct_UClass_UDirectionalLightComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunDirectionalLight__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunDirectionalLight__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseAtmosphere__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "Use Atmosphere" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "UseAtmosphere" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseAtmosphere__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__UseAtmosphere__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseAtmosphere__pf = { "UseAtmosphere", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseAtmosphere__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseAtmosphere__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseAtmosphere__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereBrightness__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "Atmosphere Brightness" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereBrightness" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereBrightness__pf = { "AtmosphereBrightness", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphereBrightness__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereBrightness__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereBrightness__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereTint__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "Atmosphere Tint" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereTint" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereTint__pf = { "AtmosphereTint", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphereTint__pf), Z_Construct_UScriptStruct_FLinearColor, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereTint__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereTint__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__PrevisArrowMaterial__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Previs Arrow Material" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "PrevisArrowMaterial" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__PrevisArrowMaterial__pf = { "PrevisArrowMaterial", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__PrevisArrowMaterial__pf), Z_Construct_UClass_UMaterialInstanceDynamic_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__PrevisArrowMaterial__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__PrevisArrowMaterial__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightColor__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Light Color" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "LightColor" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightColor__pf = { "LightColor", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__LightColor__pf), Z_Construct_UScriptStruct_FLinearColor, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightColor__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightColor__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunColorCurve__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Sun Color Curve" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "SunColorCurve" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunColorCurve__pf = { "SunColorCurve", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__SunColorCurve__pf), Z_Construct_UClass_UCurveLinearColor_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunColorCurve__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunColorCurve__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OverrideSunColor__pf_MetaData[] = {
		{ "Category", "Sun" },
		{ "DisplayName", "Override Sun Color" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "OverrideSunColor" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OverrideSunColor__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__OverrideSunColor__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OverrideSunColor__pf = { "OverrideSunColor", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OverrideSunColor__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OverrideSunColor__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OverrideSunColor__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDensityMultiplier__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "Atmosphere Density Multiplier" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereDensityMultiplier" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDensityMultiplier__pf = { "AtmosphereDensityMultiplier", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphereDensityMultiplier__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDensityMultiplier__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDensityMultiplier__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereAltitude__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "Atmosphere Altitude" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereAltitude" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereAltitude__pf = { "AtmosphereAltitude", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphereAltitude__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereAltitude__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereAltitude__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableSunDisk__pf_MetaData[] = {
		{ "Category", "Sun" },
		{ "DisplayName", "Disable Sun Disk" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "DisableSunDisk" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableSunDisk__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__DisableSunDisk__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableSunDisk__pf = { "DisableSunDisk", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableSunDisk__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableSunDisk__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableSunDisk__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseFog__pf_MetaData[] = {
		{ "Category", "Fog" },
		{ "DisplayName", "Use Fog" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "UseFog" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseFog__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__UseFog__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseFog__pf = { "UseFog", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseFog__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseFog__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseFog__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogBrightness__pf_MetaData[] = {
		{ "Category", "Fog" },
		{ "DisplayName", "Fog Brightness" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "FogBrightness" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogBrightness__pf = { "FogBrightness", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__FogBrightness__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogBrightness__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogBrightness__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogTint__pf_MetaData[] = {
		{ "Category", "Fog" },
		{ "DisplayName", "Fog Tint" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "FogTint" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogTint__pf = { "FogTint", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__FogTint__pf), Z_Construct_UScriptStruct_FLinearColor, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogTint__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogTint__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogAltitude__pf_MetaData[] = {
		{ "Category", "Fog" },
		{ "DisplayName", "Fog Altitude" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "FogAltitude" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogAltitude__pf = { "FogAltitude", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__FogAltitude__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogAltitude__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogAltitude__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogMaxOpacity__pf_MetaData[] = {
		{ "Category", "Fog" },
		{ "DisplayName", "Fog Max Opacity" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "FogMaxOpacity" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogMaxOpacity__pf = { "FogMaxOpacity", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__FogMaxOpacity__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogMaxOpacity__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogMaxOpacity__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogHeightFalloff__pf_MetaData[] = {
		{ "Category", "Fog" },
		{ "DisplayName", "Fog Height Falloff" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "FogHeightFalloff" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogHeightFalloff__pf = { "FogHeightFalloff", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__FogHeightFalloff__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogHeightFalloff__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogHeightFalloff__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogDensity__pf_MetaData[] = {
		{ "Category", "Fog" },
		{ "DisplayName", "Fog Density" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "FogDensity" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogDensity__pf = { "FogDensity", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__FogDensity__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogDensity__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogDensity__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogBrightnessCurve__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Fog Brightness Curve" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "FogBrightnessCurve" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogBrightnessCurve__pf = { "FogBrightnessCurve", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__FogBrightnessCurve__pf), Z_Construct_UClass_UCurveFloat_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogBrightnessCurve__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogBrightnessCurve__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogStartDistance__pf_MetaData[] = {
		{ "Category", "Fog" },
		{ "DisplayName", "Fog Start Distance" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "FogStartDistance" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogStartDistance__pf = { "FogStartDistance", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__FogStartDistance__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogStartDistance__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogStartDistance__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableGroundScattering__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "Disable Ground Scattering" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "DisableGroundScattering" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableGroundScattering__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__DisableGroundScattering__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableGroundScattering__pf = { "DisableGroundScattering", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableGroundScattering__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableGroundScattering__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableGroundScattering__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDistanceScale__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "Atmosphere Distance Scale" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereDistanceScale" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDistanceScale__pf = { "AtmosphereDistanceScale", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphereDistanceScale__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDistanceScale__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDistanceScale__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SkyboxMaterial__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Skybox Material" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "SkyboxMaterial" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SkyboxMaterial__pf = { "SkyboxMaterial", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__SkyboxMaterial__pf), Z_Construct_UClass_UMaterialInstanceDynamic_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SkyboxMaterial__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SkyboxMaterial__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Brightness__pf_MetaData[] = {
		{ "Category", "HDRI" },
		{ "DisplayName", "HDRI Brightness" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "HDRI_Brightness" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Brightness__pf = { "HDRI_Brightness", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__HDRI_Brightness__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Brightness__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Brightness__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Contrast__pf_MetaData[] = {
		{ "Category", "HDRI" },
		{ "DisplayName", "HDRI Contrast" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "HDRI_Contrast" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Contrast__pf = { "HDRI_Contrast", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__HDRI_Contrast__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Contrast__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Contrast__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Tint__pf_MetaData[] = {
		{ "Category", "HDRI" },
		{ "DisplayName", "HDRI Tint" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "HDRI_Tint" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Tint__pf = { "HDRI_Tint", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__HDRI_Tint__pf), Z_Construct_UScriptStruct_FLinearColor, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Tint__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Tint__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Cubemap__pf_MetaData[] = {
		{ "Category", "HDRI" },
		{ "DisplayName", "HDRI Cubemap" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "HDRI_Cubemap" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Cubemap__pf = { "HDRI_Cubemap", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__HDRI_Cubemap__pf), Z_Construct_UClass_UTexture_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Cubemap__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Cubemap__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Rotation__pf_MetaData[] = {
		{ "Category", "HDRI" },
		{ "DisplayName", "HDRI Rotation" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "HDRI_Rotation" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Rotation__pf = { "HDRI_Rotation", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__HDRI_Rotation__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Rotation__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Rotation__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereOpacityHorizon__pf_MetaData[] = {
		{ "Category", "HDRI" },
		{ "DisplayName", "Atmosphere Opacity Horizon" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereOpacityHorizon" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereOpacityHorizon__pf = { "AtmosphereOpacityHorizon", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphereOpacityHorizon__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereOpacityHorizon__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereOpacityHorizon__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereOpacityZenith__pf_MetaData[] = {
		{ "Category", "HDRI" },
		{ "DisplayName", "Atmosphere Opacity Zenith" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereOpacityZenith" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereOpacityZenith__pf = { "AtmosphereOpacityZenith", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphereOpacityZenith__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereOpacityZenith__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereOpacityZenith__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HighDensityAtmosphere__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "High Density Atmosphere" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "HighDensityAtmosphere" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HighDensityAtmosphere__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__HighDensityAtmosphere__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HighDensityAtmosphere__pf = { "HighDensityAtmosphere", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HighDensityAtmosphere__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HighDensityAtmosphere__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HighDensityAtmosphere__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphericFog__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Atmospheric Fog" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphericFog" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphericFog__pf = { "AtmosphericFog", nullptr, (EPropertyFlags)0x001000000009000d, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphericFog__pf), Z_Construct_UClass_UAtmosphericFogComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphericFog__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphericFog__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSkylight__pf_MetaData[] = {
		{ "Category", "SkyLight" },
		{ "DisplayName", "Use Skylight" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "UseSkylight" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSkylight__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__UseSkylight__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSkylight__pf = { "UseSkylight", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSkylight__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSkylight__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSkylight__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Shadowdistance__pf_MetaData[] = {
		{ "Category", "Sun" },
		{ "DisplayName", "Shadowdistance" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "Shadowdistance" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Shadowdistance__pf = { "Shadowdistance", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__Shadowdistance__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Shadowdistance__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Shadowdistance__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftBloom__pf_MetaData[] = {
		{ "Category", "LightShafts" },
		{ "DisplayName", "Light Shaft Bloom" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "LightShaftBloom" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftBloom__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__LightShaftBloom__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftBloom__pf = { "LightShaftBloom", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftBloom__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftBloom__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftBloom__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftOcclusion__pf_MetaData[] = {
		{ "Category", "LightShafts" },
		{ "DisplayName", "Light Shaft Occlusion" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "LightShaftOcclusion" },
	};
#endif
	void Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftOcclusion__pf_SetBit(void* Obj)
	{
		((ABP_LightStudio_C__pf1079297466*)Obj)->bpv__LightShaftOcclusion__pf = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftOcclusion__pf = { "LightShaftOcclusion", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_LightStudio_C__pf1079297466), &Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftOcclusion__pf_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftOcclusion__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftOcclusion__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OcclusionMaskDarkness__pf_MetaData[] = {
		{ "Category", "LightShafts" },
		{ "DisplayName", "Occlusion Mask Darkness" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "OcclusionMaskDarkness" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OcclusionMaskDarkness__pf = { "OcclusionMaskDarkness", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__OcclusionMaskDarkness__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OcclusionMaskDarkness__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OcclusionMaskDarkness__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomScale__pf_MetaData[] = {
		{ "Category", "LightShafts" },
		{ "DisplayName", "Bloom Scale" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "BloomScale" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomScale__pf = { "BloomScale", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__BloomScale__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomScale__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomScale__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomThreshold__pf_MetaData[] = {
		{ "Category", "LightShafts" },
		{ "DisplayName", "Bloom Threshold" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "BloomThreshold" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomThreshold__pf = { "BloomThreshold", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__BloomThreshold__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomThreshold__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomThreshold__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomTint__pf_MetaData[] = {
		{ "Category", "LightShafts" },
		{ "DisplayName", "Bloom Tint" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "BloomTint" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomTint__pf = { "BloomTint", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__BloomTint__pf), Z_Construct_UScriptStruct_FColor, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomTint__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomTint__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereFogMultiplier__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "Atmosphere Fog Multiplier" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereFogMultiplier" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereFogMultiplier__pf = { "AtmosphereFogMultiplier", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphereFogMultiplier__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereFogMultiplier__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereFogMultiplier__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDensityHeight__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "Atmosphere Density Height" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereDensityHeight" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDensityHeight__pf = { "AtmosphereDensityHeight", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphereDensityHeight__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDensityHeight__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDensityHeight__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereMaxScatteringOrder__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "Atmosphere Max Scattering Order" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereMaxScatteringOrder" },
	};
#endif
	const UE4CodeGen_Private::FIntPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereMaxScatteringOrder__pf = { "AtmosphereMaxScatteringOrder", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Int, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphereMaxScatteringOrder__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereMaxScatteringOrder__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereMaxScatteringOrder__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereAltitudeSampleNumber__pf_MetaData[] = {
		{ "Category", "Atmosphere" },
		{ "DisplayName", "Atmosphere Altitude Sample Number" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "AtmosphereAltitudeSampleNumber" },
	};
#endif
	const UE4CodeGen_Private::FIntPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereAltitudeSampleNumber__pf = { "AtmosphereAltitudeSampleNumber", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Int, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__AtmosphereAltitudeSampleNumber__pf), METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereAltitudeSampleNumber__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereAltitudeSampleNumber__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightFunctionMaterial__pf_MetaData[] = {
		{ "Category", "Sun" },
		{ "DisplayName", "Light Function Material" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "LightFunctionMaterial" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightFunctionMaterial__pf = { "LightFunctionMaterial", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__LightFunctionMaterial__pf), Z_Construct_UClass_UMaterialInterface_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightFunctionMaterial__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightFunctionMaterial__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__MIC_Black__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "MIC Black" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "MIC_Black" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__MIC_Black__pf = { "MIC_Black", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__MIC_Black__pf), Z_Construct_UClass_UMaterialInstance_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__MIC_Black__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__MIC_Black__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__MIC_HDRI__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "MIC HDRI" },
		{ "ModuleRelativePath", "Public/BP_LightStudio__pf1079297466.h" },
		{ "OverrideNativeName", "MIC_HDRI" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__MIC_HDRI__pf = { "MIC_HDRI", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_LightStudio_C__pf1079297466, bpv__MIC_HDRI__pf), Z_Construct_UClass_UMaterialInstance_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__MIC_HDRI__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__MIC_HDRI__pf_MetaData)) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SkyLight1__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__ExponentialHeightFog1__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__PrevisArrow__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Skybox__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Scene1__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__GlobalBrightness__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Use_HDRI__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSunLight__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunBrightness__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunTint__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__StationaryLightForSun__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunDirectionalLight__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseAtmosphere__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereBrightness__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereTint__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__PrevisArrowMaterial__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightColor__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SunColorCurve__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OverrideSunColor__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDensityMultiplier__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereAltitude__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableSunDisk__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseFog__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogBrightness__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogTint__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogAltitude__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogMaxOpacity__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogHeightFalloff__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogDensity__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogBrightnessCurve__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__FogStartDistance__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__DisableGroundScattering__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDistanceScale__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__SkyboxMaterial__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Brightness__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Contrast__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Tint__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Cubemap__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HDRI_Rotation__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereOpacityHorizon__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereOpacityZenith__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__HighDensityAtmosphere__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphericFog__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__UseSkylight__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__Shadowdistance__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftBloom__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightShaftOcclusion__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__OcclusionMaskDarkness__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomScale__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomThreshold__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__BloomTint__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereFogMultiplier__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereDensityHeight__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereMaxScatteringOrder__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__AtmosphereAltitudeSampleNumber__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__LightFunctionMaterial__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__MIC_Black__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::NewProp_bpv__MIC_HDRI__pf,
	};
	const FCppClassTypeInfoStatic Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<ABP_LightStudio_C__pf1079297466>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::ClassParams = {
		&ABP_LightStudio_C__pf1079297466::StaticClass,
		"Engine",
		&StaticCppClassTypeInfo,
		DependentSingletons,
		FuncInfo,
		Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::PropPointers,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		UE_ARRAY_COUNT(FuncInfo),
		UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::PropPointers),
		0,
		0x008000A4u,
		METADATA_PARAMS(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_ABP_LightStudio_C__pf1079297466()
	{
		UPackage* OuterPackage = FindOrConstructDynamicTypePackage(TEXT("/Game/StarterContent/Blueprints/BP_LightStudio"));
		UClass* OuterClass = Cast<UClass>(StaticFindObjectFast(UClass::StaticClass(), OuterPackage, TEXT("BP_LightStudio_C")));
		if (!OuterClass || !(OuterClass->ClassFlags & CLASS_Constructed))
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_ABP_LightStudio_C__pf1079297466_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_DYNAMIC_CLASS(ABP_LightStudio_C__pf1079297466, TEXT("BP_LightStudio_C"), 3504641989);
	template<> NATIVIZEDASSETS_API UClass* StaticClass<ABP_LightStudio_C__pf1079297466>()
	{
		return ABP_LightStudio_C__pf1079297466::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_ABP_LightStudio_C__pf1079297466(Z_Construct_UClass_ABP_LightStudio_C__pf1079297466, &ABP_LightStudio_C__pf1079297466::StaticClass, TEXT("/Game/StarterContent/Blueprints/BP_LightStudio"), TEXT("BP_LightStudio_C"), true, TEXT("/Game/StarterContent/Blueprints/BP_LightStudio"), TEXT("/Game/StarterContent/Blueprints/BP_LightStudio.BP_LightStudio_C"), nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(ABP_LightStudio_C__pf1079297466);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
