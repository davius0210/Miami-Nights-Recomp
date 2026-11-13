// Shared translation helpers (PORTING.md §1/§3).
using System;
using System.Text.RegularExpressions;

namespace MiamiNights
{
    public static class Helpers
    {
        public static sbyte[] ToS(byte[] src)
        {
            if (src == null) return null;
            var dst = new sbyte[src.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            return dst;
        }

        public static byte[] ToB(sbyte[] src)
        {
            if (src == null) return null;
            var dst = new byte[src.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            return dst;
        }
    }

    public static class MiaNow
    {
        public static long Ms() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public static class MiaStr
    {
        // java.lang.String.split: regex split that DROPS trailing empty strings
        public static string[] JavaSplit(string s, string regex)
        {
            var parts = Regex.Split(s, regex);
            int end = parts.Length;
            while (end > 0 && parts[end - 1].Length == 0) end--;
            if (end == parts.Length) return parts;
            var res = new string[end];
            Array.Copy(parts, res, end);
            return res;
        }
    }
}
