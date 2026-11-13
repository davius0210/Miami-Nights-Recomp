// Enhanced collision: axis-separated slide + corner nudge + radius inflation.
// Original: f.m_b(x,y) single-point sample, f.m_a(...) blocked test.
// Enhancement tidak mengubah nilai grid asli (k[] tetap source of truth dari SVG),
// hanya cara entity bergerak di atasnya: coba X lalu Y, slide, corner assist.
namespace MiamiNights
{
    internal static class Collision
    {
        // radius tambahan dalam tile (0 = perilaku asli, 0.3 = badan karakter).
        public static float Radius = 0.3f;
        public static bool CornerAssist = true;
        public static bool Slide = true;

        private static bool BlockedAt(float tx, float ty)
        {
            int x = (int)System.Math.Floor(tx);
            int y = (int)System.Math.Floor(ty);
            if (x < 0 || y < 0 || x >= f.t || y >= f.u) return true;
            short v = f.k[x + y * f.t];
            if ((v & 3) == 2) return true;   // solid (bit 1)
            if (v == 1) return true;          // wall
            return false;
        }

        private static bool BlockedCircle(float cx, float cy)
        {
            if (Radius <= 0f) return BlockedAt(cx, cy);
            // 4 sampel tepi + tengah
            if (BlockedAt(cx, cy)) return true;
            if (BlockedAt(cx + Radius, cy)) return true;
            if (BlockedAt(cx - Radius, cy)) return true;
            if (BlockedAt(cx, cy + Radius)) return true;
            if (BlockedAt(cx, cy - Radius)) return true;
            return false;
        }

        // Coba pindah dari (px,py) sejauh (dx,dy) dalam satuan tile.
        // Return posisi baru; slide jika satu sumbu tertahan.
        public static void TryMove(float px, float py, float dx, float dy, out float nx, out float ny)
        {
            nx = px; ny = py;
            if (dx != 0f && !BlockedCircle(px + dx, py))
                nx = px + dx;
            else if (dx != 0f && Slide)
            {
                // corner assist: geser sedikit di Y lalu coba X lagi
                if (CornerAssist && !BlockedCircle(px + dx, py + 0.4f) && !BlockedCircle(px, py + 0.4f))
                    ny = py + 0.4f;
                else if (CornerAssist && !BlockedCircle(px + dx, py - 0.4f) && !BlockedCircle(px, py - 0.4f))
                    ny = py - 0.4f;
            }
            if (dy != 0f && !BlockedCircle(nx, py + dy))
                ny = py + dy;
            else if (dy != 0f && Slide)
            {
                if (CornerAssist && !BlockedCircle(nx + 0.4f, py + dy) && !BlockedCircle(nx + 0.4f, py))
                    nx += 0.4f;
                else if (CornerAssist && !BlockedCircle(nx - 0.4f, py + dy) && !BlockedCircle(nx - 0.4f, py))
                    nx -= 0.4f;
            }
        }

        // Pintu / sel khusus (value 3): boleh lewat hanya jika flag allowDoor.
        public static bool IsDoor(int tx, int ty)
        {
            if (tx < 0 || ty < 0 || tx >= f.t || ty >= f.u) return false;
            return f.k[tx + ty * f.t] == 3;
        }
    }
}
