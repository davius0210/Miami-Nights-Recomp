// Exact port of java.util.Random (48-bit LCG) — preserves original deterministic
// sequences (GloftMMN.l = new Random(System.currentTimeMillis()); l.nextInt()).
using System;

namespace MiamiNights
{
    public sealed class JavaRandom
    {
        private long seed;

        private const long Multiplier = 0x5DEECE66DL;
        private const long Addend = 0xBL;
        private const long Mask = (1L << 48) - 1;

        public JavaRandom()
        {
            seed = (Environment.TickCount64 ^ Multiplier) & Mask;
        }

        public JavaRandom(long seed)
        {
            this.seed = (seed ^ Multiplier) & Mask;
        }

        private int Next(int bits)
        {
            seed = (seed * Multiplier + Addend) & Mask;
            return (int)(seed >>> (48 - bits));
        }

        public int NextInt() => Next(32);

        public int NextInt(int bound)
        {
            if ((bound & -bound) == bound) // power of two
                return (int)((bound * (long)Next(31)) >> 31);
            int bits, val;
            do
            {
                bits = Next(31);
                val = bits % bound;
            } while (bits - val + (bound - 1) < 0);
            return val;
        }

        public long NextLong() => (((long)Next(32)) << 32) + Next(32);

        public double NextDouble() =>
            (((long)Next(26) << 27) + Next(27)) * (1.0 / (1L << 53));

        public float NextFloat() => Next(24) / (float)(1 << 24);

        public bool NextBoolean() => Next(1) != 0;
    }
}
