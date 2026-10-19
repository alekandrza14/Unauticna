#pragma once

#if defined(MATHLIBRARY_EXPORTS) || defined(ASSEMBLYCPP_EXPORTS)
#define MATHLIBRARY_API __declspec(dllexport)
#else
#define MATHLIBRARY_API __declspec(dllimport)
#endif


extern "C" MATHLIBRARY_API void fibonacci_init(
    const unsigned long long a, const unsigned long long b);


extern "C" MATHLIBRARY_API bool fibonacci_next();


extern "C" MATHLIBRARY_API unsigned long long fibonacci_current();


extern "C" MATHLIBRARY_API unsigned fibonacci_index(); 

extern "C" MATHLIBRARY_API long my_cpp_pluss(long a, long b);

// output[ix * sizeY + iy]; caller owns buffer.
// Returns 0 on success, 1 for invalid arguments, 2 for insufficient capacity, 3 for temporary buffer allocation failure.
extern "C" MATHLIBRARY_API int __cdecl PerlinNoise_2DMFloat(
    float x, float y, int sizeX, int sizeY, float scale,
    float* output, int outputLength);
