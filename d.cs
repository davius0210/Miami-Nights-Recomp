// Port of original class d — drawable/animated object wrapper around sprite archive `a`
// (validated VF source; R1: methods a/b/c/d/e -> m_*).
using Microsoft.Xna.Framework.Graphics;

namespace MiamiNights
{
    internal sealed class d
    {
        internal int a;      // x (256.8 fixed)
        internal int b;      // y (256.8 fixed)
        internal int c;      // transform/flags
        internal a d_;        // sprite archive
        internal int e;      // action set index (-1 = none)
        internal int f;      // frame index within set
        internal int g;      // frame tick (-1 = static frame via f only)
        internal int[] h;
        internal d i;        // parent (position chain)

        internal d() { }

        internal d(a var1, int var2, int var3, d var4)
        {
            this.a = var2 << 8;
            this.b = var3 << 8;
            this.d_ = var1;
            this.h = new int[4];
            this.i = var4;
        }

        internal void m_a(int var1)      // select action set
        {
            if (var1 != this.e)
            {
                this.e = var1;
                this.f = 0;
                this.g = 0;
            }
        }

        internal bool m_a()              // animation finished?
        {
            if (this.e < 0) return true;
            if (!ValidFrame()) return true;   // unknown action for this sheet: treat as finished
            int var1;
            return this.f != (this.d_.h[this.e] & 255) - 1 ? false : (var1 = this.d_.m_a(this.e, this.f)) == 0 || this.g == var1 - 1;
        }

        internal int m_b(int var1)       // total frames of set
        {
            int var2 = 0;
            int var4 = this.d_.h[var1] & 255;
            for (int var3 = 0; var3 < var4; var3++) var2 += this.d_.m_a(var1, var3);
            return var2;
        }

        internal void m_a(Graphics var1) // draw (accumulates parent chain)
        {
            if (this.d_ != null)
            {
                int var2 = this.a;
                int var3 = this.b;
                for (d var4 = this.i; var4 != null; var4 = var4.i)
                {
                    var2 += var4.a;
                    var3 += var4.b;
                }
                var2 = m_d(var2) + 0;
                var3 = m_e(var3) + 0;
                // guard: shared UI sprites (e.g. h.v[19] emote) can hold an action that is not in their sheet
                if (this.e >= 0)
                {
                    if (this.d_.h != null && this.e < this.d_.h.Length && (this.f < 0 || this.f >= (this.d_.h[this.e] & 255))) { this.f = 0; this.g = 0; }
                    if (!ValidFrame()) return;
                }
                if (this.g >= 0) this.d_.m_a(var1, this.e, this.f, var2, var3, this.c, 0, 0);
                else if (this.e >= 0) this.d_.m_a(var1, this.e, var2, var3, this.c);
                else if (this.f >= 0) this.d_.m_a(var1, this.f, var2, var3, this.c, 0, 0);
            }
        }

        internal int[] m_c(int var1)     // placement query
        {
            int[] var2;
            (var2 = new int[2])[0] = this.a >> 8;
            var2[1] = this.b >> 8;
            return this.d_.m_a(this.e, this.f, var2, this.c, var1);
        }

        // frames per original 66ms tick (Game1 runs the loop faster for smooth movement; animations keep original pace)
        internal static int AnimDiv = 1;
        private int animAcc;

        // current (action e, frame f) exists in the sprite sheet tables
        private bool ValidFrame()
        {
            var s = this.d_;
            if (s == null || s.i == null || s.j == null) return false;
            if (this.e < 0 || this.e >= s.i.Length || this.f < 0) return false;
            return (s.i[this.e] + this.f) * 5 + 4 < s.j.Length;
        }

        internal static bool Frozen;     // set during extra (widescreen) render passes: draw only, never advance

        internal void m_b()              // advance animation one tick
        {
            if (Frozen) return;
            if (AnimDiv > 1 && ++this.animAcc < AnimDiv) return;
            this.animAcc = 0;
            if (this.d_ != null && this.g >= 0 && ValidFrame())
            {
                int var1;
                if ((var1 = this.d_.m_a(this.e, this.f)) != 0)
                {
                    this.g++;
                    if (var1 <= this.g)
                    {
                        this.g = 0;
                        this.f++;
                        if (this.f >= (this.d_.h[this.e] & 255))
                        {
                            this.f = 0;
                        }
                    }
                }
            }
        }

        internal int[] m_c()             // current draw bounds (x0,y0,x1,y1 in 8.8)
        {
            if (this.h == null) this.h = new int[4];
            if (this.d_ != null)
            {
                if (this.g >= 0) this.d_.m_a(this.h, this.e, this.f, this.a, this.b, this.c, 0, 0);
                else if (this.e >= 0) this.d_.m_a(this.h, this.e, this.a, this.b);
                else if (this.f >= 0) this.d_.m_a(this.h, this.f, this.a, this.b, this.c, 0, 0);
            }
            return this.h;
        }

        private static int m_d(int var0) => (var0 >> 8) * 1 / 1;
        private static int m_e(int var0) => (var0 >> 8) * 1 / 1;
    }
}
