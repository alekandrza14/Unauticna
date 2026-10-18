# PerlinNoise_2DMFloat — Unity 6 / Windows x64

1. Откройте AssemblyCPP.sln в Visual Studio 2022 с компонентами разработки C++.
2. Выберите Release и x64, выполните Build / Rebuild Solution.
3. Скопируйте полученную x64/Release/AssemblyCPP.dll в Assets/Plugins/x86_64/.
   Удалите прежнюю копию этой DLL из других папок Assets, чтобы не было дубликатов.
   Перед заменой DLL закройте Unity, если файл занят.
4. Скопируйте Unity/AssemblyCPPMath.cs в Assets/Scripts/.
5. В настройках импорта DLL включите Windows Editor и Windows Standalone x86_64.

```csharp
float[,] map = AssemblyCPPMath.PerlinNoise_2DMFloat(0f, 0f, 256, 128);
float height = map[10, 20];
// Масштаб можно указать пятым аргументом:
float[,] detail = AssemblyCPPMath.PerlinNoise_2DMFloat(-100f, 50f, 256, 128, 0.025f);
```

Результат имеет размеры [sizeX, sizeY] и индексируется [x, y].
Вход x,y — смещение в координатах сетки; точка шума = ((x+ix)*scale, (y+iy)*scale).
Для соседнего блока без перекрытия сдвигайте x на sizeX. Для Terrain с общим краем — на sizeX-1.
Значения в диапазоне 0..1. Это детерминированный градиентный 2D Perlin с фиксированным
хешем и квинтическим сглаживанием, не побитовая копия Unity Mathf.PerlinNoise.
На целых координатах самого шума значение 0.5 — поэтому scale по умолчанию 0.01.
TerrainData.SetHeights ожидает [y,x]: перед передачей транспонируйте карту.
Функция выделяет два массива; предназначена для генерации карты, а не вызова каждый кадр.
Параллельные вызовы шума с отдельными буферами допустимы; старые Fibonacci-функции используют общее состояние.

C ABI: int PerlinNoise_2DMFloat(float x, float y, int sizeX, int sizeY,
float scale, float* output, int outputLength), calling convention cdecl.
Память принадлежит вызывающему коду. Размер outputLength задаётся в float, не байтах.
Коды: 0 — успех; 1 — недопустимый аргумент/координата; 2 — малый буфер.
Масштабированные координаты должны лежать в [-2147483648, 2147483647).
На ошибке буфер не изменяется. Для больших миров точность исходных float ограничена.

Исправлен выбор макроса экспорта: поддержаны ASSEMBLYCPP_EXPORTS и MATHLIBRARY_EXPORTS.
Старые функции сохранены. Готовая Windows DLL не включена: проект нужно собрать в Visual Studio.
