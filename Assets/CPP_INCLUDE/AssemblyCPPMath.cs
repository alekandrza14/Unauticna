using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

public static class AssemblyCPPMath
{
    [DllImport("AssemblyCPP", EntryPoint = "PerlinNoise_2DMFloat",
        CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    private static extern int FillPerlin2D(float x, float y, int sizeX, int sizeY,
        float scale, IntPtr output, int outputLength);

    // Same API/layout as before: [ix, iy], values 0..1.
    // Only one large array is allocated; native code writes directly into it.
    public static float[,] PerlinNoise_2DMFloat(float x, float y,
        int sizeX, int sizeY, float scale = 0.01f)
    {
        Validate(x, y, sizeX, sizeY, scale);
        var result = new float[sizeX, sizeY];
        FillPinned(result, x, y, sizeX, sizeY, scale);
        return result;
    }

    // Reuse an existing rectangular buffer. No new managed array or full-array copy.
    public static void FillPerlinNoise2D(float[,] output, float x, float y, float scale = 0.01f)
    {
        if (output == null) throw new ArgumentNullException(nameof(output));
        int sizeX = output.GetLength(0), sizeY = output.GetLength(1);
        Validate(x, y, sizeX, sizeY, scale);
        FillPinned(output, x, y, sizeX, sizeY, scale);
    }

    // Flat-buffer indexing: output[ix * sizeY + iy]. A larger buffer is allowed.
    public static void FillPerlinNoise2D(float[] output, float x, float y,
        int sizeX, int sizeY, float scale = 0.01f)
    {
        if (output == null) throw new ArgumentNullException(nameof(output));
        int count = Validate(x, y, sizeX, sizeY, scale);
        if (output.Length < count) throw new ArgumentException("Output buffer is too small.", nameof(output));
        FillPinned(output, x, y, sizeX, sizeY, scale);
    }

    // Do not read/write output until the returned task completes. Uses no Unity API.
    // Cancellation is checked before native execution; an in-progress fill finishes normally.
    public static Task FillPerlinNoise2DAsync(float[] output, float x, float y,
        int sizeX, int sizeY, float scale = 0.01f, CancellationToken cancellation = default)
    {
        if (output == null) throw new ArgumentNullException(nameof(output));
        int count = Validate(x, y, sizeX, sizeY, scale);
        if (output.Length < count) throw new ArgumentException("Output buffer is too small.", nameof(output));
        return Task.Run(() => {
            cancellation.ThrowIfCancellationRequested();
            FillPinned(output, x, y, sizeX, sizeY, scale);
        }, cancellation);
    }

    private static int Validate(float x, float y, int sizeX, int sizeY, float scale)
    {
        if (sizeX <= 0) throw new ArgumentOutOfRangeException(nameof(sizeX));
        if (sizeY <= 0) throw new ArgumentOutOfRangeException(nameof(sizeY));
        if (float.IsNaN(x) || float.IsInfinity(x)) throw new ArgumentOutOfRangeException(nameof(x));
        if (float.IsNaN(y) || float.IsInfinity(y)) throw new ArgumentOutOfRangeException(nameof(y));
        if (float.IsNaN(scale) || float.IsInfinity(scale) || scale <= 0)
            throw new ArgumentOutOfRangeException(nameof(scale));
        int count = checked(sizeX * sizeY);
        checked { int bytes = count * sizeof(float); }
        return count;
    }

    private static void FillPinned(Array output, float x, float y, int sizeX, int sizeY, float scale)
    {
        GCHandle pinned = GCHandle.Alloc(output, GCHandleType.Pinned);
        try
        {
            int status = FillPerlin2D(x, y, sizeX, sizeY, scale, pinned.AddrOfPinnedObject(), output.Length);
            if (status == 3) throw new OutOfMemoryException("Native Perlin axis buffer allocation failed.");
            if (status != 0) throw new ArgumentException("PerlinNoise_2DMFloat failed, status: " + status
                + ". Check dimensions and scaled coordinate range.");
        }
        finally { pinned.Free(); }
    }
}
