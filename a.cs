// Port of original class a (sprite/font archive engine) from validated decompile_vf/a.java.
// Renames per R1: methods a/b/c/d -> m_a/m_b/m_c/m_d (fields a..d exist).
// VF byte-counter defect at frame-flag loop corrected to int (CFR reference: int i).
using System;
using Microsoft.Xna.Framework.Graphics;

namespace MiamiNights
{
    internal sealed class a
    {
        internal int a_;
        internal sbyte[] b;      // frame widths
        internal sbyte[] c;      // frame heights
        internal sbyte[] d;      // composition group counts
        internal short[] e;      // composition offsets
        internal sbyte[] f;      // f-table (4 or 5 byte entries handled via t)
        internal sbyte[] g;      // composition entries
        internal sbyte[] h;      // action set counts
        internal short[] i;      // action set offsets
        internal sbyte[] j;      // animation table (5 bytes each)
        internal int[][] k;      // palettes
        internal int l;          // palette count
        public int m;            // active palette index
        internal short n;        // pixel encoding marker
        internal int o;
        internal int p;
        internal sbyte[] q;      // frame pixel data
        internal short[] r;      // frame pixel offsets
        internal sbyte[] s;      // placeholder rects
        internal bool t;         // 5-byte composition mode
        internal int u;
        internal static int[] v = new int[4096];
        internal Image[][] w;
        internal short[] x = null;
        internal static int y;
        internal static int z;
        internal sbyte[] A;      // char -> glyph map (256)
        private int B = 0;

        // ---- parse archive payload (original a(byte[],int,int,boolean)) ----
        internal void m_a(sbyte[] var1, int var2, int var3, bool var4)
        {
            try
            {
                var2++;
                int var10001 = ++var2;
                var2++;
                int flags = (var1[var10001] & 255) + ((var1[var2++] & 255) << 8) + ((var1[var2++] & 255) << 16) + ((var1[var2++] & 255) << 24);
                this.t = (flags & 16384) != 0;
                this.a_ = (var1[var2++] & 255) + ((var1[var2++] & 255) << 8);
                if (this.a_ > 0)
                {
                    this.b = new sbyte[this.a_];
                    this.c = new sbyte[this.a_];
                    if (var4) this.s = new sbyte[this.a_ * 6];

                    for (int var7 = 0; var7 < this.a_; var7++)
                    {
                        this.b[var7] = var1[var2++];
                        if (this.b[var7] < 0)
                        {
                            if (var4)
                            {
                                this.s[var7 * 6 + 0] = var1[var2++];
                                this.s[var7 * 6 + 1] = var1[var2++];
                                this.s[var7 * 6 + 2] = var1[var2++];
                                this.s[var7 * 6 + 3] = var1[var2++];
                                this.s[var7 * 6 + 4] = var1[var2++];
                                this.s[var7 * 6 + 5] = var1[var2++];
                            }
                            else
                            {
                                var2 += 6;
                            }
                            this.b[var7] = 0;
                            this.c[var7] = 0;
                        }
                        else
                        {
                            this.c[var7] = var1[var2++];
                        }
                    }
                }

                int var59;
                if ((var59 = (var1[var2++] & 255) + ((var1[var2++] & 255) << 8)) > 0)
                {
                    this.g = new sbyte[this.t ? var59 * 5 : var59 << 2];
                    Array.Copy(var1, var2, this.g, 0, this.g.Length);
                    var2 += this.g.Length;
                }

                int var8;
                if ((var8 = (var1[var2++] & 255) + ((var1[var2++] & 255) << 8)) > 0)
                {
                    this.d = new sbyte[var8];
                    this.e = new short[var8];
                    for (int var9 = 0; var9 < var8; var9++)
                    {
                        this.d[var9] = var1[var2++];
                        int var134 = ++var2;
                        var2++;
                        this.e[var9] = (short)((var1[var134] & 255) + ((var1[var2++] & 255) << 8));
                    }
                    int var60 = var8 << 2;
                    this.f = new sbyte[var60];
                    for (int var10 = 0; var10 < var60; var10++) this.f[var10] = var1[var2++];
                }

                int var61;
                if ((var61 = (var1[var2++] & 255) + ((var1[var2++] & 255) << 8)) > 0)
                {
                    this.j = new sbyte[var61 * 5];
                    Array.Copy(var1, var2, this.j, 0, this.j.Length);
                    var2 += this.j.Length;
                }

                int var62;
                if ((var62 = (var1[var2++] & 255) + ((var1[var2++] & 255) << 8)) > 0)
                {
                    this.h = new sbyte[var62];
                    this.i = new short[var62];
                    for (int var11 = 0; var11 < var62; var11++)
                    {
                        this.h[var11] = var1[var2++];
                        int var137 = ++var2;
                        var2++;
                        this.i[var11] = (short)((var1[var137] & 255) + ((var1[var2++] & 255) << 8));
                    }
                }

                if (this.a_ > 0)
                {
                    short var63 = (short)((var1[var2++] & 255) + ((var1[var2++] & 255) << 8));
                    this.l = var1[var2++] & 255;
                    int var12;
                    if ((var12 = var1[var2++] & 255) == 0) var12 = 256;

                    this.k = var3 == -1 ? new int[this.l][] : new int[var3][];

                    for (int var13 = 0; var13 < this.l; var13++)
                    {
                        this.k[var13] = new int[var12];
                        if (var63 == -30584)
                        {
                            for (int var66 = 0; var66 < var12; var66++)
                            {
                                int var70 = (var1[var2++] & 255) + ((var1[var2++] & 255) << 8) + ((var1[var2++] & 255) << 16) + ((var1[var2++] & 255) << 24);
                                this.k[var13][var66] = var70;
                            }
                        }
                        else if (var63 == 17476)
                        {
                            this.k[var13][0] = 0;
                            var2 += 2;
                            for (int var65 = 1; var65 < var12; var65++)
                                this.k[var13][var65] = (short)((var1[var2++] & 255) + ((var1[var2++] & 255) << 8));
                        }
                        else if (var63 == 21781)
                        {
                            this.k[var13][0] = 0;
                            var2 += 2;
                            for (int var15 = 1; var15 < var12; var15++)
                            {
                                int var14 = (var1[var2++] & 255) + ((var1[var2++] & 255) << 8);
                                this.k[var13][var15] = unchecked((int)0xFF000000) | (var14 & 31744) << 9 | (var14 & 992) << 6 | (var14 & 31) << 3;
                            }
                        }
                    }

                    this.n = (short)((var1[var2++] & 255) + ((var1[var2++] & 255) << 8));
                    if (this.a_ > 0)
                    {
                        this.r = new short[this.a_ + 1];
                        int var64 = 0;
                        int var67 = var2;
                        for (int var71 = 0; var71 < this.a_; var71++)
                        {
                            int var16 = (var1[var67++] & 255) + ((var1[var67++] & 255) << 8);
                            this.r[var71] = (short)var64;
                            var67 += var16;
                            var64 += var16;
                        }
                        this.r[this.a_] = (short)var64;
                        this.q = new sbyte[var64];
                        for (int var72 = 0; var72 < this.a_; var72++)
                        {
                            int var73 = (var1[var2++] & 255) + ((var1[var2++] & 255) << 8);
                            Array.Copy(var1, var2, this.q, this.r[var72] & 0xFFFF, var73);
                            var2 += var73;
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        // ---- build RGB frames -> Images (original a(int,int,int,int,int)) ----
        internal void m_a(int var1, int var2, int var3, int var4, int var5)
        {
            if (this.a_ == 0) return;
            if (var3 == -1) var3 = this.a_ - 1;
            if (v == null) v = new int[4096];
            if (this.w == null) this.w = new Image[this.l][];

            if (this.t && this.g != null)
            {
                int var6 = this.g.Length;
                if (this.x == null)
                {
                    this.x = new short[this.a_];
                    for (int var9 = 0; var9 < var6; var9 += 5)   // int counter (CFR: int i; VF byte wrong)
                    {
                        int var7 = this.g[var9] & 255;
                        int var8 = this.g[var9 + 3];
                        this.x[var7] = (short)(this.x[var7] | 1 << var8);
                    }
                }
            }

            if (!this.t && this.w[var5] == null) this.w[var5] = new Image[this.a_];

            if (var4 >= 0)
            {
                for (int var16 = var2; var16 <= var3; var16++)
                    this.w[var5][var16] = this.w[var4][var16];
            }
            else
            {
                int var17 = var1 + 1;
                if (this.t) { var1 = 0; var17 = this.l; }
                int var18 = this.m;
                for (int var19 = var1; var19 < var17; var19++)
                {
                    if (this.t && this.w[var5] == null) this.w[var5] = new Image[this.a_];
                    this.m = this.t ? var19 : var1;
                    for (int var10 = var2; var10 <= var3; var10++)
                    {
                        if (this.x == null || (this.x[var10] >> var19 & 1) != 0)
                        {
                            int var11 = this.b[var10] & 255;
                            int var12 = this.c[var10] & 255;
                            int[] var13;
                            if (var11 > 0 && var12 > 0 && (var13 = this.m_d(var10)) != null)
                                this.w[var5][var10] = Image.CreateRGBImage(var13, var11, var12, true);
                        }
                    }
                }
                this.m = var18;
            }
        }

        // ---- draw single frame (original a(Graphics,int,int,int,int)) ----
        internal void m_a(Graphics var1, int var2, int var3, int var4, int var5)
        {
            int var6 = this.b[var2] & 255;
            int var7 = 0;
            if (var6 <= 0)
            {
                if (this.s != null)
                {
                    var5 = var2 * 6;
                    var6 = this.s[var5 + 4] & 255;
                    var7 = this.s[var5 + 5] & 255;
                    if (var6 == 1 && var7 == 1)
                    {
                        try
                        {
                            MiamiNights.h.m_a(var1, this.u, this.s[var5 + 2] & 255, this.s[var5 + 0] & 255, var3, var4);
                            return;
                        }
                        catch (Exception) { return; }
                    }
                    var1.SetColor(this.s[var5 + 2] & 255, this.s[var5 + 1] & 255, this.s[var5 + 0] & 255);
                    var1.FillRect(var3, var4, var6, var7);
                }
                return;
            }
            Image var8 = null;
            if (this.w != null && this.w[this.m] != null) var8 = this.w[this.m][var2];
            var6 = var8.GetWidth();
            var7 = var8.GetHeight();
            int tr = (var5 & 1) != 0 ? ((var5 & 2) != 0 ? 3 : 2) : ((var5 & 2) != 0 ? 1 : 0);
            var1.DrawRegion(var8, 0, 0, var6, var7, tr, var3, var4, 0);
        }

        // ---- pixel decode (original private d(int)) ----
        private int[] m_d(int var1)
        {
            int var2 = this.b[var1] & 255;
            int var3 = this.c[var1] & 255;
            int[] var4 = v;
            int[] var5;
            if ((var5 = this.k[this.m]) == null) return null;
            sbyte[] var6 = this.q;
            int var7 = this.r[var1] & 0xFFFF;
            int var8 = 0;
            int var9 = var2 * var3;

            if (this.n != 25840)
            {
                if (this.n == 10225)
                {
                    while (var8 < var9)
                    {
                        int var27;
                        if ((var27 = var6[var7++] & 255) > 127)
                        {
                            int var30 = var6[var7++] & 255;
                            int var12 = var5[var30];
                            var27 -= 128;
                            while (var27-- > 0) var4[var8++] = var12;
                        }
                        else
                        {
                            var4[var8++] = var5[var27];
                        }
                    }
                }
                else if (this.n == 22258)
                {
                    while (var8 < var9)
                    {
                        int var25;
                        if ((var25 = var6[var7++] & 255) > 128 - 1)
                        {
                            var25 -= 128;
                            while (var25-- > 0) var4[var8++] = var5[var6[var7++] & 255];
                        }
                        else
                        {
                            int var29 = var5[var6[var7++] & 255];
                            while (var25-- > 0) var4[var8++] = var29;
                        }
                    }
                }
                else if (this.n == 5632)
                {
                    while (var8 < var9)
                    {
                        var4[var8++] = var5[var6[var7] >> 4 & 15];
                        var4[var8++] = var5[var6[var7] & 15];
                        var7++;
                    }
                }
                else if (this.n == 1024)
                {
                    while (var8 < var9)
                    {
                        var4[var8++] = var5[var6[var7] >> 6 & 3];
                        var4[var8++] = var5[var6[var7] >> 4 & 3];
                        var4[var8++] = var5[var6[var7] >> 2 & 3];
                        var4[var8++] = var5[var6[var7] & 3];
                        var7++;
                    }
                }
                else if (this.n == 512)
                {
                    while (var8 < var9)
                    {
                        var4[var8++] = var5[var6[var7] >> 7 & 1];
                        var4[var8++] = var5[var6[var7] >> 6 & 1];
                        var4[var8++] = var5[var6[var7] >> 5 & 1];
                        var4[var8++] = var5[var6[var7] >> 4 & 1];
                        var4[var8++] = var5[var6[var7] >> 3 & 1];
                        var4[var8++] = var5[var6[var7] >> 2 & 1];
                        var4[var8++] = var5[var6[var7] >> 1 & 1];
                        var4[var8++] = var5[var6[var7] & 1];
                        var7++;
                    }
                }
                else if (this.n == 22018)
                {
                    while (var8 < var9) var4[var8++] = var5[var6[var7++] & 255];
                }
            }
            else
            {
                while (var8 < var9)
                {
                    int var10 = var6[var7++] & 255;
                    int var11 = var5[var10 & this.o];
                    var10 >>= this.p;
                    while (var10-- >= 0) var4[var8++] = var11;
                }
            }
            return var4;
        }

        internal void m_a() { this.w = null; }     // original a(): drop image cache

        internal int m_a(int var1, int var2) => this.j[(this.i[var1] + var2) * 5 + 1] & 0xFF;
        internal int m_a(int var1) => this.f[var1 * 4 + 2] & 0xFF;
        internal int m_b(int var1) => this.f[var1 * 4 + 3] & 0xFF;
        internal int m_b(int var1, int var2)
        {
            int var3 = this.e[var1] + var2 << 2;
            return this.g[var3 + 1];
        }
        internal int m_c(int var1, int var2)
        {
            int var3 = this.e[var1] + var2 << 2;
            return this.g[var3 + 2];
        }
        internal int m_d(int var1, int var2)
        {
            int var3 = (this.i[var1] + var2) * 5;
            return this.j[var3] & 0xFF;
        }

        // original a(int[],int,int,int,int,int,int,int,int)  (8 args)
        internal void m_a(int[] var1, int var2, int var3, int var4, int var5, int var6, int var7, int var8)
        {
            int var9 = (this.i[var2] + var3) * 5;
            int var10 = this.j[var9] & 255;
            if ((var6 & 1) != 0) var7 += this.j[var9 + 2]; else var7 -= this.j[var9 + 2];
            if ((var6 & 2) != 0) var8 += this.j[var9 + 3]; else var8 -= this.j[var9 + 3];
            this.m_a(var1, var10, var4, var5, var6 ^ this.j[var9 + 4] & 15, var7, var8);
        }

        // original a(int[],int,int,int,int,int,int,int) (7 args)
        internal void m_a(int[] var1, int var2, int var3, int var4, int var5, int var6, int var7)
        {
            int var8 = var2 << 2;
            int var9 = this.f[var8++];
            int var10 = this.f[var8++];
            int var11 = this.f[var8++] & 255;
            int var12 = this.f[var8] & 255;
            if ((var5 & 1) != 0) var6 += var9 + var11; else var6 -= var9;
            if ((var5 & 2) != 0) var7 += var10 + var12; else var7 -= var10;
            var1[0] = var3 - (var6 << 8);
            var1[1] = var4 - (var7 << 8);
            var1[2] = var1[0] + (var11 << 8);
            var1[3] = var1[1] + (var12 << 8);
        }

        // original a(int[],int,int,int) (4 args)
        internal void m_a(int[] var1, int var2, int var3, int var4)
        {
            var1[0] = var3;
            var1[1] = var4;
            var1[2] = var3 + ((this.b[var2] & 255) << 8);
            var1[3] = var4 + ((this.c[var2] & 255) << 8);
        }

        // original a(int,int,int[],int,int)
        internal int[] m_a(int var1, int var2, int[] var3, int var4, int var5)
        {
            int var6 = (this.i[var1] + var2) * 5;
            int var7 = this.j[var6] & 255;
            if ((var4 & 1) != 0) var3[0] += -this.j[var6 + 2]; else var3[0] -= -this.j[var6 + 2];
            if ((var4 & 2) != 0) var3[1] += -this.j[var6 + 3]; else var3[1] -= -this.j[var6 + 3];
            int var8 = this.d[var7] & 255;
            for (int var9 = 0; var9 < var8; var9++)
            {
                var6 = this.e[var7] + var9 << 2;
                int var10 = this.g[var6 + 3] & 255;
                int var11 = this.g[var6] & 255 | (var10 & 192) << 2;
                int var12 = this.b[var11] & 255;
                int var13 = this.c[var11] & 255;
                if (var12 <= 0 || var13 <= 0)
                {
                    if (var5 == 0)
                    {
                        if ((var4 & 1) != 0) var3[0] -= this.g[var6 + 1]; else var3[0] += this.g[var6 + 1];
                        if ((var4 & 2) != 0) var3[1] -= this.g[var6 + 2]; else var3[1] += this.g[var6 + 2];
                        return var3;
                    }
                    var5--;
                }
            }
            return null;
        }

        // original a(Graphics,int,int,int,int,int,int,int) (8 args)
        private static bool badFrameLogged;

        internal void m_a(Graphics var1, int var2, int var3, int var4, int var5, int var6, int var7, int var8)
        {
            // guard: out-of-range action/frame (seen on the "CONGRATULATIONS" popup) used to throw every frame and
            // abort the rest of that frame's UI drawing -> skip just this sprite instead
            if (var2 < 0 || var2 >= this.i.Length || var3 < 0 || (this.i[var2] + var3) * 5 + 4 >= this.j.Length)
            {
                if (!badFrameLogged) { badFrameLogged = true; Console.WriteLine("[sprite] skipped invalid action " + var2 + " frame " + var3 + " (actions " + this.i.Length + ")"); }
                return;
            }
            int var9 = (this.i[var2] + var3) * 5;
            int var10 = this.j[var9] & 255;
            if ((var6 & 1) != 0) var7 += this.j[var9 + 2]; else var7 -= this.j[var9 + 2];
            if ((var6 & 2) != 0) var8 += this.j[var9 + 3]; else var8 -= this.j[var9 + 3];
            this.m_a(var1, var10, var4 - var7, var5 - var8, var6 ^ this.j[var9 + 4] & 15, var7, var8);
        }

        // original a(Graphics,int,int,int,int,int,int) (7 args): composite draw
        internal void m_a(Graphics var1, int var2, int var3, int var4, int var5, int var6, int var7)
        {
            int var8 = this.d[var2] & 255;
            for (int var9 = 0; var9 < var8; var9++)
            {
                this.u = var9;
                this.m_a(var1, var2, var9, var3, var4, var5);
            }
        }

        // original private a(Graphics,int,int,int,int,int): part placement
        private void m_a(Graphics var1, int var2, int var3, int var4, int var5, int var6)
        {
            int var7 = this.t ? (this.e[var2] + var3) * 5 : this.e[var2] + var3 << 2;
            int var8 = this.g[var7 + (this.t ? 4 : 3)] & 255;
            int var9 = this.g[var7] & 255 | (var8 & 192) << 2;
            if ((var6 & 1) != 0) var4 -= this.g[var7 + 1]; else var4 += this.g[var7 + 1];
            if ((var6 & 2) != 0) var5 -= this.g[var7 + 2]; else var5 += this.g[var7 + 2];
            if ((var6 & 1) != 0) var4 -= this.b[var9] & 255;
            if ((var6 & 2) != 0) var5 -= this.c[var9] & 255;
            this.m_a(var1, var9, var4, var5, var6 ^ var8 & 15);
        }

        internal void m_b() { this.q = null; this.r = null; GC.Collect(); }
        internal void m_c()
        {
            if (this.k != null)
            {
                for (int var1 = 0; var1 < this.k.Length; var1++)
                    if (this.k[var1] != null) this.k[var1] = null;
                this.k = null;
            }
            GC.Collect();
        }
        internal void m_c(int var1) { this.B = var1; }

        // ---- text measure (original a(String)) ----
        internal void m_a(string var1)
        {
            y = 0;
            z = this.c[0] & 255;
            int var3 = 0;
            bool var4 = false;
            for (int var2 = 0; var2 < var1.Length; var2++)
            {
                int var5;
                if ((var5 = var1[var2]) == 123) { var4 = true; var5 = -1; }
                else if (var5 == 125) { var4 = false; var5 = -1; }
                else if (var5 > 32) { var5 = this.A[var5] & 255; }
                else
                {
                    if (var5 == 32)
                    {
                        var3 += (this.b[0] & 255) + this.g[1];
                        continue;
                    }
                    if (var5 == 10)
                    {
                        if (var3 > y) y = var3;
                        var3 = 0;
                        z = z + this.B + (this.c[0] & 255);
                        continue;
                    }
                }
                if (var5 >= 0)
                {
                    int var6 = this.g[var5 << 2] & 255;
                    if (var2 == var1.Length - 1) var3 += (this.b[var6] & 255) - this.g[(var5 << 2) + 1];
                    else var3 += (this.b[var6] & 255) - this.g[(var5 << 2) + 1] + this.g[1];
                }
                if (var4) var3 += this.g[1];
            }
            if (var3 > y) y = var3;
            if (y > 0) y = y - this.g[1];
        }

        // ---- text draw (original a(Graphics,String,int,int,int,int)) ----
        internal void m_a(Graphics var1, string var2, int var3, int var4, int var5, int var6)
        {
            this.m = var6;
            var4 -= this.g[2];
            int var7;
            if (MiamiNights.h.h_ == 21 && (var7 = var2.IndexOf((char)37)) != -1)
            {
                string var8 = GloftMMN.b.GetAppProperty("MIDlet-Version");
                var2 = var2.Substring(0, var7) + var8 + var2.Substring(var7 + 1);
            }

            bool var18 = false;
            if ((var5 & 42) != 0)
            {
                this.m_a(var2);
                if ((var5 & 8) != 0) var3 -= y;
                if ((var5 & 32) != 0) var4 -= z + 1;
                else if ((var5 & 2) != 0) var4 -= z >> 1;
            }

            int var9 = var3;
            int var10 = var4;
            bool var11 = false;
            for (int var12 = 0; var12 < var2.Length; var12++)
            {
                if (!var18 && (var5 & 1) != 0)
                {
                    var18 = true;
                    if ((var7 = var2.IndexOf('\n', var12)) != -1) this.m_a(var2.Substring(var12, var7 - var12));
                    else this.m_a(var2.Substring(var12));
                    var9 -= y >> 1;
                }

                int var13;
                if ((var13 = var2[var12] & 255) == 32)
                {
                    var9 += (this.b[0] & 255) + this.g[1];
                }
                else if (var13 == 10)
                {
                    var18 = false;
                    var9 = var3;
                    var10 += this.B + (this.c[0] & 255);
                }
                else
                {
                    if (var13 == 123) { var13 = -1; var11 = true; }
                    else if (var13 == 125) { var13 = -1; var11 = false; }
                    else
                    {
                        try { var13 = this.A[var13] & 255; }
                        catch (Exception) { var13 = 0; }
                    }
                    if (var13 > 0)
                    {
                        int var14 = this.g[var13 << 2] & 255;
                        this.m_a(var1, 0, var13, var9, var10, 0);
                        if (var11)
                        {
                            this.m_a(var1, 0, var13, var9 + 1, var10, 0);
                            var9 += this.g[1];
                        }
                        var9 += (this.b[var14] & 255) - this.g[(var13 << 2) + 1] + this.g[1];
                    }
                }
            }
        }

        // ---- multiline text (original b(Graphics,String,int,int,int,int)) ----
        internal void m_b(Graphics var1, string var2, int var3, int var4, int var5, int var6)
        {
            int var7 = 0;
            int var8 = var2.Length;
            int[] var9 = new int[100];
            for (int var10 = 0; var10 < var8; var10++)
            {
                if (var2[var10] == '\n' || var2[var10] == '|') var9[var7++] = var10;
            }
            var9[var7++] = var8;
            int var11 = 0;
            int var12 = this.B + (this.c[0] & 255);
            if ((var5 & 32) != 0) var4 -= var12 * (var7 - 1);
            else if ((var5 & 2) != 0) var4 -= var12 * (var7 - 1) >> 1;
            for (int var13 = 0; var13 < var7; var13++)
            {
                int var15 = var13 > 0 ? var9[var13 - 1] + 1 : 0;
                var11 = var9[var13];
                this.m_a(var1, var2.Substring(var15, var11 - var15), var3, var4 + var13 * var12, var5, var6);
            }
        }
    }
}
