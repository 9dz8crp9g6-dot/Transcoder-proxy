                $"BGRA32 data too small for '{texName}': got {encodedData.Length}, expected at least {expected}");
        var rgba = new byte[expected];
        Buffer.BlockCopy(encodedData, 0, rgba, 0, expected);
        return rgba;
    }

        if (!decodeFunc(encodedData, width, height, rgba))
            throw new InvalidDataException($"Kyaru Texture2DDecoder failed to decode {formatLabel}");

        return rgba;
    }

        if (!ok)
            throw new InvalidDataException($"Kyaru Texture2DDecoder failed to decode {(isDxt5 ? "DXT5" : "DXT1")}");

        if (!isDxt5)
            SwapGreenBlue(rgba);

        SwapRedBlue(rgba);
        return rgba;
    }

    private static void SwapGreenBlue(byte[] rgba)
    {
        for (int i = 0; i + 3 < rgba.Length; i += 4)
        {
            (rgba[i + 1], rgba[i + 2]) = (rgba[i + 2], rgba[i + 1]);
        }
    }

            throw new InvalidDataException(
                $"Kyaru Texture2DDecoder failed to decode {(hasAlpha ? "ETC2_RGBA8" : "ETC2_RGB")}");

        return rgba;
    }

