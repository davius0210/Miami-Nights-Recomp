// Port of original class c (validated VF source).
// R1: methods a..n -> m_a..m_n (all overloads); R5: field `c` -> c_; Java byte -> sbyte everywhere.
using System;
using System.IO;
using System.Text;

namespace MiamiNights
{
    public sealed class c : Runnable, CommandListener
    {
        public static string a = "2.0";
        public static string b = "IGP-Signature=" + a;
        private static string g = "";
        private static string h;
        private static Font i;
        private static int j = 13568256;
        private static int k = MiamiNights.e.d;
        private static int l;
        private static int m;
        private static int n;
        private static int o = 0;
        private static bool[] p = new bool[1];
        private static int[] q = new int[1];
        private static int r;
        public static int c_ = -1;          // R5: field named as enclosing class (was `c`)
        public static int d = 10;
        private static int s;
        private static int t;
        private static int u;
        private static int v;
        private static int w;
        private static int x;
        private static int y;
        private static int z;
        private static int A;
        private static int B;
        private static int C;
        private static int D;
        private static int E;
        private static int F;
        private static int G;
        private static int H = 14;
        private static int I;
        private static int[] J;
        private static sbyte[][] K;
        private static int L;
        private static sbyte[] M;
        private static int N;
        private static int O = 0;
        private static int P = 1;
        private static int Q = 2;
        private static int R = 3;
        private static Image[] S;
        private static int T;
        private static int[] U;
        private static int V;
        private static int W;
        private static bool X;
        private static readonly string[] Y = new string[]{"URL-WN", "URL-BS", "URL"};
        private static string Z;
        private static bool aa;
        public static string[] e = new string[0];
        private static string[] ab;
        private static string[] ac;
        private static string[] ad;
        private static int ae;
        private static int af;
        private static string[] ag;
        private static short[] ah;
        private static int ai = 6;
        private static int aj = 3;
        private static int ak;
        private static bool al;
        private static bool am;
        private static MIDlet an;
        private static Canvas ao;
        private static string ap;
        private static bool aq = false;
        private static CommandListener ar = null;
        public static c f = null;
        private static bool @as = false;
        private static string at = null;
        private static bool au = false;
        private static int av;
        private static int aw;
        private static int ax;
        private static int ay;
        private static int az;
        private static Image[] aA;
        private static Image[] aB;
        private static Image aC;
        private static Image aD;
        private static Image aE;
        private static Image aF;
        private static Image aG;
        private static Image aH;
        private static Image aI;
        private static Image aJ;
        private static Image aK;
        private static Image[] aL;
        private static Image aM;
        private static Image[][] aN;
        private static string[][] aO;
        private static int[][] aP;
        private static int[][] aQ;
        private static int[] aR;
        private static int aS;
        private static int aT;
        private static int aU;
        private static int aV;
        private static int aW;
        private static int aX;
        private static int aY;
        private static int aZ;
        private static int ba;
        private static int bb;
        private static int bc = -1;
        private static string[] bd;
        private static bool[] be;
        private static int bf = 0;
        private static int bg;
        private static bool bh;
        private static sbyte bi;
        private static sbyte bj;
        private static bool bk;
        private static int bl;
        private static int bm;
        private static int bn;
        private static int bo;
        private static int bp;
        private static int bq;
        private static string br;
        private static string bs;
        private static string bt;
        private static int bu;
        private static int bv;
        private static int bw;
        private static int bx;
        private static Command by;
        private static Command bz;
        private static int bA = 0;
        private static bool bB = false;
        private static bool bC = false;
        private static int bD = -1;
        private static int bE = -1;
        private static int bF = -1;
        private static int bG = -1;
        private static int bH;
        private static int bI;
        private static int bJ;
        private static Hashtable bK = new Hashtable();
        private static int bL = 0;

        private static bool m_b()
        {
            m_c();

            try
            {
                Stream var0 = null;
                I = (var0 = File.OpenRead(Midp.ResPath("/dataIGP"))).ReadByte() & 0xFF;
                I = I + ((var0.ReadByte() & 0xFF) << 8);
                J = new int[I];

                for (int var1 = 0; var1 < I; var1++)
                {
                    J[var1] = var0.ReadByte() & 0xFF;
                    J[var1] = J[var1] + ((var0.ReadByte() & 0xFF) << 8);
                    J[var1] = J[var1] + ((var0.ReadByte() & 0xFF) << 16);
                    J[var1] = J[var1] + ((var0.ReadByte() & 0xFF) << 24);
                }

                var0.Close();
                return true;
            }
            catch (Exception var2)
            {
                return false;
            }
        }

        private static void m_c()
        {
            J = null;
            K = (sbyte[][])null;
            I = 0;
            GC.Collect();
        }

        private static sbyte[] m_b(int var0)
        {
            if (var0 >= 0 && var0 < I - 1)
            {
                int var1;
                if ((var1 = J[var0 + 1] - J[var0]) == 0)
                {
                    return null;
                }
                else if (K != null)
                {
                    return K[var0];
                }
                else
                {
                    sbyte[] var2 = null;

                    try
                    {
                        Stream var3 = null;
                        (var3 = File.OpenRead(Midp.ResPath("/dataIGP"))).Seek(2 + 4 * I + J[var0], System.IO.SeekOrigin.Current);
                        int var4 = (var2 = new sbyte[var1]).Length;

                        while (var4 > 0)
                        {
                            byte[] tmp = new byte[var2.Length];
                            int n = var3.Read(tmp, 0, tmp.Length);
                            if (n > 0) Buffer.BlockCopy(tmp, 0, var2, 0, n); // Java read(byte[]) fills from index 0
                            var4 -= n;
                        }

                        var3.Close();
                    }
                    catch (Exception var5)
                    {
                    }

                    return var2;
                }
            }
            else
            {
                return null;
            }
        }

        private static int m_a(sbyte[] var0)
        {
            return (var0[L++] & 0xFF) + ((var0[L++] & 0xFF) << 8);
        }

        private static sbyte[] m_b(sbyte[] var0)
        {
            int var1;
            sbyte[] var2 = new sbyte[var1 = m_a(var0)];
            Array.Copy(var0, L, var2, 0, var1);
            L += var1;
            return var2;
        }

        private static Image m_c(sbyte[] var0)
        {
            sbyte[] var1;
            return Image.CreateImage(Helpers.ToB(var1 = m_b(var0)), 0, var1.Length);
        }

        private static Image m_a(sbyte[] var0, int var1, int var2)
        {
            if (MiamiNights.e.h)
            {
                sbyte[] var3 = new sbyte[var2];
                Array.Copy(var0, var1, var3, 0, var2);
                var0 = var3;
                var1 = 0;
            }

            return Image.CreateImage(Helpers.ToB(var0), var1, var2);
        }

        private static string m_c(int var0)
        {
            return "" + ag[var0];
        }

        private static int m_d(int var0, int var1)
        {
            if (bL != 0)
            {
                if (var1 != O && var1 != P)
                {
                    return M[var0 * 6 + var1] & 0xFF;
                }
                else
                {
                    int var2 = M[var0 * 6 + var1] & 255;
                    int var3 = M[var0 * 6 + var1 + 1] & 255;
                    int var4 = 0;
                    return (var4 = 0 | (var3 & 0xFF) << 8) | var2 & 0xFF;
                }
            }
            else
            {
                return M[(var0 << 2) + var1] & 0xFF;
            }
        }

        private static void m_a(int var0, Graphics var1, int var2, int var3, int var4)
        {
            m_a(m_c(var0), var1, bu, var2, var3, var4);
        }

        private static void m_a(string var0, Graphics var1, int var2, int var3, int var4, int var5)
        {
            m_a(var0, var1, var3, var4, var5);
        }

        private static void m_a(string var0, Graphics var1, int var2, int var3, int var4)
        {
            string var5 = var0;
            U[0] = 0;
            W = 0;
            int var6 = 0;
            bool var9 = false;
            bool var10 = false;
            int var11 = var0.Length;
            int var12 = 0;   // CFR: int (VF byte mis-inference)
            if (bu <= 176 && (ax == 0 || ax == 1 || ax == 2))
            {
                var12 += 2;
            }

            for (int var8 = 0; var8 < var11; var8++)
            {
                char var7;
                if ((var7 = var5[var8]) != '\n' || var6 >= 10)
                {
                    if (var7 != '\\' || var5[++var8] != 'N')
                    {
                        if (var7 != 0 && var7 != 1)
                        {
                            U[var6] = U[var6] + m_d(var7, Q) + o;
                        }
                        continue;
                    }
                }

                U[var6] = U[var6] - o;
                if (U[var6] > W)
                {
                    W = U[var6];
                }

                U[++var6] = 0;
            }

            U[var6] = U[var6] - o;
            if (U[var6] > W)
            {
                W = U[var6];
            }

            V = (var6 + 1) * N + var6 * (0 + var12);
            if (X)
            {
                X = false;
            }
            else
            {
                var3 += (0 + var12) * var6 / 2;
                var6 = 0;
                if ((var4 & 32) != 0)
                {
                    var3 -= V;
                }
                else if ((var4 & 2) != 0)
                {
                    var3 -= V >> 1;
                }

                int var13 = var2;
                var9 = true;
                var10 = false;
                m_b(var1, 0, 0, bu, bv);

                for (int var18 = 0; var18 < var11; var18++)
                {
                    char var17 = var5[var18];
                    if (var9)
                    {
                        var13 = var2;
                        if ((var4 & 8) != 0)
                        {
                            var13 = var2 - U[var6];
                        }
                        else if ((var4 & 1) != 0)
                        {
                            var13 = var2 - (U[var6] >> 1);
                        }

                        var9 = false;
                    }

                    if (var17 != '\n' || var6 >= 10)
                    {
                        if (var17 == '\\')
                        {
                            if (var5[++var18] == 'N')
                            {
                                goto label81; // Java: break label81
                            }
                        }

                        if (var10)
                        {
                            var10 = false;
                            char var14;
                            if ((var14 = var5[var18 - 2]) == ' ')
                            {
                                var13 -= m_d(var14, Q) + o >> 1;
                            }

                            if (var17 == ' ')
                            {
                                var13 += m_d(var17, Q) + o >> 1;
                                continue;
                            }
                        }

                        m_b(var1, var13, var3, m_d(var17, Q), m_d(var17, R));
                        m_a(var1, S[T], m_d(var17, O), m_d(var17, P), m_d(var17, Q), m_d(var17, R), var13, var3);
                        var13 += m_d(var17, Q) + o;
                        continue;
                    }

                label81:
                    var3 += N + 0 + var12 - 2;
                    var6++;
                    var9 = true;
                    var10 = true;
                }

                m_b(var1, 0, 0, bu, bv);
                T = 1;
            }
        }

        public static void m_a(MIDlet var0, Canvas var1, int var2, int var3)
        {
            m_a(var0, var1, var2, var3, null);
        }

        private static void m_a(MIDlet var0, Canvas var1, int var2, int var3, CommandListener var4)
        {
            new StringBuilder()
               .Append("initialize(midlet = ")
               .Append(var0)
               .Append(", game = ")
               .Append(var1)
               .Append(", screenWidth = ")
               .Append(var2)
               .Append(", screenHeight = ")
               .Append(var3)
               .Append(", cmdListener = ")
               .Append(var4)
               .Append(")")
               .ToString();
            bu = var2;
            bv = var3;
            bw = bu >> 1;
            bx = bv >> 1;
            l = bv * 5 / 100;
            m = bv / 2;
            n = bv * 93 / 100;
            if (MiamiNights.e.d < 0 || MiamiNights.e.d > bu / 2 - bu * 15 / 100)
            {
                k = 2;
            }

            if (an == null)
            {
                if (var1 != null)
                {
                    if (var4 != null)
                    {
                        aq = true;
                        if (f == null)
                        {
                            f = new c();
                        }

                        ar = var4;
                    }

                    an = var0;
                    ao = var1;
                    if (MiamiNights.e.s)
                    {
                        m_n();
                    }

                    m_d();
                    string var5 = b;
                    new StringBuilder().Append(var5).Append("").ToString();
                }
            }
        }

        private static bool m_b(string var0, int var1)
        {
            if (var0 == null)
            {
                return (var1 & 1) == 0;
            }
            else
            {
                var0 = var0.Trim();
                return ((var1 & 1) == 0 || var0.Length != 0)
                   && ((var1 & 2) == 0 || string.CompareOrdinal(var0.ToUpperInvariant(), "DEL") != 0)
                   && ((var1 & 4) == 0 || string.CompareOrdinal(var0.ToUpperInvariant(), "NO") != 0 && string.CompareOrdinal(var0.ToUpperInvariant(), "0") != 0);
            }
        }

        private static string m_a(string var0, string var1, string var2)
        {
            string var3 = "";

            try
            {
                if (var2 != null && var0 != null && var1 != null)
                {
                    int var4 = var0.IndexOf(var1 + "=");
                    var2 = var2.Trim();
                    if (var4 >= 0 && var2.Length > 0)
                    {
                        var4 += var1.Length + 1;
                        int var5;
                        if ((var5 = var0.IndexOf(";", var4)) < 0)
                        {
                            var5 = var0.Length;
                        }

                        if ((var3 = var0.Substring(var4, var5 - var4).Trim()).Length == 0 || string.CompareOrdinal(var3, "0") == 0 || string.CompareOrdinal(var3.ToUpperInvariant(), "NO") == 0)
                        {
                            var3 = "";
                        }
                        else if (string.CompareOrdinal(var3.ToUpperInvariant(), "DEL") != 0 && string.CompareOrdinal(var1, "OP") != 0)
                        {
                            int var6 = var2.IndexOf("XXXX");
                            var3 = var2.Substring(0, var6) + var3 + var2.Substring(var6 + "XXXX".Length);
                        }
                    }
                }
            }
            catch (Exception var7)
            {
                var3 = "";
            }

            return var3;
        }

        private static void m_a(int var0, string var1, int var2, string var3, string var4)
        {
            try
            {
                object var5 = null;
                if (aa)
                {
                    var5 = m_a(m_a(var3), var1, var4);
                }
                else
                {
                    var5 = m_a("URL-" + var1);
                }

                if (m_b((string)var5, var2) && (string.CompareOrdinal(((string)var5).ToUpperInvariant(), "NO") != 0 || string.CompareOrdinal(((string)var5).ToUpperInvariant(), "0") != 0))
                {
                    be[var0] = true;
                    bd[var0] = (string)var5;
                    if (be[var0] && var0 != 3)
                    {
                        bf++;
                        bd[var0] = bd[var0] + "&ctg=SC" + (bf < 10 ? "0" : "") + bf;
                    }
                }
            }
            catch (Exception var7)
            {
            }
        }

        private static void m_a(int var0, string[] var1, int var2, string var3)
        {
            int var4 = var1.Length;
            aO[var0] = new string[var4];
            aP[var0] = new int[var4];
            aQ[var0] = new int[var4];
            int var5 = 0;
            if (!p[0])
            {
                string var6 = "";
                if (aa)
                {
                    try
                    {
                        var3 = m_a(var3);
                        if (var0 != 2)
                        {
                            var6 = Z;
                        }
                        else if (bt.Length > 0)
                        {
                            var6 = bt + "&ctg=XXXX";
                        }
                    }
                    catch (Exception var9)
                    {
                    }
                }

                for (int var7 = 0; var7 < var1.Length; var7++)
                {
                    try
                    {
                        string var8 = "";
                        if (var0 != 2 && var7 == var4 - 1)
                        {
                            if (!aa)
                            {
                                var8 = m_a(Y[var0]);
                            }
                            else if (bt.Length > 0)
                            {
                                var8 = m_a(m_a("IGP-CATEGORIES"), var1[var7], bt + "&ctg=XXXX");
                            }
                        }
                        else if (aa)
                        {
                            if (string.CompareOrdinal(var1[var7], "GLDT") == 0)
                            {
                                var8 = m_a(var3, var1[var7], Z);
                            }
                            else if (string.CompareOrdinal(var1[var7], "CATALOG") == 0)
                            {
                                var8 = bt;
                            }
                            else
                            {
                                var8 = m_a(var3, var1[var7], var6);
                            }
                        }
                        else
                        {
                            var8 = m_a(Y[var0] + "-" + var1[var7]);
                        }

                        if (m_b(var8, 7))
                        {
                            aO[var0][var5] = var8;
                            aP[var0][var5++] = var7;
                            aQ[var0][var7] = var2 + var7;
                        }
                    }
                    catch (Exception var10)
                    {
                    }
                }

                if (var5 > 0)
                {
                    be[4 + var0] = true;
                    aR[var0] = var5;
                }
            }
        }

        private static string[] m_d(sbyte[] var0)
        {
            string[] var1 = new string[m_a(var0)];

            for (int var2 = 0; var2 < var1.Length; var2++)
            {
                int var3 = m_a(var0);
                // PORT-QUESTION: Java new String(bytes,off,len) uses platform default charset -> Iso1 (Latin-1)
                var1[var2] = GloftMMN.Iso1(var0, L, var3);
                L += var3;
            }

            return var1;
        }

        private static void m_a(string[] var0)
        {
            int var1 = (var0.Length - 1 > 0 ? var0.Length - 1 : 0) + 4;
            s = ++var1;
            t = s + 1;
            u = t + 1;
            v = u + 1;
            w = v + 1;
            x = w + 1;
            y = x + 1;
            z = y + 1;
            A = z + 1;
            B = A + 1;
            C = B + 1;
            D = C + 1;
            E = D + 1;
            F = E + 1;
            G = F + ab.Length;
        }

        private static void m_d()
        {
            string[] var0;
            try
            {
                if (!m_b())
                {
                    au = false;
                    return;
                }

                sbyte[] var2;
                m_a(var2 = m_b(0));
                int var3 = m_a(var2);
                // PORT-QUESTION: Java new String(bytes,off,len) default charset -> Iso1
                GloftMMN.Iso1(var2, L, var3);
                L += var3;
                e = m_d(var2);
                var0 = m_d(var2);
                ab = m_d(var2);
                ac = m_d(var2);
                ad = m_d(var2);

                for (int var4 = 0; var4 < p.Length; var4++)
                {
                    p[var4] = m_a(var2) == 1;
                }

                try
                {
                    int var15 = m_a(var2);
                    g = GloftMMN.Iso1(var2, L, var15);
                    if (g == "2.0z")
                    {
                        bL = 2;
                        ai = 12;
                        aj = 6;
                        P = 2;
                        Q = 4;
                        R = 5;
                    }

                    if (!g.StartsWith(a))
                    {
                        new StringBuilder().Append("Invalid dataIGP file, dataIGP file IGP Version : ").Append(g).ToString();
                        new StringBuilder().Append("IGP Class version : ").Append(a).ToString();
                    }
                }
                catch (Exception var8)
                {
                    au = false;
                }

                m_c();
            }
            catch (Exception var9)
            {
                au = false;
                return;
            }

            m_a(var0);
            ae = var0.Length;
            aL = new Image[ae];
            af = ae + 1 + 1 + 1 + 1 + (p[0] ? 1 : 0);

            for (int var1 = 0; var1 < p.Length; var1++)
            {
                if (p[var1])
                {
                    q[var1] = ++d;
                }
                else
                {
                    q[var1] = --c_;
                }
            }

            r = ++d;
            bd = new string[9];
            be = new bool[9];

            for (int var10 = 0; var10 < be.Length; var10++)
            {
                be[var10] = false;
            }

            aO = new string[3][];
            aP = new int[3][];
            aQ = new int[3][];
            aR = new int[3];

            try
            {
                Z = m_a("URL-TEMPLATE-GAME").Trim();
                aa = true;
            }
            catch (Exception var7)
            {
            }

            for (int var11 = 0; var11 < ae; var11++)
            {
                m_a(var11, var0[var11], 7, "IGP-PROMOS", Z);
            }

            object var12 = null;

            try
            {
                if (m_b((string)(var12 = m_a("URL-OPERATOR")), 7))
                {
                    bt = (string)var12;
                }

                br = m_a("URL-PT");
            }
            catch (Exception var6)
            {
            }

            if (!p[0])
            {
                if (aa)
                {
                    if (m_b(bt, 7))
                    {
                        m_a(ae, "PROMO", 7, "IGP-CATEGORIES", bt + "&ctg=XXXX");
                    }
                }
                else
                {
                    string var14;
                    if ((var14 = m_a("URL-PROMO")) != null)
                    {
                        var14.Trim();
                        if (m_b(m_a("URL-PROMO"), 7))
                        {
                            bd[3] = var14;
                            be[3] = true;
                        }
                    }
                }
            }

            m_a(0, ab, F, "IGP-WN");
            m_a(1, ac, G, "IGP-BS");
            if (!p[0])
            {
                if (aa)
                {
                    if (m_b(m_a(m_a("IGP-CATEGORIES"), "OP", bt), 7))
                    {
                        if (m_b(bt, 7))
                        {
                            be[6] = true;
                        }

                        bd[6] = bt;
                    }
                }
                else if (m_b(bt, 7))
                {
                    bd[6] = bt;
                    be[6] = true;
                }

                if (be[6])
                {
                    bd[6] = bd[6] + "&ctg=CCTL";
                }
            }

            if (p[0])
            {
                try
                {
                    if (m_b(bt, 7))
                    {
                        bd[8] = bt;
                        be[8] = true;
                    }
                }
                catch (Exception var5)
                {
                }
            }

            bc = m_f();
            if (bc > 0)
            {
                au = true;
            }

            new StringBuilder().Append("isAvailable = ").Append(au).ToString();
        }

        private static int m_e()
        {
            if (!au)
            {
                return -1;
            }
            else
            {
                return m_f() > 0 ? 0 : -1;
            }
        }

        public static bool m_a()
        {
            return m_e() != -1;
        }

        public static void m_a(string var0, int var1)
        {
            new StringBuilder()
               .Append("enterIGP(loadingMsg = ")
               .Append(var0)
               .Append(", appLanguage = ")
               .Append(var1)
               .Append(" (")
               .Append(e[var1])
               .Append(")")
               .ToString();
            m_c(var0, var1);
            if (MiamiNights.e.f == 0)
            {
                az = 4 + af;
            }
            else
            {
                az = 4;
            }

            m_l();
            ax = m_g();
            if (aq)
            {
                ao.SetCommandListener(f);
            }
        }

        private static void m_c(string var0, int var1)
        {
            if (var1 >= 0 && var1 < e.Length)
            {
                bq = var1 <= e.Length ? var1 : 0;
                bs = var0;
                ay = -1;
                av = 0;
                ax = 0;
                aV = 0;
                aW = 0;
                U = new int[10];
                @as = true;
                i = Font.GetFont(0, 0, 8);
                bi = 0;
                bj = 0;
                if (MiamiNights.e.j == 2)
                {
                    new System.Threading.Thread(new c().Run).Start();
                }
            }
        }

        private static int m_f()
        {
            int var0 = 0;

            for (int var1 = 0; var1 < be.Length; var1++)
            {
                if (be[var1])
                {
                    var0++;
                }
            }

            return var0;
        }

        private static int m_d(int var0)
        {
            switch (var0)
            {
                case 6:
                    return 10;
                case 8:
                    return q[0];
                default:
                    return 4 + var0;
            }
        }

        private static int m_g()
        {
            for (int var0 = 0; var0 < be.Length; var0++)
            {
                if (be[var0])
                {
                    return var0;
                }
            }

            return -1;
        }

        private static void m_h()
        {
            if (br != null)
            {
                int var0;
                if ((var0 = br.Length) <= 0)
                {
                    br = null;
                }
                else
                {
                    bool var1 = false;
                    int var2 = 0;
                    int var3 = 0;
                    int var4 = 0;
                    int var5 = 1;
                    string var6 = "";
                    br = br.ToUpperInvariant();

                    for (int var7 = 0; var7 < var0; var7++)
                    {
                        char var8;
                        if (((var8 = br[var7]) < ' ' || var8 > 'z') && var8 != 130 && var8 != '\n')
                        {
                            var6 = null;
                            break;
                        }

                        if (var8 == '\n')
                        {
                            var1 = true;
                        }
                        else if (var7 < var0 - 1 && var8 == '\\' && (br[var7 + 1] == 'n' || br[var7 + 1] == 'N'))
                        {
                            var1 = true;
                            var7++;
                        }

                        if (var1)
                        {
                            if (var6.Length > 0)
                            {
                                if (++var5 == 3)
                                {
                                    var6 = null;
                                    break;
                                }

                                var6 = var6 + '\n';
                                var3 = 0;
                            }
                            else
                            {
                                var6 = var6 + "";
                            }

                            var1 = false;
                        }
                        else
                        {
                            var6 = var6 + var8;
                            var3 += m_d(var8, Q);
                            if (var8 == ' ')
                            {
                                var2 = var6.Length - 1;
                                var4 = var3;
                            }
                        }

                        if (var3 >= bu)
                        {
                            if (var5 >= 3)
                            {
                                var6 = null;
                                break;
                            }

                            if (var2 == var7)
                            {
                                var6 = var6 + "\n";
                                var3 = 0;
                            }
                            else
                            {
                                if (var2 == 0)
                                {
                                    var6 = null;
                                    break;
                                }

                                var6 = var6.Substring(0, var2) + "\n" + var6.Substring(var2 + 1, var6.Length - (var2 + 1));
                                var3 -= var4;
                            }

                            var5++;
                        }
                    }

                    if (var6 != null && !m_b(var6, 7))
                    {
                        var6 = null;
                    }

                    br = var6;
                }
            }
        }

        private static void m_e(int var0)
        {
            object var1 = null;
            L = 0;
            int var2 = var0 - 4;
            switch (var0)
            {
                case -1:
                    aA = new Image[H];
                    aB = new Image[9];
                    aN = new Image[3][];
                    aN[0] = new Image[ab.Length];
                    aN[1] = new Image[ac.Length];
                    aN[2] = new Image[ad.Length];
                    return;
                case 0:
                    m_b();
                    return;
                case 1:
                    var1 = m_b(var0);

                    for (int var4 = 0; var4 < bq; var4++)
                    {
                        int var3 = m_a((sbyte[])var1);
                        L += var3;
                    }

                    m_a((sbyte[])var1);
                    int var23;
                    ag = new string[var23 = m_a((sbyte[])var1)];
                    sbyte[] var24 = new sbyte[var23];
                    Array.Copy((sbyte[])var1, L, var24, 0, var23);
                    L += var23;
                    m_a((sbyte[])var1);
                    int var5;
                    ah = new short[var5 = ((sbyte[])var1)[L++] & 255 | (((sbyte[])var1)[L++] & 255) << 8];

                    for (int var25 = 0; var25 < var5 - 1; var25++)
                    {
                        ah[var25] = (short)((((sbyte[])var1)[L++] & 255) + ((((sbyte[])var1)[L++] & 255) << 8));
                    }

                    ah[var5 - 1] = (short)var23;

                    for (int var26 = 0; var26 < var5; var26++)
                    {
                        int var27 = var26 == 0 ? 0 : ah[var26 - 1] & '\uffff';
                        int var28;
                        if ((var28 = (ah[var26] & '\uffff') - var27) != 0)
                        {
                            try
                            {
                                if (MiamiNights.e.i)
                                {
                                    // new String(var24, var27, var28, "UTF-8")
                                    ag[var26] = Encoding.UTF8.GetString(Helpers.ToB(var24), var27, var28);
                                }
                                else
                                {
                                    StringBuilder var9 = new StringBuilder(var28 / 2 + 2);

                                    for (int var29 = var27; var29 < var27 + var28; ag[var26] = var9.ToString().ToUpperInvariant())
                                    {
                                        if ((var24[var29] & 128) == 0)
                                        {
                                            var9.Append((char)(var24[var29++] & 255));
                                        }
                                        else if ((var24[var29] & 224) == 192)
                                        {
                                            if (var29 + 1 >= var27 + var28 || (var24[var29 + 1] & 192) != 128)
                                            {
                                                throw new Exception();
                                            }

                                            var9.Append((char)((var24[var29++] & 31) << 6 | var24[var29++] & 63));
                                        }
                                        else
                                        {
                                            if ((var24[var29] & 240) != 224)
                                            {
                                                throw new Exception();
                                            }

                                            if (var29 + 2 >= var27 + var28 || (var24[var29 + 1] & 192) != 128 || (var24[var29 + 2] & 192) != 128)
                                            {
                                                throw new Exception();
                                            }

                                            var9.Append((char)((var24[var29++] & 15) << 12 | (var24[var29++] & 63) << 6 | var24[var29++] & 63));
                                        }
                                    }
                                }
                            }
                            catch (Exception var16)
                            {
                            }
                        }
                    }

                    if (aq)
                    {
                        by = new Command(m_c(y), 4, 1);
                        bz = new Command(m_c(z), 2, 1);
                        m_a(true, true);
                        return;
                    }
                    break;
                case 2:
                    S = new Image[3];
                    // PORT-QUESTION: Java casts byte[] to Object[] here — in Java this is a runtime
                    // ClassCastException ((Object[])(byte[])); ported verbatim, verify at integration.
                    sbyte[] var6 = new sbyte[((object[])(var1 = m_b(var0))).Length];
                    Array.Copy((sbyte[])var1, 0, var6, 0, ((sbyte[])var1).Length);
                    int var7 = m_a((sbyte[])var1);
                    L = 0;
                    S[0] = m_c((sbyte[])var1);
                    if (MiamiNights.e.g)
                    {
                        S[1] = m_a(var6, 2, var7, 1, 46319);
                        S[2] = m_a(var6, 2, var7, 1, 16711680);
                    }
                    else
                    {
                        S[1] = S[0];
                        S[2] = S[0];
                    }

                    int var8 = m_a((sbyte[])var1);
                    M = new sbyte[(m_a((sbyte[])var1) + 1) * (4 + bL)];
                    int var10 = var8 / (6 + bL);

                    for (int var34 = 0; var34 < var10; var34++)
                    {
                        int var11 = m_a((sbyte[])var1) * (4 + bL);
                        Array.Copy((sbyte[])var1, L, M, var11, 4 + bL);
                        L = L + 4 + bL;
                    }

                    N = M[32 * (4 + bL) + R];
                    o = N == 13 ? 0 : -1;
                    m_h();
                    return;
                case 3:
                    var1 = m_b(var0);

                    for (int var33 = 0; var33 < H; var33++)
                    {
                        if (MiamiNights.e.n || var33 != 13 && var33 != 12)
                        {
                            aA[var33] = m_c((sbyte[])var1);
                        }
                    }

                    if (aE != null)
                    {
                        aA[8] = aE;
                        aA[9] = aD;
                    }

                    if (aJ != null)
                    {
                        aA[4] = aH;
                        aA[5] = aJ;
                        aA[6] = aI;
                        aA[7] = aK;
                    }

                    if (aF != null)
                    {
                        aA[13] = aG;
                        aA[12] = aF;
                    }

                    if (aM != null)
                    {
                        aA[10] = aM;
                    }

                    if (aM != null)
                    {
                        aA[10] = aM;
                        return;
                    }
                    break;
                case 4:
                case 5:
                case 6:
                    aB[var2] = m_c(m_b(var0));
                    if (aL[var2] != null)
                    {
                        aB[var2] = aL[var2];
                        return;
                    }
                    break;
                case 7:
                    sbyte[] var12 = m_b((sbyte[])(var1 = m_b(var0)));
                    aB[var2] = m_a(var12, 0, var12.Length);

                    for (int var35 = 0; var35 < bq; var35++)
                    {
                        m_c((sbyte[])var1);
                    }

                    aC = m_c((sbyte[])var1);
                    return;
                case 8:
                case 9:
                    int var13 = (var0 == 8 ? ab.Length : ac.Length) - 1;
                    int var14 = var0 == 8 ? 0 : 1;
                    var1 = m_b(var0);

                    int var15;
                    for (var15 = 0; var15 < var13; var15++)
                    {
                        aN[var14][var15] = m_c((sbyte[])var1);
                    }

                    aN[var14][var15] = aA[11];
                    aB[var2] = aA[10];
                    return;
                case 10:
                    aB[6] = m_c(m_b(var0));
                    return;
                default:
                    if (var0 == q[0])
                    {
                        var1 = m_b(var0);
                        aB[8] = m_c((sbyte[])var1);
                        return;
                    }

                    if (var0 == r)
                    {
                        m_c();
                    }
                    break; // Java: default section falls out of switch (end of method)
            }
        }

        private static void m_a(bool var0)
        {
            for (int var1 = 0; var1 < aN.Length; var1++)
            {
                if (aN[var1] != null)
                {
                    for (int var2 = 0; var2 < aN[var1].Length; var2++)
                    {
                        aN[var1][var2] = null;
                    }
                }
            }

            for (int var3 = 0; var3 < aB.Length; var3++)
            {
                aB[var3] = null;
            }

            aC = null;
            if (var0)
            {
                m_c();
                M = null;
                S = null;

                for (int var4 = 0; var4 < H; var4++)
                {
                    aA[var4] = null;
                }

                aA = null;
                ah = null;
                ag = null;
                U = null;
                bs = null;
                aB = null;
                aN = (Image[][])null;
                aD = null;
                aE = null;
                aF = null;
                aG = null;
                aH = null;
                aI = null;
                aJ = null;
                aK = null;
                aM = null;

                for (int var5 = 0; var5 < aL.Length; var5++)
                {
                    aL[var5] = null;
                }
            }

            GC.Collect();
        }

        public static bool m_a(int var0)
        {
            if (!au)
            {
                return true;
            }
            else
            {
                if (var0 == 25)
                {
                    if (MiamiNights.e.a)
                    {
                        var0 = 0;
                    }
                }
                else if (var0 == 26 && MiamiNights.e.b)
                {
                    var0 = 0;
                }

                if (MiamiNights.e.n && bB)
                {
                    bB = false;
                }
                else
                {
                    aw = var0;
                }

                switch (av)
                {
                    case 0:
                        if (ay >= az)
                        {
                            av = 1;
                            m_i();
                        }
                        else
                        {
                            m_e(ay);
                        }

                        ay++;
                        break;
                    case 1:
                        switch (aw)
                        {
                            case 21:
                                if (bk && aW > 0)
                                {
                                    aW--;
                                    if (aW - aV < 0)
                                    {
                                        aV--;
                                        return false;
                                    }
                                }

                                return false;
                            case 22:
                            case 28:
                            case 29:
                            case 30:
                            case 31:
                            default:
                                return false;
                            case 23:
                                if (bc <= 1)
                                {
                                    return false;
                                }

                                if (ax == 0)
                                {
                                    ax = 8;
                                }
                                else
                                {
                                    ax--;
                                }

                                while (!be[ax])
                                {
                                    if (ax == 0)
                                    {
                                        ax = 8;
                                    }
                                    else
                                    {
                                        ax--;
                                    }
                                }

                                al = true;
                                goto case 24; // Java fall-through
                            case 24:
                                if (bc > 1)
                                {
                                    if (!al)
                                    {
                                        if (ax == 8)
                                        {
                                            ax = 0;
                                        }
                                        else
                                        {
                                            ax++;
                                        }

                                        while (!be[ax])
                                        {
                                            if (ax == 8)
                                            {
                                                ax = 0;
                                            }
                                            else
                                            {
                                                ax++;
                                            }
                                        }

                                        am = true;
                                    }

                                    aV = 0;
                                    aW = 0;
                                    m_i();
                                }

                                return false;
                            case 25:
                            case 27:
                                av = 6;
                                return false;
                            case 26:
                                av = 4;
                                return false;
                            case 32:
                                if (bk && aW < aT - 1)
                                {
                                    aW++;
                                    if (aW - aV >= aU)
                                    {
                                        aV++;
                                        return false;
                                    }
                                }

                                return false;
                        }
                        // Java: no break — falls through to case 2, but inner switch always returns,
                        // so the fall-through is unreachable (C# endpoint likewise unreachable).
                    case 2:
                        m_a(false);
                        if (MiamiNights.e.f == 1)
                        {
                            m_b();
                        }

                        ay = m_d(ax);
                        m_e(ay);
                        if (MiamiNights.e.f == 1)
                        {
                            m_c();
                        }

                        av = 1;
                        break;
                    case 3:
                        switch (aw)
                        {
                            case 25:
                            case 27:
                                if (MiamiNights.e.j == 2)
                                {
                                    at = ap;
                                }
                                else
                                {
                                    h = ap;
                                }

                                return false;
                            case 26:
                                av = 1;
                                ap = null;
                                return false;
                            default:
                                return false;
                        }
                    case 4:
                        m_a(true);
                        if (aq)
                        {
                            ao.SetCommandListener(ar);
                            m_k();
                        }

                        @as = false;
                        return true;
                    case 5:
                    default:
                        break;
                    case 6:
                        string var1 = null;
                        var1 = bd[ax];
                        if (bk)
                        {
                            var1 = aO[aS][aW];
                        }

                        if (var1 != null && var1.Length > 0)
                        {
                            if (aa)
                            {
                                int var2;
                                if ((var2 = var1.IndexOf("&lg=")) == -1)
                                {
                                    var1 = var1 + "&lg=" + e[bq];
                                }
                                else
                                {
                                    var1 = var1.Substring(0, var2) + "&lg=" + e[bq] + var1.Substring(var2 + "&lg=".Length + 2);
                                }
                            }

                            if (MiamiNights.e.j == 2)
                            {
                                at = var1;
                            }
                            else
                            {
                                h = var1;
                            }
                        }
                        break; // Java: case 6 falls out of switch (end)
                }

                return false;
            }
        }

        public static void m_a(int var0, int var1)
        {
            int var2;
            if ((var2 = m_e(var0, var1)) != 0)
            {
                aw = var2;
                bB = true;
            }

            bA = 0;
            bC = false;
        }

        public static void m_b(int var0, int var1)
        {
            int var2;
            if ((var2 = m_e(var0, var1)) != 0)
            {
                bA = var2;
            }
        }

        public static void m_c(int var0, int var1)
        {
            aw = 0;
            bA = 0;
            bC = false;
            m_b(var0, var1);
        }

        private static int m_e(int var0, int var1)
        {
            if (var0 < 1 || var1 < 1)
            {
                return 0;
            }
            else if (av != 0 && @as)
            {
                if (bk)
                {
                    int var2 = bv * 5 / 100;
                    int var3 = 1 + var2 + aA[5].GetWidth();
                    int var4 = bu * 1 / 100;
                    int var5 = var3 + aN[aS][0].GetWidth() + var4;
                    bool var6 = var0 >= aY && var0 <= aY + ba;

                    for (int var7 = aV; var7 < aV + aU; var7++)
                    {
                        if (var6 && var1 > bH + bb * (var7 - aV) && var1 < bH + bb * (var7 - aV) + bb)
                        {
                            if (aW == var7)
                            {
                                return 25;
                            }

                            aW = var7;
                            return 0;
                        }
                    }

                    if (aU < aT && var6)
                    {
                        if (aW > 0 && var1 > bI - (var5 - 2) / 2 && var1 < bI + (var5 - 2))
                        {
                            return 21;
                        }

                        if (aW < aT - 1 && var1 > bJ - (var5 - 2) / 2 && var1 < bJ + (var5 - 2))
                        {
                            return 32;
                        }
                    }
                }
                else
                {
                    if (var0 > bo && var0 < bo + bm && var1 > bp && var1 < bp + bn)
                    {
                        return 27;
                    }

                    if (MiamiNights.e.o && var0 > bD && var0 < bD + bF && var1 > bE && var1 < bE + bG)
                    {
                        return 27;
                    }
                }

                int var8 = bu - aA[7].GetWidth();
                int var9 = (bv >> 1) - aA[7].GetHeight();
                int var10 = aA[7].GetHeight() * 2;
                int var11 = aA[7].GetWidth() * 2;
                bool var12 = MiamiNights.e.c;
                if (var1 > var9 && var1 < var9 + var10)
                {
                    if (var0 > 0 && var0 < 0 + var11)
                    {
                        return 23;
                    }

                    if (var0 > var8 - var11 / 2 && var0 < var8 + var11)
                    {
                        return 24;
                    }
                }

                if (aq)
                {
                    return 0;
                }
                else
                {
                    if (var1 >= bv - aA[13].GetHeight() * 2 && var1 <= bv)
                    {
                        if (var0 > k && var0 < aA[13].GetWidth() * 2 + k)
                        {
                            if (var12)
                            {
                                if (MiamiNights.e.a)
                                {
                                    return 0;
                                }

                                bC = true;
                                return 25;
                            }

                            if (MiamiNights.e.b)
                            {
                                return 0;
                            }

                            return 26;
                        }

                        if (var0 > bu - k - aA[13].GetWidth() * 2 && var0 < bu - k)
                        {
                            if (var12)
                            {
                                if (MiamiNights.e.b)
                                {
                                    return 0;
                                }

                                return 26;
                            }

                            if (MiamiNights.e.a)
                            {
                                return 0;
                            }

                            bC = true;
                            return 25;
                        }
                    }

                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private static void m_i()
        {
            if (MiamiNights.e.f == 1)
            {
                av = 2;
            }

            bg = ax;
            aW = 0;
            aT = 0;
            aV = 0;
            bk = false;
            bh = bd[ax] != null && bd[ax].Length > 0 && string.CompareOrdinal(bd[ax], "DEL") != 0;
            if (ax == 4)
            {
                aS = 0;
                bk = true;
                bh = false;
            }

            if (ax == 5)
            {
                aS = 1;
                bk = true;
                bh = false;
            }

            if (ax == 6 || ax == 8)
            {
                bh = true;
            }

            bl = MiamiNights.e.n ? A : (MiamiNights.e.p ? w : u);
            if (ax == 0 || ax == 1 || ax == 2)
            {
                bl = MiamiNights.e.n ? B : (MiamiNights.e.p ? x : v);
            }

            if (bk)
            {
                aT = aR[aS];
            }
        }

        public static void m_a(Graphics var0)
        {
            if (au)
            {
                if (h != null && MiamiNights.e.j == 1)
                {
                    m_m();
                }
                else
                {
                    m_b(var0, 0, 0, bu, bv);
                    m_b(var0, 0, 0, bu, bv);
                    switch (av)
                    {
                        case 0:
                            var0.SetColor(0);
                            var0.FillRect(0, 0, bu, bv);
                            m_a(var0, bx, bu * 3 / 4, ay, az);
                            if (bs != null)
                            {
                                if (bs.Trim() == "")
                                {
                                    return;
                                }

                                var0.SetColor(16777215);
                                var0.SetFont(i);
                                var0.DrawString(bs, bw, bx - 5, 33);
                                return;
                            }
                            break;
                        case 1:
                            m_b(var0);
                            if (MiaNow.Ms() % 1000L > 500L || bA == 27 && !bC)
                            {
                                m_d(var0);
                                return;
                            }
                            break;
                        case 2:
                            var0.SetFont(i);
                            int var2 = i.Height;
                            var0.SetColor(255);
                            var0.FillRect(0, bx - var2 - 5, bu, var2 * 2);
                            var0.SetColor(16777215);
                            var0.DrawString(bs, bw, bx, 65);
                            return;
                        case 3:
                            m_b(var0);
                            int var3 = bv * 40 / 100;
                            int var4 = bu;
                            if (MiamiNights.e.r)
                            {
                                m_a(var0, 0, var3, var4, bv - var3 * 2, -220209185);
                            }
                            else
                            {
                                var0.SetColor(14671839);
                                var0.FillRect(0, var3, var4, bv - var3 * 2);
                            }

                            var0.SetColor(39423);
                            var0.DrawRect(0, var3, var4 - 1, bv - var3 * 2 - 1);
                            var0.DrawRect(1, var3 + 1, var4 - 3, bv - var3 * 2 - 3);
                            m_a(E, var0, bw, bx, 3);
                            m_e(var0);
                            goto case 4; // Java fall-through into case 4/default (break)
                        case 4:
                        default:
                            break;
                        case 5:
                            return;
                    }
                }
            }
        }

        private static void m_a(Graphics var0, int var1, int var2, int var3, int var4, int var5)
        {
            int[] var6 = new int[var3 * var4];

            for (int var7 = 0; var7 < var6.Length; var7++)
            {
                var6[var7] = var5;
            }

            var0.DrawRGB(var6, 0, var3, var1, var2, var3, var4, true);
        }

        private static void m_b(Graphics var0)
        {
            m_j();
            var0.SetColor(16777215);
            if (p[0])
            {
                var0.SetColor(0);
            }

            var0.FillRect(0, 0, bu, bv);
            if (bk)
            {
                m_c(var0);
            }
            else if (ax == 8)
            {
                int var1 = bu / 2;
                int var2 = bv * 8 / 100;
                m_a(var0, aB[8], var1, var2, 17);
                X = true;
                m_a(s, null, 0, 0, 0);
                int var3 = V;
                Math.Abs((bp - aB[ax].GetHeight() - var3) / 3);
                m_a(m_c(t), var0, bu - (aA[4].GetWidth() + 8) * 2, bu / 2, bv * 60 / 100, 3);
            }
            else if (ax == 3)
            {
                bool var10 = bv >= 128;
                bool var14 = br != null && br.Length > 0;
                int var19 = var10 ? aA[10].GetHeight() : 0;
                int var4 = l + 3 * var19 / 5 + aB[3].GetHeight();
                m_a(var0, aB[3], bw, var4, 33);
                m_a(var0, aC, bw, var4, 33);
                if (MiamiNights.e.o)
                {
                    bF = aB[3].GetWidth();
                    bG = aB[3].GetHeight();
                    bD = bw - 1 - bF / 2;
                    bE = var4 - aB[3].GetHeight();
                }

                if (var10)
                {
                    m_a(var0, aA[10], bw, l, 17);
                }

                if (var14)
                {
                    T = 2;
                    int var5 = bp - var4;
                    sbyte var6 = 3;
                    if (N * 2 > var5)
                    {
                        var4 += N / 3;
                        var6 = 17;
                    }
                    else
                    {
                        var4 += var5 / 2;
                    }

                    m_a(br, var0, bu, bw, var4, var6);
                }
            }
            else if (ax == 6)
            {
                bool var11 = bv >= 128;
                int var15 = bv / 2;
                m_a(var0, aB[ax], bw, var15, 3);
                if (MiamiNights.e.o)
                {
                    bF = aB[ax].GetWidth();
                    bF = bF - 2 * aA[5].GetWidth();
                    bG = aB[ax].GetHeight();
                    bD = bw - bF / 2;
                    bE = var15 - bG / 2;
                }

                if (var11)
                {
                    m_a(var0, aA[10], bw, l, 17);
                }

                X = true;
                m_a(m_c(bg), null, 0, 0, 0, 0);
                var15 -= V / 2;
                int var20 = T;
                T = 0;
                m_a(m_c(bg), var0, aB[ax].GetWidth() / 2, bw, var15, 17);
                T = var20;
            }
            else
            {
                int var12 = aB[ax].GetHeight();
                int var17 = N * 2;
                int var21 = var12 + var17;
                int var25 = Math.Max(0, bv - var21) / 4;
                int var26;
                int var28;
                int var7 = var28 = (var26 = Math.Max(0, var25)) / 2;
                m_a(var0, aB[ax], bw, var7, 17);
                if (MiamiNights.e.o)
                {
                    bF = aB[ax].GetWidth();
                    bF = bF - 2 * aA[5].GetWidth();
                    bG = aB[ax].GetHeight();
                    bD = bw - bF / 2;
                    bE = var7;
                }

                var28 += var12 + (MiamiNights.e.n ? 0 : var26);
                int var8 = aq ? bu : bu - (aA[9].GetWidth() + aA[8].GetWidth());
                int var9 = bv - 2 - var28 - (MiamiNights.e.n ? aA[12].GetHeight() : 0);
                m_a(m_c(bg), var0, var8, bw, var28 + var9 / 2, 3);
            }

            m_e(var0);
            if (bc > 1)
            {
                int var13 = Math.Abs((int)(MiaNow.Ms() / 80L % 8L) - 4);
                sbyte var18 = 5;
                sbyte var22 = 7;
                sbyte var24 = 1;
                sbyte var27 = 3;
                if (al || MiamiNights.e.n && bA == 23)
                {
                    var18 = 4;
                    var24 = 0;
                    ak++;
                }

                if (am || MiamiNights.e.n && bA == 24)
                {
                    var22 = 6;
                    var27 = 2;
                    ak++;
                }

                m_a(var0, aA[var18], 1 + var13, bx, 6);
                if (!MiamiNights.e.n && !MiamiNights.e.e_)
                {
                    m_a(var0, aA[var24], 1 + var13 + ai, bx, 6);
                }

                m_a(var0, aA[var22], bu - 1 - var13, bx, 10);
                if (!MiamiNights.e.n && !MiamiNights.e.e_)
                {
                    m_a(var0, aA[var27], bu - 1 - var13 - (aA[var22].GetWidth() - aA[var27].GetWidth()) + aj, bx, 10);
                }

                if (ak > 4)
                {
                    al = false;
                    am = false;
                    ak = 0;
                }
            }
        }

        private static void m_c(Graphics var0)
        {
            int var1 = l;
            if (bv > 128)
            {
                m_a(var0, aB[ax], bw, l, 17);
                var1 += aB[ax].GetHeight();
            }

            T = 2;
            m_a(bg, var0, bw, var1, 17);
            int var3 = Math.Max(2 * N, aN[aS][aP[aS][0]].GetHeight());
            X = true;
            m_a(bg, null, 0, 0, 0);
            int var4 = var1 + V;
            int var5;
            int var6 = var5 = bv * 7 / 100;
            int var7 = (bv / 2 - var4) * 2;
            int var8 = bv - aA[8].GetHeight() - 2 - var4;
            aU = aT;
            if (var7 / var3 >= aT)
            {
                var4 = var4 + var7 / 2 - aU * var3 / 2;
            }
            else
            {
                if (var8 / var3 < aT)
                {
                    aU = (var8 - 2 * var6) / var3;
                }

                var4 = var4 + var8 / 2 - aU * var3 / 2;
            }

            if (aU < aT)
            {
                if (aV > 0)
                {
                    m_a(var0, bw, var4 - var6, var5, 16777215, true, false);
                    bI = var4 - var6;
                }

                if (aV + aU < aT)
                {
                    m_a(var0, bw, var4 + aU * var3 + var6, var5, 16777215, true, true);
                    bJ = var4 + aU * var3;
                }
            }

            int var9 = var4 + var3 / 2 + 1;
            ba = bu - 3 * aA[5].GetWidth();
            aY = (bu >> 1) - (ba >> 1);
            int var10 = bu * 1 / 100;
            int var11;
            int var12 = (var11 = aY + var10) + aN[aS][0].GetWidth() + var10;

            for (int var14 = aV; var14 < aV + aU; var14++)
            {
                int var15 = aP[aS][var14];
                m_a(var0, aN[aS][var15], var11, var9, 6);
                if (aS == 2 || var15 == aQ[aS].Length - 1)
                {
                    T = 2;
                }

                m_a(m_c(aQ[aS][var15]), var0, var12, var9, 6);
                var9 += var3;
            }

            aX = aW - aV;
            aZ = var4 + var3 * aX;
            bb = var3;
            bH = var4;
            var0.SetColor(16545540);
            var0.DrawRect(aY, aZ, ba, bb);
        }

        private static void m_a(Graphics var0, int var1, int var2, int var3, int var4, bool var5, bool var6)
        {
            int var7 = var6 ? -1 : 1;
            if (var3 % 2 == 0)
            {
                var3--;
            }

            var0.SetColor(46319);
            if (var5)
            {
                m_a(var0, var1, var2, var1 - (var3 >> 1), var2 + var7 * (var3 >> 1), var1 + (var3 >> 1), var2 + var7 * (var3 >> 1));
            }
            else
            {
                m_a(var0, var1, var2, var1 - var7 * (var3 >> 1), var2 - (var3 >> 1), var1 - var7 * (var3 >> 1), var2 + (var3 >> 1));
            }

            var0.SetColor(var4);
            if (var5)
            {
                m_a(var0, var1, var2 + var7, var1 - (var3 >> 1) + 2, var2 + var7 * (var3 >> 1) - var7, var1 + (var3 >> 1) - 2, var2 + var7 * (var3 >> 1) - var7);
            }
            else
            {
                m_a(var0, var1 - var7, var2, var1 - var7 * (var3 >> 1) + var7, var2 - (var3 >> 1) + 2, var1 - var7 * (var3 >> 1) + var7, var2 + (var3 >> 1) - 2);
            }
        }

        private static void m_j()
        {
            X = true;
            m_a(bl, null, 0, 0, 3);
            int var0 = m_d(32, Q) / 2;
            int var1 = m_d(32, R) / 3;
            bm = W + var0;
            bn = V + var1;
            if ((V + bn) % 2 != 0)
            {
                bn++;
            }

            bo = bw - bm / 2;
            switch (ax)
            {
                case 0:
                case 1:
                case 2:
                case 8:
                    bp = m - bn / 2;
                    break;
                case 3:
                case 6:
                    bp = n - bn / 2;
                    break; // Java: falls into empty case 4/5/7 then out of switch
                case 4:
                case 5:
                case 7:
                    break;
            }

            if (p[0] && ax == 8)
            {
                bp = bv * 80 / 100;
            }
        }

        private static void m_d(Graphics var0)
        {
            if (bh)
            {
                var0.SetColor(j);
                if (p[0])
                {
                    var0.SetColor(16744192);
                }

                if (!bC && bA == 27)
                {
                    var0.SetColor(14588928);
                    var0.DrawRect(bo - 2, bp - 2, bm + 3, bn + 4);
                    var0.DrawRect(bo - 1, bp - 1, bm + 1, bn + 2);
                    var0.SetColor(5767410);
                }

                T = 0;
                var0.FillRect(bo, bp, bm, bn + 1);
                m_a(bl, var0, bw, bp + (bn >> 1), 3);
            }
        }

        private static void m_e(Graphics var0)
        {
            int var1 = k;
            int var2 = bv - 2;
            int var3 = var1;
            int var4 = bu - var1;
            if (!aq)
            {
                if (MiamiNights.e.n)
                {
                    Image var5 = aA[12];
                    Image var6 = aA[12];
                    if (bA == 26)
                    {
                        if (MiamiNights.e.c)
                        {
                            var6 = aA[13];
                        }
                        else
                        {
                            var5 = aA[13];
                        }
                    }
                    else if (bA == 25 && bC)
                    {
                        if (MiamiNights.e.c)
                        {
                            var5 = aA[13];
                        }
                        else
                        {
                            var6 = aA[13];
                        }
                    }

                    if (!MiamiNights.e.a)
                    {
                        bj = (sbyte)(bj | (MiamiNights.e.c ? 1 : 2));
                        bi = (sbyte)(bi | 1);
                    }

                    if (!MiamiNights.e.b)
                    {
                        bj = (sbyte)(bj | (MiamiNights.e.c ? 2 : 1));
                        bi = (sbyte)(bi | 2);
                    }

                    if ((bj & 1) != 0)
                    {
                        m_a(var0, var5, var1, var2, 36);
                    }

                    if ((bj & 2) != 0)
                    {
                        m_a(var0, var6, bu - var1, var2, 40);
                    }

                    var3 = var1 + (aA[12].GetWidth() / 2 - aA[9].GetWidth() / 2);
                    var4 += -aA[12].GetWidth() / 2 + aA[8].GetWidth() / 2;
                    var2 += -aA[12].GetHeight() / 2 + aA[9].GetHeight() / 2;
                }

                if (!MiamiNights.e.a)
                {
                    bi = (sbyte)(bi | 1);
                }

                if (!MiamiNights.e.b)
                {
                    bi = (sbyte)(bi | 2);
                }

                if (MiamiNights.e.c)
                {
                    if ((bi & 1) != 0)
                    {
                        m_a(var0, aA[9], var3, var2, 36);
                    }

                    if ((bi & 2) != 0)
                    {
                        m_a(var0, aA[8], var4, var2, 40);
                        return;
                    }
                }
                else
                {
                    if ((bi & 2) != 0)
                    {
                        m_a(var0, aA[8], var3, var2, 36);
                    }

                    if ((bi & 1) != 0)
                    {
                        m_a(var0, aA[9], var4, var2, 40);
                    }
                }
            }
        }

        private static void m_a(bool var0, bool var1)
        {
            if (bz != null)
            {
                ao.RemoveCommand(bz);
            }

            if (by != null)
            {
                ao.RemoveCommand(by);
            }

            if (MiamiNights.e.c)
            {
                if (var0)
                {
                    ao.AddCommand(by);
                }

                if (var1)
                {
                    ao.AddCommand(bz);
                    return;
                }
            }
            else
            {
                if (var1)
                {
                    ao.AddCommand(bz);
                }

                if (var0)
                {
                    ao.AddCommand(by);
                }
            }
        }

        private static void m_k()
        {
            if (bz != null)
            {
                ao.RemoveCommand(bz);
                bz = null;
            }

            if (by != null)
            {
                ao.RemoveCommand(by);
                by = null;
            }
        }

        private static Image m_a(sbyte[] var0, int var1, int var2, int var3, int var4)
        {
            int var5 = 0;

            for (int var6 = var1; var5 == 0 && var6 < var1 + var2; var6++)
            {
                if ((var0[var6] & 255) == 80 && (var0[var6 + 1] & 255) == 76 && (var0[var6 + 2] & 255) == 84 && (var0[var6 + 3] & 255) == 69)
                {
                    var5 = var6;
                }
            }

            int var9 = (var0[var5 - 4] << 24 & unchecked((int)0xFF000000)) + (var0[var5 - 3] << 16 & 0xFF0000) + (var0[var5 - 2] << 8 & 0xFF00) + (var0[var5 - 1] << 0 & 0xFF);
            var0[var5 + 4 + 3 * var3] = (sbyte)((var4 & 0xFF0000) >> 16);
            var0[var5 + 4 + 3 * var3 + 1] = (sbyte)((var4 & 0xFF00) >> 8);
            var0[var5 + 4 + 3 * var3 + 2] = (sbyte)(var4 & 0xFF);
            sbyte[] var10 = new sbyte[var9 + 4];
            Array.Copy(var0, var5, var10, 0, var9 + 4);
            long[] var11 = new long[256];

            for (int var12 = 0; var12 < 256; var12++)
            {
                long var7 = var12;

                for (int var13 = 0; var13 < 8; var13++)
                {
                    if ((var7 & 1L) == 1L)
                    {
                        var7 = 3988292384L ^ var7 >> 1;
                    }
                    else
                    {
                        var7 >>= 1;
                    }
                }

                var11[var12] = var7;
            }

            long var14 = 4294967295L;

            for (int var16 = 0; var16 < var10.Length; var16++)
            {
                var14 = var11[(int)(var14 ^ var10[var16]) & 0xFF] ^ var14 >> 8;
            }

            var14 ^= 4294967295L;
            var0[var5 + 4 + var9] = (sbyte)((var14 & -16777216L) >> 24);
            var0[var5 + 4 + var9 + 1] = (sbyte)((var14 & 16711680L) >> 16);
            var0[var5 + 4 + var9 + 2] = (sbyte)((var14 & 65280L) >> 8);
            var0[var5 + 4 + var9 + 3] = (sbyte)((var14 & 255L) >> 0);
            GC.Collect();
            return m_a(var0, var1, var2);
        }

        private static void m_a(Graphics var0, int var1, int var2, int var3, int var4)
        {
            if (var3 > var4)
            {
                var3 = var4;
            }

            int var5 = (bu - var2) / 2;
            var0.SetColor(16777215);
            var0.DrawRect(var5, var1, var2, 6);
            int var6 = (var2 - 2 - 2) * var3 / var4 + 1;
            var0.SetColor(16711680);
            var0.FillRect(var5 + 1 + 1, var1 + 1 + 1, var6, 3);
        }

        private static void m_a(Graphics var0, int var1, int var2, int var3, int var4, int var5, int var6)
        {
            var0.FillTriangle(var1, var2, var3, var4, var5, var6);
        }

        private static void m_a(Graphics var0, Image var1, int var2, int var3, int var4, int var5, int var6, int var7)
        {
            var0.DrawRegion(var1, var2, var3, var4, var5, 0, var6, var7, 20);
        }

        private static void m_a(Graphics var0, Image var1, int var2, int var3, int var4)
        {
            if (MiamiNights.e.q)
            {
                var0.DrawImage(var1, var2, var3, var4);
            }
            else
            {
                if ((var4 & 1) != 0)
                {
                    var2 -= var1.GetWidth() >> 1;
                }

                if ((var4 & 2) != 0)
                {
                    var3 -= var1.GetHeight() >> 1;
                }

                if ((var4 & 8) != 0)
                {
                    var2 -= var1.GetWidth();
                }

                if ((var4 & 32) != 0)
                {
                    var3 -= var1.GetHeight();
                }

                var0.DrawImage(var1, var2, var3, 0);
            }
        }

        private static void m_b(Graphics var0, int var1, int var2, int var3, int var4)
        {
            var1 = Math.Max(var1, 0);
            var2 = Math.Max(var2, 0);
            var3 = Math.Min(var3, bu);
            var4 = Math.Min(var4, bv);
            var0.SetClip(var1, var2, var3, var4);
        }

        public void Run() // final -> none; implements Runnable (original run())
        {
            if (MiamiNights.e.j == 2)
            {
                while (@as)
                {
                    try
                    {
                        if (at != null)
                        {
                            h = at;
                            m_m();
                            at = null;
                        }

                        System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception var2)
                    {
                    }
                }
            }
        }

        private static void m_l()
        {
            RecordStore var0 = null;

            try
            {
                var0 = RecordStore.OpenRecordStore("igp19", false);
            }
            catch (Exception var5)
            {
                try
                {
                    var0 = RecordStore.OpenRecordStore("igp19", true);
                }
                catch (Exception var4)
                {
                }
            }

            try
            {
                if (var0 != null)
                {
                    var0.CloseRecordStore();
                }
            }
            catch (Exception var3)
            {
            }
        }

        private static void m_m()
        {
            if (h != null && h.Length > 0)
            {
                string var0 = h;
                h = null;
                new StringBuilder().Append("urlPlatformRequest = ").Append(var0).ToString();

                try
                {
                    m_b(var0);
                    if (MiamiNights.e.k)
                    {
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(200);
                    }
                }
                catch (Exception var2)
                {
                }

                if (MiamiNights.e.m)
                {
                    av = 4;
                }
                else
                {
                    av = 1;
                }

                if (MiamiNights.e.l)
                {
                    an.NotifyDestroyed();
                }
            }
        }

        public void CommandAction(Command var1, Displayable var2) // final -> none; implements CommandListener
        {
            if (aq)
            {
                if (var1 == by)
                {
                    m_a(25);
                    return;
                }

                if (var1 == bz)
                {
                    m_a(26);
                }
            }
        }

        private static string m_a(string var0)
        {
            if (MiamiNights.e.s)
            {
                string var1;
                return (var1 = (string)bK.get(var0)) != null && var1 != "" ? var1 : null;
            }
            else
            {
                return an.GetAppProperty(var0);
            }
        }

        private static void m_b(string var0) // was `throws ConnectionNotFoundException`
        {
            // PORT-QUESTION: network path — original `an.platformRequest(var0)`;
            // engine MIDlet has no platformRequest yet.
            Console.WriteLine("platformRequest: " + var0);
        }

        private static void m_n()
        {
            bK.put("URL-TEMPLATE-GAME", MiamiNights.e.t);
            bK.put("URL-OPERATOR", MiamiNights.e.u);
            bK.put("URL-PT", MiamiNights.e.v);
            bK.put("IGP-PROMOS", MiamiNights.e.w);
            bK.put("IGP-WN", MiamiNights.e.x);
            bK.put("IGP-BS", MiamiNights.e.y);
            bK.put("IGP-CATEGORIES", MiamiNights.e.z);
            bK.put("IGP-VERSION", MiamiNights.e.A);
            bK.put("URL-ORANGE", MiamiNights.e.B);
        }
    }
}
