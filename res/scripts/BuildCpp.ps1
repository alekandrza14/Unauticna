$MSVC = "C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.38.33130"
$SDK  = "C:\Program Files (x86)\Windows Kits\10"

$env:PATH = "$MSVC\bin\Hostx64\x64;$env:PATH"

$env:INCLUDE = @(
    "$MSVC\include"
    "$SDK\Include\10.0.22621.0\ucrt"
    "$SDK\Include\10.0.22621.0\um"
    "$SDK\Include\10.0.22621.0\shared"
    "$SDK\Include\10.0.22621.0\winrt"
    "$SDK\Include\10.0.22621.0\cppwinrt"
) -join ';'

$env:LIB = @(
    "$MSVC\lib\x64"
    "$SDK\Lib\10.0.22621.0\ucrt\x64"
    "$SDK\Lib\10.0.22621.0\um\x64"
) -join ';'

cd "D:\2new\Unauticna test\game-unauticna\res\scripts"

cl /EHsc Main.cpp /Fe:Main.exe
Read-Host "Нажмите Enter"