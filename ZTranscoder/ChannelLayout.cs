
using System;

internal enum ChannelLayout
{
    Rgba,
    Bgra,
    Argb
}

internal static class ChannelSwizzle
{
    public static byte[] ConvertToRgba(byte[] pixels, ChannelLayout sourceLayout)
    {
        switch (sourceLayout)
        {
            case ChannelLayout.Rgba:
                return pixels;
            case ChannelLayout.Bgra:
                SwapRedBlueInPlace(pixels);
                return pixels;
            case ChannelLayout.Argb:
                return ArgbToRgba(pixels);
            default:
                throw new ArgumentOutOfRangeException(nameof(sourceLayout), sourceLayout, null);
        }
    }

    public static byte[] ConvertFromRgba(byte[] rgba, ChannelLayout targetLayout)
    {
        switch (targetLayout)
        {
            case ChannelLayout.Rgba:
                return rgba;
            case ChannelLayout.Bgra:
                var bgra = (byte[])rgba.Clone();
                SwapRedBlueInPlace(bgra);
                return bgra;
            case ChannelLayout.Argb:
                return RgbaToArgb(rgba);
            default:
                throw new ArgumentOutOfRangeException(nameof(targetLayout), targetLayout, null);
        }
    }

    private static void SwapRedBlueInPlace(byte[] pixels)
    {
        for (int i = 0; i + 3 < pixels.Length; i += 4)
        {
            (pixels[i + 0], pixels[i + 2]) = (pixels[i + 2], pixels[i + 0]);
        }
    }

    private static byte[] ArgbToRgba(byte[] argb)
    {
        var rgba = new byte[argb.Length];
        for (int i = 0; i + 3 < argb.Length; i += 4)
        {
            rgba[i + 0] = argb[i + 1];
            rgba[i + 1] = argb[i + 2];
            rgba[i + 2] = argb[i + 3];
            rgba[i + 3] = argb[i + 0];
        }
        return rgba;
    }

    private static byte[] RgbaToArgb(byte[] rgba)
    {
        var argb = new byte[rgba.Length];
        for (int i = 0; i + 3 < rgba.Length; i += 4)
        {
            argb[i + 0] = rgba[i + 3];
            argb[i + 1] = rgba[i + 0];
            argb[i + 2] = rgba[i + 1];
            argb[i + 3] = rgba[i + 2];
        }
        return argb;
    }
}
