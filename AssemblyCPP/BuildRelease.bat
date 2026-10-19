@echo off
setlocal
cd /d "%~dp0"
where msbuild >nul 2>nul
if errorlevel 1 (
    echo Run this file from "x64 Native Tools Command Prompt for VS 2022".
    echo Required: Visual Studio 2022 C++ build tools and Windows SDK.
    exit /b 1
)
msbuild "AssemblyCPP.sln" /m /p:Configuration=Release /p:Platform=x64
if errorlevel 1 exit /b 1
echo Built: %~dp0bin\x64\Release\AssemblyCPP.dll
endlocal
