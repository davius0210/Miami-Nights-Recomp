// NpcAi.cs — added autonomous NPC layer: per-NPC needs decay + utility decisions
// (hygiene / hunger / fatigue / bathroom / social) driving walk-to-object, wander
// and seek-companion behavior.
// Hooks (the only touched original sites):
//   h.cs  — Tick() called once per playing frame right after g.m_m()
//   f.cs  — m_n() skips the original g.m_o() for NPCs this class is driving (Owned),
//           so movement/anim are controlled here without fighting the original
//           state machine. Original code paths are otherwise untouched.

using System;

namespace MiamiNights
{
    internal static class NpcAi
    {
        private const int IDLE = 0, MOVE = 1, USE = 2, SOCIAL = 3;

        // object-type name ids (string table 102..140) grouped per need
        private static readonly int[] CleanNames = { 109, 107, 122, 138 };                  // SHOWER SINK TOWEL JACUZZI
        private static readonly int[] ToiletNames = { 106, 107 };                           // TOILET SINK
        private static readonly int[] FoodNames = { 112, 126, 115, 133, 108, 127, 125 };    // FRIDGE FOOD TABLE KITCHEN BARBECUE BOWL DISHES
        private static readonly int[] RestNames = { 104, 114, 102 };                        // BED COUCH CHAIR

        private static readonly int[] NeedAttr = { 22, 28, 29, 25, 32 };                    // hygiene, hunger, fatigue, bathroom, social
        private static readonly int[] NeedDelta = { -1, 1, 1, 1, -1 };
        private static readonly long[] NeedPeriod = { 8000, 10000, 12000, 10000, 10000 };  // game-ms per point (f.aT)

        private sealed class State
        {
            public int mode = IDLE;
            public int obj = -1;
            public int target = -1;
            public int need = -1;
            public int tx, ty;
            public long until;
            public long nextThink;
            public readonly long[] due = new long[5];
            public bool inited;
            public bool driving;
            public long pausedAt;   // 0 = not paused; plan survives reaction interruptions
        }

        private static readonly State[] st = new State[28];
        private static g[] lastS;
        private static short[][] lastE;
        private static readonly int[] typeName = new int[90];
        private static bool namesReady;
        private static readonly int[] tmpCell = new int[2];
        private static long lastAiLog;
        private static long totalSteps;                                  // cumulative movement steps by AI-driven NPCs
        private static readonly bool Log = Environment.GetEnvironmentVariable("MN_AI_LOG") == "1";

        // true while this frame's AI owns the NPC: f.m_n() must skip g.m_o()
        public static bool Owned(int i)
        {
            return i >= 0 && i < st.Length && st[i] != null && st[i].driving;
        }

        public static void Reset()
        {
            for (int i = 0; i < st.Length; i++) st[i] = null;
        }

        public static void Tick()
        {
            g[] S = MiamiNights.h.s;
            if (S == null || MiamiNights.h.n == null) return;

            // new game / zone reload rebuilds the character or object tables -> drop stale goals
            if (!ReferenceEquals(S, lastS) || !ReferenceEquals(MiamiNights.f.e, lastE))
            {
                Reset();
                lastS = S;
                lastE = MiamiNights.f.e;
            }

            if (MiamiNights.g.au) { ReleaseAll(); return; }   // dialogue open: original code owns NPCs

            EnsureNames();
            long now = MiamiNights.f.aT;

            // periodic AI summary (MN_AI_LOG=1)
            if (Log && now - lastAiLog >= 10000L)
            {
                lastAiLog = now;
                int act = 0, mov = 0, us = 0, soc = 0, pop = 0, pau = 0;
                string flags = "";
                for (int q = 1; q < st.Length; q++)
                {
                    if (S[q] != null && S[q].m_b())
                    {
                        pop++;
                        string f2 = (!S[q].A ? "" : "A") + (S[q].b[3] == 1 ? "3" : "") + (S[q].b[19] != 0 ? "9" : "") + (S[q].b[12] != 0 ? "2" : "");
                        flags += q + ":" + (f2.Length == 0 ? "-" : f2) + " ";
                    }
                    if (st[q] == null) continue;
                    if (st[q].mode != IDLE && !st[q].driving) pau++;
                    if (!st[q].driving) continue;
                    act++;
                    if (st[q].mode == MOVE) mov++;
                    else if (st[q].mode == USE) us++;
                    else if (st[q].mode == SOCIAL) soc++;
                }
                Console.WriteLine("[AI] active=" + pop + " driving=" + act + " paused=" + pau + " move=" + mov + " use=" + us + " social=" + soc + " steps=" + totalSteps + " zoneE=" + (MiamiNights.f.e != null ? MiamiNights.f.f_ : -1) + " | " + flags);
            }

            for (int i = 1; i < S.Length && i < st.Length; i++)
            {
                g n = S[i];
                State s = st[i];
                if (n == null) { if (s != null) s.driving = false; continue; }
                if (s == null) s = st[i] = new State();

                // inactive (left the zone / despawned) -> drop the plan entirely
                bool wasPaused = s.mode != IDLE && s.pausedAt != 0;
                if (!n.m_b())
                {
                    s.driving = false;
                    if (s.mode != IDLE) { Release(s, now); }
                    continue;
                }

                // yield to original machinery: in conversation / mid-reaction /
                // special scene / paired with another character -> PAUSE the plan
                // (keep target+mode, resume stepping when the reaction clears)
                if (n.A || n.b[3] == 1 || n.b[19] != 0 || n.b[12] != 0)
                {
                    s.driving = false;
                    if (s.mode != IDLE)
                    {
                        if (s.pausedAt == 0)
                        {
                            s.pausedAt = now;
                            if (Log) Console.WriteLine("[AI] pause npc" + i + " A=" + n.A + " b3=" + n.b[3] + " b19=" + n.b[19] + " b12=" + n.b[12]);
                        }
                        else if (now - s.pausedAt > 30000L)
                        {
                            if (Log) Console.WriteLine("[AI] pause-timeout npc" + i);
                            Release(s, now);
                        }
                    }
                    continue;
                }

                if (wasPaused && Log)
                {
                    Console.WriteLine("[AI] resume npc" + i + " mode=" + s.mode);
                }
                s.pausedAt = 0;   // resumed

                if (!s.inited)
                {
                    s.inited = true;
                    s.nextThink = now + 1000 + (i * 137) % 3000;   // stagger first decisions
                    for (int k = 0; k < 5; k++) s.due[k] = now + NeedPeriod[k];
                }

                Decay(n, s, now);

                switch (s.mode)
                {
                    case IDLE:
                        if (now >= s.nextThink) Think(S, n, s, i, now);
                        break;
                    case MOVE:
                        StepMove(S, n, s, now);
                        break;
                    case USE:
                        Face(n, s.tx, s.ty);
                        if (now >= s.until) Release(s, now);
                        break;
                    case SOCIAL:
                    {
                        g tc = s.target >= 0 && s.target < S.Length ? S[s.target] : null;
                        if (tc == null || !tc.m_b() || tc.A)
                        {
                            Release(s, now);
                        }
                        else
                        {
                            Face(n, tc.c[0], tc.c[1]);
                            if (now >= s.until)
                            {
                                Release(s, now);
                                s.nextThink = now + 5000 + GloftMMN.m_c(0, 3000);   // no chat ping-pong
                            }
                        }
                        break;
                    }
                }

                s.driving = s.mode != IDLE;
            }
        }

        // ---- needs: direct clamped writes (original m_c fires player-side reaction events) ----

        private static void Decay(g n, State s, long now)
        {
            for (int k = 0; k < 5; k++)
            {
                if (now >= s.due[k])
                {
                    s.due[k] = now + NeedPeriod[k];
                    Bump(n, NeedAttr[k], NeedDelta[k]);
                }
            }
        }

        private static void Bump(g n, int attr, int delta)
        {
            int mn = g.m_d(attr, 2), mx = g.m_d(attr, 3);
            if (mx < mn) { int t = mn; mn = mx; mx = t; }   // sbyte-min attrs come back unsigned
            int v = n.a[attr] + delta;
            if (v < mn) v = mn;
            if (v > mx) v = mx;
            n.a[attr] = v;
        }

        // ---- decisions ----

        private static void Think(g[] S, g n, State s, int idx, long now)
        {
            s.nextThink = now + 1000 + GloftMMN.m_c(0, 2000);

            int best = -1, bestP = 8, p;
            if (n.a[22] < 65 && (p = (65 - n.a[22]) * 2) > bestP) { bestP = p; best = 0; }   // dirty -> clean
            if (n.a[28] > 35 && (p = (n.a[28] - 35) * 2) > bestP) { bestP = p; best = 1; }   // hungry -> eat
            if (n.a[29] > 35 && (p = (n.a[29] - 35) * 2) > bestP) { bestP = p; best = 2; }   // tired -> rest
            if (n.a[25] > 40 && (p = (n.a[25] - 40) * 2) > bestP) { bestP = p; best = 3; }   // bladder -> toilet
            if (n.a[32] < 55 && (p = (55 - n.a[32]) * 3) > bestP) { bestP = p; best = 4; }   // lonely -> companion

            if (best == 4)
            {
                PlanSocial(S, n, s, idx, now);
                if (s.mode != IDLE) { if (Log) Console.WriteLine("[AI] npc" + idx + " -> social target=" + s.target); return; }
            }
            else if (best >= 0)
            {
                int[] names = best == 0 ? CleanNames : best == 1 ? FoodNames : best == 2 ? RestNames : ToiletNames;
                int o = FindObject(names, n);
                if (o >= 0)
                {
                    MiamiNights.f.m_a(o, tmpCell);   // object use-point cell (same as spawn placement)
                    s.mode = MOVE; s.obj = o; s.target = -1; s.need = best;
                    s.tx = tmpCell[0]; s.ty = tmpCell[1];
                    s.until = now + 15000;
                    if (Log) Console.WriteLine("[AI] npc" + idx + " -> obj need=" + best + " obj=" + o + " type=" + MiamiNights.f.e[o][0] + " name=" + typeName[MiamiNights.f.e[o][0]]);
                    return;
                }
            }

            if (GloftMMN.m_c(0, 100) < 65)
            {
                if (TryWander(n, s, now) && Log) Console.WriteLine("[AI] npc" + idx + " -> wander");
            }
        }

        private static void PlanSocial(g[] S, g n, State s, int idx, long now)
        {
            int bestJ = -1;
            long bestD = 7680L * 7680L;   // ~30 tiles search radius

            g p = S[0];
            if (p != null)
            {
                long dx = p.c[0] - n.c[0], dy = p.c[1] - n.c[1];
                long d = dx * dx + dy * dy;
                if (d < bestD) { bestD = d; bestJ = 0; }
            }

            for (int j = 1; j < S.Length; j++)
            {
                if (j == idx) continue;
                g o = S[j];
                if (o == null || !o.m_b() || o.A || o.b[19] != 0) continue;
                long dx = o.c[0] - n.c[0], dy = o.c[1] - n.c[1];
                long d = dx * dx + dy * dy;
                if (d < bestD) { bestD = d; bestJ = j; }
            }

            if (bestJ < 0) return;
            s.mode = MOVE; s.obj = -1; s.target = bestJ; s.need = 4;
            s.until = now + 15000;
        }

        private static int FindObject(int[] names, g n)
        {
            short[][] E = MiamiNights.f.e;
            if (E == null) return -1;
            int count = MiamiNights.f.f_;
            int best = -1;
            long bestD = long.MaxValue;

            for (int v = 0; v < count && v < E.Length; v++)
            {
                short[] o = E[v];
                if (o == null || o.Length < 3) continue;
                int type = o[0];
                if (type < 0 || type >= 90) continue;   // spawners/config/waypoints have no name
                int nm = typeName[type];
                bool ok = false;
                for (int k = 0; k < names.Length; k++) { if (names[k] == nm) { ok = true; break; } }
                if (!ok) continue;

                MiamiNights.f.m_a(v, tmpCell);
                long dx = tmpCell[0] - n.c[0], dy = tmpCell[1] - n.c[1];
                long d = dx * dx + dy * dy;
                if (d < bestD) { bestD = d; best = v; }
            }
            return best;
        }

        private static bool TryWander(g n, State s, long now)
        {
            int cx = n.c[0] >> 8, cy = n.c[1] >> 8;
            for (int tries = 0; tries < 12; tries++)
            {
                int tx = cx + GloftMMN.m_c(-8, 9);
                int ty = cy + GloftMMN.m_c(-8, 9);
                if (tx == cx && ty == cy) continue;
                int wx = (tx << 8) + 127, wy = (ty << 8) + 127;
                int kv = MiamiNights.f.m_b(wx, wy);   // 1 == wall / out of bounds
                if (kv != 1 && !MiamiNights.f.m_a(kv, wx, wy, n.b[6], false))
                {
                    s.mode = MOVE; s.obj = -1; s.target = -1; s.need = -1;
                    s.tx = wx; s.ty = wy;
                    s.until = now + 12000;
                    return true;
                }
            }
            return false;
        }

        // ---- movement / states ----

        private static void StepMove(g[] S, g n, State s, long now)
        {
            if (now > s.until) { Release(s, now); return; }

            if (s.target >= 0)
            {
                g tc = S[s.target];
                // the player is always a valid target (m_b() zone-stamp can be stale for s[0])
                bool tcOk = tc != null && (tc == S[0] || (tc.m_b() && !tc.A));
                if (!tcOk) { Release(s, now); return; }

                long dx = tc.c[0] - n.c[0], dy = tc.c[1] - n.c[1];
                if (dx * dx + dy * dy <= 40000L) { EnterSocial(n, s, tc, now); return; }   // ~0.8 tile

                tmpCell[0] = tc.c[0]; tmpCell[1] = tc.c[1];
                Step(n, tmpCell);
                dx = tc.c[0] - n.c[0]; dy = tc.c[1] - n.c[1];
                if (dx * dx + dy * dy <= 40000L) EnterSocial(n, s, tc, now);
            }
            else
            {
                tmpCell[0] = s.tx; tmpCell[1] = s.ty;
                if (Step(n, tmpCell))
                {
                    if (s.obj >= 0) EnterUse(n, s, now);
                    else Release(s, now);   // wander arrived
                }
            }
        }

        // one step toward target, with the same save/restore + tile-occupancy dance g.m_o() uses
        private static bool Step(g n, int[] tgt)
        {
            int ox = n.c[0], oy = n.c[1];
            bool arrived = n.m_a(tgt);
            int nx = n.c[0], ny = n.c[1];
            n.c[0] = ox; n.c[1] = oy;
            n.m_a(nx, ny);
            totalSteps++;
            return arrived;
        }

        private static void EnterUse(g n, State s, long now)
        {
            s.mode = USE;
            s.until = now + 5000 + GloftMMN.m_c(0, 4000);
            if (Log) Console.WriteLine("[AI] npc arrived at obj need=" + s.need + " obj=" + s.obj);
            switch (s.need)
            {
                case 0: Bump(n, 22, 50); break;   // clean up
                case 1: Bump(n, 28, -60); break;  // eat
                case 2: Bump(n, 29, -60); break;  // rest
                case 3: Bump(n, 25, -70); break;  // toilet
            }
            Face(n, s.tx, s.ty);
        }

        private static void EnterSocial(g n, State s, g tc, long now)
        {
            s.mode = SOCIAL;
            s.until = now + 5000 + GloftMMN.m_c(0, 4000);
            if (Log) Console.WriteLine("[AI] npc socialized (player=" + (tc == MiamiNights.h.s[0]) + ")");
            Bump(n, 32, 45);
            if (tc == MiamiNights.h.s[0]) Bump(tc, 32, 15);   // chatting with the player helps the player too
            Face(n, tc.c[0], tc.c[1]);
        }

        // face a world point: same call g.m_o() uses when an NPC turns toward the player
        private static void Face(g n, int tx, int ty)
        {
            MiamiNights.f.m_a(n, tx - n.c[0], ty - n.c[1], 1, 0);
        }

        private static void Release(State s, long now)
        {
            s.mode = IDLE; s.obj = -1; s.target = -1; s.need = -1; s.pausedAt = 0;
            s.nextThink = now + 600 + GloftMMN.m_c(0, 1400);
        }

        private static void ReleaseAll()
        {
            long now = MiamiNights.f.aT;
            for (int i = 0; i < st.Length; i++)
            {
                State s = st[i];
                if (s == null) continue;
                s.driving = false;
                if (s.mode != IDLE) { s.mode = IDLE; s.obj = -1; s.target = -1; s.need = -1; s.pausedAt = 0; s.nextThink = now + 2000; }
            }
        }

        // ---- object-type -> name-id map (replicates f.m_l's I-table walk) ----

        private static void EnsureNames()
        {
            if (namesReady) return;
            sbyte[] G = MiamiNights.f.G;
            short[] H = MiamiNights.f.H;
            sbyte[] I = MiamiNights.f.I;
            if (G == null || H == null || I == null) return;

            int acc = 0;
            for (int t = 0; t < 90; t++)
            {
                typeName[t] = acc >= 0 && acc < I.Length ? I[acc] & 255 : 255;
                int stride = MiamiNights.f.m_b(t, 3, -1);
                if (stride < 0) stride = 0;
                acc += stride;
            }
            namesReady = true;
        }
    }
}
