// Port of original class h (MIDP Canvas / game loop / UI state machine) from validated decompile_vf/h.java.
// Line-by-line translation per PORTING.md. Renames applied:
//   R1 (field/method collisions in h): methods a b c d e f g h i j k l m n o p q r -> m_* (decls AND call sites).
//     [NOTE: contract list omitted `f`, but field f (line 18) + methods f()/f(int) collide -> CS0102 -> m_f applied.]
//   R5: static field h -> h_ (decl + every access; no qualified MiamiNights.h.* refs exist in source).
//   Java byte -> sbyte everywhere, (byte)x -> (sbyte)x, `& 255` kept verbatim; boolean -> bool.
//   MiamiNights.X.Y quals kept verbatim; MIDP API -> engine PascalCase.
using System;

namespace MiamiNights
{
    public sealed class h : Canvas
    {
        // implements Runnable: run() split into RunInit()/FrameStep driver per PORTING.md §5
        // (FrameStep not ported here - Game1 fixed-step drives Paint; run() while-loop/exit tail live in Game1)

        public static h Inst;                 // driver singleton (set by GloftMMN ctor, not here)

        // ---- original static fields (Java package -> internal) ----
        internal static sbyte[][] a;
        internal static sbyte[][][] b;
        internal static sbyte[] c;
        internal static int[] d = new int[] { 0, 25, -1, 1, 25, 35, -1, 1, 35, 40, -1, 2, 40, 100, -1, 2, 50, 100, 100, 2 };
        internal static sbyte[] e = new sbyte[252];
        internal static sbyte[] f = new sbyte[]{
           22, 16, 0, 0, 7, 2, 1, 3, 1, 0, 2, 5, -1, -1, -1, -1, -1, -1, -1, 0, 0, 4, 0, 6, 3, -1, -1, -1, -1, 18, 24,
           6, 0, 8, 16, 4, 4, 1, 2, 5, 2, 1, 7, 1, 7, 7, 7, 1, -1, 0, 1, 5, 6, 5, 7, 6, 4, 4, 4, -1, -1, -1, -1, -1
        };
        internal static short[] g;
        internal static int h_;                // R5: original static int h
        internal static int i;
        internal static bool j = false;
        internal static bool k;
        internal static bool l;
        internal static sbyte m = -1;
        internal static d[] n;
        internal static a[] o;
        internal static a[][] p;
        internal static sbyte[][] q;
        internal static sbyte[][] r;
        internal static g[] s;
        internal static d[] t;
        internal static a[] u;
        internal static d[] v;
        internal static sbyte w;
        internal static sbyte x;
        internal static sbyte y;
        internal static sbyte z;
        internal static sbyte A = -1;
        internal static sbyte B;
        internal static int C;
        internal static int D;
        internal static sbyte[] E = new sbyte[] { -1, -1, -1 };
        internal static int F = -1;
        internal static int G = -1;
        internal static int H = 0;
        internal static int I = -1;
        internal static bool J = true;
        internal static int K;
        internal static int L;
        internal static a M;
        internal static int[] N = new int[] { -1, -1, 1, 0, 0, 0, 0 };
        internal static bool O = false;
        internal static bool P = false;
        internal static Image Q;
        internal static int[] R = new int[16];
        internal static int[] S = new int[16];
        internal static string[] T = new string[16];
        internal static int[] U = new int[6];
        internal static int[] V = null;
        internal static int[] W = new int[] { 16754176, 16777215, 0, 16725317, 16741375, 37119, 61440, 16776960 };
        internal static int X;
        internal static bool Y;
        internal static bool Z;
        internal static bool aa;
        internal static int[] ab = new int[32];
        internal static int ac;
        internal static int[] ad = new int[64];
        internal static int[] ae = new int[2];
        internal static string af;
        internal static sbyte ag;
        internal static sbyte ah;
        internal static sbyte ai = 2;
        internal static bool aj;
        internal static int ak;
        internal static int al;
        internal static int am;
        internal static int[] an;
        internal static bool ao;
        internal static int ap = 0;
        internal static string[] aq = new string[] { "NONE", "TEXTS", "PLAYER ATTS", "FRIENDSHIP" };
        internal static sbyte[] ar = new sbyte[]{
           12, 11, 1, 18, 11, 1, 11, 10, 1, 11, 11, 1, 11, 9, 1, 11, 6, 5, 11, 7, 5, 11, 8, 4, 28, 9, 1, 28, 6, 5,
           28, 7, 5, 28, 8, 4, 30, 9, 1, 30, 10, 1, 30, 6, 5, 30, 7, 5, 30, 8, 4, 31, 9, 1, 31, 6, 5, 31, 7, 5,
           31, 8, 4, 6, 11, 1, 25, 1, 1, 25, 2, 1, 23, 3, 4, 23, 5, 4, 14, 4, 1, 14, 9, 1, 19, 4, 1
        };
        internal static bool @as;
        internal static bool at;
        internal static bool au;
        private static int bP;
        private static int bQ = 4;
        internal static readonly sbyte[] av = new sbyte[1];
        internal static sbyte[] aw = null;
        internal static sbyte ax = 0;
        internal static int ay = 0;
        internal static string[] az = new string[] { "ENGLISH", "FRANCAIS", "DEUTSCH", "ESPANOL", "ITALIANO", "PORTUGUES-BR", "POLSKA" };
        internal static int[] aA = new int[] { 0, 1, 2, 4, 3, 5 };
        internal static Graphics aB = null;
        private long bR;
        internal static sbyte[] aC;
        internal static sbyte[] aD;
        internal static bool aE = false;       // original static boolean aE (kept R-faithful/internal)
        internal static long aF;
        private bool bS = false;
        internal static long aG = 0L;
        internal static long aH = 0L;
        private static long bT = 0L;
        private static int bU = 216;
        private static int bV = 57;
        private static int bW = bV;
        private static int bX = 400 - bV;
        private static bool bY = true;
        private static bool bZ = true;
        public static bool aI = true;
        public static string aJ = "";
        internal static int[] aK;
        internal static int[] aL;
        internal static Image aM;
        internal static Graphics aN;
        internal static int aO;
        internal static bool aP;
        internal static bool aQ;
        internal static bool aR;
        internal static sbyte[] aS = new sbyte[1024];
        internal static int[] aT = new int[1024];
        internal static int[] aU = new int[1024];
        internal static int aV = 0;
        public static bool aW = false;
        public static bool aX = false;
        public static bool aY = false;
        internal static int[] aZ = new int[350];
        internal static int ba = 0;
        internal static int[] bb = new int[] { 0, 0 };
        internal static bool bc = false;
        internal static int[] bd = new int[] { 0, 0 };
        internal static bool be = false;
        internal static int[] bf = new int[] { 0, 0, 0, 0 };
        internal static bool bg = false;
        internal static int bh = -1;
        internal static int[] bi = new int[] { 0, 0 };
        internal static int[] bj = new int[] { 55, 57, 51, 49 };
        internal static int[] bk = new int[] { 52, 56, 54, 50 };
        internal static int bl;
        internal static sbyte[] bm;
        internal static sbyte[] bn;
        internal static int[] bo;
        internal static int bp;
        internal static int bq;
        internal static int[] br;
        internal static int bs;
        internal static int bt;
        internal static readonly int[] bu = new int[]{ 0, 0, 0, -107, 0, 107, -107, 0, 107, 0, -75, -75, -75, 75, 75, -75, 75, 75 };
        internal static readonly int[] bv = new int[]{ 0, -1, 0, 1, -1, 0, 1, 0, -1, -1, -1, 1, 1, -1, 1, 1 };
        internal static int bw;
        internal static int bx;
        internal static bool by = false;
        internal static int bz = -1;
        internal static int bA = -1;
        internal static int bB = -1;
        internal static int bC = -1;
        internal static int bD = -1;
        internal static int bE = -1;
        internal static int[] bF = new int[21];
        public static bool bG = false;
        public static Image bH;
        public static bool bI = false;
        public static long bJ = 3000L;
        public static long bK = 0L;
        public static long bL = 0L;
        internal static sbyte[] bM = new sbyte[]{ 67, 10, 16, 66, 47, 70, 2, 0, 69, -56, 19, 66, 47, -56, 2, 70 };
        internal static int[] bN = new int[]{
           41, 10, 71, 13, 64, 71, 80, 98, 130, 148, 160, 194, 201, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
           43, 10, 128, 9, 13, 64, 80, 85, 97, 101, 128, 136, 137, 146, 160, 192, 194, 195, 200, 201, -1, -1, -1,
           45, 10, 97, 9, 13, 64, 80, 97, 101, 136, 137, 146, 160, 192, 194, 195, 200, 201, -1, -1, -1, -1, -1,
           47, 10, 1, 1, 10, 12, 13, 64, 70, 71, 80, 82, 85, 98, 101, 132, 200, -1, -1, -1, -1, -1, -1,
           49, 10, 86, 10, 70, 81, 85, 86, 98, 101, 128, 136, 137, 147, 163, 194, 196, 197, 200, 201, -1, -1, -1,
           51, 10, 13, 13, 64, 80, 97, 101, 137, 146, 192, 194, 196, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
           53, 10, 13, 13, 64, 80, 97, 131, 136, 146, 160, 192, 194, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
           55, 10, 9, 9, 13, 64, 81, 96, 101, 131, 136, 137, 146, 160, 192, 194, 196, 201, -1, -1, -1, -1, -1,
           57, 10, 13, 13, 8, 64, 81, 98, 101, 136, 137, 147, 160, 192, 194, 196, 201, -1, -1, -1, -1, -1, -1,
           61, 10, 13, 4, 13, 64, 71, 81, 97, 101, 135, 136, 137, 145, 146, 193, 194, 196, 197, 201, -1, -1, -1,
           65, 10, 199, 12, 13, 64, 80, 97, 136, 137, 146, 160, 192, 194, 196, 199, 201, -1, -1, -1, -1, -1, -1,
           67, 10, 10, 10, 4, 13, 64, 71, 81, 82, 97, 147, 160, 192, 194, 196, 200, -1, -1, -1, -1, -1, -1,
           69, 10, 200, 1, 10, 64, 81, 82, 85, 98, 128, 136, 137, 146, 160, 194, 196, 197, 200, 201, -1, -1, -1
        };
        internal static int[] bO = new int[]{
           2, 0, 0, 13, 70, 80, 82, 86, 97, 100, 101, 136, 144, 145, 148, 162, 163, 192, 196, -1, -1, -1,
           6, 6, 5, 6, 10, 64, 70, 71, 80, 82, 98, 101, 148, 194, 201, -1, -1, -1, -1, -1, -1, -1,
           9, 81, 6, 9, 13, 81, 97, 100, 101, 148, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
           14, 100, 13, 98, 100, 148, 194, 197, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
           16, 66, 5, 9, 13, 66, 72, 80, 83, 97, 100, 101, 136, 144, 148, 160, 192, 194, 197, -1, -1, -1,
           19, 66, 5, 9, 13, 66, 72, 80, 83, 97, 100, 101, 136, 144, 148, 160, 192, 194, 197, -1, -1, -1,
           29, 132, 4, 13, 64, 81, 101, 132, 134, 136, 137, 148, 162, 194, 196, 197, -1, -1, -1, -1, -1, -1,
           30, 81, 4, 13, 64, 81, 101, 132, 134, 136, 137, 148, 162, 194, 196, 197, -1, -1, -1, -1, -1, -1,
           32, 136, 4, 9, 13, 64, 80, 97, 100, 136, 148, 160, 192, 194, 198, 201, -1, -1, -1, -1, -1, -1, -1,
           33, 101, 1, 13, 12, 12, 80, 97, 100, 101, 135, 136, 148, 162, 194, -1, -1, -1, -1, -1, -1, -1
        };

        // driver alias for aE
        public static bool HiddenByLoop { get => aE; set => aE = value; }

        // original static void a(int)
        internal static void m_a(int var0)
        {
            h_ = var0;
        }

        // original static void a(int,a[],int,boolean,boolean,int,boolean)
        internal static void m_a(int var0, a[] var1, int var2, bool var3, bool var4, int var5, bool var6)
        {
            sbyte[] var7 = GloftMMN.m_j(var0);
            var1[var2] = new a();
            var1[var2].m_a(var7, 0, var5, var6);
            if (var3)
            {
                var1[var2].m_a(0, 0, -1, -1, 0);
            }

            if (var3 && var4)
            {
                var1[var2].m_b();
            }

            if (var5 > 0)
            {
                var1[var2].l = var5;
            }
        }

        internal static bool TransActive; internal static int TransP, TransMode;

        // original private static boolean a(int,int)
        private static bool m_a(int var0, int var1)
        {
            aB.SetClip(0, 0, 240, 400);
            aB.SetColor(0);
            if (var0 > 500)
            {
                var0 = 500;
            }

            int var2 = (var0 << 8) / 500;
            TransActive = true; TransP = var2; TransMode = var1;   // widescreen: replicate the wipe across the window
            aB.FillRect(0, 0, 240 * var2 >> 8, 400);
            if (var1 == 0)
            {
                aB.FillRect(0, 0, 240 * var2 >> 8, 400);
            }
            else if (var1 == 1)
            {
                int var3 = 240 - (240 * var2 >> 8);
                aB.FillRect(240 - var3, 0, var3, 400);
            }

            return var0 >= 500;
        }

        // original private static void a(int,int,boolean)
        private static void m_a(int var0, int var1, bool var2)
        {
            if (var2)
            {
                var0++;
            }

            bP = 0;
            U[1] = var0;
            U[0] = var1;

            for (int var3 = 0; var3 < var0; var3++)
            {
                R[var3] = 226;
                S[var3] = -1;
                T[var3] = null;
            }

            if (var2)
            {
                R[var0 - 1] = 0;
                S[var0 - 1] = 21;
            }

            U[4] = -1;
            U[5] = -1;
        }

        // original private static void a(Graphics,int,int)
        private static void m_a(Graphics var0, int var1, int var2)
        {
            if (u[0] == null)
            {
                m_a(0, u, 0, false, false, 1, true);
            }

            int var3 = u[0].m_a(u[0].m_d(30, 7));
            int var4 = u[0].m_b(u[0].m_d(30, 7)) + 1;
            if (var1 == 796)
            {
                if (h_ != 16)
                {
                    var0.SetClip(0, 0, 240, 400);
                }

                if (!aW)
                {
                    u[0].m_a(var0, 30, 1, 0, 400 - var4, 0, 0, 0);
                }
                else
                {
                    u[0].m_a(var0, 30, 2, 0, 400 - var4, 0, 0, 0);
                }
            }

            if ((var1 == 901 || var1 == 849 || var1 == 848 || var1 == 401 || var1 == 875) && MiamiNights.g.ak == null)
            {
                if (!aW)
                {
                    u[0].m_a(var0, 30, 10, 0, 400 - var4, 0, 0, 0);
                }
                else
                {
                    u[0].m_a(var0, 30, 11, 0, 400 - var4, 0, 0, 0);
                }
            }

            if (var2 == 909)
            {
                if (!aX)
                {
                    u[0].m_a(var0, 30, 7, 240 - var3, 400 - var4, 0, 0, 0);
                }
                else
                {
                    u[0].m_a(var0, 30, 8, 240 - var3, 400 - var4, 0, 0, 0);
                }
            }

            if (var2 == 794 || var2 == 0)
            {
                if (y == 3)
                {
                    var0.SetClip(0, 0, 240, 400);
                }

                if (!aX)
                {
                    u[0].m_a(var0, 30, 4, 240 - var3 + 5, 400 - var4, 0, 0, 0);
                    return;
                }

                u[0].m_a(var0, 30, 5, 240 - var3 + 5, 400 - var4, 0, 0, 0);
            }
        }

        // original private static void a(Graphics,boolean,boolean)
        private static void m_a(Graphics var0, bool var1, bool var2)
        {
            var0.SetClip(0, 0, 240, 400);
            int var4 = 0;

            for (int var3 = 0; var3 < U[1]; var3++)
            {
                if (R[var3] >= 0)
                {
                    string var5 = GloftMMN.m_k(R[var3]);
                    if (T[var3] != null)
                    {
                        var5 = var5 + T[var3];
                    }

                    M.m_a(var5);
                    if (MiamiNights.a.y > var4)
                    {
                        var4 = MiamiNights.a.y;
                    }
                }
            }

            if (!var1)
            {
                M.m_a(GloftMMN.m_k(U[3]));
                if (MiamiNights.a.y > var4)
                {
                    var4 = MiamiNights.a.y;
                }
            }

            M.m_a(GloftMMN.m_k(U[2]));
            if (MiamiNights.a.y > var4)
            {
                var4 = MiamiNights.a.y;
            }

            bool var17 = false;
            int var6;
            if (bQ > U[1])
            {
                var6 = U[1] * 45;
            }
            else
            {
                var6 = bQ * 45;
            }

            if (bQ < U[1])
            {
                var6 += 10;
            }

            int var7 = var6 + 18 + 18 + 1;
            var4 += 52;
            int var8 = (240 - var4) / 2;
            int var9 = (400 - var7) / 2;
            if (var2)
            {
                d var10;
                int[] var11;
                var9 = (var11 = (var10 = v[7]).m_c(10))[1];
                var8 = var11[0] - var4 + 2;
            }

            var4 -= 2;
            if (!var1)
            {
                if (bQ < U[1])
                {
                    var9 += 5;
                }

                var0.SetColor(16768665);
                if (K % 8 < 6)
                {
                    var0.SetColor(16775323);
                }

                if (m_a(20, var9 + 18 + 18 + (U[0] - bP) * 45 + -12 - 6, 200, 40))
                {
                    u[0].m_a(var0, 28, 2, 120, var9 + 18 + 18 + (U[0] - bP) * 46 + -12, 0, 0, 0);
                }
                else
                {
                    u[0].m_a(var0, 28, 0, 120, var9 + 18 + 18 + (U[0] - bP) * 46 + -12, 0, 0, 0);
                }

                m_b();
                bool var18 = false;
                if (m_a(var8 + var4 / 2 - 30, var9 - 22, 60, 30, true))
                {
                    u[0].m_a(var0, 29, 2, 120, var9 - 22, 0, 0, 0);
                    if (U[0] > 0)
                    {
                        U[0]--;
                        bP = bP - (U[0] >= bP ? 0 : 1);
                    }
                    else
                    {
                        U[0] = U[1] - 1;
                        bP = U[1] - bQ;
                        if (bP < 0)
                        {
                            bP = 0;
                        }
                    }
                }
                else
                {
                    u[0].m_a(var0, 29, 1, 120, var9 - 22, 0, 0, 0);
                }

                if (m_a(var8 + var4 / 2 - 30, var9 + var7 + 22 - 30, 60, 30, true))
                {
                    u[0].m_a(var0, 29, 2, 120, var9 + var7 + 22, 2, 0, 0);
                    if (U[0] < U[1] - 1)
                    {
                        U[0]++;
                        bP = bP + (U[0] >= bP + bQ ? 1 : 0);
                    }
                    else
                    {
                        U[0] = 0;
                        bP = 0;
                    }
                }
                else
                {
                    u[0].m_a(var0, 29, 1, 120, var9 + var7 + 22, 2, 0, 0);
                }

                int var19;
                if ((var19 = bP + bQ) > U[1])
                {
                    var19 = U[1];
                }

                for (int var14 = bP; var14 < var19; var14++)
                {
                    int var12 = var9 + 18 + 18 + (var14 - bP) * 45 + 5;
                    string var13 = GloftMMN.m_k(R[var14]);
                    if (T[var14] != null)
                    {
                        var13 = var13 + T[var14];
                    }

                    if (var14 != U[0])
                    {
                        u[0].m_a(var0, 28, 1, 120, var9 + 18 + 18 + (var14 - bP) * 46 + -12, 0, 0, 0);
                    }

                    M.m_a(var0, var13, 120, var12 + 1, 3, 1);
                    m_a(20, var12 + 1 - 20, 200, 45, 0, 0, 9, var14, 8, var14);
                    if (S[var14] != -1 && (S[var14] != 26 || aG % 4L < 2L))
                    {
                        u[1].m_a(var0, S[var14], 0, 22, var12 + -7 - 2, 0, 0, 0);
                    }
                }

                if (h_ == 8 && (y == 32 || y == 73))
                {
                    var0.SetColor(0);
                    var0.FillRect(0, 340, 240, 60);
                }
            }
        }

        // original private static void a(boolean)
        private static void m_a(bool var0)
        {
            if (var0 && aP && U[4] == -1)
            {
                z = (sbyte)U[5];
            }

            if (aC[1] < 0)
            {
                if (U[0] > 0)
                {
                    U[0]--;
                    bP = bP - (U[0] >= bP ? 0 : 1);
                }
                else
                {
                    U[0] = U[1] - 1;
                    bP = U[1] - bQ;
                    if (bP < 0)
                    {
                        bP = 0;
                    }
                }
            }

            if (aC[2] < 0)
            {
                if (U[0] < U[1] - 1)
                {
                    U[0]++;
                    bP = bP + (U[0] >= bP + bQ ? 1 : 0);
                    return;
                }

                U[0] = 0;
                bP = 0;
            }
        }

        // original private static void a(short,byte[],int)
        private static void m_a(short var0, sbyte[] var1, int var2)
        {
            var1[var2] = (sbyte)(var0 >>> 8);
            var1[var2 + 1] = (sbyte)(var0 & 255);
        }

        // original private static void a(int,byte[],int)
        private static void m_a(int var0, sbyte[] var1, int var2)
        {
            var1[var2] = (sbyte)(var0 >>> 24);
            var1[var2 + 1] = (sbyte)(var0 >>> 16);
            var1[var2 + 2] = (sbyte)(var0 >>> 8);
            var1[var2 + 3] = (sbyte)(var0 & 0xFF);
        }

        // original static int a(byte[],int)
        internal static int m_a(sbyte[] var0, int var1)
        {
            return (var0[var1] & 0xFF) << 24 | (var0[var1 + 1] & 0xFF) << 16 | (var0[var1 + 2] & 0xFF) << 8 | var0[var1 + 3] & 0xFF;
        }

        // original private static void a(long,byte[],int)
        private static void m_a(long var0, sbyte[] var2, int var3)
        {
            var2[var3] = (sbyte)(var0 >>> 56);
            var2[var3 + 1] = (sbyte)(var0 >>> 48);
            var2[var3 + 2] = (sbyte)(var0 >>> 40);
            var2[var3 + 3] = (sbyte)(var0 >>> 32);
            var2[var3 + 4] = (sbyte)(var0 >>> 24);
            var2[var3 + 5] = (sbyte)(var0 >>> 16);
            var2[var3 + 6] = (sbyte)(var0 >>> 8);
            var2[var3 + 7] = (sbyte)(var0 & 255L);
        }

        // original static long b(byte[],int)
        internal static long m_b(sbyte[] var0, int var1)
        {
            return (long)(var0[var1 + 0] & 255) << 56
               | (long)(var0[var1 + 1] & 255) << 48
               | (long)(var0[var1 + 2] & 255) << 40
               | (long)(var0[var1 + 3] & 255) << 32
               | (long)(var0[var1 + 4] & 255) << 24
               | (long)(var0[var1 + 5] & 255) << 16
               | (long)(var0[var1 + 6] & 255) << 8
               | var0[var1 + 7] & 255;
        }

        // original private static boolean a(boolean,boolean) - IGP info record
        private static bool m_a(bool var0, bool var1)
        {
            RecordStore var3 = null;
            RecordEnumeration var4 = null;

            bool var7 = false; // C# definite-assignment; Java flow only reaches `return var7` after `var7 = true`
            try
            {
                var4 = (var3 = RecordStore.OpenRecordStore("Miami Nights" + 1, true)).EnumerateRecords(null, null, false);
                if (!var1 && var0)
                {
                    av[0] = ag;
                    if (var4.HasNextElement())
                    {
                        int var24 = var4.NextRecordId();
                        var3.SetRecord(var24, Helpers.ToB(av), 0, av.Length);
                    }
                    else
                    {
                        var3.AddRecord(Helpers.ToB(av), 0, av.Length);
                    }

                    return true;
                }

                try
                {
                    int var5 = var4.NextRecordId();
                    sbyte[] var25;
                    if ((var25 = Helpers.ToS(var3.GetRecord(var5))).Length < 1)
                    {
                        var7 = false;
                        return false;
                    }

                    Array.Copy(var25, 0, av, 0, var25.Length);
                    ag = av[0];
                    ax = 0;
                    if (ag > 1)
                    {
                        ax = 1;
                    }

                    if (ag == 2)
                    {
                        ag = 0;
                    }

                    Console.WriteLine("IGP info :: " + ag + " s_vibrateEnable::" + ax);
                    if (!var1)
                    {
                        return true;
                    }

                    var7 = true;
                }
                catch (InvalidRecordIDException)
                {
                    var4.Reset();
                    bool var6 = false;
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (var4 != null)
                {
                    var4.Destroy();
                }

                if (var3 != null)
                {
                    try
                    {
                        var3.CloseRecordStore();
                    }
                    catch (RecordStoreException)
                    {
                    }
                }

                GC.Collect();
            }

            return var7;
        }

        // original private static boolean a(boolean,boolean,boolean) - save/load game record
        private static bool m_a(bool var0, bool var1, bool var2)
        {
            RecordStore var5 = null;
            RecordEnumeration var6 = null;

            try
            {
                if (aw == null)
                {
                    aw = new sbyte[3982];
                }

                var6 = (var5 = RecordStore.OpenRecordStore("Miami Nights" + 0, true)).EnumerateRecords(null, null, false);
                if (var1 || !var0)
                {
                    try
                    {
                        int var46 = var6.NextRecordId();
                        sbyte[] var48;
                        if ((var48 = Helpers.ToS(var5.GetRecord(var46))).Length < 3982)
                        {
                            return false;
                        }
                        else
                        {
                            Array.Copy(var48, 0, aw, 0, var48.Length);
                            if (var1)
                            {
                                return true;
                            }
                            else
                            {
                                ax = aw[0];
                                ai = aw[1];
                                if (var2)
                                {
                                    return true;
                                }
                                else
                                {
                                    H = aw[61];
                                    MiamiNights.f.ah = true;
                                    return true;
                                }
                            }
                        }
                    }
                    catch (InvalidRecordIDException)
                    {
                        var6.Reset();
                        bool var47 = false;
                        return false;
                    }
                }
                else
                {
                    g var7 = s[0];
                    aw[0] = ax;
                    aw[1] = ai;

                    for (int var3 = 0; var3 < MiamiNights.g.D; var3++)
                    {
                        aw[2 + var3] = (sbyte)var7.a[var3];
                    }

                    m_a(var7.c[0], aw, 49);
                    m_a(var7.c[1], aw, 53);
                    m_a(var7.a[35], aw, 57);
                    aw[61] = (sbyte)H;
                    m_a(MiamiNights.f.aT, aw, 62);

                    for (int var30 = 0; var30 < 32; var30++)
                    {
                        aw[70 + var30] = MiamiNights.f.bc[var30];
                    }

                    for (int var31 = 0; var31 < 16; var31++)
                    {
                        aw[102 + var31] = MiamiNights.f.bb[var31];
                    }

                    for (int var32 = 0; var32 < 39; var32++)
                    {
                        aw[118 + var32] = MiamiNights.g.ah[var32];
                        aw[157 + var32] = MiamiNights.g.f[var32];
                    }

                    for (int var33 = 0; var33 < 39; var33++)
                    {
                        aw[196 + var33] = (sbyte)(MiamiNights.g.ai[var33] ? 1 : 0);
                    }

                    for (int var34 = 0; var34 < 16; var34++)
                    {
                        m_a(MiamiNights.g.ag[var34], aw, 235 + var34 * 8);
                    }

                    for (int var35 = 0; var35 < 46; var35++)
                    {
                        m_a((short)MiamiNights.g.q[var35], aw, 363 + var35 * 2);
                    }

                    for (int var36 = 0; var36 < var7.an.Length; var36++)
                    {
                        aw[455 + var36] = var7.an[var36];
                    }

                    for (int var37 = 0; var37 < 64; var37++)
                    {
                        if (var37 < MiamiNights.f.ap.Length)
                        {
                            m_a(MiamiNights.f.ap[var37], aw, 495 + var37 * 8);
                        }
                    }

                    for (int var38 = 0; var38 < 25; var38++)
                    {
                        aw[1007 + var38] = (sbyte)MiamiNights.g.G[var38];
                    }

                    for (int var39 = 0; var39 < 168; var39++)
                    {
                        aw[1032 + var39] = (sbyte)MiamiNights.g.I[var39];
                    }

                    m_a(MiamiNights.g.ae, aw, 1200);

                    for (int var40 = 0; var40 < 200; var40++)
                    {
                        if (var40 < MiamiNights.g.ad.Length)
                        {
                            aw[1204 + var40] = (sbyte)MiamiNights.g.ad[var40];
                        }
                        else
                        {
                            aw[1204 + var40] = 0;
                        }
                    }

                    aw[1404] = MiamiNights.g.aa;

                    for (int var41 = 0; var41 < 252; var41++)
                    {
                        aw[1405 + var41] = e[var41];
                    }

                    for (int var42 = 0; var42 < 64; var42++)
                    {
                        aw[1657 + var42] = f[var42];
                    }

                    for (int var43 = 0; var43 < 16; var43++)
                    {
                        aw[1721 + var43] = bM[var43];
                    }

                    for (int var44 = 0; var44 < 10; var44++)
                    {
                        if (var44 < af.Length)
                        {
                            aw[1737 + var44] = (sbyte)af[var44];
                        }
                        else
                        {
                            aw[1737 + var44] = -127;
                        }
                    }

                    int var8 = 0;

                    for (int var45 = 1; var45 < s.Length; var45++)
                    {
                        g var9 = s[var45];
                        int var10 = 1747 + var8 * 89;
                        if (var9 != null && var9.e != null)
                        {
                            if (var8 >= 25)
                            {
                                return false;
                            }

                            aw[var10 + 0] = (sbyte)var45;
                            if (var9.k != null)
                            {
                                for (int var11 = 0; var11 < 6; var11++)
                                {
                                    if (var11 < var9.k.Length)
                                    {
                                        aw[var10 + 1 + var11] = var9.k[var11];
                                    }
                                }
                            }

                            if (var9.l != null)
                            {
                                for (int var53 = 0; var53 < 6; var53++)
                                {
                                    if (var53 < var9.l.Length)
                                    {
                                        aw[var10 + 7 + var53] = var9.l[var53];
                                    }
                                }
                            }

                            if (var9.m != null)
                            {
                                for (int var54 = 0; var54 < 6; var54++)
                                {
                                    if (var54 < var9.m.Length)
                                    {
                                        aw[var10 + 13 + var54] = var9.m[var54];
                                    }
                                }
                            }

                            for (int var55 = 0; var55 < 46; var55++)
                            {
                                aw[var10 + 19 + var55] = (sbyte)var9.a[var55];
                                if (var55 == 1)
                                {
                                    aw[var10 + 19 + var55] = (sbyte)(aw[var10 + 19 + var55] - 402);
                                }
                            }

                            for (int var56 = 0; var56 < 21; var56++)
                            {
                                aw[var10 + 65 + var56] = var9.b[var56];
                            }

                            for (int var57 = 0; var57 < 3; var57++)
                            {
                                aw[var10 + 86 + var57] = var9.e[var57];
                            }

                            var8++;
                        }
                    }

                    if (var6.HasNextElement())
                    {
                        int var49 = var6.NextRecordId();
                        var5.SetRecord(var49, Helpers.ToB(aw), 0, aw.Length);
                    }
                    else
                    {
                        var5.AddRecord(Helpers.ToB(aw), 0, aw.Length);
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (var6 != null)
                {
                    var6.Destroy();
                }

                if (var5 != null)
                {
                    try
                    {
                        var5.CloseRecordStore();
                    }
                    catch (RecordStoreException)
                    {
                    }
                }

                GC.Collect();
            }
        }

        // original private static void a(Graphics) - pause/options menu
        private static void m_a(Graphics var0)
        {
            int var1 = u[0].m_b(u[0].m_d(28, 1)) / 2 - 5;
            m_b();
            m_a(20, 224 - var1, 200, 40, 6, 0, 3, 0, 6, 0);
            m_a(20, 269 - var1, 200, 40, 7, 0, 3, 0, 7, 0);
            if (aC[3] < 0)
            {
                i = 1;
            }

            if (aC[4] < 0)
            {
                i = 0;
            }

            if (h_ == 16)
            {
                var0.SetColor(0);
                var0.FillRect(0, 318, 240, 82);
            }

            MiamiNights.g.m_a(var0, 3, 151, 233, 163, 16777215, 0, 0);
            var0.SetColor(296700);
            var0.FillRect(4, 152, 231, 18);
            var0.SetColor(16777215);
            if (l)
            {
                i = 0;
            }

            if (i == 1)
            {
                var0.SetColor(296700);
            }

            if (i == 0)
            {
                var0.SetColor(296700);
            }
            else
            {
                var0.SetColor(16777215);
            }

            var0.SetColor(0);
            var0.FillRect(3, 170, 233, 1);
            short var2 = 835;
            short var3 = 276;
            short var4 = 275;
            if (6 == h_)
            {
                var2 = 46;
                var3 = 16;
                var4 = 17;
            }

            M.m_a(var0, GloftMMN.m_k(var2), 120, 152, 17, 0);
            if (MiamiNights.g.ak != null)
            {
                string var5 = MiamiNights.g.m_b(MiamiNights.g.ak, 213);
                M.m_a(var0, var5, 120, 171, 17, 1);
            }

            M.m_a(GloftMMN.m_k(var3));
            int var8 = MiamiNights.a.y;
            M.m_a(GloftMMN.m_k(var4));
            int var6 = MiamiNights.a.y;
            if (i == 1)
            {
                if (m_a(20, 224 - var1, 200, 40))
                {
                    u[0].m_a(var0, 28, 2, 120, 224 - var1, 0, 0, 0);
                }
                else
                {
                    u[0].m_a(var0, 28, 0, 120, 224 - var1, 0, 0, 0);
                }

                u[0].m_a(var0, 28, 1, 120, 269 - var1, 0, 0, 0);
            }
            else if (i == 0)
            {
                u[0].m_a(var0, 28, 1, 120, 224 - var1, 0, 0, 0);
                if (m_a(20, 269 - var1, 200, 40))
                {
                    u[0].m_a(var0, 28, 2, 120, 269 - var1, 0, 0, 0);
                }
                else
                {
                    u[0].m_a(var0, 28, 0, 120, 269 - var1, 0, 0, 0);
                }
            }

            M.m_a(var0, GloftMMN.m_k(var3), 240 - var8 >> 1, 224, 20, 1);
            M.m_a(var0, GloftMMN.m_k(var4), 240 - var6 >> 1, 269, 20, 1);
            if (aP && 6 != h_)
            {
                MiamiNights.g.m_a(MiamiNights.g.al & 255, i == 1);
                MiamiNights.g.ak = null;
            }

            if (h_ != 6)
            {
                var0.SetColor(0);
                var0.FillRect(0, 340, 240, 60);
            }
        }

        // ---- original private void e(): master state machine (UI screen dispatcher) ----
        private void m_e()
        {
            aB.Translate(0, 0);
            switch (h_)
            {
                case 0:
                    m_a(100);
                    return;
                case 3:
                    aB.SetColor(0);
                    aB.FillRect(0, 0, 240, 400);
                    M.m_a(aB, GloftMMN.m_k(0), 120, 200, 3, 0);
                    M.m_a(aB, GloftMMN.m_k(17), 237, 398, 40, 0);
                    M.m_a(aB, GloftMMN.m_k(16), 3, 398, 36, 0);
                    if (aC[13] < 0)
                    {
                        GloftMMN.f = false;
                        m_a(5);
                        i = 0;
                    }

                    if (aC[14] < 0)
                    {
                        Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        GloftMMN.f = true;
                        m_a(5);
                        i = 0;
                        return;
                    }
                    break;
                case 4:
                    if (k)
                    {
                        i = 0;
                    }

                    switch (i)
                    {
                        case 0:
                            s = null;
                            o = null;
                            n = null;
                            p = (a[][])null;
                            u = null;
                            M = null;
                            t = null;
                            MiamiNights.g.T = null;
                            MiamiNights.g.S = null;
                            MiamiNights.g.U = new Image[4];
                            MiamiNights.g.Z = null;
                            GloftMMN.m_a("STARTING GAME INIT");
                            MiamiNights.g.C = 10;
                            GloftMMN.m_a("AFTER LOADING CHARACTER CLASS");
                            MiamiNights.f.a = -1;
                            GloftMMN.m_a("AFTER LOADING LEVEL CLASS");
                            o = new a[2];
                            GloftMMN.m_a("AFTER LOADING ASPRITE CLASS");
                            n = new d[2];
                            n = null;
                            GloftMMN.m_a("AFTER LOADING ASPRITE INSTANCE CLASS");
                            aB.SetColor(16777215);
                            aB.FillRect(0, 0, 240, 400);
                            GloftMMN.m_b("/0");
                            sbyte[] var53;
                            Q = Image.CreateImage(var53 = GloftMMN.m_j(0), 0, var53.Length);
                            if (!Z)
                            {
                                aB.DrawImage(Q, 120, 200, 3);
                            }
                            break;
                        case 1:
                            MiamiNights.f.a = -1;
                            K = 0;

                            for (int var59 = 0; var59 < N.Length; var59++)
                            {
                                N[var59] = 0;
                            }
                            break;
                        case 2:
                            sbyte[] var52;
                            Q = Image.CreateImage(var52 = GloftMMN.m_j(1), 0, var52.Length);
                            GloftMMN.m_a("AFTER LOADING SPLASH");
                            GloftMMN.m_a("AFTER LOADING IFACE DATA");
                            break;
                        case 3:
                            MiamiNights.f.m_b(true);
                            break;
                        case 4:
                            MiamiNights.f.m_a();
                            GloftMMN.m_a("AFTER LOADING FONT");
                            GloftMMN.m_a("/3", 1);
                            GloftMMN.m_f();
                            GloftMMN.m_a("AFTER LOADING TEXTS MENU");
                            GloftMMN.m_b("/20");
                            GloftMMN.m_a("AFTER OPENING PACK ARRAYS");
                            MiamiNights.g.f = GloftMMN.m_f(0);
                            GloftMMN.m_a("AFTER m_bScenesMapVisibility");
                            a = GloftMMN.m_g(1);
                            GloftMMN.m_a("AFTER armBodyCombinations");
                            b = new sbyte[2][][];
                            b[0] = GloftMMN.m_g(2);
                            b[1] = GloftMMN.m_g(3);
                            b[1] = GloftMMN.m_g(3);
                            GloftMMN.m_a("AFTER clothesPrice");
                            c = GloftMMN.m_f(4);
                            GloftMMN.m_a("AFTER m_bShopAnimList");
                            g = GloftMMN.m_e(5);
                            GloftMMN.m_a("AFTER m_sBuyableObjectsInfo");
                            GloftMMN.m_f();
                            GloftMMN.m_a("AFTER COLOSING PACK ARRAYS");
                            MiamiNights.g.j = new sbyte[2];
                            break;
                        case 5:
                            GloftMMN.m_a();
                            GloftMMN.m_b("/18");
                            GloftMMN.m_a(0);
                            GloftMMN.m_a(1);
                            GloftMMN.m_a(2);
                            GloftMMN.m_a(3);
                            GloftMMN.m_a(4);
                            GloftMMN.m_f();
                            GloftMMN.m_a("AFTER INITIAL SOUNDS");
                            i = -1;
                            if (ay < 0)
                            {
                                // PORT-QUESTION: original System.getProperty("microedition.locale"); engine has no system
                                // properties -> Midp.AppProperty (manifest) with "" fallback -> falls through to ay = 0 (ENGLISH)
                                string var57;
                                if ((var57 = (Midp.AppProperty("microedition.locale") ?? "").ToLowerInvariant()).StartsWith("en"))
                                {
                                    ay = 0;
                                }
                                else if (var57.StartsWith("fr"))
                                {
                                    ay = 1;
                                }
                                else if (var57.StartsWith("de"))
                                {
                                    ay = 2;
                                }
                                else if (var57.StartsWith("it"))
                                {
                                    ay = 3;
                                }
                                else if (var57.StartsWith("es"))
                                {
                                    ay = 4;
                                }
                                else if (var57.StartsWith("pt"))
                                {
                                    ay = 0;
                                }
                                else if (var57.StartsWith("pl"))
                                {
                                    ay = 5;
                                }
                                else
                                {
                                    ay = 0;
                                }
                            }
                            else
                            {
                                GloftMMN.m_b("/19");
                                GloftMMN.m_a(20);
                                GloftMMN.m_f();
                                GloftMMN.m_c(5);
                                m_a(5);
                            }

                            long var58 = MiaNow.Ms();

                            while (MiaNow.Ms() - var58 < 2000L)
                            {
                            }

                            if (Z)
                            {
                                m_a(6);
                                Z = false;
                            }
                            break;
                    }

                    if (Z)
                    {
                        aB.SetClip(0, 0, 240, 400);
                        aB.SetColor(0);
                        aB.FillRect(0, 0, 240, 400);
                        aB.SetClip(0, 0, 231 * i / 4, 400);
                        aB.SetColor(16711680);
                        aB.FillRect(7, 316, 240, 3);
                    }

                    i++;
                    return;
                case 5:
                    if (i == 0)
                    {
                        GloftMMN.m_b("/19");
                        GloftMMN.m_a(20);
                        GloftMMN.m_f();
                        GloftMMN.m_c(5);
                        i = 1;
                    }

                    aB.DrawImage(Q, 120, 200, 3);
                    if (aG % 4L < 2L)
                    {
                        M.m_a(aB, GloftMMN.m_k(2), 121, 351, 3, 1);
                        M.m_a(aB, GloftMMN.m_k(2), 120, 350, 3, 0);
                    }

                    if (aP)
                    {
                        bB = -1;
                        bC = -1;
                        i = -1;
                        m_a(6);
                    }

                    m_b();
                    m_b(0, 0, 240, 400, 9, 0);
                    if (bZ && GloftMMN.f)
                    {
                        aB.SetClip(0, 0, 240, 400);
                        aB.ClipRect(0, 0, 240, 400);
                        if (bY)
                        {
                            bW--;
                            if (bW < 2)
                            {
                                bY = false;
                            }
                        }
                        else
                        {
                            bW++;
                            if (bW > bV)
                            {
                                bZ = false;
                            }
                        }

                        aB.SetColor(255, 255, 255);
                        m_fillRoundRect(aB, 2, bX + 1 + bW, bU - 2, bV + bW - 2, 2, 2);   // original aB.fillRoundRect
                        aB.SetColor(16758678);
                        m_fillRoundRect(aB, 3, bX + 2 + bW, bU - 4, bV + bW - 4, 2, 2);   // original aB.fillRoundRect
                        M.m_a(aB, GloftMMN.m_k(60), 65, bX + 4 + bW, 5, 1);
                        M.m_a(aB, GloftMMN.m_k(61), 70, bX + 4 + 15 + bW, 5, 1);
                        M.m_a(aB, GloftMMN.m_k(62), 93, bX + 4 + 30 + bW, 5, 1);
                        return;
                    }
                    break;
                case 6:
                    if (k)
                    {
                        i = -1;
                    }

                    if (MiamiNights.g.ak != null)
                    {
                        if (k)
                        {
                            aB.DrawImage(Q, 120, 200, 3);
                            m_a(aB, false, false);
                        }

                        m_a(aB);
                        if (aP)
                        {
                            if (i == 0)
                            {
                                MiamiNights.g.ak = null;
                                i = -1;
                                return;
                            }

                            if (i == 1)
                            {
                                Console.WriteLine("[QUIT-SITE-1 menu] i=" + i + " aP=" + aP + " y=" + y + " z=" + z + " j=" + j + " Y=" + Y);
                                h_ = -1;
                                return;
                            }
                        }

                        return;
                    }

                    if (i == -1)
                    {
                        aB.DrawImage(Q, 120, 200, 3);
                        bool var49;
                        if (aw == null)
                        {
                            var49 = m_a(false, true, true);
                        }
                        else
                        {
                            var49 = m_a(false, true, false);
                        }

                        i = 7;
                        if (!var49)
                        {
                            i--;
                        }

                        if (!MiamiNights.c.m_a())
                        {
                            i--;
                        }

                        m_a(i, 0, false);
                        bool var56 = m_a(false, true);
                        int var60 = 0;

                        for (int var4 = 5; var4 <= 13; var4++)
                        {
                            if (var4 != 8 && var4 != 9 && (var49 && var4 == 6 || var4 >= 10 || var4 == 5 || var4 == 7 && MiamiNights.c.m_a()) && (var4 != 8 || MiamiNights.c.m_a()))
                            {
                                R[var60] = var4;
                                if (var4 == 7 && (!var56 || ag == 0))
                                {
                                    S[var60] = 26;
                                }

                                var60++;
                            }
                        }

                        U[2] = 14;
                        U[3] = 15;
                        U[5] = -1;
                        i = 0;
                    }

                    m_a(false);
                    m_a(aB, false, false);
                    if (aP)
                    {
                        int var50 = U[0];
                        if ((MiamiNights.c.m_a() && U[1] == 6 || !MiamiNights.c.m_a() && U[1] == 5) && var50 > 0)
                        {
                            var50++;
                        }

                        if (!MiamiNights.c.m_a() && var50 > 1)
                        {
                            var50++;
                        }

                        switch (var50)
                        {
                            case 0:
                                GloftMMN.m_b();
                                m_a(7);
                                GloftMMN.m_b(5);
                                break;
                            case 1:
                                MiamiNights.f.ah = true;
                                GloftMMN.m_b();
                                m_a(7);
                                GloftMMN.m_b(5);
                                break;
                            case 2:
                                if (ax == 0)
                                {
                                    ag = 1;
                                }
                                else
                                {
                                    ag = 3;
                                }

                                m_a(true, false);
                                i = 0;
                                y = 69;
                                m_a(24);
                                break;
                            case 3:
                                m_d(31, 1);
                                m_a(19);
                                break;
                            case 4:
                                m_a(22);
                                i = -1;
                                break;
                            case 5:
                                m_a(21);
                                i = -1;
                                break;
                            case 6:
                                MiamiNights.g.m_a(GloftMMN.m_k(45), (sbyte)40);
                                break;
                        }
                    }

                    if (!ao)
                    {
                        if (aC[ap] < 0)
                        {
                            switch (ap)
                            {
                                case 6:
                                    ap = 7;
                                    break;
                                case 7:
                                    ap = 9;
                                    break;
                                case 8:
                                    ap = 10;
                                    break;
                                case 9:
                                    ap = 8;
                                    break;
                                case 10:
                                    ap = 6;
                                    ao = true;
                                    break;
                            }

                            return;
                        }

                        for (int var51 = 0; var51 < aC.Length; var51++)
                        {
                            if (aC[var51] < 0)
                            {
                                ap = 6;
                                return;
                            }
                        }
                    }
                    break;
                case 7:
                    if (k)
                    {
                        aB.SetClip(0, 0, 240, 400);
                        aB.SetColor(0);
                        aB.FillRect(0, 0, 240, 400);
                    }

                    try
                    {
                        aB.SetClip(0, 0, 240, 400);
                        if (i == 0)
                        {
                            X = 1;
                            GloftMMN.m_a("GAME_INIT START");
                            aB.SetClip(0, 0, 240, 800);
                            aB.SetColor(0);
                            aB.FillRect(0, 0, 240, 800);
                        }

                        if (i == 1)
                        {
                            GloftMMN.m_a("/3", 0);
                            GloftMMN.m_a("GAME_INIT TEXTS GAME");
                            MiamiNights.g.m_a(GloftMMN.m_k(!MiamiNights.f.ah ? 752 : 753), 2);
                            if (MiamiNights.f.ah)
                            {
                                MiamiNights.g.ae &= -257;
                            }

                            GloftMMN.m_b("/1");
                            sbyte[] var106 = GloftMMN.m_j(1);
                            GloftMMN.m_f();
                            Q = Image.CreateImage(var106, 0, var106.Length);
                            GloftMMN.m_a("GAME_INIT LOADING IMG");
                            d var88;
                            (var88 = v[7]).a = 30720;
                            var88.b = 51200;
                            var88.m_a(47);
                            var88.m_a(aB);
                        }

                        if (i == 2)
                        {
                            MiamiNights.f.n = 0;
                            n = new d[28];
                            t = new d[1];
                            s = new g[28];
                            GloftMMN.m_a("GAME_INIT MISC ARRAYS");
                        }

                        if (i == 3)
                        {
                            GloftMMN.l = new JavaRandom(MiaNow.Ms());   // original new Random(System.currentTimeMillis())
                            GloftMMN.m_a("GAME_INIT RANDOM");
                        }

                        if (i == 4)
                        {
                            MiamiNights.f.n = 284;
                            MiamiNights.f.o = 284;
                            GloftMMN.m_a("GAME_INIT BB");
                        }

                        if (i == 5)
                        {
                            GloftMMN.m_a("GAME_INIT BEFORE SCRIPTING");
                            MiamiNights.g.m_d();
                            GloftMMN.m_a("GAME_INIT (SCRIPTING) AFTER ATTRIBUTES");
                            MiamiNights.f.m_f();
                            GloftMMN.m_a("GAME_INIT (SCRIPTING) AFTER NPC ACTIONS");
                            MiamiNights.f.m_h();
                            GloftMMN.m_a("GAME_INIT (SCRIPTING) AFTER NPC TEMPLATES");
                            MiamiNights.f.m_g();
                            GloftMMN.m_a("GAME_INIT (SCRIPTING) AFTER NPC OCCUPATIONS");
                            MiamiNights.g.m_j();
                            GloftMMN.m_a("GAME_INIT (SCRIPTING) AFTER CONDITIONS");
                            MiamiNights.g.m_k();
                            GloftMMN.m_a("GAME_INIT (SCRIPTING) AFTER REACTIONS");
                            GloftMMN.m_a("GAME_INIT AFTER SCRIPTING");
                        }

                        if (i == 6)
                        {
                            q = new sbyte[2][];
                            r = new sbyte[2][];

                            for (int var95 = 7; var95 <= 9; var95 += 2)
                            {
                                int var107 = (var95 - 7) / 2;
                                m_a(var95 + 0, o, var107, false, false, -1, false);
                                q[var107] = GloftMMN.m_j(var95 + 1);
                                r[var107] = new sbyte[6];

                                for (int var116 = 0; var116 < q[var107].Length; var116++)
                                {
                                    sbyte var121;
                                    if ((var121 = q[var107][var116]) >= 0)
                                    {
                                        r[var107][var121]++;
                                    }
                                }
                            }

                            GloftMMN.m_f();
                            MiamiNights.g.m_a(false);
                            s[0] = new g(9, 0, 0, false, false);
                            GloftMMN.m_f();
                        }

                        if (i == 7)
                        {
                            MiamiNights.f.m_a(false);
                            MiamiNights.f.bb = new sbyte[16];
                            MiamiNights.f.bc = GloftMMN.m_j(6);
                            GloftMMN.m_f();
                        }

                        if (i == 8)
                        {
                            X = 0;
                            MiamiNights.f.m_p();
                            MiamiNights.f.m_b(true);
                            if (MiamiNights.f.ah)
                            {
                                m_a(8);
                                Console.WriteLine("RRRRRRRRRRRRRRMMMMMMMMMMMMMMMMMMSSSSSSSSSSSSSSSSSSSs");
                                m_a(false, false, false);
                                y = 20;
                                L = 0;
                                z = -1;
                            }
                            else
                            {
                                m_a(17);
                                at = false;
                                i = -2;
                            }
                        }
                    }
                    catch (Exception var43)
                    {
                        var43.ToString();
                    }

                    int var108 = i;
                    if (i < 0)
                    {
                        var108 = 7;
                    }

                    if (MiamiNights.f.ah)
                    {
                        aB.SetClip(0, 0, 231 * var108 / 30, 400);
                    }
                    else
                    {
                        aB.SetClip(0, 0, 231 * var108 / 7, 400);
                    }

                    aB.SetColor(16711680);
                    aB.FillRect(7, 316, 240, 3);
                    i++;
                    return;
                case 8:
                    d var120 = n[0];
                    g var128 = s[0];
                    if (!MiamiNights.f.d && (y == 0 || y == 19))
                    {
                        if (N[0] >= 0)
                        {
                            MiamiNights.f.au = N[0];
                            MiamiNights.f.m_f(MiamiNights.f.au);
                            B = (sbyte)N[1];
                            MiamiNights.f.m_a(true, true);
                            MiamiNights.f.m_a(MiamiNights.f.aX[B], true);
                            y = z;
                            z = -1;
                            N[0] = -1;
                            MiamiNights.f.m_a(aB, true, true);
                        }

                        if (N[4] > 0)
                        {
                            d var103;
                            (var103 = n[0]).m_a(N[4]);
                        }
                    }

                    if (y == 0 || y == 5)
                    {
                        if (N[3] == 0)
                        {
                            MiamiNights.f.aT = MiamiNights.f.aT + aH * MiamiNights.f.aU / 100L;
                            if (y == 5 && MiamiNights.f.aT > MiamiNights.f.aB)
                            {
                                MiamiNights.f.aT = MiamiNights.f.aB;
                            }

                            var128.m_f();
                            MiamiNights.g.m_b(false);
                        }

                        if (X == 1)
                        {
                            N[6]++;
                            if (N[6] >= N[5])
                            {
                                N[4] = -1;
                                X = 2;
                                m_r();
                                H = 1;
                                L = 0;
                                y = 20;
                                Y = true;
                                z = -1;
                            }
                            else
                            {
                                MiamiNights.g.m_d(N[6]);
                                if (!MiamiNights.f.d && MiamiNights.g.N.size() > 0)
                                {
                                    y = 17;
                                }
                            }
                        }
                    }

                    switch (y)
                    {
                        case 0:
                            // Java: label4309: { ... } - block translated to do/while(false); `break label4309` -> `break;`
                            do
                            {
                                if (ao && aC[6] < 0)
                                {
                                    ak++;
                                    ak %= 4;
                                    if (ak == 2)
                                    {
                                        al = 0;
                                        an = new int[s[0].a.Length];
                                        am = 0;

                                        for (int var83 = 0; var83 < s[0].a.Length; var83++)
                                        {
                                            if ((MiamiNights.g.m_d(var83, 1) & 1) != 1 || var83 == 35)
                                            {
                                                an[am++] = var83;
                                            }
                                        }
                                    }
                                }

                                if (y == 0 && z < 0)
                                {
                                    switch (ak)
                                    {
                                        case 0:
                                        default:
                                            break;
                                        case 1:
                                            if (aP)
                                            {
                                                ak = 0;

                                                for (int var84 = 353; var84 < 400; var84++)
                                                {
                                                    MiamiNights.g.m_a(var84);
                                                }

                                                for (int var85 = 498; var85 < 780; var85++)
                                                {
                                                    MiamiNights.g.m_a(var85);
                                                }
                                            }
                                            break;
                                        case 2:
                                            if (aC[3] < 0)
                                            {
                                                al--;
                                                if (al < 0)
                                                {
                                                    al = am - 1;
                                                }
                                            }
                                            else if (aC[4] < 0)
                                            {
                                                al++;
                                                al = al % am;
                                            }
                                            else if (aC[2] > 0)
                                            {
                                                s[0].m_c(an[al], -1);
                                            }
                                            else if (aC[1] > 0)
                                            {
                                                s[0].m_c(an[al], 1);
                                            }
                                            break;
                                        case 3:
                                            if (MiamiNights.f.av != -1)
                                            {
                                                g var145 = s[MiamiNights.f.av];
                                                if (aC[2] > 0)
                                                {
                                                    if (var145.a[39] > 1)
                                                    {
                                                        var145.a[39]--;
                                                    }
                                                }
                                                else if (aC[1] > 0 && var145.a[39] < 100)
                                                {
                                                    var145.a[39]++;
                                                }
                                            }
                                            break;
                                    }
                                }

                                if (N[4] <= 0 && ak == 0)
                                {
                                    MiamiNights.g.p = MiamiNights.g.p + aH;
                                    if (aC[7] <= 0 && aC[1] <= 0 && aC[8] <= 0 && aC[3] <= 0 && aC[4] <= 0 && aC[9] <= 0 && aC[2] <= 0 && aC[10] <= 0)
                                    {
                                        if (bp <= bq && bo != null)
                                        {
                                            int var146;
                                            if ((var146 = (int)aH) > 200)
                                            {
                                                var146 = 200;
                                            }

                                            int var166 = 0;
                                            int var181 = 0;
                                            int var189 = var128.c[0];
                                            int var200 = var128.c[1];
                                            int var218 = m_f(bo[bq] % bs);
                                            int var230 = m_f(bo[bq] / bs);
                                            int var238 = var218 - var189;
                                            int var248 = var230 - var200;
                                            var238 = var238 * 1000 / var146;

                                            for (var248 = var248 * 1000 / var146; bq >= 0; bq--)
                                            {
                                                var218 = m_f(bo[bq] % bs);
                                                var230 = m_f(bo[bq] / bs);
                                                var238 = var218 - var128.c[0];
                                                var248 = var230 - var128.c[1];
                                                var238 = var238 * 1000 / var146;
                                                var248 = var248 * 1000 / var146;
                                                if (!m_a((long)var238, (long)var248))
                                                {
                                                    m_c(var166, var181, var238, var248);
                                                    var238 = bw;
                                                    var248 = bx;
                                                    break;
                                                }

                                                var189 = var218;
                                                var200 = var230;
                                                var166 = var238;
                                                var181 = var248;
                                            }

                                            int var255 = 0;   // CFR: int (VF byte mis-inference)
                                            int var260 = 0;   // CFR: int (VF byte mis-inference)
                                            if (var238 > 0)
                                            {
                                                if (Math.Abs(var238) >= Math.Abs(var248))
                                                {
                                                    var255 = 4;
                                                    var260 = 0;
                                                }
                                                else if (var248 < 0)
                                                {
                                                    var260 = 0;
                                                    var255 = 6;
                                                }
                                                else
                                                {
                                                    var260 = 1;
                                                    var255 = 4;
                                                }
                                            }
                                            else if (Math.Abs(var238) > Math.Abs(var248))
                                            {
                                                var255 = 6;
                                                var260 = 1;
                                            }
                                            else if (var248 < 0)
                                            {
                                                var260 = 0;
                                                var255 = 6;
                                            }
                                            else
                                            {
                                                var260 = 1;
                                                var255 = 4;
                                            }

                                            if (!var128.m_a(var238, var248, var255, var260, false) && var189 != var128.c[0] && var200 != var128.c[1])
                                            {
                                                var128.m_a(var189, var200, var255, var260, true);
                                            }

                                            if (aR)
                                            {
                                                bp = 1;
                                                bq = 0;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        m_a(
                                           var128,
                                           var120,
                                           aC[3] > 0 || aC[7] > 0 || aC[9] > 0,
                                           aC[4] > 0 || aC[8] > 0 || aC[10] > 0,
                                           aC[1] > 0 || aC[7] > 0 || aC[8] > 0,
                                           aC[2] > 0 || aC[9] > 0 || aC[10] > 0
                                        );
                                        bp = 1;
                                        bq = 0;
                                    }
                                }

                                MiamiNights.g.m_m();
                                if (aC[12] < 0)
                                {
                                    StatsPanel.Toggle();   // added: '#' / '?' toggles stats panel
                                }

                                if (aP)
                                {
                                    D = 0;
                                    if (MiamiNights.f.av >= 0)
                                    {
                                        g var147 = s[MiamiNights.f.av];
                                        sbyte var167;
                                        if ((var167 = MiamiNights.f.bc[25]) > 0 && var147.b[6] == var167 && MiamiNights.f.bc[24] != H)
                                        {
                                            MiamiNights.g.m_a(780);
                                            MiamiNights.g.au = true;
                                        }
                                        else
                                        {
                                            if (var147.b[7] == -1)
                                            {
                                                var147.b[7] = (sbyte)n[var147.b[5]].c;
                                            }

                                            MiamiNights.g.m_b(MiamiNights.f.av);
                                            if (!MiamiNights.g.au)
                                            {
                                                MiamiNights.f.m_a(aB, true);
                                            }
                                        }
                                    }
                                    else if (MiamiNights.f.au < 0 && MiamiNights.f.aR >= 0)
                                    {
                                        short var148;
                                        if ((var148 = MiamiNights.f.e[MiamiNights.f.aR][4]) >= 0)
                                        {
                                            m_a(2, 0, true);
                                            R[0] = 141 + var148;
                                            R[1] = 400;
                                        }
                                        else if (var148 != -2)
                                        {
                                            i = -1;
                                            m_b();
                                            m_a(15);
                                            break;   // Java: break label4309 (exits the do-block)
                                        }

                                        if (var148 >= 0)
                                        {
                                            i = 0;
                                            U[2] = 401;
                                            U[3] = 781;
                                            U[5] = 21;
                                            z = 22;
                                        }
                                    }
                                }

                                if ((aC[13] < 0 || (MiamiNights.g.ae & 256) == 256 && MiamiNights.f.aT - MiamiNights.g.af >= 5000L) && !aP)
                                {
                                    GloftMMN.m_c(3);
                                    m_a(16);
                                    y = 24;
                                    MiamiNights.g.ae &= -257;
                                    K = 0;
                                }
                                else
                                {
                                    if (aC[14] < 0 || k && K > 1)
                                    {
                                        y = 32;
                                        if (k)
                                        {
                                            i = -2;
                                        }
                                        else
                                        {
                                            i = -1;
                                        }
                                    }

                                    if (MiamiNights.g.p > 0L)
                                    {
                                        bool var149 = MiamiNights.g.m_g(var120.e);
                                        if (MiamiNights.g.v == 85)
                                        {
                                            var120.m_a(var149 ? 88 : 87);
                                        }
                                        else if (MiamiNights.g.v == 91)
                                        {
                                            var120.m_a(var149 ? 94 : 93);
                                        }
                                        else
                                        {
                                            bool var168 = MiamiNights.g.v != 0;
                                            int var182 = 0;   // CFR: int (VF byte mis-inference)
                                            if (var168)
                                            {
                                                var182 = 8;
                                            }

                                            if (!var168 && MiamiNights.g.p >= 6000L)
                                            {
                                                if (MiamiNights.g.p < 7000L && var120.m_a())
                                                {
                                                    var120.m_a(3);
                                                }
                                                else if (MiamiNights.g.p >= 7000L && var120.m_a())
                                                {
                                                    int var190;
                                                    if ((var190 = GloftMMN.m_c(0, 100)) < 25)
                                                    {
                                                        var120.m_a(3);
                                                    }
                                                    else if (var190 < 50)
                                                    {
                                                        var120.m_a(2);
                                                    }
                                                    else
                                                    {
                                                        var120.m_a(0);
                                                    }
                                                }
                                            }
                                            else if (MiamiNights.g.m_g(var120.e))
                                            {
                                                var120.m_a(1 + var182);
                                            }
                                            else
                                            {
                                                var120.m_a(0 + var182);
                                            }
                                        }
                                    }

                                    if (z == -1)
                                    {
                                        if (MiamiNights.g.v <= 6)
                                        {
                                            if (!MiamiNights.f.m_f(var128.c[0], var128.c[1]))
                                            {
                                                MiamiNights.f.m_e(var128.c[0], var128.c[1]);
                                            }
                                        }
                                        else
                                        {
                                            MiamiNights.f.av = -1;
                                            MiamiNights.f.au = -1;
                                        }
                                    }

                                    if (K > 0 && !MiamiNights.f.d && MiamiNights.g.N.size() > 0)
                                    {
                                        z = 17;
                                    }
                                    else if (MiamiNights.g.ak != null)
                                    {
                                        i = 0;
                                        z = 33;
                                    }

                                    if (y == 0 && z == -1)
                                    {
                                        int var150;
                                        if (((var150 = MiamiNights.f.m_b(var128.c[0], var128.c[1])) & 16384) != 0)
                                        {
                                            if (MiamiNights.g.v <= 6)
                                            {
                                                MiamiNights.g.w = MiamiNights.g.v;
                                            }

                                            MiamiNights.g.v = 85;
                                        }
                                        else if ((var150 & -32768) != 0)
                                        {
                                            if (MiamiNights.g.v <= 6)
                                            {
                                                MiamiNights.g.w = MiamiNights.g.v;
                                            }

                                            MiamiNights.g.v = 91;
                                        }
                                        else
                                        {
                                            MiamiNights.g.v = MiamiNights.g.w;
                                        }
                                    }

                                    if (aj && ai != 0 && K > 0 && !k)
                                    {
                                        z = 76;
                                        aj = false;
                                    }
                                }
                            }
                            while (false);   // Java: label4309 block end
                            goto case 1;     // Java: block falls into empty case-1 group -> break switch
                        case 1:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                        case 33:
                        case 34:
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
                        default:
                            break;
                        case 2:
                            if (K == 0)
                            {
                                MiamiNights.f.m_a(aB, false, true);
                            }

                            if (!MiamiNights.f.m_a(false, false))
                            {
                                break;
                            }

                            int var144 = MiamiNights.f.m_i(MiamiNights.f.aX[B], 5);
                            int var165 = MiamiNights.f.ao[MiamiNights.f.m_g(var144, -1)];
                            if (MiamiNights.f.m_a(s[0], MiamiNights.f.an, var165 + 6, false, true) > var128.a[35])
                            {
                                MiamiNights.g.m_a(434);
                                Console.WriteLine("this is correct one....");
                                z = 0;
                            }
                            else
                            {
                                int var188;
                                int var199;
                                int var217 = MiamiNights.f.m_g(var199 = MiamiNights.f.m_i(var188 = MiamiNights.f.aX[B], 5), -1);
                                int var229 = MiamiNights.f.m_g(var199, 4);
                                long var237;
                                long var254 = (var237 = MiamiNights.f.ap[var217]) + var229 * 60L * 1000L / 60L;
                                if (!MiamiNights.g.m_e(var199))
                                {
                                    z = 0;
                                }
                                else
                                {
                                    if (var237 != 0L && MiamiNights.f.aT < var254)
                                    {
                                        MiamiNights.f.m_a(var188, false);
                                        break;
                                    }

                                    MiamiNights.f.m_a(var188, true);
                                }
                            }
                            break;
                        case 3:
                        case 4:
                        case 16:
                            if (y == 16)
                            {
                                int var143 = MiamiNights.f.aJ[MiamiNights.f.m_c(E[D - 2], E[D - 1]) + 5] & 255;
                                if (aC[1] < 0)
                                {
                                    B--;
                                    if (B < 0)
                                    {
                                        B = (sbyte)(B + var143);
                                    }
                                }
                                else if (aC[2] < 0)
                                {
                                    B++;
                                    B = (sbyte)(B % var143);
                                }
                                else if (aC[13] < 0 || aC[6] < 0)
                                {
                                    GloftMMN.m_c(3);
                                    D--;
                                    MiamiNights.f.m_b(aB, 4);
                                }
                                else if (aP)
                                {
                                    E[D] = B;
                                    MiamiNights.f.m_a(aB, false);
                                }
                            }
                            else if (K >= 3)
                            {
                                if (aC[3] < 0 && C >= 2)
                                {
                                    if (B != 1)
                                    {
                                        aa = true;
                                        B = 1;
                                    }
                                }
                                else if (aC[4] < 0 && C >= 3)
                                {
                                    if (B != 2)
                                    {
                                        B = 2;
                                        aa = true;
                                    }
                                }
                                else if (aC[1] < 0)
                                {
                                    if (B != 0)
                                    {
                                        B = 0;
                                        aa = true;
                                    }
                                }
                                else if (aC[2] < 0 && C >= 4)
                                {
                                    if (B != 3)
                                    {
                                        B = 3;
                                        aa = true;
                                    }
                                }
                                else if (aP)
                                {
                                    i = y;
                                    z = 34;
                                }
                                else if (aC[13] < 0 || aC[6] < 0)
                                {
                                    GloftMMN.m_c(3);
                                    if (y == 3)
                                    {
                                        y = 0;
                                        k = true;
                                    }
                                    else if (D <= 0)
                                    {
                                        z = 15;
                                    }
                                    else
                                    {
                                        D--;
                                        MiamiNights.f.m_b(aB, 4);
                                    }
                                }
                            }

                            if (K == 0)
                            {
                                MiamiNights.f.m_a(aB, false, true);
                            }

                            MiamiNights.g.p = 0L;
                            break;
                        case 5:
                            if (K == 0)
                            {
                                MiamiNights.f.m_a(aB, false, true);
                            }

                            MiamiNights.f.m_m();
                            break;
                        case 10:
                            if (MiamiNights.f.m_a(false, false))
                            {
                                MiamiNights.f.m_b(aB, 4);
                            }
                            break;
                        case 11:
                            int var142 = MiamiNights.g.m_h(MiamiNights.f.aM, MiamiNights.f.aN);
                            sbyte var164 = MiamiNights.g.@as[var142 + 8];
                            if (MiamiNights.f.aq && MiamiNights.f.ar)
                            {
                                MiamiNights.f.aP = MiamiNights.g.@as[var142 + 6] & 255;
                                MiamiNights.f.aO = MiamiNights.g.@as[var142 + 7] & 255;
                                var120.e = -1;
                                var120.m_a(MiamiNights.g.@as[var142 + 5] & 255);
                                MiamiNights.f.aq = false;
                                MiamiNights.f.ar = false;
                                MiamiNights.f.m_d();
                                if (var164 > 0)
                                {
                                    MiamiNights.g.u = -1;
                                    MiamiNights.g.m_a(true, 76);
                                    GloftMMN.m_c(0);
                                }

                                z = 12;
                                break;
                            }

                            MiamiNights.f.m_d();
                            break;
                        case 12:
                            if (MiamiNights.f.aq && MiamiNights.f.ar)
                            {
                                MiamiNights.g.m_a(false, 76);
                                z = 14;
                                if (MiamiNights.g.ar > 0)
                                {
                                    object var141 = null;
                                    short var163;
                                    if ((var163 = MiamiNights.g.aq[0]) == MiamiNights.g.J)
                                    {
                                        MiamiNights.g.K++;
                                    }
                                    else
                                    {
                                        MiamiNights.g.J = var163;
                                        MiamiNights.g.K = 0;
                                    }

                                    MiamiNights.g.m_h(MiamiNights.f.aM, MiamiNights.f.aN);
                                    if (MiamiNights.g.L != MiamiNights.f.av)
                                    {
                                        MiamiNights.g.K = 0;
                                    }

                                    MiamiNights.g.M = null;
                                    MiamiNights.g.Q = 0;
                                    MiamiNights.g.J = var163;
                                    MiamiNights.g.M = MiamiNights.g.m_b(GloftMMN.m_k(var163), 207);
                                    z = 13;
                                }
                                break;
                            }

                            MiamiNights.f.m_d();
                            break;
                        case 13:
                            if (aP)
                            {
                                z = 14;
                                if (MiamiNights.g.M != null)
                                {
                                    int var82 = MiamiNights.g.M.Length << 1;
                                    if (MiamiNights.g.Q < var82)
                                    {
                                        MiamiNights.g.Q = var82;
                                        z = 13;
                                    }
                                }

                                if (z == 14)
                                {
                                    MiamiNights.g.Q = 0;
                                    MiamiNights.g.M = null;
                                }
                            }
                            break;
                        case 14:
                            MiamiNights.g.x = null;
                            g var94 = s[MiamiNights.f.av];
                            int var140 = MiamiNights.g.m_h(MiamiNights.f.aM, MiamiNights.f.aN);
                            MiamiNights.f.m_a(var128, MiamiNights.g.@as, var140 + 10, false, false);
                            w = MiamiNights.g.@as[var140 + 8];
                            var94.m_c(39, w);
                            if (w != 0)
                            {
                                m_b(1000);
                            }

                            B = (sbyte)(C - 1);
                            MiamiNights.g.Q = 0;
                            if (w < 0 && (E[0] == 2 && E[1] == 2 && x >= 2 || E[0] == 3 && E[1] == 0))
                            {
                                int var162 = GloftMMN.m_c(0, 100);
                                int var180;
                                if ((var180 = s[0].a[24] - 20) < 10)
                                {
                                    var180 = 10;
                                }

                                if (MiamiNights.f.bc[31] == 0 && var180 > 0 && var162 <= var180)
                                {
                                    MiamiNights.g.m_f(13, 1);
                                }
                            }

                            z = 7;
                            break;
                        case 15:
                            g var93 = s[MiamiNights.f.av];
                            MiamiNights.g.L = MiamiNights.f.av;
                            var120.m_a(0);
                            MiamiNights.f.m_i();
                            MiamiNights.g.x = null;
                            v[18].e = -1;
                            var93.A = false;
                            if (D <= 0)
                            {
                                D = 0;
                                z = 0;
                                k = true;
                                var93.m_n();
                            }
                            else
                            {
                                MiamiNights.g.m_a(var93);
                                D = 0;
                                if (O)
                                {
                                    var93.m_n();
                                    h_ = 16;
                                    Console.WriteLine("!!!!!!!!!!!!!!opennnnnnnnn");
                                    k = true;
                                    y = 27;
                                    O = false;
                                    MiamiNights.g.au = false;
                                }
                                else if (MiamiNights.g.N.size() > 0)
                                {
                                    z = 17;
                                }
                                else
                                {
                                    if (MiamiNights.g.au && ak == 0)
                                    {
                                        var93.m_n();
                                        z = 0;
                                        k = true;
                                        MiamiNights.f.av = -1;
                                        MiamiNights.g.au = false;
                                        break;
                                    }

                                    MiamiNights.f.m_b(aB, 4);
                                }
                            }
                            break;
                        case 17:
                            int var139 = MiamiNights.g.N.size();
                            if (K < 4 && var139 > 0)
                            {
                                if (aP)
                                {
                                    i = 255;
                                }
                            }
                            else
                            {
                                if (var139 > 0 && !aP && i != 255)
                                {
                                    break;
                                }

                                i = 0;
                                MiamiNights.g.Q = 0;
                                MiamiNights.g.M = null;
                                if (var139 > 0)
                                {
                                    MiamiNights.g.N.removeElementAt(0);
                                }

                                if (P)
                                {
                                    P = false;
                                    h_ = 16;
                                    y = 27;
                                    MiamiNights.g.au = true;
                                    z = -1;
                                    K = 0;
                                }
                                else if (X == 1)
                                {
                                    z = 5;
                                }
                                else
                                {
                                    z = 0;
                                    MiamiNights.g.m_c(aB);
                                    if (z == 0)
                                    {
                                        MiamiNights.f.m_a(aB, false, true);
                                    }
                                }
                            }
                            break;
                        case 22:
                            m_a(true);
                            if (z >= 0)
                            {
                                MiamiNights.f.m_a(aB, false, true);
                            }
                            break;
                        case 32:
                            if (i < 0)
                            {
                                GloftMMN.m_b();
                                m_a(5, 0, true);
                                if (i == -2)
                                {
                                    U[0] = 0;
                                }

                                U[2] = 790;
                                U[3] = 791;
                                U[5] = 0;
                                R[0] = 400;
                                R[1] = 792;
                                R[2] = 890;
                                R[3] = 794;
                                R[4] = 795;
                                i = 0;
                                MiamiNights.f.m_a(aB, false, true);
                            }

                            m_a(false);
                            if (k)
                            {
                                i = -2;
                            }
                            else if (aP)
                            {
                                int var138;
                                if ((var138 = U[0]) == 2)
                                {
                                    z = 73;
                                    m_d(890, 1);
                                    z = 73;
                                }
                                else if (var138 == 1)
                                {
                                    z = 81;
                                    j = true;
                                    k = true;
                                    MiamiNights.f.m_a(aB, true, false);
                                }
                                else if (var138 == 0)
                                {
                                    if (MiamiNights.f.bc[31] == 0)
                                    {
                                        i = -1;
                                        m_a(15);
                                    }
                                    else
                                    {
                                        MiamiNights.g.m_a(903);
                                        z = 0;
                                    }
                                }
                                else if (var138 == 3)
                                {
                                    Y = true;
                                    z = 74;
                                    j = false;
                                    MiamiNights.f.m_a(aB, true, true);
                                }
                                else if (var138 == 4)
                                {
                                    Y = false;
                                    z = 74;
                                    j = false;
                                    MiamiNights.f.m_a(aB, true, true);
                                }
                                else
                                {
                                    k = true;
                                    MiamiNights.f.bn = true;
                                    y = 0;
                                    MiamiNights.g.H = -1;
                                    MiamiNights.f.m_a(aB, true, true);
                                }
                            }
                            break;
                        case 35:
                            if (i >= 2)
                            {
                                if (K == 0)
                                {
                                    aB.SetClip(0, 0, 240, 400);
                                    aB.SetColor(0);
                                    aB.FillRect(0, 199, 240, MiamiNights.a.z + 5);
                                    M.m_a(aB, GloftMMN.m_k(834), 120, 200, 17, 0);
                                }
                                else if (K == 1)
                                {
                                    m_a(true, false, false);
                                }
                                else
                                {
                                    z = 0;
                                    k = true;
                                }
                            }
                            break;
                        case 67:
                            k = true;
                            aB.SetClip(0, 0, 240, 400);
                            aB.FillRect(0, 0, 240, 400);
                            if (k)
                            {
                                aB.SetColor(0);
                                aB.FillRect(0, 0, 240, 76);
                            }

                            if (MiamiNights.f.m == null)
                            {
                                MiamiNights.f.m = Image.CreateImage(MiamiNights.f.n, MiamiNights.f.o);
                                MiamiNights.f.aj = MiamiNights.f.m.GetGraphics();
                            }

                            Graphics var137 = MiamiNights.f.aj;
                            MiamiNights.f.aj.Translate(0, -75);
                            d var115 = v[7];
                            bool var161 = aP || aC[14] < 0;
                            d var179 = v[17];
                            if (i != -2)
                            {
                                if (K == 0)
                                {
                                    var137.SetColor(0);
                                    var137.FillRect(0, 0, 240, 400);
                                    MiamiNights.f.m_a(var137, false, true);
                                    var115.m_a(48);
                                    var115.a = 30720;
                                    var115.b = 51200;
                                    var115.m_a(var137);
                                    MiamiNights.g.m_a(GloftMMN.m_k(828), 2);
                                    MiamiNights.g.ae &= -257;
                                    i = -1;
                                }
                                else if (i == -1)
                                {
                                    var115.m_a(51);
                                    var115.m_a(var137);
                                    if (var161)
                                    {
                                        i = 0;
                                        var137.SetColor(0);
                                        var137.FillRect(0, 75, 240, 240);
                                        var115.m_a(48);
                                        var115.m_a(var137);
                                    }
                                }
                                else
                                {
                                    var137.SetColor(0);
                                    var137.FillRect(0, 140, 240, 272);
                                    if (aC[1] < 0)
                                    {
                                        i--;
                                    }
                                    else if (aC[2] < 0)
                                    {
                                        i++;
                                    }

                                    if (i < 0)
                                    {
                                        i = 5;
                                    }

                                    i %= 6;
                                    var115.m_a(49);
                                    int[] var187 = var115.m_c(1 + i);
                                    var137.SetColor(16545380);
                                    u[0].m_a(var137, 30, 4, 220, 380, 0, 0, 0);
                                    var137.FillRect(0, var187[1] + 6 - 3 - 12, 240, 35);

                                    for (int var81 = 0; var81 < 2; var81++)
                                    {
                                        u[1].m_a(var137, 92 + var81, 0, var81 * 240, var187[1] - 1, 0, 0, 0);
                                    }

                                    var115.m_a(var137);
                                    if (var161)
                                    {
                                        GloftMMN.m_c(3);
                                        MiamiNights.f.bc[29] = (sbyte)i;
                                        var179.m_a(89);
                                        var179.a = 30720;
                                        var179.b = var187[1] + 14 << 8;
                                        i = -2;
                                    }
                                }
                            }

                            M.m_b(var137, GloftMMN.m_k(820), 120, 90, 17, 1);
                            aB.DrawImage(MiamiNights.f.m, 0, 75, 20);
                            if (i == -2)
                            {
                                var179.m_a(aB);
                                if (var179.m_a())
                                {
                                    aB.SetColor(0);
                                    aB.FillRect(0, 0, 240, 400);
                                    X = 1;
                                    s[0].a[22] = 41;
                                    MiamiNights.f.bc[30] = 1;
                                    H = 36;
                                    MiamiNights.g.m_a(GloftMMN.m_k(753), 2);
                                    MiamiNights.g.ae &= -257;
                                    L = 0;
                                    y = 20;
                                    z = -1;
                                    MiamiNights.f.d = true;
                                }
                                else
                                {
                                    var179.m_b();
                                }
                            }

                            var137.Translate(0, 75);
                            break;
                    }

                    if (h_ != 8)
                    {
                        return;
                    }

                    if (y != 20 && (y < 11 || y > 16) && y != 7)
                    {
                        m_a(var128);
                    }

                    bool var151 = K == 0;
                    bool var169 = false;
                    bool var183;
                    if (!(var183 = y == 35 && !k || y == 20 || y == 8 || y == 75 || y == 67 || y == 68)
                       && y != 15
                       && y != 33
                       && y != 3
                       && y != 4
                       && y != 16
                       && (var151 || y != 7 && y != 13 && y != 17 && y != 34 && y != 32 && y != 73 && y != 74 && y != 81))
                    {
                        var169 = true;
                    }

                    if (y == 17 && z == 17)
                    {
                        var169 = true;
                    }

                    if (var169 || k && !var183)
                    {
                        if (k)
                        {
                            aB.SetColor(0);
                            aB.FillRect(0, 0, 240, 400);
                        }

                        NpcAi.Tick();   // added: needs-driven NPC AI, right before the world tick (decisions consumed by f.m_n this frame)
                        MiamiNights.f.m_n();
                        MiamiNights.f.m_a(aB);
                        MiamiNights.f.m_o();
                    }
                    switch (y)
                    {
                        case 0:
                            if (MiamiNights.f.aR >= 0)
                            {
                                MiamiNights.f.m_a(aB, null, false, true, false, null);
                            }
                            goto case 1;   // Java: falls into empty case-1 group -> break
                        case 1:
                        case 2:
                        case 5:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 22:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                        case 32:
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
                        case 69:
                        case 70:
                        case 71:
                        case 72:
                        case 77:
                        case 78:
                        case 79:
                        case 80:
                        default:
                            break;
                        case 3:
                        case 4:
                            if (z < 0)
                            {
                                MiamiNights.f.m_c(aB, y);
                            }
                            break;
                        case 6:
                            if (K > 10)
                            {
                                MiamiNights.g.H = -1;
                                z = 7;
                            }
                            break;
                        case 7:
                            MiamiNights.f.m_c(aB);
                            break;
                        case 8:
                            d var105 = n[0];
                            sbyte var192 = var128.b[17];
                            int var202 = 16751593;
                            if (s[0].a[0] == 0)
                            {
                                var202 = 706047;
                            }

                            if (K != 0 && !k)
                            {
                                aB.SetColor(4472414);
                                aB.FillRect(4, 98, 226, 99);
                                var105.a = 29952;
                                var105.b = 46848;
                                aB.SetColor(6117777);
                                aB.FillRect(72, 99, 93, 83);
                                v[17].d_.m_a(aB, 86, 0, var105.a >> 8, var105.b >> 8, 0, 0, 0);
                                aB.SetColor(var202);
                                aB.FillRect(5, 83, 41, 14);
                                aB.FillRect(188, 83, 39, 14);
                                aB.FillRect(5, 291, 226, 15);
                                var105.m_a(aB);
                                var105.m_b();
                                d var223;
                                (var223 = v[19]).i = var105;
                                var223.a = 0;
                                var223.b = -16128;
                                var223.m_a(aB);
                                var223.m_b();
                                d var232;
                                (var232 = v[17]).m_a(69);
                                var232.a = 768;
                                var232.b = 20480;
                                var232.m_a(aB);
                                var232.a += 47360;
                                var232.m_a(aB);
                                var232.a = 25088;
                                var232.b = 73984;
                                var232.m_a(aB);
                                var232.m_b();
                                M.m_a(aB, GloftMMN.m_k(938), 117, 315, 17, 0);
                                if (var232.m_a())
                                {
                                    var232.e = -1;
                                }

                                if (var192 > 0)
                                {
                                    M.m_a(aB, GloftMMN.m_k(MiamiNights.g.m_d(var192, 0)), 120, 197, 17, 0);
                                    MiamiNights.f.m_a(aB, var192, 79, 211, 5);
                                }

                                bool var241 = false;

                                for (int var87 = 0; var87 < aC.Length; var87++)
                                {
                                    if (aC[var87] < 0)
                                    {
                                        var241 = true;
                                        break;
                                    }
                                }

                                if (var241 && K >= 5)
                                {
                                    bB = -1;
                                    bC = -1;
                                    if (MiamiNights.g.V != 0)
                                    {
                                        if (MiamiNights.g.V < 0)
                                        {
                                            s[0].a[6] = -MiamiNights.g.V - 1;
                                            s[0].a[7] = MiamiNights.g.W & 255;
                                        }
                                        else
                                        {
                                            s[0].a[8] = MiamiNights.g.V - 1;
                                            s[0].a[9] = MiamiNights.g.W & 255;
                                        }

                                        MiamiNights.g.V = 0;
                                        z = 68;
                                        i = 0;
                                    }
                                    else
                                    {
                                        z = 75;
                                    }
                                }
                                break;
                            }

                            z = -1;
                            var128.b[16] = (sbyte)var105.e;
                            var105.m_a(43);
                            var105.d_.m = var128.b[15];
                            v[19].e = -1;
                            v[19].m_a(75);
                            aB.SetColor(0);
                            aB.FillRect(0, 0, 240, 400);
                            aB.SetClip(0, 75, 240, 260);
                            aB.SetColor(4472414);
                            aB.FillRect(0, 75, 240, 240);
                            MiamiNights.g.m_a(aB, 3, 81, 229, 227, var202, 16777099, 16777099);
                            M.m_a(aB, GloftMMN.m_k(657), 117, 83, 17, 0);
                            aB.SetColor(4472414);
                            aB.FillRect(4, 98, 226, 127);
                            string var221;
                            var221 = MiamiNights.g.m_b((var221 = (string)MiamiNights.g.N.elementAt(0)).Substring(1, var221.Length - 1), 196);
                            M.m_a(aB, var221, 120, 229, 17, 0);
                            aB.SetColor(16777099);
                            aB.FillRect(4, 97, 226, 1);
                            if (!k)
                            {
                                GloftMMN.m_c(1);
                            }

                            m_b(1000);
                            break;
                        case 16:
                            if (z < 0)
                            {
                                MiamiNights.f.m_b(aB, false);
                            }
                            break;
                        case 21:
                            int var191 = U[0];
                            int var201 = R[var191] - 141;
                            if (var191 == U[1] - 1)
                            {
                                z = 0;
                            }
                            else if (var191 == U[1] - 2)
                            {
                                i = -1;
                                m_b();
                                m_a(15);
                            }
                            else if (MiamiNights.g.ah[var201] == 0)
                            {
                                string var220;
                                if ((var220 = GloftMMN.m_k(435 + var201)) != null)
                                {
                                    MiamiNights.g.m_a(var220);
                                }
                                else
                                {
                                    MiamiNights.g.m_a(867);
                                }

                                z = 0;
                            }
                            else
                            {
                                H = var201;
                                z = 18;
                                L = 0;
                            }
                            break;
                        case 23:
                            if (U[0] == 0)
                            {
                                H = R[2];
                                z = 18;
                                L = 0;
                            }
                            else
                            {
                                z = 0;
                            }
                            break;
                        case 33:
                            if (K == 0)
                            {
                                MiamiNights.f.m_a(aB, false, true);
                            }

                            m_a(aB);
                            if (aP)
                            {
                                if (MiamiNights.f.av != -1)
                                {
                                    s[MiamiNights.f.av].A = false;
                                }

                                z = 0;
                                MiamiNights.f.m_a(aB, false, true);
                            }
                            break;
                        case 34:
                            aB.SetClip(0, 75, 240, 240);
                            MiamiNights.f.m_c(aB, i);
                            if (v[4].m_a())
                            {
                                if (i == 3)
                                {
                                    MiamiNights.f.m_a(true, false);
                                }
                                else if (D < 3)
                                {
                                    E[D++] = B;
                                    MiamiNights.f.m_b(aB, 4);
                                }
                            }
                            break;
                        case 68:
                            GloftMMN.m_b();
                            if (i == 0)
                            {
                                aB.SetColor(0);
                                aB.FillRect(0, 0, 240, 400);
                                M.m_a(aB, GloftMMN.m_k(829), 120, 200, 3, 0);
                            }
                            else if (i == 1)
                            {
                                MiamiNights.f.m = null;
                                MiamiNights.f.aj = null;
                                GloftMMN.n = null;
                                GloftMMN.o = null;
                                MiamiNights.f.m_b(false);
                            }
                            else if (i == 2)
                            {
                                MiamiNights.g.m_a(false);
                            }
                            else if (i == 3)
                            {
                                int var86 = s[0].a[0];
                                MiamiNights.g.j[var86] = 0;
                                s[0].m_a(7 + var86 * 2, 0, true);
                            }
                            else if (i == 4)
                            {
                                MiamiNights.g.m_a(true);
                            }
                            else
                            {
                                au = true;
                                MiamiNights.f.m = Image.CreateImage(MiamiNights.f.n, MiamiNights.f.o);
                                MiamiNights.f.aj = MiamiNights.f.m.GetGraphics();
                                GloftMMN.m_a("/3", 0);
                                MiamiNights.f.m_b(true);
                                if (MiamiNights.g.V == 0)
                                {
                                    z = 75;
                                }
                                else
                                {
                                    z = 8;
                                }
                            }

                            i++;
                            break;
                        case 73:
                            if (aP)
                            {
                                MiamiNights.f.m_a(aB);
                            }

                            if (m_d(890, 2))
                            {
                                z = 32;
                                i = -1;
                            }
                            break;
                        case 74:
                            if (MiamiNights.g.ak == null)
                            {
                                MiamiNights.g.m_a(GloftMMN.m_k(866), (sbyte)-56);
                                i = 0;
                            }

                            m_a(aB);
                            if (aP)
                            {
                                MiamiNights.g.ak = null;
                                if (i == 0)
                                {
                                    z = 32;
                                    bP = 0;
                                    Y = false;
                                }
                                else if (i == 1)
                                {
                                    z = 81;
                                }
                            }
                            break;
                        case 75:
                            d var104;
                            (var104 = n[0]).m_a(var128.b[16]);
                            if (MiamiNights.g.N.size() > 0)
                            {
                                MiamiNights.g.N.removeElementAt(0);
                            }

                            var128.b[17] = 0;
                            z = 0;
                            MiamiNights.g.m_c(aB);
                            if (z != 4)
                            {
                                if (z == 17)
                                {
                                    z = 0;
                                }
                                else if (z != 18)
                                {
                                    z = 0;
                                }
                            }

                            if (z == 18)
                            {
                                L = 0;
                                y = 20;
                                z = -1;
                            }
                            else
                            {
                                MiamiNights.f.d = true;
                                MiamiNights.f.E = -10000;
                                MiamiNights.f.F = -10000;
                                MiamiNights.g.H = -1;
                            }

                            MiamiNights.g.p = 0L;
                            break;
                        case 76:
                            if (K == 0)
                            {
                                MiamiNights.g.m_a(GloftMMN.m_k(906 + ai - 1), (sbyte)-56);
                                i = 0;
                            }
                            else if (K > 3)
                            {
                                m_a(aB);
                                if (aP)
                                {
                                    if (i == 0)
                                    {
                                        z = 0;
                                    }
                                    else if (i == 1)
                                    {
                                        i = 2;
                                        z = 35;
                                    }
                                }
                            }
                            break;
                        case 81:
                            if (MiamiNights.g.ak == null)
                            {
                                if (!j)
                                {
                                    MiamiNights.g.m_a(GloftMMN.m_k(921), (sbyte)-56);
                                }
                                else
                                {
                                    MiamiNights.g.m_a(GloftMMN.m_k(866), (sbyte)-56);
                                }

                                i = 0;
                            }

                            m_a(aB);
                            if (aP)
                            {
                                MiamiNights.g.ak = null;
                                if (i == 1)
                                {
                                    if (j)
                                    {
                                        j = false;
                                        i = 2;
                                        K = 0;
                                        z = 35;
                                    }
                                    else
                                    {
                                        z = 83;
                                    }
                                }
                                else if (j)
                                {
                                    j = false;
                                    i = 0;
                                    z = 0;
                                    k = true;
                                }
                                else
                                {
                                    z = 82;
                                }
                            }
                            break;
                        case 82:
                            if (!Y)
                            {
                                Console.WriteLine("[QUIT-SITE-2 case82] Y=" + Y + " i=" + i + " aP=" + aP + " y=" + y + " z=" + z + " j=" + j);
                                h_ = -1;
                                return;
                            }

                            Z = true;
                            m_a(4);
                            MiamiNights.f.bd = 0;
                            MiamiNights.f.m_a(aB, H);
                            MiamiNights.f.m_e();
                            MiamiNights.f.m_b();
                            i = 0;
                            y = -1;
                            break;
                        case 83:
                            aB.SetClip(0, 0, 240, 400);
                            aB.SetColor(0);
                            aB.FillRect(0, 199, 240, MiamiNights.a.z + 5);
                            M.m_a(aB, GloftMMN.m_k(834), 120, 200, 17, 0);
                            if (K == 1)
                            {
                                m_a(true, false, false);
                            }

                            if (K > 1)
                            {
                                z = 82;
                            }
                            break;
                    }
                    if (y == -1)
                    {
                        return;
                    }

                    if (MiamiNights.f.d && y != 20)
                    {
                        aB.SetClip(0, 75, 240, 240);
                        aB.SetColor(0);
                        aB.FillRect(0, 75, 240, 240);
                        if (z == -1)
                        {
                            MiamiNights.f.d = false;
                        }
                    }
                    else if (y == 18)
                    {
                        if (K == 0)
                        {
                            aB.SetClip(0, 0, 240, 400);
                            v[5].d_.m_a(aB, 3, 0, v[5].a >> 8, v[5].b >> 8, 0, 0, 0);
                        }

                        if (!m_a(L, 0) && !k)
                        {
                            L = L + (int)aH;
                        }
                        else
                        {
                            L = 0;
                            z = 20;
                        }
                    }
                    else if (y == 20)
                    {
                        if (L == 0)
                        {
                            MiamiNights.f.bd = 0;
                            L = 1;
                        }
                        else if (L == 1)
                        {
                            MiamiNights.f.m_a(aB, H);
                        }
                    }
                    else if (y == 19)
                    {
                        if (z == -1)
                        {
                            if (N[0] >= 0)
                            {
                                aB.SetClip(0, 0, 240, 400);
                                aB.SetColor(0);
                                aB.FillRect(0, 0, 240, 400);
                            }
                            else if (!m_a(L, 1) && !k)
                            {
                                L = L + (int)aH;
                            }
                            else
                            {
                                z = 0;
                                MiamiNights.f.m_a(aB, true, true);
                                Console.WriteLine("TTTTTTTTTTTTTTTTTTT");
                                v[6].m_a(aB);
                            }
                        }
                    }
                    else if (y != 67)
                    {
                        if (y == 17)
                        {
                            if (K == 0)
                            {
                                MiamiNights.f.m_a(aB, false, true);
                            }

                            MiamiNights.g.m_b(aB);
                        }

                        bool var193 = y == 8 || y == 68;
                        if (X != 1 && !var193)
                        {
                            int var203 = K % 10;
                            if (k)
                            {
                                MiamiNights.f.m_a(aB, true, true);
                            }

                            bool var224 = (MiamiNights.g.ae & 256) == 256;
                            aB.SetClip(0, 0, 240, 400);
                            d var233 = v[5];
                            d var242 = v[6];
                            if (var224 && y == 0 && K != 0 && !k && z <= 0)
                            {
                                var233.d_.m_a(aB, 3, 0, v[5].a >> 8, v[5].b >> 8, 0, 0, 0);
                                var233.m_a(1);
                                var233.m_a(aB);
                                var242.m_a(5);
                                var242.g = var233.g;
                                var242.f = var233.f;
                                var242.m_a(aB);
                                var233.m_b();
                            }
                            else
                            {
                                var242.m_a(4);
                                if (y != 3 && y != 4 && y != 16 && y != 34 && y != 32 && y != 73 && y != 35 && y != 81 && y != 74 && y != 75)
                                {
                                    if (var233.e == 1 || K == 0)
                                    {
                                        var233.d_.m_a(aB, 3, 0, v[5].a >> 8, v[5].b >> 8, 0, 0, 0);
                                        var233.m_a(0);
                                        var233.m_a(aB);
                                    }

                                    aB.SetClip(0, 0, 240, 400);
                                    var242.m_a(aB);
                                }
                            }

                            if ((var203 & 1) == 0 || k)
                            {
                                MiamiNights.f.m_b(aB);
                            }

                            MiamiNights.f.m_i();
                            if (y != 1 || N[0] < 0)
                            {
                                if (var203 != 0 && y != 5 && !k)
                                {
                                    MiamiNights.f.m_c(aB, true);
                                }
                                else if (z < 0)
                                {
                                    if (y != 5 && !k)
                                    {
                                        MiamiNights.f.m_c(aB, K % 40 != 0);
                                    }
                                    else
                                    {
                                        MiamiNights.f.m_c(aB, false);
                                    }
                                }

                                if (z < 0)
                                {
                                    MiamiNights.f.m_d(aB, y == 6);
                                }

                                if (y == 0)
                                {
                                    MiamiNights.g.m_a(aB);
                                }
                            }

                            if (y == 13)
                            {
                                if (MiamiNights.g.ar > 0)
                                {
                                    MiamiNights.g.m_a(aB, false, 103, false);
                                    MiamiNights.g.m_a(aB, true, 103, false);
                                }
                                else
                                {
                                    MiamiNights.g.m_a(aB, false, 195, false);
                                }

                                MiamiNights.g.R = 0L;
                            }
                            else if (y == 11 || y == 12 || y == 14 || y == 7 && MiamiNights.f.av != -1 || MiamiNights.g.p != 0L && MiamiNights.f.av != -1 && y != 16 && y != 17)
                            {
                                if (y == 0 && v[2].e != 3)
                                {
                                    MiamiNights.g.R = 0L;
                                }
                                else
                                {
                                    MiamiNights.g.m_a(aB, false, 195, y == 0);
                                }
                            }

                            if (MiamiNights.f.au != -1 && y == 3)
                            {
                                aB.SetClip(0, 75, 240, 240);
                                int var257;
                                int var262 = MiamiNights.f.m_i(var257 = MiamiNights.f.aX[B], 5);
                                int var265;
                                if ((var265 = MiamiNights.f.m_g(MiamiNights.f.m_i(var257, 5), 2)) > 0)
                                {
                                    MiamiNights.g.m_a(aB, 0, 78, 120, 21, 13092848, 16777215, 0);
                                    M.m_a(aB, MiamiNights.f.m_a(var265 * 60L, false), 3, 80, 20, 1);
                                }

                                int var251 = MiamiNights.f.ao[MiamiNights.f.m_g(var262, -1)];
                                if ((var251 = MiamiNights.f.m_a(s[0], MiamiNights.f.an, var251 + 6, false, true)) > 0)
                                {
                                    MiamiNights.g.m_a(aB, 120, 78, 120, 21, 16768667, 16777215, 0);
                                    M.m_a(aB, "-" + MiamiNights.f.m_e(var251) + "$", 237, 80, 24, 1);
                                }
                            }
                        }
                    }

                    if (h_ == 8)
                    {
                        K++;
                        if (z >= 0)
                        {
                            y = z;
                            z = -1;
                            K = 0;
                        }
                    }

                    aB.SetClip(0, 0, 240, 400);
                    if (StatsPanel.Visible && y == 0 && z < 0)
                    {
                        StatsPanel.Draw(aB);   // added: Sims-style player stats panel (last draw, nothing overwrites it)
                    }

                    if (ak != 0)
                    {
                        aB.SetColor(0);
                        aB.FillRect(43, 16, 132, 50);
                        aB.SetColor(16777215);
                        aB.DrawString(aq[ak], 43, 16, 20);
                    }

                    switch (ak)
                    {
                        case 0:
                        case 1:
                        default:
                            break;
                        case 2:
                            int var195 = 16 + aB.GetFont().Height;
                            aB.SetColor(65280);
                            aB.DrawString(GloftMMN.m_k(180 + an[al]) + "=" + s[0].a[an[al]], 43, var195, 20);
                            break;
                        case 3:
                            int var194 = 16 + aB.GetFont().Height;
                            if (MiamiNights.f.av == -1)
                            {
                                aB.SetColor(16711680);
                                aB.DrawString("no one there !", 43, var194, 20);
                            }
                            else
                            {
                                g var204;
                                if ((var204 = s[MiamiNights.f.av]).a[42] > 0)
                                {
                                    aB.SetColor(16711680);
                                    aB.DrawString("love=" + var204.a[39] + "/100", 43, var194, 20);
                                }
                                else
                                {
                                    aB.SetColor(16776960);
                                    aB.DrawString("friendship=" + var204.a[39] + "/100", 43, var194, 20);
                                }
                            }
                            break;
                    }

                    if ((y == 22 || y == 32) && i >= 0)
                    {
                        if (K == 0)
                        {
                            MiamiNights.f.m_a(aB, false, true);
                        }

                        m_a(aB, false, false);
                    }
                    break;
                case 15:
                    m_b();
                    aB.SetColor(0);
                    aB.FillRect(0, 0, 240, 400);
                    k = true;
                    d var92 = v[7];
                    d var102 = v[2];
                    if (k)
                    {
                        MiamiNights.f.m_a(aB, true, true);
                        int var111 = var92.e;
                        MiamiNights.f.m_c(aB, false);
                        var92.m_a(var111);
                        var92.m_a(aB);
                    }

                    if (i == -1)
                    {
                        aB.SetClip(0, 0, 240, 400);
                        aB.SetColor(0);
                        aB.FillRect(0, 0, 240, 400);
                        i = -2;
                        MiamiNights.f.m_a(aB, false, true);
                    }

                    if (i == -2)
                    {
                        MiamiNights.f.m_b();
                        MiamiNights.f.m = null;
                        MiamiNights.f.aj = null;
                        sbyte var112 = 1;
                        if (MiamiNights.f.m_l())
                        {
                            var112 = 0;
                        }
                        else if (MiamiNights.f.m_j())
                        {
                            var112 = 3;
                        }
                        else if (MiamiNights.f.m_k())
                        {
                            var112 = 2;
                        }

                        GloftMMN.m_b("/1");
                        MiamiNights.a.v = new int[16384];
                        m_a(0, u, 5, false, true, 4, true);
                        u[5].m_a(var112, 0, -1, -1, 0);
                        MiamiNights.a.v = null;
                        GloftMMN.m_f();
                        i = MiamiNights.g.h[H];
                        y = 30;
                        k = true;
                        MiamiNights.f.m_a(aB, true, true);
                        MiamiNights.f.m_c(aB, false);
                        var92.m_a(32);
                        var92.a = 30720;
                        var92.b = 51200;
                        var102.e = -1;
                    }
                    else if (i <= -3)
                    {
                        m_a(aB, false, false);
                        MiamiNights.g.m_b(aB);
                        if (aP)
                        {
                            GloftMMN.m_c(3);
                            y = 30;
                            i = -i - 3;
                        }
                    }
                    else
                    {
                        U[2] = 783 + i;
                        if (aC[13] < 0)
                        {
                            GloftMMN.m_c(3);
                            m_a(8);
                            y = 20;
                            Y = true;
                            L = 0;
                        }

                        if (y == 31)
                        {
                            m_a(false);
                            m_a(aB, false, false);
                            if (aP || aC[14] < 0)
                            {
                                if (U[0] == U[1] - 1)
                                {
                                    y = 30;
                                    MiamiNights.f.m_a(aB, true, true);
                                    k = true;
                                }
                                else
                                {
                                    int var113 = R[U[0]] - 141;
                                    if (MiamiNights.g.ah[var113] == 0)
                                    {
                                        i *= -1;
                                        i -= 3;
                                        MiamiNights.g.m_a(867);
                                        k = true;
                                    }
                                    else
                                    {
                                        int var118 = MiamiNights.g.i[MiamiNights.g.h[H] * 7 + i] & 0xFF;
                                        MiamiNights.f.aT += var118 * 60L * 1000L / 60L;
                                        MiamiNights.f.m_c(null, true);
                                        H = var113;
                                        m_a(8);
                                        y = 20;
                                        L = 0;
                                    }
                                }
                            }
                        }
                        else if (y == 30)
                        {
                            var92.m_a(aB);
                            bool var114 = aC[3] < 0;
                            bool var119 = aC[4] < 0;
                            bool var127 = aC[1] < 0;
                            bool var136 = aC[2] < 0;
                            sbyte[] var160 = new sbyte[]{ 6, 1, 3, 3, 0, 2, 0, 4, 1, 5, 1, 5, 0, 4, 0, 0, 3, 5, 1, 0, 4, 6, 2, 0, 5, 0, 2, 0 };
                            int var178 = i;
                            int var186 = i;
                            if (var114)
                            {
                                var186 = var160[i * 4 + 0];
                            }
                            else if (var119)
                            {
                                var186 = var160[i * 4 + 1];
                            }
                            else if (var127)
                            {
                                var186 = var160[i * 4 + 2];
                            }
                            else if (var136)
                            {
                                var186 = var160[i * 4 + 3];
                            }

                            if (var186 != var178)
                            {
                                var102.e = -1;
                                i = var186;
                            }

                            int var198 = 0;

                            for (int var216 = 0; var216 < 2; var216++)
                            {
                                for (int var80 = 0; var80 < MiamiNights.g.h.Length; var80++)
                                {
                                    sbyte var227 = MiamiNights.g.g_[var80];
                                    if (MiamiNights.g.h[var227] == i && MiamiNights.g.f[var227] == 1)
                                    {
                                        if (var216 == 1)
                                        {
                                            R[var198] = 141 + var227;
                                            if (MiamiNights.f.bc[25] != -1)
                                            {
                                                sbyte var235 = MiamiNights.f.bc[24];
                                                if (var227 == var235)
                                                {
                                                    S[var198] = 7;
                                                }
                                            }

                                            if (MiamiNights.g.ah[var227] == 0)
                                            {
                                                S[var198] = 25;
                                            }
                                        }

                                        var198++;
                                    }
                                }

                                if (var216 == 0)
                                {
                                    m_a(var198, 0, true);
                                    R[var198] = 400;
                                    var198 = 0;
                                }
                            }

                            U[3] = 401;
                            U[5] = -1;
                            if ((aP || aC[14] < 0) && !var114 && !var127 && !var119 && !var136)
                            {
                                y = 31;
                            }

                            m_a(aB, true, false);
                            sbyte var228 = MiamiNights.g.h[H];
                            int var236 = i;
                            int var247;
                            if ((var247 = MiamiNights.g.i[var228 * 7 + var236] & 0xFF) > 0)
                            {
                                MiamiNights.g.m_a(aB, 120, 288, 120, 21, 13092848, 16777215, 0);
                                M.m_a(aB, MiamiNights.f.m_a(var247 * 60L, false), 123, 290, 20, 1);
                            }
                        }
                    }

                    aB.SetClip(0, 0, 240, 400);
                    if (var102.e == -1)
                    {
                        var102.m_a(2);
                    }

                    if (h_ != 15)
                    {
                        u[5] = null;
                        Q = null;
                        GC.Collect();
                    }

                    K++;
                    return;
                case 16:
                    long var110 = 0L;
                    d var123 = v[7];
                    switch (y)
                    {
                        case -1:
                            GloftMMN.m_c(3);
                            m_a(8);
                            y = 0;
                            MiamiNights.f.m_a(aB, true, true);
                            MiamiNights.g.p = 1000L;
                            MiamiNights.f.be = null;
                            K = 0;
                            break;
                        case 24:
                            m_b();
                            if (K == 0 || k)
                            {
                                var123.a = 30720;
                                var123.b = 50176;
                                var123.m_a(13);
                                var123.m_a(aB);
                            }

                            if (aC[13] < 0 || aP)
                            {
                                y = -1;
                                if ((MiamiNights.g.ae & 512) != 0)
                                {
                                    bF[2] = 0;
                                    bF[3] = 0;
                                    bF[4] = 0;
                                    bF[0] = 0;
                                    bF[1] = 0;
                                    y = 25;
                                    K = -1;
                                    MiamiNights.g.ae |= -513;
                                }
                            }
                            break;
                        case 25:
                            if (K == 0 || k)
                            {
                                var123.a = 30720;
                                var123.b = 51200;
                                var123.m_a(15);
                                var123.m_a(aB);
                            }

                            if (bF[1] == 1)
                            {
                                m_a(false);
                                m_a(aB, false, false);
                                if (aP)
                                {
                                    MiamiNights.g.m_f(11, 1 + U[0]);
                                    y = -1;
                                }
                            }
                            else
                            {
                                (var123 = v[9]).m_a(17);
                                var123.a = 30720;
                                var123.b = 51200;
                                var123.m_a(aB);
                                var123.m_b();
                                m_b();
                                m_a(var123);
                                m_b(0, 200, 240, 400, 3, 0);
                                bF[2 + bF[0]] = 1;
                                if (aP)
                                {
                                    if (bF[2] + bF[3] + bF[4] == 3)
                                    {
                                        m_a(3, 0, false);
                                        R[0] = s[1].a[1];
                                        R[1] = s[2].a[1];
                                        R[2] = s[3].a[1];
                                        U[2] = 812;
                                        U[3] = 813;
                                        U[5] = 25;
                                        bF[1] = 1;
                                    }
                                    else
                                    {
                                        aC[4] = -1;
                                    }
                                }

                                if (aC[3] < 0)
                                {
                                    K = -1;
                                    bF[0]--;
                                    if (bF[0] < 0)
                                    {
                                        bF[0] = 2;
                                    }
                                }

                                if (aC[4] < 0)
                                {
                                    K = -1;
                                    bF[0]++;
                                    bF[0] = bF[0] % 3;
                                }
                            }
                            break;
                        case 26:
                            m_b();
                            aB.SetClip(0, 0, 240, 400);
                            bool var132 = k;
                            if (K == 0)
                            {
                                var132 = true;
                                bF[0] = 0;
                            }

                            if (V == null)
                            {
                                int var156 = 0;

                                for (int var176 = 0; var176 < 2; var176++)
                                {
                                    for (int var79 = 0; var79 < s[0].a.Length; var79++)
                                    {
                                        if ((MiamiNights.g.m_d(var79, 1) & 1) != 1)
                                        {
                                            if (var176 == 1)
                                            {
                                                V[var156] = var79;
                                            }

                                            var156++;
                                        }
                                    }

                                    if (var176 == 0)
                                    {
                                        V = new int[var156];
                                        var156 = 0;
                                    }
                                }
                            }

                            if (aC[1] < 0)
                            {
                                var132 = true;
                                bF[0] = bF[0] - 2;
                                if (bF[0] < 0)
                                {
                                    bF[0] = 0;
                                }
                            }

                            if (aC[2] < 0)
                            {
                                var132 = true;
                                bF[0] = bF[0] + 2;
                                if (bF[0] >= V.Length - 1 - 3)
                                {
                                    bF[0] = V.Length - 1 - 3;
                                }
                            }

                            if (var132)
                            {
                                var123.a = 30720;
                                var123.b = 50176;
                                var123.m_a(18);
                                var123.m_a(aB);
                            }

                            (var123 = v[9]).m_a(19);
                            var123.a = 30720;
                            var123.b = 51200;
                            int[] var157;
                            m_b(((var157 = var123.m_c())[0] >> 8) - 20, var157[1] >> 8, (var157[2] - var157[0] >> 8) + 40, var157[3] - var157[1] >> 1 >> 8, 4, 0);
                            m_b((var157[0] >> 8) - 20, var157[1] + var157[3] >> 1 >> 8, (var157[2] - var157[0] >> 1 >> 8) + 40, var157[3] - var157[1] >> 1 >> 8, 5, 0);
                            var123.m_a(aB);
                            var123.m_b();
                            if (aC[13] < 0 || aC[6] < 0)
                            {
                                y = -1;
                            }
                            break;
                        case 27:
                            m_b();
                            g var175 = null;
                            int var185 = bF[1];
                            int var197 = -1;
                            if (var185 >= 0)
                            {
                                var197 = MiamiNights.g.G[var185];
                            }

                            if (var197 >= 0)
                            {
                                var175 = s[var197];
                            }

                            if (K >= 2 && !k)
                            {
                                if (U[1] > 0)
                                {
                                    m_a(aB, false, false);
                                    m_a(false);
                                    if (aC[14] < 0 || aP)
                                    {
                                        if (U[0] == U[1] - 1)
                                        {
                                            K = -1;
                                        }
                                        else
                                        {
                                            bF[3] = R[U[0]] - 141;
                                            U[1] = -1;
                                            if (MiamiNights.f.bc[25] > 0)
                                            {
                                                MiamiNights.g.m_a(GloftMMN.m_k(882), (sbyte)40);
                                            }
                                            else
                                            {
                                                MiamiNights.g.m_a(GloftMMN.m_k(878) + GloftMMN.m_k(var175.a[1]) + GloftMMN.m_k(877) + GloftMMN.m_k(141 + bF[3]) + GloftMMN.m_k(879), (sbyte)40);
                                            }

                                            i = 0;
                                        }
                                    }
                                    break;
                                }

                                if (U[1] < 0)
                                {
                                    m_a(aB);
                                    if (aP)
                                    {
                                        if (i == 0)
                                        {
                                            K = -1;
                                        }
                                        else if (i == 1)
                                        {
                                            MiamiNights.f.bc[25] = (sbyte)var197;
                                            MiamiNights.f.bc[24] = (sbyte)bF[3];
                                            MiamiNights.g.m_a(GloftMMN.m_k(var175.a[1]) + GloftMMN.m_k(876) + GloftMMN.m_k(141 + bF[3]));
                                            MiamiNights.g.au = true;
                                            y = -1;
                                        }
                                    }
                                    break;
                                }

                                var123.a = 30720;
                                var123.b = 50176;
                                var123.m_a(20);
                                int[] var215 = var123.m_c(11);
                                var123.a = var215[0] << 8;
                                int var226 = 0;

                                int var78;
                                for (var78 = 0; var78 < MiamiNights.g.G.Length && MiamiNights.g.G[var78] >= 1; var78++)
                                {
                                    aB.SetClip(0, 0, 240, 400);
                                    g var91;
                                    if (MiamiNights.f.m_d((var91 = s[MiamiNights.g.G[var78]]).b[13]) == -1)
                                    {
                                        if (bF[2] == var226)
                                        {
                                            var123.m_a(21);
                                            bF[1] = var78;
                                        }
                                        else
                                        {
                                            var123.m_a(22 + var226 % 2);
                                        }

                                        int[] var246 = var123.m_c();
                                        GloftMMN.m_k(var91.a[1]);
                                        bF[0] = var78;
                                        var123.b = (var215[1] << 8) + var226 * (var246[3] - var246[1]);
                                        int[] var155;
                                        m_b((var155 = var123.m_c())[0] >> 8, var155[1] >> 8, var155[2] - var155[0] >> 8, var155[3] - var155[1] >> 8, 22, var226);
                                        if (bF[0] == bF[1] || bF[0] == bF[4] || K <= 3 || bF[4] == -1)
                                        {
                                            var123.m_a(aB);
                                        }

                                        var226++;
                                    }
                                }

                                if (bF[4] == -1)
                                {
                                    bF[4] = 0;
                                }

                                if (var78 == 0)
                                {
                                    @as = true;
                                    M.m_a(aB, GloftMMN.m_k(805), 120, 200, 3, 0);
                                }
                                else
                                {
                                    @as = false;
                                }

                                if (var226 > 0)
                                {
                                    if (aC[1] < 0)
                                    {
                                        bF[4] = bF[1];
                                        bF[2]--;
                                    }

                                    if (aC[2] < 0)
                                    {
                                        bF[4] = bF[1];
                                        bF[2]++;
                                    }

                                    if (bF[2] < 0)
                                    {
                                        bF[2] = var226 - 1;
                                    }

                                    bF[2] = bF[2] % var226;
                                    if (MiamiNights.f.bc[31] == 0 && (MiamiNights.g.ah[14] == 1 || MiamiNights.g.ah[7] == 1 || MiamiNights.g.ah[28] == 1) && (aC[14] < 0 || aP))
                                    {
                                        m_a(2, 0, true);
                                        U[2] = 802;
                                        U[3] = 791;
                                        U[5] = -1;
                                        R[0] = 908;
                                        R[1] = 909;
                                        z = 77;
                                    }
                                }

                                if (aC[13] < 0 || aC[6] < 0)
                                {
                                    y = -1;
                                }
                                break;
                            }

                            Console.WriteLine("------------- CONTACT LIST INIT ------------------");
                            Console.WriteLine("s_game_refreshAll=" + k);
                            var123.a = 30720;
                            var123.b = 50176;
                            var123.m_a(20);
                            var123.m_a(aB);
                            if (!k)
                            {
                                bF[2] = 0;
                                U[1] = 0;
                            }

                            int var214 = 0;

                            for (int var77 = 0; var77 < MiamiNights.g.G.Length && MiamiNights.g.G[var77] >= 1; var77++)
                            {
                                g var90;
                                if (MiamiNights.f.m_d((var90 = s[MiamiNights.g.G[var77]]).b[13]) == -1)
                                {
                                    var214++;
                                }
                            }

                            @as = var214 == 0;
                            bF[4] = -1;
                            break;
                        case 77:
                            m_a(aB, false, false);
                            m_a(false);
                            if (aC[14] >= 0 && !aP)
                            {
                                break;
                            }

                            if (U[0] == U[1] - 1)
                            {
                                U[1] = 0;
                                k = true;
                                y = 27;
                                K = -1;
                            }
                            else
                            {
                                if (U[0] == 0)
                                {
                                    m_a(3, 0, true);
                                    U[2] = 908;
                                    U[3] = 781;
                                    U[5] = -1;
                                    int var213 = 0;
                                    if (MiamiNights.f.bc[31] == 0)
                                    {
                                        if (MiamiNights.g.ah[7] == 1)
                                        {
                                            var213++;
                                            R[0] = 148;
                                        }

                                        if (MiamiNights.g.ah[28] == 1)
                                        {
                                            R[var213++] = 169;
                                        }

                                        if (MiamiNights.g.ah[14] == 1 && !MiamiNights.g.ai[14])
                                        {
                                            R[var213++] = 155;
                                        }

                                        if (var213 != 0)
                                        {
                                            R[var213] = 0;
                                            S[var213] = 21;
                                            var213++;
                                        }
                                    }

                                    U[1] = var213;
                                    k = true;
                                    y = 27;
                                    K = 0;
                                    break;
                                }

                                int var212 = MiamiNights.g.G[bF[1]];
                                g var174 = s[var212];
                                if (var212 != MiamiNights.f.bc[25] && var212 != MiamiNights.f.bc[26])
                                {
                                    i = 0;
                                    MiamiNights.g.m_a(GloftMMN.m_k(910) + "{" + GloftMMN.m_k(var174.a[1]) + "}", (sbyte)40);
                                    y = 78;
                                }
                                else
                                {
                                    MiamiNights.g.m_a(GloftMMN.m_k(911) + "{" + GloftMMN.m_k(var174.a[1]) + "} " + GloftMMN.m_k(912));
                                    y = 79;
                                }

                                K = 0;
                            }
                            break;
                        case 78:
                            m_a(aB);
                            if (!aP)
                            {
                                break;
                            }

                            if (i == 1)
                            {
                                g var173;
                                (var173 = s[MiamiNights.g.G[bF[1]]]).e = null;

                                int var211;
                                for (int var76 = var211 = bF[1]; var76 < 24; var76++)
                                {
                                    MiamiNights.g.G[var76] = MiamiNights.g.G[var76 + 1];
                                }
                            }

                            y = 27;
                            K = -1;
                            U[1] = 0;
                            k = true;
                            break;
                        case 79:
                            MiamiNights.g.m_b(aB);
                            if (aP)
                            {
                                MiamiNights.g.N.removeAllElements();
                                y = 27;
                                K = -1;
                                U[1] = 0;
                                k = true;
                            }
                            break;
                    }

                    aB.SetClip(0, 0, 240, 400);
                    if (h_ != 8 && (K == 0 || k))
                    {
                        if (y != 27 && y < 77)
                        {
                            MiamiNights.f.m_a(aB, true, true);
                        }
                        else
                        {
                            MiamiNights.f.m_a(aB, true, y < 77 && U[1] == 0);
                        }

                        int var133 = (var123 = v[7]).a;
                        int var158 = var123.b;
                        int var177 = var123.e;
                        var123.a = 30720;
                        var123.b = 51200;
                        MiamiNights.f.aV = -1;
                        MiamiNights.f.m_c(aB, false);
                        MiamiNights.g.H = -1;
                        MiamiNights.f.m_d(aB, false);
                        var123.a = var133;
                        var123.b = var158;
                        var123.e = var177;
                    }

                    if (h_ != 8 && y >= 0 && y != 77 && y != 78 && y != 79)
                    {
                        if (y != 25 && y > 0)
                        {
                            int var134 = y;
                            if (y > 25)
                            {
                                var134--;
                            }

                            var134 = 8 + (var134 - 24) * 2;
                            v[8].m_a(var134);
                            v[8].a = 30720;
                            v[8].b = 51200;
                            v[8].d_.m_a(aB, v[8].e - 1, 0, 120, 200, 0, 0, 0);
                            int[] var159;
                            m_a(
                               ((var159 = v[8].m_c())[0] >> 8) - 40,
                               (var159[1] >> 8) - 20,
                               (var159[2] - var159[0] >> 1 >> 8) + 40,
                               (var159[3] - var159[1] >> 8) + 40,
                               1,
                               52,
                               2,
                               52
                            );
                            m_a(
                               var159[0] + var159[2] >> 1 >> 8,
                               (var159[1] >> 8) - 20,
                               (var159[2] - var159[0] >> 1 >> 8) + 40,
                               (var159[3] - var159[1] >> 8) + 40,
                               1,
                               54,
                               2,
                               54
                            );
                            v[8].m_a(aB);
                            v[8].m_b();
                        }

                        if ((MiamiNights.g.ae & 512) == 0 && y != 25 && MiamiNights.g.ak == null)
                        {
                            if (aC[3] == 1)
                            {
                                z = (sbyte)(y - 1);
                                if (z == 25)
                                {
                                    z--;
                                }

                                if (z < 24)
                                {
                                    z = 27;
                                }
                            }

                            if (aC[4] == 1)
                            {
                                z = (sbyte)(y + 1);
                                if (z == 25)
                                {
                                    z++;
                                }

                                if (z > 27)
                                {
                                    z = 24;
                                }
                            }
                        }

                        if (z >= 0)
                        {
                            y = z;
                            z = -1;
                            K = 0;
                            return;
                        }

                        K++;
                        return;
                    }
                    break;
                case 17:
                    int[] var10000 = new int[] { 0, 0, 0, 0 };
                    object var75 = null;
                    int[] var89 = new int[] { 0, 0, 0, 0 };
                    g var109 = s[0];
                    d var117 = n[0];
                    d var122 = v[7];
                    d var131 = v[8];
                    aB.SetClip(0, 0, 240, 400);
                    if (!at)
                    {
                        Q = null;
                        MiamiNights.g.m_a(false);

                        for (int var96 = 4; var96 <= 10; var96 += 2)
                        {
                            var109.a[var96] = 0;
                            var109.a[var96 + 1] = 0;
                        }

                        var109.a[6] = 0;
                        var109.a[4] = 0;
                        var109.a[5] = 9;
                        var109.a[9] = 17;
                        var109.a[7] = 41;
                        var109.a[12] = 1;
                        int var97 = var109.a[9] / 8;
                        var109.a[9] = var97 * 8 + var109.a[12];
                        var97 = var109.a[7] / 8;
                        var109.a[7] = var97 * 8 + var109.a[12];
                        var109.m_a(7 + var109.a[0] * 2, 0, true);
                        af = GloftMMN.m_k(417);
                        i = 0;
                        k = true;

                        try
                        {
                            GloftMMN.m_b("/18");
                            GloftMMN.m_a(5);
                            GloftMMN.m_f();
                            GloftMMN.m_a(5, 1);
                        }
                        catch (Exception)
                        {
                        }

                        at = true;
                    }

                    if (i == -1 || k)
                    {
                        aB.SetColor(9806814);
                        aB.FillRect(0, 0, 240, 400);
                        if (k && af != null && af.IndexOf((char)45) != -1)
                        {
                            if (var109.a[0] == 0)
                            {
                                af = GloftMMN.m_k(402);
                            }
                            else
                            {
                                af = GloftMMN.m_k(417);
                            }
                        }

                        i = 0;
                        var122.a = 30720;
                        var122.b = 51200;
                        var122.m_a(33);
                        var122.m_a(aB);
                        MiamiNights.f.m_a(aB, true, true);
                    }

                    MiamiNights.g.j[0] = 0;
                    MiamiNights.g.j[1] = 0;
                    bool var154 = false;
                    bool var172 = false;
                    if (i != -1)
                    {
                        if (MiamiNights.g.ak != null)
                        {
                            m_a(aB);
                            aB.SetColor(0);
                            aB.FillRect(0, 317, 240, 25);
                            if (aP)
                            {
                                if (i == 0)
                                {
                                    MiamiNights.g.ak = null;
                                    i = -1;
                                }
                                else
                                {
                                    GloftMMN.m_b(5);
                                    MiamiNights.g.m_a(true);
                                    m_a(8);
                                    y = 67;
                                    K = 0;
                                    z = -1;
                                    i = 0;
                                }
                            }
                        }
                        else
                        {
                            m_b();
                            int var184;
                            int var196 = ((var184 = 7 + var109.a[0] * 2) - 7) / 2;
                            bool var210 = aC[3] == 1;
                            bool var225 = aC[4] == 1;
                            bool var234 = aC[1] == 1;
                            bool var245 = aC[2] == 1 || aP && i != 2 && i != 1;
                            if (i == 1 && aC[5] < 0)
                            {
                                i = 63;
                                bF[2] = 0;
                                bF[3] = -1;
                                bF[4] = -1;
                                bF[5] = -1;
                                af = "----------";
                                m_r();
                            }
                            else if (i != 63)
                            {
                                if (var234)
                                {
                                    i--;
                                }

                                if (var245)
                                {
                                    i++;
                                }

                                if (i < 0)
                                {
                                    i = 9;
                                }

                                if (i > 9)
                                {
                                    i = 0;
                                }
                            }

                            bool var253 = false;
                            int var259 = 0;   // CFR: int (VF byte mis-inference)
                            int[] var264 = null;
                            object var266 = null;
                            var122.a = 30720;
                            var122.b = 51200;
                            var122.e = -1;
                            var122.m_a(33);
                            sbyte var267 = -1;
                            int var270 = -1;
                            if (i == 3 || i == 6)
                            {
                                var267 = 5;
                            }

                            if (i == 4 || i == 7)
                            {
                                var267 = 2;
                            }

                            if (i == 5 || i == 8)
                            {
                                var267 = 4;
                            }

                            if (var267 != -1)
                            {
                                var270 = 1 + p[var196][var267].a_ / r[var196][var267];
                                if (var267 == 5)
                                {
                                    if (var109.a[0] == 0)
                                    {
                                        var270 += MiamiNights.g.X.Length - 1;
                                    }
                                    else
                                    {
                                        var270 += MiamiNights.g.Y.Length - 1;
                                    }
                                }

                                bF[0] = var270;
                                bF[1] = var267;
                            }

                            if (i == 0)
                            {
                                var259 = 35;
                                var264 = var122.m_c(26);
                                if (var210 || var225)
                                {
                                    if (var109.a[0] == 1 && string.CompareOrdinal(af, GloftMMN.m_k(417)) == 0)
                                    {
                                        af = GloftMMN.m_k(402);
                                    }
                                    else if (var109.a[0] == 0 && string.CompareOrdinal(af, GloftMMN.m_k(402)) == 0)
                                    {
                                        af = GloftMMN.m_k(417);
                                    }

                                    var109.a[0] = (var109.a[0] + 1) % 2;
                                    var196 = ((var184 = 7 + var109.a[0] * 2) - 7) / 2;
                                    var117.d_ = o[var196];

                                    for (int var101 = 4; var101 <= 10; var101 += 2)
                                    {
                                        var109.a[var101] = 0;
                                        var109.a[var101 + 1] = 0;
                                    }

                                    var109.a[4] = 0;
                                    var109.a[5] = 9;
                                    var109.a[9] = 17;
                                    var109.a[7] = 41;
                                    var253 = true;
                                }
                            }
                            else if (i == 1)
                            {
                                var259 = 37;
                                var264 = var122.m_c(28);
                            }
                            else if (i == 63)
                            {
                                aI = true;
                                var253 = false;
                                char[][] var280 = new char[][]{
                                   new char[]{ 'A', 'B', 'C', 'D', 'E' },
                                   new char[]{ 'F', 'G', 'H', 'I', 'J' },
                                   new char[]{ 'K', 'L', 'M', 'N', 'O' },
                                   new char[]{ 'P', 'Q', 'R', 'S', 'T' },
                                   new char[]{ 'U', 'V', 'W', 'X', 'Y' },
                                   new char[]{ 'Z', ' ', ' ' }
                                };
                                var259 = 37;
                                var264 = var122.m_c(28);
                                MiamiNights.f.m_a(aB, false, true);
                                aB.SetColor(16775323);
                                aB.FillRect(0, 70, 240, 36);
                                bool var283 = false;
                                bool var289 = false;
                                aB.SetClip(0, 160, 240, 201);
                                string var292 = " ";
                                short var300 = 0;
                                switch (var292.Length)
                                {
                                    case 4:
                                        var300 = 198;
                                        break;
                                    case 5:
                                        var300 = 205;
                                        break;
                                    case 6:
                                        var300 = 212;
                                        break;
                                    case 7:
                                        var300 = 220;
                                        break;
                                    default:
                                        var300 = 205;
                                        break;
                                }

                                if (aJ.Length <= 9)
                                {
                                    if (aI)
                                    {
                                        aB.SetColor(16777068);
                                        aB.FillRect(0, 160, 240, 200);

                                        for (int var314 = 0; var314 < 6; var314++)
                                        {
                                            int var324 = 160 + var314 * 28 + (var314 + 1) * 4;

                                            for (int var333 = 0; var333 < 5; var333++)
                                            {
                                                int var338 = 0 + var333 * 44 + (var333 + 1) * 4;
                                                if (var314 == 5 && var333 >= 3)
                                                {
                                                    aB.SetColor(3368601);
                                                    m_drawRoundRect(aB, var338, var324, 86, 28, 8, 8);   // original aB.drawRoundRect
                                                    break;
                                                }

                                                if (var280[var314][var333] != ' ')
                                                {
                                                    aB.SetColor(3368601);
                                                    m_drawRoundRect(aB, var338, var324, 42, 28, 8, 8);   // original aB.drawRoundRect
                                                    aB.SetColor(0);
                                                    M.m_a(aB, var280[var314][var333] + "", var338 + 24, var324 + 8, 24, 1);
                                                }
                                            }
                                        }

                                        aB.SetColor(0);
                                        M.m_a(aB, GloftMMN.m_k(937), var300, 330, 24, 1);
                                    }

                                    if (bB > -1 && bC > -1 && bB >= 4 && bB <= 244 && bC >= 160 && bC <= 358)
                                    {
                                        int var315 = (bB - 4) / 48;
                                        int var325 = (bC - 164) / 32;
                                        // Java: af.length(); (statement no-op - dropped, invalid as C# statement)
                                        char[] var334 = null;
                                        var334 = af.ToCharArray();

                                        for (int var339 = 0; var339 < var334.Length; var339++)
                                        {
                                            if (var334[var339] == 45)
                                            {
                                                if (var325 < var280.Length && var315 < var280[var325].Length)
                                                {
                                                    if (var280[var325][var315] != ' ')
                                                    {
                                                        var334[var339] = var280[var325][var315];
                                                    }
                                                    break;
                                                }

                                                var334[var339] = (char)32;
                                                break;
                                            }
                                        }

                                        af = new string(var334);
                                        af.Trim();   // Java: af.trim(); (result discarded)
                                        bB = -1;
                                        bC = -1;
                                    }
                                }

                                if (bz > -1 && bA > -1 && bz >= 4 && bz <= 244 && bA >= 160 && bA <= 358)
                                {
                                    int var316 = (bz - 4) / 48;
                                    int var326 = (bA - 164) / 32;
                                    if (bz >= 148 && bz <= 236 && bA >= 325 && bA <= 358)
                                    {
                                        if (4 * (var316 + 1) + 44 * var316 >= 195)
                                        {
                                            var316--;
                                        }

                                        aB.SetColor(0);
                                        m_drawRoundRect(aB, 4 * (var316 + 1) + 44 * var316, 160 + 4 * (var326 + 1) + 28 * var326, 88, 28, 8, 8);   // original aB.drawRoundRect
                                        aB.SetColor(16755359);
                                        m_fillRoundRect(aB, 4 * (var316 + 1) + 44 * var316, 160 + 4 * (var326 + 1) + 28 * var326, 88, 28, 8, 8);   // original aB.fillRoundRect
                                        aB.SetColor(0);
                                        M.m_a(aB, GloftMMN.m_k(937), var300, 330, 24, 1);
                                    }
                                    else if (var326 != 5 || var316 < 1)
                                    {
                                        aB.SetColor(0);
                                        m_drawRoundRect(aB, 4 * (var316 + 1) + 44 * var316, 160 + 4 * (var326 + 1) + 28 * var326, 44, 28, 8, 8);   // original aB.drawRoundRect
                                        aB.SetColor(16755359);
                                        m_fillRoundRect(aB, 4 * (var316 + 1) + 44 * var316, 160 + 4 * (var326 + 1) + 28 * var326, 44, 28, 8, 8);   // original aB.fillRoundRect
                                        aB.SetColor(0);
                                        int var336 = 0 + var316 * 44 + (var316 + 1) * 4;
                                        int var340 = 160 + var326 * 28 + (var326 + 1) * 4;
                                        M.m_a(aB, var280[var326][var316] + "", var336 + 24, var340 + 8, 24, 1);
                                    }
                                }

                                if (aC[13] < 0)
                                {
                                    int var318;
                                    if ((var318 = af.IndexOf((char)45)) < 0)
                                    {
                                        var318 = af.Length;
                                    }

                                    if (--var318 >= 0)
                                    {
                                        // Java: af.length(); (statement no-op - dropped, invalid as C# statement)
                                        object var327 = null;
                                        var327 = af.ToCharArray();
                                        ((char[])var327)[var318] = (char)45;
                                        af = new string((char[])var327);
                                    }
                                }
                                else if (aC[14] < 0 || aP && aQ)
                                {
                                    int var317;
                                    if ((var317 = af.IndexOf((char)45)) >= 0)
                                    {
                                        af = af.Substring(0, var317);
                                    }

                                    if (af.Trim().Length <= 2)
                                    {
                                        if (var109.a[0] == 1)
                                        {
                                            af = GloftMMN.m_k(417);
                                        }
                                        else
                                        {
                                            af = GloftMMN.m_k(402);
                                        }

                                        i = 1;
                                    }
                                    else
                                    {
                                        i = 2;
                                    }

                                    aB.SetColor(9806814);
                                    aB.FillRect(0, 0, 240, 400);
                                    var122.a = 30720;
                                    var122.b = 51200;
                                    var122.m_a(33);
                                    var122.m_a(aB);
                                    MiamiNights.f.m_a(aB, true, true);
                                    aB.SetColor(9806814);
                                    aB.FillRect(0, 70, 240, 36);
                                    aB.SetColor(9806814);
                                    aB.FillRect(0, 139, 237, 127);
                                    aI = false;
                                    m_r();
                                    var172 = true;
                                }
                            }
                            else if (i == 2)
                            {
                                var259 = 38;
                                var264 = var122.m_c(32);
                                if (aP)
                                {
                                    int var277 = 1 + p[var196][5].a_ / r[var196][5];
                                    if (var109.a[0] == 0)
                                    {
                                        var277 += MiamiNights.g.X.Length - 1;
                                    }
                                    else
                                    {
                                        var277 += MiamiNights.g.Y.Length - 1;
                                    }

                                    var277--;
                                    if (var109.a[0] == 0)
                                    {
                                        var277--;
                                    }

                                    var109.a[4] = GloftMMN.m_c(0, var277);
                                    var109.a[5] = GloftMMN.m_c(0, p[var196][5].l);
                                    bool var282 = false;
                                    var109.a[6] = GloftMMN.m_c(0, a[var196].Length / 3 + -4);
                                    var109.a[7] = GloftMMN.m_c(0, p[var196][2].l);
                                    var109.a[8] = GloftMMN.m_c(0, p[var196][4].a_ / r[var196][4]);
                                    var109.a[9] = GloftMMN.m_c(0, p[var196][4].l);
                                    var253 = true;
                                }
                            }
                            else if (i == 3)
                            {
                                var259 = 39;
                                var264 = var122.m_c(34);
                                if (var210)
                                {
                                    var109.a[4]--;
                                }

                                if (var225)
                                {
                                    var109.a[4]++;
                                }

                                sbyte var276 = -2;
                                if (var109.a[0] == 0)
                                {
                                    var276 = -3;
                                }

                                if (var109.a[4] < 0)
                                {
                                    var109.a[4] = var270 + var276;
                                }

                                if (var109.a[4] > var270 + var276)
                                {
                                    var109.a[4] = 0;
                                }

                                if (var210 || var225)
                                {
                                    var253 = true;
                                }
                            }
                            else if (i == 4)
                            {
                                var259 = 39;
                                (var264 = var122.m_c(34))[1] += 21;
                                int var274 = a[var196].Length / 3;
                                var274 -= 4;
                                if (var210)
                                {
                                    var109.a[6]--;
                                }

                                if (var225)
                                {
                                    var109.a[6]++;
                                }

                                if (var109.a[6] < 0)
                                {
                                    var109.a[6] = var274 - 1;
                                }

                                if (var109.a[6] > var274 - 1)
                                {
                                    var109.a[6] = 0;
                                }

                                if (var210 || var225)
                                {
                                    var253 = true;
                                }
                            }
                            else if (i == 5)
                            {
                                var259 = 39;
                                (var264 = var122.m_c(34))[1] += 42;
                                if (var210)
                                {
                                    var109.a[8]--;
                                }

                                if (var225)
                                {
                                    var109.a[8]++;
                                }

                                if (var109.a[8] < -1)
                                {
                                    var109.a[8] = var270 - 2;
                                }

                                if (var109.a[8] >= var270 - 1)
                                {
                                    var109.a[8] = -1;
                                }

                                if (var210 || var225)
                                {
                                    var253 = true;
                                }
                            }
                            else if (i == 6)
                            {
                                var259 = 42;
                                var264 = var122.m_c(34);
                                int var273 = p[var196][5].l;
                                if (var210)
                                {
                                    var109.a[5]--;
                                }

                                if (var225)
                                {
                                    var109.a[5]++;
                                }

                                if (var109.a[5] < 0)
                                {
                                    var109.a[5] = var273 - 1;
                                }

                                if (var109.a[5] > var273 - 1)
                                {
                                    var109.a[5] = 0;
                                }

                                if (var210 || var225)
                                {
                                    var253 = true;
                                }
                            }
                            else if (i == 7)
                            {
                                var259 = 42;
                                (var264 = var122.m_c(34))[1] += 21;
                                int var272 = p[var196][2].l;
                                if (var210)
                                {
                                    var109.a[7] = var109.a[7] - 8;
                                }

                                if (var225)
                                {
                                    var109.a[7] = var109.a[7] + 8;
                                }

                                if (var109.a[7] < 1)
                                {
                                    var109.a[7] = var272 - 8 + 1;
                                }

                                if (var109.a[7] > var272 - 1)
                                {
                                    var109.a[7] = 1;
                                }

                                if (var210 || var225)
                                {
                                    var253 = true;
                                }
                            }
                            else if (i == 8)
                            {
                                var259 = 42;
                                (var264 = var122.m_c(34))[1] += 42;
                                int var271 = p[var196][4].l;
                                if (var210)
                                {
                                    var109.a[9] = var109.a[9] - 8;
                                }

                                if (var225)
                                {
                                    var109.a[9] = var109.a[9] + 8;
                                }

                                if (var109.a[9] < 1)
                                {
                                    var109.a[9] = var271 - 8 + 1;
                                }

                                if (var109.a[9] > var271 - 1)
                                {
                                    var109.a[9] = 1;
                                }

                                if (var210 || var225)
                                {
                                    var253 = true;
                                }
                            }
                            else if (i == 9)
                            {
                                var259 = 45;
                                var264 = var122.m_c(41);
                                if (var210)
                                {
                                    var109.a[12]--;
                                }

                                if (var225)
                                {
                                    var109.a[12]++;
                                }

                                if (var109.a[12] < 1)
                                {
                                    var109.a[12] = W.Length - 1;
                                }

                                if (var109.a[12] >= W.Length)
                                {
                                    var109.a[12] = 1;
                                }

                                if (var210 || var225)
                                {
                                    int var99 = var109.a[9] / 8;
                                    var109.a[9] = var99 * 8 + var109.a[12];
                                    var99 = var109.a[7] / 8;
                                    var109.a[7] = var99 * 8 + var109.a[12];
                                    var253 = true;
                                }
                            }

                            if (i != 63 && (var234 || var245 || var253 || var172))
                            {
                                var122.a = 30720;
                                var122.b = 51200;
                                var122.m_a(33);
                                var122.m_a(aB);
                            }

                            if (!var172)
                            {
                                if (var264 != null && var259 != 39 && var259 != 42)
                                {
                                    aB.SetClip(0, 0, 240, 400);
                                    var122.a = var264[0] << 8;
                                    var122.b = var264[1] << 8;
                                    var122.e = -1;
                                    var122.m_a(var259);
                                    var122.m_a(aB);
                                    var122.m_c();
                                    if (i == 0 || i == 9)
                                    {
                                        if (i == 0)
                                        {
                                            var131.m_a(36);
                                        }
                                        else
                                        {
                                            var131.m_a(46);
                                        }

                                        var131.a = var122.a;
                                        var131.b = var122.b;
                                        var131.m_a(aB);
                                        var131.m_b();
                                        var89 = var131.m_c();
                                    }
                                }

                                aB.SetClip(0, 0, 240, 400);
                                if (var253)
                                {
                                    for (int var281 = 0; var281 < p.Length; var281++)
                                    {
                                        for (int var284 = 0; var284 < p[var281].Length; var284++)
                                        {
                                            if (p[var196][var284] != null)
                                            {
                                                p[var196][var284].w = (Image[][])null;
                                            }
                                        }
                                    }

                                    var109.m_a(var184, 0, true);
                                }

                                if (i != 63)
                                {
                                    var122.a = 30720;
                                    var122.b = 51200;
                                    if (var259 == 39)
                                    {
                                        var122.m_a(41);
                                    }
                                    else
                                    {
                                        var122.m_a(34);
                                    }

                                    var122.m_a(aB);
                                }

                                if ((var259 == 39 || var259 == 42) && var264 != null)
                                {
                                    aB.SetClip(0, 0, 240, 400);
                                    if (var259 == 42)
                                    {
                                        var122.m_a(44);
                                        var122.m_a(aB);
                                    }

                                    var122.a = var264[0] << 8;
                                    var122.b = var264[1] << 8;
                                    var122.e = -1;
                                    var122.m_a(var259);
                                    var122.m_a(aB);
                                    var131.a = var122.a;
                                    var131.b = var122.b;
                                    if (var259 == 39)
                                    {
                                        var131.m_a(40);
                                    }
                                    else
                                    {
                                        var131.m_a(43);
                                    }

                                    var131.m_a(aB);
                                    var131.m_b();
                                    var89 = var131.m_c();
                                }
                            }
                        }
                    }

                    if (i != 63 && aC[14] < 0 && MiamiNights.g.ak == null)
                    {
                        MiamiNights.g.m_a(GloftMMN.m_k(866), (sbyte)-56);
                        i = 0;
                    }

                    m_a(var89[0] >> 8, var89[1] >> 8, var89[2] - var89[0] >> 8 >> 1, var89[3] - var89[1] >> 8, 1, 52, 2, 52);
                    m_a((var89[0] >> 8) + (var89[2] - var89[0] >> 8 >> 1), var89[1] >> 8, (var89[2] - var89[0] >> 8 >> 1) + 40, var89[3] - var89[1] >> 8, 1, 54, 2, 54);
                    return;
                case 18:
                    if (v[13] == null && y != 66 && y != 36)
                    {
                        GloftMMN.m_b("/10");
                        m_a(4, u, 4, true, true, 1, true);
                        GloftMMN.m_f();
                        v[13] = new d(u[4], 0, 0, null);
                        v[14] = new d(u[4], 0, 0, null);
                        v[15] = new d(u[4], 0, 0, null);
                        v[16] = new d(u[4], 0, 0, null);
                    }

                    d var6 = v[13];
                    d var7 = v[15];
                    d var8 = v[16];
                    g var9 = s[0];
                    bool var10 = false;
                    if (var6 != null)
                    {
                        var6.a = 30720;
                        var6.b = 51200;
                    }

                    bool var11 = true;
                    if (y == 40 || y == 59 || y == 62)
                    {
                        if (aC[3] < 0)
                        {
                            bF[1] = 0;
                            bF[2] = 0;
                            bF[5] = 2;
                        }
                        else if (aC[4] < 0)
                        {
                            bF[1] = 0;
                            bF[2] = 1;
                            bF[5] = 2;
                        }

                        if (y == 62)
                        {
                            bF[4] = s[0].b[1] - 1;
                        }
                        else if (bF[2] == 0)
                        {
                            if (s[0].a[0] == 0)
                            {
                                bF[4] = 43;
                            }
                            else
                            {
                                bF[4] = 48;
                            }
                        }
                        else if (s[0].a[0] == 0)
                        {
                            bF[4] = 12;
                        }
                        else
                        {
                            bF[4] = 15;
                        }

                        if (y != 59)
                        {
                            bF[4]++;
                        }

                        if (y == 59)
                        {
                            ac = 0;

                            for (int var5 = 0; var5 < bF[4]; var5++)
                            {
                                int var12;
                                if (bF[2] == 0)
                                {
                                    var12 = MiamiNights.g.m_b(var5, -1);
                                }
                                else
                                {
                                    var12 = MiamiNights.g.m_b(-1, var5);
                                }

                                if (var12 != -1)
                                {
                                    ab[ac++] = var5;
                                }
                            }

                            bF[4] = ac + 1;
                        }

                        if (aC[1] > 2 || aC[1] == 1 || aO == 1)
                        {
                            aO = 0;
                            if (bF[1] > 0)
                            {
                                bF[5] = 0;
                                bF[1]--;
                            }
                        }
                        else if (aC[2] > 2 || aC[2] == 1 || aO == 2)
                        {
                            aO = 0;
                            if (bF[1] < bF[4] - 1)
                            {
                                bF[5] = 0;
                                bF[1]++;
                            }
                        }
                        else if (i != 0 && aC[3] >= 0 && aC[4] >= 0)
                        {
                            var11 = false;
                        }

                        bool var152 = false;
                        if (i == 0 || k)
                        {
                            h_ = 16;
                            MiamiNights.f.m_a(aB, true, true);
                            h_ = 18;
                            MiamiNights.f.m_c(aB, false);
                            MiamiNights.f.m_d(aB, false);
                            i = 1;
                            var152 = true;
                        }

                        bF[3] = bF[1] / 9;
                        if (var11 || bF[5] == 2 || var152)
                        {
                            if (y == 59)
                            {
                                var6.m_a(2);
                            }
                            else if (y == 62)
                            {
                                var6.m_a(1);
                            }
                            else
                            {
                                var6.m_a(0);
                            }

                            var6.m_a(aB);
                        }

                        if (y != 62)
                        {
                            var6.m_a(4 + bF[2] * 2);
                            var6.m_a(aB);
                        }

                        if (y != 62)
                        {
                            var7.a = 30720;
                            var7.b = 51200;
                            var7.m_a(4 + bF[2] * 2 + 1);
                            int[] var13;
                            m_a((var13 = var7.m_c())[0] >> 8, (var13[1] >> 8) - 20, var13[2] - var13[0] >> 1 >> 8, (var13[3] - var13[1] >> 8) + 40, 1, 52, 2, 52);
                            m_a(var13[0] + var13[2] >> 1 >> 8, (var13[1] >> 8) - 20, var13[2] - var13[0] >> 1 >> 8, (var13[3] - var13[1] >> 8) + 40, 1, 54, 2, 54);
                            var7.m_a(aB);
                            var7.m_b();
                        }

                        var8.a = 30720;
                        var8.b = 51200;
                        var8.m_a(8);
                        int[] var170;
                        if (m_a(((var170 = var8.m_c())[0] >> 8) - 20, var170[1] >> 8, (var170[2] - var170[0] >> 8) + 40, var170[3] - var170[1] >> 1 >> 8, true))
                        {
                            this.KeyPressed(50);
                            this.KeyReleased(50);
                        }

                        if (m_a((var170[0] >> 8) - 20, var170[1] + var170[3] >> 1 >> 8, (var170[2] >> 8) + 40, var170[3] - var170[1] >> 1 >> 8, true))
                        {
                            this.KeyPressed(56);
                            this.KeyReleased(56);
                        }

                        var8.m_a(aB);
                        var8.m_b();
                        bF[5]++;
                    }

                    int var153 = -1;
                    int var171 = -1;
                    int var14 = -1;
                    int var15 = -1;
                    int var16 = 0;
                    int var17 = -1;
                    d var18 = null;
                    if (y == 47 || y == 48 || y == 49 || y == 50)
                    {
                        int var19 = bF[12];
                        MiamiNights.f.au = ad[var19 * 2 + 0];
                        var18 = MiamiNights.f.c[MiamiNights.f.au];
                        var171 = ad[bF[12] * 2 + 1];
                        var15 = ((var153 = f[var171 - 1] & 255) & 240) >> 4;
                        var18.d_.m = var15;
                        bF[14] = var15;
                        var14 = (var153 & 15) >> 0;
                        var18.m_a(MiamiNights.f.m_h(MiamiNights.f.e[MiamiNights.f.au][0], var14));
                        var18.m_c();
                        var16 = (short)-1;

                        int var21;
                        for (int var61 = 0; var61 < 64 && (var21 = var61 * 17) < g.Length; var61++)
                        {
                            short var22;
                            if ((var22 = g[var21 + 2]) == var171)
                            {
                                var17 = var61;
                                var16 = g[var21 + 3 + var14];
                                break;
                            }
                        }

                        bF[19] = var16;
                        if (var18.d_.w == null || var18.d_.w[var15] == null)
                        {
                            var18.d_.w = (Image[][])null;
                            var18.d_.m_a(var15, 0, -1, -1, var15);
                        }
                    }

                    switch (y)
                    {
                        case 36:
                            if (i == 0)
                            {
                                aB.SetColor(0);
                                aB.FillRect(0, 0, 240, 400);
                                M.m_a(aB, GloftMMN.m_k(829), 120, 200, 3, 0);
                                i++;
                            }
                            else
                            {
                                i = 0;
                                if (J)
                                {
                                    MiamiNights.f.m = null;
                                }

                                GloftMMN.m_b("/10");
                                m_a(4, u, 4, true, true, 1, true);
                                GloftMMN.m_f();
                                v[13] = new d(u[4], 0, 0, null);
                                v[14] = new d(u[4], 0, 0, null);
                                v[15] = new d(u[4], 0, 0, null);
                                v[16] = new d(u[4], 0, 0, null);
                                y = z;
                                c[0] = 0;
                                I = H;
                            }
                            break;
                        case 37:
                            aB.SetColor(0);
                            aB.FillRect(0, 0, 240, 400);
                            m_a(3, 0, false);

                            for (int var72 = 0; var72 < 3; var72++)
                            {
                                R[var72] = 815 + var72;
                            }

                            U[2] = 818;
                            U[3] = 819;
                            U[5] = -1;
                            i = 0;
                            y = 38;
                            break;
                        case 38:
                            if (k)
                            {
                                aB.SetColor(0);
                                aB.FillRect(0, 0, 240, 400);
                            }

                            m_a(false);
                            m_a(aB, false, false);
                            if (aP)
                            {
                                aB.SetColor(0);
                                aB.FillRect(0, 0, 240, 400);
                                M.m_a(aB, GloftMMN.m_k(829), 120, 200, 3, 0);
                                int var244;
                                if ((var244 = U[0]) == 0)
                                {
                                    y = 39;
                                }
                                else
                                {
                                    bF[20] = H;
                                    i = -1;
                                    y = 45;
                                    if (var244 == 1)
                                    {
                                        z = 46;
                                    }
                                    else
                                    {
                                        z = 52;
                                    }
                                }
                            }
                            break;
                        case 39:
                        case 58:
                        case 61:
                            GloftMMN.n = null;
                            GloftMMN.o = null;
                            MiamiNights.f.m_b();
                            MiamiNights.g.m_a(false);
                            GloftMMN.m_a("/3", 0);
                            if (y == 58)
                            {
                                y = 59;
                            }
                            else if (y == 61)
                            {
                                bF[15] = var9.a[4];
                                bF[16] = var9.a[5];
                                y = 62;
                            }
                            else
                            {
                                y = 40;
                            }

                            bF[0] = -1;
                            bF[1] = 0;
                            bF[2] = 0;
                            bF[5] = 2;
                            i = 0;
                            break;
                        case 40:
                            if (aP)
                            {
                                y = 41;
                                sbyte var71 = 7;
                                if (bF[2] == 1)
                                {
                                    var71 = 9;
                                }

                                bF[10] = s[0].a[var71];
                            }
                            break;
                        case 41:
                        case 60:
                        case 64:
                            d var243 = v[14];
                            int var20 = bF[1] - bF[3] * 9;
                            bF[0] = var20;
                            var243.m_a(12);
                            var243.a = bF[6] << 8;
                            var243.b = bF[7] << 8;
                            var243.m_a(aB);
                            var243.m_b();
                            bF[0] = -1;
                            if (y != 64)
                            {
                                var6.m_a(aB);
                            }

                            var8.m_a(aB);
                            var8.m_b();
                            if (var243.m_a())
                            {
                                if (y == 64)
                                {
                                    if (var9.a[35] >= 10)
                                    {
                                        y = 63;
                                        i = 0;
                                    }
                                    else
                                    {
                                        y = 57;
                                        z = 62;
                                        bB = -1;
                                        MiamiNights.g.m_a(434);
                                    }
                                }
                                else if (y == 60)
                                {
                                    var9.a[8] = bF[11];
                                    var9.a[9] = bF[12];
                                    var9.a[6] = bF[13];
                                    var9.a[7] = bF[14];
                                    bF[1] = 0;
                                    y = 59;
                                    i = 0;
                                    MiamiNights.f.bc[14] = 1;
                                }
                                else
                                {
                                    sbyte var209 = b[var9.a[0]][bF[2]][bF[1]];
                                    if (var9.a[35] >= var209)
                                    {
                                        y = 42;
                                        i = 0;
                                    }
                                    else
                                    {
                                        y = 57;
                                        z = 40;
                                        MiamiNights.g.m_a(434);
                                        bB = -1;
                                    }
                                }
                            }
                            break;
                        case 42:
                            var11 = true;
                            int var258 = bF[10] / 8;
                            int var263 = bF[10] % 8;
                            if (aC[3] < 0)
                            {
                                var258--;
                            }
                            else if (aC[4] < 0)
                            {
                                var258++;
                            }
                            else
                            {
                                var11 = false;
                            }

                            a var23;
                            if (bF[2] == 1)
                            {
                                var23 = p[var9.a[0]][4];
                            }
                            else
                            {
                                var23 = p[var9.a[0]][2];
                            }

                            int var24 = var23.l / 8;
                            if (var258 >= var24)
                            {
                                var258 = 0;
                            }

                            if (var258 < 0)
                            {
                                var258 = var24 - 1;
                            }

                            bF[10] = var258 * 8 + var263;
                            if (var11 || i == 0)
                            {
                                bF[5] = 2;
                                i = 1;
                                var6.m_a(0);
                                var6.m_a(aB);
                            }

                            var6.m_a(4 + bF[2] * 2);
                            var6.m_a(aB);
                            var8.m_a(15);
                            int[] var269;
                            m_a((var269 = var8.m_c())[0] >> 8, (var269[1] >> 8) - 20, var269[2] - var269[0] >> 1 >> 8, (var269[3] - var269[1] >> 8) + 40, 1, 52, 2, 52);
                            m_a(var269[0] + var269[2] >> 1 >> 8, (var269[1] >> 8) - 20, var269[2] - var269[0] >> 1 >> 8, (var269[3] - var269[1] >> 8) + 40, 1, 54, 2, 54);
                            var8.m_a(aB);
                            var8.m_b();
                            if (aP)
                            {
                                y = 43;
                                i = -1;
                            }
                            break;
                        case 43:
                            sbyte var208 = b[var9.a[0]][bF[2]][bF[1]];
                            if (i == -1)
                            {
                                MiamiNights.g.m_a(GloftMMN.m_k(865) + " $" + MiamiNights.f.m_e(var208), (sbyte)-56);
                                i = 0;
                            }
                            else
                            {
                                m_a(aB);
                                if (aP)
                                {
                                    if (i == 0)
                                    {
                                        var10 = true;
                                        y = 42;
                                    }
                                    else if (i == 1)
                                    {
                                        int var288 = bF[1] - 1;
                                        if (bF[2] == 0)
                                        {
                                            MiamiNights.g.m_a(var288, -1, (sbyte)bF[10]);
                                        }
                                        else
                                        {
                                            MiamiNights.g.m_a(-1, var288, (sbyte)bF[10]);
                                        }

                                        y = 56;
                                        z = 44;
                                        i = -1;
                                        K = 0;
                                        MiamiNights.f.bo[70] = var9.a[35];
                                        MiamiNights.f.bo[71] = var9.a[35] - var208;
                                    }
                                }
                            }
                            break;
                        case 44:
                            if (i == -1)
                            {
                                MiamiNights.g.m_a(GloftMMN.m_k(864), (sbyte)-56);
                                i = 0;
                            }
                            else
                            {
                                m_a(aB);
                                if (aP)
                                {
                                    if (i != 0 && i == 1)
                                    {
                                        var9.a[8] = bF[11];
                                        var9.a[9] = bF[12];
                                        var9.a[6] = bF[13];
                                        var9.a[7] = bF[14];
                                        MiamiNights.f.bc[14] = 1;
                                    }

                                    bF[1] = 0;
                                    y = 40;
                                    i = 0;
                                    var10 = true;
                                }
                            }
                            break;
                        case 45:
                            if (i == -1)
                            {
                                aB.SetColor(0);
                                aB.FillRect(0, 0, 240, 400);
                                m_a(2, 0, true);
                                U[2] = 830;
                                U[3] = 831;
                                R[0] = 832;
                                R[1] = 833;
                                i = 0;
                            }
                            else
                            {
                                m_a(false);
                                m_a(aB, false, false);
                                if (aP)
                                {
                                    aB.SetColor(0);
                                    aB.FillRect(0, 0, 240, 400);
                                    M.m_a(aB, GloftMMN.m_k(829), 120, 200, 3, 0);
                                    int var287;
                                    if ((var287 = U[0]) == 0)
                                    {
                                        if (MiamiNights.f.bc[0] >= 30)
                                        {
                                            bF[11] = 22;
                                        }
                                        else
                                        {
                                            bF[11] = 0;
                                        }

                                        MiamiNights.f.bd = 0;
                                        y = z;
                                    }
                                    else if (var287 == 1)
                                    {
                                        if (MiamiNights.f.bc[0] >= 30)
                                        {
                                            bF[11] = 34;
                                        }
                                        else
                                        {
                                            bF[11] = 1;
                                        }

                                        MiamiNights.f.bd = 0;
                                        y = z;
                                    }
                                    else
                                    {
                                        y = 66;
                                    }
                                }
                            }
                            break;
                        case 46:
                            H = bF[11];
                            if (MiamiNights.f.bd == 0)
                            {
                                MiamiNights.g.M = GloftMMN.m_k(829);
                            }

                            if (!MiamiNights.f.m_a(aB, H))
                            {
                                if (MiamiNights.f.bd == 1)
                                {
                                    aB.SetClip(0, 0, 240, 400);
                                    M.m_a(aB, MiamiNights.g.M, 120, 200, 3, 0);
                                }
                                break;
                            }

                            y = 47;
                            MiamiNights.f.d = true;
                            bF[0] = -1;
                            bF[12] = 0;
                            bF[13] = 0;

                            int var291;
                            for (int var286 = 0; var286 < 64 && (var291 = var286 * 17) < g.Length; var286++)
                            {
                                short var299 = g[var291 + 0];
                                short var307 = g[var291 + 1];

                                for (int var70 = 0; var70 < MiamiNights.f.f_; var70++)
                                {
                                    short var323;
                                    if ((MiamiNights.f.e[var70][0] & 255) == var307 && H == var299 && (var323 = g[var291 + 2]) == MiamiNights.f.e[var70][10])
                                    {
                                        int var332 = bF[13];
                                        ad[var332 * 2 + 0] = var70;
                                        ad[var332 * 2 + 1] = g[var291 + 2];
                                        bF[13]++;
                                    }
                                }
                            }

                            h_ = 16;
                            MiamiNights.f.m_a(aB, true, true);
                            h_ = 18;
                            MiamiNights.f.m_c(aB, false);
                            MiamiNights.f.m_d(aB, false);
                            MiamiNights.g.M = null;
                            break;
                        case 47:
                            short var285 = MiamiNights.f.e[MiamiNights.f.au][1];
                            short var290 = MiamiNights.f.e[MiamiNights.f.au][2];
                            MiamiNights.f.m_b(var285, var290, var9.c);
                            m_a(var9);
                            MiamiNights.f.m_a(aB);
                            MiamiNights.f.d = false;
                            var18.a = var285 - MiamiNights.f.C + 0 << 8;
                            var18.b = var290 - MiamiNights.f.D + 75 << 8;
                            int[] var268 = var18.m_c();
                            d var298;
                            (var298 = v[2]).a = var268[2] + var268[0] >> 1;
                            var298.b = var268[1];
                            var298.m_a(27);
                            var298.m_a(aB);
                            var298.m_b();
                            if (aG % 4L < 2L && var268[2] - var268[0] != 0)
                            {
                                var268 = var18.m_c();
                                aB.SetColor(16711680);
                                aB.DrawRect(var268[0] >> 8, var268[1] >> 8, var268[2] - var268[0] >> 8, var268[3] - var268[1] >> 8);
                            }

                            if (aC[3] < 0)
                            {
                                MiamiNights.f.E = -1000;
                                MiamiNights.f.d = true;
                                bF[12]--;
                            }

                            if (aC[4] < 0)
                            {
                                MiamiNights.f.E = -1000;
                                MiamiNights.f.d = true;
                                bF[12]++;
                            }

                            if (bF[12] < 0)
                            {
                                bF[12] = bF[13] - 1;
                            }

                            if (bF[12] >= bF[13])
                            {
                                bF[12] = 0;
                            }

                            if (aC[13] < 0 || aC[11] < 0)
                            {
                                GloftMMN.m_c(3);
                                y = 45;
                                z = 46;
                                i = -1;
                            }

                            if (aP)
                            {
                                bF[18] = var153;
                                y = 48;
                            }

                            m_b();
                            if (var268[2] - var268[0] >> 8 > 0)
                            {
                                m_a(var268[0] >> 8, var268[1] >> 8, var268[2] - var268[0] >> 8, var268[3] - var268[1] >> 8, 1, 53, 2, 53);
                            }
                            else
                            {
                                aB.SetColor(255, 0, 0);
                                aB.DrawRect((var268[0] >> 8) - 35, var268[1] >> 8, 70, 30);
                                m_a((var268[0] >> 8) - 35, var268[1] >> 8, 70, 30, 1, 53, 2, 53);
                            }

                            m_a(var298);
                            break;
                        case 48:
                            int var28 = MiamiNights.f.m_b(MiamiNights.f.e[MiamiNights.f.au][0], 3, -1);

                            while (g[var17 * 17 + 3 + var14] < 0)
                            {
                                if (++var14 >= var28)
                                {
                                    var14 = 0;
                                }
                            }

                            var6.m_a(16);
                            var6.m_a(aB);
                            var7.a = var6.a;
                            var7.b = var6.b;
                            var7.m_a(18);
                            m_b();
                            m_a(var7);
                            m_b(0, 0, 240, 360, 3, 0);
                            var7.m_a(aB);
                            var7.m_b();
                            var6.m_a(19);
                            var6.m_a(aB);
                            if (aC[13] < 0)
                            {
                                GloftMMN.m_c(3);
                                f[var171 - 1] = (sbyte)bF[18];
                                y = 47;
                            }
                            else
                            {
                                if (!aP && aC[14] >= 0)
                                {
                                    if (aC[3] < 0)
                                    {
                                        do
                                        {
                                            if (--var14 < 0)
                                            {
                                                var14 = var28 - 1;
                                            }
                                        }
                                        while (g[var17 * 17 + 3 + var14] < 0);
                                    }

                                    if (aC[4] < 0)
                                    {
                                        do
                                        {
                                            if (++var14 >= var28)
                                            {
                                                var14 = 0;
                                            }
                                        }
                                        while (g[var17 * 17 + 3 + var14] < 0);
                                    }

                                    f[var171 - 1] = (sbyte)(f[var171 - 1] & 240);
                                    f[var171 - 1] = (sbyte)(f[var171 - 1] | var14 << 0);
                                    break;
                                }

                                y = 49;
                            }
                            break;
                        case 49:
                            var6.m_a(16);
                            var6.m_a(aB);
                            var6.m_a(19);
                            var6.m_a(aB);
                            var7.a = var6.a;
                            var7.b = var6.b;
                            var7.m_a(20);
                            m_b();
                            m_a(var7);
                            m_b(0, 0, 240, 360, 3, 0);
                            var7.m_a(aB);
                            var7.m_b();
                            bool var29 = false;
                            if (aC[3] < 0 || aC[4] < 0)
                            {
                                if (aC[3] < 0)
                                {
                                    var15--;
                                }

                                if (aC[4] < 0)
                                {
                                    var15++;
                                }

                                if (var15 >= var18.d_.l / 3)
                                {
                                    var15 = 0;
                                }
                                else if (var15 < 0)
                                {
                                    var15 = var18.d_.l / 3 - 1;
                                }

                                f[var171 - 1] = (sbyte)(f[var171 - 1] & 15);
                                f[var171 - 1] = (sbyte)(f[var171 - 1] | var15 << 4);
                                sbyte[] var297 = new sbyte[var18.d_.w.Length];
                                var18.d_.m_a(var15, 0, -1, -1, var15);
                                var297[var15] = 1;

                                for (int var68 = 0; var68 < MiamiNights.f.c.Length; var68++)
                                {
                                    d var306;
                                    short var313;
                                    if ((var306 = MiamiNights.f.c[var68]) != null && var306.d_ == var18.d_ && (var313 = MiamiNights.f.e[var68][4]) >= 0)
                                    {
                                        var297[var313] = 1;
                                    }
                                }

                                for (int var69 = 0; var69 < var18.d_.w.Length; var69++)
                                {
                                    if (var297[var69] == 0)
                                    {
                                        var18.d_.w[var69] = null;
                                    }
                                }

                                GC.Collect();
                            }

                            if (aC[13] < 0)
                            {
                                GloftMMN.m_c(3);
                                f[var171 - 1] = (sbyte)bF[18];
                                y = 48;
                            }

                            if (aP || aC[14] < 0)
                            {
                                y = 50;
                                i = -1;
                            }
                            break;
                        case 50:
                            var16 = bF[19];
                            if (var9.a[35] < var16)
                            {
                                if (i == -1)
                                {
                                    MiamiNights.g.m_a(434);
                                    i = 0;
                                }

                                MiamiNights.g.m_b(aB);
                                if (aP)
                                {
                                    f[var171 - 1] = (sbyte)bF[18];
                                    MiamiNights.g.N.removeAllElements();
                                    y = 47;
                                }
                            }
                            else if (i == -1)
                            {
                                MiamiNights.g.m_a(GloftMMN.m_k(865) + " $" + MiamiNights.f.m_e(var16), (sbyte)-56);
                                i = 0;
                            }
                            else
                            {
                                m_a(aB);
                                if (aP)
                                {
                                    if (i == 0)
                                    {
                                        f[var171 - 1] = (sbyte)bF[18];
                                        y = 47;
                                    }
                                    else if (i == 1)
                                    {
                                        var9.a[35] = var9.a[35] - var16;
                                        y = 47;
                                        short[] var296;
                                        (var296 = MiamiNights.f.e[MiamiNights.f.au])[4] = (short)var18.d_.m;
                                        MiamiNights.f.ae[MiamiNights.f.au] = (sbyte)MiamiNights.f.m_b(var296[0], 1, var296[3]);
                                        MiamiNights.f.af[MiamiNights.f.au] = (sbyte)MiamiNights.f.m_b(var296[0], 2, var296[3]);
                                        var18.a = var296[1] << 8;
                                        var18.b = var296[2] << 8;
                                        int[] var305 = var18.m_c();
                                        MiamiNights.f.ag[MiamiNights.f.au][0] = var305[0] >> 8;
                                        MiamiNights.f.ag[MiamiNights.f.au][1] = var305[1] >> 8;
                                        MiamiNights.f.ag[MiamiNights.f.au][2] = var305[2] >> 8;
                                        MiamiNights.f.ag[MiamiNights.f.au][3] = var305[3] >> 8;
                                        MiamiNights.f.m_d(aB, false);
                                        MiamiNights.f.E = -1000;
                                        MiamiNights.f.d = true;
                                        k = true;
                                    }
                                }
                            }
                            goto case 51;   // Java: case 50 falls through into case 51/default
                        case 51:
                        default:
                            break;
                        case 52:
                            H = bF[11];
                            if (MiamiNights.f.m_a(aB, H))
                            {
                                y = 53;
                                MiamiNights.f.d = true;
                                bF[0] = -1;
                                h_ = 16;
                                MiamiNights.f.m_a(aB, true, true);
                                h_ = 18;
                                MiamiNights.f.m_c(aB, false);
                                MiamiNights.f.m_d(aB, false);
                                m_a(var9);
                                MiamiNights.f.m_a(aB);
                                MiamiNights.f.d = false;
                                int var295 = MiamiNights.f.bh * 4;
                                bF[11] = bM[var295 + 0] & 255;
                                bF[12] = bM[var295 + 1] & 255;
                                bF[13] = bM[var295 + 2] & 255;
                                bF[14] = bM[var295 + 3] & 255;
                                bF[15] = 0;
                                i = 0;
                            }
                            break;
                        case 53:
                            if (i == -1)
                            {
                                MiamiNights.f.d = true;
                                MiamiNights.f.m_a(aB);
                                MiamiNights.f.d = false;
                                i = 0;
                            }

                            if (k)
                            {
                                h_ = 16;
                                MiamiNights.f.m_a(aB, true, true);
                                h_ = 18;
                                MiamiNights.f.m_c(aB, false);
                                MiamiNights.f.m_d(aB, false);
                                MiamiNights.f.d = true;
                                MiamiNights.f.m_a(aB);
                                MiamiNights.f.d = false;
                            }

                            var6.m_a(16);
                            var6.m_a(aB);
                            var6.m_a(19);
                            var6.m_a(aB);
                            var7.a = var6.a;
                            var7.b = var6.b;
                            if (bF[15] == 1)
                            {
                                var7.m_a(20);
                            }
                            else
                            {
                                var7.m_a(17);
                            }

                            m_b();
                            m_a(var7);
                            m_b(0, 0, 240, 360, 3, 0);
                            var7.m_a(aB);
                            var7.m_b();
                            int var294 = MiamiNights.f.bh * 4;
                            int var303 = bM[var294 + 0] & 255;
                            int var310 = bM[var294 + 1] & 255;
                            if (aC[13] < 0)
                            {
                                GloftMMN.m_c(3);
                                if (bF[15] == 0)
                                {
                                    y = 45;
                                    z = 52;
                                    i = -1;
                                    bM[var294 + 0] = (sbyte)bF[11];
                                    bM[var294 + 1] = (sbyte)bF[12];
                                }
                                else
                                {
                                    bF[15] = 0;
                                }
                            }
                            else if (!aP && aC[14] >= 0)
                            {
                                int var322 = -1;
                                int var331 = bN.Length / 23;

                                for (int var65 = 0; var65 < bN.Length; var65 += 23)
                                {
                                    if (bN[var65 + 0] == var303)
                                    {
                                        var322 = var65 / 23;
                                        break;
                                    }
                                }

                                bF[16] = bN[var322 * 23 + 1];
                                bool var337 = true;
                                int var341 = -1;
                                int var342 = -1;
                                if (bF[15] == 1)
                                {
                                    int var343 = -1;
                                    int var344 = 0;

                                    for (int var66 = 0; var66 < 20; var66++)
                                    {
                                        int var345;
                                        if ((var345 = bN[var322 * 23 + 3 + var66]) >= 0)
                                        {
                                            var344++;
                                        }

                                        if (var310 == var345)
                                        {
                                            var343 = var66;
                                        }
                                    }

                                    if (aC[3] < 0)
                                    {
                                        var343--;
                                    }
                                    else if (aC[4] < 0)
                                    {
                                        var343++;
                                    }
                                    else
                                    {
                                        var337 = false;
                                    }

                                    if (var337)
                                    {
                                        var341 = var303;
                                        var342 = var310;
                                        if (var343 < 0)
                                        {
                                            var343 = var344 - 1;
                                        }

                                        if (var343 >= var344)
                                        {
                                            var343 = 0;
                                        }

                                        var310 = bN[var322 * 23 + 3 + var343];
                                        bM[var294 + 1] = (sbyte)var310;
                                    }
                                }
                                else
                                {
                                    if (aC[3] < 0)
                                    {
                                        var322--;
                                    }
                                    else if (aC[4] < 0)
                                    {
                                        var322++;
                                    }
                                    else
                                    {
                                        var337 = false;
                                    }

                                    if (var322 < 0)
                                    {
                                        var322 = var331 - 1;
                                    }

                                    if (var322 >= var331)
                                    {
                                        var322 = 0;
                                    }

                                    if (var337)
                                    {
                                        var341 = var303;
                                        var342 = var310;
                                        var303 = bN[var322 * 23 + 0];
                                        var310 = bN[var322 * 23 + 2];
                                        bM[var294 + 0] = (sbyte)var303;
                                        if (var303 == bF[11])
                                        {
                                            bM[var294 + 1] = (sbyte)bF[12];
                                        }
                                        else
                                        {
                                            bM[var294 + 1] = (sbyte)var310;
                                        }
                                    }
                                }

                                if (var337)
                                {
                                    for (int var67 = 0; var67 < 2; var67++)
                                    {
                                        if (var341 != -1 && var342 != -1)
                                        {
                                            MiamiNights.f.b[0].w[var342][var341 + var67] = null;
                                        }

                                        MiamiNights.f.b[0].m_a(bM[var294 + 1] & 255, (bM[var294 + 0] & 255) + var67, (bM[var294 + 0] & 255) + var67, -1, bM[var294 + 1] & 255);
                                        GC.Collect();
                                    }
                                }
                            }
                            else if (bF[15] == 0)
                            {
                                bF[15] = 1;
                            }
                            else
                            {
                                bF[15] = 0;
                                y = 54;
                            }
                            break;
                        case 54:
                            var6.m_a(16);
                            var6.m_a(aB);
                            var6.m_a(19);
                            var6.m_a(aB);
                            if (bF[15] == 1)
                            {
                                var7.m_a(20);
                            }
                            else
                            {
                                var7.m_a(18);
                            }

                            var7.m_a(aB);
                            var7.m_b();
                            int var293 = MiamiNights.f.bh * 4;
                            int var31 = bM[var293 + 2] & 255;
                            int var32 = bM[var293 + 3] & 255;
                            if (aC[13] < 0)
                            {
                                GloftMMN.m_c(3);
                                if (bF[15] == 0)
                                {
                                    bF[15] = 1;
                                    y = 53;
                                }
                                else
                                {
                                    bF[15] = 0;
                                }
                            }
                            else if (aP)
                            {
                                if (bF[15] == 0)
                                {
                                    bF[15] = 1;
                                }
                                else
                                {
                                    y = 55;
                                    i = -1;
                                }
                            }
                            else
                            {
                                int var321 = -1;
                                int var330 = bO.Length / 22;

                                for (int var63 = 0; var63 < bO.Length; var63 += 22)
                                {
                                    if (bO[var63 + 0] == var31)
                                    {
                                        var321 = var63 / 22;
                                        break;
                                    }
                                }

                                bool var35 = true;
                                int var36 = -1;
                                int var37 = -1;
                                if (bF[15] == 0)
                                {
                                    if (aC[3] < 0)
                                    {
                                        var321--;
                                    }
                                    else if (aC[4] < 0)
                                    {
                                        var321++;
                                    }
                                    else
                                    {
                                        var35 = false;
                                    }

                                    if (var321 < 0)
                                    {
                                        var321 = var330 - 1;
                                    }

                                    if (var321 >= var330)
                                    {
                                        var321 = 0;
                                    }

                                    if (var35)
                                    {
                                        var36 = var31;
                                        var37 = var32;
                                        var31 = bO[var321 * 22 + 0];
                                        var32 = bO[var321 * 22 + 1];
                                        bM[var293 + 2] = (sbyte)var31;
                                        if (var31 == bF[13])
                                        {
                                            bM[var293 + 3] = (sbyte)bF[14];
                                        }
                                        else
                                        {
                                            bM[var293 + 3] = (sbyte)var32;
                                        }
                                    }
                                }
                                else
                                {
                                    int var38 = -1;
                                    int var39 = 0;

                                    for (int var64 = 0; var64 < 20; var64++)
                                    {
                                        int var40;
                                        if ((var40 = bO[var321 * 22 + 2 + var64]) >= 0)
                                        {
                                            var39++;
                                        }

                                        if (var32 == var40)
                                        {
                                            var38 = var64;
                                        }
                                    }

                                    if (aC[3] < 0)
                                    {
                                        var38--;
                                    }
                                    else if (aC[4] < 0)
                                    {
                                        var38++;
                                    }
                                    else
                                    {
                                        var35 = false;
                                    }

                                    if (var35)
                                    {
                                        var36 = var31;
                                        var37 = var32;
                                        if (var38 < 0)
                                        {
                                            var38 = var39 - 1;
                                        }

                                        if (var38 >= var39)
                                        {
                                            var38 = 0;
                                        }

                                        var32 = bO[var321 * 22 + 2 + var38];
                                        bM[var293 + 3] = (sbyte)var32;
                                    }
                                }

                                if (var35)
                                {
                                    if (var36 != -1 && var37 != -1)
                                    {
                                        MiamiNights.f.b[0].w[var37][var36] = null;
                                    }

                                    MiamiNights.f.b[0].m_a(bM[var293 + 3] & 255, bM[var293 + 2] & 255, bM[var293 + 2] & 255, -1, bM[var293 + 3] & 255);
                                    GC.Collect();
                                }
                            }
                            break;
                        case 55:
                            var16 = bF[16];
                            if (var9.a[35] < var16)
                            {
                                if (i == -1)
                                {
                                    MiamiNights.g.m_a(434);
                                    i = 0;
                                }

                                MiamiNights.g.m_b(aB);
                                if (aP)
                                {
                                    MiamiNights.g.N.removeAllElements();
                                    y = 53;
                                }
                            }
                            else if (i == -1)
                            {
                                MiamiNights.g.m_a(GloftMMN.m_k(865) + " $" + MiamiNights.f.m_e(var16), (sbyte)-56);
                                i = 0;
                            }
                            else
                            {
                                m_a(aB);
                                if (aP)
                                {
                                    if (i == 0)
                                    {
                                        y = 53;
                                    }
                                    else if (i == 1)
                                    {
                                        var9.a[35] = var9.a[35] - var16;
                                        y = 66;
                                    }
                                }
                            }

                            if (y != 53)
                            {
                                break;
                            }

                            i = -1;
                            int var30 = MiamiNights.f.bh * 4;
                            int var33 = bM[var30 + 0] & 255;
                            int var34 = bM[var30 + 1] & 255;
                            bM[var30 + 0] = (sbyte)bF[11];
                            bM[var30 + 1] = (sbyte)bF[12];

                            for (int var62 = 0; var62 < 2; var62++)
                            {
                                if (var33 != -1 && var34 != -1)
                                {
                                    MiamiNights.f.b[0].w[var34][var33 + var62] = null;
                                }

                                MiamiNights.f.b[0].m_a(bM[var30 + 1] & 255, (bM[var30 + 0] & 255) + var62, (bM[var30 + 0] & 255) + var62, -1, bM[var30 + 1] & 255);
                            }

                            var33 = bM[var30 + 2] & 255;
                            var34 = bM[var30 + 3] & 255;
                            bM[var30 + 2] = (sbyte)bF[13];
                            bM[var30 + 3] = (sbyte)bF[14];
                            if (var33 != -1 && var34 != -1)
                            {
                                MiamiNights.f.b[0].w[var34][var33] = null;
                            }

                            MiamiNights.f.b[0].m_a(bM[var30 + 3] & 255, bM[var30 + 2] & 255, bM[var30 + 2] & 255, -1, bM[var30 + 3] & 255);
                            GC.Collect();
                            break;
                        case 56:
                            var9.a[35] = MiamiNights.f.bo[71];
                            i = -1;
                            y = z;
                            z = -1;
                            break;
                        case 57:
                            MiamiNights.g.m_b(aB);
                            if (bB > 0)
                            {
                                y = z;
                                i = 0;
                                bB = -1;
                            }
                            break;
                        case 59:
                            if (aP)
                            {
                                y = 60;
                            }
                            break;
                        case 62:
                            if (aP)
                            {
                                y = 64;
                            }
                            break;
                        case 63:
                            var11 = true;
                            int var26 = p[var9.a[0]][5].l;
                            int var27 = var9.a[5];
                            if (aC[3] < 0)
                            {
                                var27--;
                            }
                            else if (aC[4] < 0)
                            {
                                var27++;
                            }
                            else
                            {
                                var11 = false;
                            }

                            if (var27 < 0)
                            {
                                var27 = var26 - 1;
                            }

                            if (var27 >= var26)
                            {
                                var27 = 0;
                            }

                            var9.a[5] = var27;
                            if (var11 || i == 0)
                            {
                                bF[5] = 2;
                                i = 1;
                                var6.m_a(1);
                                var6.m_a(aB);
                            }

                            var8.m_a(15);
                            int[] var25;
                            m_a((var25 = var8.m_c())[0] >> 8, (var25[1] >> 8) - 20, var25[2] - var25[0] >> 1 >> 8, (var25[3] - var25[1] >> 8) + 40, 1, 52, 2, 52);
                            m_a(var25[0] + var25[2] >> 1 >> 8, (var25[1] >> 8) - 20, var25[2] - var25[0] >> 1 >> 8, (var25[3] - var25[1] >> 8) + 40, 1, 54, 2, 54);
                            var8.m_a(aB);
                            var8.m_b();
                            if (aP)
                            {
                                y = 65;
                                i = -1;
                            }

                            if (aC[13] < 0 || aC[1] < 0 || aC[2] < 0)
                            {
                                GloftMMN.m_c(3);
                                y = 62;
                                aC[13] = 0;
                                var9.a[5] = bF[16];
                            }
                            break;
                        case 65:
                            if (i == -1)
                            {
                                MiamiNights.g.m_a(GloftMMN.m_k(865) + " $" + MiamiNights.f.m_e(10), (sbyte)-56);
                                i = 0;
                            }
                            else
                            {
                                m_a(aB);
                                if (aP)
                                {
                                    if (i == 0)
                                    {
                                        var9.a[5] = bF[16];
                                        y = 63;
                                    }
                                    else if (i == 1)
                                    {
                                        y = 66;
                                    }
                                }
                            }
                            break;
                    }

                    if (var6 != null && !var10 && i != 0 && (y == 59 || y == 62 || y == 63 || y > 39 && y < 43))
                    {
                        int var73 = var6.e;
                        var6.m_a(3);
                        var6.m_a(aB);
                        var6.m_a(var73);
                    }

                    if (y != 40 && y != 59 && y != 62)
                    {
                        if ((y == 42 || y == 63) && (aC[13] < 0 || aC[1] < 0 || aC[2] < 0))
                        {
                            GloftMMN.m_c(3);
                            if (y == 42)
                            {
                                y = 40;
                                i = 0;
                            }
                            else
                            {
                                y = 62;
                            }
                        }
                    }
                    else if (aC[13] < 0)
                    {
                        GloftMMN.m_c(3);
                        if (y == 40 || y == 59)
                        {
                            MiamiNights.g.m_h();
                        }
                        else if (y == 62)
                        {
                            var9.a[4] = bF[15];
                            var9.a[5] = bF[16];
                        }

                        y = 66;
                    }

                    if (y == 66)
                    {
                        if (u[4] != null)
                        {
                            i = 0;
                            u[4] = null;
                            v[13] = null;
                            v[14] = null;
                            v[15] = null;
                            v[16] = null;
                        }
                        else if (i == 1)
                        {
                            MiamiNights.g.m_a(true);
                        }
                        else if (i == 2)
                        {
                            p[0] = null;
                            p[1] = null;
                        }
                        else if (i == 3)
                        {
                            MiamiNights.f.m_e();
                        }
                        else if (i == 4)
                        {
                            if (MiamiNights.f.b[0] != null)
                            {
                                MiamiNights.f.b[0].m_b();
                                MiamiNights.f.b[0].m_c();
                                MiamiNights.f.b[0] = null;
                            }
                        }
                        else if (i == 5)
                        {
                            for (int var74 = 3; var74 < MiamiNights.f.b.Length; var74++)
                            {
                                if (MiamiNights.f.b[var74] != null)
                                {
                                    MiamiNights.f.b[var74].m_b();
                                    MiamiNights.f.b[var74].m_c();
                                    MiamiNights.f.b[var74] = null;
                                }
                            }
                        }
                        else if (i == 6)
                        {
                            MiamiNights.f.m_b();
                        }
                        else if (i == 7)
                        {
                            H = I;
                            m_a(8);
                            y = 20;
                            z = -1;
                            L = 0;
                            MiamiNights.f.bd = 0;
                        }

                        if (i != 7)
                        {
                            i++;
                            return;
                        }
                    }
                    break;
                case 19:
                    if (m_d(31, 2))
                    {
                        m_a(6);
                        i = -1;
                        return;
                    }
                    break;
                case 20:
                    if (m_e(42, 2))
                    {
                        m_a(19);
                        m_d(31, 1);
                        return;
                    }
                    break;
                case 21:
                    if (i == -1)
                    {
                        i = 800;
                        y = -1;
                        L = 0;
                        K = 0;
                        GloftMMN.m_a("/3", 2);
                        GloftMMN.m_f();
                        MiamiNights.f.m = Image.CreateImage(240, 400);
                        MiamiNights.f.aj = MiamiNights.f.m.GetGraphics();
                        GloftMMN.m_e();
                    }

                    aB.SetClip(0, 0, 240, 400);
                    aB.SetColor(0);
                    aB.FillRect(0, 0, 240, 400);
                    object var47 = null;
                    if (i >= 400 + K)
                    {
                        L = 0;
                        i = 0;
                        y++;
                        if (0 + y == 17)
                        {
                            y = 0;
                        }

                        Graphics var54 = MiamiNights.f.aj;
                        MiamiNights.f.aj.SetColor(0);
                        var54.FillRect(0, 0, 240, 400);
                        var47 = GloftMMN.m_k(0 + y);
                        M.m_a((string)var47);
                        K = MiamiNights.a.z;
                        M.m_a(var54, (string)var47, 120, 0, 17, 0);
                    }

                    bool var55 = false;
                    if (L < 1500 && 400 - i + K / 2 <= 200)
                    {
                        L += 83;
                        i = 400 + K / 2 - 200;
                        var55 = true;
                    }

                    u[3].m_a(aB, 31, 0, 223, 398, 0, 0, 0);
                    aB.SetClip(0, 0, 240, 382);
                    aB.DrawImage(MiamiNights.f.m, 0, 400 - i, 20);
                    if (!var55)
                    {
                        i += 5;
                    }

                    if (aC[13] < 0)
                    {
                        i = -1;
                        y = -1;
                        L = -1;
                        m_a(6);
                        GloftMMN.m_a("/3", 1);
                        GloftMMN.m_f();
                        MiamiNights.f.m = null;
                        MiamiNights.f.aj = null;
                    }

                    aB.SetClip(0, 0, 240, 400);
                    m_a(aB, -1, 0);
                    return;
                case 22:
                    short[] var46 = new short[] { 935, 936 };
                    aB.SetColor(0);
                    aB.FillRect(0, 0, 240, 400);
                    if (i == -1)
                    {
                        i = 0;
                        GloftMMN.m_a("/3", 0);
                        GloftMMN.m_f();
                    }

                    M.m_a(aB, MiamiNights.g.m_b(GloftMMN.m_k(var46[i]), 192), 120, 200, 3, 0);
                    bool var2 = false;
                    m_a(aB, -1, 794);
                    m_a(aB, 901, -1);
                    if (aC[14] < 0)
                    {
                        i++;
                        i %= var46.Length;
                    }

                    if (aC[13] < 0)
                    {
                        i = -1;
                        m_a(6);
                        GloftMMN.m_a("/3", 1);
                        GloftMMN.m_f();
                        return;
                    }
                    break;
                case 24:
                    switch (y)
                    {
                        case 69:
                            GloftMMN.m_b();
                            y = 71;
                            i = -1;
                            k = true;
                            Console.WriteLine("load igp..........");
                            MiamiNights.c.m_a(GloftMMN.m_k(3), ay);
                            MiamiNights.c.m_b(0, 0);
                            ah = -1;
                            break;
                        case 70:
                            GC.Collect();
                            o[0] = null;
                            aB.SetColor(0);
                            aB.FillRect(0, 0, 240, 400);
                            GloftMMN.m_b("/0");
                            sbyte[] var45;
                            Q = Image.CreateImage(var45 = GloftMMN.m_j(1), 0, var45.Length);
                            m_a(6);
                            GloftMMN.m_c(5);
                            i = -1;
                            break;
                        case 71:
                            if (ah < 10)
                            {
                                MiamiNights.c.m_b(0, 0);
                                ah++;
                            }

                            aB.SetClip(0, 0, 240, 400);
                            MiamiNights.c.m_a(aB);
                            int var44 = 0;   // CFR: int (VF byte mis-inference)
                            if (aC[1] < 0)
                            {
                                var44 = 21;
                            }

                            if (aC[2] < 0)
                            {
                                var44 = 32;
                            }

                            if (aC[3] < 0)
                            {
                                var44 = 23;
                            }

                            if (aC[4] < 0)
                            {
                                var44 = 24;
                            }
                            else if (aP || aC[14] < 0)
                            {
                                var44 = 25;
                            }
                            else if (aC[13] < 0)
                            {
                                var44 = 26;
                            }

                            if (MiamiNights.c.m_a(var44))
                            {
                                y = 70;
                            }
                            break;
                    }
                    return;
                case 100:
                    aB.SetClip(0, 0, 240, 400);
                    aB.SetColor(0);
                    aB.FillRect(0, 0, 240, 400);
                    if (bH == null)
                    {
                        try
                        {
                            bH = Image.CreateImage("/operatorLogo.png");
                        }
                        catch (Exception)
                        {
                            bI = true;
                        }
                    }
                    else
                    {
                        aB.DrawImage(bH, 120, 200, 3);
                    }

                    long var1 = MiaNow.Ms();
                    if (bL == 0L)
                    {
                        bL = var1;
                    }

                    long var3;
                    if ((var3 = var1 - bL) < 0L || var3 > 200L)
                    {
                        var3 = 0L;
                    }

                    bL = var1;
                    bK += var3;
                    if (bK > bJ)
                    {
                        bI = true;
                    }

                    if (bI)
                    {
                        m_a(4);
                        return;
                    }
                    break;
            }
        }
        // original private static void b(int) - vibrate
        private static void m_b(int var0)
        {
            if (ax == 1)
            {
                try
                {
                    // PORT-QUESTION: original `Display.getDisplay(GloftMMN.b).vibrate(var0);` - engine Display has
                    // no Vibrate() member (do-not-edit rule); desktop has no vibrator -> call dropped, shell kept.
                    Display.GetDisplay(GloftMMN.b);
                    return;
                }
                catch (Exception)
                {
                }
            }
        }

        // original h() constructor (package-private)
        internal h()
        {
            m_a(0);
            this.SetFullScreenMode(true);
            aC = new sbyte[15];
            aD = new sbyte[15];
            aK = new int[96000];
            aL = new int[96000];
            aM = Image.CreateImage(240, 400);
            aN = aM.GetGraphics();
        }

        public override void HideNotify()
        {
            if (af != null)
            {
                af = af.Replace('?', '-');
            }

            aE = true;
            m_r();
        }

        public override void ShowNotify()
        {
            k = true;
            aE = false;
            l = true;
            bT = MiaNow.Ms();
        }

        // original static void a(): quit sentinel (driver member, PORTING.md §5)
        public static void m_a()
        {
            h_ = -1;
        }

        // original run() head; while-loop replaced by Game1 fixed-step.
        public void RunInit()
        {
            MiamiNights.c.m_a(GloftMMN.b, this, 240, 400);
            Console.WriteLine("igp IS AVAILABLE ::>:: " + MiamiNights.c.m_a());
            Console.WriteLine("paint...2 :: " + MiamiNights.b.a);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            GloftMMN.f = true;
            this.bS = true;
            // original run() for(this.bS = true; h >= 0; System.gc()) { repaint/serviceRepaints; 66ms pacing;
            //   1500ms watchdog hideNotify/showNotify } -> Game1 fixed-step + Draw watchdog.
            // original loop exit tail GloftMMN.e()/d()/c()/b.destroyApp(true) -> Game1.Draw (h_ < 0 branch).
        }

        // original public final void paint(Graphics) [driver: was protected]
        public void Paint(Graphics g) // was protected
        {
            try
            {
                Graphics var4 = aN;
                this.m_b(var4);
                m_a(g, aM);
            }
            catch (Exception var3)
            {
                Console.WriteLine("[PAINT-EX] " + var3.ToString());   // DIAG
                aB.SetColor(255, 0, 0);
                aB.FillRect(0, 0, 240, 100);
                aB.SetColor(255, 255, 255);
                aB.DrawString("" + var3.ToString(), 0, 0, 0);
            }
        }

        // original private static void a(Graphics,Image) - 2x upscale quadrant doubling
        private static void m_a(Graphics var0, Image var1)
        {
            var1.GetRGB(aK, 0, 240, 0, 0, 240, 400);
            m_b(var0, 0, 0);
            m_b(var0, 120, 0);
            m_b(var0, 0, 200);
            m_b(var0, 120, 200);
        }

        // original private static void b(Graphics,int,int)
        // 2x upscale of a 120x200 quadrant with Scale2x/EPX edge smoothing (diagonals stay clean, flat areas stay crisp)
        private static void m_b(Graphics var0, int var1, int var2)
        {
            int var3 = 0;
            bool sharp = Environment.GetEnvironmentVariable("MN_SHARP") == "1";
            for (int y = var2; y < var2 + 200; y++)
            {
                int ym = y > 0 ? y - 1 : y, yp = y < 399 ? y + 1 : y;
                int row = 240 * 2 * (y - var2) ;
                for (int x = var1; x < var1 + 120; x++)
                {
                    int xm = x > 0 ? x - 1 : x, xp = x < 239 ? x + 1 : x;
                    int e = aK[y * 240 + x];
                    int e0 = e, e1 = e, e2 = e, e3 = e;
                    if (!sharp)
                    {
                        int B = aK[ym * 240 + x], H = aK[yp * 240 + x], D = aK[y * 240 + xm], F = aK[y * 240 + xp];
                        if (B != H && D != F)
                        {
                            if (D == B) e0 = D;
                            if (B == F) e1 = F;
                            if (D == H) e2 = D;
                            if (H == F) e3 = F;
                        }
                    }
                    int o = row + (x - var1) * 2;
                    aL[o] = e0; aL[o + 1] = e1;
                    aL[o + 240] = e2; aL[o + 241] = e3;
                }
            }

            var0.DrawRGB(aL, 0, 240, var1 << 1, var2 << 1, 240, 400, false);
        }

        // original private void b(Graphics): per-frame logic+render driver body
        private void m_b(Graphics var1)
        {
            if (this.bS)
            {
                if (!aE)
                {
                    aF = MiaNow.Ms();
                    aH = aF - bT;
                    bT = aF;
                    aG++;

                    try
                    {
                        aB = var1;
                        this.m_e();
                    }
                    catch (Exception var4)
                    {
                        Console.WriteLine(var4);
                    }

                    this.m_q();
                    GloftMMN.m_d();
                    k = false;
                    l = false;
                }
            }
        }

        // original protected final void keyPressed(int) [driver: was protected]
        public void KeyPressed(int var1) // was protected
        {
            // original reset every key on each press (phones = one key at a time). Keep held direction keys
            // when another direction is pressed so W+D etc. combine into diagonal movement.
            int ga = this.GetGameAction(var1);
            if (ga == 1 || ga == 2 || ga == 5 || ga == 6) m_rKeepDirections();
            else m_r();
            int var2 = var1;
            int var3;
            if ((var3 = this.GetGameAction(var1)) != 0)
            {
                switch (var3)
                {
                    case 1:
                        var2 = 50;
                        break;
                    case 2:
                        var2 = 52;
                        goto case 3;   // Java: case 2 falls into case 3 group -> break
                    case 3:
                    case 4:
                    case 7:
                    default:
                        break;
                    case 5:
                        var2 = 54;
                        break;
                    case 6:
                        var2 = 56;
                        break;
                    case 8:
                        var2 = 53;
                        break;
                }
            }

            sbyte var4 = m_c(var2);
            if (aD[var4] <= 0)
            {
                if (aD[var4] < 0)
                {
                    aD[var4] = 0;
                }

                if (aD[var4] < 126)
                {
                    aD[var4]++;
                }
            }
        }

        // original protected final void keyReleased(int) [driver: was protected]
        public void KeyReleased(int var1) // was protected
        {
            int var2 = var1;
            int var3;
            if ((var3 = this.GetGameAction(var1)) != 0)
            {
                switch (var3)
                {
                    case 1:
                        var2 = 50;
                        break;
                    case 2:
                        var2 = 52;
                        goto case 3;   // Java: case 2 falls into case 3 group -> break
                    case 3:
                    case 4:
                    case 7:
                    default:
                        break;
                    case 5:
                        var2 = 54;
                        break;
                    case 6:
                        var2 = 56;
                        break;
                    case 8:
                        var2 = 53;
                        break;
                }
            }

            sbyte var4 = m_c(var2);
            if (aD[var4] > 0)
            {
                if (aD[var4] == 1)
                {
                    aO = var4;
                }

                aD[var4] = (sbyte)(aD[var4] * -1);
            }
        }

        // original private static byte c(int) - key -> keyState index
        private static sbyte m_c(int var0)
        {
            aQ = false;
            if (var0 == -6 || var0 == -21 || var0 == 21)
            {
                return 14;
            }
            else if (var0 == -7 || var0 == -22 || var0 == 22)
            {
                return 13;
            }
            else if (var0 == 53)
            {
                return 5;
            }
            else if ((var0 = Math.Abs(var0)) == 1)
            {
                aQ = true;
                return 1;
            }
            else if (var0 == 3)
            {
                aQ = true;
                return 3;
            }
            else if (var0 == 4)
            {
                aQ = true;
                return 4;
            }
            else if (var0 == 2)
            {
                aQ = true;
                return 2;
            }
            else if (var0 == 5)
            {
                aQ = true;
                return 5;
            }
            else if (var0 == 35)
            {
                return 12;
            }
            else if (var0 == 42)
            {
                return 11;
            }
            else if (var0 == 48)
            {
                return 6;
            }
            else if (var0 == 49)
            {
                return 7;
            }
            else if (var0 == 50)
            {
                return 1;
            }
            else if (var0 == 51)
            {
                return 8;
            }
            else if (var0 == 52)
            {
                return 3;
            }
            else if (var0 == 54)
            {
                return 4;
            }
            else if (var0 == 55)
            {
                return 9;
            }
            else if (var0 == 56)
            {
                return 2;
            }
            else
            {
                return (sbyte)(var0 == 57 ? 10 : 0);
            }
        }

        // original private static void a(g,d,boolean,boolean,boolean,boolean) - "UpadateMovement"
        private static void m_a(g var0, d var1, bool var2, bool var3, bool var4, bool var5)
        {
            // var2 left, var3 right, var4 up, var5 down. Modern 8-way: screen-space direction, uniform screen speed.
            // world->screen (iso 2:1): sx = wx - wy, sy = (wx + wy) / 2  =>  wx = sy + sx/2, wy = sy - sx/2
            int sxi = (var3 ? 1 : 0) - (var2 ? 1 : 0);
            int syi = (var5 ? 1 : 0) - (var4 ? 1 : 0);
            if (sxi == 0 && syi == 0) return;
            const double Speed = 900.0;                 // screen units/s (orig: 1024 horizontal, 768 vertical)
            double len = Math.Sqrt(sxi * sxi + syi * syi);
            double sx = sxi / len * Speed, sy = syi / len * Speed;
            int wx = (int)Math.Round(sy + sx / 2), wy = (int)Math.Round(sy - sx / 2);
            // keep the original animation choice per direction (6 = walk away, 4 = walk toward, 7 up, 5 down; flip = facing)
            int anim, flip;
            if (syi < 0 && sxi != 0) { anim = 6; flip = sxi > 0 ? 0 : 1; }
            else if (syi > 0 && sxi != 0) { anim = 4; flip = sxi > 0 ? 0 : 1; }
            else if (sxi != 0) { anim = 4; flip = sxi > 0 ? 0 : 1; }
            else if (syi < 0) { anim = 7; flip = var1.c; }
            else { anim = 5; flip = var1.c; }
            var0.m_a(wx, wy, anim, flip, false);
            // facing (g.o / g.n) drives the "what is in front of me" probe for NPC/object actions:
            // keep it on the original 8 iso directions so interactions trigger exactly like the original.
            int ox, oy;
            if (var4 && var3) { ox = 0; oy = -721; }
            else if (var4 && var2) { ox = -721; oy = 0; }
            else if (var5 && var3) { ox = 721; oy = 0; }
            else if (var5 && var2) { ox = 0; oy = 721; }
            else if (var3) { ox = 512; oy = -512; }
            else if (var2) { ox = -512; oy = 512; }
            else if (var4) { ox = -768; oy = -768; }
            else { ox = 768; oy = 768; }
            if (var0.o != null && var0.n != null)
            {
                var0.o[0] = ox; var0.o[1] = oy;
                MiamiNights.f.m_c(var0.o);
                var0.n[0] = ox * MiamiNights.f.w[0] + oy * MiamiNights.f.x[0] >> 8;
                var0.n[1] = ox * MiamiNights.f.w[1] + oy * MiamiNights.f.x[1] >> 8;
                MiamiNights.f.m_c(var0.n);
            }
        }

        // original private static boolean a(int,int,int,int)
        private static bool m_a(int var0, int var1, int var2, int var3)
        {
            return m_b(var0, var1, var2, var3);
        }

        // original private static boolean b(int,int,int,int)
        private static bool m_b(int var0, int var1, int var2, int var3)
        {
            return m_a(var0, var1, var2, var3, true);
        }

        // original private static boolean a(int,int,int,int,boolean) - stylus hit test
        private static bool m_a(int var0, int var1, int var2, int var3, bool var4)
        {
            if (!by)
            {
                return false;
            }
            else if (bB >= var0 && bB <= var0 + var2 && bC >= var1 && bC <= var1 + var3)
            {
                if (var4)
                {
                    bB = -1;
                    bC = -1;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        // original protected final synchronized void pointerPressed(int,int) [driver]
        public void PointerPressed(int var1, int var2) // was synchronized
        {
            var1 >>= 1;
            var2 >>= 1;
            if (var1 <= 60 && var2 >= 360)
            {
                aW = true;
            }

            if (var1 >= 180 && var2 >= 360)
            {
                aX = true;
            }

            if (aV < 1024)
            {
                aS[aV] = 1;
                aT[aV] = var1;
                aU[aV++] = var2;
            }

            bz = var1;
            bA = var2;
            bD = -1;
            bE = -1;
            bB = -1;
            bC = -1;
            by = true;
            if (h_ == 24)
            {
                if (bz > 200 && bA > 170 && bA < 230)
                {
                    bz = 225;
                    bA = 200;
                }

                MiamiNights.c.m_b(bz, bA);
            }
        }

        // original protected final synchronized void pointerReleased(int,int) [driver]
        public void PointerReleased(int var1, int var2) // was synchronized
        {
            var1 >>= 1;
            var2 >>= 1;
            aW = false;
            aX = false;
            bool var3 = m_a(var1, var2, 0, 358, 50, 42);
            bool var4 = m_a(var1, var2, 190, 358, 80, 52);
            if (var3 && (y != 67 || i != 0))
            {
                this.KeyPressed(-6);
                this.KeyReleased(-6);
            }

            if (var4)
            {
                this.KeyPressed(-7);
                this.KeyReleased(-7);
            }

            if (aV < 1024)
            {
                aS[aV] = 2;
                aT[aV] = var1;
                aU[aV++] = var2;
            }

            bB = var1;
            bC = var2;
            bz = -1;
            bA = -1;
            bD = -1;
            bE = -1;
            if (h_ == 24)
            {
                if (bB > 200 && bC > 170 && bC < 230)
                {
                    bB = 225;
                    bC = 200;
                }

                MiamiNights.c.m_a(bB, bC);
            }
        }

        // original protected final synchronized void pointerDragged(int,int)
        public void PointerDragged(int var1, int var2) // was synchronized
        {
            var1 >>= 1;
            var2 >>= 1;
            if (aV < 1024)
            {
                aS[aV] = 3;
                aT[aV] = var1;
                aU[aV++] = var2;
            }

            bD = var1;
            bE = var2;
            bz = -1;
            bA = -1;
            bB = -1;
            bC = -1;
            if (h_ == 24)
            {
                if (bD > 200 && bE > 170 && bE < 230)
                {
                    bD = 225;
                    bE = 200;
                }

                MiamiNights.c.m_c(bD, bE);
            }
        }

        // original private synchronized void f() - pointer queue flush
        private void m_f() // was synchronized
        {
            int var1 = aV;

            for (int var2 = 0; var2 < var1; var2++)
            {
                if (aS[var2] != 3 || var2 >= var1 - 1 || aS[var2 + 1] != 3)
                {
                    this.m_a(aS[var2], aT[var2], aU[var2]);
                }
            }

            aV = 0;
        }

        // original private void g() - stylus/touch hit routing (synthetic key presses)
        private void m_g()
        {
            if (h_ == 8 && y == 0 && bG)
            {
                m_a(aB, 796, -1);
            }

            if (y == 67 && i == -1)
            {
                m_a(aB, 849, -1);
            }

            if (y == 24 || y == 26 || y == 27)
            {
                m_a(aB, -1, 0);
            }

            if (h_ == 18 && y != 38 && y != 45 && y != 68 && y != 55 && y != 50 || y == 3 || y == 4 || y == 34 || y == 16)
            {
                m_a(aB, -1, 0);
            }

            if (h_ == 15)
            {
                m_a(aB, 401, 0);
                if (y == 31 && (i == -3 || i == -8) && m_a(0, 75, 240, 240, true))
                {
                    this.KeyPressed(53);
                    this.KeyReleased(53);
                    return;
                }
            }

            if (h_ == 17 && MiamiNights.g.ak == null)
            {
                m_a(aB, 848, -1);
                if (i != 0 && m_a(2, 114, 236, 16, true) && i != 63)
                {
                    i = 1;
                    this.KeyPressed(50);
                    return;
                }

                if (m_a(2, 133, 236, 18, true) && i != 63)
                {
                    if (i == 1)
                    {
                        this.KeyPressed(53);
                        this.KeyReleased(53);
                        return;
                    }

                    i = 2;
                    this.KeyPressed(50);
                    return;
                }

                if (m_a(2, 160, 236, 20, true))
                {
                    if (i == 2)
                    {
                        this.KeyPressed(53);
                        this.KeyReleased(53);
                        return;
                    }

                    i = 3;
                    this.KeyPressed(50);
                    return;
                }

                if (i != 3 && m_a(1, 189, 81, 34, true))
                {
                    i = 4;
                    this.KeyPressed(50);
                    return;
                }

                if (i != 4 && m_a(1, 224, 81, 19, true))
                {
                    i = 5;
                    this.KeyPressed(50);
                    return;
                }

                if (i != 5 && m_a(1, 244, 81, 27, true))
                {
                    i = 6;
                    this.KeyPressed(50);
                    return;
                }

                if (i != 6 && m_a(160, 189, 76, 34, true))
                {
                    i = 7;
                    this.KeyPressed(50);
                    return;
                }

                if (i != 7 && m_a(160, 224, 76, 19, true))
                {
                    i = 8;
                    this.KeyPressed(50);
                    return;
                }

                if (i != 8 && m_a(160, 244, 76, 27, true))
                {
                    i = 9;
                    this.KeyPressed(50);
                    return;
                }

                if (i != 9 && m_a(1, 278, 235, 36, true))
                {
                    i = 10;
                    this.KeyPressed(50);
                    return;
                }
            }

            if (h_ == 8)
            {
                if (y != 32 && y != 33 && y != 35 && y < 73 && y != 3 && y != 4 && y != 5 && y != 8)
                {
                    m_b();
                    if (m_a(57, 315, 126, 35, true))
                    {
                        Console.WriteLine("1212121212121212121211212");
                        if (MiamiNights.f.aY > 0 && MiamiNights.f.au >= 0)
                        {
                            MiamiNights.f.m_b(aB, 3);
                            return;
                        }

                        this.KeyPressed(53);
                        this.KeyReleased(53);
                        return;
                    }
                }

                if (y == 67 && i >= 0)
                {
                    for (int var1 = 0; var1 < 6; var1++)
                    {
                        if (m_a(bD, bE, 1, 146 + var1 * 30, 238, 30))
                        {
                            i = var1;
                        }

                        if (m_a(bz, bA, 1, 146 + var1 * 30, 238, 30))
                        {
                            i = var1;
                        }

                        if (m_a(bB, bC, 1, 146 + var1 * 30, 238, 30))
                        {
                            i = var1;
                        }

                        if (m_a(1, 146 + var1 * 30, 238, 30, true))
                        {
                            this.KeyPressed(-6);
                            this.KeyReleased(-6);
                            return;
                        }
                    }
                }

                if ((y == 17 || y == 13) && m_a(0, 75, 240, 240, true))
                {
                    this.KeyPressed(53);
                    this.KeyReleased(53);
                    return;
                }

                if (y == 8 && m_a(0, 0, 240, 400, true))
                {
                    this.KeyPressed(53);
                    this.KeyReleased(53);
                    return;
                }

                if (y == 0)
                {
                    if (bc && bh == -1)
                    {
                        if (m_a(bb[0] - 5, bb[1] - 25, 20, 28, true))
                        {
                            if (MiamiNights.f.aY > 0 && MiamiNights.f.au >= 0)
                            {
                                MiamiNights.f.m_b(aB, 3);
                                return;
                            }

                            this.KeyPressed(53);
                            this.KeyReleased(53);
                            return;
                        }

                        bc = false;
                    }

                    if (be && bh == -1)
                    {
                        if (m_a(bd[0] - 5, bd[1] - 25, 20, 28, true))
                        {
                            Console.WriteLine("545454545454545454545454");
                            this.KeyPressed(53);
                            this.KeyReleased(53);
                            return;
                        }

                        be = false;
                    }

                    if (bg && bh == -1)
                    {
                        if (m_a(bf[0], bf[1], 37, 37, true))
                        {
                            Console.WriteLine("dfgdfgdfgdfgfdgdfgfdgdfgfd");
                            this.KeyPressed(53);
                            this.KeyReleased(53);
                            return;
                        }

                        if (m_a(bf[2], bf[3], 197, 18, true))
                        {
                            this.KeyPressed(53);
                            this.KeyReleased(53);
                            return;
                        }

                        bg = false;
                    }

                    if (m_a(0, 75, 240, 240, false))
                    {
                        bi[0] = bB;
                        bi[1] = bC;

                        try
                        {
                            this.m_n();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Here error..........");

                            for (int var2 = 0; var2 < 4; var2++)
                            {
                                this.KeyReleased(bj[var2]);
                            }

                            for (int var4 = 0; var4 < 4; var4++)
                            {
                                this.KeyReleased(bk[var4]);
                            }
                        }
                    }
                }

                m_a(0, 0, 240, 400, true);
            }
        }

        // original private void a(int,int,int) - stylus zone dispatch
        private void m_a(int var1, int var2, int var3)
        {
            switch (var1)
            {
                case 1:
                    for (int var9 = 0; var9 < ba; var9++)
                    {
                        int var12 = var9 * 7;
                        if (m_a(var2, var3, aZ, var12))
                        {
                            int var14 = aZ[var12 + 4] & 0xFF;
                            int var16 = aZ[var12 + 4] >> 8;
                            this.m_b(var14, var16);
                            break;
                        }
                    }
                    break;
                case 2:
                    for (int var8 = 0; var8 < ba; var8++)
                    {
                        int var11 = var8 * 7;
                        if (m_a(var2, var3, aZ, var11))
                        {
                            int var13 = aZ[var11 + 5] & 0xFF;
                            int var15 = aZ[var11 + 5] >> 8;
                            this.m_b(var13, var15);
                            break;
                        }
                    }
                    break;
                case 3:
                    for (int var4 = 0; var4 < ba; var4++)
                    {
                        int var5 = var4 * 7;
                        if (m_a(var2, var3, aZ, var5))
                        {
                            int var6 = aZ[var5 + 6] & 0xFF;
                            int var7 = aZ[var5 + 6] >> 8;
                            this.m_b(var6, var7);
                            break;
                        }
                    }
                    break;
            }

            for (int var10 = 0; var10 < ba; var10++)
            {
                if (m_a(var2, var3, aZ, var10 * 7))
                {
                    if (U != null && U.Length > 0)
                    {
                        U[0] = aZ[var10 * 7 + 6] >> 8;
                        return;
                    }
                    break;
                }
            }
        }

        // original private static boolean a(int,int,int,int,int,int)
        private static bool m_a(int var0, int var1, int var2, int var3, int var4, int var5)
        {
            return var0 >= var2 && var0 <= var2 + var4 && var1 >= var3 && var1 <= var3 + var5;
        }

        // original private static boolean a(int,int,int[],int)
        private static bool m_a(int var0, int var1, int[] var2, int var3)
        {
            return var0 >= var2[var3] && var0 <= var2[var3] + var2[var3 + 2] && var1 >= var2[var3 + 1] && var1 <= var2[var3 + 1] + var2[var3 + 3];
        }

        // original public static void b() - StylusInit
        public static void m_b()
        {
            ba = 0;
            if (aY)
            {
                Console.WriteLine("------------------");
                Console.WriteLine("StylusInit");
            }
        }

        // original private static void b(int,int,int,int,int,int)
        private static void m_b(int var0, int var1, int var2, int var3, int var4, int var5)
        {
            m_a(var0, var1, var2, var3, 0, 0, var4, var5, 0, 0, false);
        }

        // original private static void a(int,int,int,int,int,int,int,int)
        private static void m_a(int var0, int var1, int var2, int var3, int var4, int var5, int var6, int var7)
        {
            m_a(var0, var1, var2, var3, var4, var5, var6, var7, 0, 0, false);
        }

        // original public static void a(int x10)
        public static void m_a(int var0, int var1, int var2, int var3, int var4, int var5, int var6, int var7, int var8, int var9)
        {
            m_a(var0, var1, var2, var3, var4, var5, var6, var7, var8, var9, false);
        }

        // original private static void a(int x10, boolean)
        private static void m_a(int var0, int var1, int var2, int var3, int var4, int var5, int var6, int var7, int var8, int var9, bool var10)
        {
            if (ba < 50)
            {
                if (var10)
                {
                    Array.Copy(aZ, 0, aZ, 7, ba * 7);
                }

                int var11 = (var10 ? 0 : ba) * 7;
                aZ[var11++] = var0;
                aZ[var11++] = var1;
                aZ[var11++] = var2;
                aZ[var11++] = var3;
                aZ[var11++] = var4 & 0xFF | var5 << 8;
                aZ[var11++] = var6 & 0xFF | var7 << 8;
                aZ[var11] = var8 & 0xFF | var9 << 8;
                ba++;
            }
        }

        // original private static int[] a(d)
        private static int[] m_a(d var0)
        {
            int[] var1;
            m_a(((var1 = var0.m_c())[0] >> 8) - 20, (var1[1] >> 8) - 15, 53, (var1[3] - var1[1] >> 8) + 30, 1, 52, 2, 52);
            m_a((var1[2] >> 8) - 13, (var1[1] >> 8) - 15, 53, (var1[3] - var1[1] >> 8) + 30, 1, 54, 2, 54);
            return var1;
        }

        private void m_h()
        {
            this.KeyPressed(53);
            this.KeyReleased(53);
        }

        private void m_i()
        {
            this.KeyPressed(50);
            this.KeyReleased(50);
        }

        private void m_j()
        {
            this.KeyPressed(56);
            this.KeyReleased(56);
        }

        private void m_k()
        {
            this.KeyPressed(52);
            this.KeyReleased(52);
        }

        private void m_l()
        {
            this.KeyPressed(54);
            this.KeyReleased(54);
        }

        private void m_m()
        {
            this.KeyPressed(-7);
            this.KeyReleased(-7);
        }

        private void m_d(int var1)
        {
            this.KeyPressed(var1);
        }

        private void m_e(int var1)
        {
            this.KeyReleased(var1);
        }

        // original private void b(int,int) - synthetic action dispatcher
        private void m_b(int var1, int var2)
        {
            switch (var1)
            {
                case 1:
                    this.m_d(var2);
                    return;
                case 2:
                    this.m_e(var2);
                    return;
                case 3:
                    this.m_h();
                    return;
                case 4:
                    this.m_i();
                    return;
                case 5:
                    this.m_j();
                    return;
                case 6:
                    this.m_k();
                    return;
                case 7:
                    this.m_l();
                    return;
                case 8:
                    U[0] = var2;
                    return;
                case 9:
                    U[0] = var2;
                    this.m_h();
                    return;
                case 10:
                    if (var2 == 0)
                    {
                        this.m_k();
                    }
                    else
                    {
                        this.m_l();
                    }

                    this.m_h();
                    return;
                case 11:
                    return;
                case 12:
                    if ((var2 & 1048576) != 0)
                    {
                        this.m_l();
                    }

                    if ((var2 & 2097152) != 0)
                    {
                        this.m_k();
                        return;
                    }
                    break;
                case 13:
                    if ((var2 & 1048576) != 0)
                    {
                        this.m_l();
                    }

                    if ((var2 & 2097152) != 0)
                    {
                        this.m_k();
                        return;
                    }
                    break;
                case 14:
                    if ((var2 & 1048576) != 0)
                    {
                        this.m_l();
                    }

                    if ((var2 & 2097152) != 0)
                    {
                        this.m_k();
                        return;
                    }
                    break;
                case 15:
                    return;
                case 16:
                    this.m_h();
                    return;
                case 17:
                    if (var2 > 0)
                    {
                        this.m_j();
                        return;
                    }

                    if (var2 <= 0)
                    {
                        this.m_i();
                        return;
                    }
                    break;
                case 18:
                    return;
                case 19:
                    this.m_h();
                    return;
                case 20:
                    return;
                case 21:
                    return;
                case 22:
                    bF[2] = var2;
                    bF[4] = bF[1];
                    return;
                case 23:
                    this.m_m();
                    return;
                case 24:
                    return;
                case 25:
                    if (aY)
                    {
                        Console.WriteLine("Minimap Location: " + var2);
                        return;
                    }
                    break;
                case 26:
                    i = var2;
                    this.m_h();
                    return;
                case 27:
                case 28:
                default:
                    break;
                case 29:
                    B = (sbyte)var2;
                    break;
            }
        }

        // original private static int f(int)
        private static int m_f(int var0)
        {
            return (var0 << 8) / 3;
        }

        // original private static int g(int)
        private static int m_g(int var0)
        {
            return (var0 + 42) * 3 >> 8;
        }

        // original static void c() - pathfinding grid init
        internal static void m_c()
        {
            bs = MiamiNights.f.t * 3;
            bt = MiamiNights.f.u * 3;
            bm = new sbyte[bs * bt];

            for (int var0 = 0; var0 < bm.Length; var0++)
            {
                bm[var0] = (sbyte)(MiamiNights.f.m_a(m_f(var0 % bs), m_f(var0 / bs), 127) ? 2 : 0);
            }
        }

        // original static void d() - pathfinding teardown
        internal static void m_d()
        {
            bo = null;
            br = null;
            bp = 1;
            bq = 0;
            bn = null;
            bm = null;
        }

        // original private void n() - tap -> world path
        private void m_n()
        {
            bi[0] = bi[0] + MiamiNights.f.C;
            bi[1] = bi[1] - 75 + MiamiNights.f.D;

            try
            {
                MiamiNights.f.m_b(bi[0], bi[1], bi);
            }
            catch (Exception)
            {
            }

            bi[0] = m_g(bi[0]);
            bi[1] = m_g(bi[1]);
            if (bi[0] >= 0 && bi[1] >= 0)
            {
                try
                {
                    m_o();
                }
                catch (Exception)
                {
                }

                m_b(true);
                m_b(false);
            }
        }

        // original private static void o()
        private static void m_o()
        {
            bo = new int[bs * bt];
            br = new int[bs * bt];
            bn = new sbyte[bs * bt];
            Array.Copy(bm, 0, bn, 0, bs * bt);

            for (int var0 = 1; var0 < s.Length; var0++)
            {
                g var1;
                if ((var1 = s[var0]) != null)
                {
                    for (int var4 = 0; var4 < bu.Length; var4++)
                    {
                        int var2 = m_g(var1.c[0] + bu[var4]);
                        int var3 = m_g(var1.c[1] + bu[++var4]);
                        if (var2 <= 0 || var3 <= 0 || var2 > bs || var3 > bt)
                        {
                            break;
                        }

                        bn[var2 + var3 * bs] = 1;
                    }
                }
            }
        }

        // original private static void p()
        private static void m_p()
        {
            bl = m_g(s[0].c[1]) * bs + m_g(s[0].c[0]);
        }

        // original private static void c(int,int)
        private static void m_c(int var0, int var1)
        {
            br[var0] = var1;
            bo[bq++] = var0;
            bn[var0] = 3;
        }

        // original private static void b(boolean) - BFS path search
        private static void m_b(bool var0)
        {
            try
            {
                bq = 0;
                bp = 0;
                m_p();
                br[bl] = -1;
                int var1 = bi[0] + bi[1] * bs;
                if (var0)
                {
                    if (bn[var1] == 0)
                    {
                        return;
                    }

                    bo[bq++] = var1;
                }
                else
                {
                    if (var1 == bl)
                    {
                        bp = 1;
                        return;
                    }

                    bo[bq++] = bl;
                }

                while (bq > bp)
                {
                    int var2 = bo[bp++];
                    bn[var2] = 3;

                    for (int var3 = 0; var3 < bv.Length; var3++)
                    {
                        int var4 = var2 % bs + bv[var3];
                        var3++;
                        int var5 = var2 / bs + bv[var3];
                        if (var4 > 0 && var5 > 0 && var4 < bs && var5 < bt)
                        {
                            int var6 = var5 * bs + var4;
                            if (var0)
                            {
                                if (bn[var6] == 0)
                                {
                                    bi[0] = var4;
                                    bi[1] = var5;
                                    return;
                                }

                                m_c(var6, var2);
                            }
                            else
                            {
                                if (bi[0] == var4 && bi[1] == var5)
                                {
                                    br[var6] = var2;
                                    bq = 0;
                                    bp = 0;

                                    for (int var7 = var6; var7 >= 0; var7 = br[var7])
                                    {
                                        bo[bq++] = var7;
                                    }

                                    bq--;
                                    if (bq > 0)
                                    {
                                        int var13 = m_f(bo[bq - 1] % bs);
                                        int var8 = m_f(bo[bq - 1] / bs);
                                        int var9 = m_f(bo[bq] % bs) - var13;
                                        int var10 = m_f(bo[bq] / bs) - var8;
                                        var13 = s[0].c[0] - var13;
                                        var8 = s[0].c[1] - var8;
                                        if (var9 * var9 + var10 * var10 >= var13 * var13 + var8 * var8)
                                        {
                                            bq--;
                                        }
                                    }

                                    return;
                                }

                                if (bn[var6] == 0)
                                {
                                    m_c(var6, var2);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception var11)
            {
                Console.WriteLine(var11);
            }

            bq = 0;
            Console.WriteLine("path not found" + var0);
        }

        // original private static boolean a(long,long)
        private static bool m_a(long var0, long var2)
        {
            return ((var2 - var0) * (var2 - var0) << 8) / 1048576L + ((var0 + var2) * (var0 + var2) << 8) / 2359296L <= 256L;
        }

        // original private static boolean b(long,long)
        private static bool m_b(long var0, long var2)
        {
            return ((var2 - var0) * (var2 - var0) << 8) / 1048576L + ((var0 + var2) * (var0 + var2) << 8) / 2359296L <= 236L;
        }

        // original private static void c(int,int,int,int) - walkable midpoint search
        private static void m_c(int var0, int var1, int var2, int var3)
        {
            int var4 = 0;

            while (var4 < 10)
            {
                var4++;
                bw = (var0 + var2) / 2;
                bx = (var1 + var3) / 2;
                if (m_b((long)bw, (long)bx))
                {
                    var0 = bw;
                    var1 = bx;
                }
                else
                {
                    if (m_a((long)bw, (long)bx))
                    {
                        break;
                    }

                    var2 = bw;
                    var3 = bx;
                }
            }

            if (var4 >= 10)
            {
                bw = var0;
                bx = var1;
            }
        }

        // original private void q() - per-frame input pump
        private void m_q()
        {
            this.m_f();
            this.m_g();

            for (int var1 = 0; var1 < 15; var1++)
            {
                aC[var1] = aD[var1];
                if (var1 == 5)
                {
                    aP = false;
                    if (aD[var1] == 1 || aD[var1] == -1)
                    {
                        aP = true;
                    }
                }

                if (aD[var1] != 0)
                {
                    if (aD[var1] < 0)
                    {
                        aD[var1] = 0;
                    }
                    else if (aD[var1] < 126)
                    {
                        aD[var1]++;
                        if (var1 >= 13)
                        {
                            aD[var1] = (sbyte)(aD[var1] * -1);
                        }
                    }
                }
            }
        }

        // original private static void r() - key state reset
        private static void m_rKeepDirections()
        {
            for (int var0 = 0; var0 < 15; var0++)
            {
                if (var0 >= 1 && var0 <= 4 && aD[var0] > 0) continue;   // 1 up, 2 down, 3 left, 4 right
                aC[var0] = 0;
                aD[var0] = 0;
            }
        }

        private static void m_r()
        {
            for (int var0 = 0; var0 < 15; var0++)
            {
                aC[var0] = 0;
                aD[var0] = 0;
            }
        }

        // original private static void c(Graphics,int,int) - NPC sprite step
        private static void m_c(Graphics var0, int var1, int var2)
        {
            v[17].d_.m_a(var0, 86, 0, var1, var2, 0, 0, 0);
            d var3;
            (var3 = n[0]).a = var1 << 8;
            var3.b = var2 << 8;
            var3.d_.m = s[0].b[15];
            var3.m_a(var0);
            var3.m_b();
            if (var3.m_a())
            {
                c[0]++;
                c[0] = (sbyte)(c[0] % (c.Length - 1));
                var3.m_a(c[c[0] + 1]);
            }
        }

        // original static void a(Graphics,int,int,int,int,int) - softkey/tooltip renderer (long if/else on frame id)
        internal static void m_a(Graphics var0, int var1, int var2, int var3, int var4, int var5)
        {
            int var7 = -1;
            int var8 = -1;
            string var9 = null;
            int var10;
            if (h_ == 18)
            {
                if (bF[0] == -1)
                {
                    var10 = v[13].e;
                }
                else
                {
                    var10 = v[14].e;
                }
            }
            else
            {
                var10 = v[7].e;
            }

            int var11 = 0;   // CFR: int (VF byte mis-inference)
            int var12 = 0;   // CFR: int (VF byte mis-inference)
            if (var2 == 255)
            {
                var11 = 17;
            }
            else if (var3 == 255)
            {
                var11 = 24;
            }
            else
            {
                var11 = 20;
            }

            var0.SetClip(0, 0, 240, 400);
            if (var10 != 24)
            {
                if (var10 == 25)
                {
                    d var13 = v[5];
                    if (var2 == 255)
                    {
                        var11 = 17;
                    }
                    else if (var3 == 255)
                    {
                        var11 = 20;
                    }
                    else
                    {
                        var11 = 24;
                    }

                    var4 = 240 - var4;
                    bool var14 = h_ == 17 && i == 63;
                    bG = z == 0 || y == 0 || z == 21;
                    if (y != 25)
                    {
                        switch (var1)
                        {
                            case 1:
                                if (var14)
                                {
                                    var8 = 909;
                                }
                                else if ((h_ == 16 || h_ == 15) && y != 77)
                                {
                                    var8 = 0;
                                }
                                break;
                            case 2:
                                if (h_ != 16 && !var14 && h_ != 15)
                                {
                                    if (h_ != 17 && y != 67)
                                    {
                                        v[10].m_a(3);
                                        v[10].a = var4 << 8;
                                        v[10].b = var5 << 8;
                                        v[10].m_a(var0);
                                        if (h_ != 18 && y != 3 && y != 4 && y != 34 && y != 16)
                                        {
                                            var13.e = -1;
                                            var13.m_a(0);
                                            var13.a = var4 << 8;
                                            var13.b = var5 << 8;
                                            var13.m_a(var0);
                                        }
                                    }
                                }
                                else if (y != 77)
                                {
                                }
                                goto case 3;   // Java: case 2 falls into case 3/default -> break
                            case 3:
                            default:
                                break;
                            case 4:
                                if (h_ == 15)
                                {
                                    var8 = 401;
                                }
                                else if (h_ == 17 && i == 63)
                                {
                                    var8 = 849;
                                }
                                else if (h_ == 17)
                                {
                                    var8 = 848;
                                }
                                else if (y == 27 && MiamiNights.f.bc[31] == 0)
                                {
                                    if ((MiamiNights.g.ah[14] == 1 || MiamiNights.g.ah[7] == 1 || MiamiNights.g.ah[28] == 1) && !@as)
                                    {
                                        var8 = 875;
                                    }
                                }
                                else if (y == 77)
                                {
                                    var8 = 849;
                                }
                                else if (y == 67)
                                {
                                    var8 = 849;
                                }
                                else if (h_ != 16 && bG)
                                {
                                    var8 = 796;
                                }
                                break;
                        }
                    }
                }
                else if (var10 == 27 && var1 == 1)
                {
                    var7 = 39;
                }
                else if (var10 == 29 && var1 == 2)
                {
                    var7 = 40;
                }
                else if (var10 == 26 && var1 == 2)
                {
                    var7 = MiamiNights.g.ao & 255;
                }
                else if (var10 == 47)
                {
                    switch (var1)
                    {
                        case 2:
                            var0.DrawImage(Q, 0, 0, 20);
                            break;
                        case 3:
                            d var35;
                            if (h_ != 7 && !MiamiNights.f.ah && (var35 = n[0]).d_.w != null && var35.d_.w[0] != null)
                            {
                                v[17].d_.m_a(var0, 86, 0, var4, var5, 0, 0, 0);
                                var35.m_a(0);
                                var35.a = var4 << 8;
                                var35.b = var5 << 8;
                                var35.d_.m = s[0].b[15];
                                var35.m_a(var0);
                            }
                            break;
                        case 4:
                            if (MiamiNights.g.ad != null)
                            {
                                if ((MiamiNights.g.ae & 256) == 256 && X == 0)
                                {
                                    var9 = MiamiNights.g.m_b(GloftMMN.m_k(914), 215);
                                }
                                else
                                {
                                    var9 = MiamiNights.g.m_b(MiamiNights.g.ad, 215);
                                }

                                var11 = 17;
                                var4 = 120;
                            }
                            goto case 5;   // Java: case 4 falls into empty case 5 -> switch end
                        case 5:
                            break;
                    }
                }
                else if (var10 == 48)
                {
                    if (var1 == 5)
                    {
                        var12 = 1;
                        var9 = MiamiNights.g.m_b(GloftMMN.m_k(820), 229);
                    }
                }
                else if (var10 == 49)
                {
                    if (var1 > 0)
                    {
                        if (s[0].a[0] == 0)
                        {
                            var8 = 822 + (var1 - 1);
                        }
                        else
                        {
                            var8 = 926 + (var1 - 1);
                        }
                    }
                    else
                    {
                        var8 = 821;
                    }
                }
                else if (var10 == 50)
                {
                    if (var1 == 1)
                    {
                        m_c(var0, var4, var5 - 21);
                    }
                }
                else if (var10 == 51)
                {
                    if (var1 == 2)
                    {
                        var9 = MiamiNights.g.m_b(GloftMMN.m_k(828), 229);
                    }
                }
                else
                {
                    // Java: label745: switch (h) - break label745 -> label after this switch
                    switch (h_)
                    {
                        case 15:
                            var12 = 0;
                            switch (var1)
                            {
                                case 1:
                                    var8 = 863;
                                    goto label745;
                                case 2:
                                    sbyte var67 = 1;
                                    if (MiamiNights.f.m_l())
                                    {
                                        var67 = 0;
                                    }
                                    else if (MiamiNights.f.m_j())
                                    {
                                        var67 = 3;
                                    }
                                    else if (MiamiNights.f.m_k())
                                    {
                                        var67 = 2;
                                    }

                                    u[5].m_a(var0, var67, 0, var4, var5, 0, 0, 0);
                                    goto case 10;   // Java: case 2 falls into case 10
                                case 10:
                                    goto label745;
                                default:
                                    sbyte var33 = 22;
                                    int var75 = 0;
                                    int var79 = 0;

                                    for (int var80 = 0; var80 < 39; var80++)
                                    {
                                        if (MiamiNights.g.h[var80] == var1 - 3 && MiamiNights.g.ah[var80] == 1 && MiamiNights.g.f[var80] == 1)
                                        {
                                            var79++;
                                        }
                                    }

                                    if (i == var1 - 3)
                                    {
                                        var33 = 23;
                                    }
                                    else if (MiamiNights.g.aa == var1 - 3)
                                    {
                                        var75 = K % 12 < 6 ? 0 : 1;
                                        var33 = 24;
                                    }
                                    else if (var79 == 0)
                                    {
                                        var33 = 96;
                                    }

                                    if (var33 == 96)
                                    {
                                        u[1].m_a(var0, 96, 0, var4, var5, 0, 0, 0);
                                        int[] var81 = new int[] { 0, 0, 0, 0 };
                                        u[1].m_a(var81, var33, 0, var4 << 8, var5 << 8, 0, 0, 0);
                                        m_b((var81[0] >> 8) - 10, (var81[1] >> 8) - 10, (var81[2] - var81[0] >> 8) + 20, (var81[3] - var81[1] >> 8) + 20, 26, var1 - 3);
                                    }
                                    else
                                    {
                                        u[0].m_a(var0, var33, var75, var4, var5, 0, 0, 0);
                                        int[] var82 = new int[] { 0, 0, 0, 0 };
                                        u[0].m_a(var82, var33, 0, var4 << 8, var5 << 8, 0, 0, 0);
                                        m_b((var82[0] >> 8) - 10, (var82[1] >> 8) - 10, (var82[2] - var82[0] >> 8) + 20, (var82[3] - var82[1] >> 8) + 20, 26, var1 - 3);
                                    }

                                    if (var33 == 24)
                                    {
                                        u[1].m_a(var0, 88, var75, var4, var5, 0, 0, 0);
                                        int[] var83 = new int[] { 0, 0, 0, 0 };
                                        u[1].m_a(var83, var33, 0, var4 << 8, var5 << 8, 0, 0, 0);
                                        m_b((var83[0] >> 8) - 10, (var83[1] >> 8) - 10, (var83[2] - var83[0] >> 8) + 20, (var83[3] - var83[1] >> 8) + 20, 26, var1 - 3);
                                    }

                                    if (var33 == 23)
                                    {
                                        int[] var84 = new int[] { 0, 0, 0, 0 };
                                        u[0].m_a(var84, var33, 0, var4 << 8, var5 << 8, 0, 0, 0);
                                        d var25;
                                        (var25 = v[2]).a = (var84[0] + var84[2]) / 2;
                                        var25.b = var84[1];
                                        var25.m_a(var0);
                                        var25.m_b();
                                        if (var25.e == 2 && var25.m_a())
                                        {
                                            var25.m_a(3);
                                        }

                                        m_b(((var84 = var25.m_c())[0] >> 8) - 10, (var84[1] >> 8) - 10, (var84[2] - var84[0] >> 8) + 20, (var84[3] - var84[1] >> 8) + 20, 3, 0);
                                    }

                                    if (var1 - 3 == MiamiNights.g.h[H] && aG % 12L < 8L)
                                    {
                                        u[0].m_a(var0, 26, 0, var4, var5, 0, 0, 0);
                                    }

                                    if (MiamiNights.f.bc[0] >= 30 && var1 - 3 == 2 || MiamiNights.f.bc[0] < 30 && var1 - 3 == 0)
                                    {
                                        u[0].m_a(var0, 25, 0, var4, var5, 0, 0, 0);
                                    }

                                    if (MiamiNights.f.bc[25] != -1)
                                    {
                                        sbyte var86 = MiamiNights.f.bc[24];
                                        sbyte var87 = MiamiNights.g.h[var86];
                                        if (var1 - 3 == var87)
                                        {
                                            u[1].m_a(var0, 94, 0, var4, var5, 0, 0, 0);
                                        }
                                    }
                                    goto label745;
                            }
                            goto case 16;   // Java: case 15 falls into case 16 (unreachable: inner switch always exits)
                        case 16:
                            g var53 = s[0];
                            switch (y)
                            {
                                case 24:
                                    if (var10 == 13)
                                    {
                                        switch (var1)
                                        {
                                            case 12:
                                                var8 = 860;
                                                goto label745;
                                            case 13:
                                                var12 = 1;
                                                var9 = GloftMMN.m_k(861) + " " + GloftMMN.m_k(s[4].a[1]);
                                                goto label745;
                                            case 14:
                                                var12 = 1;
                                                MiamiNights.g.m_b(MiamiNights.g.ad, 240 - var4 * 2);
                                                var11 = 17;
                                                var4 = 112;
                                                var9 = MiamiNights.g.m_b(MiamiNights.g.ad, 212);
                                                goto label745;
                                            case 15:
                                                Image var74 = MiamiNights.g.U[3];
                                                var0.DrawImage(var74, var4 - var74.GetWidth() / 2, var5 - var74.GetHeight() / 2, 20);
                                                goto case 16;   // Java: case 15 falls into empty case 16
                                            case 16:
                                                break;
                                        }
                                    }
                                    goto label745;
                                case 25:
                                    if (var10 == 15)
                                    {
                                        g var32 = s[1 + bF[0]];
                                        var12 = 1;
                                        switch (var1)
                                        {
                                            case 14:
                                                var12 = 0;
                                                var8 = 856;
                                                goto label745;
                                            case 15:
                                                var8 = var32.a[1];
                                                goto label745;
                                            case 16:
                                                if (bF[2] + bF[3] + bF[4] == 3)
                                                {
                                                    var8 = 858;
                                                }
                                                else
                                                {
                                                    var8 = 859;
                                                }
                                                goto label745;
                                            case 17:
                                                Image var73 = MiamiNights.g.U[bF[0]];
                                                var0.DrawImage(var73, var4 - var73.GetWidth() / 2, var5 - var73.GetHeight() / 2, 20);
                                                goto label745;
                                            case 18:
                                                var9 = MiamiNights.g.m_b(GloftMMN.m_k(806 + bF[0] * 2), 240 - var4 * 2);
                                                break;
                                        }
                                    }
                                    goto label745;
                                case 26:
                                    int var63 = var1 + bF[0];
                                    if (var1 >= 20 && var1 <= 23)
                                    {
                                        var63 -= 20;
                                        var8 = 180 + V[var63];
                                    }
                                    else if (var1 >= 24 && var1 <= 27)
                                    {
                                        var63 -= 24;
                                        MiamiNights.f.m_a(var0, V[var63], var4, var5, 5);
                                    }
                                    else if (var1 >= 33 && var1 <= 36)
                                    {
                                        var63 -= 33;
                                        var12 = 1;
                                        var9 = var53.a[V[var63]].ToString();
                                    }
                                    else
                                    {
                                        switch (var1)
                                        {
                                            case 19:
                                                var9 = af;
                                                goto case 20;   // Java: case 19 falls into case 20-group
                                            case 20:
                                            case 21:
                                            case 22:
                                            case 23:
                                            case 24:
                                            case 25:
                                            case 26:
                                            case 27:
                                            case 33:
                                            case 34:
                                            case 35:
                                            case 36:
                                            default:
                                                goto label745;
                                            case 28:
                                                var7 = 84 + var53.a[0];
                                                goto label745;
                                            case 29:
                                                var7 = 79;
                                                goto label745;
                                            case 30:
                                                var7 = 92;
                                                goto label745;
                                            case 31:
                                                var7 = 62;
                                                goto label745;
                                            case 32:
                                                var7 = 95;
                                                goto label745;
                                            case 37:
                                                var12 = 1;
                                                var9 = MiamiNights.f.m_e(var53.a[35]);
                                                goto label745;
                                            case 38:
                                                var8 = 887;
                                                goto label745;
                                            case 39:
                                                var9 = var53.a[36].ToString();
                                                goto label745;
                                            case 40:
                                                var9 = var53.a[37].ToString();
                                                goto label745;
                                            case 41:
                                                var9 = var53.a[38].ToString();
                                                goto label745;
                                            case 42:
                                                n[0].d_.m = var53.b[15];
                                                n[0].d_.m_a(var0, 0, 0, var4, var5, 0, 0, 0);
                                                break;
                                        }
                                    }
                                    goto label745;
                                case 27:
                                    if (var10 == 20)
                                    {
                                        var12 = 1;
                                        switch (var1)
                                        {
                                            case 8:
                                                var12 = 0;
                                                var8 = 802;
                                                break;
                                            case 9:
                                                var8 = 874;
                                                break;
                                            case 10:
                                                var8 = 803;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        g var72 = s[MiamiNights.g.G[bF[0]]];
                                        switch (var1)
                                        {
                                            case 3:
                                                var7 = 84 + var72.a[0];
                                                break;
                                            case 4:
                                                if (var10 == 21)
                                                {
                                                    var12 = 1;
                                                }

                                                var8 = var72.a[1];
                                                break;
                                            case 5:
                                                MiamiNights.g.m_a(var0, var72, var4, var5);
                                                break;
                                        }
                                    }
                                    goto label745;   // Java: case 27 falls into default: break label745
                            }
                            goto case 17;   // Java: case 16 falls into case 17 (unreachable: switch(y) always exits)
                        case 17:
                            g var31 = s[0];
                            int var37;
                            int var38 = ((var37 = 7 + var31.a[0] * 2) - 7) / 2;
                            bool var42 = false;
                            bool var47 = false;
                            if (var10 == 33)
                            {
                                switch (var1)
                                {
                                    case 25:
                                        var8 = 814;
                                        goto case 26;   // Java: falls into 26-group
                                    case 26:
                                    case 28:
                                    case 32:
                                    case 34:
                                    case 41:
                                    default:
                                        goto label745;
                                    case 27:
                                        var8 = 180;
                                        goto label745;
                                    case 29:
                                        var8 = 181;
                                        goto label745;
                                    case 30:
                                        var7 = 84 + var31.a[0];
                                        goto label745;
                                    case 31:
                                        var9 = af;
                                        goto label745;
                                    case 33:
                                        var8 = 885;
                                        goto label745;
                                    case 35:
                                        var9 = "" + (var31.a[4] + 1);
                                        goto label745;
                                    case 36:
                                        var9 = "" + (var31.a[6] + 1);
                                        goto label745;
                                    case 37:
                                        var9 = "" + (var31.a[8] + 2);
                                        goto label745;
                                    case 38:
                                        var0.SetColor(p[var38][5].k[var31.a[5]][2]);
                                        var0.FillRect(var4, var5, 23, 12);
                                        goto label745;
                                    case 39:
                                        var0.SetColor(p[var38][2].k[var31.a[7]][5]);
                                        var0.FillRect(var4, var5, 23, 12);
                                        goto label745;
                                    case 40:
                                        var0.SetColor(p[var38][4].k[var31.a[9]][5]);
                                        var0.FillRect(var4, var5, 23, 12);
                                        goto label745;
                                    case 42:
                                        var8 = 192;
                                        goto label745;
                                    case 43:
                                        var0.SetColor(W[var31.a[12]]);
                                        var0.FillRect(var4, var5, 23, 12);
                                        break;
                                }
                            }
                            else if ((var10 != 34 || var1 != 1) && (var10 != 41 || var1 != 2))
                            {
                                if (i == 0)
                                {
                                    var12 = 1;
                                    if (var1 == 2)
                                    {
                                        var8 = 180;
                                    }
                                    else if (var1 == 3)
                                    {
                                        var7 = 84 + var31.a[0];
                                    }
                                }
                                else if (i == 1 || i == 63)
                                {
                                    var12 = 1;
                                    if (var1 == 2)
                                    {
                                        var8 = 181;
                                    }
                                    else if (var1 == 3)
                                    {
                                        var9 = af;
                                    }
                                }
                                else if (i == 2)
                                {
                                    var12 = 1;
                                    var8 = 885;
                                }
                                else if (var10 == 44)
                                {
                                    if (var1 == 5)
                                    {
                                        var0.SetColor(p[var38][5].k[var31.a[5]][2]);
                                        var0.FillRect(var4, var5, 23, 12);
                                    }
                                    else if (var1 == 6)
                                    {
                                        var0.SetColor(p[var38][2].k[var31.a[7]][5]);
                                        var0.FillRect(var4, var5, 23, 12);
                                    }
                                    else if (var1 == 7)
                                    {
                                        var0.SetColor(p[var38][4].k[var31.a[9]][5]);
                                        var0.FillRect(var4, var5, 23, 12);
                                    }
                                }
                                else if (var10 == 45)
                                {
                                    if (var1 == 3)
                                    {
                                        var0.SetColor(W[var31.a[12]]);
                                        var0.FillRect(var4, var5, 23, 12);
                                    }
                                    else if (var1 == 4)
                                    {
                                        var12 = 1;
                                        var8 = 192;
                                    }
                                }
                            }
                            else
                            {
                                d var52;
                                (var52 = n[0]).a = var4 << 8;
                                var52.b = var5 << 8;
                                var52.d_.m = var31.b[15];
                                var52.m_a(var0);
                                var52.m_b();
                                if (var52.m_a())
                                {
                                    c[0]++;
                                    c[0] = (sbyte)(c[0] % (c.Length - 1));
                                    var52.m_a(c[c[0] + 1]);
                                }
                            }
                            break;
                        case 18:
                            g var6 = s[0];
                            int var36;
                            int var15 = ((var36 = 7 + var6.a[0] * 2) - 7) / 2;
                            d var17 = null;
                            int var16 = bF[1];
                            switch (y) // Java: label743: switch (y) - break label743 -> label after this switch
                            {
                                case 40:
                                case 41:
                                case 42:
                                case 56:
                                case 59:
                                case 60:
                                case 62:
                                case 63:
                                case 64:
                                    bool var51 = bF[2] == 0;
                                    if (bF[0] == -1)
                                    {
                                        if (var10 == 2)
                                        {
                                            switch (var1)
                                            {
                                                case 10:
                                                    for (int var44 = 0; var44 < 9; var44++)
                                                    {
                                                        sbyte var57 = 9;
                                                        int var68;
                                                        if ((var68 = var44 + bF[3] * 9) == bF[1])
                                                        {
                                                            var57 = 11;
                                                            bF[6] = var4;
                                                            bF[7] = var5 + var44 * 22;
                                                        }

                                                        if (var68 <= ac)
                                                        {
                                                            (var17 = v[14]).m_a(var57);
                                                            var17.a = var4 << 8;
                                                            var17.b = var5 + var44 * 22 << 8;
                                                            if (var57 == 11)
                                                            {
                                                                m_b();
                                                                int[] var23;
                                                                m_b((var23 = var17.m_c())[0] >> 8, var23[1] >> 8, var23[2] - var23[0] >> 8, var23[3] - var23[1] >> 8, 3, 0);
                                                            }

                                                            bF[0] = var44;
                                                            var17.m_a(var0);
                                                        }
                                                    }

                                                    bF[0] = -1;
                                                    if (bF[5] >= 2 && bF[5] == 2)
                                                    {
                                                        if (var16 == 0)
                                                        {
                                                            m_h(0);
                                                        }
                                                        else
                                                        {
                                                            m_h(ab[var16 - 1] + 1);
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                        else if (var10 == 1)
                                        {
                                            switch (var1)
                                            {
                                                case 12:
                                                    for (int var45 = 0; var45 < 9; var45++)
                                                    {
                                                        sbyte var59;
                                                        int var69;
                                                        if ((var69 = var45 + bF[3] * 9) == bF[1])
                                                        {
                                                            var59 = 11;
                                                            bF[6] = var4;
                                                            bF[7] = var5 + var45 * 22;
                                                        }
                                                        else
                                                        {
                                                            var59 = 10;
                                                        }

                                                        if (var69 <= s[0].b[1] - 1)
                                                        {
                                                            (var17 = v[14]).m_a(var59);
                                                            var17.a = var4 << 8;
                                                            var17.b = var5 + var45 * 22 << 8;
                                                            if (var59 == 11)
                                                            {
                                                                m_b();
                                                                int[] var76;
                                                                m_b((var76 = var17.m_c())[0] >> 8, var76[1] >> 8, var76[2] - var76[0] >> 8, var76[3] - var76[1] >> 8, 3, 0);
                                                            }

                                                            bF[0] = var45;
                                                            var17.m_a(var0);
                                                        }
                                                    }

                                                    bF[0] = -1;
                                                    break;
                                                case 13:
                                                    if (bF[5] >= 2 && bF[5] == 2)
                                                    {
                                                        m_h(var16);
                                                    }
                                                    break;
                                                case 14:
                                                    if (y == 63)
                                                    {
                                                        bF[0] = 1;
                                                        d var58;
                                                        (var58 = v[14]).m_a(14);
                                                        var58.a = var4 << 8;
                                                        var58.b = var5 << 8;
                                                        var58.m_a(var0);
                                                        bF[0] = -1;
                                                    }
                                                    break;
                                                case 15:
                                                    if (y != 63)
                                                    {
                                                        var1 = var6.a[5];
                                                        var0.SetColor(p[var15][5].k[var1][2]);
                                                        var0.FillRect(var4, var5, 23, 12);
                                                    }
                                                    break;
                                                case 16:
                                                    var12 = 1;
                                                    var8 = 850;
                                                    break;
                                                case 17:
                                                    var7 = 79;
                                                    break;
                                                case 18:
                                                    var12 = 1;
                                                    var9 = MiamiNights.f.m_e(10);
                                                    goto case 19;   // Java: case 18 falls into case 19/default group
                                                case 19:
                                                default:
                                                    break;
                                                case 20:
                                                    var12 = 1;
                                                    var8 = 170;
                                                    break;
                                            }
                                        }
                                        else if (var10 == 0)
                                        {
                                            switch (var1)
                                            {
                                                case 12:
                                                    for (int var46 = 0; var46 < 9; var46++)
                                                    {
                                                        sbyte var61 = 9;
                                                        int var70;
                                                        if ((var70 = var46 + bF[3] * 9) == bF[1])
                                                        {
                                                            var61 = 11;
                                                            bF[6] = var4;
                                                            bF[7] = var5 + var46 * 22;
                                                        }
                                                        else if (var70 == 0 || var51 && MiamiNights.g.m_b(var70 - 1, -1) != -1 || !var51 && MiamiNights.g.m_b(-1, var70 - 1) != -1)
                                                        {
                                                            var61 = 10;
                                                        }

                                                        if (var70 < bF[4])
                                                        {
                                                            (var17 = v[14]).m_a(var61);
                                                            var17.a = var4 << 8;
                                                            var17.b = var5 + var46 * 22 << 8;
                                                            if (var61 == 11)
                                                            {
                                                                m_b();
                                                                int[] var77;
                                                                m_b((var77 = var17.m_c())[0] >> 8, var77[1] >> 8, var77[2] - var77[0] >> 8, var77[3] - var77[1] >> 8, 3, 0);
                                                            }

                                                            bF[0] = var46;
                                                            var17.m_a(var0);
                                                        }
                                                    }

                                                    bF[0] = -1;
                                                    break;
                                                case 13:
                                                    if (bF[5] >= 2 && bF[5] == 2)
                                                    {
                                                        m_h(var16);
                                                    }
                                                    break;
                                                case 14:
                                                    if (y == 42)
                                                    {
                                                        bF[0] = 1;
                                                        d var60;
                                                        (var60 = v[14]).m_a(14);
                                                        var60.a = var4 << 8;
                                                        var60.b = var5 << 8;
                                                        var60.m_a(var0);
                                                        bF[0] = -1;
                                                    }
                                                    break;
                                                case 15:
                                                    if (y != 42)
                                                    {
                                                        if (bF[2] == 0)
                                                        {
                                                            var1 = MiamiNights.g.m_b(var16 - 1, -1);
                                                        }
                                                        else
                                                        {
                                                            var1 = MiamiNights.g.m_b(-1, var16 - 1);
                                                        }

                                                        if (var1 == -1)
                                                        {
                                                            if (bF[2] == 0)
                                                            {
                                                                var1 = var6.a[7];
                                                            }
                                                            else
                                                            {
                                                                var1 = var6.a[9];
                                                            }
                                                        }

                                                        var1 &= 255;
                                                        var0.SetColor(p[var15][2].k[var1][5]);
                                                        var0.FillRect(var4, var5, 23, 12);
                                                    }
                                                    break;
                                                case 16:
                                                    var12 = 1;
                                                    var8 = 850;
                                                    break;
                                                case 17:
                                                    var7 = 79;
                                                    break;
                                                case 18:
                                                    var12 = 1;
                                                    if (bF[1] != 0)
                                                    {
                                                        var9 = MiamiNights.f.m_e(b[var6.a[0]][bF[2]][bF[1]]);
                                                    }
                                                    else
                                                    {
                                                        var9 = MiamiNights.f.m_e(0);
                                                    }
                                                    break;
                                                case 19:
                                                    if ((var1 = bF[1]) > 0)
                                                    {
                                                        if (bF[2] == 0)
                                                        {
                                                            var1 = MiamiNights.g.m_b(var1 - 1, -1);
                                                        }
                                                        else
                                                        {
                                                            var1 = MiamiNights.g.m_b(-1, var1 - 1);
                                                        }

                                                        if (var1 != -1)
                                                        {
                                                            var8 = 851;
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                        else if (var10 == 3)
                                        {
                                            if (var1 == 1)
                                            {
                                                m_c(var0, var4, var5);
                                            }
                                        }
                                        else if (var10 == 4 || var10 == 6)
                                        {
                                            var12 = 1;
                                            var8 = 852 + (var1 - 1);
                                        }
                                    }
                                    else if (var10 == 14)
                                    {
                                        if (var1 == 3)
                                        {
                                            if (y == 42)
                                            {
                                                var0.SetColor(p[var15][2].k[bF[10]][5]);
                                            }
                                            else if (y == 63)
                                            {
                                                var0.SetColor(p[var15][5].k[var6.a[5]][2]);
                                            }

                                            var0.FillRect(var4, var5, 23, 12);
                                        }
                                    }
                                    else
                                    {
                                        int var62 = bF[0];
                                        int var71 = bF[3] * 9 + var62;
                                        bool var78 = false;
                                        bool var24 = false;
                                        var12 = 1;
                                        if (y == 59 || y == 60)
                                        {
                                            if (var71 == 0)
                                            {
                                                var8 = 854;
                                            }
                                            else
                                            {
                                                var9 = GloftMMN.m_k(855) + " " + ab[var71 - 1];
                                            }
                                        }

                                        if (y != 62 && y != 64 && y != 63)
                                        {
                                            if (var71 == 0)
                                            {
                                                var8 = 854;
                                            }
                                            else
                                            {
                                                var9 = GloftMMN.m_k(855) + " " + (var71 - 1);
                                            }
                                        }
                                        else if (var71 == 0)
                                        {
                                            var8 = 854;
                                        }
                                        else
                                        {
                                            var9 = GloftMMN.m_k(184) + " " + (var71 - 1);
                                        }
                                    }
                                    goto case 43;   // Java: grouped 40-64 section falls into case 43 group
                                case 43:
                                case 44:
                                case 45:
                                case 46:
                                case 47:
                                case 50:
                                case 51:
                                case 52:
                                case 55:
                                case 57:
                                case 58:
                                case 61:
                                default:
                                    break;
                                case 48:
                                case 49:
                                    if (var10 == 16)
                                    {
                                        switch (var1)
                                        {
                                            case 6:
                                                v[17].d_.m_a(var0, 86, 0, var4, var5, 0, 0, 0);
                                                d var49;
                                                (var49 = MiamiNights.f.c[MiamiNights.f.au]).a = var4 << 8;
                                                var49.b = var5 << 8;
                                                int[] var55 = var49.m_c();
                                                var49.a = var49.a - (var55[0] - (var4 << 8));
                                                var49.b = var49.b - (var55[1] - (var5 << 8));
                                                var49.a = var49.a - (var55[2] - var55[0]) / 2;
                                                var49.b = var49.b - (var55[3] - var55[1]);
                                                var49.b += 3584;
                                                var49.m_a(var0);
                                                goto case 7;   // Java: case 6 falls into case 7/default -> break label743
                                            case 7:
                                            default:
                                                goto label743;
                                            case 8:
                                                var12 = 1;
                                                var8 = 850;
                                                goto label743;
                                            case 9:
                                                var7 = 79;
                                                goto label743;
                                            case 10:
                                                var12 = 1;
                                                var9 = MiamiNights.f.m_e(bF[19]);
                                                break;
                                        }
                                    }
                                    else if (var10 == 19)
                                    {
                                        switch (var1)
                                        {
                                            case 3:
                                                d var50;
                                                int var56 = (var50 = MiamiNights.f.c[MiamiNights.f.au]).d_.m;
                                                var0.SetColor(var50.d_.k[var56][1]);
                                                var0.FillRect(var4, var5, 23, 12);
                                                break;
                                        }
                                    }
                                    break;
                                case 53:
                                case 54:
                                    a var18 = MiamiNights.f.b[0];
                                    if (var10 == 16)
                                    {
                                        switch (var1)
                                        {
                                            case 6:
                                                int var20 = bM[MiamiNights.f.bh * 4 + 2] & 255;
                                                int var21 = bM[MiamiNights.f.bh * 4 + 3] & 255;
                                                var18.m = var21;
                                                int[] var22 = new int[] { -22, 0, -22, 22, -44, 11, 0, 11 };

                                                for (int var19 = 0; var19 < 4; var19++)
                                                {
                                                    var18.m_a(var0, var20, var4 + var22[var19 * 2 + 0], var5 + var22[var19 * 2 + 1], 0, 0, 0);
                                                }

                                                var20 = bM[MiamiNights.f.bh * 4 + 0] & 255;
                                                var21 = bM[MiamiNights.f.bh * 4 + 1] & 255;
                                                var18.m = var21;
                                                var18.m_a(var0, var20, var4 - 22, var5 - 11, 0, 0, 0);
                                                var18.m_a(var0, var20, var4 - 44, var5 - 11 + 11, 0, 0, 0);
                                                var18.m_a(var0, var20 + 1, var4, var5 - 11, 0, 0, 0);
                                                var18.m_a(var0, var20 + 1, var4 + 22, var5 - 11 + 11, 0, 0, 0);
                                                goto case 7;   // Java: falls into case 7/default
                                            case 7:
                                            default:
                                                break;
                                            case 8:
                                                var12 = 1;
                                                var8 = 850;
                                                break;
                                            case 9:
                                                var7 = 79;
                                                break;
                                            case 10:
                                                var12 = 1;
                                                var9 = MiamiNights.f.m_e(bF[16]);
                                                break;
                                        }
                                    }
                                    else if (var10 == 19)
                                    {
                                        switch (var1)
                                        {
                                            case 3:
                                                sbyte var43 = 1;
                                                if (y == 54)
                                                {
                                                    var43 = 3;
                                                }

                                                var0.SetColor(var18.k[bM[MiamiNights.f.bh * 4 + var43] & 255][2]);
                                                var0.FillRect(var4, var5, 23, 12);
                                                break;
                                        }
                                    }
                                    break;
                            }

                            label743: ;   // Java: break label743 target (end of switch(y))
                            break;         // case 18 of switch(h) ends (Java falls to switch end)
                    }
                label745: ;   // Java: break label745 target (end of switch(h))
                }
            }

            if (var8 >= 0)
            {
                var9 = GloftMMN.m_k(var8);
            }

            if (var9 != null && var8 != 794 && var8 != 909 && var8 != 849 && var8 != 848 && var8 != 796 && var8 != 401 && var8 != 0 && var8 != 901 && var8 != 875)
            {
                M.m_a(var0, var9, var4, var5, var11, var12);
            }
            else if (var9 != null && (var8 == 794 || var8 == 909 || var8 == 901 || var8 == 875) && var5 > 200)
            {
                if (var4 < 120)
                {
                    m_a(var0, var8, -1);
                }
                else
                {
                    m_a(var0, -1, var8);
                }
            }

            if (var7 >= 0)
            {
                u[1].m_a(var0, var7, 0, var4, var5, 0, 0, 0);
            }
        }

        // original private static void h(int) - apply shop/clothing selection
        private static void m_h(int var0)
        {
            g var1 = s[0];
            int var2;
            int var3 = ((var2 = 7 + var1.a[0] * 2) - 7) / 2;
            int var4 = var1.a[6];
            int var5 = var1.a[8];
            int var6 = var1.a[7] & 0xFF;
            int var7 = var1.a[9] & 0xFF;
            if (var0 > 0)
            {
                if (y >= 62 && y <= 64)
                {
                    var1.a[4] = var0 - 1;
                }
                else if (bF[2] == 0)
                {
                    if (y == 42)
                    {
                        var1.a[7] = bF[10];
                    }
                    else
                    {
                        int var8;
                        if ((var8 = MiamiNights.g.m_b(var0 - 1, -1)) != -1)
                        {
                            var1.a[7] = var8;
                        }
                    }

                    var1.a[6] = var0 - 1;
                }
                else
                {
                    if (y == 42)
                    {
                        var1.a[9] = bF[10];
                    }
                    else
                    {
                        int var10;
                        if ((var10 = MiamiNights.g.m_b(-1, var0 - 1)) != -1)
                        {
                            var1.a[9] = var10;
                        }
                    }

                    var1.a[8] = var0 - 1;
                }
            }

            bF[11] = var1.a[8];
            bF[12] = var1.a[9] & 0xFF;
            bF[13] = var1.a[6];
            bF[14] = var1.a[7] & 0xFF;
            MiamiNights.g.j[var3] = 0;
            MiamiNights.f.m_b(0);

            for (int var11 = 0; var11 < p.Length; var11++)
            {
                if (p[var11] != null)
                {
                    for (int var9 = 0; var9 < p[var11].Length; var9++)
                    {
                        if (p[var11][var9] != null && p[var11][var9].w != null)
                        {
                            p[var11][var9].w = (Image[][])null;
                        }
                    }
                }
            }

            GC.Collect();
            var1.m_a(var2, 0, true);
            var1.a[6] = var4;
            var1.a[8] = var5;
            var1.a[7] = var6;
            var1.a[9] = var7;
        }

        // original private static void a(g) - camera follow / room transition check
        private static void m_a(g var0)
        {
            int[] var1 = new int[2];
            MiamiNights.f.m_a(var0.c[0], var0.c[1], var1);
            short[] var3 = null;
            if (h_ != 18 && y == 1)
            {
                int var8 = F - MiamiNights.f.C;
                int var12 = G - MiamiNights.f.D;
                int var6;
                if ((var6 = GloftMMN.m_a((long)(var8 * var8 + var12 * var12))) < 22)
                {
                    MiamiNights.f.C = F;
                    MiamiNights.f.D = G;
                    if (A == -1)
                    {
                        z = 0;
                    }
                    else
                    {
                        z = A;
                    }

                    A = -1;
                }
                else
                {
                    var8 = (var8 << 8) / var6;
                    var12 = (var12 << 8) / var6;
                    var8 *= 22;
                    var12 *= 22;
                    MiamiNights.f.C += var8 >> 8;
                    MiamiNights.f.D += var12 >> 8;
                }
            }
            else
            {
                if (y != 20 && y != 67)
                {
                    int var4 = 0;
                    var4 = MiamiNights.f.m_b(var1);
                    int var5 = 0;
                    if (MiamiNights.f.d || var4 != -1)
                    {
                        if ((var5 = MiamiNights.f.m_a(var1)) != -1 && ((var3 = MiamiNights.f.e[var5])[1] != F || var3[2] != G))
                        {
                            F = var3[1];
                            G = var3[2];
                            A = y;
                            z = 1;
                        }

                        if (MiamiNights.f.d)
                        {
                            MiamiNights.f.E = -10000;
                            MiamiNights.f.F = -10000;
                            if (var3 != null)
                            {
                                F = var3[1];
                                G = var3[2];
                                MiamiNights.f.C = F;
                                MiamiNights.f.D = G;
                            }
                            else
                            {
                                F = -1;
                                G = -1;
                            }

                            if (y == 0)
                            {
                                MiamiNights.f.m_a(aB, true, true);
                            }
                        }
                    }
                }
            }
        }

        // original private static boolean d(int,int) - options menu state machine
        private static bool m_d(int var0, int var1)
        {
            aB.SetClip(0, 0, 240, 400);
            if (y == 73)
            {
                MiamiNights.f.m_a(aB, false, true);
            }
            else
            {
                k = true;
            }

            int var3 = 0;   // CFR: int (VF byte mis-inference)
            if (z == 73 || y == 73)
            {
                var3 = 1;
            }

            if (var1 == 1)
            {
                m_a(4 - var3, 0, true);
                U[2] = var0 + 0;
                U[3] = var0 + 1;

                for (int var2 = 0; var2 < 4 - var3; var2++)
                {
                    R[var2] = var0 + var2 + 2;
                }

                if (var3 == 0)
                {
                    R[3] = var0 + 11;
                }

                R[4] = var0 + 10;
                U[5] = -1;
            }

            int var5 = U[0];
            if (var1 != 1 && aP)
            {
                if (h_ == 19)
                {
                    aB.DrawImage(Q, 0, 0, 20);
                }

                if (var5 == 0)
                {
                    GloftMMN.f = !GloftMMN.f;
                    if (GloftMMN.f)
                    {
                        if (var0 == 31)
                        {
                            GloftMMN.m_c(5);
                        }
                        else
                        {
                            GloftMMN.m_c(3);
                        }
                    }
                    else
                    {
                        GloftMMN.m_e();
                    }
                }
                else if (var5 == 1)
                {
                    ax = (sbyte)((ax + 1) % 2);
                    sbyte var4 = ag;
                    if (ax == 1)
                    {
                        if (ag == 0)
                        {
                            ag = 2;
                        }
                        else
                        {
                            ag = 3;
                        }
                    }
                    else if (ag != 0)
                    {
                        ag = 1;
                    }

                    m_a(true, false);
                    ag = var4;
                    if (ax == 1)
                    {
                        m_b(1000);
                    }
                }
                else if (var5 == 2)
                {
                    ai = (sbyte)((ai + 1) % 3);
                    aj = false;
                }
                else
                {
                    if (var5 == 3)
                    {
                        if (var3 != 0)
                        {
                            return true;
                        }

                        m_a(20);
                        m_e(var0 + 11, 1);
                        return false;
                    }

                    if (var5 == 4)
                    {
                        return true;
                    }
                }
            }

            sbyte var6 = 6;
            if (GloftMMN.f)
            {
                var6 = 5;
            }

            T[0] = " : " + GloftMMN.m_k(var0 + var6);
            var6 = 6;
            if (ax == 1)
            {
                var6 = 5;
            }

            T[1] = " : " + GloftMMN.m_k(var0 + var6);
            T[2] = " : " + GloftMMN.m_k(var0 + 7 + ai);
            if ((var1 == 1 || k) && Q != null)
            {
                aB.DrawImage(Q, 120, 200, 3);
            }

            m_a(false);
            m_a(aB, false, false);
            return false;
        }

        // original private static boolean e(int,int) - language select menu
        private static bool m_e(int var0, int var1)
        {
            aB.SetClip(0, 0, 240, 400);
            k = true;
            if (var1 == 1)
            {
                if (ay < 0)
                {
                    m_a(6, 0, false);
                }
                else
                {
                    m_a(6, 0, true);
                }

                U[2] = var0;
                U[3] = 32;

                for (int var2 = 0; var2 < 6; var2++)
                {
                    R[var2] = aA[var2];
                }

                if (ay >= 0)
                {
                    R[6] = 41;
                }

                U[5] = -1;
            }

            int var4 = U[0];
            if (var1 != 1 && aP)
            {
                aP = false;
                if (ay >= 0 && var4 == 6)
                {
                    return true;
                }

                if (var4 != ay)
                {
                    bool var3 = ay < 0;
                    ay = var4;
                    GloftMMN.m_a("/3", 1);
                    if (var3)
                    {
                        m_a(3);
                    }
                    else
                    {
                        m_e(var0, 1);
                    }

                    return false;
                }
            }

            if (ay < 0)
            {
                aB.SetColor(0);
                aB.FillRect(0, 0, 240, 400);
            }
            else if ((var1 == 1 || k) && Q != null)
            {
                aB.DrawImage(Q, 120, 200, 3);
            }

            m_a(false);
            m_a(aB, false, false);
            return false;
        }

        // PORT-QUESTION: MIDP Graphics.fillRoundRect/drawRoundRect - engine Graphics has no roundrect members
        // (do-not-edit rule) -> local approximations used at the 8 original call sites; candidate to move into
        // Engine/Midp.cs Graphics later.
        private static void m_fillRoundRect(Graphics g, int x, int y, int w, int h, int arcW, int arcH)
        {
            if (arcW <= 0 || arcH <= 0 || w <= 0 || h <= 0)
            {
                g.FillRect(x, y, w, h);
                return;
            }

            for (int row = 0; row < h; row++)
            {
                int inset = 0;
                if (row < arcH)
                {
                    double dy = (arcH - row - 0.5) / arcH;
                    inset = arcW - (int)(arcW * Math.Sqrt(Math.Max(0.0, 1.0 - dy * dy)));
                }
                else if (row >= h - arcH)
                {
                    double dy = (row - (h - arcH) + 0.5) / arcH;
                    inset = arcW - (int)(arcW * Math.Sqrt(Math.Max(0.0, 1.0 - dy * dy)));
                }

                g.FillRect(x + inset, y + row, w - 2 * inset, 1);
            }
        }

        private static void m_drawRoundRect(Graphics g, int x, int y, int w, int h, int arcW, int arcH)
        {
            if (arcW <= 0 || arcH <= 0 || w <= 0 || h <= 0)
            {
                g.DrawRect(x, y, w, h);
                return;
            }

            g.FillRect(x + arcW, y, w - 2 * arcW, 1);
            g.FillRect(x + arcW, y + h - 1, w - 2 * arcW, 1);
            g.FillRect(x, y + arcH, 1, h - 2 * arcH);
            g.FillRect(x + w - 1, y + arcH, 1, h - 2 * arcH);

            for (int row = 0; row < arcH; row++)
            {
                double dy = (arcH - row - 0.5) / arcH;
                int inset = arcW - (int)(arcW * Math.Sqrt(Math.Max(0.0, 1.0 - dy * dy)));
                int rowTop = y + row;
                int rowBot = y + h - 1 - row;
                g.FillRect(x + inset, rowTop, 1, 1);
                g.FillRect(x + w - 1 - inset, rowTop, 1, 1);
                if (rowBot != rowTop)
                {
                    g.FillRect(x + inset, rowBot, 1, 1);
                    g.FillRect(x + w - 1 - inset, rowBot, 1, 1);
                }
            }
        }

        // original static { ... } initializer block
        static h()
        {
            int[] var10000 = new int[] { 0, 0 };
            var10000 = new int[] { -1, -1 };
            var10000 = new int[] { 0, 0 };
            var10000 = new int[] { 0, 0 };
        }
    }
}
