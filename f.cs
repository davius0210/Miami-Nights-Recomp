// Port of original class f — level/object loader, map renderer, shop/NPC glue
// (validated source: decompile_vf/f.java, javac-clean).
// R1: class f collision list a..s -> ALL methods renamed m_a..m_s (decls + call sites).
// R5: class f's own field `f` (short) -> f_ (decl + accesses).
// byte -> sbyte everywhere; (byte)x -> (sbyte)x; x & 255 kept (sign-extend+mask = identical).
using System;
using System.IO;

namespace MiamiNights
{
    public sealed class f
    {
        internal static int a;
        internal static a[] b;
        internal static d[] c;
        internal static bool d = false;
        internal static short[][] e;
        internal static short f_;                 // R5: was `f` (collides with class name)
        internal static Graphics g;
        internal static sbyte[] h;
        internal static sbyte[] i;
        internal static sbyte[][] j;
        internal static short[] k;
        internal static sbyte[] l;
        internal static Image m;
        internal static int n;
        internal static int o;
        internal static sbyte[] p = null;
        internal static sbyte[] q = null;
        internal static sbyte r = -1;
        internal static sbyte s = -1;
        internal static int t;
        internal static int u;
        internal static int v;
        internal static int[] w = new int[]{128, 128};
        internal static int[] x = new int[]{-128, 128};
        internal static int y;
        internal static int z;
        internal static int A;
        internal static int B;
        internal static int C;
        internal static int D;
        internal static int E = -10000;
        internal static int F = -10000;
        internal static sbyte[] G = null;
        internal static short[] H = null;
        internal static sbyte[] I = null;
        internal static bool J;
        internal static sbyte K;
        internal static int[][] L = new int[][]{ new int[]{0, 7}, new int[]{0, 7}, new int[]{22, 7}, new int[]{0, 3}, new int[]{0, 3}, new int[]{-7, 7}, new int[]{0, -82}, new int[]{0, 7}, new int[]{0, -82} };
        internal static int[] M = new int[]{0, 0};
        internal static int[] N = new int[]{0, 0};
        internal static int[] O = new int[]{0, 0};
        internal static int[] P = new int[]{0, 0};
        internal static int[] Q = new int[256];
        internal static int[] R = new int[256];
        internal static int S;
        internal static int T;
        internal static int U;
        internal static int V;
        internal static sbyte[] W = new sbyte[256];
        internal static int X;
        internal static sbyte[] Y;
        internal static sbyte[] Z;
        internal static sbyte[] aa;
        internal static sbyte[] ab;
        internal static sbyte[] ac;
        internal static sbyte[] ad;
        internal static sbyte[] ae;
        internal static sbyte[] af;
        internal static int[][] ag;
        internal static bool ah;
        internal static int ai = -1;
        internal static Graphics aj;
        internal static int[] ak;
        internal static sbyte al;
        internal static int am;
        internal static sbyte[] an = null;
        internal static int[] ao = null;
        internal static long[] ap = null;
        internal static bool aq;
        internal static bool ar;
        internal static int @as;
        internal static sbyte[] at;
        internal static int au;
        internal static int av;
        internal static int aw;
        internal static sbyte ax = -1;
        internal static sbyte ay;
        internal static int az;
        internal static int aA;
        internal static long aB;
        internal static sbyte aC;
        internal static bool aD;
        internal static int aE;
        internal static d aF;
        internal static sbyte aG;
        internal static int aH;
        internal static int[] aI = new int[]{0, 0};
        internal static sbyte[] aJ;
        internal static sbyte[] aK;
        internal static sbyte[] aL;
        internal static int aM;
        internal static int aN;
        internal static int aO;
        internal static int aP;
        internal static int aQ;
        internal static int aR;
        internal static Vector<string> aS = new Vector<string>();
        internal static long aT;
        internal static long aU;
        internal static int aV;
        internal static string[] aW;
        internal static int[] aX;
        internal static int aY;
        internal static d[] aZ;
        internal static bool ba;
        internal static sbyte[] bb;
        internal static sbyte[] bc;
        internal static int bd;
        internal static string be = null;
        internal static sbyte[] bf;
        internal static sbyte bg = -1;
        internal static sbyte bh;
        internal static int bi;
        internal static int bj;
        internal static bool bk = false;
        internal static int bl;
        internal static sbyte bm = -1;
        internal static bool bn = false;
        internal static int[] bo;
        public static Player bp = null;

        // original static void a(boolean)
        internal static void m_a(bool var0)
        {
            GloftMMN.m_a("LEVELS_INIT START");
            b = new a[98];

            try
            {
                GloftMMN.m_b("/8");
                MiamiNights.h.m_a(0, b, 2, false, false, -1, false);
                GloftMMN.m_h(1);
                GloftMMN.m_a("LEVELS_INIT AFTER OPEN PACK");
                int var2;
                h = new sbyte[var2 = GloftMMN.m_g() * 90];
                GloftMMN.m_a(h, 0, var2);
                GloftMMN.m_a("LEVELS_INIT AFTER BG SETS");
                GloftMMN.m_h(3);
                i = new sbyte[GloftMMN.m_g() * 3];
                GloftMMN.m_a(i, 0, i.Length);
                GloftMMN.m_a("LEVELS_INIT AFTER MAPS");
                GloftMMN.m_h(4);
                ak = new int[18];

                for (int var1 = 2; var1 < 18; var1++)
                {
                    int var3 = GloftMMN.m_g();
                    int var4 = GloftMMN.m_g();
                    int var5 = GloftMMN.m_g();
                    ak[var1] = unchecked((int)0xFF000000) | var3 << 16 | var4 << 8 | var5;
                }

                ak[0] = -1;
                ak[1] = -1;
                m_q();
                GloftMMN.m_a("LEVELS_INIT AFTER OBJECT SIZES & daytimeColors");
                if (var0)
                {
                    GloftMMN.m_f();
                    GloftMMN.m_a("LEVELS_INIT END");
                }
            }
            catch (Exception) { }
        }

        // original static void b(boolean)
        internal static void m_b(bool var0)
        {
            if (var0)
            {
                MiamiNights.h.u = new a[6];
                MiamiNights.h.v = new d[20];
                GloftMMN.m_b("/10");
                MiamiNights.h.m_a(3, MiamiNights.h.u, 3, true, true, 1, true);
                MiamiNights.h.m_a(0, MiamiNights.h.u, 0, true, true, 1, true);
                MiamiNights.h.m_a(1, MiamiNights.h.u, 1, true, true, 1, false);
                MiamiNights.h.m_a(2, MiamiNights.h.u, 2, true, true, 1, false);
                GloftMMN.m_f();
                MiamiNights.h.v[7] = new d(MiamiNights.h.u[3], 0, 0, null);
                MiamiNights.h.v[0] = new d(MiamiNights.h.u[0], 0, 0, null);
                MiamiNights.h.v[3] = new d(MiamiNights.h.u[0], 0, 0, null);
                MiamiNights.h.v[4] = new d(MiamiNights.h.u[0], 0, 0, null);
                MiamiNights.h.v[1] = new d(MiamiNights.h.u[0], 0, 0, null);
                MiamiNights.h.v[2] = new d(MiamiNights.h.u[0], 0, 0, null);
                MiamiNights.h.v[17] = new d(MiamiNights.h.u[1], 0, 0, null);
                MiamiNights.h.v[17].e = -1;
                MiamiNights.h.v[18] = new d(MiamiNights.h.u[1], 0, 0, null);
                MiamiNights.h.v[18].e = -1;
                MiamiNights.h.v[19] = new d(MiamiNights.h.u[1], 0, 0, null);
                MiamiNights.h.v[9] = new d(MiamiNights.h.u[3], 0, 0, null);
                MiamiNights.h.v[10] = new d(MiamiNights.h.u[3], 0, 0, null);
                MiamiNights.h.v[5] = new d(MiamiNights.h.u[3], 0, 0, null);
                MiamiNights.h.v[6] = new d(MiamiNights.h.u[3], 0, 0, MiamiNights.h.v[5]);
                MiamiNights.h.v[8] = new d(MiamiNights.h.u[3], 120, 200, null);
                MiamiNights.h.v[8].m_a(8);
                MiamiNights.h.v[11] = new d(MiamiNights.h.u[1], 0, 0, null);
                MiamiNights.h.v[12] = new d(MiamiNights.h.u[1], 0, 0, null);
            }
            else
            {
                for (int var1 = 0; var1 < MiamiNights.h.v.Length; var1++)
                {
                    MiamiNights.h.v[var1] = null;
                }

                for (int var2 = 0; var2 < MiamiNights.h.u.Length; var2++)
                {
                    MiamiNights.h.u[var2] = null;
                }

                if (MiamiNights.h.s != null)
                {
                    for (int var3 = 0; var3 < MiamiNights.h.s.Length; var3++)
                    {
                        if (MiamiNights.h.s[var3] != null)
                        {
                            MiamiNights.h.s[var3].y = null;
                            MiamiNights.h.s[var3].z = null;
                        }
                    }
                }

                MiamiNights.g.S = null;
                MiamiNights.g.T = null;
                aZ = null;
                MiamiNights.h.u = null;
                MiamiNights.h.v = null;
            }
        }

        // original static void a() — font archive load
        internal static void m_a()
        {
            GloftMMN.m_b("/2");
            MiamiNights.h.M = new a();
            MiamiNights.h.M.m_a(GloftMMN.m_j(0), 0, 2, false);
            GloftMMN.m_h(1);
            sbyte[] var1;
            GloftMMN.m_a(var1 = new sbyte[GloftMMN.i[1]]);
            GloftMMN.m_f();
            MiamiNights.h.M.m_a(1, 0, -1, -1, 0);
            MiamiNights.h.M.m_a(0, 0, -1, -1, 1);
            MiamiNights.h.M.m_b();
            MiamiNights.h.M.A = new sbyte[256];

            for (int var0 = 65; var0 <= 90; var0++)
            {
                MiamiNights.h.M.A[var0] = (sbyte)(var0 - 65 + 3);
            }

            for (int var2 = 48; var2 <= 57; var2++)
            {
                MiamiNights.h.M.A[var2] = (sbyte)(var2 - 48 + 26 + 3);
            }

            for (int var3 = 0; var3 < var1.Length; var3++)
            {
                MiamiNights.h.M.A[var1[var3] & 255] = (sbyte)(39 + var3);
            }

            MiamiNights.h.M.A[209] = 2;
            MiamiNights.h.M.m_c(2);
        }

        // original private static void a(int, a)
        private static void m_a(int var0, a var1)
        {
            try
            {
                GloftMMN.m_h(var0);
                int var4 = GloftMMN.m_g();
                GloftMMN.m_g();
                int var5 = var1.l;

                for (int var2 = 0; var2 < var5; var2++)
                {
                    var1.k[var2] = new int[var4];

                    for (int var3 = 0; var3 < var4; var3++)
                    {
                        var1.k[var2][var3] = m_a(GloftMMN.m_h());
                    }
                }
            }
            catch (Exception) { }
        }

        // original static void b() — clear all object sprites
        internal static void m_b()
        {
            k = null;
            l = null;
            if (c != null)
            {
                for (int var0 = 0; var0 < c.Length; var0++)
                {
                    c[var0] = null;
                }
            }

            c = null;
            GloftMMN.m_a("AFTER CLEAR ALL OBJECT SPRITE INSTANCES");
            if (b != null)
            {
                for (int var1 = 3; var1 < b.Length; var1++)
                {
                    b[var1] = null;
                }

                if (b[0] != null)
                {
                    b[0].m_a();
                }

                if (b[1] != null)
                {
                    b[1].m_a();
                }

                if (b[2] != null)
                {
                    b[2].m_a();
                }
            }

            GloftMMN.m_a("AFTER CLEAR ALL OBJECT SPRITES");
            Y = null;
            Z = null;
            aa = null;
            ab = null;
            ac = null;
            ad = null;
            ae = null;
            af = null;
            ag = (int[][])null;
            aF = null;
            e = (short[][])null;
            k = null;
            l = null;
            p = null;
            q = null;
            GloftMMN.m_a("AFTER CLEAR ALL MISC ARRAYS");
        }
        // original static boolean a(Graphics, int) — level load state machine (bd)
        internal static bool m_a(Graphics var0, int var1)
        {
            GloftMMN.m_a("LLOAD STEP " + bd);
            if (MiamiNights.h.k)
            {
                bd = 0;
            }

            g var7 = MiamiNights.h.s[0];
            bool var8 = MiamiNights.h.h_ == 18;
            switch (bd)
            {
                case 0:
                    GloftMMN.m_b();
                    if (a > 0)
                    {
                        GloftMMN.m_b(5);
                        a = -1;
                        GloftMMN.m_a("CLEAN AFTER UNLOAD SOUND");
                    }

                    if (MiamiNights.h.k)
                    {
                        GloftMMN.m_a("/3", 0);
                        GloftMMN.m_a("RELOADING DATA BECAUSE INTERUPTED !!!");
                        m_a();
                        m_b(true);
                    }

                    MiamiNights.g.N.removeAllElements();
                    if (MiamiNights.h.J)
                    {
                        m = null;
                        aj = null;
                        GloftMMN.m_a("CLEAN AFTER BB FREE");
                    }

                    var0.SetColor(0);
                    var0.FillRect(0, 0, 240, 400);
                    GloftMMN.m_a("CLEAN BEFORE LOADING PNG OPENING");
                    if (!var8)
                    {
                        GloftMMN.m_b("/1");
                        sbyte[] var108 = GloftMMN.m_j(1);
                        GloftMMN.m_f();
                        // PORT-QUESTION: Java Image.createImage(byte[],...) takes sbyte[] here -> Helpers.ToB
                        MiamiNights.h.Q = Image.CreateImage(Helpers.ToB(var108), 0, var108.Length);
                    }

                    GloftMMN.m_a("AFTER LOADING PNG OPENING");
                    d var109;
                    (var109 = MiamiNights.h.v[7]).a = 30720;
                    var109.b = 51200;
                    var109.m_a(47);
                    var109.m_a(var0);
                    MiamiNights.h.Q = null;
                    GloftMMN.m_a("AFTER LOAD IMAGE DISALLOCATED ! cGame.m_MapImage=" + MiamiNights.h.Q);
                    MiamiNights.h.m_d();
                    break;
                case 1:
                    if (bc[26] > 0
                       && !var8
                       && (bc[0] >= 30 && var1 != 22 && var1 != 34 && var1 != 35 && var1 != 23 || bc[0] < 30 && var1 != 0 && var1 != 1 && var1 != 2 && var1 != 5))
                    {
                        g var107;
                        (var107 = MiamiNights.h.s[bc[26]]).s = false;
                        MiamiNights.g.m_a(GloftMMN.m_k(888) + GloftMMN.m_k(var107.a[1]) + GloftMMN.m_k(889));
                        var107.b[2] = var107.b[4];
                        var107.b[3] = 0;
                        var107.b[4] = -1;
                        bc[26] = -1;
                    }

                    bc[7] = (sbyte)var1;
                    K = (sbyte)var1;
                    GloftMMN.m_a("BEFORE TXT FREE");
                    if (MiamiNights.h.J)
                    {
                        GloftMMN.n = null;
                        GloftMMN.o = null;
                    }

                    GloftMMN.m_a("CLEAN AFTER TXT FREE");
                    GloftMMN.m_a("BEFORE FONT FREE " + GloftMMN.g);
                    MiamiNights.h.M = null;
                    GloftMMN.m_a("CLEAN AFTER FONT FREE");
                    break;
                case 2:
                    if (!var8)
                    {
                        GloftMMN.m_a("BEFORE IFACE FREE " + GloftMMN.g);
                        m_b(false);
                        GloftMMN.m_a("CLEAN AFTER IFACE FREE " + GloftMMN.g);
                    }

                    ai = -1;
                    MiamiNights.h.au = false;
                    if (MiamiNights.h.X != 0)
                    {
                        MiamiNights.g.m_e();
                        MiamiNights.g.m_b(true);

                        for (int var78 = 0; var78 < MiamiNights.g.G.Length; var78++)
                        {
                            MiamiNights.g.G[var78] = 0;
                        }
                    }

                    aW = new string[4];
                    break;
                case 3:
                    m_e();
                    break;
                case 4:
                    m_b();
                    p = null;
                    q = null;
                    j = (sbyte[][])null;
                    break;
                case 5:
                    for (int var77 = 0; var77 < 5; var77++)
                    {
                        GloftMMN.m_a("AFTER GC " + var77);
                    }
                    break;
                case 6:
                    GloftMMN.m_a("CLEAN END");
                    aU = 100L;
                    int var36 = 3 * var1;
                    y = i[var36 + 0];
                    z = i[var36 + 1];
                    A = i[var36 + 2];
                    GloftMMN.m_b("/8");
                    GloftMMN.m_h(2);
                    j = new sbyte[GloftMMN.m_g()][];

                    for (int var95 = 0; var95 <= z; var95++)
                    {
                        int var105 = GloftMMN.m_g();
                        int var112 = GloftMMN.m_g();
                        int var114 = var105 * var112 >> 1;
                        if (var95 != y && var95 != z)
                        {
                            // original GloftMMN.i(int) — renamed SkipBytes in GloftMMN.cs (currently private)
                            GloftMMN.SkipBytes(var114);
                        }
                        else
                        {
                            int var115 = 0;
                            j[var95] = new sbyte[var105 * var112 + 2];
                            sbyte[] var187 = j[var95];
                            var115++;
                            var187[0] = (sbyte)var105;
                            var187 = j[var95];
                            var115++;
                            var187[1] = (sbyte)var112;

                            for (int var120 = 0; var120 < var114; var120++)
                            {
                                int var122 = GloftMMN.m_g();
                                j[var95][var115++] = (sbyte)(var122 >> 4 & 15);
                                j[var95][var115++] = (sbyte)(var122 & 15);
                            }
                        }
                    }

                    GloftMMN.m_a("LEVELS_INIT AFTER LAYERS");
                    GloftMMN.m_f();
                    p = j[y];
                    q = j[z];
                    r = p[0];
                    s = p[1];
                    B = A * 90;
                    int var106 = j[y][0] & 255;
                    int var113 = j[y][1] & 255;
                    t = var106;
                    u = var113;
                    v = (var113 * w[1] + var106 * x[1]) * 22 >> 8;
                    v += 65;
                    break;
                case 7:
                    GloftMMN.m_b("/13");
                    GloftMMN.m_h(0 + var1);
                    e = new short[140][];

                    int var9;
                    for (f_ = 0; (var9 = GloftMMN.m_g()) != 0; f_++)
                    {
                        e[f_] = new short[var9];

                        for (int var94 = 0; var94 < var9; var94++)
                        {
                            e[f_][var94] = (short)(GloftMMN.m_g() | GloftMMN.m_g() << 8);
                        }

                        e[f_][1] = (short)(e[f_][1] * 136 / 100);
                        e[f_][2] = (short)(e[f_][2] * 136 / 100);
                    }

                    GloftMMN.m_f();
                    var9 = m_a(95, -1);
                    short[] var110 = e[var9];

                    for (int var74 = 0; var74 < 8; var74++)
                    {
                        bb[var74] = (sbyte)var110[var74 + 4];
                    }

                    var9 = m_a(96, -1);
                    var110 = e[var9];

                    for (int var75 = 8; var75 < 16; var75++)
                    {
                        bb[var75] = (sbyte)var110[var75 - 8 + 3];
                    }

                    int var11;
                    if ((var11 = m_a(91, -1)) >= 0)
                    {
                        m_a(var11, MiamiNights.h.s[0].c);
                    }

                    if (bg >= 0 && bg != 14)
                    {
                        for (int var76 = 0; var76 < f_; var76++)
                        {
                            if (e[var76][0] == 94 && e[var76][4] == bg)
                            {
                                m_a(var76, MiamiNights.h.s[0].c);
                                goto label1358;      // Java: break label1358 (exits the switch)
                            }
                        }
                    }
                    break;
                case 8:
                    if (ah)
                    {
                        for (int var56 = 0; var56 < 32; var56++)
                        {
                            bc[var56] = MiamiNights.h.aw[70 + var56];
                        }

                        for (int var57 = 0; var57 < 16; var57++)
                        {
                            bb[var57] = MiamiNights.h.aw[102 + var57];
                        }

                        for (int var58 = 0; var58 < MiamiNights.g.D; var58++)
                        {
                            if (var58 >= 4 && var58 <= 11 && (var58 - 4) % 2 == 1)
                            {
                                var7.a[var58] = MiamiNights.h.aw[2 + var58] & 255;
                            }
                            else
                            {
                                var7.a[var58] = MiamiNights.h.aw[2 + var58];
                            }
                        }

                        MiamiNights.h.n[0].d_ = MiamiNights.h.o[var7.a[0]];
                        var7.c[0] = MiamiNights.h.m_a(MiamiNights.h.aw, 49);
                        var7.c[1] = MiamiNights.h.m_a(MiamiNights.h.aw, 53);
                        var7.a[35] = MiamiNights.h.m_a(MiamiNights.h.aw, 57);
                        aT = MiamiNights.h.m_b(MiamiNights.h.aw, 62);

                        for (int var59 = 0; var59 < MiamiNights.g.ah.Length; var59++)
                        {
                            MiamiNights.g.ah[var59] = MiamiNights.h.aw[118 + var59];
                            MiamiNights.g.f[var59] = MiamiNights.h.aw[157 + var59];
                        }

                        for (int var60 = 0; var60 < MiamiNights.g.ai.Length; var60++)
                        {
                            MiamiNights.g.ai[var60] = MiamiNights.h.aw[196 + var60] == 1;
                        }

                        for (int var61 = 0; var61 < 16; var61++)
                        {
                            MiamiNights.g.ag[var61] = MiamiNights.h.m_b(MiamiNights.h.aw, 235 + var61 * 8);
                        }

                        for (int var62 = 0; var62 < var7.an.Length; var62++)
                        {
                            var7.an[var62] = MiamiNights.h.aw[455 + var62];
                        }

                        for (int var63 = 0; var63 < ap.Length; var63++)
                        {
                            ap[var63] = MiamiNights.h.m_b(MiamiNights.h.aw, 495 + var63 * 8);
                        }

                        for (int var64 = 0; var64 < 25; var64++)
                        {
                            MiamiNights.g.G[var64] = MiamiNights.h.aw[1007 + var64] & 255;
                        }

                        for (int var65 = 0; var65 < 168; var65++)
                        {
                            MiamiNights.g.I[var65] = MiamiNights.h.aw[1032 + var65] & 255;
                        }

                        MiamiNights.g.ae = MiamiNights.h.m_a(MiamiNights.h.aw, 1200);
                        MiamiNights.g.ad = "";

                        for (int var66 = 0; var66 < 200 && MiamiNights.h.aw[1204 + var66] != 0; var66++)
                        {
                            MiamiNights.g.ad = MiamiNights.g.ad + ((char)(MiamiNights.h.aw[1204 + var66] & 255)).ToString();
                        }

                        MiamiNights.g.aa = MiamiNights.h.aw[1404];

                        for (int var67 = 0; var67 < 252; var67++)
                        {
                            MiamiNights.h.e[var67] = MiamiNights.h.aw[1405 + var67];
                        }

                        for (int var68 = 0; var68 < 64; var68++)
                        {
                            MiamiNights.h.f[var68] = MiamiNights.h.aw[1657 + var68];
                        }

                        for (int var69 = 0; var69 < 16; var69++)
                        {
                            MiamiNights.h.bM[var69] = MiamiNights.h.aw[1721 + var69];
                        }

                        int var70 = 0;

                        while (var70 < 10 && MiamiNights.h.aw[1737 + var70] != -127)
                        {
                            var70++;
                        }

                        MiamiNights.h.af = GloftMMN.Iso1(MiamiNights.h.aw, 1737, var70);

                        for (int var71 = 1; var71 < MiamiNights.h.s.Length; var71++)
                        {
                            MiamiNights.h.s[var71] = null;
                        }

                        for (int var72 = 1; var72 < MiamiNights.h.n.Length; var72++)
                        {
                            MiamiNights.h.n[var72] = null;
                        }

                        for (int var73 = 0; var73 < 25; var73++)
                        {
                            int var35 = 1747 + var73 * 89;
                            sbyte var128;
                            if ((var128 = MiamiNights.h.aw[var35 + 0]) > 0)
                            {
                                MiamiNights.h.s[var128] = null;
                                GC.Collect();
                                MiamiNights.h.s[var128] = new g(-1, -1, -1, true, true);
                                g var132 = MiamiNights.h.s[var128];
                                int var135 = 0;

                                for (int var84 = 0; var84 < 6; var84++)
                                {
                                    if (MiamiNights.h.aw[var35 + 1 + var84] != -1)
                                    {
                                        var135++;
                                    }
                                }

                                if (var135 > 0)
                                {
                                    var132.k = new sbyte[var135];

                                    for (int var85 = 0; var85 < var135; var85++)
                                    {
                                        var132.k[var85] = MiamiNights.h.aw[var35 + 1 + var85];
                                    }
                                }

                                var135 = 0;

                                for (int var86 = 0; var86 < 6; var86++)
                                {
                                    if (MiamiNights.h.aw[var35 + 7 + var86] != -1)
                                    {
                                        var135++;
                                    }
                                }

                                if (var135 > 0)
                                {
                                    var132.l = new sbyte[var135];

                                    for (int var87 = 0; var87 < var135; var87++)
                                    {
                                        var132.l[var87] = MiamiNights.h.aw[var35 + 7 + var87];
                                    }
                                }

                                var135 = 0;

                                for (int var88 = 0; var88 < 6; var88++)
                                {
                                    if (MiamiNights.h.aw[var35 + 13 + var88] != -1)
                                    {
                                        var135++;
                                    }
                                }

                                if (var135 > 0)
                                {
                                    var132.m = new sbyte[var135];

                                    for (int var89 = 0; var89 < var135; var89++)
                                    {
                                        var132.m[var89] = MiamiNights.h.aw[var35 + 13 + var89];
                                    }
                                }

                                for (int var90 = 0; var90 < 46; var90++)
                                {
                                    var132.a[var90] = MiamiNights.h.aw[var35 + 19 + var90];
                                }

                                var132.a[1] = var132.a[1] + 402;

                                for (int var91 = 0; var91 < 21; var91++)
                                {
                                    var132.b[var91] = MiamiNights.h.aw[var35 + 65 + var91];
                                }

                                var132.b[18] = -1;
                                var132.b[3] = 0;
                                var132.e = new sbyte[3];

                                for (int var92 = 0; var92 < 3; var92++)
                                {
                                    var132.e[var92] = MiamiNights.h.aw[var35 + 86 + var92];
                                }

                                for (int var93 = 0; var93 < MiamiNights.h.n.Length; var93++)
                                {
                                    if (MiamiNights.h.n[var93] == null)
                                    {
                                        int var144;
                                        int var151 = ((var144 = 7 + var132.a[0] * 2) - 7) / 2;
                                        var132.b[5] = (sbyte)var93;
                                        MiamiNights.h.n[var93] = new d(MiamiNights.h.o[var151], 0, 0, null);
                                        if (var93 == 0)
                                        {
                                            MiamiNights.h.t[0] = new d(MiamiNights.h.o[var151], 0, 0, null);
                                        }
                                        break;
                                    }
                                }
                            }

                            MiamiNights.g.af = aT;
                        }

                        MiamiNights.h.N[0] = -1;
                        MiamiNights.h.N[1] = -1;
                        MiamiNights.h.N[2] = 1;
                        MiamiNights.h.N[3] = 0;
                        MiamiNights.h.N[4] = 0;
                        MiamiNights.h.N[5] = 0;
                        MiamiNights.h.N[6] = 0;
                    }

                    J = bb[13] == 1;
                    int var133 = J ? 1 : 0;
                    sbyte var138;
                    if (m_j())
                    {
                        var138 = 3;
                    }
                    else if (bb[15] == 1)
                    {
                        var138 = 3;
                    }
                    else
                    {
                        var138 = 1;
                    }

                    m_j(var133, var138);

                    for (int var102 = 0; var102 < s; var102++)
                    {
                        for (int var99 = 0; var99 < r; var99++)
                        {
                            int var145 = 2 + var99 + var102 * r;
                            int var152 = 0;
                            int var161 = 0;
                            int var169 = 0;
                            if (var99 < r - 1)
                            {
                                var161 = p[var145 + 1] & 15;
                            }

                            if (var99 > 0)
                            {
                                var152 = p[var145 - 1] & 15;
                            }

                            if (var102 < s - 1)
                            {
                                var169 = p[var145 + r] & 15;
                            }

                            int var173 = p[var145] & 15;
                            int var175 = -1;
                            if (var173 != 0)
                            {
                                int var179;
                                if ((var179 = h[B + (var173 - 1) * 3 + 2] & 255) == 1)
                                {
                                    if (var169 == 0)
                                    {
                                        var175 = 5;
                                    }
                                    else
                                    {
                                        var175 = 6;
                                    }

                                    int var129;
                                    if (var99 > 0 && (var129 = p[var145 - 1] & 15) > 0 && (h[B + (var129 - 1) * 3 + 2] & 255) == 2)
                                    {
                                        var175 = -1;
                                    }
                                }
                                else if (var179 == 2)
                                {
                                    if (var161 == 0)
                                    {
                                        var175 = 7;
                                    }
                                    else
                                    {
                                        var175 = 8;
                                    }

                                    int var130;
                                    if (var99 < r - 1 && (var130 = p[var145 + 1] & 15) > 0 && (h[B + (var130 - 1) * 3 + 2] & 255) == 1)
                                    {
                                        var175 = -1;
                                    }
                                }
                                else if (var173 < 14)
                                {
                                    int var182;
                                    if ((var182 = m_k(var99, var102)) == 2)
                                    {
                                        var175 = 0;
                                    }
                                    else if (var182 == 3)
                                    {
                                        if (var161 == 0 && var152 != 0)
                                        {
                                            var175 = 2;
                                        }
                                        else
                                        {
                                            var175 = 1;
                                        }
                                    }
                                }
                                else if (var173 == 14)
                                {
                                    var175 = 4;
                                }
                                else if (var173 == 15)
                                {
                                    var175 = 3;
                                }
                            }

                            p[var145] = (sbyte)(var173 | ++var175 << 4);
                        }
                    }
                    break;
                case 9:
                    if (ah)
                    {
                        bc[2] = MiamiNights.h.aw[72];
                    }

                    c = new d[f_];
                    sbyte[] var12 = new sbyte[90];

                    for (int var54 = 0; var54 < f_; var54++)
                    {
                        short var13;
                        if ((var13 = e[var54][0]) < 90)
                        {
                            int var123;
                            if ((var123 = e[var54][9] - 2) >= 0 && !MiamiNights.g.m_a(var123, null, false))
                            {
                                e[var54][5] = -127;
                            }
                            else
                            {
                                var12[var13] = 1;
                            }

                            if (var13 == 55)
                            {
                                var12[var13] = 0;
                                e[var54][5] = -127;
                            }
                        }
                    }

                    int var119 = -1;

                    for (int var121 = 0; var121 < 4; var121++)
                    {
                        if (var121 == 0)
                        {
                            GloftMMN.m_b("/14");
                        }
                        else if (var121 == 1)
                        {
                            GloftMMN.m_b("/15");
                        }
                        else if (var121 == 2)
                        {
                            GloftMMN.m_b("/16");
                        }
                        else
                        {
                            GloftMMN.m_b("/17");
                        }

                        if (var121 == 0)
                        {
                            var119 = GloftMMN.h;
                        }

                        for (int var55 = 0; var55 < GloftMMN.h; var55++)
                        {
                            int var124;
                            if ((var124 = var55 + var121 * var119) < 90 && var12[var124] == 1)
                            {
                                MiamiNights.h.m_a(var55, b, 3 + var124, false, false, -1, false);
                                a var126 = b[3 + var124];

                                for (int var83 = 0; var83 < var126.k.Length; var83++)
                                {
                                    if (var126.k[var83] != null)
                                    {
                                        var126.k[var83][0] = 0;
                                    }
                                }
                            }
                        }

                        GloftMMN.m_f();
                    }
                    break;
                case 10:
                    for (int var52 = 0; var52 < f_; var52++)
                    {
                        short var142;
                        if ((var142 = e[var52][0]) < 90 && e[var52][5] != -127)
                        {
                            short var159 = e[var52][1];
                            short var167 = e[var52][2];
                            a var172 = b[3 + var142];
                            c[var52] = new d(var172, var159, var167, null);
                            d var174 = c[var52];
                            int var178 = e[var52][3];
                            int var181 = e[var52][4];
                            int var29;
                            short var183;
                            if ((var183 = e[var52][10]) > 0)
                            {
                                for (int var81 = 0; var81 < 64 && (var29 = var81 * 17) < MiamiNights.h.g.Length; var81++)
                                {
                                    short var30 = MiamiNights.h.g[var29 + 0];
                                    short var31;
                                    if (MiamiNights.h.H == var30 && (var31 = MiamiNights.h.g[var29 + 2]) == var183)
                                    {
                                        int var32;
                                        int var33 = ((var32 = MiamiNights.h.f[var31 - 1] & 255) & 15) >> 0;
                                        int var34 = (var32 & 240) >> 4;
                                        var178 = m_h(var142, var33);
                                        var181 = var34;
                                        break;
                                    }
                                }
                            }

                            e[var52][3] = (short)var178;
                            var174.m_a(var178);
                            if (e[var52][8] == 1)
                            {
                                var174.c = 1;
                            }

                            var29 = var174.d_.h[var174.e] & 255;
                            var174.g = 0;
                            var174.f = var159 % var29;
                            int var185 = var181;
                            if (bb[15] == 0 && m_j())
                            {
                                var185 = var181 + var172.l / 3;
                            }
                            else if (bb[15] == 0 && m_k())
                            {
                                var185 = var181 + var172.l / 3 * 2;
                            }

                            if (var185 < 0)
                            {
                                var185 = 0;
                                e[var52][4] = 0;
                                int var186 = GloftMMN.m_c(0, var174.d_.h.Length);
                                e[var52][3] = (short)var186;
                                var174.m_a(var186);
                            }
                            else
                            {
                                e[var52][4] = (short)var185;
                            }

                            if (var172.w == null || var172.w[var185] == null)
                            {
                                var172.m_a(var185, 0, -1, -1, var185);
                            }
                        }
                    }

                    for (int var53 = 3; var53 < b.Length; var53++)
                    {
                        if (b[var53] != null)
                        {
                            bool var143 = true;

                            int var150;
                            for (int var82 = 0; var82 < 64 && (var150 = var82 * 17) < MiamiNights.h.g.Length; var82++)
                            {
                                short var160 = MiamiNights.h.g[var150 + 0];
                                short var168;
                                if (var1 == var160 && (var168 = MiamiNights.h.g[var150 + 1]) == var53 - 3)
                                {
                                    var143 = false;
                                    break;
                                }
                            }

                            if (!var8 || var143)
                            {
                                b[var53].m_b();
                            }
                        }
                    }

                    m_c();
                    break;
                case 11:
                    sbyte[] var14 = j[y];
                    object var15 = null;
                    k = new short[t * u];
                    l = new sbyte[512];

                    for (int var48 = 0; var48 < u; var48++)
                    {
                        for (int var79 = 0; var79 < t; var79++)
                        {
                            short var16 = 0;
                            int var17 = var14[2 + var79 + var48 * t] & 15;
                            int var19 = 0;   // CFR: int (VF byte mis-inference)
                            int var18 = 0;

                            while (
                               var18 < MiamiNights.h.ar.Length / 3
                                  && (MiamiNights.h.ar[var18 * 3 + 0] != var1 || MiamiNights.h.ar[var18 * 3 + 1] + 1 != var17 || (var19 = MiamiNights.h.ar[var18 * 3 + 2]) != 1 && var19 != 5 && var19 != 4)
                            )
                            {
                                var18++;
                            }

                            if (var18 != MiamiNights.h.ar.Length / 3)
                            {
                                if (var19 == 1)
                                {
                                    var16 = 3;
                                }
                                else if (var19 == 5)
                                {
                                    var16 = 16384;
                                }
                                else
                                {
                                    var16 = -32768;
                                }
                            }
                            else if (var17 == 0 || (h[B + (var17 - 1) * 3 + 2] & 255) != 0)
                            {
                                var16 = 1;
                            }

                            k[var79 + var48 * t] = var16;
                        }
                    }

                    CurLevel = var1;
                    SvgMap.Apply(var1, k, t, u);   // SVG = editable source of truth for the walk grid
                    int var125 = 0;

                    for (int var49 = 0; var49 < l.Length; var49++)
                    {
                        l[var49] = -1;
                    }

                    for (int var50 = 0; var50 < f_; var50++)
                    {
                        short var127;
                        bool var131;
                        if ((var131 = (var127 = e[var50][0]) >= 90) || e[var50][5] != -127)
                        {
                            int var134 = -1;
                            int var141 = -1;
                            if (!var131)
                            {
                                short var148 = e[var50][3];
                                var134 = m_b(var127, 1, var148);
                                var141 = m_b(var127, 2, var148);
                            }

                            if (var134 > 4 || var131)
                            {
                                var134 = 1;
                                var141 = 1;
                            }

                            bool var149 = !var131 && e[var50][8] == 1;
                            int[] var158 = new int[]{0, 0};
                            short var5;
                            short var6;
                            if (var131)
                            {
                                var5 = -1;
                                var6 = -1;
                            }
                            else
                            {
                                var5 = e[var50][5];
                                var6 = e[var50][6];
                            }

                            if (!var131 && var5 != -1 && var6 != -1)
                            {
                                var158[0] = e[var50][6] + 1;
                                var158[1] = e[var50][5] + 1;
                                if (!var131)
                                {
                                    e[var50][9] = -1;
                                }
                            }
                            else
                            {
                                if (!var131)
                                {
                                    e[var50][9] = -2;
                                }

                                var5 = e[var50][1];
                                var6 = e[var50][2];
                                if (var131)
                                {
                                    var5 += 22;
                                    var6 -= 11;
                                }
                                else if (var149)
                                {
                                    var5 -= 11;
                                }
                                else
                                {
                                    var5 += 11;
                                }

                                m_b(var5, var6, var158);
                                var158[0] >>= 8;
                                var158[1] >>= 8;
                            }

                            if (!var131)
                            {
                                e[var50][5] = (short)var158[0];
                                e[var50][6] = (short)var158[1];
                            }

                            if (var158[0] < 0)
                            {
                                var158[0] = 0;
                            }

                            if (var158[1] < 0)
                            {
                                var158[1] = 0;
                            }

                            if (var149)
                            {
                                int var165 = var134;
                                var134 = var141;
                                var141 = var165;
                            }

                            for (int var80 = 0; var80 < var141; var80++)
                            {
                                for (int var166 = 0; var166 < var134; var166++)
                                {
                                    var5 = (short)(var158[0] + var80);
                                    var6 = (short)(var158[1] - var166);
                                    if (var5 >= 0 && var5 < t && var6 >= 0 && var6 < u)
                                    {
                                        int var177;
                                        short var180;
                                        if (((var180 = k[var5 + var6 * t]) & 3) == 2)
                                        {
                                            var177 = (var180 & 508) >> 2;
                                            int var170 = 0;

                                            while (var170 < 4)
                                            {
                                                var170++;
                                            }
                                        }
                                        else
                                        {
                                            var177 = var125++;
                                        }

                                        for (int var171 = 0; var171 < 4; var171++)
                                        {
                                            if (l[var177 * 4 + var171] == -1)
                                            {
                                                l[var177 * 4 + var171] = (sbyte)(var50 & 0xFF);
                                                break;
                                            }
                                        }

                                        short var28;
                                        if ((var28 = k[var5 + var6 * t]) != 1 && var28 != 16384 && var28 != -32768)
                                        {
                                            k[var5 + var6 * t] = (short)(2 | var177 << 2);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    for (int var51 = 0; var51 < k.Length; var51++)
                    {
                        if (k[var51] == 3)
                        {
                            k[var51] = 1;
                        }
                    }

                    MiamiNights.h.m_c();
                    break;
                case 12:
                    if (!var8)
                    {
                        if (!ah && MiamiNights.h.X == 2)
                        {
                            int[] var140 = new int[]{37, 44, 45, 49, 50, 51};
                            int var2 = 0;   // CFR: int (VF byte mis-inference)
                            if (var7.a[0] == 0)
                            {
                                var2 = 3;
                            }

                            for (int var45 = 0; var45 < 3; var45++)
                            {
                                MiamiNights.h.s[1 + var45] = new g(-1, 1 + var45, var140[var45 + var2], false, false);
                                MiamiNights.h.s[1 + var45].b[6] = (sbyte)(1 + var45);
                                MiamiNights.h.s[1 + var45].m_a();
                            }
                        }

                        MiamiNights.g.m_a(false);
                        if (ah || MiamiNights.h.X == 2)
                        {
                            for (int var46 = 0; var46 < 3; var46++)
                            {
                                m_a(MiamiNights.h.s[1 + var46], var46);
                            }

                            for (int var47 = 0; var47 < 3; var47++)
                            {
                                m_b(1 + var47);
                            }

                            if (ah)
                            {
                                m_a(MiamiNights.h.s[4], 3);
                                m_b(4);
                            }

                            MiamiNights.g.m_a(true);
                            MiamiNights.g.m_a(false);
                        }

                        m_s();
                        if (MiamiNights.g.v > 6)
                        {
                            MiamiNights.g.v = 0;
                        }
                    }
                    break;
                case 13:
                    GloftMMN.m_b("/11");
                    MiamiNights.h.m_a(0, b, 0, false, false, 256, false);
                    if (bb[15] == 0)
                    {
                        if (m_j())
                        {
                            m_a(2, b[0]);
                        }
                        else if (m_k())
                        {
                            m_a(3, b[0]);
                        }
                        else
                        {
                            m_a(1, b[0]);
                        }
                    }
                    else
                    {
                        m_a(1, b[0]);
                    }

                    GloftMMN.m_f();
                    bf = new sbyte[16];
                    int var139 = r * s;

                    for (int var44 = 0; var44 < var139; var44++)
                    {
                        int var146;
                        if ((var146 = p[2 + var44] & 15) > 0)
                        {
                            bf[--var146] = 1;
                        }
                    }
                    break;
                case 14:
                    bool var21 = false;
                    bh = -1;
                    if (var1 == 0 || var1 == 1 || var1 == 22 || var1 == 34)
                    {
                        var21 = true;
                        if (var1 == 0)
                        {
                            bh = 0;
                        }

                        if (var1 == 1)
                        {
                            bh = 1;
                        }

                        if (var1 == 22)
                        {
                            bh = 2;
                        }

                        if (var1 == 34)
                        {
                            bh = 3;
                        }
                    }

                    for (int var43 = 0; var43 < 15; var43++)
                    {
                        if (bf[var43] != 0)
                        {
                            int var157 = h[B + var43 * 3 + 1] & 255;
                            int var164 = h[B + var43 * 3 + 0] & 255;
                            if (var21)
                            {
                                if (var43 == 0)
                                {
                                    var164 = MiamiNights.h.bM[bh * 4 + 2] & 255;
                                    var157 = MiamiNights.h.bM[bh * 4 + 3] & 255;
                                }

                                if (var43 == 1)
                                {
                                    var164 = MiamiNights.h.bM[bh * 4 + 0] & 255;
                                    var157 = MiamiNights.h.bM[bh * 4 + 1] & 255;
                                }
                                else if (var43 == 2)
                                {
                                    var164 = (MiamiNights.h.bM[bh * 4 + 0] & 255) + 1;
                                    var157 = MiamiNights.h.bM[bh * 4 + 1] & 255;
                                }

                                h[B + var43 * 3 + 0] = (sbyte)var164;
                                h[B + var43 * 3 + 1] = (sbyte)var157;
                            }

                            if (var157 == 255)
                            {
                                var157 = 0;
                            }

                            if (var164 != 255)
                            {
                                b[0].m_a(var157, var164, var164, -1, var157);
                            }
                        }
                    }

                    bf = null;
                    if (MiamiNights.h.y != 52)
                    {
                        b[0].m_b();
                        b[0].m_c();
                    }
                    break;
                case 15:
                    GloftMMN.m_b("/12");
                    MiamiNights.h.m_a(0, b, 1, false, false, 64, false);
                    if (bb[15] != 0 && bb[15] != 2)
                    {
                        m_a(1, b[1]);
                    }
                    else if (m_j())
                    {
                        m_a(2, b[1]);
                    }
                    else if (m_k())
                    {
                        m_a(3, b[1]);
                    }
                    else
                    {
                        m_a(1, b[1]);
                    }

                    GloftMMN.m_f();
                    bf = new sbyte[16];
                    int var20 = r * s;

                    for (int var42 = 0; var42 < var20; var42++)
                    {
                        int var155;
                        if ((var155 = q[2 + var42] & 15) > 0)
                        {
                            bf[--var155] = 1;
                        }
                    }
                    break;
                case 16:
                    for (int var41 = 0; var41 < 15; var41++)
                    {
                        if (bf[var41] != 0)
                        {
                            int var154 = h[B + 45 + var41 * 3 + 1] & 255;
                            int var163 = h[B + 45 + var41 * 3 + 0] & 255;
                            if (var154 == 255)
                            {
                                var154 = 0;
                            }

                            if (var163 != 255)
                            {
                                b[1].m_a(var154, var163, var163, -1, var154);
                            }
                        }
                    }

                    b[1].m_b();
                    b[1].m_c();
                    break;
                case 17:
                    MiamiNights.a.v = null;
                    GloftMMN.m_a("STARTING TO REALLOCATE");
                    sbyte var40;
                    if ((var40 = MiamiNights.g.am[MiamiNights.h.H]) >= 0)
                    {
                        GloftMMN.m_b("/19");
                        GloftMMN.m_a((int)var40);
                        GloftMMN.m_f();
                        GC.Collect();
                        a = var40 + 1;
                    }
                    else
                    {
                        a = -1;
                    }

                    GloftMMN.m_a("LEVEL MUSIC LOADED");
                    break;
                case 18:
                    GloftMMN.m_a("/3", 0);
                    GloftMMN.m_a("TXTS LOADED");
                    break;
                case 19:
                    if (!var8)
                    {
                        m_b(true);
                    }

                    GloftMMN.m_a("IFACE LOADED");
                    break;
                case 20:
                    m_a();
                    GloftMMN.m_a("FONT LOADED");
                    break;
                case 21:
                    if (m == null)
                    {
                        m = Image.CreateImage(n, o);
                        aj = m.GetGraphics();
                    }

                    GloftMMN.m_a("BB LOADED");
                    break;
                case 22:
                    GloftMMN.m_a("BEFORE MISC ARRAYS " + GloftMMN.g);
                    Y = new sbyte[15];
                    Z = new sbyte[15];
                    aa = new sbyte[15];
                    ab = new sbyte[15];
                    ac = new sbyte[15];
                    ad = new sbyte[15];

                    for (int var3 = 0; var3 < 15; var3++)
                    {
                        Y[var3] = (sbyte)(h[B + var3 * 3 + 0] & 255);
                        Z[var3] = (sbyte)(h[B + var3 * 3 + 1] & 255);
                        aa[var3] = (sbyte)(h[B + 45 + var3 * 3 + 0] & 255);
                        ab[var3] = (sbyte)(h[B + 45 + var3 * 3 + 1] & 255);
                        ac[var3] = (sbyte)(h[B + 45 + var3 * 3 + 2] * 136 / 100);
                        ad[var3] = (sbyte)(h[B + var3 * 3 + 2] & 255);
                    }

                    ae = new sbyte[f_];
                    af = new sbyte[f_];
                    ag = new int[f_][];

                    for (int var37 = 0; var37 < f_; var37++)
                    {
                        short[] var10 = e[var37];
                        d var22 = c[var37];
                        if (var10[0] < 90 && var10[5] != -127)
                        {
                            ae[var37] = (sbyte)m_b(var10[0], 1, var10[3]);
                            af[var37] = (sbyte)m_b(var10[0], 2, var10[3]);
                            var22.a = var10[1] << 8;
                            var22.b = var10[2] << 8;
                            int[] var23 = var22.m_c();
                            ag[var37] = new int[4];
                            ag[var37][0] = var23[0] >> 8;
                            ag[var37][1] = var23[1] >> 8;
                            ag[var37][2] = var23[2] >> 8;
                            ag[var37][3] = var23[3] >> 8;
                        }
                    }

                    MiamiNights.g.L = -1;
                    aR = -1;
                    au = -1;
                    d = true;
                    av = -1;
                    au = -1;
                    bg = (sbyte)MiamiNights.h.H;
                    C = -1000;
                    D = -1000;
                    if (!var8)
                    {
                        MiamiNights.h.y = 19;
                    }

                    MiamiNights.h.z = -1;
                    MiamiNights.h.i = -1;
                    MiamiNights.h.L = 0;
                    MiamiNights.h.K = 0;
                    var0.SetClip(0, 0, 240, 400);
                    var0.SetColor(0);
                    var0.FillRect(0, 0, 240, 400);
                    if (ai >= 0)
                    {
                        MiamiNights.g.m_a(ai);
                        ai = -1;
                    }

                    if (MiamiNights.h.X == 1)
                    {
                        MiamiNights.h.N[0] = 20;
                        MiamiNights.h.N[1] = 0;
                        MiamiNights.h.N[2] = 0;
                        MiamiNights.h.N[3] = 1;
                        MiamiNights.h.N[5] = 35;
                        d = true;
                        MiamiNights.h.y = 0;
                    }
                    else if (MiamiNights.h.X == 2)
                    {
                        MiamiNights.h.s[0].a[22] = 0;
                        bc[30] = 0;
                        MiamiNights.h.N[0] = 5;
                        MiamiNights.h.N[1] = 0;
                        MiamiNights.h.N[2] = 0;
                        MiamiNights.h.N[3] = 1;
                        MiamiNights.h.s[4].m_a();
                        m_a(MiamiNights.h.s[4], 3);

                        for (int var38 = 0; var38 < MiamiNights.h.e.Length; var38++)
                        {
                            MiamiNights.h.e[var38] = -1;
                        }

                        MiamiNights.g.m_a(MiamiNights.h.s[0].a[6], -1, (sbyte)MiamiNights.h.s[0].a[7]);
                        MiamiNights.g.m_a(-1, MiamiNights.h.s[0].a[8], (sbyte)MiamiNights.h.s[0].a[9]);
                    }

                    if (!ah && (MiamiNights.g.ae & 0xFF) == 0)
                    {
                        MiamiNights.g.ae &= -257;
                    }

                    ah = false;
                    if (MiamiNights.h.X != 1)
                    {
                        MiamiNights.h.X = 0;
                    }

                    MiamiNights.g.m_c(MiamiNights.h.H);
                    GloftMMN.m_f();
                    MiamiNights.g.au = false;
                    if (MiamiNights.h.n[0] != null)
                    {
                        MiamiNights.h.n[0].m_a(0);
                    }

                    MiamiNights.h.O = false;
                    int var153 = bi;
                    int var162 = bj;
                    bi = 0;
                    bj = 0;

                    for (int var39 = 0; var39 < 64; var39++)
                    {
                        if (MiamiNights.h.f[var39] != -1)
                        {
                            int var24 = -1;

                            for (int var4 = 0; var4 < MiamiNights.h.g.Length; var4 += 17)
                            {
                                if (MiamiNights.h.g[var4 + 2] - 1 == var39)
                                {
                                    var24 = var4 / 17;
                                    break;
                                }
                            }

                            short var25 = MiamiNights.h.g[var24 * 17 + 0];
                            int var26 = (MiamiNights.h.f[var39] & 15) >> 0;
                            short var27 = MiamiNights.h.g[var24 * 17 + 3 + var26];
                            if (var25 != 22 && var25 != 34)
                            {
                                bi += var27;
                            }
                            else
                            {
                                bj += var27;
                            }
                        }
                    }

                    if (var153 != 0 && (var153 != bi || var162 != bj))
                    {
                        MiamiNights.g.m_i();
                    }

                    if (a != -1 && GloftMMN.f)
                    {
                        GloftMMN.m_a("BEFORE MUSIC PLAY");
                        GloftMMN.m_c(5);
                    }

                    return true;
            }

        label1358: ;   // Java: `label1358:` on the switch; break label1358 lands here
            if (!MiamiNights.h.Z)
            {
                if (ah)
                {
                    var0.SetClip(0, 0, 231 * (bd + 8) / 29, 400);
                }
                else
                {
                    var0.SetClip(0, 0, 231 * bd / 21, 400);
                }

                var0.SetColor(16711680);
                var0.FillRect(7, 316, 240, 3);
            }
            else
            {
                var0.SetColor(0);
                var0.FillRect(0, 0, 240, 400);
            }

            bd++;
            return false;
        }
        // original private static void a(g, int)
        private static void m_a(g var0, int var1)
        {
            var0.m_a(7 + var0.a[0] * 2, var0.b[6], true);
            d var2;
            (var2 = MiamiNights.h.n[var0.b[5]]).m_a(66);
            var2.d_.m = var0.b[15];
            int[] var3;
            int var4 = (var3 = var2.m_c())[2] - var3[0] >> 8;
            int var5 = var3[3] - var3[1] >> 8;
            MiamiNights.g.U[var1] = Image.CreateImage(var4, var5);
            Graphics var6;
            (var6 = MiamiNights.g.U[var1].GetGraphics()).SetColor(16777215);
            var6.FillRect(0, 0, var4, var5);
            var2.a = var4 / 2 << 8;
            var2.b = var5 / 2 << 8;
            var2.m_a(var6);
        }

        // original static void c()
        internal static void m_c()
        {
            for (int var0 = 0; var0 < c.Length; var0++)
            {
                short var1;
                if (c[var0] != null && e[var0][0] == 44 && ((var1 = e[var0][3]) == 0 || var1 == 1))
                {
                    if (bb[0] == 0)
                    {
                        c[var0].m_a(0);
                    }
                    else
                    {
                        c[var0].m_a(1);
                    }

                    e[var0][3] = (short)c[var0].e;
                }
            }
        }

        // original static int a(int) — 1555 color expand
        internal static int m_a(int var0)
        {
            int var1 = var0 >> 10 & 31;
            int var2 = var0 >> 5 & 31;
            int var3 = var0 >> 0 & 31;
            int var4 = (var0 >> 15 & 1) * 255;
            var1 = var1 * 255 / 31;
            var2 = var2 * 255 / 31;
            var3 = var3 * 255 / 31;
            return var4 << 24 | var1 << 16 | var2 << 8 | var3;
        }

        // original private static int a(d)
        private static int m_a(d var0)
        {
            int var1 = (var0.d_.i[var0.e] + var0.f) * 5;
            return var0.d_.j[var1] & 0xFF;
        }

        // original static int a(int,int) — object index lookup
        internal static int m_a(int var0, int var1)
        {
            for (int var2 = 0; var2 < f_; var2++)
            {
                if (e[var2][0] == var0)
                {
                    if (var1 == -1)
                    {
                        return var2;
                    }

                    if (e[var2][3] == var1)
                    {
                        return var2;
                    }
                }
            }

            return -1;
        }

        // original static void a(int,int[]) — screen cell coord
        internal static void m_a(int var0, int[] var1)
        {
            int var2 = e[var0][1] + 22;
            int var3 = e[var0][2] - 11;
            m_b(var2, var3, var1);
            var1[0] &= -256;
            var1[1] &= -256;
            var1[0] += 127;
            var1[1] += 127;
        }

        // original private static void j(int,int) — palette for object sprite b[2]
        private static void m_j(int var0, int var1)
        {
            ak[0] = var1;
            ak[1] = var0;
            sbyte var2 = bb[14];
            int var3 = 0 + (var0 == 0 ? 10 : 2);
            if (var2 == 1)
            {
                var3 += 0;
            }
            else if (var2 == 2)
            {
                var3 += 2;
            }
            else if (var2 == 3)
            {
                var3 += 4;
            }
            else if (var2 == 4)
            {
                var3 += 6;
            }
            else if (m_l())
            {
                var3 += 0;
            }
            else if (m_j())
            {
                var3 += 6;
            }
            else if (m_k())
            {
                var3 += 4;
            }
            else
            {
                var3 += 2;
            }

            for (int var4 = 0; var4 < b[2].k.Length; var4++)
            {
                if (b[2].k[var4] != null)
                {
                    b[2].k[var4][1] = ak[var3];
                }
            }

            b[2].m_a(0, 0, -1, -1, 0);
            int var6 = 1 + (ak[1] == 0 ? 10 : 2);
            if (var2 == 1)
            {
                var6 += 0;
            }
            else if (var2 == 2)
            {
                var6 += 2;
            }
            else if (var2 == 3)
            {
                var6 += 4;
            }
            else if (var2 == 4)
            {
                var6 += 6;
            }
            else if (m_l())
            {
                var6 += 0;
            }
            else if (m_j())
            {
                var6 += 6;
            }
            else if (m_k())
            {
                var6 += 4;
            }
            else
            {
                var6 += 2;
            }

            bl = ak[var6];
        }

        // original static void a(int,int,int[])
        internal static void m_a(int var0, int var1, int[] var2)
        {
            m_c(var0, var1, var2);
            var2[0] -= C;
            var2[1] -= D;
        }

        // original private static void c(int,int,int[]) — iso projection
        private static void m_c(int var0, int var1, int[] var2)
        {
            int var3 = s * 44 / 2;
            int var5 = (var0 * w[0] + var1 * x[0] >> 8) * 44;
            int var6 = (var0 * w[1] + var1 * x[1] >> 8) * 22;
            var5 >>= 8;
            var6 >>= 8;
            var5 += var3;
            var6 += 54;
            var2[0] = var5;
            var2[1] = var6;
        }

        // original static void b(int,int,int[]) — fixed point iso
        internal static void m_b(int var0, int var1, int[] var2)
        {
            int var3 = s * 44 / 2 << 8;
            int var5 = var0 << 8;
            int var6 = var1 << 8;
            var2[0] = (var5 - var3) / 44 + (var6 - 13824) / 22;
            var2[1] = (var6 - 13824) / 22 - (var5 - var3) / 44;
        }

        // original private static int c(int,int,int) — layer tile read
        private static int m_c(int var0, int var1, int var2)
        {
            return var0 == 0 ? p[2 + var1 + var2 * r] & 0xFF & 15 : q[2 + var1 + var2 * r] & 0xFF;
        }

        // original private static int k(int,int) — neighbour tile count
        private static int m_k(int var0, int var1)
        {
            int var2 = 0;
            int[][] var3 = new int[][]{ new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, -1}, new int[]{0, 1} };

            for (int var4 = 0; var4 < 4; var4++)
            {
                int var5 = var0 + var3[var4][0];
                int var6 = var1 + var3[var4][1];
                if (var5 >= 0 && var5 < r && var6 >= 0 && var6 < s && m_c(0, var5, var6) != 0)
                {
                    var2++;
                }
            }

            return var2;
        }

        // original static boolean a(int,int,int) — walkable box check
        internal static bool m_a(int var0, int var1, int var2)
        {
            int var3 = m_b(var0 - var2 / 2, var1 - var2 / 2);
            int var4 = m_b(var0 + var2 / 2, var1 - var2 / 2);
            int var5 = m_b(var0 + var2 / 2, var1 + var2 / 2);
            int var6 = m_b(var0 - var2 / 2, var1 + var2 / 2);
            return var3 == 1
               || m_a(var3, var0, var1, 0, true)
               || var4 == 1
               || m_a(var4, var0, var1, 0, true)
               || var5 == 1
               || m_a(var5, var0, var1, 0, true)
               || var6 == 1
               || m_a(var6, var0, var1, 0, true);
        }

        // original static int b(int,int) — walk map sample (8.8)
        internal static int m_b(int var0, int var1)
        {
            if (var0 >= 0 && var0 < t << 8 && var1 >= 0 && var1 < u << 8)
            {
                var0 >>= 8;
                var1 >>= 8;
                return k[var0 + var1 * t];
            }
            else
            {
                return 1;
            }
        }

        // original static boolean a(int,int,int,int,boolean) — tile blocked?
        internal static bool m_a(int var0, int var1, int var2, int var3, bool var4)
        {
            if ((var0 & 15872) != 0)
            {
                if (var1 == -1 || var2 == -1)
                {
                    return true;
                }

                int var5 = (var0 & 15872) >> 9;
                if (var3 != var5)
                {
                    if (!var4)
                    {
                        return true;
                    }

                    g var6;
                    var1 = (var6 = MiamiNights.h.s[var5]).c[0] - var1;
                    var2 = var6.c[1] - var2;
                    if (GloftMMN.m_a((long)(var1 * var1 + var2 * var2)) <= 128)
                    {
                        return true;
                    }
                }
            }

            if ((var0 & 3) == 2)
            {
                int var11 = (var0 & 508) >> 2;

                for (int var12 = 0; var12 < 4; var12++)
                {
                    int var7;
                    if ((var7 = l[var11 * 4 + var12]) != -1)
                    {
                        var7 &= 255;   // object index stored as byte: read unsigned (ids >= 128 were negative)
                        if (var7 < e.Length && e[var7] != null && e[var7][0] < 90 && m_b(e[var7][0], 1, e[var7][3]) < 5)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        // original private static void a(Graphics,Image,int,int,int) — clipped blit
        private static void m_a(Graphics var0, Image var1, int var2, int var3, int var4)
        {
            if (m_b(var2, var3, var1.GetWidth(), var1.GetHeight(), S, T, S + U, T + V))
            {
                var0.DrawImage(var1, var2, var3, var4);
            }
        }

        // original private static boolean b(int x,int y,int w,int h,int x0,int y0,int x1,int y1)
        private static bool m_b(int var0, int var1, int var2, int var3, int var4, int var5, int var6, int var7)
        {
            if (var0 >= var6)
            {
                return false;
            }
            else if (var0 + var2 < var4)
            {
                return false;
            }
            else
            {
                return var1 >= var7 ? false : var1 + var3 >= var5;
            }
        }

        // original static boolean a(int,int,int,int,int,int,int,int)
        internal static bool m_a(int var0, int var1, int var2, int var3, int var4, int var5, int var6, int var7)
        {
            if (var0 >= var6)
            {
                return false;
            }
            else if (var2 < var4)
            {
                return false;
            }
            else
            {
                return var1 >= var7 ? false : var3 >= var5;
            }
        }

        // original private static void a(Graphics,int,int,int,int,int,int,int) — map layer painter
        private static void m_a(Graphics var0, int var1, int var2, int var3, int var4, int var5, int var6, int var7)
        {
            g.GetClipWidth();
            g.GetClipHeight();
            g.SetClip(var6, var7, var4, var5);
            S = var6;
            T = var7;
            U = var4;
            V = var5;
            if (var1 < 3)
            {
                var5 += 87;
            }

            int var10 = var4;
            int var11 = var5;
            if (var4 < 44)
            {
                var10 = 44;
            }

            if (var5 < 22)
            {
                var11 = 22;
            }

            if (var1 == 0)
            {
                g.SetColor(bl);
                g.FillRect(var6, var7, var4, var5);
            }

            int var21 = 0;
            m_b(var2, var3, M);
            m_b(var2 + var10, var3, N);
            m_b(var2 + var10, var3 + var11, O);
            m_b(var2, var3 + var11, P);
            M[0] = M[0] >> 8;
            M[1] = M[1] >> 8;
            N[0] = N[0] >> 8;
            N[1] = N[1] >> 8;
            O[0] = O[0] >> 8;
            O[1] = O[1] >> 8;
            P[0] = P[0] >> 8;
            P[1] = P[1] >> 8;
            var21 = P[1] - N[1] + 1;
            int var22 = (M[0] - N[0] << 8) / (M[1] - N[1]);
            int var23 = (O[0] - N[0] << 8) / (O[1] - N[1]);
            int var24 = (P[0] - M[0] << 8) / (P[1] - M[1]);
            int var25 = (P[0] - O[0] << 8) / (P[1] - O[1]);

            for (int var26 = 0; var26 < var21; var26++)
            {
                int var9;
                if ((var9 = var26 + N[1]) < O[1])
                {
                    R[var26] = (N[0] << 8) + (var9 - N[1]) * var23;
                }
                else
                {
                    R[var26] = (O[0] << 8) + (var9 - O[1]) * var25;
                }

                if (var9 < M[1])
                {
                    Q[var26] = (N[0] << 8) + (var9 - N[1]) * var22;
                }
                else
                {
                    Q[var26] = (M[0] << 8) + (var9 - M[1]) * var24;
                }
            }

            d var27 = null;
            object var28 = null;
            if (var1 == 2)
            {
                int var69 = var6 - var2;
                int var71 = var7 - var3;

                for (int var61 = 0; var61 < X; var61++)
                {
                    int var67 = W[var61] & 255;
                    int[] var66;
                    if (m_a((var66 = ag[var67])[0] + var69, var66[1] + var71, var66[2] + var69, var66[3] + var71, S, T, S + U, T + V))
                    {
                        var27 = c[var67];
                        var28 = e[var67];
                        var27.a = var69 + ((short[])var28)[1] << 8;
                        var27.b = var71 + ((short[])var28)[2] << 8;
                        var27.d_.m = (int)((short[])var28)[4];
                        var27.m_a(g);
                    }
                }
            }
            else
            {
                sbyte[] var30 = var1 == 0 ? p : q;
                int var32 = s * 44 / 2;
                int var33 = 0;
                var32 += var6 - var2 - 22;
                var33 = 54 + var7 - var3 + 22;
                Image[][] var34 = (Image[][])null;
                if (var1 == 0)
                {
                    var34 = b[0].w;
                }
                else if (var1 == 1)
                {
                    var34 = b[1].w;
                }

                int var39 = -1;
                int var40 = -1;
                if (var1 == 3)
                {
                    g var41 = null;
                    if (MiamiNights.h.s != null)
                    {
                        var39 = (var41 = MiamiNights.h.s[0]).c[0] >> 8;
                        var40 = var41.c[1] >> 8;
                    }
                }

                for (int var60 = 0; var60 < var21; var60++)
                {
                    int var56;
                    if ((var56 = N[1] + var60) >= 0 && var56 < s)
                    {
                        int var12;
                        int var13;
                        if (var1 == 3)
                        {
                            var12 = (Q[var60] >> 8) - 2;
                            var13 = (R[var60] >> 8) + 2;
                        }
                        else
                        {
                            var12 = (Q[var60] >> 8) - 1;
                            var13 = (R[var60] >> 8) + 1;
                        }

                        int var31 = 2 + var56 * r;
                        int var47 = var56 * t;

                        for (int var8 = var12; var8 <= var13; var8++)
                        {
                            if (var8 >= 0 && var8 < r)
                            {
                                if (var1 != 3)
                                {
                                    int var16;
                                    if (var1 <= 2 && (var16 = var30[var31 + var8] & 15) > 0)
                                    {
                                        int var14 = var32 + (var8 - var56) * 44 / 2;
                                        int var15 = var33 + (var8 + var56) * 22 / 2;
                                        int var17;
                                        if (var1 == 0)
                                        {
                                            var17 = var16;
                                        }
                                        else
                                        {
                                            var17 = p[var31 + var8] & 15;
                                        }

                                        if (var17 > 0 && ad[var17 - 1] == 1)
                                        {
                                            var14 += 22;
                                        }

                                        var16--;
                                        if (var1 == 0)
                                        {
                                            sbyte var54;
                                            if ((var54 = (sbyte)((var30[var31 + var8] & 240) >> 4)) >= 1)
                                            {
                                                b[2].m_a(g, --var54, var14 + L[var54][0], var15 + L[var54][1], 0, 0, 0);
                                            }

                                            int var36 = Y[var16] & 255;
                                            Image var35 = var34[Z[var16] & 255][var36];
                                            m_a(g, var35, var14, var15 - var35.GetHeight(), 20);
                                            if ((h[B + var16 * 3 + 2] & 255) == 2
                                               && var8 < r - 1
                                               && (var16 = var30[var31 + var8 + 1] & 15) > 0
                                               && (h[B + (var16 - 1) * 3 + 2] & 255) == 1)
                                            {
                                                m_a(g, var35, var14 + 22, var15 - var35.GetHeight() + 11, 20);
                                            }
                                        }
                                        else
                                        {
                                            int var73;
                                            if (var1 == 1 && (var73 = aa[var16] & 255) != 255)
                                            {
                                                Image var72 = var34[ab[var16] & 255][var73];
                                                m_a(g, var72, var14, var15 - var72.GetHeight() - ac[var16], 20);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    short var75;
                                    if (((var75 = k[var8 + var47]) & 3) == 2)
                                    {
                                        int var43 = (var75 & 508) >> 2 << 2;

                                        int var44;
                                        for (int var45 = 0; var45 < 4 && (var44 = l[var43 + var45]) != -1; var45++)
                                        {
                                            var44 &= 255;
                                            if (((short[])(var28 = e[var44]))[0] < 90)
                                            {
                                                if (((var27 = c[var44]).d_.h[var27.e] & 255) > 1)
                                                {
                                                    var0.SetClip(0, 75, 240, 240);
                                                    var27.a = ((short[])var28)[1] - C + 0 << 8;
                                                    var27.b = ((short[])var28)[2] - D + 75 << 8;
                                                    var27.d_.m = (int)((short[])var28)[4];
                                                    var27.m_a(var0);
                                                    int[] var29;
                                                    (var29 = var27.m_c())[0] >>= 8;
                                                    var29[1] >>= 8;
                                                    var29[2] >>= 8;
                                                    var29[3] >>= 8;
                                                    m_a(var0, var29, var8, var56, null);
                                                    var27.m_b();
                                                }

                                                m_d(var0, var44);
                                            }
                                        }
                                    }

                                    int var42 = (var75 & 15872) >> 9;
                                    bool var46 = var8 == var39 && var56 == var40;
                                    int var49 = 0;
                                    sbyte var50 = 1;
                                    g var53;
                                    int var51 = (var53 = MiamiNights.h.s[0]).c[0] + var53.c[1];
                                    int var52 = 0;
                                    if (var42 > 0)
                                    {
                                        var52 = (var53 = MiamiNights.h.s[var42]).c[0] + var53.c[1];
                                    }

                                    if (var52 > var51)
                                    {
                                        var50 = 0;
                                    }

                                    var0.SetClip(0, 75, 240, 240);

                                    for (; var49 < 2; var49++)
                                    {
                                        if (var49 != var50 && var42 > 0)
                                        {
                                            var0.SetClip(0, 75, 240, 240);
                                            var53.m_a(var0, false);
                                        }

                                        if (var49 == var50 && var46)
                                        {
                                            var0.SetClip(0, 75, 240, 240);
                                            g = var0;
                                            m_c(false);
                                        }
                                    }

                                    if (var42 > 0)
                                    {
                                        var53.m_a(var0, true);
                                    }

                                    if (var46)
                                    {
                                        m_c(true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        // ---- widescreen: draw dynamic entities (layer 3: characters, animated objects) over a wider viewport ----
        internal static void RenderWideEntities(Graphics gw, int leftExtra, int width)
        {
            int saveC = C, sS = S, sT = T, sU = U, sV = V;
            Graphics saveG = g;
            // drawing updates screen-space state (sprite positions, character draw bounds) that game logic reads
            // (interaction / hit tests). Snapshot it so the extra pass leaves no trace.
            var snap = new System.Collections.Generic.List<System.Action>();
            void Keep(MiamiNights.d[] arr)
            {
                if (arr == null) return;
                foreach (var o in arr) { if (o == null) continue; int a0 = o.a, b0 = o.b, m0 = o.d_ != null ? o.d_.m : 0; var dd = o.d_; snap.Add(() => { o.a = a0; o.b = b0; if (dd != null) dd.m = m0; }); }
            }
            Keep(c); Keep(MiamiNights.h.n); Keep(MiamiNights.h.v);
            if (MiamiNights.h.s != null)
                foreach (var ch in MiamiNights.h.s)
                {
                    if (ch == null) continue;
                    var bounds = ch.d; int[] copy = bounds != null ? (int[])bounds.Clone() : null;
                    var yy = ch.y; var zz = ch.z;
                    snap.Add(() => { ch.d = bounds; if (bounds != null) Array.Copy(copy, bounds, copy.Length); ch.y = yy; ch.z = zz; });
                    if (ch.y != null) { var o = ch.y; int a0 = o.a, b0 = o.b; snap.Add(() => { o.a = a0; o.b = b0; }); }
                    if (ch.z != null) { var o = ch.z; int a0 = o.a, b0 = o.b; snap.Add(() => { o.a = a0; o.b = b0; }); }
                }
            MiamiNights.d.Frozen = true;
            WidePass = true;
            try
            {
                C = saveC - leftExtra;
                m_a(gw, 3, C, D, width, 240, 0, 75);
            }
            catch (Exception) { }
            finally
            {
                MiamiNights.d.Frozen = false;
                WidePass = false;
                C = saveC; S = sS; T = sT; U = sU; V = sV; g = saveG;
                foreach (var r in snap) r();
            }
        }

        // ---- widescreen: render the whole level background (layers 0..2) uncropped ----
        internal static bool WorldDrawn;
        internal static int CurLevel = -1;
        internal static int FullX0, FullY0;

        internal static Image RenderFullBackground()
        {
            if (m == null || aj == null || r <= 0 || s <= 0 || p == null || e == null) return null;
            int x0 = -48, y0 = -240;
            int fw = (r + s) * 22 + 96, fh = 76 + (r + s) * 11 + 60 + 240;
            var big = new Image(fw, fh);
            Graphics saveG = g;
            int saveX = X, sS = S, sT = T, sU = U, sV = V;
            var saveW = (sbyte[])W.Clone();
            try
            {
                g = big.GetGraphics();
                X = 0;
                for (int i = 0; i < f_; i++)
                {
                    short[] o = e[i];
                    if (o == null || !(o[0] < 90 && o[5] != -127 && ae[i] <= 7)) continue;
                    d ob = c[i];
                    int[] bb = ag[i];
                    if (ob == null || bb == null) continue;
                    if (m_a(bb[0] - x0, bb[1] - y0, bb[2] - x0, bb[3] - y0, 0, 0, fw, fh))
                    {
                        if ((ob.d_.h[ob.e] & 255) == 1 && X < W.Length) W[X++] = (sbyte)i;
                        ob.d_.m = (int)o[4];
                    }
                }
                for (int cy = 0; cy < fh; cy += 240)
                    for (int cx = 0; cx < fw; cx += 240)
                    {
                        int cw = Math.Min(240, fw - cx), ch = Math.Min(240, fh - cy);
                        for (int layer = 0; layer < 3; layer++)
                        {
                            try { m_a(null, layer, x0 + cx, y0 + cy, cw, ch, cx, cy); } catch (Exception) { }
                        }
                    }
            }
            finally
            {
                g = saveG; X = saveX; S = sS; T = sT; U = sU; V = sV;
                Array.Copy(saveW, W, W.Length);
            }
            FullX0 = x0; FullY0 = y0;
            return big;
        }

        // original static void a(Graphics) — background tiles + entities + foreground pass
        internal static void m_a(Graphics var0)
        {
            WorldDrawn = true;
            int[] var10000 = new int[]{0, 0};
            g = aj;
            int var3 = m.GetWidth();
            int var4 = m.GetHeight();
            int var5;
            if ((var5 = C % var3) < 0)
            {
                var5 += var3;
            }

            int var6;
            if ((var6 = D % var4) < 0)
            {
                var6 += var4;
            }

            int var7 = var3 - var5;
            int var8 = var4 - var6;
            d var9 = null;
            object var10 = null;
            int var12 = C - E;
            int var13 = D - F;
            X = 0;

            for (int var1 = 0; var1 < f_; var1++)
            {
                var9 = c[var1];
                if (((short[])(var10 = e[var1]))[0] < 90 && ((short[])var10)[5] != -127 && ae[var1] <= 7)
                {
                    var9.a = ((short[])var10)[1] - C << 8;
                    var9.b = ((short[])var10)[2] - D << 8;
                    int[] var11;
                    if (m_a((var11 = ag[var1])[0] - C, var11[1] - D, var11[2] - C, var11[3] - D, 0, 0, var3, var4))
                    {
                        if ((var9.d_.h[var9.e] & 255) == 1)
                        {
                            W[X] = (sbyte)var1;
                            X++;
                        }

                        var9.d_.m = (int)((short[])var10)[4];
                    }
                }
            }

            if (var12 <= 44 && var13 <= 44)
            {
                if (var12 > 0 || var12 < 0)
                {
                    int var16;
                    int var18;
                    if (var12 > 0)
                    {
                        var16 = var5 - 22;
                        var18 = C + var3 - 22;
                    }
                    else
                    {
                        var16 = var5;
                        var18 = C;
                    }

                    sbyte var20 = 1;
                    if (var16 < 0 || var16 + 22 >= var3)
                    {
                        var20 = 2;
                    }

                    for (int var32 = 0; var32 < 3; var32++)
                    {
                        for (int var28 = 0; var28 < var20; var28++)
                        {
                            if (var28 == 1)
                            {
                                if (var16 < 0)
                                {
                                    var16 += var3;
                                }
                                else if (var16 + 22 >= var3)
                                {
                                    var16 = -(var3 - var16);
                                }
                            }

                            m_a(null, var32, var18, D + var8, 22, var6, var16, 0);
                            m_a(null, var32, var18, D, 22, var8, var16, var6);
                        }
                    }

                    E = C;
                }

                if (var13 > 0 || var13 < 0)
                {
                    int var17;
                    int var19;
                    if (var13 > 0)
                    {
                        var19 = D + var4 - 22;
                        var17 = var6 - 22;
                    }
                    else
                    {
                        var19 = D;
                        var17 = var6;
                    }

                    sbyte var34 = 1;
                    if (var17 < 0 || var17 + 22 >= var4)
                    {
                        var34 = 2;
                    }

                    for (int var33 = 0; var33 < 3; var33++)
                    {
                        for (int var29 = 0; var29 < var34; var29++)
                        {
                            if (var29 == 1)
                            {
                                if (var17 < 0)
                                {
                                    var17 += var4;
                                }
                                else if (var17 + 22 >= var4)
                                {
                                    var17 = -(var4 - var17);
                                }
                            }

                            try
                            {
                                m_a(null, var33, C, var19, var7, 22, var5, var17);
                            }
                            catch (Exception var27)
                            {
                                var27.ToString();
                            }

                            try
                            {
                                m_a(null, var33, C + var7, var19, var5, 22, 0, var17);
                            }
                            catch (Exception var26)
                            {
                                var26.ToString();
                            }
                        }
                    }

                    F = D;
                }
            }
            else
            {
                for (int var15 = 0; var15 < 3; var15++)
                {
                    m_a(null, var15, C, D, var7, var8, var5, var6);
                    m_a(null, var15, C + var7, D + var8, var5, var6, 0, 0);
                    m_a(null, var15, C, D + var8, var7, var6, var5, 0);
                    m_a(null, var15, C + var7, D, var5, var8, 0, var6);
                }

                E = C;
                F = D;
            }

            var0.SetClip(0, 75, 240, 240);

            try
            {
                m_a(var0, 0, 0, var5, var6, var7, var8);
            }
            catch (Exception) { }

            try
            {
                m_a(var0, 0, var6, var5, var8, var7, 0);
            }
            catch (Exception) { }

            try
            {
                m_a(var0, var5, 0, var7, var6, 0, var8);
            }
            catch (Exception) { }

            try
            {
                m_a(var0, var5, var6, var7, var8, 0, 0);
            }
            catch (Exception) { }

            var0.SetClip(0, 75, 240, 240);
            m_a(var0, 3, C, D, 240, 240, 0, 75);
            m_d(var0);
        }

        // original private static void a(Graphics,int,int,int,int,int,int) — clipped drawRegion strip
        private static void m_a(Graphics var0, int var1, int var2, int var3, int var4, int var5, int var6)
        {
            if (var5 + var3 >= 240)
            {
                var3 -= var5 + var3 - 240;
            }

            if (var6 + var4 >= 240)
            {
                var4 -= var6 + var4 - 240;
            }

            if (var1 < 0)
            {
                Console.WriteLine("xxxxxxxxxxxxxxx lesssssssss");
                var1 = 0;
            }

            if (var2 < 0)
            {
                Console.WriteLine("yyyyyyyyyyyyyyyy lesssssssss");
                var2 = 0;
            }

            if (var3 > 0 && var4 > 0 && var1 >= 0 && var2 >= 0)
            {
                var0.DrawRegion(m, var1, var2, var3, var4, 0, var5 + 0, var6 + 75, 20);
            }
        }

        // original private static void a(Graphics,int[],int,int,g) — object instances in tile pass
        private static void m_a(Graphics var0, int[] var1, int var2, int var3, g var4)
        {
            d var13 = null;
            object var14 = null;
            int var15 = var2 + var3;
            int var16 = -C + 0;
            int var17 = -D + 75;

            for (int var6 = 0; var6 < X; var6++)
            {
                int var7 = W[var6] & 255;
                if (ae[var7] != 6)
                {
                    int[] var8 = ag[var7];
                    int var9 = ((short[])(var14 = e[var7]))[5] & 255;
                    int var10 = ((short[])var14)[6] & 255;
                    sbyte var11 = ae[var7];
                    sbyte var12 = af[var7];
                    int var5;
                    if (ae[var7] >= 5 || ((short[])var14)[8] != 1)
                    {
                        var5 = var9 + var10;
                    }
                    else if (((short[])var14)[9] == -1)
                    {
                        var5 = var9 + var11 - 1 + (var10 - (var12 - 1));
                    }
                    else
                    {
                        var5 = var9 - (var11 - 1) + var10 + (var12 - 1);
                    }

                    if ((ae[var7] == 7 || var5 > var15 && (var9 >= var2 || var10 >= var3) || var5 == var15 && var11 < var12)
                       && m_a(var8[0] + var16, var8[1] + var17, var8[2] + var16, var8[3] + var17, var1[0], var1[1], var1[2], var1[3]))
                    {
                        var11 = ae[var7];
                        var12 = af[var7];
                        bool var18 = false;
                        if (var4 != null && (var11 > 1 || var12 > 1))
                        {
                            int var19 = var4.c[0] >> 8;
                            int var20 = var4.c[1] >> 8;
                            if (((short[])var14)[8] == 1)
                            {
                                if (var19 >= var9 && var19 < var9 + var11 && var20 > var10 - var12 && var20 <= var10)
                                {
                                    var18 = true;
                                }
                            }
                            else if (var19 >= var9 && var19 < var9 + var12 && var20 > var10 - var11 && var20 <= var10)
                            {
                                var18 = true;
                            }
                        }

                        if (!var18)
                        {
                            var0.SetClip(var1[0], var1[1], var1[2] - var1[0], var1[3] - var1[1]);
                            var0.ClipRect(0, 75, 240, 240);
                            (var13 = c[var7]).a = var16 + ((short[])var14)[1] << 8;
                            var13.b = var17 + ((short[])var14)[2] << 8;
                            var13.d_.m = (int)((short[])var14)[4];
                            var13.m_a(var0);
                        }
                    }
                }
            }
        }

        // original static void a(Graphics,g)
        internal static void m_a(Graphics var0, g var1)
        {
            m_a(var0, var1.d, var1.c[0] >> 8, var1.c[1] >> 8, var1);
        }

        // original static int a(int[]) — nearest type-93 zone
        internal static int m_a(int[] var0)
        {
            int var1 = var0[0] + C;
            int var2 = var0[1] + D;
            object var4 = null;
            int var5 = -1;
            int var6 = 100000;

            for (int var7 = 0; var7 < f_; var7++)
            {
                if (((short[])(var4 = e[var7]))[0] == 93
                   && var1 >= ((short[])var4)[1]
                   && var2 >= ((short[])var4)[2]
                   && var1 < ((short[])var4)[1] + 240
                   && var2 < ((short[])var4)[2] + 240)
                {
                    int var8 = var1 - (((short[])var4)[1] + 120);
                    int var9 = var2 - (((short[])var4)[2] + 120);
                    int var10;
                    if ((var10 = var8 * var8 + var9 * var9) < var6)
                    {
                        var5 = var7;
                        var6 = var10;
                    }
                }
            }

            return var5;
        }

        // original static int b(int[]) — hud corner hit test
        internal static int m_b(int[] var0)
        {
            if (var0[0] < 40)
            {
                return 0;
            }
            else if (var0[0] > 200)
            {
                return 1;
            }
            else if (var0[1] - 63 < 40)
            {
                return 2;
            }
            else
            {
                return var0[1] > 200 ? 3 : -1;
            }
        }

        // original private static void q() — daytime palette table
        private static void m_q()
        {
            G = GloftMMN.m_j(5);
            H = new short[90];
            int var0 = 0;

            for (int var2 = 0; var2 < 90; var2++)
            {
                H[var2] = (short)var0;
                int var1 = G[var0++] & 255;
                var0 += var1;
                var1 = G[var0++] & 255;
                var0 += var1;
            }
        }

        // original private static String l(int,int) — object label
        private static string m_l(int var0, int var1)
        {
            int var2 = 0;

            for (int var3 = 0; var3 < 90; var3++)
            {
                int var4 = m_b(var3, 3, -1);
                if (var3 == var0)
                {
                    sbyte var5;
                    if ((var5 = I[var2 + var1]) == -1)
                    {
                        return "UNKNOWN !";
                    }

                    return GloftMMN.m_k(var5 & 255);
                }

                var2 += var4;
            }

            return null;
        }

        // original static int b(int,int,int) — object property read
        internal static int m_b(int var0, int var1, int var2)
        {
            int var3 = H[var0];
            int var4 = G[var3++] & 255;
            if (var1 == 0)
            {
                return var4;
            }
            else if (var1 == 1)
            {
                return G[var3 + var2] >> 3;
            }
            else if (var1 == 2)
            {
                return G[var3 + var2] & 7;
            }
            else
            {
                var3 += var4;
                if (var1 == 3)
                {
                    return G[var3] & 0xFF;
                }
                else
                {
                    return var1 == 4 ? G[var3 + 1 + var2] & 0xFF : -1;
                }
            }
        }

        // original private static void c(boolean) — player sprite draw + hud bits
        internal static bool WidePass;   // set while RenderWideEntities runs

        private static void m_c(bool var0)
        {
            // the player is always inside the original camera window (the camera follows them) and some player poses
            // (sleeping/sitting) use cached screen coords -> never draw the player in the widescreen side pass
            if (WidePass) return;
            g var1 = MiamiNights.h.s[0];
            d var2 = MiamiNights.h.n[0];
            if (MiamiNights.h.h_ != 18)
            {
                if (!var0)
                {
                    var1.m_g();
                    int[] var3 = new int[]{0, 0};
                    if (aD)
                    {
                        var2.m_b();
                        return;
                    }

                    if (MiamiNights.h.y != 5 || MiamiNights.h.z >= 0)
                    {
                        m_a(var1.c[0], var1.c[1], var3);
                        var2.a = var3[0] + 0 << 8;
                        var2.b = var3[1] + 75 << 8;
                    }

                    var2.d_.m = 0;
                    Image[] var4 = var2.d_.w[0];
                    int var5 = 0;

                    for (int var6 = 0; var6 < var2.d_.a_; var6++)
                    {
                        if (MiamiNights.h.q[var1.a[0]][var6] == 5)
                        {
                            if (var1.a[0] == 0 && var1.a[4] == 11 || var1.a[22] > 40 && bc[30] == 1)
                            {
                                int var8 = var1.a[0];
                                int var9 = MiamiNights.h.p[var8][5].a_ / MiamiNights.h.r[var8][5];
                                int var10 = var1.a[4];
                                if (var1.a[0] == 0)
                                {
                                    var9--;
                                }

                                if (var1.a[0] == 0)
                                {
                                    int var11 = var9 - 1;
                                    if (var10 >= var11)
                                    {
                                        var10++;
                                    }
                                }

                                if (var10 >= var9)
                                {
                                    var10 -= var9;
                                    if (var1.a[0] == 0)
                                    {
                                        var8 = 1;
                                        var10 = MiamiNights.g.X[var10];
                                    }
                                    else
                                    {
                                        var8 = 0;
                                        var10 = MiamiNights.g.Y[var10];
                                    }
                                }

                                a var12 = MiamiNights.h.p[var8][5];
                                var4[var6] = var12.w[0][var10 * 3 + var5];
                            }
                            else
                            {
                                bc[30] = 0;
                                var4[var6] = MiamiNights.g.Z[var5];
                            }

                            if (++var5 == 3)
                            {
                                break;
                            }
                        }
                    }

                    var2.m_a(g);
                }

                var1.d = var2.m_c();
                var1.d[0] = var1.d[0] >> 8;
                var1.d[1] = var1.d[1] >> 8;
                var1.d[2] = var1.d[2] >> 8;
                var1.d[3] = var1.d[3] >> 8;
                if (var0)
                {
                    MiamiNights.h.aB.SetClip(0, 75, 240, 240);
                    if (MiamiNights.h.y == 0 && (au != -1 || av != -1) && MiamiNights.h.X != 1)
                    {
                        m_a(g, null, false, true, false, null);
                    }

                    d var13 = MiamiNights.h.v[19];
                    if (MiamiNights.g.u >= 0)
                    {
                        if (var13.e != MiamiNights.g.u)
                        {
                            var13.e = -1;
                            var13.m_a(MiamiNights.g.u);
                            var13.i = var2;
                            var13.a = 0;
                            var13.b = -16128;
                        }

                        var13.m_a(g);
                        if (var13.e != 76 || !var13.m_a())
                        {
                            var13.m_b();
                        }
                    }
                    else
                    {
                        var13.e = -1;
                    }
                }

                if (!var0)
                {
                    m_a(g, var1);
                }

                if (!var0 && MiamiNights.h.y != 1)
                {
                    var2.m_b();
                }
            }
        }

        // original private static void d(Graphics,int) — highlight selected object
        private static void m_d(Graphics var0, int var1)
        {
            if (MiamiNights.h.y == 0 && !ba && var1 == au)
            {
                d var2 = c[var1];
                short[] var3 = e[var1];
                ba = true;
                var0.SetClip(0, 75, 240, 240);
                var2.a = var3[1] - C + 0 << 8;
                var2.b = var3[2] - D + 75 << 8;
                m_a(var0, var2, true, false, false, null);
            }
        }

        // original private static void d(Graphics) — NPC bubbles / name tags
        private static void m_d(Graphics var0)
        {
            var0.SetClip(0, 75, 240, 240);
            if (MiamiNights.h.y == 5 && MiamiNights.h.z < 0 && ax > 0 && (m_i(ax, 10) & 0xFF) != 255)
            {
                d var1;
                (var1 = MiamiNights.h.t[0]).d_ = MiamiNights.h.n[0].d_;
                var1.d_.m = MiamiNights.h.s[0].b[15];
                var1.m_a(var0);
                var1.m_b();
            }

            for (int var2 = 1; var2 < MiamiNights.h.s.Length; var2++)
            {
                g var3;
                if ((var3 = MiamiNights.h.s[var2]) != null && var3.s)
                {
                    d var4 = MiamiNights.h.n[var3.b[5]];
                    int var5 = (var3.c[0] >> 8) + (var3.c[1] >> 8);
                    int var6 = (MiamiNights.h.s[0].c[0] >> 8) + (MiamiNights.h.s[0].c[1] >> 8);
                    if (var4 != null && var4.e == 67)
                    {
                        var0.SetClip(0, 75, 240, 240);
                        var4.d_.m = var3.b[15];
                        var4.d_.m_a(var0, 68, (int)(MiamiNights.h.aG / 2L % 15L), var4.a >> 8, var4.b >> 8, var4.c, 0, 0);
                        if (var5 < var6)
                        {
                            int[] var7 = new int[4];
                            var4.d_.m_a(var7, 68, (int)(MiamiNights.h.aG / 2L % 15L), var4.a, var4.b, var4.c, 0, 0);
                            var7[0] >>= 8;
                            var7[1] >>= 8;
                            var7[2] >>= 8;
                            var7[3] >>= 8;
                            int[] var8 = MiamiNights.h.s[0].d;
                            var0.SetClip(0, 0, 240, 400);
                            if (m_a(var7[0], var7[1], var7[2], var7[3], var8[0], var8[1], var8[2], var8[3]))
                            {
                                var0.SetClip(var7[0], var7[1], var7[2] - var7[0], var7[3] - var7[1]);
                                MiamiNights.h.n[0].d_.m = MiamiNights.h.s[0].b[15];
                                MiamiNights.h.n[0].m_a(var0);
                                m_c(true);
                            }
                        }
                    }
                }
            }
        }

        // original static int a(int,int,int,int) — distance
        internal static int m_a(int var0, int var1, int var2, int var3)
        {
            int var4 = var0 - var2 << 8;
            int var5 = var1 - var3 << 8;
            return GloftMMN.m_a((long)(var4 * var4 + var5 * var5));
        }

        // original private static int r()
        private static int m_r()
        {
            for (int var0 = 0; var0 < f_; var0++)
            {
                if (e[var0][0] < 90 && e[var0][7] == aG)
                {
                    return var0;
                }
            }

            return -1;
        }

        // original private static void d(int[])
        private static void m_d(int[] var0)
        {
            var0[0] += C - 0;
            var0[1] += D - 75;
            m_b(var0[0], var0[1], var0);
        }

        // original private static int[] g(int) — object placement rect
        private static int[] m_g(int var0)
        {
            short[] var1;
            short var2 = (var1 = e[var0])[0];
            short var3 = var1[3];
            short var4 = var1[5];
            short var5 = var1[6];
            int var7 = m_b(var2, 1, var3);
            int var8 = m_b(var2, 2, var3);
            int var9 = 0;

            for (int var10 = 1; var10 < MiamiNights.h.s.Length; var10++)
            {
                if (MiamiNights.h.s[var10] != null && MiamiNights.h.s[var10].m_b())
                {
                    int var11 = MiamiNights.h.s[var10].c[0] >> 8;
                    int var12 = MiamiNights.h.s[var10].c[1] >> 8;
                    if (var11 >= var4 && var11 < var4 + var7 && var12 <= var5 && var12 > var5 - var8)
                    {
                        var9++;
                    }
                }
            }

            c[var0].a = var1[1] - C + 0 << 8;
            c[var0].b = var1[2] - D + 75 << 8;
            if (var9 != 0)
            {
                return c[var0].m_c(var9);
            }
            else
            {
                for (int var13 = 0; var13 < 4; var13++)
                {
                    int[] var14;
                    if ((var14 = c[var0].m_c(var13)) != null)
                    {
                        m_d(var14);
                        int var15;
                        if (((var15 = m_b(var14[0], var14[1])) != 1 || MiamiNights.h.H == 25) && (var15 & 15872) == 0)
                        {
                            return c[var0].m_c(var13);
                        }
                    }
                }

                return null;
            }
        }

        // original static void a(g,int,int,int,int) — set NPC facing anim
        internal static void m_a(g var0, int var1, int var2, int var3, int var4)
        {
            d var5 = MiamiNights.h.n[var0.b[5] & 255];
            var0.o[0] = var1;
            var0.o[1] = var2;
            m_c(var0.o);
            var0.n[0] = var1 * w[0] + var2 * x[0] >> 8;
            var0.n[1] = var1 * w[1] + var2 * x[1] >> 8;
            m_c(var0.n);
            if (var0.n[1] < 0)
            {
                var5.m_a(var3);
            }
            else
            {
                var5.m_a(var4);
            }

            if (var0.n[0] < 0)
            {
                var5.c = 1;
            }
            else
            {
                var5.c = 0;
            }
        }

        // original private static void h(int) — move player to object
        private static void m_h(int var0)
        {
            g var1 = MiamiNights.h.s[0];
            short[] var3;
            int var4 = ((var3 = e[var0])[5] << 8) + 127;
            int var5 = (var3[6] << 8) + 127;
            int var6 = m_b(var3[0], 1, var3[3]);
            int var7 = m_b(var3[0], 2, var3[3]);
            if (var6 > 1 && var6 < 5)
            {
                var4 += (var6 << 8) / 2;
                var5 -= (var7 << 8) / 2;
            }

            int var8 = (var1.c[0] & -256) + 127;
            int var9 = (var1.c[1] & -256) + 127;
            m_a(var1, var4 - var8, var5 - var9, 1, 0);
        }

        // original static void a(g,g) — move a toward b
        internal static void m_a(g var0, g var1)
        {
            int var2 = var1.c[0];
            int var3 = var1.c[1];
            int var4 = var0.c[0];
            int var5 = var0.c[1];
            m_a(var0, var2 - var4, var3 - var5, 1, 0);
        }

        // original static void c(int[]) — normalize
        internal static void m_c(int[] var0)
        {
            int var1;
            if ((var1 = GloftMMN.m_a((long)(var0[0] * var0[0] + var0[1] * var0[1]))) != 0)
            {
                var0[0] = (var0[0] << 8) / var1;
                var0[1] = (var0[1] << 8) / var1;
            }
        }
        // original static boolean a(boolean,boolean) — warp to object/target
        internal static bool m_a(bool var0, bool var1)
        {
            short[] var4 = null;
            if (au >= 0)
            {
                var4 = e[au];
            }

            if (var0)
            {
                g var9 = MiamiNights.h.s[0];
                aG = (sbyte)m_i(aX[MiamiNights.h.B], 9);
                int[] var10;
                if (aG >= 0)
                {
                    var10 = m_g(m_r());
                }
                else
                {
                    var10 = m_g(au);
                }

                if (var10 == null)
                {
                    aI[0] = var9.c[0];
                    aI[1] = var9.c[1];
                }
                else
                {
                    m_d(var10);
                    int var2;
                    if ((var2 = m_b(var10[0], var10[1])) != 1 && !m_a(var2, var10[0], var10[1], 0, true))
                    {
                        aI[0] = var10[0];
                        aI[1] = var10[1];
                    }
                    else
                    {
                        aI[0] = var9.c[0];
                        aI[1] = var9.c[1];
                    }
                }

                if (var1)
                {
                    var9.c[0] = aI[0];
                    var9.c[1] = aI[1];
                }
                else
                {
                    MiamiNights.h.z = 2;
                }

                return false;
            }
            else
            {
                g var5;
                bool var6;
                if ((var6 = (var5 = MiamiNights.h.s[0]).m_a(aI)) && var4 != null)
                {
                    int var7 = (var4[5] << 8) + 127 - var5.c[0];
                    int var8 = (var4[6] << 8) + 127 - var5.c[1];
                    if (var7 != 0 && var8 != 0)
                    {
                        m_a(var5, var7, var8, 1, 0);
                    }
                }

                return var6;
            }
        }

        // original static void a(Graphics,boolean) — shop / dialogue action
        internal static void m_a(Graphics var0, bool var1)
        {
            g var2 = MiamiNights.h.s[av];
            g var3 = MiamiNights.h.s[0];
            if (var1)
            {
                bool var27 = false;
                sbyte var28;
                if (var3.c[0] > var2.c[0])
                {
                    var28 = 1;
                }
                else
                {
                    var28 = -1;
                }

                int var30 = var2.c[0];
                int var39 = var2.c[1];
                int var25 = var30 + 160 * var28;
                int var26 = var39 - 160 * var28;
                int var40 = m_b(var25, var26);
                bool var42 = false;
                var42 = false | (var40 == 1 || m_a(var40, var25, var26, 0, true));
                int[] var47 = new int[]{0, 0};
                m_a(var25, var26, var47);
                if (var42 = var42 | (var47[0] <= 0 || var47[0] >= 239))
                {
                    var28 = (sbyte)(var28 * -1);   // Java: var28 *= -1 (byte compound)
                    var25 = var30 + 160 * var28;
                    var26 = var39 - 160 * var28;
                    var40 = m_b(var25, var26);
                    var42 = false | (var40 == 1 || m_a(var40, var25, var26, 0, true));
                    m_a(var25, var26, var47);
                    if (var42 = var42 | (var47[0] <= 0 || var47[0] >= 239))
                    {
                        MiamiNights.g.N.removeAllElements();
                        MiamiNights.h.z = 0;
                        return;
                    }
                }

                aI[0] = var25;
                aI[1] = var26;
                var3.c[0] = aI[0];
                var3.c[1] = aI[1];
                m_b(var0, 4);
                m_a(var2, var3);
            }
            else
            {
                d var5 = MiamiNights.h.n[var2.b[5] & 255];
                sbyte var6 = MiamiNights.h.E[MiamiNights.h.D - 2];
                sbyte var7 = MiamiNights.h.E[MiamiNights.h.D - 1];
                int var8;
                int var9;
                if ((var9 = var8 = MiamiNights.h.E[MiamiNights.h.D]) == -1)
                {
                    var9 = 0;
                }

                var9 += var6 * 28 + var7 * 7;
                var2.r[var9]++;
                int var10;
                MiamiNights.h.x = (sbyte)(var10 = var2.r[var9] & 255);
                int var11 = -1;
                var9 = m_c(var6, var7);
                int var12 = aJ[var9 + 6] & 255;
                int var13 = -1;
                if (var8 != -1)
                {
                    var9 += 7 + var12 * 4;

                    for (int var4 = 0; var4 <= var8; var4++)
                    {
                        if (var4 == var8)
                        {
                            var13 = aJ[var9 + 0] | aJ[var9 + 0 + 1] << 8;
                        }

                        var11 = aJ[var9 + 2] & 255;
                        var12 = aJ[var9 + 3] & 255;
                        var9 += 4;
                        if (var4 != var8)
                        {
                            var9 += var12 * 4;
                        }
                    }
                }
                else
                {
                    var11 = aJ[var9 + 4] & 255;
                    var12 = aJ[var9 + 6] & 255;
                    var9 += 7;
                }

                if (var13 != -1)
                {
                    aQ = 2;
                    if (var2.l != null)
                    {
                        for (int var21 = 0; var21 < var2.l.Length; var21++)
                        {
                            if ((var2.l[var21] & 255) == var13)
                            {
                                aQ = 0;
                            }
                        }
                    }

                    if (var2.m != null)
                    {
                        for (int var22 = 0; var22 < var2.m.Length; var22++)
                        {
                            if ((var2.m[var22] & 255) == var13)
                            {
                                aQ = 1;
                            }
                        }
                    }
                }

                int var14 = var11;

                for (int var23 = 0; var23 < var12; var23++)
                {
                    int var15 = var9 + var23 * 4;
                    int var16 = aJ[var15 + 1] & 255 | (aJ[var15 + 2] & 255) << 8;
                    int var17 = aJ[var9 + var23 * 4 + 3] & 255;
                    int var18 = aJ[var9 + var23 * 4 + 0] & 255;
                    bool var19 = MiamiNights.g.m_a(var16, var2, true);
                    if (var18 == 1)
                    {
                        var19 = !var19;
                    }

                    if (var19)
                    {
                        var14 = var17;
                        break;
                    }
                }

                if (var6 == 1 && var7 == 2)
                {
                    if (m_d(var2.b[13]) != -1)
                    {
                        MiamiNights.g.m_a(915);
                    }
                    else if (var14 == var11)
                    {
                        int var49;
                        if ((var49 = MiamiNights.g.m_b(var2)) == -3)
                        {
                            MiamiNights.g.m_a(432);
                            MiamiNights.h.P = true;
                        }
                        else if (var49 == -2)
                        {
                            MiamiNights.g.m_a(GloftMMN.m_k(var2.a[1]) + GloftMMN.m_k(433));
                        }
                        else
                        {
                            MiamiNights.h.O = true;
                        }
                    }
                }
                else if (var14 == var11 && var6 == 1 && var7 == 0 && var8 == 1)
                {
                    if (MiamiNights.h.H == 25)
                    {
                        MiamiNights.g.m_a(904);
                    }
                    else
                    {
                        sbyte var48 = var2.b[13];
                        int var51 = -1;
                        if (var48 != -2)
                        {
                            var51 = m_d(var48);
                        }

                        int var53;
                        if ((var53 = MiamiNights.g.m_b(var2)) == -3 || var53 == -1)
                        {
                            MiamiNights.g.m_a(432);
                        }
                        else if (var53 != -2 && var51 == -1)
                        {
                            MiamiNights.g.m_a(GloftMMN.m_k(var2.a[1]) + GloftMMN.m_k(431));
                        }

                        if (var53 != -3)
                        {
                            MiamiNights.h.s[av].m_a(0, 0, -1);
                            MiamiNights.g.m_a(872);
                            bc[26] = (sbyte)av;
                            if (bc[0] >= 30)
                            {
                                MiamiNights.h.m = 22;
                            }
                            else
                            {
                                MiamiNights.h.m = 0;
                            }
                        }
                    }

                    MiamiNights.h.z = 0;
                    return;
                }

                var9 = m_c(var6, var7);
                int var50;
                if ((var50 = aJ[var9 + 3] & 255) == 255)
                {
                    var9 = m_c(var6, -1);
                    var50 = aJ[var9 + 3] & 255;
                }

                var9 = MiamiNights.g.m_f(var14);
                int var52 = MiamiNights.g.@as[var9++] & 255;

                int var24;
                for (var24 = 0; var24 < var52; var24++)
                {
                    var9 = MiamiNights.g.m_h(var14, var24);
                    int var54 = MiamiNights.g.@as[var9 + 0] & 255;
                    int var55 = MiamiNights.g.@as[var9 + 1] & 255;
                    if (var10 >= var54 && var10 <= var55)
                    {
                        break;
                    }
                }

                int var56 = m_a(var2, MiamiNights.g.@as, var9 + 10, false, true);
                if (var6 != 3 && var7 != 0 && var56 > 0 && var56 > var3.a[35])
                {
                    MiamiNights.g.m_a(GloftMMN.m_k(434) + " " + var56 + "$");
                    MiamiNights.h.z = 0;
                    MiamiNights.h.D = 0;
                }
                else
                {
                    d var57;
                    (var57 = MiamiNights.h.n[0]).e = -1;
                    if (var50 == 60 && var14 != 40)
                    {
                        var57.m_a(48);
                    }
                    else
                    {
                        var57.m_a(var50);
                    }

                    aM = var14;
                    aN = var24;
                    var9 = MiamiNights.g.m_h(aM, aN);
                    aP = MiamiNights.g.@as[var9 + 3] & 255;
                    aO = MiamiNights.g.@as[var9 + 4] & 255;
                    aq = false;
                    ar = false;
                    var5.e = -1;
                    var5.m_a(0);
                    int var20 = (MiamiNights.g.@as[var9 + 2] & 255) * 255 / 100;
                    if (var57.c == 1)
                    {
                        var20 *= -1;
                    }

                    var3.c[0] = var2.c[0] - var20;
                    var3.c[1] = var2.c[1] + var20;
                    MiamiNights.h.z = 11;
                }
            }
        }
        // original static void d() — transaction anim step
        internal static void m_d()
        {
            d var0 = MiamiNights.h.n[0];
            if (!aq)
            {
                g var1 = MiamiNights.h.s[av];
                d var2 = MiamiNights.h.n[var1.b[5]];
                if (aO == 0)
                {
                    var2.e = -1;
                    var2.m_a(aP);
                    aO = -1;
                    if (MiamiNights.h.y == 11)
                    {
                        int var3 = MiamiNights.g.m_h(aM, aN);
                        int var4;
                        if ((var4 = MiamiNights.g.@as[var3 + 9] & 255) != 255)
                        {
                            MiamiNights.g.x = var1;
                            MiamiNights.h.v[17].m_a(var4);
                            MiamiNights.h.v[17].c = 0;
                            m_a(var2, var0.a > var2.a);
                        }
                    }
                }
                else if (aO == -1)
                {
                    if (var2.m_a())
                    {
                        aq = true;
                        var2.e = -1;
                        var2.m_a(0);
                    }
                }
                else
                {
                    aO--;
                }
            }

            if (!ar && var0.m_a())
            {
                ar = true;
                var0.e = -1;
                var0.m_a(0);
            }
        }

        // original static void a(d,boolean)
        internal static void m_a(d var0, bool var1)
        {
            d var3;
            (var3 = MiamiNights.h.v[18]).a = var0.a;
            var3.b = var0.b - 16128 + 2816;
            if (var1)
            {
                var3.a -= 1536;
                var3.c = 1;
            }
            else
            {
                var3.a += 1536;
                var3.c = 0;
            }
        }

        // original static void b(int) — drop sprite images of NPC slot
        internal static void m_b(int var0)
        {
            a var1 = MiamiNights.h.n[MiamiNights.h.s[var0].b[5]].d_;
            if (MiamiNights.h.n[MiamiNights.h.s[var0].b[5]].d_ != null && var1.w != null)
            {
                for (int var2 = 0; var2 < var1.w.Length; var2++)
                {
                    if (var1.w[var2] != null)
                    {
                        for (int var3 = 0; var3 < var1.w[var2].Length; var3++)
                        {
                            var1.w[var2][var3] = null;
                        }

                        var1.w[var2] = null;
                    }
                }
            }
        }

        // original static void e() — drop all cached sprite images
        internal static void m_e()
        {
            for (int var1 = 0; var1 < MiamiNights.h.s.Length; var1++)
            {
                if (MiamiNights.h.s[var1] != null)
                {
                    m_b(var1);
                }
            }

            for (int var6 = 0; var6 < 2; var6++)
            {
                a var4;
                if ((var4 = MiamiNights.h.o[var6]) != null)
                {
                    int var2 = 0;
                    if (var4.w != null)
                    {
                        for (; var2 < var4.w.Length; var2++)
                        {
                            if (var4.w[var2] != null)
                            {
                                for (int var3 = 0; var3 < var4.w[var2].Length; var3++)
                                {
                                    var4.w[var2][var3] = null;
                                }

                                var4.w[var2] = null;
                            }
                        }
                    }
                }
            }

            MiamiNights.h.t[0].d_ = null;

            for (int var7 = 1; var7 < MiamiNights.h.s.Length; var7++)
            {
                g var0;
                if ((var0 = MiamiNights.h.s[var7]) != null)
                {
                    if (var0.e == null)
                    {
                        var0.m_c();
                        MiamiNights.h.s[var7] = null;
                    }
                    else
                    {
                        for (int var9 = 0; var9 < var0.r.Length; var9++)
                        {
                            var0.r[var9] = 0;
                        }
                    }
                }
            }

            for (int var8 = 0; var8 < MiamiNights.h.p.Length; var8++)
            {
                if (MiamiNights.h.p[var8] != null)
                {
                    for (int var10 = 0; var10 < MiamiNights.h.p[var8].Length; var10++)
                    {
                        a var12;
                        if ((var12 = MiamiNights.h.p[var8][var10]) != null && var12.w != null)
                        {
                            for (int var11 = 0; var11 < var12.w.Length; var11++)
                            {
                                if (var12.w[var11] != null)
                                {
                                    for (int var5 = 0; var5 < var12.w[var11].Length; var5++)
                                    {
                                        var12.w[var11][var5] = null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // original private static void s() — spawn/refresh NPCs at zone objects
        private static void m_s()
        {
            bk = false;
            int var3 = MiamiNights.h.s[0].a[0];
            MiamiNights.g.j[0] = 0;
            MiamiNights.g.j[1] = 0;
            MiamiNights.h.s[0].m_a(7 + MiamiNights.h.s[0].a[0] * 2, 0, true);
            MiamiNights.g.j[var3] = 1;

            for (int var0 = 0; var0 < MiamiNights.h.s.Length; var0++)
            {
                if (MiamiNights.h.s[var0] != null)
                {
                    if (bc[25] != var0)
                    {
                        MiamiNights.h.s[var0].b[19] = 0;
                    }

                    MiamiNights.h.s[var0].b[20] = 0;
                    MiamiNights.h.s[var0].s = false;
                }
            }

            int var5 = 1;

            for (int var6 = 0; var6 < 2; var6++)
            {
                for (int var11 = 0; var11 < f_; var11++)
                {
                    short var4;
                    if ((var4 = e[var11][0]) == 90 || var4 == 92)
                    {
                        if (var4 == 92)
                        {
                            if (var6 == 0 && bc[25] > 0 && bc[26] <= 0)
                            {
                                g var14 = MiamiNights.h.s[bc[25]];
                                if (bc[24] == K)
                                {
                                    m_a(var11, var14.c);
                                    var14.m_a(var14.c[0], var14.c[1]);
                                    var14.b[4] = var14.b[2];
                                    var14.m_a(0, -1, -1);
                                    var14.m_a(7 + var14.a[0] * 2, bc[25], true);
                                    if (var14.b[19] == 0)
                                    {
                                        ai = 870;
                                    }

                                    var14.b[19] = 1;
                                    var14.b[20] = 1;
                                    var14.b[12] = 0;
                                    var14.A = false;
                                }
                            }
                            else if (bc[26] > 0 && var6 == 0)
                            {
                                g var13 = MiamiNights.h.s[bc[26]];
                                if (bc[0] >= 30 && (K == 22 || K == 34 || K == 23) || bc[0] < 30 && (K == 0 || K == 1))
                                {
                                    m_a(var11, var13.c);
                                    var13.m_a(var13.c[0], var13.c[1]);
                                    var13.b[4] = var13.b[2];
                                    var13.m_a(0, -1, -1);
                                    var13.m_a(7 + var13.a[0] * 2, bc[26], true);
                                    if (var13.b[19] == 0)
                                    {
                                        ai = 870;
                                    }

                                    var13.b[19] = 1;
                                    var13.b[20] = 1;
                                    var13.b[12] = 0;
                                    var13.A = false;
                                    bk = true;
                                }
                                else
                                {
                                    var13.b[19] = 0;
                                    var13.b[20] = 0;
                                }
                            }
                        }
                        else
                        {
                            short var7 = e[var11][9];
                            short var8 = e[var11][10];
                            bool var9 = var7 < 2 || MiamiNights.g.m_a(var7 - 2, null, false);
                            bool var10 = var8 < 2 || MiamiNights.g.m_a(var8 - 2, null, false);
                            if (var9 && var10)
                            {
                                int var1 = 1;

                                g var2;
                                while (
                                   var1 < MiamiNights.h.s.Length
                                      && (
                                         (var2 = MiamiNights.h.s[var1]) == null
                                            || var2.e == null
                                            || (var2.a[43] == 127 || e[var11][4] != var2.b[13]) && (var2.e[0] != K || (var2.e[1] & 255) != var11)
                                      )
                                )
                                {
                                    var1++;
                                }

                                if (var1 != MiamiNights.h.s.Length)
                                {
                                    if (var6 == 0 && var1 != bc[25])
                                    {
                                        MiamiNights.h.s[var1].b[20] = 1;
                                        MiamiNights.h.s[var1].b[14] = (sbyte)var11;
                                        MiamiNights.h.s[var1].b[3] = 0;
                                        MiamiNights.h.s[var1].b[18] = -1;
                                        m_a(var11, MiamiNights.h.s[var1].c);
                                        MiamiNights.h.s[var1].m_a(MiamiNights.h.s[var1].c[0], MiamiNights.h.s[var1].c[1]);
                                        MiamiNights.h.s[var1].m_a(e[var11][3], e[var11][5], -1);
                                        MiamiNights.h.s[var1].b[4] = -1;
                                        MiamiNights.h.s[var1].m_a(7 + MiamiNights.h.s[var1].a[0] * 2, var1, true);
                                    }
                                }
                                else if (var6 == 1)
                                {
                                    while (var5 < MiamiNights.h.s.Length && MiamiNights.h.s[var5] != null)
                                    {
                                        var5++;
                                    }

                                    (var2 = new g(-1, var5, e[var11][4], false, true)).b[14] = (sbyte)var11;
                                    MiamiNights.h.s[var5] = var2;
                                    var2.b[6] = (sbyte)var5;
                                    m_a(var11, MiamiNights.h.s[var5].c);
                                    MiamiNights.h.s[var5].m_a(MiamiNights.h.s[var5].c[0], MiamiNights.h.s[var5].c[1]);
                                    var2.m_a(e[var11][3], e[var11][5], -1);
                                }
                            }
                        }
                    }
                }
            }

            m_c(-1);
            MiamiNights.g.m_a(true);
            g var15;
            if (bc[25] > 0 && bc[24] != K && (var15 = MiamiNights.h.s[bc[25]]).b[19] == 1)
            {
                sbyte var16;
                if ((var16 = bc[26]) == bc[25] && (bc[0] >= 30 && (K == 22 || K == 34 || K == 23) || bc[0] < 30 && (K == 0 || K == 1)))
                {
                    bc[25] = -1;
                    return;
                }

                var15.b[19] = 0;
                bc[25] = -1;
                ai = 880;
            }
        }

        // original static void c(int) — NPC takeover pairing
        internal static void m_c(int var0)
        {
            for (int var4 = 1; var4 < MiamiNights.h.s.Length; var4++)
            {
                g var8;
                if ((var8 = MiamiNights.h.s[var4]) != null && var8.m_b())
                {
                    int var1 = var8.c[0] & -256;
                    int var2 = var8.c[1] & -256;
                    int var5 = var8.b[2] & 255;
                    int var6;
                    if ((var6 = aL[1 + var5 * 5 + 2] & 255) != 255)
                    {
                        g var7 = null;
                        int var3;
                        if ((var3 = (m_b(var1 + 256, var2 - 256) & 15872) >> 9) != 0)
                        {
                            var7 = MiamiNights.h.s[var3];
                        }
                        else if ((var3 = (m_b(var1 - 256, var2 + 256) & 15872) >> 9) != 0)
                        {
                            var7 = MiamiNights.h.s[var3];
                        }

                        if (var7 != null && (var0 == -1 || (var8.b[6] & 255) == var0 || (var7.b[6] & 255) == var0))
                        {
                            int var9 = aL[1 + var5 * 5 + 3] & 255;
                            int var10 = 255 * var9 / 100;
                            var7.m_a(var8.c[0] + var10, var8.c[1] - var10);
                            var8.m_a(var5, 0, var6);
                            var7.m_a(var6, 1, var5);
                            if (var7.y != null)
                            {
                                var7.y.a -= (44 * var9 << 8) / 200;
                            }

                            var8.b[12] = var7.b[6];
                            var7.b[12] = var8.b[6];
                        }
                    }
                }
            }
        }

        // original static int c(int,int) — dialogue row offset
        internal static int m_c(int var0, int var1)
        {
            int var2 = 0;

            do
            {
                int var3 = aJ[var2 + 3] & 255;
                int var4 = 0;
                if (var0 != 0 || var1 != -1)
                {
                    for (var2 += 4; var4 < var3; var4++)
                    {
                        if (var0 == 0 && var1 != -1 && var4 == var1)
                        {
                            return var2;
                        }

                        int var5 = aJ[var2 + 5] & 255;
                        int var6 = aJ[var2 + 6] & 255;
                        var2 += 7;

                        for (var2 += var6 * 4; var5 > 0; var5--)
                        {
                            var2 += 3;
                            var6 = aJ[var2] & 255;
                            var2 += 1 + var6 * 4;
                        }
                    }

                    var0--;
                }
            } while (var0 > 0 || var0 >= 0 && var1 != -1);

            return var2;
        }

        // original static void f() — load dialogue table
        internal static void m_f()
        {
            aJ = GloftMMN.m_j(1);
        }

        // original static void g() — load trades table
        internal static void m_g()
        {
            aL = GloftMMN.m_j(3);
        }

        // original static void h() — load schedule table
        internal static void m_h()
        {
            aK = GloftMMN.m_j(2);
        }
        // original static int d(int,int)
        internal static int m_d(int var0, int var1)
        {
            int var2 = aK[1 + var0 * 2] & 255 | (aK[1 + var0 * 2 + 1] & 255) << 8;
            int var3 = aK[0] & 255;
            int var4 = aK[1 + var3 * 2] & 255;
            var2++;
            int var8 = var1;
            if (var1 < 0)
            {
                var8 = var4;
            }

            for (int var5 = 0; var5 < var8; var5++)
            {
                sbyte var6;
                int var7;
                if ((var7 = (var6 = aK[var2++]) & 3) == 0)
                {
                    var2++;
                }
                else if (var7 == 1)
                {
                    var2 += 2;
                }
                else if (var7 == 2)
                {
                    var2 += (var6 & 252) >> 2;
                }
            }

            return var2;
        }

        // original static int d(int)
        internal static int m_d(int var0)
        {
            int var1 = aK[1 + var0 * 2] & 255 | (aK[1 + var0 * 2 + 1] & 255) << 8;
            return aK[var1];
        }

        // original static void b(Graphics,int) — leave shop page
        internal static void m_b(Graphics var0, int var1)
        {
            if (MiamiNights.h.D == 2 && var1 == 4)
            {
                m_b(var0, true);
            }
            else
            {
                if (au >= 0)
                {
                    m_h(au);
                }
                else if (MiamiNights.h.D == 0)
                {
                    MiamiNights.h.E[0] = -1;
                    MiamiNights.h.E[1] = -1;
                    MiamiNights.h.E[2] = -1;
                    g var2 = MiamiNights.h.s[0];
                    g var3 = MiamiNights.h.s[av];
                    d var4 = MiamiNights.h.n[var3.b[5]];
                    m_a(var2, var3);
                    m_a(var3, var2);
                    var4.m_a(0);
                    int var5;
                    if ((var5 = var3.b[12] & 255) != 0)
                    {
                        MiamiNights.h.n[MiamiNights.h.s[var5].b[5] & 255].m_a(0);
                    }

                    var3.A = true;
                }

                MiamiNights.h.z = (sbyte)var1;
                MiamiNights.h.v[0].m_a(15);
                MiamiNights.h.B = 0;
            }
        }

        // original static void c(Graphics,int) — shop page render
        internal static void m_c(Graphics var0, int var1)
        {
            int var3 = 0;
            sbyte var4 = -1;
            d var7 = MiamiNights.h.v[0];
            d var8 = MiamiNights.h.v[3];
            d var9 = MiamiNights.h.v[4];
            var7.a = 17408;
            var7.b = 65280;
            if (var7.e == 15 && var7.g == 0)
            {
                m_n();
                m_a(var0);
                m_o();
            }

            if (var7.e == 15)
            {
                var7.d_.m_a(var0, 5, 0, var7.a >> 8, var7.b >> 8, 0, 0, 0);
                var7.d_.m_a(var0, 6, 0, var7.a >> 8, var7.b >> 8, 0, 0, 0);
                var7.m_a(var0);
                if (var7.m_a())
                {
                    var7.e = -1;
                }
                else
                {
                    var7.m_b();
                }
            }
            else
            {
                if (var1 == 3)
                {
                    MiamiNights.h.C = aY;
                }
                else if (var1 == 4)
                {
                    if (MiamiNights.h.D == 0)
                    {
                        MiamiNights.h.C = 4;
                    }
                    else if (MiamiNights.h.D == 1)
                    {
                        var3 = m_c(var4 = MiamiNights.h.E[MiamiNights.h.D - 1], -1);
                        MiamiNights.h.C = aJ[var3 + 3];
                    }
                }

                var7.m_a(17 + MiamiNights.h.B);
                int var10;
                bool var11;
                if ((var11 = (var10 = m_a(var7)) != 16 && var10 != 17 && var10 != 18 && var10 != 19) || MiamiNights.h.aa)
                {
                    m_n();
                    m_a(var0);
                    m_o();
                    if (var11)
                    {
                        MiamiNights.h.aa = true;
                    }
                    else
                    {
                        MiamiNights.h.aa = false;
                    }
                }

                var7.d_.m_a(var0, 5, 0, var7.a >> 8, var7.b >> 8, 0, 0, 0);
                var7.d_.m_a(var0, 6, 0, var7.a >> 8, var7.b >> 8, 0, 0, 0);
                var8.m_a(4);
                if (MiamiNights.h.y != 34 && MiamiNights.h.y != 16)
                {
                    var8.a = var7.a;
                    var8.b = var7.b;
                    var8.m_a(var0);
                    var8.m_b();
                }

                MiamiNights.h.m_b();

                for (int var2 = MiamiNights.h.C - 1; var2 >= 0; var2--)
                {
                    int var12 = (var7.a >> 8) + var7.d_.m_b(var10, var2);
                    int var13 = (var7.b >> 8) + var7.d_.m_c(var10, var2);
                    int[] var14 = new int[]{0, 0, 0, 0};
                    var7.d_.m_a(var14, 14, 0, var12 << 8, var13 << 8, 0, 0, 0);
                    sbyte var15 = 4;
                    switch (var2)
                    {
                        case 0:
                            var15 = 4;
                            break;
                        case 1:
                            var15 = 6;
                            break;
                        case 2:
                            var15 = 7;
                            break;
                        case 3:
                            var15 = 5;
                            break;   // Java fell out of switch here; break added (same behavior)
                    }

                    if (var2 == MiamiNights.h.B)
                    {
                        MiamiNights.h.m_a(var14[0] >> 8, var14[1] >> 8, var14[2] - var14[0] >> 8, var14[3] - var14[1] >> 8, 0, 0, 3, 0, var15, 0);
                    }
                    else
                    {
                        MiamiNights.h.m_a(var14[0] >> 8, var14[1] >> 8, var14[2] - var14[0] >> 8, var14[3] - var14[1] >> 8, var15, 0, 0, 0, var15, 0);
                    }

                    var7.d_.m_a(var0, 14, 0, var12, var13, 0, 0, 0);
                    if (var2 == MiamiNights.h.B)
                    {
                        var9.a = var12 << 8;
                        var9.b = var13 << 8;
                        if (MiamiNights.h.y == 34)
                        {
                            var9.m_a(9);
                        }
                        else
                        {
                            var9.m_a(8);
                        }

                        var9.m_a(var0);
                    }

                    int var5 = -1;
                    int var6 = -1;
                    if (var1 == 3)
                    {
                        int var16;
                        if ((var16 = aX[var2]) == -1)
                        {
                            var5 = 21;
                            var6 = 0;
                        }
                        else
                        {
                            var5 = m_g(var6 = m_i(var16, 5), 1);
                        }
                    }
                    else if (MiamiNights.h.D == 0)
                    {
                        var3 = m_c(var2, -1);
                        var5 = aJ[var3 + 2];
                        var6 = aJ[var3 + 0];
                    }
                    else if (MiamiNights.h.D == 1)
                    {
                        var3 = m_c(var4, var2);
                        var5 = aJ[var3 + 2];
                        var6 = aJ[var3 + 0];
                    }

                    MiamiNights.h.u[1].m_a(var0, var5, 0, var12, var13, 0, 0, 0);
                    if (var2 == MiamiNights.h.B)
                    {
                        int[] var20;
                        if ((var20 = var9.m_c(0)) != null)
                        {
                            MiamiNights.h.M.m_a(var0, GloftMMN.m_k(var6), var20[0], var20[1], 20, 1);
                        }

                        if (!var9.m_a())
                        {
                            var9.m_b();
                        }
                    }
                }
            }
        }

        // original static void b(Graphics,boolean) — shop item list
        internal static void m_b(Graphics var0, bool var1)
        {
            d var2 = MiamiNights.h.v[0];
            d var3 = MiamiNights.h.v[4];
            sbyte var4 = MiamiNights.h.E[MiamiNights.h.D - 2];
            sbyte var5 = MiamiNights.h.E[MiamiNights.h.D - 1];
            int var6 = m_c(var4, var5);
            int var7 = aJ[var6 + 5] & 255;
            int var8 = aJ[var6 + 6] & 255;
            var6 += 7 + var8 * 4;
            if (var1)
            {
                if (var7 <= 0)
                {
                    m_a(var0, false);
                }
                else
                {
                    MiamiNights.h.y = 16;
                    MiamiNights.h.B = 0;
                }
            }
            else
            {
                sbyte var9 = MiamiNights.h.B;
                MiamiNights.h.B = (sbyte)var5;
                MiamiNights.h.D--;
                m_c(var0, 4);
                MiamiNights.h.y = 16;
                MiamiNights.h.D++;
                MiamiNights.h.B = var9;
                var0.SetClip(0, 0, 240, 400);
                var0.SetColor(0);
                int var11 = 0;
                int[] var15 = new int[var7];

                for (int var10 = 0; var10 < var7; var10++)
                {
                    var15[var10] = aJ[var6 + 0] | aJ[var6 + 0 + 1] << 8;
                    var8 = aJ[var6 + 3] & 255;
                    var6 += 4 + var8 * 4;
                }

                int[] var16 = var3.m_c(0);
                MiamiNights.h.m_b();

                for (int var22 = var7 - 1; var22 >= 0; var22--)
                {
                    sbyte var13 = 11;
                    if (var22 == MiamiNights.h.B)
                    {
                        var13 = 12;
                    }

                    var2.d_.m_a(var0, var13, 0, var3.a >> 8, (var3.b >> 8) - 18 * (var7 - 1 - var22), 0, 0, 0);
                    var11 = var16[0];
                    int var12 = var16[1] - 18 * (var7 - var22) + 2;
                    MiamiNights.h.M.m_a(var0, GloftMMN.m_k(var15[var22]), var11, var12, 20, 1);
                    int var17 = var3.a >> 8;
                    int var18 = (var3.b >> 8) - 18 * (var7 - 1 - var22);
                    int[] var19 = new int[]{0, 0, 0, 0};
                    var2.d_.m_a(var19, 11, 0, var17 << 8, var18 << 8, 0, 0, 0);
                    MiamiNights.h.m_a(var19[0] >> 8, var19[1] >> 8, var19[2] - var19[0] >> 8, var19[3] - var19[1] >> 8, 29, var22, 3, 0, 29, var22);
                }
            }
        }

        // original static void e(int,int) — hover scan for interactables
        internal static void m_e(int var0, int var1)
        {
            int var2 = au;
            int var3 = av;
            au = -1;
            av = -1;
            int var4 = var0 >> 8;
            int var5 = var1 >> 8;
            int var16 = 25600000;
            g var19 = MiamiNights.h.s[0];
            int var17 = var0 + var19.o[0];
            int var18 = var1 + var19.o[1];
            var17 >>= 8;
            var18 >>= 8;

            for (int var6 = var4 - 1; var6 <= var4 + 1; var6++)
            {
                for (int var7 = var5 - 1; var7 <= var5 + 1; var7++)
                {
                    int var9 = m_b(var6 << 8, var7 << 8);
                    int var13 = (var6 << 8) + 127;
                    int var14 = (var7 << 8) + 127;
                    if ((var9 & 15872) != 0)
                    {
                        int var20 = (var9 & 15872) >> 9;
                        if ((MiamiNights.h.s[var20].b[11] & 255) != 6)
                        {
                            d var21 = MiamiNights.h.n[MiamiNights.h.s[var20].b[5] & 255];
                            if (MiamiNights.h.s[var20].s && var21.a >> 8 > 0 && var21.b >> 8 < 315)
                            {
                                int var15 = ((var13 - var0) * (var13 - var0) >> 8) + ((var14 - var1) * (var14 - var1) >> 8);
                                if (var6 == var17 && var7 == var18)
                                {
                                    av = var20;
                                    au = -1;
                                    var6 = var4 + 2;
                                    var7 = var5 + 2;
                                }
                                else if (var15 <= var16)
                                {
                                    av = var20;
                                    au = -1;
                                    var16 = var15;
                                }
                            }
                        }
                    }

                    if (var6 != var4 + 2 && var7 != var5 + 2 && (var9 & 3) == 2)
                    {
                        int var10 = (var9 & 508) >> 2;

                        for (int var8 = 0; var8 < 4; var8++)
                        {
                            sbyte var11;
                            if ((var11 = l[var10 * 4 + var8]) != -1)
                            {
                                var11 = (sbyte)(var11 & 255);   // Java compound byte&=255
                                short var12;
                                if ((var12 = e[var11][0]) < 90 && m_b(var12, 1, e[var11][3]) <= 6)
                                {
                                    m_f(var11);
                                    if (aY > 0 && (var12 != 57 || MiamiNights.h.H != 28 && MiamiNights.h.H != 23 && MiamiNights.h.H != 31))
                                    {
                                        if (var6 == var17 && var7 == var18)
                                        {
                                            au = var11;
                                            av = -1;
                                            var6 = var4 + 2;
                                            var7 = var5 + 2;
                                            break;
                                        }

                                        int var31;
                                        if (av == -1 && (var31 = ((var13 - var0) * (var13 - var0) >> 8) + ((var14 - var1) * (var14 - var1) >> 8)) <= var16)
                                        {
                                            au = var11;
                                            av = -1;
                                            var16 = var31;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            d var34 = MiamiNights.h.v[1];
            d var35 = MiamiNights.h.v[2];
            string var23 = null;
            if (au == 38 && f_ == 56)
            {
                au = -1;
            }

            bool var22;
            if (av != -1)
            {
                var22 = var3 != av;
            }
            else
            {
                if (au == -1)
                {
                    return;
                }

                var22 = var2 != au;
                m_f(au);
                int var24 = e[au][3];
                int var25 = -1;
                short var30;
                int var26 = m_b(var30 = e[au][0], 3, -1);

                for (int var28 = 0; var28 < var26; var28++)
                {
                    int var27 = m_b(var30, 4, var28);
                    if (var24 < var27)
                    {
                        var25 = var28;
                        break;
                    }

                    var24 -= var27;
                }

                var23 = m_l(e[au][0], var25);
            }

            if (var22)
            {
                var34.e = -1;
                var34.m_a(0);
                var35.e = -1;
                aw = 0;
            }
            else
            {
                if (aw >= 300 && var35.e == -1)
                {
                    var35.m_a(2);
                }

                if (var35.e == 2 && var35.m_a())
                {
                    var35.m_a(3);
                }

                aw = (int)(aw + MiamiNights.h.aH);
            }

            m_i();
            if (var23 != null)
            {
                m_a(var23, 0);
            }
        }

        // original static void a(Graphics,d,boolean,boolean,boolean,g) — npc bubbles + name tags
        internal static void m_a(Graphics var0, d var1, bool var2, bool var3, bool var4, g var5)
        {
            // the widescreen side pass re-renders layer 3; bubbles/name tags belong to the main pass only (else they show twice)
            if (WidePass) return;
            d var6 = MiamiNights.h.v[1];
            d var7 = MiamiNights.h.v[2];
            var0.SetClip(0, 75, 240, 240);
            if (var2 && MiamiNights.g.p > 500L)
            {
                int[] var8 = var1.m_c();
                if (var4)
                {
                    var7.a = var1.a;
                    var7.b = var1.b - 16128;
                }
                else
                {
                    var7.a = var8[2] + var8[0] >> 1;
                    var7.b = var8[1];
                }

                MiamiNights.h.bb[0] = var7.a >> 8;
                MiamiNights.h.bb[1] = var7.b >> 8;
                MiamiNights.h.bc = true;
                if (var7.e == 0)
                {
                    var7.m_a(3);
                }

                if (var7.e >= 0)
                {
                    var7.m_a(var0);
                    var7.m_b();
                }
            }
            else if (var5 != null && m_d(var5.b[13]) >= 0)
            {
                var0.SetClip(0, 75, 240, 240);
                MiamiNights.h.u[1].m_a(var0, 87, 0, var1.a >> 8, var5.d[1], 0, 0, 0);
            }

            if (var3)
            {
                d var9 = MiamiNights.h.n[0];
                var6.a = var9.a;
                var6.b = var9.b - 16128;
                if (var6.b < 21248)
                {
                    var6.a = var9.a + -4096;
                    var6.b = var9.b - 8064;
                }

                var6.m_a(var0);
                if (var6.e == 1 && var6.m_a())
                {
                    var6.e = -1;
                    var6.m_a(1);
                }

                if (!var6.m_a())
                {
                    var6.m_b();
                }

                MiamiNights.h.bd[0] = var6.a >> 8;
                MiamiNights.h.bd[1] = var6.b >> 8;
                MiamiNights.h.be = true;
            }
        }
        // original static boolean f(int,int) — zone-94 hover line
        internal static bool m_f(int var0, int var1)
        {
            int var3 = m_b(var0, var1);
            if (bc[31] == 0 && (var3 & 3) == 2)
            {
                int var4 = (var3 & 508) >> 2;

                for (int var2 = 0; var2 < 4; var2++)
                {
                    sbyte var5;
                    if ((var5 = l[var4 * 4 + var2]) != -1)
                    {
                        var5 = (sbyte)(var5 & 255);   // Java compound byte&=255
                        short var7;
                        if (e[var5][0] == 94 && (var7 = e[var5][4]) > -2)
                        {
                            if (aR != var5)
                            {
                                aR = var5;
                                au = -1;
                                av = -1;
                                d var8;
                                (var8 = MiamiNights.h.v[1]).e = -1;
                                var8.m_a(1);
                            }

                            m_i();
                            var7 = (short)(var7 & 255);   // Java: var7 &= 255 (short)
                            var2 = 141 + var7;
                            if (var7 > 127)
                            {
                                var2 = 400;
                            }

                            if (var2 == 169)
                            {
                                var2 = 918;
                            }

                            m_a(GloftMMN.m_k(var2), 1);
                            return true;
                        }
                    }
                }
            }

            aR = -1;
            return false;
        }

        // original static void a(Graphics,boolean,boolean) — hud top/bottom bars
        internal static void m_a(Graphics var0, bool var1, bool var2)
        {
            if (MiamiNights.h.X != 1)
            {
                var0.SetClip(0, 0, 240, 400);
                d var3;
                int var4 = (var3 = MiamiNights.h.v[7]).a;
                int var5 = var3.b;
                int var6 = var3.e;
                var3.a = 30720;
                var3.b = 51200;

                if (var1)
                {
                    var0.SetColor(0);
                    var0.FillRect(0, 0, 240, 75);
                    MiamiNights.g.H = -1;
                    var3.m_a(24);
                    var3.m_a(var0);
                }

                if (var2)
                {
                    var0.SetColor(0);
                    var0.FillRect(0, 314, 240, 85);
                    var3.m_a(25);
                    var3.b = 65280;
                    var3.m_a(var0);
                }

                var3.a = var4;
                var3.b = var5;
                var3.e = var6;
            }
        }

        // original static void a(String,int) — queue message
        internal static void m_a(string var0, int var1)
        {
            aS.addElement(var1.ToString() + var0);
        }

        // original static void b(Graphics) — draw queued message
        internal static void m_b(Graphics var0)
        {
            if (aS != null)
            {
                if (MiamiNights.h.k)
                {
                    MiamiNights.g.p = 1000L;
                    be = null;
                }

                var0.SetClip(0, 315, 240, 85);
                d var1;
                (var1 = MiamiNights.h.v[7]).a = 30720;
                var1.b = 51200;
                if (aS.size() <= 0)
                {
                    if (be != null)
                    {
                        var1.m_a(30);
                        var1.m_a(var0);
                        be = null;
                    }
                }
                else
                {
                    string var2 = aS.elementAt(0);
                    if (MiamiNights.h.h_ != 8 || (be == null || string.CompareOrdinal(be, var2) != 0) && MiamiNights.g.p >= 700L)
                    {
                        int var4 = 0;   // CFR: int n2 (VF byte mis-inference; stride 11 over 72 records)
                        sbyte var5 = 3;
                        if (aR != -1)
                        {
                            var1.m_a(27);
                            var1.m_a(var0);
                            var5 = 2;
                            var4 = 1;
                        }
                        else if (au != -1)
                        {
                            var1.m_a(29);
                            var1.m_a(var0);
                        }
                        else
                        {
                            var1.m_a(26);
                            var1.m_a(var0);
                        }

                        int[] var3 = var1.m_c(var5);
                        MiamiNights.h.M.m_a(var0, var2.Substring(1), var3[0], var3[1], 20, var4);
                        be = var2;
                    }
                }
            }
        }

        // original static void i() — dequeue message
        internal static void m_i()
        {
            if (aS.size() > 0)
            {
                aS.removeElementAt(0);
            }
        }

        // original private static String m(int,int) — 12/24h suffix
        private static string m_m(int var0, int var1)
        {
            short var2;
            if (var1 == 0 && var0 == 0)
            {
                var0 = 12;
                var2 = 840;
            }
            else if (var0 == 0)
            {
                var0 += 12;
                var2 = 839;
            }
            else if (var0 >= 1 && var0 <= 11)
            {
                var2 = 839;
            }
            else if (var0 >= 12 && var0 < 13)
            {
                var2 = 840;
            }
            else
            {
                var0 -= 12;
                var2 = 840;
            }

            string var3 = GloftMMN.m_k(var2);
            return var0 < 10 ? "0" + var0 + var3 : var0 + var3;
        }

        // original static String a(long,boolean) — clock text
        internal static string m_a(long var0, bool var2)
        {
            long var5 = var0 / 3600L % 24L;
            long var7 = var0 / 60L % 60L;
            string var9 = "" + var7;
            if (var7 < 10L)
            {
                var9 = "0" + var9;
            }

            string var12;
            if (var2)
            {
                int var11 = (var12 = m_m((int)var5, (int)var7)).Length;
                var12 = var12.Substring(0, var11 - 2) + ":" + var9 + var12.Substring(var11 - 2, 2);
            }
            else
            {
                var12 = "" + var5;
                if (var5 < 10L)
                {
                    var12 = "0" + var5;
                }

                var12 = var12 + ":" + var9;
            }

            return var12;
        }

        // original static boolean j() — night hours?
        internal static bool m_j()
        {
            long var2;
            return (var2 = aT / 1000L * 60L / 3600L % 24L) >= 21L || var2 <= 4L;
        }

        // original static boolean k() — evening hours?
        internal static bool m_k()
        {
            long var2;
            return (var2 = aT / 1000L * 60L / 3600L % 24L) >= 17L && var2 < 21L;
        }

        // original static boolean l() — morning hours?
        internal static bool m_l()
        {
            long var2;
            return (var2 = aT / 1000L * 60L / 3600L % 24L) >= 5L && var2 <= 8L;
        }

        // original static void c(Graphics,boolean) — clock tick
        internal static void m_c(Graphics var0, bool var1)
        {
            if (bm == -1)
            {
                if (string.CompareOrdinal("LANG", "EN") == 0)
                {
                    bm = 1;
                }
                else
                {
                    bm = 0;
                }
            }

            if (!var1)
            {
                var0.SetClip(0, 0, 240, 400);
                MiamiNights.h.v[7].m_a(24);
                int[] var2 = MiamiNights.h.v[7].m_c(1);
                var0.SetColor(0);
                var0.FillRect(var2[0], var2[1], 120, 15);
                string var3 = m_a(aT / 1000L * 60L, bm == 1);
                MiamiNights.h.M.m_a(var0, var3, var2[0], var2[1], 20, 0);
            }

            long var13;
            long var4 = (var13 = aT / 1000L * 60L) / 3600L % 24L;
            long var6 = var13 / 60L % 60L;
            if (MiamiNights.h.ai == 2 && var4 == 0L && bc[2] == 23)
            {
                MiamiNights.h.aj = true;
            }

            bc[2] = (sbyte)var4;
            if (var6 != aV)
            {
                for (int var8 = 0; var8 < 1; var8++)
                {
                    long var10;
                    if ((var10 = var6 - aV) < 0L)
                    {
                        var10 += 60L;
                    }

                    for (int var12 = 0; var12 < MiamiNights.g.D; var12++)
                    {
                        if (MiamiNights.g.q[var12] != -1L)
                        {
                            MiamiNights.g.q[var12] = MiamiNights.g.q[var12] - var10;
                            if (MiamiNights.g.q[var12] < 0L)
                            {
                                MiamiNights.g.q[var12] = 0L;
                            }
                        }
                    }
                }
            }

            aV = (int)var6;
        }

        // original static String e(int) — number with separators
        internal static string m_e(int var0)
        {
            string var1 = "";
            if (var0 > 1000000000)
            {
                string var3;
                int var4 = (var3 = ((int)(var0 * 100L / 1000000000L)).ToString()).Length;

                for (int var5 = 0; var5 < var4; var5++)
                {
                    var1 = var1 + var3.Substring(var5, 1);
                    if (var5 == 0)
                    {
                        var1 = var1 + ",";
                    }
                }

                var1 = var1 + "<";
            }
            else if (var0 > 1000000)
            {
                string var6;
                int var8 = (var6 = ((int)(var0 * 100L / 1000000L)).ToString()).Length;

                for (int var10 = 0; var10 < var8; var10++)
                {
                    var1 = var1 + var6.Substring(var10, 1);
                    if (var10 == 0)
                    {
                        var1 = var1 + ",";
                    }
                }

                var1 = var1 + ">";
            }
            else
            {
                string var2;
                int var7 = (var2 = var0.ToString()).Length;

                for (int var9 = 0; var9 < var2.Length; var9++)
                {
                    var1 = var1 + var2.Substring(var9, 1);
                    if (var9 != var7 - 1 && (var7 - 1 - var9) % 3 == 0)
                    {
                        var1 = var1 + ",";
                    }
                }
            }

            return var1;
        }

        // original static void d(Graphics,boolean) — money / stat bar
        internal static void m_d(Graphics var0, bool var1)
        {
            g var2 = MiamiNights.h.s[0];
            d var3 = MiamiNights.h.n[0];
            var0.SetClip(0, 0, 240, 400);
            if (var1 || var2.a[35] != MiamiNights.g.H || MiamiNights.h.k || bn)
            {
                d var4;
                int var5 = (var4 = MiamiNights.h.v[7]).a;
                int var6 = var4.b;
                var4.a = 30720;
                var4.b = 51200;
                var4.m_a(24);
                int[] var7 = var4.m_c(2);
                var0.SetColor(0);
                var0.FillRect(var7[0], var7[1], 240 - var7[0], 15);
                d var8;
                (var8 = MiamiNights.h.v[11]).a = var7[0] << 8;
                var8.b = var7[1] << 8;
                if (var1)
                {
                    var8.m_a(80);
                }
                else
                {
                    var8.m_a(79);
                }

                var8.m_a(var0);
                var8.m_b();
                int[] var9 = var4.m_c(3);
                string var16;
                if (var1)
                {
                    int var11 = bo[70];
                    int var12;
                    int var13;
                    var16 = m_e(Math.Abs(var13 = (var12 = bo[71]) - var11));
                    if (var13 < 0)
                    {
                        var16 = "-" + var16;
                    }
                    else
                    {
                        var16 = "+" + var16;
                    }

                    d var14;
                    (var14 = MiamiNights.h.v[12]).a = var8.a;
                    var14.b = 19200;
                    if (var13 < 0)
                    {
                        var14.m_a(82);
                    }
                    else
                    {
                        var14.m_a(81);
                        int var15;
                        var15 = ((var15 = MiamiNights.h.K % 6) << 8) / 5;
                        var14.a = var3.a + (var8.a - var3.a >> 8) * var15;
                        var14.b = var3.b - 16128 + (75 - ((var3.b >> 8) - 63)) * var15;
                    }

                    if (MiamiNights.h.h_ != 18)
                    {
                        var0.SetClip(0, 0, 240, 400);
                        var14.m_a(var0);
                        var14.m_b();
                    }
                }
                else
                {
                    var16 = m_e(var2.a[35]);
                    MiamiNights.g.H = var2.a[35];
                }

                MiamiNights.h.M.m_a(var0, var16, var9[0], var9[1], 24, 0);
                var4.a = var5;
                var4.b = var6;
            }

            bn = false;
        }
        // original static int a(g,byte[],int,boolean,boolean) — apply stat deltas
        internal static int m_a(g var0, sbyte[] var1, int var2, bool var3, bool var4)
        {
            if (var0 == MiamiNights.h.s[0])
            {
                if (bo == null)
                {
                    bo = new int[var0.a.Length * 2];
                }

                for (int var5 = 0; var5 < var0.a.Length; var5++)
                {
                    bo[var5 * 2 + 0] = var0.a[var5];
                }
            }

            for (int var15 = 0; var15 < aW.Length; var15++)
            {
                aW[var15] = null;
            }

            int var6 = var1[var2 + 0] & 255;
            if (var3)
            {
                return var2 + 1 + var6 * 2;
            }
            else
            {
                for (int var16 = 0; var16 < var6; var16++)
                {
                    sbyte var7 = var1[var2 + 1 + var16 * 2 + 0];
                    sbyte var8 = var1[var2 + 1 + var16 * 2 + 1];
                    if (var7 == 35)
                    {
                        var8 = (sbyte)(var8 * 5);   // Java: var8 *= 5 (byte compound)
                    }

                    if (!var4)
                    {
                        aW[var16] = GloftMMN.m_k(MiamiNights.g.m_d(var7, 0));
                        if (var8 != 0)
                        {
                            if (var8 > 0)
                            {
                                aW[var16] = "+" + aW[var16];
                            }
                            else
                            {
                                aW[var16] = "-" + aW[var16];
                            }
                        }

                        aW[var16] = aW[var16] + "#" + var7;
                        int var9 = var0.a[var7];
                        var0.m_c(var7, var8);
                        int var10 = var0.a[var7];
                        if (var0.b[6] == 0)
                        {
                            for (int var11 = 0; var11 < MiamiNights.g.B.Length; var11++)
                            {
                                sbyte var12;
                                if ((var12 = MiamiNights.g.B[var11]) == var7)
                                {
                                    int var13 = MiamiNights.g.m_e(var7, var9);
                                    int var14 = MiamiNights.g.m_e(var7, var10);
                                    if (var10 > var9 && var13 != var14)
                                    {
                                        if (var0.b[17] == 0)
                                        {
                                            var0.b[17] = (sbyte)var7;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (var7 == 35)
                    {
                        if (var8 < 0)
                        {
                            return -var8;
                        }

                        return 0;
                    }
                }

                if (var0 == MiamiNights.h.s[0])
                {
                    for (int var17 = 0; var17 < var0.a.Length; var17++)
                    {
                        bo[var17 * 2 + 1] = var0.a[var17];
                    }
                }

                return -1;
            }
        }

        // original static int g(int,int) — anim table lookup
        internal static int m_g(int var0, int var1)
        {
            for (int var3 = 0; var3 < am; var3++)
            {
                int var2 = ao[var3];
                if ((an[var2 + 0] & 255) == var0)
                {
                    if (var1 == -1)
                    {
                        return var3;
                    }

                    if (var1 != 2 && var1 != 4)
                    {
                        return an[var2 + var1] & 0xFF;
                    }

                    return an[var2 + var1] & 0xFF | (an[var2 + var1 + 1] & 0xFF) << 8;
                }
            }

            return -1;
        }

        // original static void f(int) — object frame availability scan
        internal static void m_f(int var0)
        {
            if (aX == null)
            {
                aX = new int[4];
            }

            aY = 0;
            short var3 = e[var0][0];
            int var4 = 0;   // CFR: int n2 (VF byte mis-inference; stride 11 over 72 records)

            for (int var1 = 0; var1 < @as; var1++)
            {
                int var2;
                if (((var2 = at[var4 + 0] & 255) == 255 || var2 == MiamiNights.h.H) && (at[var4 + 1] & 255) == var3)
                {
                    int var8 = c[var0].e;
                    int var9 = at[var4 + 2] & 255 | (at[var4 + 3] & 255) << 8;

                    for (int var10 = 0; var10 < 16; var10++)
                    {
                        if ((var9 & 1 << var10) != 0)
                        {
                            int var7 = m_h(var3, var10);
                            int var6 = m_b(var3, 4, var10);
                            if (var8 >= var7 && var8 < var7 + var6)
                            {
                                aX[aY++] = var1;
                                var10 = 16;
                                if (aY == 3 && var3 == 85)
                                {
                                    var1 = @as;
                                }
                            }
                        }
                    }
                }

                var4 += 11;
            }
        }

        // original static int h(int,int) — frame offset sum
        internal static int m_h(int var0, int var1)
        {
            int var2 = 0;

            for (int var4 = 0; var4 < var1; var4++)
            {
                var2 += m_b(var0, 4, var4);
            }

            return var2;
        }

        // original private static int n(int,int)
        private static int m_n(int var0, int var1)
        {
            short var2;
            int var3 = m_b(var2 = e[var0][0], 3, -1);
            int var4 = 0;

            for (int var5 = 0; var5 < var3 - 1; var5++)
            {
                if (var1 >= m_h(var2, var5) && var1 < m_h(var2, var5 + 1))
                {
                    var4 = var5;
                    break;
                }
            }

            return var4;
        }

        // original static int i(int,int) — schedule byte
        internal static int m_i(int var0, int var1)
        {
            return at[var0 * 11 + var1] & 0xFF;
        }

        // original static void a(int,boolean) — begin object interaction
        internal static void m_a(int var0, bool var1)
        {
            if (!var1)
            {
                MiamiNights.h.N[2] = 0;
            }

            ax = (sbyte)var0;
            int var2 = m_i(var0, 5);
            bool var3 = bc[26] > 0 || bc[25] > 0 || bc[31] == 1;
            if (var2 == 5)
            {
                if ((bc[0] & 255) >= 1 && !var3)
                {
                    MiamiNights.h.m_a(18);
                    MiamiNights.h.y = 36;
                    MiamiNights.h.z = 37;
                    MiamiNights.h.i = 0;
                }
                else
                {
                    MiamiNights.g.m_a(873);
                    MiamiNights.h.y = 0;
                }
            }
            else if (var2 == 62)
            {
                if (var3)
                {
                    MiamiNights.g.m_a(873);
                    MiamiNights.h.y = 0;
                }
                else
                {
                    MiamiNights.h.m_a(18);
                    MiamiNights.h.y = 36;
                    MiamiNights.h.z = 58;
                    MiamiNights.h.i = 0;
                }
            }
            else if (var2 == 64)
            {
                if (MiamiNights.h.s[0].a[22] > 40 && bc[30] == 1)
                {
                    MiamiNights.h.m_a(18);
                    MiamiNights.h.y = 36;
                    MiamiNights.h.z = 61;
                    MiamiNights.h.i = 0;
                }
                else
                {
                    MiamiNights.g.m_a(354);
                    MiamiNights.h.y = 0;
                }
            }
            else
            {
                bool var4 = true;
                if (var2 == 3 || var2 == 1 || var2 == 4)
                {
                    if (bb[0] != 0)
                    {
                        if (GloftMMN.m_b(0, 4))
                        {
                            GloftMMN.m_d(0);
                        }

                        MiamiNights.h.y = 0;
                        bb[0] = 0;
                        m_c();
                        MiamiNights.h.k = true;
                        return;
                    }

                    GloftMMN.m_e();
                    GloftMMN.m_c(4);
                    var4 = false;
                }

                if (var2 == 56 && bc[12] == 1)
                {
                    MiamiNights.g.m_a(905);
                    MiamiNights.h.y = 0;
                }
                else if (bk && var2 == 10)
                {
                    MiamiNights.g.m_a(913);
                    MiamiNights.h.y = 0;
                }
                else
                {
                    d var6;
                    (var6 = MiamiNights.h.n[0]).m_a(m_i(ax, 6));
                    var6.c = 0;
                    aF = c[au];
                    ay = (sbyte)((m_i(ax, 8) & 254) >> 1);
                    az = (ay & 255) * var6.m_b(var6.e);
                    aA = m_g(m_i(ax, 5), 2);
                    int var7 = (az << 8) / 12;
                    aU = (aA * 100 << 8) / var7;
                    aB = aT + aA * 60L * 1000L / 60L;
                    aC = 0;
                    aD = (m_i(ax, 8) & 1) == 1;
                    aG = (sbyte)m_i(ax, 9);
                    int var8;
                    if (aG == -1)
                    {
                        int[] var9;
                        if ((var9 = m_g(au)) != null && var4)
                        {
                            var6.a = var9[0] << 8;
                            var6.b = var9[1] << 8;
                        }

                        var8 = au;
                    }
                    else
                    {
                        int var15;
                        int[] var10 = m_g(var15 = m_r());
                        var6.a = var10[0] << 8;
                        var6.b = var10[1] << 8;
                        var8 = var15;
                    }

                    MiamiNights.h.ae[0] = MiamiNights.h.s[0].c[0];
                    MiamiNights.h.ae[1] = MiamiNights.h.s[0].c[1];
                    m_b((var6.a >> 8) - 0 + C, (var6.b >> 8) - 75 + D, MiamiNights.h.s[0].c);
                    int var16;
                    if (!m_a(var16 = m_b(MiamiNights.h.s[0].c[0], MiamiNights.h.s[0].c[1]), MiamiNights.h.s[0].c[0], MiamiNights.h.s[0].c[1], -1, false) && (var16 & 3) != 1)
                    {
                        int var17 = au;
                        int[] var11;
                        int var12 = (var11 = c[var17].m_c())[0] + (var11[2] - var11[0]) / 2;
                        if (var6.a > var12)
                        {
                            var6.c = 1;
                        }
                        else
                        {
                            var6.c = 0;
                        }
                    }
                    else
                    {
                        var6.c = c[var8].c;
                    }

                    if (var2 == 34)
                    {
                        if (c[var8].c == 0)
                        {
                            var6.c = 1;
                        }
                        else
                        {
                            var6.c = 0;
                        }
                    }

                    if (var2 == 53)
                    {
                        var6.c = 0;
                    }

                    if (var2 == 41)
                    {
                        var6.c = 0;
                    }

                    if (var2 == 42)
                    {
                        var6.c = 1;
                    }

                    if (var2 == 23 && MiamiNights.h.H == 11)
                    {
                        var6.c = 1;
                    }

                    if (var2 == 31 && MiamiNights.h.H == 11)
                    {
                        var6.c = 0;
                    }

                    aH = aF.e;
                    int var18 = m_i(ax, 4);
                    int var19 = c[au].e;
                    int var20 = m_n(au, var19);
                    int var13 = m_h(e[au][0], var20);
                    aF.m_a(var13 + var18);
                    MiamiNights.h.z = 5;
                    aE = 1;
                    int var14;
                    if ((var14 = m_i(ax, 10) & 0xFF) != 255)
                    {
                        MiamiNights.h.t[0].a = var6.a;
                        MiamiNights.h.t[0].b = var6.b;
                        MiamiNights.h.t[0].c = var6.c;
                        MiamiNights.h.t[0].m_a(var14);
                    }
                }
            }
        }
        // original static void m() — interaction tick / sound pump
        internal static void m_m()
        {
            d var0 = MiamiNights.h.n[0];
            bool var1 = false;
            if (ay > 0 && ay < 127)
            {
                if (var0.m_a())
                {
                    aC++;
                }

                if (aC == ay)
                {
                    var1 = true;
                }

                if (m_i(ax, 5) == 20 && GloftMMN.f && MiamiNights.h.X != 1)
                {
                    try
                    {
                        if (bp == null)
                        {
                            Console.WriteLine("hiiiiiiiiiiii" + MiamiNights.h.h_ + " :: " + MiamiNights.h.y);
                            bp = Manager.CreatePlayer(File.OpenRead(Midp.ResPath("/sfx_shower.wav")), "audio/x-wav");
                        }

                        bp.Realize();
                        bp.Prefetch();
                        bp.Start();
                    }
                    catch (Exception var15)
                    {
                        Console.WriteLine(var15);
                    }
                }
            }
            else
            {
                var1 = true;
            }

            if (!var1)
            {
                aE++;
            }
            else
            {
                int var2;
                if ((var2 = m_i(ax, 5)) == 18)
                {
                    bc[30] = 1;
                }

                aF.m_a(aH);
                aD = false;
                int var3 = ao[m_g(var2, -1)];
                bool var4;
                if (!(var4 = MiamiNights.h.N[2] == 1))
                {
                    MiamiNights.h.N[2] = 1;
                }

                aU = 100L;
                if (MiamiNights.h.N[3] != 1)
                {
                    aT = aB;
                }

                if (var4)
                {
                    m_a(MiamiNights.h.s[0], an, var3 + 6, false, false);
                }

                int var5 = an[var3 + 6 + 0] & 255;
                var3 += 7 + var5 * 2;
                var5 = an[var3] & 255;
                var3++;
                if (var4)
                {
                    for (int var6 = 0; var6 < var5; var6++)
                    {
                        int var7 = an[var3 + 0] & 255 | an[var3 + 1] << 8;
                        int var8 = an[var3 + 2] & 255;
                        if (MiamiNights.g.m_a(var7, null, false))
                        {
                            var3 += 3;

                            for (int var9 = 0; var9 < var8; var9++)
                            {
                                int var10 = an[var3 + 0] & 255;
                                int var11 = an[var3 + 1] & 255;
                                bool var12 = (var10 & 32) != 0;
                                int var13 = var10 & 192;
                                int var14 = var10 & 31;
                                if (var12)
                                {
                                    if (var13 == 128)
                                    {
                                        MiamiNights.g.m_g(var14, var11);
                                    }
                                    else
                                    {
                                        MiamiNights.g.m_g(var14, bb[var14] + var11);
                                    }
                                }
                                else if (var13 == 128)
                                {
                                    MiamiNights.g.m_f(var14, var11);
                                }
                                else
                                {
                                    MiamiNights.g.m_f(var14, bb[var14] + var11);
                                }

                                var3 += 2;
                            }
                            break;
                        }

                        var3 += 3 + var8 * 2;
                    }
                }

                var0.m_a(0);
                MiamiNights.h.s[0].c[0] = MiamiNights.h.ae[0];
                MiamiNights.h.s[0].c[1] = MiamiNights.h.ae[1];
                if (aW[0] == null)
                {
                    MiamiNights.g.m_p();
                    MiamiNights.h.k = true;
                }
                else
                {
                    int var20 = bo[70];
                    int var21;
                    if ((var21 = bo[71]) != var20)
                    {
                        MiamiNights.h.s[0].a[35] = var20;
                        MiamiNights.h.z = 6;
                    }
                    else
                    {
                        MiamiNights.h.z = 7;
                    }
                }
            }
        }

        // original static void a(Graphics,int,int,int,int) — stat progress bar
        internal static void m_a(Graphics var0, int var1, int var2, int var3, int var4)
        {
            int var6 = MiamiNights.h.s[0].a[var1];
            int[] var7 = new int[]{0, 0, 0};
            MiamiNights.g.m_a(var1, var6, var7);
            int var8 = var7[2];

            for (int var5 = 0; var5 < 3; var5++)
            {
                sbyte var9 = -1;
                if (var5 == 0)
                {
                    var9 = 0;
                }
                else if (var5 == 1)
                {
                    var9 = 4;
                    int var10 = 1 + var2;
                    int var11 = 13 * (var6 - var7[0]) / (var7[1] - var7[0]);
                    int var12 = var10 + var8 * 15 + var11;
                    if (var7[1] <= var7[0])
                    {
                        return;
                    }

                    var0.SetClip(var10, var3, var12 - var10, 400);
                }
                else if (var5 == 2)
                {
                    if (var8 <= 2)
                    {
                        var9 = 1;
                    }
                    else if (var8 <= 3)
                    {
                        var9 = 2;
                    }
                    else
                    {
                        var9 = 3;
                    }

                    int var13;
                    int var14 = (var13 = 1 + var2) + var8 * 15;
                    var0.SetClip(var13, var3, var14 - var13, 400);
                }

                if (var9 >= 0)
                {
                    MiamiNights.h.u[2].m_a(var0, var9, 0, var2, var3, 0, 0, 0);
                }
            }

            var0.SetClip(var2, var3, 76 * (var6 - var7[0]) / (var7[1] - var7[0]), 400);
            MiamiNights.h.u[2].m_a(var0, var4, 0, var2, var3, 0, 0, 0);
        }

        // original static void c(Graphics) — level-up / upgrade panel
        internal static void m_c(Graphics var0)
        {
            int var2 = 0;
            g var4 = MiamiNights.h.s[0];
            if (aZ == null)
            {
                aZ = new d[aW.Length];

                for (int var1 = 0; var1 < aZ.Length; var1++)
                {
                    aZ[var1] = new d(MiamiNights.h.u[1], 0, 0, null);
                }
            }

            if (MiamiNights.h.K == 0)
            {
                for (int var15 = 13; var15 < 32; var15++)
                {
                    var4.a[var15] = bo[var15 * 2 + 0];
                }
            }
            else
            {
                int var6 = (MiamiNights.h.K - 1) / 20;
                int var7 = MiamiNights.h.K - 1 - var6 * 20;

                for (int var16 = 0; var16 < aW.Length; var16++)
                {
                    string var8;
                    int var9;
                    if ((var8 = aW[var16]) != null && (var9 = int.Parse(var8.Substring(var8.IndexOf((char)35) + 1, var8.Length - (var8.IndexOf((char)35) + 1)))) != 35)
                    {
                        var0.SetClip(0, 0, 240, 400);
                        int var10 = 130 + var2 * 29;
                        MiamiNights.g.m_a(var0, 82, var10, 156, 30, 12875393, 16777215, 0);
                        sbyte var3;
                        if (var8[0] == '+')
                        {
                            aZ[var16].m_a(77);
                            var3 = 5;
                        }
                        else
                        {
                            aZ[var16].m_a(78);
                            var3 = 6;
                        }

                        MiamiNights.h.M.m_a(var0, var8.Substring(1, var8.IndexOf((char)35) - 1), 86, var10 + 2, 20, 0);
                        if (var2 == var6 && var7 < 20)
                        {
                            int var11 = bo[var9 * 2 + 0];
                            int var12;
                            int var13 = (var12 = bo[var9 * 2 + 1]) - var11;
                            int var14 = (var7 << 8) / 20;
                            if (var13 != 0)
                            {
                                var4.a[var9] = var11 + ((var12 - var11) * var14 >> 8);
                            }
                        }

                        m_a(var0, var9, 86, var10 + 17, var3);
                        var0.SetClip(0, 0, 240, 400);
                        var0.SetColor(16777215);
                        var0.FillRect(218, var10, 22, 29);
                        aZ[var16].a = 55808;
                        aZ[var16].b = var10 << 8;
                        aZ[var16].m_a(var0);
                        if (var2 == var6)
                        {
                            aZ[var16].m_b();
                        }
                        else
                        {
                            aZ[var16].g = 0;
                            aZ[var16].f = 0;
                        }

                        MiamiNights.h.M.m_a(var0, var4.a[var9].ToString(), 215, var10 + 7, 24, 0);
                        var2++;
                    }
                }
            }

            if (MiamiNights.h.K - 1 == var2 * 20 + 5)
            {
                for (int var17 = 13; var17 < 32; var17++)
                {
                    var4.a[var17] = bo[var17 * 2 + 1];
                }

                var4.a[35] = bo[71];
                if (av != -1)
                {
                    MiamiNights.h.z = 15;
                    return;
                }

                MiamiNights.g.m_p();
                if (var4.b[17] > 0 && MiamiNights.g.N.size() > 0 && ((string)MiamiNights.g.N.elementAt(0))[0] == '!')
                {
                    MiamiNights.h.z = 8;
                    return;
                }

                MiamiNights.h.y = 0;
                MiamiNights.h.k = true;
            }
        }

        // original static void n() — sort NPCs by distance
        internal static void m_n()
        {
            int[] var0 = new int[]{0, 0};
            al = -1;

            for (int var1 = 1; var1 < MiamiNights.h.s.Length; var1++)
            {
                if (MiamiNights.h.s[var1] != null && MiamiNights.h.s[var1].m_b())
                {
                    if (!NpcAi.Owned(var1))
                    {
                        MiamiNights.h.s[var1].m_o();   // AI-driven NPCs are moved by NpcAi this frame instead
                    }

                    var0[0] = MiamiNights.h.s[0].c[0] - MiamiNights.h.s[var1].c[0];
                    var0[0] = var0[0] * var0[0] >> 8;
                    var0[1] = MiamiNights.h.s[0].c[1] - MiamiNights.h.s[var1].c[1];
                    var0[1] = var0[1] * var0[1] >> 8;
                    MiamiNights.h.s[var1].t = var0[0] + var0[1];
                    if (MiamiNights.h.s[var1].y != null && (al == -1 || MiamiNights.h.s[var1].t < MiamiNights.h.s[al].t))
                    {
                        al = (sbyte)var1;
                    }
                }
            }

            ba = false;
        }

        // original static void o()
        internal static void m_o()
        {
            if (MiamiNights.g.m_l())
            {
                for (int var0 = 1; var0 < MiamiNights.h.s.Length; var0++)
                {
                    if (MiamiNights.h.s[var0] != null && MiamiNights.h.s[var0].m_b())
                    {
                        d var1;
                        (var1 = MiamiNights.h.n[MiamiNights.h.s[var0].b[5]]).m_b();
                        MiamiNights.h.s[var0].m_g();
                    }
                }
            }
        }

        // original static void p() — load schedule/anim tables
        internal static void m_p()
        {
            try
            {
                GloftMMN.m_b("/9");
                GloftMMN.m_h(0);
                @as = GloftMMN.m_g();
                at = new sbyte[@as * 11];
                GloftMMN.m_a(at);
                I = GloftMMN.m_j(1);
                bool var0 = false;
                an = GloftMMN.m_j(2);
                am = an[0] & 255;
                ao = new int[am];
                ap = new long[am];
                int var8 = 1;

                for (int var7 = 0; var7 < am; var7++)
                {
                    ao[var7] = var8;
                    int var4 = an[var8 + 6 + 0] & 255;
                    var8 += 7 + var4 * 2;
                    var4 = an[var8] & 255;
                    var8++;

                    for (int var1 = 0; var1 < var4; var1++)
                    {
                        int var5 = an[var8 + 2] & 255;
                        var8 += 3 + var5 * 2;
                    }
                }

                GloftMMN.m_f();
            }
            catch (Exception) { }
        }
    }
}
