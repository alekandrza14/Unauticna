// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "NativizedAssets/Public/NewBlueprint8__pf3696703102.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeNewBlueprint8__pf3696703102() {}
// Cross Module References
	NATIVIZEDASSETS_API UClass* Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_NoRegister();
	NATIVIZEDASSETS_API UClass* Z_Construct_UClass_ANewBlueprint8_C__pf3696703102();
	ENGINE_API UClass* Z_Construct_UClass_ACharacter();
	ENGINE_API UClass* Z_Construct_UClass_UStaticMeshComponent_NoRegister();
// End Cross Module References
	void ANewBlueprint8_C__pf3696703102::StaticRegisterNativesANewBlueprint8_C__pf3696703102()
	{
	}
	UClass* Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_NoRegister()
	{
		return ANewBlueprint8_C__pf3696703102::StaticClass();
	}
	struct Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_bpv__Shape_Cube__pf_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_bpv__Shape_Cube__pf;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_ACharacter,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::Class_MetaDataParams[] = {
		{ "BlueprintType", "true" },
		{ "HideCategories", "Navigation" },
		{ "IncludePath", "NewBlueprint8__pf3696703102.h" },
		{ "IsBlueprintBase", "true" },
		{ "ModuleRelativePath", "Public/NewBlueprint8__pf3696703102.h" },
		{ "ObjectInitializerConstructorDeclared", "" },
		{ "OverrideNativeName", "NewBlueprint8_C" },
		{ "ReplaceConverted", "/Game/res/NewBlueprint8.NewBlueprint8_C,/Game/StarterContent/Shapes/NewBlueprint8.NewBlueprint8_C,/Game/StarterContent/Shapes/NewBlueprint.NewBlueprint_C" },
	};
#endif
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::NewProp_bpv__Shape_Cube__pf_MetaData[] = {
		{ "Category", "Default" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "Public/NewBlueprint8__pf3696703102.h" },
		{ "OverrideNativeName", "Shape_Cube" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::NewProp_bpv__Shape_Cube__pf = { "Shape_Cube", nullptr, (EPropertyFlags)0x001000040008000c, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(ANewBlueprint8_C__pf3696703102, bpv__Shape_Cube__pf), Z_Construct_UClass_UStaticMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::NewProp_bpv__Shape_Cube__pf_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::NewProp_bpv__Shape_Cube__pf_MetaData)) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::NewProp_bpv__Shape_Cube__pf,
	};
	const FCppClassTypeInfoStatic Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<ANewBlueprint8_C__pf3696703102>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::ClassParams = {
		&ANewBlueprint8_C__pf3696703102::StaticClass,
		"Game",
		&StaticCppClassTypeInfo,
		DependentSingletons,
		nullptr,
		Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::PropPointers,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		0,
		UE_ARRAY_COUNT(Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::PropPointers),
		0,
		0x008000A4u,
		METADATA_PARAMS(Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_ANewBlueprint8_C__pf3696703102()
	{
		UPackage* OuterPackage = FindOrConstructDynamicTypePackage(TEXT("/Game/res/NewBlueprint8"));
		UClass* OuterClass = Cast<UClass>(StaticFindObjectFast(UClass::StaticClass(), OuterPackage, TEXT("NewBlueprint8_C")));
		if (!OuterClass || !(OuterClass->ClassFlags & CLASS_Constructed))
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_ANewBlueprint8_C__pf3696703102_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_DYNAMIC_CLASS(ANewBlueprint8_C__pf3696703102, TEXT("NewBlueprint8_C"), 2376560719);
	template<> NATIVIZEDASSETS_API UClass* StaticClass<ANewBlueprint8_C__pf3696703102>()
	{
		return ANewBlueprint8_C__pf3696703102::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_ANewBlueprint8_C__pf3696703102(Z_Construct_UClass_ANewBlueprint8_C__pf3696703102, &ANewBlueprint8_C__pf3696703102::StaticClass, TEXT("/Game/res/NewBlueprint8"), TEXT("NewBlueprint8_C"), true, TEXT("/Game/res/NewBlueprint8"), TEXT("/Game/res/NewBlueprint8.NewBlueprint8_C"), nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(ANewBlueprint8_C__pf3696703102);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
