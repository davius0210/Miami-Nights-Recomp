// StatsPanel.cs — Sims-style "Motives" panel for the main player (h.s[0]).
// Look (The Sims 1): beveled blue-grey panel, header with name + mood plumbob,
// inset bar tracks, need bars that shift green -> yellow -> orange -> red,
// skills as segmented blocks. Bar length = "how good" (full = good).
// Drawn from h.cs at the end of the game frame (clip already full-canvas there);
// toggled with the '#' / '?' key.

namespace MiamiNights
{
    internal static class StatsPanel
    {
        // 0 = compact (default, small corner widget), 1 = full panel, 2 = hidden
        public static int Mode = 0;
        public static bool Visible { get { return Mode != 2; } }
        public static void Toggle() { Mode = (Mode + 1) % 3; }

        private static readonly string[] NeedLab = { "Hygiene", "Hunger", "Energy", "Bladder", "Social" };
        private static readonly int[] NeedAttr = { 22, 28, 29, 25, 32 };
        // false = high raw value is BAD (hunger/fatigue/bladder grow as they worsen)
        private static readonly bool[] NeedHighGood = { true, false, false, false, true };

        private static readonly string[] SkillLab = { "Culture", "Health", "Charisma", "Fitness" };
        private static readonly int[] SkillAttr = { 13, 14, 17, 30 };

        // palette
        private const int PanelBg = 0x7B8DB0, PanelHi = 0xD6E0F5, PanelLo = 0x2E3A58;
        private const int HeaderBg = 0x4C5F8A, TrackBg = 0x1B2236, TrackHi = 0x59688C;
        private const int Shadow = 0x141A2B;

        private const int W = 134, BarX = 70, BarW = 59;
        private const int HeaderH = 18, RowH = 11;

        public static void Draw(Graphics gfx)
        {
            g p = MiamiNights.h.s != null && MiamiNights.h.s.Length > 0 ? MiamiNights.h.s[0] : null;
            if (p == null || p.a == null) return;

            if (Mode == 0) { DrawCompact(gfx, p); return; }

            int h = HeaderH + NeedAttr.Length * RowH + RowH + SkillAttr.Length * RowH + 4;
            int x = 2, y = 315 - h - 4;

            // drop shadow, body, 2px bevel
            gfx.SetColor(Shadow);
            gfx.FillRect(x + 3, y + 3, W, h);
            gfx.SetColor(PanelBg);
            gfx.FillRect(x, y, W, h);
            gfx.SetColor(PanelHi);
            gfx.FillRect(x, y, W, 1);
            gfx.FillRect(x, y, 1, h);
            gfx.SetColor(PanelLo);
            gfx.FillRect(x, y + h - 1, W, 1);
            gfx.FillRect(x + W - 1, y, 1, h);

            // header strip
            gfx.SetColor(HeaderBg);
            gfx.FillRect(x + 2, y + 2, W - 4, HeaderH - 3);
            gfx.SetColor(PanelLo);
            gfx.FillRect(x + 2, y + HeaderH - 2, W - 4, 1);

            string title = GloftMMN.m_k(p.a[1]);
            if (string.IsNullOrEmpty(title)) title = "Sim";
            if (title.Length > 10) title = title.Substring(0, 10);
            Text(gfx, title, x + 5, y + 5, 0xFFFFFF);

            // needs
            int[] pcts = new int[NeedAttr.Length];
            int sum = 0;
            int ry = y + HeaderH + 1;
            for (int i = 0; i < NeedAttr.Length; i++)
            {
                pcts[i] = Pct(p, NeedAttr[i], NeedHighGood[i]);
                sum += pcts[i];
                Text(gfx, NeedLab[i], x + 4, ry, 0xF0F4FF);
                NeedBar(gfx, x + BarX, ry + 1, pcts[i]);
                ry += RowH;
            }

            // mood plumbob in the header, colour follows average need level
            int mood = sum / NeedAttr.Length;
            Plumbob(gfx, x + W - 14, y + 3, MoodColor(mood));

            // divider + skills
            gfx.SetColor(PanelLo);
            gfx.FillRect(x + 3, ry + 1, W - 6, 1);
            gfx.SetColor(PanelHi);
            gfx.FillRect(x + 3, ry + 2, W - 6, 1);
            ry += 3;
            for (int i = 0; i < SkillAttr.Length; i++)
            {
                int pct = Pct(p, SkillAttr[i], true);
                Text(gfx, SkillLab[i], x + 4, ry + 1, 0xDCE6FF);
                SkillBar(gfx, x + BarX, ry + 2, pct);
                ry += RowH;
            }
        }

        // Sims-style minimal widget: plumbob + 5 thin need bars, no labels, tucked in the bottom-left corner
        // Sims 2 style docked bottom panel: beveled box, plumbob on the left,
        // "Needs" header, two columns of labelled thin motive bars.
        private static void DrawCompact(Graphics gfx, g p)
        {
            const int sx = 34, sw = 172, sh = 46;
            int y = 315 - sh;
            gfx.SetColor(PanelLo);
            gfx.FillRect(sx, y, sw, sh);
            gfx.SetColor(PanelBg);
            gfx.FillRect(sx + 1, y + 1, sw - 2, sh - 1);
            gfx.SetColor(PanelHi);
            gfx.FillRect(sx + 1, y + 1, sw - 2, 1);
            gfx.FillRect(sx + 1, y + 1, 1, sh - 1);
            // inner inset area
            gfx.SetColor(HeaderBg);
            gfx.FillRect(sx + 18, y + 3, sw - 21, sh - 5);

            // header
            Text(gfx, "Needs", sx + 18 + (sw - 21) / 2 - 12, y + 4, 0xFFFFFF);

            int sum = 0;
            for (int i = 0; i < NeedAttr.Length; i++)
            {
                int pct = Pct(p, NeedAttr[i], NeedHighGood[i]);
                sum += pct;
                int col = i / 3, row = i % 3;
                int cx = sx + 21 + col * 76;
                int ry = y + 14 + row * 10;
                Text(gfx, NeedLab[i], cx, ry - 1, 0xF0F4FF);
                // thin bar under the label: track + fill
                gfx.SetColor(TrackBg);
                gfx.FillRect(cx, ry + 7, 70, 3);
                int fw = 70 * pct / 100;
                if (fw > 0)
                {
                    gfx.SetColor(MoodColor(pct));
                    gfx.FillRect(cx, ry + 7, fw, 3);
                }
            }
            Plumbob(gfx, sx + 3, y + sh / 2 - 7, MoodColor(sum / NeedAttr.Length));
        }

        private static int Pct(g p, int attr, bool highGood)
        {
            int v = p.a[attr];
            int mn = MiamiNights.g.m_d(attr, 2), mx = MiamiNights.g.m_d(attr, 3);
            if (mx < mn) { int t = mn; mn = mx; mx = t; }
            if (mx <= mn) mx = mn + 100;
            int pct = highGood ? (v - mn) * 100 / (mx - mn) : (mx - v) * 100 / (mx - mn);
            return pct < 0 ? 0 : pct > 100 ? 100 : pct;
        }

        private static void Text(Graphics gfx, string s, int x, int y, int color)
        {
            gfx.SetColor(Shadow);
            gfx.DrawString(s, x + 1, y + 1, 20);
            gfx.SetColor(color);
            gfx.DrawString(s, x, y, 20);
        }

        private static int MoodColor(int pct)
        {
            return pct >= 70 ? 0x38E048 : pct >= 50 ? 0xB8E030 : pct >= 30 ? 0xFFB020 : 0xFF3A30;
        }

        // inset track + continuous fill with a lighter top highlight (Sims motive bar)
        private static void NeedBar(Graphics gfx, int x, int y, int pct)
        {
            gfx.SetColor(PanelLo);
            gfx.FillRect(x - 1, y - 1, BarW + 2, 9);
            gfx.SetColor(TrackBg);
            gfx.FillRect(x, y, BarW, 7);
            gfx.SetColor(TrackHi);
            gfx.FillRect(x - 1, y + 7, BarW + 2, 1);

            int bw = BarW * pct / 100;
            if (bw <= 0) return;
            int c = MoodColor(pct);
            gfx.SetColor(c);
            gfx.FillRect(x, y, bw, 7);
            gfx.SetColor(Lighten(c));
            gfx.FillRect(x, y, bw, 2);
            gfx.SetColor(Darken(c));
            gfx.FillRect(x, y + 6, bw, 1);
        }

        // 10 blocks, filled ones in the Sims skill blue
        private static void SkillBar(Graphics gfx, int x, int y, int pct)
        {
            int filled = (pct * 10 + 50) / 100;
            for (int b = 0; b < 10; b++)
            {
                int bx = x + b * 6;
                gfx.SetColor(b < filled ? 0x4AA8FF : TrackBg);
                gfx.FillRect(bx, y, 5, 6);
                if (b < filled)
                {
                    gfx.SetColor(0xB4DCFF);
                    gfx.FillRect(bx, y, 5, 1);
                }
            }
        }

        // green diamond like the Sims plumbob
        private static void Plumbob(Graphics gfx, int x, int y, int c)
        {
            gfx.SetColor(Shadow);
            gfx.FillTriangle(x + 6, y - 1, x - 1, y + 6, x + 13, y + 6);
            gfx.FillTriangle(x - 1, y + 6, x + 13, y + 6, x + 6, y + 14);
            gfx.SetColor(c);
            gfx.FillTriangle(x + 6, y, x, y + 6, x + 12, y + 6);
            gfx.SetColor(Darken(c));
            gfx.FillTriangle(x, y + 6, x + 12, y + 6, x + 6, y + 13);
            gfx.SetColor(Lighten(c));
            gfx.FillTriangle(x + 6, y + 1, x + 3, y + 5, x + 6, y + 5);
        }

        private static int Lighten(int c)
        {
            int r = (c >> 16 & 255) + 70, gg = (c >> 8 & 255) + 70, b = (c & 255) + 70;
            return (r > 255 ? 255 : r) << 16 | (gg > 255 ? 255 : gg) << 8 | (b > 255 ? 255 : b);
        }

        private static int Darken(int c)
        {
            return (c >> 16 & 255) * 3 / 5 << 16 | (c >> 8 & 255) * 3 / 5 << 8 | (c & 255) * 3 / 5;
        }
    }
}
