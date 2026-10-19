#pragma once
#include <cmath>
#include <cstdint>
#include <limits>
#include <vector>
#include <new>

namespace AssemblyNoiseDetail {
inline std::uint32_t Hash(int x, int y) {
    std::uint32_t h = static_cast<std::uint32_t>(x) * 0x8da6b343u
                    ^ static_cast<std::uint32_t>(y) * 0xd8163841u;
    h ^= h >> 16; h *= 0x7feb352du;
    h ^= h >> 15; h *= 0x846ca68bu;
    return h ^ (h >> 16);
}
inline double GradientCode(std::uint32_t code, double dx, double dy) {
    const double d = 0.7071067811865475244;
    switch (code & 7u) {
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
inline double Gradient(int x, int y, double dx, double dy) {
    return GradientCode(Hash(x, y), dx, dy);
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
    // Tiny requests do not justify a temporary axis cache.
    if (count < 256) {
        for (int ix = 0; ix < sizeX; ++ix)
            for (int iy = 0; iy < sizeY; ++iy)
                output[static_cast<std::int64_t>(ix)*sizeY+iy] =
                    Sample((static_cast<double>(x)+ix)*scale, (static_cast<double>(y)+iy)*scale);
        return 0;
    }
    struct Axis { int cell; double fraction, fade; };
    try {
        // Each y coordinate/fade is shared by every x row; keep row-major writes.
        std::vector<Axis> ys(static_cast<std::size_t>(sizeY));
        for (int iy = 0; iy < sizeY; ++iy) {
            const double sy = (static_cast<double>(y)+iy)*scale;
            const int cell = static_cast<int>(std::floor(sy));
            const double fraction = sy-cell;
            ys[iy] = Axis{cell, fraction, Fade(fraction)};
        }
        for (int ix = 0; ix < sizeX; ++ix) {
            const double sx = (static_cast<double>(x)+ix)*scale;
            const int cx = static_cast<int>(std::floor(sx));
            const double dx = sx-cx, fx = Fade(dx);
            int cachedY = 0;
            std::uint32_t h00=0,h10=0,h01=0,h11=0;
            float* row = output+static_cast<std::int64_t>(ix)*sizeY;
            for (int iy = 0; iy < sizeY; ++iy) {
                const Axis& axis=ys[iy];
                if (iy==0 || axis.cell!=cachedY) {
                    cachedY=axis.cell;
                    h00=Hash(cx,cachedY); h10=Hash(cx+1,cachedY);
                    h01=Hash(cx,cachedY+1); h11=Hash(cx+1,cachedY+1);
                }
                const double dy=axis.fraction;
                const double a=Lerp(GradientCode(h00,dx,dy),GradientCode(h10,dx-1,dy),fx);
                const double b=Lerp(GradientCode(h01,dx,dy-1),GradientCode(h11,dx-1,dy-1),fx);
                const double v=0.5+0.5*Lerp(a,b,axis.fade);
                row[iy]=static_cast<float>(v<0 ? 0 : (v>1 ? 1 : v));
            }
        }
        return 0;
    } catch (const std::bad_alloc&) {
        return 3; // Never let an allocation exception cross the C/PInvoke ABI.
    } catch (...) {
        return 3;
    }
}
}
