#pragma once
#include <cmath>
#include <cstdint>
#include <limits>

namespace AssemblyNoiseDetail {
inline std::uint32_t Hash(int x, int y) {
    std::uint32_t h = static_cast<std::uint32_t>(x) * 0x8da6b343u
                    ^ static_cast<std::uint32_t>(y) * 0xd8163841u;
    h ^= h >> 16; h *= 0x7feb352du;
    h ^= h >> 15; h *= 0x846ca68bu;
    return h ^ (h >> 16);
}
inline double Gradient(int x, int y, double dx, double dy) {
    const double d = 0.7071067811865475244;
    switch (Hash(x, y) & 7u) {
    case 0: return dx;
    case 1: return -dx;
    case 2: return dy;
    case 3: return -dy;
    case 4: return (dx + dy) * d;
    case 5: return (dx - dy) * d;
    case 6: return (-dx + dy) * d;
    default: return (-dx - dy) * d;
    }
}
inline double Fade(double t) { return t*t*t*(t*(t*6.0-15.0)+10.0); }
inline double Lerp(double a, double b, double t) { return a+(b-a)*t; }
inline float Sample(double x, double y) {
    const int ix = static_cast<int>(std::floor(x));
    const int iy = static_cast<int>(std::floor(y));
    const double dx = x-ix, dy = y-iy;
    const double a = Lerp(Gradient(ix,iy,dx,dy),
                          Gradient(ix+1,iy,dx-1,dy), Fade(dx));
    const double b = Lerp(Gradient(ix,iy+1,dx,dy-1),
                          Gradient(ix+1,iy+1,dx-1,dy-1), Fade(dx));
    const double v = 0.5 + 0.5 * Lerp(a,b,Fade(dy));
    return static_cast<float>(v < 0 ? 0 : (v > 1 ? 1 : v));
}
inline bool ValidCoordinate(double v) {
    return std::isfinite(v) && v >= -2147483648.0 && v < 2147483647.0;
}
inline int Fill(float x, float y, int sizeX, int sizeY, float scale,
                float* output, int outputLength) {
    if (!output || sizeX <= 0 || sizeY <= 0 || !std::isfinite(x)
        || !std::isfinite(y) || !std::isfinite(scale) || scale <= 0) return 1;
    const std::int64_t count = static_cast<std::int64_t>(sizeX)*sizeY;
    if (outputLength < 0 || count > outputLength) return 2;
    const double x0 = static_cast<double>(x)*scale;
    const double y0 = static_cast<double>(y)*scale;
    const double x1 = (static_cast<double>(x)+sizeX-1)*scale;
    const double y1 = (static_cast<double>(y)+sizeY-1)*scale;
    if (!ValidCoordinate(x0) || !ValidCoordinate(y0)
        || !ValidCoordinate(x1) || !ValidCoordinate(y1)) return 1;
    for (int ix = 0; ix < sizeX; ++ix) {
        const double sx = (static_cast<double>(x)+ix)*scale;
        for (int iy = 0; iy < sizeY; ++iy)
            output[static_cast<std::int64_t>(ix)*sizeY+iy] =
                Sample(sx, (static_cast<double>(y)+iy)*scale);
    }
    return 0;
}
}
