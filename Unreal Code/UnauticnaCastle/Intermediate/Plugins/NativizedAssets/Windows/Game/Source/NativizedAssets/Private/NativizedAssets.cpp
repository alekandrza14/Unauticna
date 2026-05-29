// Fill out your copyright notice in the Description page of Project Settings.

#include "NativizedAssets.h"
#include "Modules/ModuleInterface.h"
#include "Modules/ModuleManager.h"

class FNativizedAssetsModule : public IModuleInterface
{	
	virtual void StartupModule() override
	{
			
	}
};

IMPLEMENT_MODULE( FNativizedAssetsModule, NativizedAssets );
