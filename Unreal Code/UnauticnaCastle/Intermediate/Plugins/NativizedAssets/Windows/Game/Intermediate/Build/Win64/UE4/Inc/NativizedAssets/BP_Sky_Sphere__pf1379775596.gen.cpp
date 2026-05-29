// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "NativizedAssets/Public/BP_Sky_Sphere__pf1379775596.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeBP_Sky_Sphere__pf1379775596() {}
// Cross Module References
	NATIVIZEDASSETS_API UClass* Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_NoRegister();
	NATIVIZEDASSETS_API UClass* Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596();
	ENGINE_API UClass* Z_Construct_UClass_AActor();
	ENGINE_API UClass* Z_Construct_UClass_UStaticMeshComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_USceneComponent_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_UMaterialInstanceDynamic_NoRegister();
	ENGINE_API UClass* Z_Construct_UClass_ADirectionalLight_NoRegister();
	COREUOBJECT_API UScriptStruct* Z_Construct_UScriptStruct_FLinearColor();
	ENGINE_API UClass* Z_Construct_UClass_UCurveLinearColor_NoRegister();
// End Cross Module References
	DEFINE_FUNCTION(ABP_Sky_Sphere_C__pf1379775596::execbpf__RefreshMaterial__pf)
	{
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__RefreshMaterial__pf();
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(ABP_Sky_Sphere_C__pf1379775596::execbpf__UpdateSunDirection__pf)
	{
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__UpdateSunDirection__pf();
		P_NATIVE_END;
	}
	DEFINE_FUNCTION(ABP_Sky_Sphere_C__pf1379775596::execbpf__UserConstructionScript__pf)
	{
		P_FINISH;
		P_NATIVE_BEGIN;
		P_THIS->bpf__UserConstructionScript__pf();
		P_NATIVE_END;
	}
	static FName NAME_ABP_Sky_Sphere_C__pf1379775596_bpf__UserConstructionScript__pf = FName(TEXT("UserConstructionScript"));
	void ABP_Sky_Sphere_C__pf1379775596::eventbpf__UserConstructionScript__pf()
	{
		ProcessEvent(FindFunctionChecked(NAME_ABP_Sky_Sphere_C__pf1379775596_bpf__UserConstructionScript__pf),NULL);
	}
	void ABP_Sky_Sphere_C__pf1379775596::StaticRegisterNativesABP_Sky_Sphere_C__pf1379775596()
	{
		UClass* Class = ABP_Sky_Sphere_C__pf1379775596::StaticClass();
		static const FNameNativePtrPair Funcs[] = {
			{ "RefreshMaterial", &ABP_Sky_Sphere_C__pf1379775596::execbpf__RefreshMaterial__pf },
			{ "UpdateSunDirection", &ABP_Sky_Sphere_C__pf1379775596::execbpf__UpdateSunDirection__pf },
			{ "UserConstructionScript", &ABP_Sky_Sphere_C__pf1379775596::execbpf__UserConstructionScript__pf },
		};
		FNativeFunctionRegistrar::RegisterFunctions(Class, Funcs, UE_ARRAY_COUNT(Funcs));
	}
	struct Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__RefreshMaterial__pf_Statics
	{
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__RefreshMaterial__pf_Statics::Function_MetaDataParams[] = {
		{ "Category", "" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "RefreshMaterial" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__RefreshMaterial__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596, nullptr, "RefreshMaterial", nullptr, nullptr, 0, nullptr, 0, RF_Public|RF_Transient, (EFunctionFlags)0x04020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__RefreshMaterial__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__RefreshMaterial__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__RefreshMaterial__pf()
	{
		UObject* Outer = Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "RefreshMaterial" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__RefreshMaterial__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UpdateSunDirection__pf_Statics
	{
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UpdateSunDirection__pf_Statics::Function_MetaDataParams[] = {
		{ "Category", "" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "UpdateSunDirection" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UpdateSunDirection__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596, nullptr, "UpdateSunDirection", nullptr, nullptr, 0, nullptr, 0, RF_Public|RF_Transient, (EFunctionFlags)0x04020400, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UpdateSunDirection__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UpdateSunDirection__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UpdateSunDirection__pf()
	{
		UObject* Outer = Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "UpdateSunDirection" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UpdateSunDirection__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	struct Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UserConstructionScript__pf_Statics
	{
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UserConstructionScript__pf_Statics::Function_MetaDataParams[] = {
		{ "BlueprintInternalUseOnly", "true" },
		{ "Category", "" },
		{ "Comment", "/**t * Construction script, the place to spawn components and do other setup.t * @note Name used in CreateBlueprint functiont */" },
		{ "CppFromBpEvent", "" },
		{ "DisplayName", "Construction Script" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "UserConstructionScript" },
		{ "ToolTip", "Construction script, the place to spawn components and do other setup.@note Name used in CreateBlueprint function" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UserConstructionScript__pf_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596, nullptr, "UserConstructionScript", nullptr, nullptr, 0, nullptr, 0, RF_Public|RF_Transient, (EFunctionFlags)0x04020C00, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UserConstructionScript__pf_Statics::Function_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UserConstructionScript__pf_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UserConstructionScript__pf()
	{
		UObject* Outer = Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596();
		UFunction* ReturnFunction = static_cast<UFunction*>(StaticFindObjectFast( UFunction::StaticClass(), Outer, "UserConstructionScript" ));
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UserConstructionScript__pf_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	UClass* Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_NoRegister()
	{
		return ABP_Sky_Sphere_C__pf1379775596::StaticClass();
	}
	struct Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics
	{
		static UObject* (*const DependentSingletons[])();
		static const FClassFunctionLinkInfo FuncInfo[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__SkySphereMesh__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__SkySphereMesh__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Base__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Base__pf;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Skyxmaterial__pfT_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Skyxmaterial__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Refreshxmaterial__pfT_MetaData[];
#endif
		static void NewProp_bpv__Refreshxmaterial__pfT_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__Refreshxmaterial__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Directionalxlightxactor__pfTT_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Directionalxlightxactor__pfTT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT_MetaData[];
#endif
		static void NewProp_bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT_SetBit(void* Obj);
		static const UE4CodeGen_Private::FBoolPropertyParams NewProp_bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Sunxheight__pfT_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__Sunxheight__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Sunxbrightness__pfT_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__Sunxbrightness__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__HorizonxFalloff__pfT_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__HorizonxFalloff__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__ZenithxColor__pfT_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpv__ZenithxColor__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Horizonxcolor__pfT_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpv__Horizonxcolor__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Cloudxcolor__pfT_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpv__Cloudxcolor__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__OverallxColor__pfT_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_bpv__OverallxColor__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Cloudxspeed__pfT_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__Cloudxspeed__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Cloudxopacity__pfT_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__Cloudxopacity__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Starsxbrightness__pfT_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_bpv__Starsxbrightness__pfT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Horizonxcolorxcurve__pfTT_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Horizonxcolorxcurve__pfTT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Zenithxcolorxcurve__pfTT_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Zenithxcolorxcurve__pfTT;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Cloudxcolorxcurve__pfTT_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Cloudxcolorxcurve__pfTT;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_AActor,
	};
	const FClassFunctionLinkInfo Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::FuncInfo[] = {
		{ &Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__RefreshMaterial__pf, "RefreshMaterial" }, // 1655949274
		{ &Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UpdateSunDirection__pf, "UpdateSunDirection" }, // 1672954380
		{ &Z_Construct_UFunction_ABP_Sky_Sphere_C__pf1379775596_bpf__UserConstructionScript__pf, "UserConstructionScript" }, // 773126576
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::Class_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "IncludePath", "BP_Sky_Sphere__pf1379775596.h" },
		{ "IsBlueprintBase", "true" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "ObjectInitializerConstructorDeclared", "" },
		{ "OverrideNativeName", "BP_Sky_Sphere_C" },
		{ "ReplaceConverted", "/Engine/EngineSky/BP_Sky_Sphere.BP_Sky_Sphere_C" },
	};
#endif
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__SkySphereMesh__pf_MetaData[] = {
		{ "Category", "BP_Skydome" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "SkySphereMesh" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__SkySphereMesh__pf = { "SkySphereMesh", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__SkySphereMesh__pf), Z_Construct_UClass_UStaticMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__SkySphereMesh__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__SkySphereMesh__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Base__pf_MetaData[] = {
		{ "Category", "BP_Skydome" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Base" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Base__pf = { "Base", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Base__pf), Z_Construct_UClass_USceneComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Base__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Base__pf_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Skyxmaterial__pfT_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Sky Material" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Sky material" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Skyxmaterial__pfT = { "Sky material", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Skyxmaterial__pfT), Z_Construct_UClass_UMaterialInstanceDynamic_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Skyxmaterial__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Skyxmaterial__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Refreshxmaterial__pfT_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Refresh Material" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Refresh material" },
		{ "Tooltip", "Use this to update the sky material after moving  a directional light" },
	};
#endif
	void Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Refreshxmaterial__pfT_SetBit(void* Obj)
	{
		((ABP_Sky_Sphere_C__pf1379775596*)Obj)->bpv__Refreshxmaterial__pfT = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Refreshxmaterial__pfT = { "Refresh material", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_Sky_Sphere_C__pf1379775596), &Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Refreshxmaterial__pfT_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Refreshxmaterial__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Refreshxmaterial__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Directionalxlightxactor__pfTT_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Directional Light Actor" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Directional light actor" },
		{ "Tooltip", "Assign your level's directional light actor to this variable to  match the sky's sun position and color" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Directionalxlightxactor__pfTT = { "Directional light actor", nullptr, (EPropertyFlags)0x0010000000000805, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Directionalxlightxactor__pfTT), Z_Construct_UClass_ADirectionalLight_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Directionalxlightxactor__pfTT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Directionalxlightxactor__pfTT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Colors Determined By Sun Position" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Colors determined by sun position" },
		{ "Tooltip", "If enabled, sky colors will change according to the sun's position" },
	};
#endif
	void Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT_SetBit(void* Obj)
	{
		((ABP_Sky_Sphere_C__pf1379775596*)Obj)->bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT = 1;
	}
	const UE4CodeGen_Private::FBoolPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT = { "Colors determined by sun position", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Bool | UE4CodeGen_Private::EPropertyGenFlags::NativeBool, RF_Public|RF_Transient|RF_MarkAsNative, 1, sizeof(bool), sizeof(ABP_Sky_Sphere_C__pf1379775596), &Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT_SetBit, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Sunxheight__pfT_MetaData[] = {
		{ "Category", "Override settings" },
		{ "DisplayName", "Sun Height" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Sun height" },
		{ "Tooltip", "If no directional light is assigned, this value determines the height of the sun" },
		{ "UIMax", "1" },
		{ "UIMin", "-1" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Sunxheight__pfT = { "Sun height", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Sunxheight__pfT), METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Sunxheight__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Sunxheight__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Sunxbrightness__pfT_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Sun Brightness" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Sun brightness" },
		{ "Tooltip", "Brightness multiplier for the sun disk" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Sunxbrightness__pfT = { "Sun brightness", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Sunxbrightness__pfT), METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Sunxbrightness__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Sunxbrightness__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__HorizonxFalloff__pfT_MetaData[] = {
		{ "Category", "Override settings" },
		{ "DisplayName", "Horizon Falloff" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Horizon Falloff" },
		{ "Tooltip", "Affects the size of the gradient from zenith color to horizon color" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__HorizonxFalloff__pfT = { "Horizon Falloff", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__HorizonxFalloff__pfT), METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__HorizonxFalloff__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__HorizonxFalloff__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__ZenithxColor__pfT_MetaData[] = {
		{ "Category", "Override settings" },
		{ "DisplayName", "Zenith Color" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Zenith Color" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__ZenithxColor__pfT = { "Zenith Color", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__ZenithxColor__pfT), Z_Construct_UScriptStruct_FLinearColor, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__ZenithxColor__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__ZenithxColor__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Horizonxcolor__pfT_MetaData[] = {
		{ "Category", "Override settings" },
		{ "DisplayName", "Horizon Color" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Horizon color" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Horizonxcolor__pfT = { "Horizon color", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Horizonxcolor__pfT), Z_Construct_UScriptStruct_FLinearColor, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Horizonxcolor__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Horizonxcolor__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxcolor__pfT_MetaData[] = {
		{ "Category", "Override settings" },
		{ "DisplayName", "Cloud Color" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Cloud color" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxcolor__pfT = { "Cloud color", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Cloudxcolor__pfT), Z_Construct_UScriptStruct_FLinearColor, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxcolor__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxcolor__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__OverallxColor__pfT_MetaData[] = {
		{ "Category", "Override settings" },
		{ "DisplayName", "Overall Color" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Overall Color" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__OverallxColor__pfT = { "Overall Color", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__OverallxColor__pfT), Z_Construct_UScriptStruct_FLinearColor, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__OverallxColor__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__OverallxColor__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxspeed__pfT_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Cloud Speed" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Cloud speed" },
		{ "Tooltip", "Panning speed for the clouds" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxspeed__pfT = { "Cloud speed", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Cloudxspeed__pfT), METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxspeed__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxspeed__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxopacity__pfT_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Cloud Opacity" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Cloud opacity" },
		{ "Tooltip", "Opacity of the panning clouds" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxopacity__pfT = { "Cloud opacity", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Cloudxopacity__pfT), METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxopacity__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxopacity__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Starsxbrightness__pfT_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Stars Brightness" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Stars brightness" },
		{ "Tooltip", "Multiplier for the brightness of the stars when the sun is below the horizon" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Starsxbrightness__pfT = { "Stars brightness", nullptr, (EPropertyFlags)0x0010000000000005, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Starsxbrightness__pfT), METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Starsxbrightness__pfT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Starsxbrightness__pfT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Horizonxcolorxcurve__pfTT_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Horizon Color Curve" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Horizon color curve" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Horizonxcolorxcurve__pfTT = { "Horizon color curve", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Horizonxcolorxcurve__pfTT), Z_Construct_UClass_UCurveLinearColor_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Horizonxcolorxcurve__pfTT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Horizonxcolorxcurve__pfTT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Zenithxcolorxcurve__pfTT_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Zenith Color Curve" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Zenith color curve" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Zenithxcolorxcurve__pfTT = { "Zenith color curve", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Zenithxcolorxcurve__pfTT), Z_Construct_UClass_UCurveLinearColor_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Zenithxcolorxcurve__pfTT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Zenithxcolorxcurve__pfTT_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxcolorxcurve__pfTT_MetaData[] = {
		{ "Category", "Default" },
		{ "DisplayName", "Cloud Color Curve" },
		{ "ModuleRelativePath", "Public/BP_Sky_Sphere__pf1379775596.h" },
		{ "OverrideNativeName", "Cloud color curve" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxcolorxcurve__pfTT = { "Cloud color curve", nullptr, (EPropertyFlags)0x0010000000010005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ABP_Sky_Sphere_C__pf1379775596, bpv__Cloudxcolorxcurve__pfTT), Z_Construct_UClass_UCurveLinearColor_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxcolorxcurve__pfTT_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxcolorxcurve__pfTT_MetaData)) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__SkySphereMesh__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Base__pf,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Skyxmaterial__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Refreshxmaterial__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Directionalxlightxactor__pfTT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Colorsxdeterminedxbyxsunxposition__pfTTTT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Sunxheight__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Sunxbrightness__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__HorizonxFalloff__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__ZenithxColor__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Horizonxcolor__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxcolor__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__OverallxColor__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxspeed__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxopacity__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Starsxbrightness__pfT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Horizonxcolorxcurve__pfTT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Zenithxcolorxcurve__pfTT,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::NewProp_bpv__Cloudxcolorxcurve__pfTT,
	};
	const FCppClassTypeInfoStatic Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<ABP_Sky_Sphere_C__pf1379775596>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::ClassParams = {
		&ABP_Sky_Sphere_C__pf1379775596::StaticClass,
		"Engine",
		&StaticCppClassTypeInfo,
		DependentSingletons,
		FuncInfo,
		Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::PropPointers,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		UE_ARRAY_COUNT(FuncInfo),
		UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::PropPointers),
		0,
		0x008000A4u,
		METADATA_PARAMS(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596()
	{
		UPackage* OuterPackage = FindOrConstructDynamicTypePackage(TEXT("/Engine/EngineSky/BP_Sky_Sphere"));
		UClass* OuterClass = Cast<UClass>(StaticFindObjectFast(UClass::StaticClass(), OuterPackage, TEXT("BP_Sky_Sphere_C")));
		if (!OuterClass || !(OuterClass->ClassFlags & CLASS_Constructed))
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_DYNAMIC_CLASS(ABP_Sky_Sphere_C__pf1379775596, TEXT("BP_Sky_Sphere_C"), 2725822280);
	template<> NATIVIZEDASSETS_API UClass* StaticClass<ABP_Sky_Sphere_C__pf1379775596>()
	{
		return ABP_Sky_Sphere_C__pf1379775596::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_ABP_Sky_Sphere_C__pf1379775596(Z_Construct_UClass_ABP_Sky_Sphere_C__pf1379775596, &ABP_Sky_Sphere_C__pf1379775596::StaticClass, TEXT("/Engine/EngineSky/BP_Sky_Sphere"), TEXT("BP_Sky_Sphere_C"), true, TEXT("/Engine/EngineSky/BP_Sky_Sphere"), TEXT("/Engine/EngineSky/BP_Sky_Sphere.BP_Sky_Sphere_C"), nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(ABP_Sky_Sphere_C__pf1379775596);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
