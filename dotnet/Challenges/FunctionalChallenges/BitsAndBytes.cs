namespace Challenges;

public static class BitsAndBytes
{
    // Original: int bitcount(unsigned x), "The C Programming Language", page 50
    public static int BitCount(uint x) =>
        x == 0 ? 0 : BitCount(x >> 1) + (int)(x & 1);

    // In the next three methods I use [..size] instead of slicing with Span<T> for more compact code
    // But .Slice(0, size) is more probably more readable
    
    public static void ByteCopy(byte[] src, byte[] dst, int size) =>
        ((Span<byte>)src)[..Min([size, src.Length, dst.Length])].CopyTo(dst);

    public static void ByteZero(byte[] a, int size) =>
        ((Span<byte>)a)[..Min([a.Length, size])].Clear();

    public static void ByteSet(byte[] a, byte value, int size) =>
        ((Span<byte>)a)[..Min([a.Length, size])].Fill(value);
    
    private static int Min(int[] numbers) => numbers.MinBy(n => n);
}