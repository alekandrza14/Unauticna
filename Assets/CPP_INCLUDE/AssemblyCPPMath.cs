using System;
using System.Runtime.InteropServices;

public static class AssemblyCPPMath
{
    [DllImport("AssemblyCPP", EntryPoint = "PerlinNoise_2DMFloat",
        CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    private static extern int FillPerlin2D(float x, float y, int sizeX, int sizeY,
        float scale, [Out] float[] output, int outputLength);

    // Coordinates are sampled at ((x + ix) * scale, (y + iy) * scale).
    // Result indexing: [ix, iy]. Values: 0..1. Fixed deterministic noise.
    public static float[,] PerlinNoise_2DMFloat(float x, float y,
        int sizeX, int sizeY, float scale = 0.01f)
    {
        if (sizeX <= 0) throw new ArgumentOutOfRangeException(nameof(sizeX));
        if (sizeY <= 0) throw new ArgumentOutOfRangeException(nameof(sizeY));
        if (float.IsNaN(x) || float.IsInfinity(x))
            throw new ArgumentOutOfRangeException(nameof(x));
        if (float.IsNaN(y) || float.IsInfinity(y))
            throw new ArgumentOutOfRangeException(nameof(y));
        if (float.IsNaN(scale) || float.IsInfinity(scale) || scale <= 0)
            throw new ArgumentOutOfRangeException(nameof(scale));
        int count = checked(sizeX * sizeY);
        int bytes = checked(count * sizeof(float));
        var buffer = new float[count];
        int status = FillPerlin2D(x, y, sizeX, sizeY, scale, buffer, count);
        if (status != 0)
            throw new ArgumentException("PerlinNoise_2DMFloat failed, status: " + status
                + ". Check dimensions and scaled coordinate range.");
        var result = new float[sizeX, sizeY];
        Buffer.BlockCopy(buffer, 0, result, 0, bytes);
        return result;
    }
}
