// Port of original class g (validated decompile_vf/g.java).
// R1 m_ renames (field/method collisions): a b c d e f h i j k l m n o p q r s t -> m_* (all overloads).
//   NOTE: `i` was MISSING from PORTING.md's g-row (collisions.py skipped the multi-line `static int[] i` initializer);
//   CS0102 forces the same m_ rule -> f.cs call site `MiamiNights.g.i()` must become `MiamiNights.g.m_i()`.
// R5: static field `g` (sbyte[] table) renamed `g_`; methods named `g` KEEP name `g`.
//   -> h.cs must read the table as `MiamiNights.g.g_[...]` (was `MiamiNights.g.g[...]`).
// byte -> sbyte throughout; MIDP Graphics -> engine PascalCase; Vector -> shim (lowercase API kept).
using System;

namespace MiamiNights
{
    public sealed class g
    {
        internal int[] a;
        internal sbyte[] b;
        internal int[] c;
        internal int[] d;
        internal sbyte[] e;
        internal static sbyte[] f = null;
        internal static sbyte[] g_ = new sbyte[]{
           4, 0, 1, 2, 5, 6, 9, 11, 3, 28, 30, 31, 12, 7, 10, 14, 19, 16, 17, 8, 15, 13, 18, 29, 20, 22, 23, 24, 27, 26, 25, 21, 32, 33, 34, 35, 36, 37, 38
        };
        internal static sbyte[] h = new sbyte[]{0, 0, 0, 6, 0, 0, 0, 5, 5, 0, 5, 6, 5, 5, 5, 5, 5, 5, 5, 5, 2, 5, 2, 2, 1, 3, 3, 1, 6, 5, 6, 6, 4, 4, 2, 2, 2, 2, 2};
        internal static int[] i = new int[]{
           0,
           60,
           70,
           80,
           90,
           100,
           110,
           60,
           0,
           70,
           80,
           90,
           100,
           110,
           70,
           60,
           0,
           80,
           70,
           60,
           80,
           80,
           90,
           100,
           0,
           60,
           80,
           90,
           80,
           80,
           70,
           60,
           0,
           70,
           80,
           100,
           90,
           60,
           80,
           60,
           0,
           60,
           110,
           90,
           70,
           110,
           90,
           60,
           0
        };
        internal static sbyte[] j;
        internal sbyte[] k;
        internal sbyte[] l;
        internal sbyte[] m;
        internal int[] n;
        internal int[] o;
        internal static long p;
        internal static long[] q;
        internal sbyte[] r;
        internal bool s;
        internal int t;
        internal static int u = -1;
        internal static int v = 0;
        internal static int w = 0;
        internal static g x;
        internal d y;
        internal d z;
        internal bool A;
        internal static sbyte[] B = new sbyte[]{13, 16, 17, 19, 20, 30};
        internal static int C;
        internal static int D;
        internal static sbyte[] E;
        internal static int[] F;
        internal static int[] G = new int[25];
        internal static int H = -1;
        internal static int[] I = new int[168];
        internal static int J;
        internal static sbyte K;
        internal static int L;
        internal static string M;
        internal static Vector<string> N = new Vector<string>();
        internal static int O;
        internal static sbyte P;
        internal static int Q = 0;
        internal static long R;
        internal static d S;
        internal static d T;
        internal static Image[] U = new Image[4];
        internal static sbyte V;
        internal static sbyte W;
        internal static sbyte[] X = new sbyte[]{1, 3, 4};
        internal static sbyte[] Y = new sbyte[]{1, 3, 6, 7, 8, 12};
        internal static Image[] Z;
        internal static sbyte aa;
        internal static string ab;
        internal static string ac;
        internal static string ad;
        internal static int ae;
        internal static long af;
        internal static long[] ag = new long[16];
        internal static sbyte[] ah = new sbyte[39];
        internal static bool[] ai = new bool[39];
        internal static short[][] aj = new short[][]{
           new short[]{13},
           new short[]{1, 1, 505},
           new short[]{10, 10, 506},
           new short[]{25, 25, 508},
           new short[]{45, 45, 510, 756},
           new short[]{60, 60, 512},
           new short[]{85, 85, 514},
           new short[]{16},
           new short[]{1, 1, 516},
           new short[]{10, 10, 517},
           new short[]{25, 25, 519},
           new short[]{35, 35, 521, 757},
           new short[]{60, 60, 523},
           new short[]{80, 80, 525},
           new short[]{17},
           new short[]{10, 10, 528},
           new short[]{25, 25, 530},
           new short[]{45, 45, 532},
           new short[]{60, 60, 534},
           new short[]{90, 90, 536},
           new short[]{19},
           new short[]{10, 10, 539},
           new short[]{20, 20, 541},
           new short[]{40, 40, 543},
           new short[]{61, 61, 545},
           new short[]{85, 85, 547},
           new short[]{20},
           new short[]{10, 10, 551},
           new short[]{20, 20, 549},
           new short[]{25, 25, 553},
           new short[]{40, 40, 555},
           new short[]{60, 60, 557},
           new short[]{95, 95, 559},
           new short[]{30},
           new short[]{1, 1, 572},
           new short[]{10, 10, 573},
           new short[]{20, 20, 575},
           new short[]{35, 35, 577, 759},
           new short[]{45, 45, 579},
           new short[]{70, 70, 581},
           new short[]{95, 95, 583}
        };
        internal static string ak;
        internal static sbyte al;
        internal static sbyte[] am = new sbyte[]{
           12, 12, 12, 18, 1, 13, 1, 1, 1, 11, 8, 18, 1, 1, 8, 1, 1, 12, 1, 8, 1, 4, 11, 13, -1, 10, 5, -1, 18, 15, 18, 18, 6, -1, 11, 11, 9, 11, 11
        };
        internal sbyte[] an;
        internal static sbyte ao;
        internal static sbyte[] ap;
        internal static short[] aq = new short[16];
        internal static sbyte ar;
        internal static sbyte[] @as;
        internal static sbyte[] at;
        internal static bool au;
        internal int[] av;

        internal void m_a()
        {
            this.e = new sbyte[3];
            this.e[0] = MiamiNights.f.K;
            this.e[1] = this.b[14];
        }

        internal bool m_b()
        {
            return this.b[20] == 1 && (this.e == null || this.a[43] != 127 || this.e[0] == MiamiNights.f.K || this.b[19] == 1);
        }

        internal void m_a(int var1, int var2)
        {
            int var3 = this.c[0] >> 8;
            int var4 = this.c[1] >> 8;
            int var5 = var3 + var4 * MiamiNights.f.t;
            MiamiNights.f.k[var5] = (short)(MiamiNights.f.k[var5] & -15873);
            this.c[0] = var1;
            this.c[1] = var2;
            if (var1 != -255)
            {
                var3 = this.c[0] >> 8;
                var4 = this.c[1] >> 8;
                var5 = var3 + var4 * MiamiNights.f.t;
                MiamiNights.f.k[var5] = (short)(MiamiNights.f.k[var5] & -15873);
                MiamiNights.f.k[var5] = (short)(MiamiNights.f.k[var5] | (this.b[6] & 255) << 9);
            }
        }

        internal void m_a(Graphics var1, bool var2)
        {
            if (MiamiNights.h.h_ != 18)
            {
                int[] var3 = new int[]{0, 0};
                d var4 = MiamiNights.h.n[this.b[5]];
                MiamiNights.f.m_a(this.c[0], this.c[1], var3);
                int var5 = 1 + (this.b[2] & 255) * 5;
                int var6;
                if ((var6 = MiamiNights.f.aL[var5 + 4] & 255) != 255)
                {
                    if (this.y == null)
                    {
                        this.y = new d(MiamiNights.h.u[1], 0, -63, var4);
                    }

                    if (this.z == null)
                    {
                        this.z = new d(MiamiNights.h.u[1], 0, 0, null);
                    }

                    this.y.m_a(var6);
                    this.z.m_a(var6);
                }
                else
                {
                    this.y = null;
                }

                var4.a = var3[0] + 0 << 8;
                var4.b = var3[1] + 75 << 8;
                if (var4.e == 67)
                {
                    if (var4.c != 0)
                    {
                        var4.b += 1536;
                        var4.a -= 2560;
                    }
                    else
                    {
                        var4.b += 1536;
                        var4.a += 1536;
                    }
                }

                if (!var2)
                {
                    this.d = var4.m_c();
                    this.d[0] = this.d[0] >> 8;
                    this.d[1] = this.d[1] >> 8;
                    this.d[2] = this.d[2] >> 8;
                    this.d[3] = this.d[3] >> 8;
                    this.s = false;
                    if (MiamiNights.f.m_a(this.d[0], this.d[1], this.d[2], this.d[3], 0, 75, 240, 315))
                    {
                        this.s = true;
                        var4.d_.m = this.b[15];
                        var4.m_a(var1);
                        MiamiNights.f.m_a(var1, this);
                        if (this.y != null && MiamiNights.h.y == 0 && MiamiNights.f.al == this.b[6])
                        {
                            var1.SetClip(0, 75, 240, 240);
                            if (this.y.e < 63)
                            {
                                MiamiNights.f.m_a(var4, var4.c == 0);
                                d var7;
                                (var7 = MiamiNights.h.v[18]).m_a(30);
                                var7.f = 1;
                                var7.d_.m_a(var1, 30, 1, var7.a >> 8, var7.b >> 8, var7.c, 0, 0);
                                int[] var12 = var7.m_c();
                                this.z.a = var12[0];
                                this.z.b = var12[1];
                                this.z.m_a(var1);
                                this.z.m_b();
                                var7.e = -1;
                                return;
                            }

                            this.y.m_a(var1);
                            this.y.m_b();
                        }
                    }
                }
                else if (this.s)
                {
                    var1.SetClip(0, 75, 240, 240);
                    if (this == x)
                    {
                        d var8;
                        int var9;
                        if ((var9 = (var8 = MiamiNights.h.v[18]).e) == -1)
                        {
                            var8.m_a(29);
                        }
                        else if (var8.m_a() && var9 == 29)
                        {
                            var8.m_a(30);
                            var9 = 255;
                        }
                        else
                        {
                            var9 = 255;
                        }

                        var8.m_a(var1);
                        if (!var8.m_a())
                        {
                            var8.m_b();
                        }

                        if (var9 == 255)
                        {
                            int[] var10 = var8.m_c();
                            d var11;
                            (var11 = MiamiNights.h.v[17]).a = var10[0];
                            var11.b = var10[1];
                            var11.m_a(var1);
                            if (!var11.m_a())
                            {
                                var11.m_b();
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (MiamiNights.h.y == 0 && MiamiNights.f.av == this.b[6])
                        {
                            MiamiNights.f.m_a(var1, var4, true, false, true, this);
                            return;
                        }

                        MiamiNights.f.m_a(var1, var4, false, false, false, this);
                    }
                }
            }
        }

        private void m_b(int var1, bool var2)
        {
            int var4 = MiamiNights.f.m_d(var1, 0);
            this.a[0] = MiamiNights.f.aK[var4 + 1];
            int var6 = MiamiNights.f.aK[0] & 255;
            int var7 = MiamiNights.f.aK[1 + var6 * 2] & 255;
            var4 = MiamiNights.f.m_d(var1, 1);

            for (int var3 = 1; var3 < var7; var3++)
            {
                int var8 = MiamiNights.f.aK[1 + var6 * 2 + 1 + var3] & 255;
                bool var11 = true;
                if (!var2 && (var8 >= 4 && var8 <= 11 || var8 > 35))
                {
                    var11 = false;
                }

                if (var8 == 41)
                {
                    var11 = true;
                }

                int var9;
                int var10;
                if ((var10 = (var9 = MiamiNights.f.aK[var4++] & 255) & 3) == 0)
                {
                    if (var11)
                    {
                        this.a[var8] = MiamiNights.f.aK[var4];
                    }

                    var4++;
                }
                else if (var10 == 1)
                {
                    if (var11)
                    {
                        this.a[var8] = GloftMMN.m_c(MiamiNights.f.aK[var4], MiamiNights.f.aK[var4 + 1] + 1);
                    }

                    var4 += 2;
                }
                else if (var10 == 2)
                {
                    var9 = (var9 & 252) >> 2;

                    for (int var12 = GloftMMN.m_c(0, var9); var9-- > 0; var12--)
                    {
                        if (var12 == 0 && var11)
                        {
                            this.a[var8] = MiamiNights.f.aK[var4];
                        }

                        var4++;
                    }
                }

                if (var8 >= 13 && var8 <= 33 && var8 <= 26 || var8 == 41)
                {
                    this.a[var8] = this.a[var8] * (MiamiNights.f.bc[17] + 100) / 100;
                    int var17 = m_d(var8, 3);
                    if (this.a[var8] >= var17)
                    {
                        this.a[var8] = var17 - 1;
                    }
                }
            }

            C = MiamiNights.f.m_d(var1, -1);
            this.k = m_a((sbyte[])null);
            this.l = m_a((sbyte[])null);
            this.m = m_a(this.l);
            int var13;
            if ((var13 = MiamiNights.f.m_d(var1)) >= 0)
            {
                this.a[1] = 474 + var13;
            }
            else if (this.a[0] == 0)
            {
                this.a[1] = GloftMMN.m_c(402, 417);
            }
            else
            {
                this.a[1] = GloftMMN.m_c(417, 429);
            }

            if (!var2)
            {
                this.a[39] = 0;
                this.a[42] = 0;

                for (int var14 = 0; var14 < this.r.Length; var14++)
                {
                    this.r[var14] = 0;
                }
            }
        }

        internal g(int var1, int var2, int var3, bool var4, bool var5)
        {
            try
            {
                this.d = new int[4];
                this.r = new sbyte[112];
                this.b = new sbyte[21];
                this.b[7] = -1;
                this.a = new int[D];
                this.n = new int[2];
                this.o = new int[2];
                if (!var4)
                {
                    this.b[4] = -1;
                    this.b[6] = (sbyte)var2;
                    this.b[18] = -1;
                    this.b[20] = 1;
                }

                if (var2 == 0)
                {
                    q = new long[D];

                    for (int var6 = 0; var6 < D; var6++)
                    {
                        q[var6] = -1L;
                    }

                    for (int var9 = 0; var9 < D; var9++)
                    {
                        this.a[var9] = m_d(var9, 4);
                        if (var9 == 35)
                        {
                            this.a[var9] = this.a[var9] * 5;
                        }
                    }

                    q[28] = 75L;
                    q[25] = 60L;
                    q[24] = 180L;
                    q[22] = 70L;
                    q[29] = 115L;
                    q[26] = 120L;
                    this.m_r();
                }
                else if (!var4)
                {
                    this.b[13] = (sbyte)var3;
                    this.m_b(var3, true);
                    var1 = 7 + this.a[0] * 2;
                }

                if (!var4)
                {
                    this.b[0] = (sbyte)var1;
                }

                this.c = new int[2];
                this.c[0] = 0;
                this.c[1] = 0;
                int var7 = (var1 - 7) / 2;
                if (!var4)
                {
                    if (var5)
                    {
                        this.m_a(var1, var2, true);
                    }

                    for (int var10 = 0; var10 < MiamiNights.h.n.Length; var10++)
                    {
                        if (MiamiNights.h.n[var10] == null)
                        {
                            this.b[5] = (sbyte)var10;
                            MiamiNights.h.n[var10] = new d(MiamiNights.h.o[var7], 0, 0, null);
                            if (var10 == 0)
                            {
                                MiamiNights.h.t[0] = new d(MiamiNights.h.o[var7], 0, 0, null);
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception var8)
            {
            }
        }

        internal void m_c()
        {
            this.a = null;
            MiamiNights.h.n[this.b[5]] = null;
            this.b = null;
            this.c = null;
            this.n = null;
            this.o = null;
            GC.Collect();
        }

        internal static void m_a(int var0, int var1, sbyte var2)
        {
            int var3;
            int var4 = (var3 = MiamiNights.h.s[0].a[0]) * 126;
            if (var0 >= 0)
            {
                MiamiNights.h.e[var4 + var0] = var2;
            }
            else
            {
                if (var1 >= 0)
                {
                    MiamiNights.h.e[var4 + 63 + var1] = var2;
                }
            }
        }

        internal static int m_b(int var0, int var1)
        {
            int var2;
            int var3 = (var2 = MiamiNights.h.s[0].a[0]) * 126;
            return var0 != -1 ? MiamiNights.h.e[var3 + var0] : MiamiNights.h.e[var3 + 63 + var1];
        }

        internal void m_a(int var1, int var2, bool var3)
        {
            bool var4 = MiamiNights.h.H == 30 && MiamiNights.f.bc[2] >= 8 && MiamiNights.f.bc[2] <= 19;
            g var8 = this;
            int var9 = (var1 - 7) / 2;
            a var10 = MiamiNights.h.o[var9];
            sbyte var11 = j[var9];
            if (var3)
            {
                this.b[15] = (sbyte)var11;
            }

            if (var10.w == null)
            {
                var10.w = new Image[var10.l][];
            }

            int[] var12 = new int[6];
            int[] var13 = new int[6];

            for (int var5 = 0; var5 < 6; var5++)
            {
                var12[var5] = -1;
            }

            if (var2 == 0)
            {
                var12[4] = this.a[8] + 1;
                var13[4] = this.a[9] & 0xFF;
                var12[5] = this.a[4] + 1;
                var13[5] = this.a[5] & 0xFF;
                var12[3] = 1;
                var13[3] = ((this.a[9] & 0xFF) + 40) % MiamiNights.h.p[var9][4].l;
                if (this.a[6] != -1)
                {
                    sbyte var14 = MiamiNights.h.a[var9][this.a[6] * 3 + 0];
                    sbyte var15 = MiamiNights.h.a[var9][this.a[6] * 3 + 1];
                    sbyte var16 = MiamiNights.h.a[var9][this.a[6] * 3 + 2];
                    this.a[43] = var14;
                    var12[2] = var14 + 1;
                    var13[2] = this.a[7] & 0xFF;
                    this.a[44] = var15;
                    var12[0] = var15 + 1;
                    var13[0] = (this.a[7] & 0xFF) + var16;
                    var13[0] %= MiamiNights.h.p[var9][0].l;
                }

                if (this.a[6] == -1 || MiamiNights.h.H == 36)
                {
                    var12[2] = 0;
                    var12[0] = 0;
                    var12[4] = 0;
                }

                var12[1] = var12[0];
                var13[1] = var13[0] & 0xFF;
                a var37 = MiamiNights.h.p[0][5];
                sbyte var42 = MiamiNights.h.r[0][5];
                int var32;
                var32 = ((var32 = var37.a_ / var42) - 1) * var42;
                Z = new Image[var42];

                for (int var45 = var32; var45 < var32 + var42; var45++)
                {
                    var37.m_a(var13[5] & 0xFF, var45, var45, -1, var37.l - 2);
                    Z[var45 - var32] = var37.w[var37.l - 2][var45];
                }
            }
            else
            {
                if (!var3)
                {
                    int[] var44 = new int[6];

                    for (int var40 = 0; var40 < 6; var40++)
                    {
                        var44[var40] = -1;
                    }

                    sbyte var47 = this.b[15];
                    int[] var48 = new int[6];

                    for (int var41 = 0; var41 < var10.a_; var41++)
                    {
                        sbyte var49;
                        if ((var49 = MiamiNights.h.q[var9][var41]) > 0 && var49 != 0 && var49 != 1 && var49 != 3 && var49 != 5)
                        {
                            while (var44[var49] == -1)
                            {
                                for (int var35 = 1; var35 < MiamiNights.h.s.Length; var35++)
                                {
                                    if ((var8 = MiamiNights.h.s[var35]) != null && var8.a[0] == this.a[0] && (var8.b[20] != 0 || var35 == 0) && GloftMMN.m_c(0, 100) <= 10)
                                    {
                                        var44[var49] = var35;
                                        break;
                                    }
                                }
                            }

                            int var50 = -1;
                            bool var51 = true;
                            if (var49 == 2)
                            {
                                var50 = var8.a[6];
                            }
                            else if (var49 == 5)
                            {
                                var50 = var8.a[4];
                                int var52 = MiamiNights.h.p[var9][5].a_ / MiamiNights.h.r[var9][5] - 2;
                                if (var50 >= var52)
                                {
                                    var51 = false;
                                }
                            }
                            else if (var49 == 4)
                            {
                                var50 = var8.a[8];
                            }

                            if (var51)
                            {
                                a var36 = MiamiNights.h.p[var9][var49];
                                int var53;
                                var53 = (var53 = var48[var49]) + var50 * MiamiNights.h.r[var9][var49];
                                var10.w[var47][var41] = var36.w[0][var53];
                            }

                            var48[var49]++;
                        }
                    }

                    return;
                }

                g var38 = MiamiNights.h.s[0];
                var12[2] = this.a[6] + 1;
                var13[2] = this.a[7] & 0xFF;
                var12[4] = this.a[8] + 1;
                var13[4] = this.a[9] & 0xFF;
                var12[5] = this.a[4] + 1;
                var13[5] = this.a[5] & 0xFF;
                if (var4)
                {
                    var12[2] = 0;
                    var13[2] = 0;
                    var12[4] = 0;
                    var13[4] = 0;
                }

                if (this.a[0] == 0)
                {
                    var12[3] = 1;
                }
                else
                {
                    var12[3] = var38.a[10] + 1;
                }

                var13[3] = var38.a[11] & 0xFF;
                var12[0] = 0;
                var13[0] = 0;
                var12[1] = var12[0];
                var13[1] = var13[0];
            }

            int[] var39 = new int[6];
            a var43 = MiamiNights.h.o[0];
            object var46 = null;
            bool var17 = false;
            bool var18 = false;
            bool var19 = false;
            bool var20 = false;
            if (var10.w[var11] == null)
            {
                var10.w[var11] = new Image[var10.a_];
            }

            for (int var34 = 0; var34 < var10.a_; var34++)
            {
                sbyte var21;
                if ((var21 = MiamiNights.h.q[var9][var34]) == -1)
                {
                    int var24;
                    if (var9 == 0)
                    {
                        var24 = var34;
                    }
                    else
                    {
                        var24 = var34 - 69 + 64;
                    }

                    if (var24 >= 64 && var24 < 113)
                    {
                        if (var43.w == null || var43.w[0] == null || var43.w[0][var24] == null)
                        {
                            var43.m_a(0, var24, var24, -1, 0);
                        }

                        var10.w[var11][var34] = var43.w[0][var24];
                    }
                    else
                    {
                        bool var25 = true;
                        if (var4)
                        {
                            if (var24 >= 113)
                            {
                                var25 = true;
                            }
                        }
                        else if (var24 >= 113)
                        {
                            var25 = false;
                        }

                        if (var25)
                        {
                            if (var10.w == null || var10.w[0] == null || var10.w[0][var34] == null)
                            {
                                var10.m_a(0, var34, var34, -1, 0);
                            }

                            var10.w[var11][var34] = var10.w[0][var34];
                        }
                    }
                }
                else if (var12[var21] == 0)
                {
                    int var23 = var10.l - 1;
                    if (var10.w == null || var10.w[var23] == null || var10.w[var23][var34] == null)
                    {
                        var10.m_a(0, var34, var34, -1, var23);
                    }

                    if (var10.w[var11] == null)
                    {
                        var10.w[var11] = new Image[var10.a_];
                    }

                    var10.w[var11][var34] = var10.w[var23][var34];
                }
                else
                {
                    a var7 = MiamiNights.h.p[var9][var21];
                    int var55 = var39[var21];
                    object var57 = null;
                    int var58 = var9;
                    int var26 = var12[var21];
                    bool var27 = false;
                    if (var21 == 5)
                    {
                        int var29 = var12[5] - 1;
                        int var30 = MiamiNights.h.p[var9][5].a_ / MiamiNights.h.r[var9][5];
                        if (this.a[0] == 0)
                        {
                            var30--;
                        }

                        var8.b[1] = (sbyte)var30;
                        bool var31;
                        if (var31 = this.a[0] == 0)
                        {
                            var8.b[1] = (sbyte)(var8.b[1] + X.Length);
                        }
                        else
                        {
                            var8.b[1] = (sbyte)(var8.b[1] + Y.Length);
                        }

                        int var28;
                        if (var31)
                        {
                            var28 = var30 - 1;
                        }
                        else
                        {
                            var28 = var8.b[1] - 1;
                        }

                        if (var29 == var8.b[1] - 1)
                        {
                            var27 = true;
                            if (!var31)
                            {
                                var58 = 0;
                                var29 = Y[var29 - var30];
                            }
                            else
                            {
                                var29 = var28;
                            }
                        }
                        else if (var29 >= var28 && this.a[0] == 0)
                        {
                            var29++;
                        }

                        if (!var27 && var29 >= var30)
                        {
                            var29 -= var30;
                            if (var31)
                            {
                                var58 = 1;
                                var29 = X[var29];
                            }
                            else
                            {
                                var58 = 0;
                                var29 = Y[var29];
                            }
                        }

                        var7 = MiamiNights.h.p[var58][var21];
                        var12[var21] = var29 + 1;
                    }

                    var55 += (var12[var21] - 1) * MiamiNights.h.r[var58][var21];
                    if (MiamiNights.h.h_ == 17 || MiamiNights.h.h_ == 18 || var7.w == null || var7.w[0] == null || var7.w[0][var55] == null)
                    {
                        var7.m_a(var13[var21], var55, var55, -1, 0);
                    }

                    if (var10.w[var11] == null)
                    {
                        var10.w[var11] = new Image[var10.a_];
                    }

                    var10.w[var11][var34] = var7.w[0][var55];
                    var39[var21]++;
                    var12[var21] = var26;
                }
            }

            j[var9]++;
        }

        internal static void m_a(bool var0)
        {
            if (!var0)
            {
                MiamiNights.h.p = new a[2][];
            }

            for (int var1 = 0; var1 < 2; var1++)
            {
                if (!var0)
                {
                    if (var1 == 0)
                    {
                        GloftMMN.m_b("/5");
                    }
                    else
                    {
                        GloftMMN.m_b("/6");
                    }

                    MiamiNights.h.p[var1] = new a[6];
                }

                for (int var2 = 0; var2 < 6; var2++)
                {
                    if (!var0)
                    {
                        MiamiNights.h.m_a(0 + var2, MiamiNights.h.p[var1], var2, false, false, 1, false);
                        a var4;
                        (var4 = MiamiNights.h.p[var1][var2]).h = null;
                        var4.i = null;
                        var4.d = null;
                        var4.e = null;
                        var4.f = null;
                        var4.i = null;
                        var4.j = null;
                        var4.g = null;
                        GC.Collect();
                    }
                    else
                    {
                        MiamiNights.h.p[var1][var2].m_b();
                        MiamiNights.h.p[var1][var2].m_c();
                    }
                }

                if (!var0)
                {
                    GloftMMN.m_f();
                }
            }

            if (!var0)
            {
                GloftMMN.m_b("/7");
                a var3;
                if ((var3 = MiamiNights.h.p[0][0]).l == 1)
                {
                    GloftMMN.m_h(0);
                    int var14 = GloftMMN.m_g();
                    var3.l = var14;
                    var3.k = new int[var14][];
                    sbyte[] var5 = new sbyte[16];

                    for (int var6 = 0; var6 < var14; var6++)
                    {
                        GloftMMN.m_a(var5, 0, 16);
                        var3.k[var6] = new int[8];

                        for (int var10 = 0; var10 < 8; var10++)
                        {
                            var3.k[var6][var10] = MiamiNights.f.m_a(var5[var10 * 2 + 0] & 255 | (var5[var10 * 2 + 1] & 255) << 8);
                        }
                    }

                    for (int var7 = 0; var7 < 2; var7++)
                    {
                        for (int var11 = 0; var11 < 6; var11++)
                        {
                            if (var11 != 5)
                            {
                                MiamiNights.h.p[var7][var11].k = MiamiNights.h.p[0][0].k;
                                MiamiNights.h.p[var7][var11].l = var14;
                            }
                        }
                    }

                    GloftMMN.m_h(1);
                    var14 = GloftMMN.m_g();
                    (var3 = MiamiNights.h.p[0][5]).l = var14;
                    var3.k = new int[var14][];

                    for (int var8 = 0; var8 < var14; var8++)
                    {
                        GloftMMN.m_a(var5, 0, 16);
                        var3.k[var8] = new int[8];

                        for (int var12 = 0; var12 < 8; var12++)
                        {
                            var3.k[var8][var12] = MiamiNights.f.m_a(var5[var12 * 2 + 0] & 255 | (var5[var12 * 2 + 1] & 255) << 8);
                        }
                    }

                    for (int var9 = 0; var9 < 2; var9++)
                    {
                        MiamiNights.h.p[var9][5].k = MiamiNights.h.p[0][5].k;
                        MiamiNights.h.p[var9][5].l = var14;
                    }
                }

                GloftMMN.m_f();
            }
        }

        internal void m_c(int var1, int var2)
        {
            if (var1 == 35)
            {
                int var6;
                H = var6 = this.a[35];
                this.a[35] = this.a[35] + var2;
                if (this.a[35] < 0)
                {
                    this.a[35] = 0;
                }

                if (this.a[35] > 1000000000)
                {
                    this.a[35] = 1000000000;
                }

                this.m_b(35, var6, this.a[35]);
            }
            else
            {
                int var3 = m_d(var1, 2);
                int var4 = m_d(var1, 3);
                int var5 = this.a[var1];
                this.a[var1] = this.a[var1] + var2;
                if (this.a[var1] < var3)
                {
                    this.a[var1] = var3;
                }

                if (this.a[var1] > var4)
                {
                    this.a[var1] = var4;
                }

                if (var1 == 39 || this.a[var1] != var5)
                {
                    this.m_b(var1, var5, this.a[var1]);
                }
            }
        }

        internal static int m_d(int var0, int var1)
        {
            int var2 = F[var0];
            if (var1 > 0)
            {
                if (var1 == 1)
                {
                    var2 += 2;
                }
                else if (var1 == 2)
                {
                    var2 += 3;
                }
                else if (var1 == 3)
                {
                    var2 += 4;
                }
                else if (var1 == 4)
                {
                    var2 += 5;
                }
                else if (var1 == 5)
                {
                    var2 += 6;
                }

                if (var1 != 2 && var1 != 3)
                {
                    return E[var2] & 0xFF;
                }
                else
                {
                    return var0 != 36 && var0 != 37 && var0 != 38 ? E[var2] : E[var2] & 0xFF;
                }
            }
            else
            {
                return E[var2 + 0] & 0xFF | (E[var2 + 1] & 0xFF) << 8;
            }
        }

        internal static int m_e(int var0, int var1)
        {
            int var2 = m_d(var0, 5);

            for (int var3 = 0; var3 < var2; var3++)
            {
                int var4 = F[var0] + 7 + var3 * 4;
                sbyte var5 = E[var4 + 2];
                sbyte var6 = E[var4 + 3];
                int var7 = E[var4 + 0] & 255 | (E[var4 + 1] & 255) << 8;
                if (var1 >= var5 && var1 <= var6)
                {
                    return var7;
                }
            }

            return -1;
        }

        internal static void m_a(int var0, int var1, int[] var2)
        {
            int var3 = m_d(var0, 5);

            for (int var4 = 0; var4 < var3; var4++)
            {
                int var5 = F[var0] + 7 + var4 * 4;
                sbyte var6 = E[var5 + 2];
                sbyte var7 = E[var5 + 3];
                if (var1 >= var6 && var1 <= var7)
                {
                    var2[0] = E[var5 + 2];
                    var2[1] = E[var5 + 3];
                    var2[2] = var4;
                    return;
                }
            }
        }

        internal static void m_d()
        {
            GloftMMN.m_b("/4");
            E = GloftMMN.m_j(0);
            D = E[0];
            F = new int[D];
            int var1 = 1;

            for (int var0 = 0; var0 < D; var0++)
            {
                F[var0] = var1;
                var1 += E[var1 + 6] * 4;
                var1 += 7;
            }
        }

        private static void m_i(int var0, int var1)
        {
            m_a(GloftMMN.m_k(var0), var1);
        }

        internal static void m_a(string var0, int var1)
        {
            ad = var0;
            if (ad[0] == '~')
            {
                ad = ad.Substring(1, ad.Length - 1);
            }

            ae = var1 & 0xFF | 256;
            af = MiamiNights.f.aT;
        }

        internal static void m_a(int var0)
        {
            if (var0 == 884)
            {
                if (MiamiNights.f.bb[11] != 0)
                {
                    return;
                }

                MiamiNights.f.bb[11] = 1;
            }

            m_a(GloftMMN.m_k(var0));
        }

        private void m_q()
        {
            int var2 = 0;
            int[] var3 = new int[]{13, 19, 30};

            for (int var1 = 1; var1 < 3; var1++)
            {
                if (this.a[var3[var1]] > this.a[var3[var2]])
                {
                    var2 = var1;
                }
            }

            if ((var2 = var3[var2]) == 13)
            {
                ab = GloftMMN.m_k(843);
            }
            else if (var2 == 19)
            {
                ab = GloftMMN.m_k(844);
            }
            else
            {
                ab = GloftMMN.m_k(845);
            }

            ac = GloftMMN.m_k(m_d(this.k[0] & 255, 0));
        }

        internal static void m_b(bool var0)
        {
            long var1 = MiamiNights.f.aT;
            if (!var0)
            {
                sbyte var4;
                if (((var4 = MiamiNights.f.bc[2]) < 22 || var4 > 23) && (var4 < 0 || var4 >= 8))
                {
                    ah[29] = 1;
                    ah[9] = 1;
                    ah[32] = 1;
                    ah[33] = 1;
                }
                else
                {
                    ah[29] = 0;
                    ah[9] = 0;
                    ah[32] = 0;
                    ah[33] = 0;
                }

                if (var4 >= 2 && var4 < 11)
                {
                    ah[21] = 0;
                }
                else
                {
                    ah[21] = 1;
                }

                if (MiamiNights.h.y == 0 && MiamiNights.h.z == -1)
                {
                    for (int var5 = 0; var5 < 5; var5++)
                    {
                        long var6;
                        if ((var6 = ag[var5]) > 0L && var1 >= var6)
                        {
                            bool var8 = true;
                            switch (var5)
                            {
                                case 0:
                                    if ((MiamiNights.h.H < 0 || MiamiNights.h.H > 2) && MiamiNights.h.H != 5)
                                    {
                                        if (MiamiNights.f.bc[6] != 3 && MiamiNights.f.bc[0] < 40)
                                        {
                                            m_a(498);
                                            m_a(499);
                                            m_f(6, 1);
                                            ah[0] = 0;
                                            ah[1] = 0;
                                            var8 = false;
                                            ag[0] = MiamiNights.f.aT + 4320000L;
                                        }
                                    }
                                    else
                                    {
                                        var8 = false;
                                    }
                                    break;
                                case 1:
                                    m_f(1, 1);
                                    m_a(847);
                                    m_a(500);
                                    m_a(501);
                                    m_a(502);
                                    m_a(503);
                                    m_a(504);
                                    m_a(935);
                                    m_a(936);
                                    goto case 2;
                                case 2:
                                default:
                                    break;
                                case 3:
                                    m_f(4, 12);
                                    m_a(652);
                                    aa = 5;
                                    if (MiamiNights.h.s[0].a[0] == 1)
                                    {
                                        m_a(GloftMMN.m_k(647) + " " + GloftMMN.m_k(648) + " " + GloftMMN.m_k(649), 2);
                                    }
                                    else
                                    {
                                        m_a(GloftMMN.m_k(647) + " " + GloftMMN.m_k(648) + " " + GloftMMN.m_k(649), 13);
                                    }

                                    MiamiNights.f.bc[31] = 0;
                                    MiamiNights.h.m = 0;
                                    break;
                                case 4:
                                    m_a(846);
                                    m_f(13, 0);
                                    MiamiNights.h.s[0].m_c(24, -MiamiNights.h.s[0].a[24]);
                                    MiamiNights.h.m = 26;
                                    MiamiNights.f.bc[31] = 0;
                                    break;
                            }

                            if (var8)
                            {
                                ag[var5] = 0L;
                            }
                        }
                    }
                }
            }
        }

        internal static void m_e()
        {
            for (int var0 = 0; var0 < 39; var0++)
            {
                ah[var0] = 0;
                ai[var0] = true;
            }

            ah[1] = 1;
            ag[1] = MiamiNights.f.aT + 333L;
            MiamiNights.f.aT = 540000L;
            MiamiNights.f.aU = 100L;
            MiamiNights.f.aV = -1;
            if (MiamiNights.f.bo != null)
            {
                for (int var1 = 0; var1 < MiamiNights.f.bo.Length; var1++)
                {
                    MiamiNights.f.bo[var1] = 0;
                }
            }

            MiamiNights.h.s[0].a[35] = 50;
            aa = -1;
        }

        internal void m_f()
        {
            for (int var1 = 0; var1 < D; var1++)
            {
                if (q[var1] == 0L)
                {
                    switch (var1)
                    {
                        case 22:
                            this.m_c(22, -1);
                            q[22] = 70L;
                            goto case 23;
                        case 23:
                        case 27:
                        default:
                            break;
                        case 24:
                            this.m_c(24, -1);
                            q[24] = 180L;
                            break;
                        case 25:
                            this.m_c(25, 1);
                            q[25] = 60L;
                            break;
                        case 26:
                            this.m_c(26, -10);
                            q[26] = 120L;
                            break;
                        case 28:
                            this.m_c(28, 2);
                            q[28] = 75L;
                            break;
                        case 29:
                            if (MiamiNights.h.n[0].e != 56)
                            {
                                this.m_c(29, 6);
                            }

                            q[29] = 115L;
                            break;
                    }
                }
            }
        }

        private void m_b(int var1, int var2, int var3)
        {
            g var4 = MiamiNights.h.s[0];

            int var6;
            for (var6 = 0; var6 < aj.Length; var6++)
            {
                if (aj[var6].Length == 1 && aj[var6][0] == var1)
                {
                    var6++;

                    for (; var6 < aj.Length && aj[var6].Length != 1; var6++)
                    {
                        if (var3 >= aj[var6][0] && var2 < aj[var6][1])
                        {
                            m_a(aj[var6][2]);
                            if (aj[var6].Length == 4)
                            {
                                m_a(aj[var6][3]);
                            }
                        }
                    }
                    break;
                }
            }

            if (var6 == aj.Length)
            {
                int var7 = 0;
                if (var1 == 22)
                {
                    if (var3 < 36 && var2 > 37)
                    {
                        m_a(675);
                        var4.m_c(17, -2);
                    }
                    else if (var3 < 40)
                    {
                        var4.m_c(16, -2);
                    }
                }

                if (var1 == 24)
                {
                    if (var3 >= 50 && var2 < 50)
                    {
                        var4.m_a((sbyte)13, (sbyte)0, 799);
                    }
                    else if (var3 >= 80 && var2 < 80)
                    {
                        m_a(355);
                    }
                    else if (var3 < 50 && var2 >= 50)
                    {
                        var4.m_a((sbyte)13);
                    }
                }

                if (var1 == 25)
                {
                    if (var3 >= 50 && var2 < 50)
                    {
                        var4.m_a((sbyte)22, (sbyte)0, 800);
                    }
                    else if (var3 < 50)
                    {
                        var4.m_a((sbyte)22);
                    }
                    else if (var3 >= 85 && var2 < 85)
                    {
                        m_a(562);
                    }
                }

                if (var1 == 28)
                {
                    if (var3 >= 35 && var2 < 35)
                    {
                        var4.m_a((sbyte)34, (sbyte)0, 798);
                    }
                    else if (var3 < 35)
                    {
                        var4.m_a((sbyte)34);
                    }

                    if (var3 >= 55 && var2 < 55)
                    {
                        m_a(758);
                        var4.m_c(30, -3);
                    }

                    if (var3 >= 70 && var2 < 70)
                    {
                        m_a(569);
                    }
                    else if (var3 >= 85 && var2 < 85)
                    {
                        m_a(570);
                    }
                }

                if (var1 == 29)
                {
                    bool var8 = MiamiNights.h.n[0].e != 56;
                    if (var3 >= 55 && var2 < 55 && var8)
                    {
                        var4.m_a((sbyte)20, (sbyte)0, 801);
                        var4.m_c(16, -1);
                        m_a(676);
                    }
                    else if (var3 >= 55 && var3 >= var2 && var8)
                    {
                        var4.m_c(16, -1);
                        m_a(676);
                    }
                    else if (var3 < 50)
                    {
                        var4.m_a((sbyte)20);
                    }
                    else if (var3 >= 75 && var2 < 75 && var8)
                    {
                        m_a(571);
                    }
                }

                if (var1 == 35 && var3 >= 100 && var2 < 100 && MiamiNights.f.bc[0] < 6)
                {
                    m_f(0, 6);
                    m_f(6, 1);
                    if (MiamiNights.h.s[0].a[0] == 1)
                    {
                        m_i(612, 2);
                    }
                    else
                    {
                        m_i(612, 13);
                    }

                    aa = 0;
                    m_f(3, 3);
                }

                if (var1 == 36)
                {
                    if (var3 == 1 && var2 == 0)
                    {
                        m_a(677);
                    }

                    if (var3 > var2)
                    {
                        if (MiamiNights.f.bc[8] == 1 && MiamiNights.h.H == 14)
                        {
                            m_g(6, MiamiNights.f.bb[6] + 1);
                            if (MiamiNights.f.bb[6] == 1)
                            {
                                m_f(8, 4);
                                m_a(658);
                                if (MiamiNights.h.s[0].a[0] == 1)
                                {
                                    m_a(GloftMMN.m_k(659), 2);
                                }
                                else
                                {
                                    m_a(GloftMMN.m_k(659), 13);
                                }

                                au = true;
                                m_f(0, 24);
                            }
                            else
                            {
                                m_a(662);
                                au = true;
                            }
                        }

                        if (MiamiNights.f.av > 0 && MiamiNights.f.m_d(MiamiNights.h.s[MiamiNights.f.av].b[13]) == -1)
                        {
                            m_a(884);
                        }
                    }

                    if (var3 == 10 && MiamiNights.f.bc[17] < 10)
                    {
                        m_a(772);
                        m_f(17, 10);
                    }
                    else if (var3 == 20 && MiamiNights.f.bc[17] < 20)
                    {
                        m_a(772);
                        m_f(17, 20);
                    }
                    else if (var3 == 30 && MiamiNights.f.bc[17] < 30)
                    {
                        m_a(772);
                        m_f(17, 30);
                    }
                    else if (var3 == 35 && MiamiNights.f.bc[17] < 35)
                    {
                        m_a(772);
                        m_f(17, 40);
                    }
                    else if (var3 == 40 && MiamiNights.f.bc[17] < 40)
                    {
                        m_a(772);
                        m_f(17, 50);
                    }
                }

                if (var1 == 37 && MiamiNights.f.av > 0 && MiamiNights.f.m_d(MiamiNights.h.s[MiamiNights.f.av].b[13]) == -1)
                {
                    m_a(884);
                }

                if (var1 == 39)
                {
                    var7 = MiamiNights.f.m_d(this.b[13]);
                    sbyte var21 = MiamiNights.h.E[MiamiNights.h.D - 2];
                    sbyte var9 = MiamiNights.h.E[MiamiNights.h.D - 1];
                    int var10 = MiamiNights.f.m_c(var21, -1);
                    sbyte var11 = MiamiNights.f.aJ[var10 + 0];
                    var10 = MiamiNights.f.m_c(var21, var9);
                    sbyte var12 = MiamiNights.f.aJ[var10 + 0];
                    this.m_g();
                    if (var3 < var2 && this.a[40] < this.a[41] && this.a[42] > 0 && var7 == -1)
                    {
                        m_a(760);
                        var4.m_c(38, 1);
                        this.a[42] = 0;
                        return;
                    }

                    if ((var11 == 65 || var11 == 66) && this.a[42] == 0 && this.a[40] >= this.a[41] && !m_a(11, this, false))
                    {
                        m_a(637);
                    }

                    if (var11 == 67 && (var12 == 78 || var12 == 77) && this.a[42] == 0 && this.a[40] >= this.a[41] && var3 >= var2)
                    {
                        this.m_c(42, this.a[40]);
                    }

                    int var13 = m_e(39, var2);
                    int var14;
                    if ((var14 = m_e(39, var3)) > var13)
                    {
                        if (var14 > var13 && var13 < 287 && var14 > 286)
                        {
                            var4.m_c(36, 1);
                        }

                        if (var14 == 285)
                        {
                            if (!m_c(this))
                            {
                                if (var7 != -1)
                                {
                                    m_b(this);
                                }

                                if (var7 == 3 || var7 == 14)
                                {
                                    m_f(4, 1);
                                }
                            }
                        }
                        else if (var14 == 286)
                        {
                            if (var7 == 0)
                            {
                                m_a(497);
                                m_a(638);
                                m_f(5, 1);
                                ah[17] = 1;
                                MiamiNights.h.m = 17;
                            }
                            else if (var7 == 4 && MiamiNights.f.bc[3] < 2)
                            {
                                m_f(3, 2);
                                m_a(626);
                                m_a(627);
                                au = true;
                                int var18 = var4.a[35];
                                var4.m_c(35, 100);
                                MiamiNights.f.bo[70] = var18;
                                MiamiNights.f.bo[71] = var18 + 100;
                            }
                            else if (MiamiNights.f.bc[4] < 2 && (var7 == 3 || var7 == 14 || var7 == 9 || var7 == 15 || var7 == 10 || var7 == 16))
                            {
                                m_a(629);
                                m_a(639);
                                m_f(4, 2);
                                m_a(776);
                                if (MiamiNights.h.s[0].a[0] == 1)
                                {
                                    m_a(GloftMMN.m_k(663), 2);
                                }
                                else
                                {
                                    m_a(GloftMMN.m_k(663), 13);
                                }

                                aa = 0;
                                MiamiNights.h.m = 1;
                            }
                            else if (var7 == 8)
                            {
                                m_g(4, 1);
                                if (MiamiNights.f.bc[0] == 24)
                                {
                                    m_f(0, 25);
                                }

                                ah[19] = 1;
                                m_a(664);
                                au = true;
                            }
                            else if (var7 == 11)
                            {
                                m_f(0, 26);
                                m_a(679);
                                if (MiamiNights.h.s[0].a[0] == 1)
                                {
                                    m_a(GloftMMN.m_k(680), 2);
                                }
                                else
                                {
                                    m_a(GloftMMN.m_k(680), 13);
                                }

                                aa = 4;
                                au = true;
                            }
                            else if (var7 == -1 && MiamiNights.f.bc[16] == 0)
                            {
                                m_f(16, 1);
                                m_a(761);
                                m_a(762);
                            }
                        }
                        else if (var14 == 287)
                        {
                            if (var7 == 12)
                            {
                                m_f(0, 40);
                                m_a(681);
                                m_a(682);
                                au = true;
                                if (MiamiNights.h.s[0].a[0] == 1)
                                {
                                    m_a(GloftMMN.m_k(683), 2);
                                }
                                else
                                {
                                    m_a(GloftMMN.m_k(683), 13);
                                }

                                aa = 2;
                                ah[20] = 1;
                                f[20] = 1;
                            }
                            else
                            {
                                if (var7 == 22)
                                {
                                    m_f(0, 46);
                                    this.m_a(87, MiamiNights.h.n[this.b[5]].c != 0 ? 1 : 0, -1);
                                    m_a(684);
                                    m_a(GloftMMN.m_k(684), 22);
                                    au = true;
                                    return;
                                }

                                if (var7 == 19)
                                {
                                    m_f(0, 42);
                                }
                            }
                        }
                        else if (var14 == 288)
                        {
                            m_a(GloftMMN.m_k(593) + GloftMMN.m_k(this.a[1]));
                            if (MiamiNights.f.av > 0 && MiamiNights.f.m_d(MiamiNights.h.s[MiamiNights.f.av].b[13]) == -1)
                            {
                                m_a(884);
                            }
                        }
                        else if (var14 == 289)
                        {
                            m_a(GloftMMN.m_k(657) + " " + GloftMMN.m_k(this.a[1]) + GloftMMN.m_k(594));
                        }
                    }
                    else if (var14 < var13)
                    {
                        if (var13 >= 287 && var14 <= 287)
                        {
                            var4.m_c(36, -1);
                        }

                        if (var14 == 285 && var7 == 0 && MiamiNights.f.bc[5] == 1)
                        {
                            m_f(5, 0);
                        }
                    }
                }

                if (var1 == 42)
                {
                    var7 = MiamiNights.f.m_d(this.b[13]);
                    if (var3 > 0 && var2 == 0)
                    {
                        if (var7 == 3 || var7 == 14 || var7 == 9 || var7 == 15 || var7 == 10 || var7 == 16)
                        {
                            if (MiamiNights.f.bc[4] == 5)
                            {
                                m_f(4, 7);
                            }
                        }
                        else if (var7 == 20 || var7 == 21)
                        {
                            if (MiamiNights.f.bc[0] < 44)
                            {
                                m_f(0, 44);
                                m_a(685);
                                au = true;
                            }
                        }
                        else if (var7 == 1)
                        {
                            m_a(686);
                            m_f(6, 3);
                        }

                        var4.m_c(37, 1);
                        return;
                    }

                    if (var3 == 0 && var2 > 0 && var7 == 1)
                    {
                        m_f(6, 0);
                        ag[0] = MiamiNights.f.aT + 10080000L;
                        m_a(687);
                    }
                }
            }
        }

        internal void m_g()
        {
            bool var1 = this.b[6] == 0;
            g var2 = MiamiNights.h.s[0];

            for (int var3 = 0; var3 < D; var3++)
            {
                int var4;
                int var5 = var4 = this.a[var3];
                if (var3 == 40 && !var1)
                {
                    var5 = 0;

                    for (int var6 = 0; var6 < this.k.Length; var6++)
                    {
                        var5 += var2.a[this.k[var6]];
                    }

                    int var8;
                    var5 = ((var8 = var5 / this.k.Length) + this.a[39]) / 2;
                }

                if (var1)
                {
                    if (var3 == 22 && var1)
                    {
                        m_a(var4 <= 39, 71);
                    }

                    if (var3 == 26)
                    {
                        if (var4 >= 50)
                        {
                            m_a(true, 70);
                            v = 6;
                        }
                        else
                        {
                            m_a(false, 70);
                            if (v == 6)
                            {
                                v = 0;
                            }
                        }
                    }
                }

                this.a[var3] = var5;
            }
        }

        internal static void m_b(int var0)
        {
            g var1 = MiamiNights.h.s[var0];
            g var2 = MiamiNights.h.s[0];
            int var3 = 0;
            var3 = MiamiNights.f.m_d(var1.b[13]);
            string var4 = null;
            string var5 = null;
            string var6 = null;
            au = true;
            if (var3 == -1)
            {
                if (var1.b[2] == 66 || var1.b[2] == 62)
                {
                    m_a(623);
                    return;
                }

                if (var1.b[2] == 69)
                {
                    m_a(632);
                    au = false;
                    return;
                }

                if (m_a(247, var1, false))
                {
                    m_a(643);
                    au = false;
                    return;
                }
            }

            if (MiamiNights.f.bc[1] < 10)
            {
                if ((var3 == 2 || var3 == 13) && MiamiNights.f.bc[1] == 1)
                {
                    var4 = GloftMMN.m_k(598);
                }
                else if ((var3 == 2 || var3 == 13) && MiamiNights.f.bc[1] == 2)
                {
                    var4 = GloftMMN.m_k(599);
                }
            }

            if (var3 == 1)
            {
                if (MiamiNights.f.bc[0] == 0)
                {
                    m_f(0, 1);
                    m_f(1, 10);
                    var4 = GloftMMN.m_k(601);
                    var5 = GloftMMN.m_k(602);
                    m_f(6, 0);
                    ag[0] = MiamiNights.f.aT + 4320000L;
                    if (MiamiNights.h.s[0].a[0] == 1)
                    {
                        m_a(GloftMMN.m_k(606) + " " + GloftMMN.m_k(607), 2);
                    }
                    else
                    {
                        m_a(GloftMMN.m_k(606) + " " + GloftMMN.m_k(607), 13);
                    }

                    aa = 5;
                    ah[5] = 1;
                    ah[4] = 1;
                    ah[12] = 1;
                    ah[26] = 1;
                    ah[25] = 1;
                    ah[33] = 1;
                    au = true;
                }
                else if (MiamiNights.f.bc[6] == 1)
                {
                    if (var2.a[35] >= 100)
                    {
                        var4 = GloftMMN.m_k(604);
                        var5 = GloftMMN.m_k(605);
                        var2.m_c(35, -100);
                        ag[0] = MiamiNights.f.aT + 10080000L;
                        m_f(6, 0);
                        if (MiamiNights.f.bc[0] <= 6)
                        {
                            m_f(0, 8);
                            if (MiamiNights.h.s[0].a[0] == 1)
                            {
                                m_a(GloftMMN.m_k(617) + " " + GloftMMN.m_k(618) + " " + GloftMMN.m_k(619), 2);
                            }
                            else
                            {
                                m_a(GloftMMN.m_k(617) + " " + GloftMMN.m_k(618) + " " + GloftMMN.m_k(619), 13);
                            }

                            ae |= 512;
                        }
                    }
                    else
                    {
                        var4 = GloftMMN.m_k(603);
                    }
                }
                else if (MiamiNights.f.bc[6] == 0)
                {
                    au = false;
                    m_a(654);
                }
            }
            else if (MiamiNights.f.bc[0] == 3 && var3 == -1)
            {
                m_f(0, 4);
                var4 = GloftMMN.m_k(608);
            }
            else if (var3 == 0 && MiamiNights.f.bc[0] > 0 && MiamiNights.f.bc[0] != 3 && MiamiNights.f.bc[5] == 0)
            {
                var4 = GloftMMN.m_k(609);
                var5 = GloftMMN.m_k(610);
                var6 = GloftMMN.m_k(611);
                if (MiamiNights.f.bc[0] < 6)
                {
                    m_f(0, 3);
                }

                au = false;
            }
            else if ((var3 == 2 || var3 == 13) && MiamiNights.f.bc[1] > 9)
            {
                if (MiamiNights.f.bc[0] < 3)
                {
                    var4 = GloftMMN.m_k(606);
                    var5 = GloftMMN.m_k(607);
                    int var10;
                    if ((var10 = m_b(var1)) != -1 && var10 == -3)
                    {
                    }
                }
                else if (MiamiNights.f.bc[0] >= 7 && MiamiNights.f.bc[0] < 20)
                {
                    var4 = GloftMMN.m_k(617);
                    var5 = GloftMMN.m_k(618);
                    var6 = GloftMMN.m_k(619);
                }
                else if (MiamiNights.f.bc[0] == 23 && MiamiNights.f.bc[7] == 14)
                {
                    if (MiamiNights.f.bc[8] < 4)
                    {
                        if (MiamiNights.f.bc[8] == 3)
                        {
                            m_a(665);
                        }

                        m_a(660);
                        au = true;
                        m_f(8, 1);
                        return;
                    }

                    if (MiamiNights.f.bc[8] == 4)
                    {
                        au = true;
                        m_a(658);
                        m_a(659);
                        if (MiamiNights.h.s[0].a[0] == 1)
                        {
                            m_a(GloftMMN.m_k(658) + " " + GloftMMN.m_k(659), 2);
                        }
                        else
                        {
                            m_a(GloftMMN.m_k(658) + " " + GloftMMN.m_k(659), 13);
                        }

                        m_f(0, 24);
                    }
                }
                else
                {
                    if (MiamiNights.f.bc[0] == 24)
                    {
                        au = true;
                        m_a(659);
                        return;
                    }

                    if (MiamiNights.f.bc[0] == 40 && MiamiNights.f.bc[7] == 20)
                    {
                        au = true;
                        m_a(688);
                        return;
                    }

                    if (MiamiNights.f.bc[0] == 40)
                    {
                        m_a(689);
                        m_a(690);
                        m_a(691);
                        m_a(692);
                        if (MiamiNights.h.s[0].a[0] == 1)
                        {
                            m_a(GloftMMN.m_k(692), 2);
                        }
                        else
                        {
                            m_a(GloftMMN.m_k(692), 13);
                        }

                        m_f(0, 41);
                        aa = 5;
                        au = true;
                        return;
                    }

                    if (MiamiNights.f.bc[0] == 60)
                    {
                        m_a(693);
                        m_a(694);
                        if (MiamiNights.h.s[0].a[0] == 1)
                        {
                            m_a(GloftMMN.m_k(694), 2);
                        }
                        else
                        {
                            m_a(GloftMMN.m_k(694), 13);
                        }

                        au = true;
                        return;
                    }
                }
            }
            else if (var3 == 4 && var1.b[2] == 60 && MiamiNights.f.bc[3] < 2)
            {
                var4 = GloftMMN.m_k(624);
            }
            else if (var3 == 4 && var1.b[2] != 60 && MiamiNights.f.bc[3] == 0)
            {
                var4 = GloftMMN.m_k(625);
                var5 = GloftMMN.m_k(630);
                m_b(var1);
                m_f(3, 1);
                var1.a[39] = 10;
                au = false;
            }
            else if (var3 == 6)
            {
                if (var2.a[16] < 35)
                {
                    var4 = GloftMMN.m_k(650);
                    var5 = GloftMMN.m_k(695);
                }
                else if (var2.a[35] < 10)
                {
                    var4 = GloftMMN.m_k(656);
                }
                else if (m_a(28, var1, false))
                {
                    m_a(354);
                }
                else
                {
                    var4 = GloftMMN.m_k(651);
                    if (MiamiNights.f.bb[5] == 0)
                    {
                        var2.m_c(35, -10);
                        m_g(5, 1);
                    }
                }
            }
            else if (var3 == 8)
            {
                if (m_a(272, var1, false))
                {
                    m_g(5, 1);
                }
                else
                {
                    if (ah[19] == 0)
                    {
                        var4 = GloftMMN.m_k(653);
                    }
                    else
                    {
                        var4 = GloftMMN.m_k(748);
                        au = true;
                    }

                    if (m_a(28, var1, false))
                    {
                        var5 = GloftMMN.m_k(354);
                    }
                    else if (MiamiNights.f.bc[8] == 4 && MiamiNights.f.bc[7] == 14)
                    {
                        au = false;
                    }
                }
            }
            else if ((var3 == 9 || var3 == 15) && MiamiNights.h.H == 11)
            {
                if (MiamiNights.f.bc[0] > 6 && MiamiNights.f.bc[0] < 9)
                {
                    var4 = GloftMMN.m_k(666);
                    var5 = GloftMMN.m_k(622);
                    m_f(0, 9);
                }
                else if (MiamiNights.f.bc[4] == 2)
                {
                    var4 = GloftMMN.m_k(631);
                }
                else if (MiamiNights.f.bb[0] == 1)
                {
                    var4 = GloftMMN.m_k(667);
                    var6 = GloftMMN.m_k(668);
                }
                else if (MiamiNights.f.bb[0] == 0)
                {
                    GloftMMN.m_k(632);
                    var4 = GloftMMN.m_k(669);
                    au = false;
                }
            }
            else if ((var3 == 10 || var3 == 16) && MiamiNights.h.H == 11)
            {
                if (MiamiNights.f.bc[0] > 6 && MiamiNights.f.bc[0] < 10)
                {
                    var4 = GloftMMN.m_k(666);
                    var5 = GloftMMN.m_k(622);
                    m_f(0, 9);
                }
                else if (MiamiNights.f.bc[4] == 2)
                {
                    var4 = GloftMMN.m_k(631);
                }
                else if (MiamiNights.f.bb[0] == 1)
                {
                    var4 = GloftMMN.m_k(670);
                    var5 = GloftMMN.m_k(671);
                }
                else if (MiamiNights.f.bb[0] == 0)
                {
                    var4 = GloftMMN.m_k(632);
                    var5 = GloftMMN.m_k(669);
                    au = false;
                }
            }
            else if ((var3 == 3 || var3 == 14) && MiamiNights.h.H == 11)
            {
                if (MiamiNights.f.bc[11] != 1)
                {
                    if (MiamiNights.f.bc[7] == 11)
                    {
                        if (var2.a[30] >= 35)
                        {
                            if (MiamiNights.f.bb[9] == 0)
                            {
                                m_a(GloftMMN.m_k(922), (sbyte)3);
                            }
                            else if (MiamiNights.f.bb[9] == 2)
                            {
                                var4 = GloftMMN.m_k(707);
                            }
                            else
                            {
                                var4 = GloftMMN.m_k(705);
                            }
                        }
                        else
                        {
                            var4 = GloftMMN.m_k(923);
                        }
                    }
                }
                else if (MiamiNights.f.bc[0] > 6 && MiamiNights.f.bc[0] < 10)
                {
                    var4 = GloftMMN.m_k(666);
                    var5 = GloftMMN.m_k(622);
                    m_f(0, 9);
                }
                else if (MiamiNights.f.bc[0] == 11)
                {
                    var4 = GloftMMN.m_k(631);
                }
                else if (MiamiNights.f.bb[0] == 1)
                {
                    var4 = GloftMMN.m_k(620);
                    var5 = GloftMMN.m_k(621);
                }
                else if (MiamiNights.f.bb[0] == 0)
                {
                    var4 = GloftMMN.m_k(669);
                    au = false;
                }
                else if (MiamiNights.f.bc[4] == 2)
                {
                    var4 = GloftMMN.m_k(631);
                }
            }
            else if (var3 == 11 && MiamiNights.f.bc[0] == 26)
            {
                var4 = GloftMMN.m_k(696);
                var5 = GloftMMN.m_k(697);
                m_f(0, 27);
                au = true;
            }
            else if (var3 == 11 && MiamiNights.f.bc[0] == 27)
            {
                var4 = GloftMMN.m_k(698);
                var5 = GloftMMN.m_k(699);
                m_f(0, 28);
                m_a(GloftMMN.m_k(699), 11);
                aa = 0;
                au = true;
            }
            else if (var3 == 11 && MiamiNights.f.bc[0] == 28)
            {
                var4 = GloftMMN.m_k(700);
                var5 = GloftMMN.m_k(701);
                ah[21] = 1;
                f[21] = 1;
                m_f(0, 29);
                if (MiamiNights.h.s[0].a[0] == 1)
                {
                    m_a(GloftMMN.m_k(702), 2);
                }
                else
                {
                    m_a(GloftMMN.m_k(702), 13);
                }

                aa = 5;
            }
            else if (var3 == 11 && MiamiNights.f.bc[0] == 29)
            {
                var4 = GloftMMN.m_k(703);
            }
            else if (var3 == 12 && MiamiNights.f.bc[0] == 29)
            {
                if (var2.a[13] < 25)
                {
                    var4 = GloftMMN.m_k(769);
                    var5 = GloftMMN.m_k(770);
                    au = true;
                }
                else
                {
                    var4 = GloftMMN.m_k(704);
                    au = false;
                }
            }
            else if (var3 == 17)
            {
                if (MiamiNights.f.bc[7] == 29)
                {
                    if (var2.a[16] >= 35)
                    {
                        if (MiamiNights.f.bb[9] == 0)
                        {
                            m_a(GloftMMN.m_k(705), (sbyte)2);
                        }
                        else if (MiamiNights.f.bb[9] == 2)
                        {
                            var4 = GloftMMN.m_k(707);
                        }
                        else
                        {
                            var4 = GloftMMN.m_k(705);
                        }
                    }
                    else
                    {
                        var4 = GloftMMN.m_k(708);
                    }
                }
                else if (MiamiNights.f.bc[7] == 32)
                {
                    if (var2.a[13] >= 45)
                    {
                        if (MiamiNights.f.bb[9] == 0)
                        {
                            var4 = GloftMMN.m_k(709);
                            var5 = GloftMMN.m_k(710);
                            m_g(9, 1);
                        }
                        else if (MiamiNights.f.bb[9] == 2)
                        {
                            var4 = GloftMMN.m_k(707);
                        }
                        else
                        {
                            var4 = GloftMMN.m_k(710);
                        }
                    }
                    else
                    {
                        var4 = GloftMMN.m_k(711);
                    }
                }
            }
            else if (var3 == 19)
            {
                var1.m_a();
                if (MiamiNights.f.bc[0] == 41)
                {
                    var4 = GloftMMN.m_k(712);
                    var5 = GloftMMN.m_k(713);
                    au = false;
                }
                else if (MiamiNights.f.bc[0] == 42)
                {
                    if (var2.a[35] < 500)
                    {
                        m_a(733);
                        au = true;
                        return;
                    }

                    m_a(714);
                    var2.m_c(35, -500);
                    m_f(0, 43);
                    au = true;
                    return;
                }
            }
            else if (var3 == 20 || var3 == 21)
            {
                if (MiamiNights.f.bc[0] == 43)
                {
                    m_a(715);
                    m_a(716);
                    au = false;
                    var1.m_a();
                }
                else if (MiamiNights.f.bc[0] >= 44 && MiamiNights.f.bc[0] < 60)
                {
                    m_a(685);
                    au = true;
                }
                else
                {
                    if (MiamiNights.f.bc[0] == 60)
                    {
                        m_a(717);
                        m_a(718);
                        if (MiamiNights.h.s[0].a[0] == 1)
                        {
                            m_a(GloftMMN.m_k(718), 21);
                        }
                        else
                        {
                            m_a(GloftMMN.m_k(718), 20);
                        }

                        m_f(0, 61);
                        ah[24] = 1;
                        f[24] = 1;
                        aa = 1;
                        au = true;
                        return;
                    }

                    if (MiamiNights.f.bc[0] == 61 && MiamiNights.f.bc[7] != 24)
                    {
                        m_a(718);
                    }
                    else if (MiamiNights.f.bc[0] == 61)
                    {
                        var4 = GloftMMN.m_k(720);
                        var2.a[33] = 1;
                        m_f(0, 62);
                        bool var8 = false;
                        if (MiamiNights.h.s[0].a[0] == 1)
                        {
                            m_a(GloftMMN.m_k(924), 2);
                        }
                        else
                        {
                            m_a(GloftMMN.m_k(924), 13);
                        }

                        aa = -1;
                    }
                }
            }
            else if (var3 == 22)
            {
                if (var2.a[16] < 60)
                {
                    m_a(771);
                    au = true;
                    return;
                }

                if (MiamiNights.f.bc[0] == 45)
                {
                    m_a(722);
                    m_a(723);
                    m_a(724);
                    au = false;
                    var1.m_a();
                }
                else if (MiamiNights.f.bc[0] == 46)
                {
                    if (var2.a[35] >= 500)
                    {
                        m_a(726);
                        var2.m_c(35, -500);
                        m_f(0, 60);
                        if (MiamiNights.h.s[0].a[0] == 1)
                        {
                            m_a(GloftMMN.m_k(727), 2);
                        }
                        else
                        {
                            m_a(GloftMMN.m_k(727), 13);
                        }

                        aa = 2;
                        au = true;
                        return;
                    }

                    m_a(725);
                }
            }
            else if (var3 == 18)
            {
                var4 = GloftMMN.m_k(731);
                if (MiamiNights.f.bb[10] == 0)
                {
                    if (var2.a[24] < 60)
                    {
                        if (MiamiNights.f.bc[12] <= 0)
                        {
                            m_a(GloftMMN.m_k(728), (sbyte)1);
                            var4 = null;
                        }
                    }
                    else if (var2.a[24] < 80)
                    {
                        var4 = GloftMMN.m_k(729);
                        au = false;
                    }
                    else if (var2.a[24] < 90)
                    {
                        var4 = GloftMMN.m_k(730);
                        au = false;
                    }
                }
            }
            else if (var3 == 3 || var3 == 14 || var3 == 9 || var3 == 15 || var3 == 10 || var3 == 16)
            {
                if (MiamiNights.f.bc[0] < 20)
                {
                    if (MiamiNights.f.bc[4] == 2 || MiamiNights.f.bc[4] == 3)
                    {
                        var4 = GloftMMN.m_k(634);
                        m_f(4, 3);
                        au = false;
                    }
                    else if (MiamiNights.f.bc[4] == 4 && MiamiNights.f.bb[0] == 0)
                    {
                        var4 = GloftMMN.m_k(635);
                    }
                    else if (MiamiNights.f.bc[4] == 4 && MiamiNights.f.bb[0] == 1)
                    {
                        var4 = GloftMMN.m_k(640);
                        m_f(4, 5);
                        au = false;
                    }
                    else if (MiamiNights.f.bc[4] == 5)
                    {
                        if (m_a(85, var1, false))
                        {
                            var4 = GloftMMN.m_k(586);
                        }
                        else
                        {
                            var4 = GloftMMN.m_k(916);
                        }

                        au = false;
                    }
                }
                else if (MiamiNights.f.bc[0] < 30)
                {
                    if (MiamiNights.f.bc[4] == 8)
                    {
                        m_f(4, 9);
                        var4 = GloftMMN.m_k(642);
                        if (m_a(247, var1, false))
                        {
                            var5 = GloftMMN.m_k(643);
                        }

                        au = false;
                    }
                    else if (m_a(247, var1, false))
                    {
                        m_a(643);
                        au = false;
                    }
                }
            }

            if (var3 == -1)
            {
                if (var3 == 7 && m_a(15, var1, false))
                {
                    m_a(646);
                }

                if (m_a(59, var1, false))
                {
                    m_a(775);
                }
                else
                {
                    if (m_a(253, var1, false) && !m_a(236, var1, false))
                    {
                        if (m_a(64, var1, false))
                        {
                            m_a(773);
                        }
                        else if (m_a(63, var1, false) && !m_a(20, var1, false))
                        {
                            m_a(774);
                        }
                        else
                        {
                            m_a(645);
                        }
                    }
                    else if (m_a(252, var1, false))
                    {
                        m_a(644);
                    }

                    au = false;
                }
            }

            if (var4 != null)
            {
                m_a(var4);
                if (var5 != null)
                {
                    m_a(var5);
                }

                if (var6 != null)
                {
                    m_a(var6);
                    return;
                }
            }
            else
            {
                au = false;
            }
        }

        internal static void m_f(int var0, int var1)
        {
            sbyte var2 = MiamiNights.f.bc[var0];
            sbyte var3 = 13;
            if (MiamiNights.h.s[0].a[0] == 1)
            {
                var3 = 2;
            }

            switch (var0)
            {
                case 0:
                    if (var1 == 42)
                    {
                        m_a(732);
                        m_a(733);
                        m_a(GloftMMN.m_k(733), 19);
                        au = true;
                    }
                    else if (var1 == 43)
                    {
                        m_a(GloftMMN.m_k(734), (int)var3);
                        aa = 6;
                        ah[31] = 1;
                    }
                    else if (var1 == 44)
                    {
                        if (MiamiNights.f.bj < 2000)
                        {
                            m_a(GloftMMN.m_k(777) + GloftMMN.m_k(778), (int)var3);
                            aa = 2;
                        }
                        else
                        {
                            var1 = 45;
                            m_a(GloftMMN.m_k(779), (int)var3);
                            aa = 5;
                        }
                    }
                    else if (var1 == 45)
                    {
                        m_a(GloftMMN.m_k(735), (int)var3);
                        aa = 5;
                    }

                    if (var1 > var2 && MiamiNights.h.ai == 1)
                    {
                        MiamiNights.h.aj = true;
                    }
                    break;
                case 1:
                    if (var2 == 1 && var1 == 2)
                    {
                        m_a(613);
                    }
                    else if (var2 < 3 && var1 == 3)
                    {
                        ah[1] = 1;
                        ah[0] = 1;
                        m_a(614);
                        MiamiNights.h.m = 0;
                    }
                    goto case 2;
                case 2:
                case 3:
                case 7:
                case 8:
                case 9:
                case 10:
                case 12:
                default:
                    break;
                case 4:
                    if (var1 == 4 && MiamiNights.f.bb[0] == 0)
                    {
                        m_a(635);
                        au = true;
                    }
                    else if (var1 == 7)
                    {
                        m_f(0, 20);
                        var1 = 8;
                        m_a(641);
                        MiamiNights.h.m = 1;
                        m_a(GloftMMN.m_k(672), (int)var3);
                        aa = 0;
                        MiamiNights.f.bc[31] = 1;
                    }
                    break;
                case 5:
                    if (var1 == 1)
                    {
                        m_a(655);
                    }
                    break;
                case 6:
                    if (var1 == 0 && var2 == 1)
                    {
                        ah[0] = 1;
                        ah[1] = 1;
                    }
                    break;
                case 11:
                    if (var1 > 0 && var2 == 0 && MiamiNights.f.bc[0] == 8)
                    {
                        m_a(GloftMMN.m_k(674), (int)var3);
                        aa = 6;
                        ah[11] = 1;
                        f[11] = 1;
                    }
                    break;
                case 13:
                    if (var1 == 1 && var2 == 0)
                    {
                        ag[4] = MiamiNights.f.aT + 1440000L;
                        m_a(394);
                        m_a(902);
                        MiamiNights.h.m = 25;
                        MiamiNights.f.bc[31] = 1;
                    }
                    break;
            }

            MiamiNights.f.bc[var0] = (sbyte)var1;
        }

        internal static void m_g(int var0, int var1)
        {
            switch (var0)
            {
                case 0:
                    if (MiamiNights.h.H != 0 && MiamiNights.h.H != 9 && MiamiNights.h.H != 17 && MiamiNights.h.H != 30)
                    {
                        if (var1 == 1)
                        {
                            GloftMMN.m_e();
                            GloftMMN.m_c(4);
                        }
                        else if (var1 == 0 && GloftMMN.m_b(0, 4))
                        {
                            GloftMMN.m_d(0);
                        }
                    }
                    break;
                case 2:
                    if (var1 == 1)
                    {
                        m_a(736);
                    }
                    break;
                case 5:
                    if (var1 == 1)
                    {
                        m_g(4, 1);
                        if (MiamiNights.f.bc[0] == 21)
                        {
                            m_f(0, 22);
                        }
                        else if (MiamiNights.f.bc[0] == 22)
                        {
                            m_f(0, 23);
                        }
                    }
                    else
                    {
                        m_g(4, 0);
                    }
                    break;
                case 12:
                    if (var1 == 1)
                    {
                        m_a(919);
                    }
                    break;
            }

            MiamiNights.f.bb[var0] = (sbyte)var1;
        }

        internal static void m_a(g var0)
        {
            g var1 = MiamiNights.h.s[0];
            sbyte var2 = MiamiNights.h.E[MiamiNights.h.D - 2];
            sbyte var3 = MiamiNights.h.E[MiamiNights.h.D - 1];
            sbyte var4 = MiamiNights.h.E[MiamiNights.h.D];
            int var5 = MiamiNights.f.m_d(var0.b[13]);
            if (var2 == 1 && var3 == 1 && var4 == 0 && MiamiNights.h.w > 0)
            {
                var0.m_c(26, 30);
                au = true;
                if ((var5 == 3 || var5 == 14 || var5 == 9 || var5 == 15 || var5 == 10 || var5 == 16) && MiamiNights.f.bc[4] == 3)
                {
                    m_f(4, 4);
                }
            }

            if (var2 == 1 && var3 == 0 && var4 == 0)
            {
                if (MiamiNights.h.w > 0 && MiamiNights.f.bc[4] == 4 && MiamiNights.f.bb[0] == 1 && (var5 == 3 || var5 == 14 || var5 == 9 || var5 == 15 || var5 == 10 || var5 == 16))
                {
                    m_f(4, 5);
                    au = true;
                }

                au = true;
            }

            if (var2 == 2 && var3 == 2 && var4 == -1 && MiamiNights.h.w > 0)
            {
                if ((var5 == 3 || var5 == 14 || var5 == 9 || var5 == 15 || var5 == 10 || var5 == 16) && MiamiNights.f.bc[4] == 9)
                {
                    m_f(4, 11);
                    m_f(0, 22);
                    ag[3] = MiamiNights.f.aT + 7000L;
                    m_f(11, 0);
                }

                m_a(749);
                au = true;
            }

            if (var2 == 2 && var3 == 3 && var4 == -1 && var0.a[42] > 0)
            {
                if ((var5 == 3 || var5 == 14 || var5 == 9 || var5 == 15 || var5 == 10 || var5 == 16) && MiamiNights.f.bc[4] == 9)
                {
                    m_f(4, 12);
                    m_a(652);
                    MiamiNights.h.m = 0;
                    aa = 5;
                    if (MiamiNights.h.s[0].a[0] == 1)
                    {
                        m_a(GloftMMN.m_k(647) + " " + GloftMMN.m_k(648) + " " + GloftMMN.m_k(649), 2);
                    }
                    else
                    {
                        m_a(GloftMMN.m_k(647) + " " + GloftMMN.m_k(648) + " " + GloftMMN.m_k(649), 13);
                    }

                    m_f(0, 22);
                    MiamiNights.f.bc[31] = 0;
                }

                m_f(11, 0);
                var0.m_c(42, -var0.a[42]);
                var1.m_c(38, 1);
            }

            if (var2 == 1 && var3 == 1 && MiamiNights.h.w > 0 && m_a(236, var0, false))
            {
                var0.m_c(39, -var0.a[39]);
            }
            else if (var2 >= 0 && m_a(236, var0, false) && MiamiNights.f.bc[13] == 0)
            {
                m_a(737);
            }

            if (var5 == 8 && var2 == 1 && var3 == 1 && var4 == 1 && MiamiNights.h.w > 0)
            {
                m_g(4, 1);
                if (MiamiNights.f.bc[0] == 24)
                {
                    m_f(0, 25);
                }

                ah[19] = 1;
                m_a(664);
                au = true;
            }

            if (var5 == 18 && MiamiNights.h.w > 0)
            {
                if (var2 == 1 && var3 == 1 && var4 == 4)
                {
                    var1.m_c(35, 300);
                    m_g(10, 1);
                    au = true;
                }
                else if (var2 == 1 && var3 == 1 && var4 == 3)
                {
                    var1.m_c(35, 500);
                    m_g(10, 1);
                    au = true;
                }
            }

            if (var2 == 1 && var3 == 1 && var4 == 5 && MiamiNights.h.w > 0 && MiamiNights.f.bc[12] > 0)
            {
                m_f(12, 0);
                var0.m_c(33, -1);
                m_a(738);
                m_a(739);
            }

            if (var2 >= 0 && MiamiNights.h.w < 1 && m_a(58, var0, false) && var5 == 11)
            {
                m_a(740);
                m_a(741);
                au = true;
            }
        }

        internal static void m_a(string var0, sbyte var1)
        {
            ak = var0;
            al = var1;
        }

        internal static void m_a(int var0, bool var1)
        {
            g var2 = MiamiNights.h.s[0];
            switch (var0)
            {
                case 1:
                    if (var1)
                    {
                        if (var2.a[35] >= 10)
                        {
                            m_f(12, 1);
                            var2.m_c(35, -10);
                            m_a(750);
                            m_g(10, 1);
                        }
                        else
                        {
                            m_a(434);
                        }

                        au = true;
                        return;
                    }
                    break;
                case 2:
                    if (var1)
                    {
                        m_g(9, 1);
                        m_a(706);
                        au = true;
                        return;
                    }
                    break;
                case 3:
                    if (var1)
                    {
                        m_g(9, 1);
                        m_a(763);
                        m_a(764);
                        au = true;
                    }
                    break;
            }
        }

        internal static void m_c(int var0)
        {
            if (ai[var0])
            {
                ai[var0] = false;
                switch (var0)
                {
                    case 4:
                        ah[6] = 1;
                        f[6] = 1;
                        if (ah[7] == 0)
                        {
                            Console.WriteLine("Auto barrrrrrrrr");
                            m_a(751);
                            return;
                        }
                        goto case 5;
                    case 5:
                    case 8:
                    case 9:
                    case 10:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 19:
                    case 21:
                    case 23:
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                    case 31:
                    case 32:
                    case 33:
                    default:
                        break;
                    case 6:
                        ah[9] = 1;
                        return;
                    case 7:
                        ah[16] = 1;
                        ah[32] = 1;
                        f[32] = 1;
                        ah[33] = 1;
                        f[33] = 1;
                        return;
                    case 11:
                        ah[30] = 1;
                        f[30] = 1;
                        m_a(765);
                        return;
                    case 12:
                        ah[18] = 1;
                        f[18] = 1;
                        ah[13] = 1;
                        ah[7] = 1;
                        f[7] = 1;
                        ah[14] = 1;
                        f[26] = 1;
                        ah[26] = 1;
                        return;
                    case 18:
                        f[29] = 1;
                        return;
                    case 20:
                        ah[22] = 1;
                        f[22] = 1;
                        ah[37] = 1;
                        f[37] = 1;
                        return;
                    case 22:
                        ah[34] = 1;
                        f[34] = 1;
                        ah[23] = 1;
                        f[23] = 1;
                        ah[22] = 1;
                        f[22] = 1;
                        return;
                    case 24:
                        ah[27] = 1;
                        break;
                    case 30:
                        ah[28] = 1;
                        f[28] = 1;
                        return;
                    case 34:
                        ah[35] = 1;
                        f[35] = 1;
                        return;
                }
            }
        }

        internal static void m_d(int var0)
        {
            if (var0 == 30)
            {
                m_a(742);
            }

            if (var0 == 30)
            {
                m_a(743);
            }
        }

        internal static void m_h()
        {
            if (MiamiNights.f.bc[4] == 2 && MiamiNights.f.bc[0] < 11 && MiamiNights.f.bc[14] == 1)
            {
                m_f(0, 11);
                aa = 5;
                if (MiamiNights.h.s[0].a[0] == 1)
                {
                    m_a(GloftMMN.m_k(744), 2);
                }
                else
                {
                    m_a(GloftMMN.m_k(744), 13);
                }
            }

            m_f(14, 0);
        }

        internal static void m_i()
        {
            if (MiamiNights.f.bc[0] >= 30)
            {
                if (MiamiNights.f.bj >= 2000 && MiamiNights.f.bc[0] == 44)
                {
                    m_a(GloftMMN.m_k(766));
                    m_f(0, 45);
                    return;
                }

                m_a(GloftMMN.m_k(920) + "$ " + MiamiNights.f.bj + " !");
            }
        }

        internal static bool m_e(int var0)
        {
            if (var0 == 18 && MiamiNights.f.bc[1] < 2)
            {
                m_a(504);
                return false;
            }
            else
            {
                if (var0 == 57)
                {
                    if (MiamiNights.f.bb[9] == 0 || MiamiNights.f.bb[9] == 2)
                    {
                        m_a(745);
                        return false;
                    }
                }
                else if (var0 == 63)
                {
                    if (MiamiNights.f.bb[9] == 0 || MiamiNights.f.bb[9] == 2)
                    {
                        m_a(767);
                        return false;
                    }
                }
                else if (var0 == 60 && (MiamiNights.f.bb[9] == 0 || MiamiNights.f.bb[9] == 2))
                {
                    m_a(768);
                    return false;
                }

                return true;
            }
        }

        private void m_r()
        {
            if (this.an == null)
            {
                this.an = new sbyte[40];
            }

            for (int var1 = 0; var1 < 8; var1++)
            {
                this.an[var1 * 5 + 0] = 0;
            }
        }

        private void m_a(sbyte var1, sbyte var2, int var3)
        {
            int var5 = 0;
            int var6 = -1;

            for (int var4 = 0; var4 < 8; var4++)
            {
                if (this.an[var5 + 0] == 1)
                {
                    if (this.an[var5 + 1] == var1)
                    {
                        if (this.an[var5 + 2] == var2)
                        {
                            return;
                        }

                        var6 = var4;
                    }
                }
                else if (var6 == -1)
                {
                    var6 = var4;
                }

                var5 += 5;
            }

            if (var6 != -1)
            {
                var5 = var6 * 5;
                this.an[var5 + 0] = 1;
                this.an[var5 + 1] = var1;
                this.an[var5 + 2] = var2;
                this.an[var5 + 3] = 1;
                this.an[var5 + 4] = (sbyte)(var3 - 798);
            }
        }

        private void m_a(sbyte var1)
        {
            int var3 = 0;   // CFR: int (VF byte mis-inference)

            for (int var2 = 0; var2 < 8; var2++)
            {
                if (this.an[var3 + 1] == var1)
                {
                    this.an[var3 + 0] = 0;
                    return;
                }

                var3 += 5;
            }
        }

        internal static void m_a(Graphics var0)
        {
            var0.SetClip(0, 75, 240, 240);
            g var1 = MiamiNights.h.s[0];
            if (S == null)
            {
                S = new d(MiamiNights.h.u[1], 0, 0, null);
                T = new d(MiamiNights.h.u[1], 0, 0, null);
                S.e = -1;
            }

            sbyte[] var2 = var1.an;
            int var4 = -1;
            int var5 = 0;

            for (int var3 = 7; var3 >= 0; var3--)
            {
                var5 = var3 * 5;
                if (var2[var5 + 0] > 0)
                {
                    var4 = var3;
                    break;
                }
            }

            if (var4 != -1)
            {
                if (MiamiNights.f.aS.size() <= 0 && N.size() == 0)
                {
                    MiamiNights.f.m_a(GloftMMN.m_k(var2[var5 + 4] + 798), 0);
                    ao = var2[var5 + 1];
                }

                var5 = var4 * 5;
                long var6 = p;
                if (p >= 1500L)
                {
                    if (S.e == -1)
                    {
                        S.m_a(27);
                    }
                    else if (S.e == 27 && S.m_a())
                    {
                        S.m_a(28);
                    }

                    S.a = MiamiNights.h.n[0].a + 1792;
                    S.b = MiamiNights.h.n[0].b - 16128 + 2048;
                    S.m_a(var0);
                    if (S.e != 28 || !S.m_a())
                    {
                        S.m_b();
                    }

                    if (S.e == 28)
                    {
                        int[] var9 = S.m_c();
                        T.a = var9[0];
                        T.b = var9[1];
                        T.m_a(var2[var5 + 1]);
                        T.m_a(var0);
                        T.m_b();
                        return;
                    }
                }
                else
                {
                    S.e = -1;
                    T.e = -1;
                }
            }
        }

        private static int m_h(int var0)
        {
            return ap[2 + var0 * 2 + 0] & 0xFF | (ap[2 + var0 * 2 + 1] & 0xFF) << 8;
        }

        internal static void m_j()
        {
            ap = GloftMMN.m_j(4);
        }

        private static int m_a(int var0, g var1)
        {
            g var2 = MiamiNights.h.s[0];
            int var3 = var0 & 3;
            int var4 = var0 >> 2;
            if (var3 == 0)
            {
                return var1.a[var4];
            }
            else if (var3 == 1)
            {
                return var2.a[var4];
            }
            else if (var3 == 3)
            {
                var4 = var0 >> 3;
                return (var0 & 4) >> 2 == 0 ? MiamiNights.f.bb[var4] : MiamiNights.f.bc[var4];
            }
            else
            {
                return 0;
            }
        }

        internal static bool m_a(int var0, g var1, bool var2)
        {
            if (var2)
            {
                for (int var3 = 0; var3 < 16; var3++)
                {
                    aq[var3] = -1;
                }

                ar = 0;
            }

            return m_a(var0, var1, var2, false);
        }

        private static bool m_a(int var0, g var1, bool var2, bool var3)
        {
            int var5 = m_h(var0);
            bool var6 = false;
            int var7;
            int var8 = (var7 = ap[var5 + 0] & 255) & 3;
            int var9;
            if ((var9 = var7 >> 3) == 0)
            {
                var9 = 1;
            }

            int var10 = ap[var5 + 1 + 0] & 255 | (ap[var5 + 1 + 1] & 255) << 8;
            var5 += 3;
            bool var11 = false;
            if (var8 == 1)
            {
                var11 = true;
            }

            for (int var12 = 0; var12 < var9; var12++)
            {
                int var13;
                switch (var13 = ap[var5++] & 0xFF)
                {
                    case 0:
                        int var28 = ap[var5++] & 255;
                        sbyte var29 = ap[var5++];
                        sbyte var17 = ap[var5++];
                        int var14;
                        if ((var14 = m_a(var28, var1)) >= var29 && var14 <= var17)
                        {
                            var6 = true;
                            break;
                        }

                        var6 = false;
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    default:
                        int var20 = m_a(ap[var5++] & 255, var1);
                        int var21 = m_a(ap[var5++] & 255, var1);
                        if (var13 == 1)
                        {
                            var6 = var20 > var21;
                        }
                        else if (var13 == 2)
                        {
                            var6 = var20 >= var21;
                        }
                        else if (var13 == 3)
                        {
                            var6 = var20 < var21;
                        }
                        else if (var13 == 4)
                        {
                            var6 = var20 <= var21;
                        }
                        else if (var13 == 5)
                        {
                            var11 = var20 != var21;
                        }
                        else if (var13 == 6)
                        {
                            var6 = var20 == var21;
                        }
                        break;
                    case 7:
                        int var18 = ap[var5++] & 255;
                        var6 = m_a(ap[var5++] & 255 | (ap[var5++] & 255) << 8, var1, var2, var18 == 1);
                        break;
                    case 8:
                        var6 = MiamiNights.f.aQ == 0;
                        break;
                    case 9:
                        var6 = MiamiNights.f.aQ == 1;
                        break;
                    case 10:
                        var6 = false;
                        if (var1 != null)
                        {
                            int var15 = ap[var5++] & 255;

                            for (int var16 = 0; var16 < var1.k.Length; var16++)
                            {
                                if (var1.k[var16] == var15)
                                {
                                    var6 = true;
                                    break;
                                }
                            }
                        }
                        break;
                }

                if (var8 == 0)
                {
                    var11 = var6;
                }
                else if (var8 == 1)
                {
                    var11 = var11 && var6;
                }
                else if (var8 == 2)
                {
                    var11 = var11 || var6;
                }
            }

            if (var3)
            {
                var11 = !var11;
            }

            if (var2 && var11 && var10 != 65535)
            {
                aq[ar & 255] = (short)var10;
                ar++;
            }

            return var11;
        }

        internal static int m_f(int var0)
        {
            return @as[1 + var0 * 2 + 0] & 0xFF | (@as[1 + var0 * 2 + 1] & 0xFF) << 8;
        }

        internal static int m_h(int var0, int var1)
        {
            int var2 = m_f(var0) + 1;

            for (int var3 = 0; var3 < var1; var3++)
            {
                var2 = MiamiNights.f.m_a(null, @as, var2 + 10, true, false);
            }

            return var2;
        }

        private static int m_i(int var0)
        {
            return at[1 + var0 * 2 + 0] & 0xFF | (at[1 + var0 * 2 + 1] & 0xFF) << 8;
        }

        internal static void m_k()
        {
            @as = GloftMMN.m_j(5);
            at = GloftMMN.m_j(6);
        }

        private static bool m_s()
        {
            return MiamiNights.h.y == 0 || MiamiNights.h.y == 1 || MiamiNights.h.y == 19 || MiamiNights.h.y == 6;
        }

        internal static bool m_l()
        {
            return MiamiNights.h.y == 0 || MiamiNights.h.y == 1 || MiamiNights.h.y == 2 || MiamiNights.h.y == 5 || MiamiNights.h.y == 19 || MiamiNights.h.y == 6 || MiamiNights.h.y == 7 || MiamiNights.h.y == 11 || MiamiNights.h.y == 12;
        }

        internal static void m_m()
        {
            if (m_s())
            {
                for (int var0 = 1; var0 < MiamiNights.h.s.Length; var0++)
                {
                    g var3;
                    if ((var3 = MiamiNights.h.s[var0]) != null && var3.s && (var3.b[13] < 0 || MiamiNights.f.m_d(var3.b[13]) != 22 || var3.b[2] != 87))
                    {
                        int var4;
                        for (var4 = 0; var4 < (at[0] & 255); var4++)
                        {
                            int var1 = m_i(var4);
                            bool var5 = false;
                            int var6 = MiamiNights.f.aL[1 + var3.b[2] * 5 + 1] & 7;
                            if (var3.b[3] == 1 || at[var1 + 1] >= var6)
                            {
                                int var2;
                                if ((var2 = at[var1 + 0] & 255) == 255)
                                {
                                    var5 = true;
                                }
                                else
                                {
                                    int var14;
                                    var2 = (var14 = (var2 << 8) / 10) * var14 >> 8;
                                    var5 = var3.t <= var2;
                                }
                            }

                            if (var5 && m_a(at[var1 + 2] & 255 | (at[var1 + 3] & 255) << 8, var3, false))
                            {
                                int var16 = at[var1 + 4] & 255;
                                var1 += 5;

                                int var7;
                                for (var7 = 0; var7 < var16; var7++)
                                {
                                    if (m_a(at[var1 + 0] & 255 | (at[var1 + 1] & 255) << 8, var3, false))
                                    {
                                        sbyte var9 = var3.b[2];
                                        sbyte var10 = at[var1 + 2];
                                        d var11 = MiamiNights.h.n[0];
                                        d var12 = MiamiNights.h.n[var3.b[5]];
                                        if (var10 != var9)
                                        {
                                            var3.b[3] = 1;
                                            if (var3.b[4] == -1)
                                            {
                                                var3.b[4] = var9;
                                                var3.b[7] = (sbyte)var12.c;
                                            }

                                            var3.m_a((int)var10, -1, -1);   // java invocation picks a(int,int,int) - no arg narrowing
                                        }

                                        if (var11.a > var12.a)
                                        {
                                            var12.c = 0;
                                        }
                                        else
                                        {
                                            var12.c = 1;
                                        }
                                        break;
                                    }

                                    var1 += 3;
                                }

                                if (var7 != var16)
                                {
                                    break;
                                }
                            }
                        }

                        if (var4 == (at[0] & 255) && var3.b[3] == 1)
                        {
                            if (var3.b[7] != -1)
                            {
                                MiamiNights.h.n[var3.b[5]].c = var3.b[7];
                                var3.b[7] = -1;
                            }

                            var3.m_a((int)var3.b[4], -1, -1);
                            var3.b[4] = -1;
                            var3.b[3] = 0;
                            MiamiNights.f.m_c(var3.b[6] & 255);
                        }
                    }
                }
            }
        }

        internal static void m_a(Graphics var0, int var1, int var2, int var3, int var4, int var5, int var6, int var7)
        {
            var0.SetColor(var5);
            var0.FillRect(var1, var2, var3, var4);
            var0.SetColor(var6);
            var0.FillRect(var1, var2, var3, 1);
            var0.FillRect(var1, var2 + var4 - 1, var3, 1);
            var0.FillRect(var1, var2, 1, var4);
            var0.FillRect(var1 + var3 - 1, var2, 1, var4);
            var0.SetColor(var7);
            var0.FillRect(var1 + 3, var2 + var4, var3, 3);
            var0.FillRect(var1 + var3, var2 + 3, 3, var4);
        }

        internal static void m_a(Graphics var0, g var1, int var2, int var3)
        {
            var0.SetClip(0, 75, 240, 240);
            sbyte var4 = 65;
            if (var1.a[39] < 0)
            {
                var4 = 63;
            }
            else if (var1.a[42] > 0)
            {
                var4 = 67;
            }

            int var6 = var1.a[39];
            int var7 = m_e(39, 0);
            int var8 = m_e(39, 10);
            int var9 = m_e(39, var6);

            for (int var5 = 0; var5 < 5; var5++)
            {
                MiamiNights.h.u[1].m_a(var0, var4, 0, var2 + 16 * var5, var3, 0, 0, 0);
            }

            if (var6 < 0)
            {
                bool var10 = false;
                bool var11 = false;
                int var13 = 62 * (Math.Abs(var6) - 0) / 100;
                var13 += 16;
                var0.SetClip(var2, 75, var13, 240);

                for (int var16 = 0; var16 < 5; var16++)
                {
                    int var12 = var2 + 16 * var16;
                    MiamiNights.h.u[1].m_a(var0, var4 + 1, 0, var12, var3, 0, 0, 0);
                }
            }
            else if (var6 >= 10)
            {
                int var18;
                if ((var18 = var9 - var8) > 4)
                {
                    var18 = 4;
                }

                int var19 = 0;

                for (int var17 = 0; var17 <= var18; var17++)
                {
                    var19 = var2 + 16 * var17;
                    MiamiNights.h.u[1].m_a(var0, var4 + 1, 0, var19, var3, 0, 0, 0);
                }

                if (var18 < 4)
                {
                    int var21 = F[39] + 7 + (var9 - var7 + 1) * 4;
                    sbyte var23 = E[var21 + 2];
                    sbyte var14 = E[var21 + 3];
                    var19 += 16;
                    int var15;
                    if ((var15 = 42 * (var6 - var23) / (4 * (var14 - var23))) < 0)
                    {
                        var15 = 0;
                    }

                    var0.SetClip(var19, 75, var15, 240);
                    MiamiNights.h.u[1].m_a(var0, var4 + 1, 0, var19, var3, 0, 0, 0);
                }
            }
        }

        internal static void m_a(Graphics var0, bool var1, int var2, bool var3)
        {
            var0.SetClip(0, 75, 240, 240);
            if (!var1)
            {
                m_a(var0, 3, 77, 37, 37, 4891536, 0, 0);
                m_a(var0, 38, 96, 197, 18, 3635849, 0, 0);
                MiamiNights.h.bf[0] = 3;
                MiamiNights.h.bf[1] = 77;
                MiamiNights.h.bf[2] = 38;
                MiamiNights.h.bf[3] = 96;
                MiamiNights.h.bg = true;
                g var5;
                sbyte var6 = (var5 = MiamiNights.h.s[MiamiNights.f.av]).b[5];
                MiamiNights.h.n[var6].d_.m = var5.b[15];
                MiamiNights.h.n[var6].d_.m_a(var0, 66, 0, 21, 95, 0, 0, 0);
                string var7 = GloftMMN.m_k(var5.a[1]);
                var0.SetClip(44, 96, 109, 18);
                int var8 = 44;
                if (var3 && R >= 1000L)
                {
                    var5.m_q();
                    string var9 = GloftMMN.m_k(836);
                    var7 = var7 + var9 + ab + var9 + GloftMMN.m_k(837) + " " + ac + var9;
                    MiamiNights.h.M.m_a(var7);
                    int var10 = (int)((R - 1000L) * 44L) / 1000;
                    var8 = 44 - var10 % (MiamiNights.a.y + 109);
                    var8 += 109;
                }

                MiamiNights.h.M.m_a(var0, var7, var8, 98, 20, 0);
                m_a(var0, var5, 155, 99);
                R = R + MiamiNights.h.aH;
            }
            else
            {
                if (M != null)
                {
                    m_a(var0, 3, 112, 232, 80, 16777215, 0, 0);
                    Q = m_a(var0, M, Q, 115);
                    if (MiamiNights.h.K >= 4 && (MiamiNights.h.K - 4) % 4 < 2)
                    {
                        MiamiNights.h.v[7].d_.m_a(var0, 31, 0, 227, 186, 0, 0, 0);
                    }
                }
            }
        }

        internal static void m_b(Graphics var0)
        {
            var0.SetClip(0, 75, 240, 240);
            if (N.size() > 0)
            {
                int var1;
                int var2;
                string var3;
                string var4;
                if ((var4 = N.elementAt(0))[0] == '#')
                {
                    au = true;
                    if (MiamiNights.h.K == 0)
                    {
                        GloftMMN.m_c(2);
                    }

                    var3 = GloftMMN.m_k(841);
                    var4 = var4.Substring(1, var4.Length - 1);
                    var1 = 16711680;
                    var2 = 0;
                }
                else
                {
                    if (var4[0] == '!')
                    {
                        MiamiNights.h.z = 8;
                        return;
                    }

                    if (var4[0] == '%')
                    {
                        if (MiamiNights.f.av <= 0)
                        {
                            MiamiNights.h.z = 8;
                            return;
                        }

                        g var17;
                        int var18 = (var17 = MiamiNights.h.s[MiamiNights.f.av]).a[41];
                        int var19 = 0;

                        while (var19 < MiamiNights.h.d.Length && (var18 < MiamiNights.h.d[var19 + 0] || var18 < MiamiNights.h.d[var19 + 0]))
                        {
                            var19 += 4;
                        }

                        var4 = var4 + GloftMMN.m_k(var17.a[1]) + GloftMMN.m_k(886);
                        MiamiNights.h.z = 8;
                        int var8;
                        if ((var8 = MiamiNights.h.d[var19 + 2]) > 0)
                        {
                            var4 = var4 + var8.ToString() + " $";
                            MiamiNights.h.s[0].m_c(35, var8);
                        }
                        else
                        {
                            var19 = MiamiNights.h.d[var19 + 3];
                            g var12;
                            int var13 = (var12 = MiamiNights.h.s[0]).a[0];
                            int var14 = 0;
                            if (var19 == 1)
                            {
                                int var21 = var12.a[6];
                                int var23 = MiamiNights.h.a[var13].Length / 3;

                                int var22;
                                do
                                {
                                    var22 = GloftMMN.m_a(0, var23, var21);
                                }
                                while (++var14 < 32 && m_b(var22, -1) != -1);

                                V = (sbyte)((var12.a[6] + 1) * -1);
                                W = (sbyte)var12.a[7];
                                var12.a[6] = var22;
                                var12.a[7] = var12.a[7] + GloftMMN.m_c(1, 255);
                                var12.a[7] = var12.a[7] % MiamiNights.h.p[var13][2].l;
                                var4 = var4 + GloftMMN.m_k(883);
                                m_a(var22, -1, (sbyte)var12.a[7]);
                            }
                            else if (var19 == 2)
                            {
                                int var9 = var12.a[8];
                                int var11 = MiamiNights.h.p[var13][4].a_ / MiamiNights.h.r[var13][4];

                                int var10;
                                do
                                {
                                    var10 = GloftMMN.m_a(0, var11, var9);
                                }
                                while (++var14 < 32 && m_b(-1, var10) != -1);

                                V = (sbyte)(var12.a[8] + 1);
                                W = (sbyte)var12.a[9];
                                var12.a[8] = var10;
                                var12.a[9] = var12.a[9] + GloftMMN.m_c(1, 255);
                                var12.a[9] = var12.a[9] % MiamiNights.h.p[var13][4].l;
                                var4 = var4 + GloftMMN.m_k(883);
                                m_a(-1, var10, (sbyte)var12.a[7]);
                            }

                            MiamiNights.h.i = 0;
                            MiamiNights.h.z = 68;
                        }

                        N.setElementAt(var4, 0);
                        return;
                    }

                    if (var4[0] == '~')
                    {
                        g var6 = null;
                        int var7 = MiamiNights.f.av;
                        if (MiamiNights.f.av == -1)
                        {
                            for (int var5 = 1; var5 < MiamiNights.h.s.Length; var5++)
                            {
                                if (MiamiNights.h.s[var5] != null && (MiamiNights.h.s[var5].e != null || MiamiNights.h.s[var5].a[43] >= 0) && MiamiNights.h.s[var5].b[20] == 1)
                                {
                                    var6 = MiamiNights.h.s[var5];
                                    MiamiNights.f.av = var5;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            var6 = MiamiNights.h.s[MiamiNights.f.av];
                        }

                        if (var6 == null)
                        {
                            MiamiNights.h.i = 255;
                            return;
                        }

                        var0.SetClip(0, 0, 240, 400);
                        m_a(var0, false, 103, false);
                        M = m_b(var4.Substring(1, var4.Length - 1), 207);
                        m_a(var0, true, 103, false);
                        MiamiNights.f.av = var7;
                        return;
                    }

                    var3 = GloftMMN.m_k(842);
                    var1 = 0;
                    var2 = 11632793;
                }

                m_a(var0, 3, 155, 229, 19, var2, var1, var1);
                MiamiNights.h.M.m_a(var0, var3, 120, 156, 17, 0);
                m_a(var0, 3, 171, 229, 83, -1, var1, var1);
                var4 = m_b(var4, 207);
                Q = m_a(var0, var4, Q, 174);
                if (MiamiNights.h.K >= 4 && (MiamiNights.h.K - 4) % 4 < 2)
                {
                    MiamiNights.h.v[7].d_.m_a(var0, 31, 0, 224, 248, 0, 0, 0);
                }
            }
        }

        private static int m_a(Graphics var0, string var1, int var2, int var3)
        {
            MiamiNights.h.M.m_a(var0, var1, 116, var3, 17, 1);
            return var1.Length << 1;
        }

        internal static string m_b(string var0, int var1)
        {
            int var2 = 0;
            int var3 = 1;
            string var4 = "";

            do
            {
                MiamiNights.h.M.m_a(var0.Substring(var2, var3 - var2));
                if (MiamiNights.a.y < var1)
                {
                    var3++;
                }
                else
                {
                    if (var0[var3] == ' ')
                    {
                        var3--;
                    }

                    while (var3 >= 0 && var0[var3] != ' ' && var0[var3] != '\n')
                    {
                        var3--;
                    }

                    var4 = var4 + var0.Substring(var2, var3 - var2) + "\n";
                    var3 = (var2 = var3 + 1) + 1;
                }
            }
            while (var3 < var0.Length);

            return var4 + var0.Substring(var2, var0.Length - var2);
        }

        internal static int m_b(g var0)
        {
            int var1 = var0.b[6] & 255;
            bool var2 = MiamiNights.f.m_d(var0.b[13]) != -1;

            for (int var3 = 0; var3 < 25; var3++)
            {
                if (G[var3] == var1)
                {
                    return -2;
                }
            }

            if (!var2 && m_t())
            {
                return -3;
            }
            else
            {
                int var5 = -1;

                for (int var4 = 0; var4 < 25; var4++)
                {
                    if (G[var4] < 1)
                    {
                        var5 = var4;
                        break;
                    }
                }

                if (var5 == -1)
                {
                    return -1;
                }
                else
                {
                    G[var5] = var1;
                    var0.m_a();
                    return 1;
                }
            }
        }

        private static bool m_t()
        {
            int var0 = 0;

            for (int var1 = 0; var1 < 25; var1++)
            {
                if (G[var1] > 0 && MiamiNights.f.m_d(MiamiNights.h.s[G[var1]].b[13]) == -1)
                {
                    var0++;
                }
            }

            return var0 >= 9;
        }

        private static bool m_c(g var0)
        {
            for (int var1 = 0; var1 < 25; var1++)
            {
                if (G[var1] == (var0.b[6] & 255))
                {
                    return true;
                }
            }

            return false;
        }

        internal static void m_a(string var0)
        {
            N.addElement(var0);
        }

        internal static void m_a(bool var0, int var1)
        {
            if (var0)
            {
                if (var1 > u)
                {
                    u = var1;
                    return;
                }
            }
            else if (u == var1)
            {
                u = -1;
            }
        }

        internal void m_n()
        {
            d var1 = MiamiNights.h.n[this.b[5] & 255];
            if (this.b[7] != -1)
            {
                var1.c = this.b[7];
            }

            this.m_a((int)this.b[2], -1, -1);
            MiamiNights.f.m_c(this.b[6] & 255);
        }

        internal void m_a(int var1, int var2, int var3)
        {
            d var4;
            (var4 = MiamiNights.h.n[this.b[5] & 255]).e = -1;
            if (var1 < 0)
            {
                var1 = 0;
            }

            this.b[2] = (sbyte)var1;
            this.a[44] = var1;
            int var5 = 1 + var1 * 5;
            int var6 = MiamiNights.f.aL[var5 + 0] & 255;
            this.b[11] = (sbyte)var6;
            if (var3 == -1)
            {
                var4.m_a(var6);
                this.b[8] = 0;
                this.b[9] = 0;
                this.b[10] = (sbyte)var4.m_b(var6);
                this.b[12] = 0;
            }
            else
            {
                int var7 = (MiamiNights.f.aL[var5 + 1] & 255) >> 3;
                var5 = 1 + var3 * 5;
                int var8 = (MiamiNights.f.aL[var5 + 1] & 255) >> 3;
                int var9 = MiamiNights.f.aL[var5 + 0] & 255;
                int var10 = var4.m_b(var6);
                int var11 = var4.m_b(var9);
                int var12 = var8 + var10;
                if (var7 + var11 > var12)
                {
                    var12 = var7 + var11;
                }

                if (var8 == 0)
                {
                    var4.m_a(var6);
                }
                else
                {
                    var4.m_a(0);
                }

                this.b[8] = (sbyte)var8;
                this.b[9] = 0;
                this.b[10] = (sbyte)var12;
            }

            if (var2 == 0)
            {
                var4.c = 0;
            }
            else
            {
                if (var2 == 1)
                {
                    var4.c = 1;
                }
            }
        }

        internal void m_o()
        {
            if (m_l())
            {
                if (!this.A)
                {
                    d var1 = MiamiNights.h.n[this.b[5] & 255];
                    sbyte var2;
                    if ((var2 = this.b[12]) != 0)
                    {
                        g var3;
                        if ((var3 = MiamiNights.h.s[var2]).A)
                        {
                            return;
                        }

                        if (this.b[3] != 1 && var3.b[3] == 1)
                        {
                            var1.m_a(0);
                            return;
                        }
                    }

                    int var12;
                    if ((var12 = this.b[11] & 255) != 4 && var12 != 6)
                    {
                        int var14 = this.b[9] & 255;
                        int var15;
                        if (((var15 = this.b[8] & 255) != 0 || var14 != 0) && var14 != var15 - 1)
                        {
                            if (var14 == (this.b[10] & 255) - 1)
                            {
                                this.b[9] = 0;
                                return;
                            }

                            if (var1.m_a())
                            {
                                var1.m_a(0);
                            }
                        }
                        else
                        {
                            var1.m_a(var12);
                        }

                        this.b[9]++;
                    }
                    else
                    {
                        if (var12 != 6 && MiamiNights.f.av == this.b[6])
                        {
                            var1.m_a(0);
                            MiamiNights.f.m_a(this, MiamiNights.h.s[0]);
                            return;
                        }

                        short[] var4 = MiamiNights.f.e[this.b[14] & 255];
                        if (this.b[18] == -1)
                        {
                            if (this.av == null)
                            {
                                this.av = new int[2];
                            }
                            else if (!m_c(this) && !MiamiNights.h.au)
                            {
                                this.m_b(this.b[13], false);
                                this.m_a(7 + this.a[0] * 2, this.b[6], false);
                            }

                            this.b[18] = (sbyte)var4[8];
                            MiamiNights.f.k[(this.c[0] >> 8) + (this.c[1] >> 8) * MiamiNights.f.t] = (short)(MiamiNights.f.k[(this.c[0] >> 8) + (this.c[1] >> 8) * MiamiNights.f.t] & -15873);
                            MiamiNights.f.m_a(this.b[14], this.c);
                            this.m_a(this.c[0], this.c[1]);
                        }

                        int var5;
                        MiamiNights.f.m_a(var5 = MiamiNights.f.m_a(97, this.b[18]), this.av);
                        int var6 = this.c[0];
                        int var7 = this.c[1];
                        bool var8 = this.m_a(this.av);
                        int var9 = this.c[0];
                        int var10 = this.c[1];
                        this.c[0] = var6;
                        this.c[1] = var7;
                        this.m_a(var9, var10);
                        if (var8)
                        {
                            short var11;
                            if ((var11 = (var4 = MiamiNights.f.e[var5])[4]) == -3)
                            {
                                this.m_a(0, -1, -1);
                                return;
                            }

                            if (var11 == -2)
                            {
                                this.b[20] = 0;
                                this.m_a(-255, -255);
                                return;
                            }

                            this.b[18] = (sbyte)var4[4];
                            return;
                        }
                    }
                }
            }
        }

        private static sbyte[] m_a(sbyte[] var0)
        {
            sbyte[] var6 = new sbyte[8];
            int var8 = 0;
            int var1 = MiamiNights.f.aK[C++] & 255;
            int var2 = MiamiNights.f.aK[C++] & 255;
            int var3 = MiamiNights.f.aK[C++] & 255;

            for (int var4 = 0; var4 < var3; var4++)
            {
                var6[var4] = MiamiNights.f.aK[C++];
            }

            if (var0 != null)
            {
                int var9 = var3;

                for (int var5 = 0; var5 < var0.Length; var5++)
                {
                    for (int var10 = 0; var10 < var3; var10++)
                    {
                        if (var6[var10] == var0[var5])
                        {
                            var9--;
                        }
                    }
                }

                if (var2 > var9)
                {
                    var2 = var9;
                }

                if (var1 > var2)
                {
                    var1 = var2;
                }
            }

            if ((var8 = GloftMMN.m_c(var1, var2 + 1)) <= 0)
            {
                return null;
            }
            else
            {
                sbyte[] var7 = new sbyte[var8];

                for (int var11 = 0; var11 < var7.Length; var11++)
                {
                    var7[var11] = -1;
                    bool var14 = false;

                    while (var7[var11] == -1 || var14)
                    {
                        var8 = GloftMMN.m_c(0, var3);
                        var7[var11] = var6[var8];
                        var14 = false;
                        if (var0 != null)
                        {
                            for (int var12 = 0; var12 < var0.Length; var12++)
                            {
                                if (var7[var11] == var0[var12])
                                {
                                    var14 = true;
                                    break;
                                }
                            }
                        }
                    }

                    var6[var8] = -1;
                }

                return var7;
            }
        }

        internal static bool m_g(int var0)
        {
            switch (var0)
            {
                case 0:
                case 2:
                case 3:
                case 4:
                case 5:
                case 8:
                case 10:
                case 11:
                case 87:
                case 89:
                case 90:
                case 93:
                case 95:
                case 96:
                    return false;
                case 1:
                case 6:
                case 7:
                case 9:
                case 12:
                case 13:
                case 88:
                case 91:
                case 92:
                case 94:
                case 97:
                case 98:
                    return true;
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                case 46:
                case 47:
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                case 86:
                default:
                    return false;
            }
        }

        internal bool m_a(int[] var1)
        {
            int var2 = var1[0] - this.c[0];
            int var3 = var1[1] - this.c[1];
            int var4;
            if ((var4 = GloftMMN.m_a((long)(var2 * var2 + var3 * var3))) > 0)
            {
                var2 = (var2 << 8) / var4;
                var3 = (var3 << 8) / var4;
            }

            if (var4 <= 32)
            {
                this.c[0] = var1[0];
                this.c[1] = var1[1];
                return true;
            }
            else
            {
                int[] var5 = new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                int var6 = this.c[0] + var2 * 60 * 2 / 1000;
                int var7 = this.c[1] + var3 * 60 * 2 / 1000;
                int var8 = var6 >> 8;
                int var9 = var7 >> 8;
                int var10 = this.c[0] >> 8;
                int var11 = this.c[1] >> 8;
                int var12 = var8 - var10;
                int var13 = var9 - var11;
                var5[0] = var8;
                var5[1] = var9;
                if (var12 != 0 && var13 != 0)
                {
                    var5[5] = var10 + var12;
                    var5[6] = var11;
                    var5[10] = var10;
                    var5[11] = var11 + var13;
                }
                else
                {
                    var5[5] = var10 - var13;
                    var5[6] = var11 + var12;
                    var5[10] = var10 + var13;
                    var5[11] = var11 - var12;
                }

                for (int var14 = 0; var14 < 3; var14++)
                {
                    int var15 = var14 * 5;
                    int var16 = (var5[var15 + 0] << 8) + 127;
                    int var17 = (var5[var15 + 1] << 8) + 127;
                    if (var14 == 0)
                    {
                        var16 = var6;
                        var17 = var7;
                    }

                    int var18;
                    bool var19 = (var18 = MiamiNights.f.m_b(var16, var17)) != 1;
                    bool var20 = !MiamiNights.f.m_a(var18, var16, var17, this.b[6], this == MiamiNights.h.s[0]);
                    int var21 = 0;   // CFR: int (VF byte mis-inference)
                    if (var19 && var20)
                    {
                        var21 = 1;
                    }

                    var5[var15 + 2] = var21;
                    var5[var15 + 3] = MiamiNights.f.m_a(var10, var11, var5[var15 + 0], var5[var15 + 1]);
                    var5[var15 + 4] = MiamiNights.f.m_a(var1[0] >> 8, var1[1] >> 8, var5[var15 + 0], var5[var15 + 1]);
                }

                if (var5[2] != 1)
                {
                    int var28 = -1;
                    int var29 = 100000;

                    for (int var25 = 0; var25 < 3; var25++)
                    {
                        int var26 = var25 * 5;
                        if (var5[var26 + 2] == 1 && var5[var26 + 4] < var29)
                        {
                            var29 = var5[var26 + 4];
                            var28 = var25;
                        }
                    }

                    if (var28 != -1)
                    {
                        int var27 = var28 * 5;
                        var2 = var5[var27 + 0] - var10 << 8;
                        var3 = var5[var27 + 1] - var11 << 8;
                        var4 = GloftMMN.m_a((long)(var2 * var2 + var3 * var3));
                        var2 = (var2 << 8) / var4;
                        var3 = (var3 << 8) / var4;
                    }
                }

                this.c[0] = this.c[0] + var2 * 60 * 2 / 1000;
                this.c[1] = this.c[1] + var3 * 60 * 2 / 1000;
                MiamiNights.f.m_a(this, var2, var3, 6, 4);
                return false;
            }
        }

        internal bool m_a(int var1, int var2, int var3, int var4, bool var5)
        {
            d var6;
            bool var7;
            if (var7 = (var6 = MiamiNights.h.n[this.b[5] & 255]) == MiamiNights.h.n[0])
            {
                var3 += v;
            }

            if (var3 != -1)
            {
                var6.m_a(var3);
            }

            if (var4 != -1)
            {
                var6.c = var4;
            }

            int var8 = 0;
            int var9 = 0;
            if (var5)
            {
                var8 = var1;
                var9 = var2;
                var1 -= this.c[0];
                var2 -= this.c[1];
            }
            else
            {
                int var10;
                if ((var10 = (int)MiamiNights.h.aH) > 200)
                {
                    var10 = 200;
                }

                var8 = this.c[0] + var1 * var10 / 1000;
                var9 = this.c[1] + var2 * var10 / 1000;
            }

            bool var15 = false;
            bool var11 = false;
            if (var7)
            {
                int[] var12 = new int[]{0, 0};
                MiamiNights.f.m_a(var8, var9, var12);
                if (var2 < 0 || var1 > 0)
                {
                    var12[0] += 14;
                }

                if (var2 > 0 || var1 < 0)
                {
                    var12[0] -= 14;
                }

                if (MiamiNights.f.m_a(var12) == -1)
                {
                    var15 = true;
                }
            }

            MiamiNights.h.aR = var15;
            if (!var15)
            {
                if (!MiamiNights.f.m_a(var8, var9, 127))
                {
                    this.c[0] = var8;
                    this.c[1] = var9;
                    var11 = true;
                }
                else if (!MiamiNights.f.m_a(var8, this.c[1], 127))
                {
                    this.c[0] = var8;
                    var11 = true;
                }
                else if (!MiamiNights.f.m_a(this.c[0], var9, 127))
                {
                    this.c[1] = var9;
                    var11 = true;
                }
            }

            this.o[0] = var1;
            this.o[1] = var2;
            MiamiNights.f.m_c(this.o);
            this.n[0] = var1 * MiamiNights.f.w[0] + var2 * MiamiNights.f.x[0] >> 8;
            this.n[1] = var1 * MiamiNights.f.w[1] + var2 * MiamiNights.f.x[1] >> 8;
            MiamiNights.f.m_c(this.n);
            if (var7)
            {
                p = 0L;
            }

            return var11;
        }

        internal static void m_c(Graphics var0)
        {
            if (N.size() > 0)
            {
                MiamiNights.h.z = 17;
            }
            else
            {
                if (MiamiNights.h.m >= 0)
                {
                    MiamiNights.h.z = 18;
                    MiamiNights.h.L = 0;
                    MiamiNights.h.H = MiamiNights.h.m;
                    MiamiNights.h.m = -1;
                }
                else if (MiamiNights.f.av >= 0 && !au && !MiamiNights.h.O)
                {
                    MiamiNights.f.m_a(var0, true);
                }
                else if (O != 0)
                {
                    MiamiNights.h.m_a(O);
                    MiamiNights.h.y = P;
                    P = 0;
                    MiamiNights.h.K = 0;
                    MiamiNights.h.z = -1;
                }

                au = false;
                O = 0;
            }
        }

        internal static void m_p()
        {
            if (MiamiNights.f.ax != -1)
            {
                int var1 = MiamiNights.f.m_g(MiamiNights.f.m_i(MiamiNights.f.ax, 5), -1);
                MiamiNights.f.ap[var1] = MiamiNights.f.aT;
            }

            MiamiNights.h.n[0].m_a(0);
            MiamiNights.f.ax = -1;
            MiamiNights.f.m_i();
            MiamiNights.h.z = 0;
            MiamiNights.h.N[3] = 0;
            MiamiNights.f.m_c();
        }

        static g()
        {
            sbyte[][] var10000 = new sbyte[][]{ new sbyte[]{21}, new sbyte[]{7, 10}, new sbyte[]{0, 1}, new sbyte[]{7, 10, 3} };
        }
    }
}
