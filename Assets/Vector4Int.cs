[System.Serializable]
public class Vector4Int
{
    public int x, y, z, w;
    public Vector4Int(int x1, int y1, int z1, int w1)
    {
        x = x1; y = y1; z = z1; w = w1;
    }
    public Vector4Int copy()
    {
        return new Vector4Int(x,y,z,w);
    }
    public static Vector4Int zero = new Vector4Int(0, 0, 0, 0);
    public static Vector4Int up_max = new Vector4Int(0, int.MaxValue, 0, 0);
}