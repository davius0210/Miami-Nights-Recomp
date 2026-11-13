// Port of original class GloftMMN (validated VF decompile).
// Naming: original names kept; m_ prefix where field/method collide (PORTING.md R1).
// Resource container (RECON.md §3), string tables, MMAPI audio channel machine.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MiamiNights
{
    public sealed class GloftMMN : MIDlet
    {
        public static string a = "";
        public static GloftMMN b;
        public static h c;
        public static Display d;
        public static int e;
        private static sbyte[][] p;
        private static int[] q;
        private static Dictionary<int, int> r;
        private static Player[] s;
        private static int[] t;
        private static int[] u;
        private static int[] v;
        private static int[] w;
        private static int[] x;
        private static int[] y;
        public static bool f;
        private static sbyte[] z;
        public static Stream g;
        private static string A;
        public static int h;
        private static int[] B;
        private static int C;
        public static int[] i;
        private static int D;
        public static int j;
        public static readonly string[] k;
        public static JavaRandom l;                 // java.util.Random (assigned by original site)
        public static int m;
        public static sbyte[] n;
        public static int[] o;

        static GloftMMN()
        {
            k = new[] { "?", "audio/x-wav", "audio/midi" };
            s = new Player[1];
            f = false;
        }

        // ---------------- MIDlet lifecycle ----------------

        public GloftMMN()
        {
            b = this;
            if (c == null)
            {
                c = new h();
                MiamiNights.h.Inst = c;
                // original: new Thread(c).start(); -> Game1 drives RunInit/FrameStep
            }
        }

        public override void StartApp()
        {
            if (d == null) d = Display.GetDisplay(this);
            d.SetCurrent(c);
            if (c != null) c.ShowNotify();
        }

        public override void PauseApp()
        {
            c.HideNotify();
        }

        public override void DestroyApp(bool unconditional)
        {
            if (c != null) MiamiNights.h.m_a();   // original: h.a() sets loop sentinel h=-1
            NotifyDestroyed();
        }

        // ---------------- original a(String): memory debug ----------------
        public static void m_a(string msg)
        {
            GC.Collect();
            Console.WriteLine(msg + " => " + (GC.GetTotalMemory(false) / 1024));
        }

        // ---------------- audio channel machine ----------------

        private static void l32(int n)   // original private l(int): init capacity (R1 rename)
        {
            s = new Player[1];
            t = new int[1];
            u = new int[1];
            v = new int[1];
            w = new int[1];
            x = new int[1];
            y = new int[1];
            e = n;
            r = new Dictionary<int, int>();
            p = new sbyte[e][];
            q = new int[e];
        }

        public static void m_a()       // original a(): audio init (32 slots)
        {
            l32(32);
        }

        public static void m_c()       // original c(): free everything
        {
            m_e();
            for (int n = 0; n < e; ++n) p[n] = null;
            p = null; q = null; r = null;
            for (int n = 0; n < 1; ++n) FreePlayer(n);
            s = null; t = null; u = null; v = null; w = null; x = null; y = null;
            GC.Collect();
        }

        private static void m_m(int n) // original private m(int): load sound record into slot
        {
            int n2 = 0;
            if (n < 0) return;
            while (p[n2] != null) ++n2;
            p[n2] = m_j(n);
            q[n2] = j;
            r[n2] = n2;
        }

        private static void m_n(int n) // original private n(int): unload sound
        {
            if (n < 0) return;
            int n2 = m_o(n);
            r?.Remove(n2);
            p[n2] = null;
            GC.Collect();
        }

        private static int m_o(int n)  // original private o(int): id -> slot resolve
        {
            if (r != null && r.TryGetValue(n, out int val)) return val;
            return n;
        }

        public static void m_a(int n)          // original a(int): load sound
        {
            m_m(n);
        }

        public static void m_b(int n)          // original b(int): unload sound
        {
            m_n(n);
        }

        private static void Play0(int n, int n2, int n3, int n4, int n5)   // original private a(int,int,int,int,int)
        {
            if (n2 < 0) return;
            try { n2 = m_o(n2); }
            catch (Exception) { return; }
            bool bl = u[n] == n2 && w[n] == 1;
            if (!bl)
            {
                if (w[n] == 2 && (v[n] < n5 || u[n] == n2)) return;
                FreePlayer(n);
            }
            t[n] = 2;
            u[n] = n2;
            v[n] = n5;
            y[n] = n3;
            x[n] = n4;
            if (!bl) w[n] = 0;
        }

        public static void m_c(int n)          // original c(int): play via a(n,1)
        {
            m_a(n, 1);
        }

        public static void m_a(int n, int n2)  // original a(int,int): play with loop count
        {
            if (f)
            {
                m_b();
                Play0(0, n, n2, 100, 0);
            }
        }

        public static void m_b()               // original b(): stop + free channel
        {
            m_e();
            FreePlayer(0);
        }

        public static void m_d(int n)          // original d(int): pause channel (queued)
        {
            t[n] = 3;
        }

        private static void CreatePlayer(int n)
        {
            try
            {
                int n2 = u[n];
                s[n] = Manager.CreatePlayer(new MemoryStream(Helpers.ToB(p[n2])), k[q[n2]]);
                if (s[n] == null) return;
                s[n].Realize();
                s[n].Prefetch();
                w[n] = 1;
            }
            catch (Exception) { }
        }

        private static void StartPlayer(int n)
        {
            try
            {
                int n2 = u[n];
                if (u[n] != n2 || w[n] != 1) CreatePlayer(n);
                if (y[n] == 0) s[n].SetLoopCount(-1);
                else s[n].SetLoopCount(y[n]);
                s[n].Start();
                w[n] = 2;
            }
            catch (Exception) { }
        }

        private static void StopPlayer(int n)
        {
            if (s[n] == null) return;
            try { s[n].Stop(); } catch (Exception) { }
            w[n] = 1;
        }

        private static void PausePlayer(int n)
        {
            try { s[n].Stop(); } catch (Exception) { }
            w[n] = 3;
        }

        private static void ResumePlayer(int n)
        {
            try { s[n].Start(); w[n] = 2; }
            catch (Exception) { }
        }

        public static void m_d()               // original d(): per-frame command pump
        {
            if (t == null) return;
            for (int i2 = 0; i2 < 1; ++i2)
            {
                try
                {
                    if (t[i2] == 0) continue;
                    switch (t[i2])
                    {
                        case 1: CreatePlayer(i2); break;
                        case 2: StartPlayer(i2); break;
                        case 3: StopPlayer(i2); break;
                        case 4: PausePlayer(i2); break;
                        case 5: ResumePlayer(i2); break;
                    }
                    t[i2] = 0;
                    s[i2]?.TickLoop();
                }
                catch (Exception) { }
            }
        }

        public static void m_e()               // original e(): queue stop on all channels
        {
            if (t == null) return;
            for (int i2 = 0; i2 < 1; ++i2) t[i2] = 3;
        }

        public static short[] m_e(int n)       // e(int): short[] record reader
        {
            m_h(n);
            m_g();
            int n2 = m_i();
            var sArray = new short[n2];
            for (int idx = 0; idx < n2; ++idx) sArray[idx] = (short)m_h();
            return sArray;
        }

        public static bool m_b(int n, int n2)  // original b(int,int): is sound playing
        {
            try
            {
                if (n2 < 0) return false;
                if (w[n] != 2) return false;
                if (u[n] != m_o(n2)) return false;
            }
            catch (Exception) { }
            return true;
        }

        private static void FreePlayer(int n)
        {
            try
            {
                if (s == null || w == null || t == null) return;
                if (s[n] != null)
                {
                    s[n].Stop();
                    s[n].Deallocate();
                    s[n].Close();
                    s[n] = null;
                    GC.Collect();
                }
                w[n] = 0;
                t[n] = 0;
            }
            catch (Exception) { }
        }

        // ---------------- resource container ----------------

        public static sbyte[] m_f(int n)       // f(int): byte[] record reader
        {
            m_h(n);
            m_g();
            int n2 = m_i();
            var byArray = new sbyte[n2];
            for (int idx = 0; idx < n2; ++idx) byArray[idx] = (sbyte)m_g();
            return byArray;
        }

        public static sbyte[][] m_g(int n)     // g(int): byte[][] table reader
        {
            m_h(n);
            m_g();
            int n2 = m_i();
            var table = new sbyte[n2][];
            for (int idx = 0; idx < n2; ++idx)
            {
                int n3 = m_i();
                if (n3 == 0) continue;
                table[idx] = new sbyte[n3];
                for (int jj = 0; jj < n3; ++jj) table[idx][jj] = (sbyte)m_g();
            }
            return table;
        }

        public static bool m_b(string path)    // b(String): open container + index
        {
            if (path == A) return true;
            if (g != null) m_f();
            A = path;
            try { g = File.OpenRead(Midp.ResPath(path)); }
            catch (Exception) { g = null; }
            D = 0;
            h = m_i();
            C = 4;
            B = new int[h + 1];
            i = new int[h];
            B[0] = 0;
            for (int idx = 0; idx < h; ++idx)
            {
                B[idx + 1] = m_i();
                C += 4;
                i[idx] = B[idx + 1] - B[idx] - 1;
            }
            return true;
        }

        public static void m_h(int n)          // h(int): seek record n, consume type byte -> j
        {
            int n2 = B[n] + C;
            if (D == n2)
            {
                j = m_g();
                return;
            }
            if (D > n2)
            {
                if (g != null)
                {
                    try { g.Close(); } catch (Exception) { }
                }
                try { g = File.OpenRead(Midp.ResPath(A)); }
                catch (Exception) { g = null; }
                D = 0;
            }
            else
            {
                n2 -= D;
            }
            SkipBytes(n2);
            j = m_g();
        }

        internal static void SkipBytes(int n)   // original i(int)
        {
            try
            {
                if (z == null) z = new sbyte[256];
                byte[] tmp = new byte[256];
                while (n > 256)
                {
                    int got = g.Read(tmp, 0, 256);
                    if (got <= 0) break;
                    D += got;
                    n -= 256;
                    if (got < 256) { n = 0; break; }
                }
                if (n > 0)
                {
                    int got = g.Read(tmp, 0, n);
                    if (got > 0) D += got;
                }
            }
            catch (Exception) { }
        }

        public static void m_f()               // f(): close container
        {
            try
            {
                if (A != null) A = null;
                if (g != null)
                {
                    g.Close();
                    g = null;
                }
                D = -1;
                GC.Collect();
            }
            catch (Exception) { }
        }

        public static int m_g()                // g(): u8, EOF -> 0xFF (Java read()==-1 & 0xFF)
        {
            int n = 0;
            try
            {
                n = g.ReadByte();
                ++D;
            }
            catch (Exception) { }
            return n & 0xFF;
        }

        public static int m_a(sbyte[] buf)     // a(byte[]): full read
        {
            int n = 0;
            try
            {
                byte[] tmp = new byte[buf.Length];
                while (n < buf.Length)
                {
                    int got = g.Read(tmp, n, buf.Length - n);
                    if (got <= 0) break;
                    n += got;
                }
                Buffer.BlockCopy(tmp, 0, buf, 0, n);
                D += n;
            }
            catch (Exception) { }
            return n;
        }

        public static int m_a(sbyte[] buf, int off, int len)
        {
            int n = 0;
            try
            {
                byte[] tmp = new byte[len];
                while (n < len)
                {
                    int got = g.Read(tmp, n, len - n);
                    if (got <= 0) break;
                    n += got;
                }
                Buffer.BlockCopy(tmp, 0, buf, off, n);
                D += n;
            }
            catch (Exception) { }
            return n;
        }

        public static sbyte[] m_j(int n)       // j(int): full record payload
        {
            sbyte[] byArray = null;
            try
            {
                if (n < 0 || n >= h) return null;
                m_h(n);
                byArray = new sbyte[i[n]];
                int got = 0;
                while (got < i[n])
                {
                    byte[] tmp = new byte[i[n] - got];
                    int rl = g.Read(tmp, 0, tmp.Length);
                    if (rl <= 0) break;
                    Buffer.BlockCopy(tmp, 0, byArray, got, rl);
                    got += rl;
                }
                D += got;
            }
            catch (Exception) { }
            return byArray;
        }

        public static int m_h()                // h(): u16 LE
        {
            return m_g() | m_g() << 8;
        }

        private static int m_i()               // i(): u32 LE
        {
            return m_g() | m_g() << 8 | m_g() << 16 | m_g() << 24;
        }

        // ---------------- random (original c(int,int) / a(int,int,int) / a(long)) ----------------

        public static int m_c(int n, int n2)
        {
            if (n2 != n)
            {
                int n3 = l.NextInt();
                if (n3 < 0) n3 *= -1;
                return n + n3 % (n2 - n);
            }
            return n2;
        }

        public static int m_a(int n, int n2, int n3)
        {
            int n4;
            while ((n4 = m_c(n, n2)) == n3) { }
            return n4;
        }

        public static int m_a(long val)        // original a(long): ported literally
        {
            long acc = 0L;
            long bit = 32768L;
            long shift = 15L;
            do
            {
                long thresh;
                if (val < (thresh = ((acc << 1) + bit) << (int)shift--)) continue;
                acc += bit;
                val -= thresh;
            } while ((bit >>= 1) > 0L);
            return (int)acc;
        }

        private static void SkipN(int n)       // original v(int)
        {
            try
            {
                g.Seek(n, SeekOrigin.Current);
                D += n;
            }
            catch (Exception) { }
        }

        // ---------------- strings (original a(String,int) / k(int)) ----------------

        public static void m_a(string path, int lang)
        {
            int n2;
            m_b(path);
            m_h(lang);
            m = 0;
            o = null;
            n = null;
            int n3 = 0;
            for (n2 = 0; n2 < MiamiNights.h.ay; ++n2)
            {
                n3 = m_i();
                SkipN(4 * (n3 - 1));
                n3 = m_i();
                SkipN(n3);
            }
            m = m_i();
            o = new int[m + 1];
            for (n2 = 1; n2 < m + 1; ++n2) o[n2] = m_i();
            n = new sbyte[o[m]];
            m_a(n);
            m_f();
        }

        public static string m_k(int idx)
        {
            if (MiamiNights.h.h_ == 20 && idx < MiamiNights.h.az.Length) return MiamiNights.h.az[idx];
            try
            {
                int n2 = o[idx + 1] - o[idx];
                if (n2 == 0) return null;
                int n3 = o[idx];
                string str = Iso1(n, n3, 1);
                if (string.CompareOrdinal(str, "@") == 0)
                {
                    if (MiamiNights.h.s[0].a[0] == 1) return m_k(idx + 1);
                    --n2;
                    ++n3;
                }
                if (MiamiNights.h.h_ == 21)
                {
                    var byArray = new sbyte[n2];
                    for (int idx2 = 0; idx2 < n2; ++idx2)
                        byArray[idx2] = n[n3 + idx2] == 124 ? (sbyte)10 : n[n3 + idx2];
                    return Iso1(byArray, 0, n2);
                }
                return Iso1(n, n3, n2);
            }
            catch (Exception) { return null; }
        }

        internal static string Iso1(sbyte[] bytes, int off, int len)
        {
            return Encoding.GetEncoding("ISO-8859-1").GetString(Helpers.ToB(bytes), off, len);
        }
    }
}
