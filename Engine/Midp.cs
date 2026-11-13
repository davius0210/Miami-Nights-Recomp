// MIDP/CLDC API surface used by the original MIDlet, reimplemented with
// byte-compatible semantics on top of CPU int[] ARGB buffers.
// Reference: JSR-118 (MIDP 2.0) spec; original code paths in decompile/*.java.
using System;
using System.IO;

namespace MiamiNights
{
    // ---- javax.microedition.lcdui.GameCanvas constants (JSR-118 exact values) ----
    public static class Midp
    {
        public const int UP = 1;
        public const int LEFT = 2;
        public const int DOWN = 6;
        public const int RIGHT = 5;
        public const int FIRE = 8;
        public const int GAME_A = 9;
        public const int GAME_B = 10;
        public const int GAME_C = 11;
        public const int GAME_D = 12;

        // key codes
        public const int KEY_NUM0 = 48, KEY_NUM1 = 49, KEY_NUM2 = 50, KEY_NUM3 = 51, KEY_NUM4 = 52;
        public const int KEY_NUM5 = 53, KEY_NUM6 = 54, KEY_NUM7 = 55, KEY_NUM8 = 56, KEY_NUM9 = 57;
        public const int KEY_STAR = 42, KEY_POUND = 35;
        public const int KEY_UP = -1, KEY_DOWN = -2, KEY_LEFT = -3, KEY_RIGHT = -4, KEY_FIRE = -5;
        public const int KEY_SOFT1 = -6, KEY_SOFT2 = -7;

        // Standard MIDP device mapping: key code -> game action (0 = none).
        public static int GetGameAction(int keyCode)
        {
            switch (keyCode)
            {
                case KEY_UP: return UP;
                case KEY_DOWN: return DOWN;
                case KEY_LEFT: return LEFT;
                case KEY_RIGHT: return RIGHT;
                case KEY_FIRE: return FIRE;
                case KEY_NUM2: return UP;
                case KEY_NUM4: return LEFT;
                case KEY_NUM8: return DOWN;
                case KEY_NUM6: return RIGHT;
                case KEY_NUM5: return FIRE;
                case KEY_STAR: return GAME_A;
                case KEY_POUND: return GAME_B;
                default: return 0;
            }
        }

        public static string ResPath(string name)
        {
            // name like "/0" or "/dataIGP" (what getResourceAsStream received)
            return Path.Combine(AppContext.BaseDirectory, "res", name.TrimStart('/'));
        }

        private static System.Collections.Generic.Dictionary<string, string> manifest;

        public static string AppProperty(string key)
        {
            if (manifest == null)
            {
                manifest = new System.Collections.Generic.Dictionary<string, string>();
                try
                {
                    string path = Path.Combine(AppContext.BaseDirectory, "res", "META-INF", "MANIFEST.MF");
                    foreach (string raw in File.ReadAllLines(path))
                    {
                        int idx = raw.IndexOf(':');
                        if (idx > 0) manifest[raw.Substring(0, idx).Trim()] = raw.Substring(idx + 1).Trim();
                    }
                }
                catch (Exception) { }
            }
            return manifest.TryGetValue(key, out var val) ? val : null;
        }
    }

    // ---- javax.microedition.lcdui.Font (only Font.getFont(0,0,8) + getHeight + drawString used) ----
    public sealed class Font
    {
        public int Height;
        internal int size; // 0=small 2=large (MIDP sizes: 0,2,8 -> we track requested)

        public static Font GetFont(int face, int style, int size)
        {
            // original: Font.getFont(0, 0, 8) = FACE_SYSTEM, STYLE_PLAIN, SIZE_LARGE
            var f = new Font { size = size };
            f.Height = size >= 8 ? 11 : (size == 2 ? 9 : 8);
            return f;
        }

        public static Font GetDefaultFont() { return GetFont(0, 0, 0); }
    }

    // ---- javax.microedition.lcdui.Image ----
    public sealed class Image
    {
        public int W, H;
        public int[] Pixels; // ARGB, row-major (null until rasterized by SpriteArchive lazy loader)

        public Image() { }

        public Image(int w, int h)
        {
            W = w; H = h; Pixels = new int[w * h];
        }

        public static Image CreateRGBImage(int[] rgb, int w, int h, bool processAlpha)
        {
            var img = new Image(w, h);
            if (processAlpha)
            {
                Array.Copy(rgb, img.Pixels, w * h);
            }
            else
            {
                for (int i = 0; i < w * h; i++) img.Pixels[i] = rgb[i] | unchecked((int)0xFF000000);
            }
            return img;
        }

        public static Image CreateImage(int w, int h) { return new Image(w, h); }

        public static Image CreateImage(byte[] data)
        {
            var img = new Image();
            using (var ms = new MemoryStream(data))
            using (var tex = Microsoft.Xna.Framework.Graphics.Texture2D.FromStream(Game1.Instance.GraphicsDevice, ms))
            {
                img.W = tex.Width;
                img.H = tex.Height;
                img.Pixels = new int[tex.Width * tex.Height];
                tex.GetData(img.Pixels); // XNA top-left origin, same as MIDP
                // XNA Color memory order is ABGR (R lowest byte); engine uses ARGB. Un-premultiply + swap R/B.
                var pp = img.Pixels;
                for (int i = 0; i < pp.Length; i++)
                {
                    uint c = (uint)pp[i];
                    uint a = c >> 24, r = c & 0xFF, g = (c >> 8) & 0xFF, b = (c >> 16) & 0xFF;
                    if (a != 0 && a != 255) { r = Math.Min(255u, r * 255 / a); g = Math.Min(255u, g * 255 / a); b = Math.Min(255u, b * 255 / a); }
                    pp[i] = (int)((a << 24) | (r << 16) | (g << 8) | b);
                }
            }
            return img;
        }

        public static Image CreateImage(sbyte[] data)
        {
            return CreateImage(Helpers.ToB(data));
        }

        public static Image CreateImage(sbyte[] data, int off, int len)
        {
            byte[] tmp = new byte[len];
            Buffer.BlockCopy(data, off, tmp, 0, len);
            return CreateImage(tmp);
        }

        public static Image CreateImage(byte[] data, int off, int len)
        {
            if (off == 0 && len == data.Length) return CreateImage(data);
            var tmp = new byte[len];
            Array.Copy(data, off, tmp, 0, len);
            return CreateImage(tmp);
        }

        public static Image CreateImage(string name) // "/operatorLogo.png" etc
        {
            return CreateImage(File.ReadAllBytes(Midp.ResPath(name)));
        }

        public int GetWidth() { return W; }
        public int GetHeight() { return H; }

        public void GetRGB(int[] rgbData, int offset, int scanlength, int x, int y, int width, int height)
        {
            for (int row = 0; row < height; row++)
            {
                int src = (y + row) * W + x;
                int dst = offset + row * scanlength;
                Array.Copy(Pixels, src, rgbData, dst, width);
            }
        }

        public Graphics GetGraphics() { return new Graphics(this); }
    }

    // ---- javax.microedition.lcdui.Graphics ----
    // Origin/translate/clip semantics per MIDP. All coordinates are device-pixel ints.
    public sealed class Graphics
    {
        internal Image target;
        internal int tx, ty;             // translation origin
        internal int cx, cy, cw, ch;     // clip in translated coords (absolute = cx+tx..)
        internal int color = unchecked((int)0xFF000000);
        internal Font font = Font.GetDefaultFont();

        // construction defaults: full clip, no translation, black
        public Graphics(Image t)
        {
            target = t;
            cx = 0; cy = 0; cw = t.W; ch = t.H;
        }

        // MIDP coordinate space of this Graphics' target
        public int GetClipWidth() { return cw; }
        public int GetClipHeight() { return ch; }
        public int GetTranslateX() { return tx; }
        public int GetTranslateY() { return ty; }

        public void Translate(int x, int y) { tx += x; ty += y; }

        public void SetColor(int rgb)
        {
            color = unchecked((int)0xFF000000) | (rgb & 0xFFFFFF);
        }

        public void SetColor(int r, int g, int b)
        {
            color = unchecked((int)0xFF000000) | ((r & 0xFF) << 16) | ((g & 0xFF) << 8) | (b & 0xFF);
        }

        public int GetColor() { return color; }

        public void SetFont(Font f) { font = f; }
        public Font GetFont() { return font; }

        public static bool WorldClipSeen;
        public void SetClip(int x, int y, int w, int h)
        {
            // replaces clip; coordinates relative to current origin
            if (x == 0 && y == 75 && w == 240 && h == 240)
            {
                if (WideWorld) { cx = 0; cy = 0; cw = target.W; ch = target.H; return; }   // wide entity pass: world window = whole canvas
                WorldClipSeen = true; // gameplay world window
            }
            int ax = x + tx, ay = y + ty;
            cx = Math.Max(0, ax); cy = Math.Max(0, ay);
            cw = w; ch = h;
            IntersectClipBounds();
        }

        // widescreen entity pass: hard-coded world window (0,75,240,240) means "whole canvas"
        public bool WideWorld;

        public void ClipRect(int x, int y, int w, int h)
        {
            if (WideWorld && x == 0 && y == 75 && w == 240 && h == 240) return;
            int ax = x + tx, ay = y + ty;
            int x0 = Math.Max(cx, ax), y0 = Math.Max(cy, ay);
            int x1 = Math.Min(cx + cw, ax + w), y1 = Math.Min(cy + ch, ay + h);
            cx = x0; cy = y0; cw = Math.Max(0, x1 - x0); ch = Math.Max(0, y1 - y0);
        }

        private void IntersectClipBounds()
        {
            cx = Math.Max(0, Math.Min(cx, target.W));
            cy = Math.Max(0, Math.Min(cy, target.H));
            cw = Math.Max(0, Math.Min(cw, target.W - cx));
            ch = Math.Max(0, Math.Min(ch, target.H - cy));
        }

        // rectangle in absolute target pixels intersected with clip
        private void AbsRect(int x, int y, int w, int h, out int X0, out int Y0, out int X1, out int Y1)
        {
            X0 = Math.Max(cx, x + tx);
            Y0 = Math.Max(cy, y + ty);
            X1 = Math.Min(cx + cw, x + tx + w);
            Y1 = Math.Min(cy + ch, y + ty + h);
        }

        public void FillRect(int x, int y, int w, int h)
        {
            if (w <= 0 || h <= 0) return;
            AbsRect(x, y, w, h, out int X0, out int Y0, out int X1, out int Y1);
            int[] px = target.Pixels;
            int stride = target.W;
            for (int yy = Y0; yy < Y1; yy++)
            {
                int row = yy * stride;
                for (int xx = X0; xx < X1; xx++) px[row + xx] = color;
            }
        }

        public void DrawRect(int x, int y, int w, int h)
        {
            if (w <= 0 || h <= 0) return;
            FillRect(x, y, w, 1);
            FillRect(x, y + h - 1, w, 1);
            FillRect(x, y + 1, 1, h - 2);
            FillRect(x + w - 1, y + 1, 1, h - 2);
        }

        public void FillTriangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            // bbox + edge functions, then clip
            int minX = Math.Max(cx, Math.Min(x1, Math.Min(x2, x3)) + tx);
            int maxX = Math.Min(cx + cw, Math.Max(x1, Math.Max(x2, x3)) + tx + 1);
            int minY = Math.Max(cy, Math.Min(y1, Math.Min(y2, y3)) + ty);
            int maxY = Math.Min(cy + ch, Math.Max(y1, Math.Max(y2, y3)) + ty + 1);
            int ax1 = x1 + tx, ay1 = y1 + ty, ax2 = x2 + tx, ay2 = y2 + ty, ax3 = x3 + tx, ay3 = y3 + ty;
            long d1 = (long)(ax2 - ax1) * (ay3 - ay1) - (long)(ax3 - ax1) * (ay2 - ay1);
            if (d1 == 0) return;
            int[] px = target.Pixels;
            int stride = target.W;
            for (int yy = minY; yy < maxY; yy++)
            {
                int row = yy * stride;
                for (int xx = minX; xx < maxX; xx++)
                {
                    long w1 = (long)(ax2 - ax1) * (yy - ay1) - (long)(xx - ax1) * (ay2 - ay1);
                    long w2 = (long)(ax3 - ax2) * (yy - ay2) - (xx - ax2) * (ay3 - ay2);
                    long w3 = (long)(ax1 - ax3) * (yy - ay3) - (xx - ax3) * (ay1 - ay3);
                    bool inside = d1 > 0 ? (w1 >= 0 && w2 >= 0 && w3 >= 0) : (w1 <= 0 && w2 <= 0 && w3 <= 0);
                    if (inside) px[row + xx] = color;
                }
            }
        }

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            // Bresenham with clip
            int ax1 = x1 + tx, ay1 = y1 + ty, ax2 = x2 + tx, ay2 = y2 + ty;
            int dx = Math.Abs(ax2 - ax1), sx = ax1 < ax2 ? 1 : -1;
            int dy = -Math.Abs(ay2 - ay1), sy = ay1 < ay2 ? 1 : -1;
            int err = dx + dy;
            int[] px = target.Pixels;
            int stride = target.W;
            while (true)
            {
                if (ax1 >= cx && ax1 < cx + cw && ay1 >= cy && ay1 < cy + ch)
                    px[ay1 * stride + ax1] = color;
                if (ax1 == ax2 && ay1 == ay2) break;
                int e2 = 2 * err;
                if (e2 >= dy) { err += dy; ax1 += sx; }
                if (e2 <= dx) { err += dx; ay1 += sy; }
            }
        }

        public void DrawImage(Image img, int x, int y, int anchor)
        {
            int ax = x, ay = y;
            if ((anchor & 0x08) != 0) ax -= img.W;      // RIGHT
            else if ((anchor & 0x01) != 0) ax -= img.W / 2; // HCENTER
            // LEFT(4) or none -> left edge at x
            if ((anchor & 0x20) != 0) ay -= img.H;      // BOTTOM
            else if ((anchor & 0x02) != 0) ay -= img.H / 2; // VCENTER
            // TOP(16) or none -> top edge at y
            Blit(img, 0, 0, img.W, img.H, ax, ay, false, false);
        }

        // MIDP TRANS_*: 0 NONE, 1 MIRROR_ROT180(v-flip), 2 MIRROR(h-flip), 3 ROT180,
        // 4 MIRROR_ROT270, 5 ROT90, 6 ROT270, 7 MIRROR_ROT90
        public void DrawRegion(Image img, int x_src, int y_src, int w, int h, int transform, int x_dst, int y_dst, int anchor)
        {
            bool swap = transform >= 4;
            int dw = swap ? h : w, dh = swap ? w : h;
            int ax = x_dst, ay = y_dst;
            if ((anchor & 0x08) != 0) ax -= dw;
            else if ((anchor & 0x01) != 0) ax -= dw / 2;
            if ((anchor & 0x20) != 0) ay -= dh;
            else if ((anchor & 0x02) != 0) ay -= dh / 2;
            if (transform == 0) { Blit(img, x_src, y_src, w, h, ax, ay, false, false); return; }
            if (transform <= 3) { Blit(img, x_src, y_src, w, h, ax, ay, transform == 2 || transform == 3, transform == 1 || transform == 3); return; }
            int dx = ax + tx, dy = ay + ty;
            int X0 = Math.Max(cx, dx), Y0 = Math.Max(cy, dy);
            int X1 = Math.Min(cx + cw, dx + dw), Y1 = Math.Min(cy + ch, dy + dh);
            if (X1 <= X0 || Y1 <= Y0) return;
            int[] sp = img.Pixels, dp = target.Pixels;
            for (int yy = Y0; yy < Y1; yy++)
                for (int xx = X0; xx < X1; xx++)
                {
                    int i = xx - dx, j = yy - dy, u, v;
                    switch (transform)
                    {
                        case 4: u = j; v = i; break;
                        case 5: u = j; v = h - 1 - i; break;
                        case 6: u = w - 1 - j; v = i; break;
                        default: u = w - 1 - j; v = h - 1 - i; break;
                    }
                    int c = sp[(y_src + v) * img.W + x_src + u];
                    if ((c & unchecked((int)0xFF000000)) != 0) dp[yy * target.W + xx] = c;
                }
        }

        private void Blit(Image img, int sx, int sy, int w, int h, int dx, int dy, bool hflip, bool vflip)
        {
            // translate
            dx += tx; dy += ty;
            // clip intersection
            int X0 = Math.Max(cx, dx);
            int Y0 = Math.Max(cy, dy);
            int X1 = Math.Min(cx + cw, dx + w);
            int Y1 = Math.Min(cy + ch, dy + h);
            if (X1 <= X0 || Y1 <= Y0) return;
            int[] sp = img.Pixels, dp = target.Pixels;
            int dstride = target.W;
            for (int yy = Y0; yy < Y1; yy++)
            {
                int srcy = vflip ? (sy + h - 1 - (yy - dy)) : (sy + (yy - dy));
                int srow = srcy * img.W;
                int drow = yy * dstride;
                for (int xx = X0; xx < X1; xx++)
                {
                    int srcx = hflip ? (sx + w - 1 - (xx - dx)) : (sx + (xx - dx));
                    int c = sp[srow + srcx];
                    if ((c & unchecked((int)0xFF000000)) != 0) dp[drow + xx] = c;
                }
            }
        }

        // MIDP drawRGB(int[] rgbData, int offset, int scanlength, int x, int y, int width, int height, boolean alpha)
        public void DrawRGB(int[] rgbData, int offset, int scanlength, int x, int y, int width, int height, bool alpha)
        {
            int X0 = Math.Max(cx, x + tx);
            int Y0 = Math.Max(cy, y + ty);
            int X1 = Math.Min(cx + cw, x + tx + width);
            int Y1 = Math.Min(cy + ch, y + ty + height);
            int[] dp = target.Pixels;
            int dstride = target.W;
            for (int yy = Y0; yy < Y1; yy++)
            {
                int srcRow = offset + (yy - (y + ty)) * scanlength;
                int drow = yy * dstride;
                for (int xx = X0; xx < X1; xx++)
                {
                    int c = rgbData[srcRow + (xx - (x + tx))];
                    if (!alpha) c |= unchecked((int)0xFF000000);
                    else if ((c & unchecked((int)0xFF000000)) == 0) continue;
                    dp[drow + xx] = c;
                }
            }
        }

        // Only used by the exception fallback path + a few c.java dialogs:
        public void DrawString(string str, int x, int y, int anchor)
        {
            SimpleFont.Draw(this, str, x, y, anchor, color);
        }
    }
}
