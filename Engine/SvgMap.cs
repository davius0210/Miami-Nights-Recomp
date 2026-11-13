// SVG as the editable source of truth for a level's walk/collision grid.
//   res/maps/lvl_<id>.svg : viewBox "0 0 t u" (1 unit = 1 tile). One <g data-value="N"> per distinct cell value,
//   containing <rect> runs. Cells not covered by any rect are 0 (free).
//   MN_EXPORT_MAPS=1 -> write the SVG for every level that loads (if missing). An existing SVG overrides the grid.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace MiamiNights
{
    internal static class SvgMap
    {
        private static readonly bool Export = Environment.GetEnvironmentVariable("MN_EXPORT_MAPS") == "1";
        private static readonly bool Disabled = Environment.GetEnvironmentVariable("MN_NO_SVGMAP") == "1";

        internal static string MapDir(bool forWrite)
        {
            if (forWrite)
            {
                // prefer the source tree (walk up to the csproj) so the exported SVGs can be committed/edited
                var d = new DirectoryInfo(AppContext.BaseDirectory);
                while (d != null && !File.Exists(Path.Combine(d.FullName, "MiamiNight.csproj"))) d = d.Parent;
                if (d != null) return Path.Combine(d.FullName, "res", "maps");
            }
            return Path.Combine(AppContext.BaseDirectory, "res", "maps");
        }

        private static string FileFor(int level, bool forWrite) { return Path.Combine(MapDir(forWrite), "lvl_" + level + ".svg"); }

        private static string ColorFor(int v)
        {
            if (v == 1) return "#e0405a";
            if (v == 3) return "#40a0e0";
            if (v == 16384) return "#e0c040";
            if (v == -32768) return "#a060e0";
            int h = (v * 40503) & 0xFFFFFF;
            return "#" + (0x404040 | h).ToString("x6");
        }

        // Called right after the base walk grid is built (before objects add their flags).
        public static void Apply(int level, short[] k, int t, int u)
        {
            if (Disabled || k == null) return;
            try
            {
                string read = FileFor(level, false);
                if (!File.Exists(read)) read = FileFor(level, true);
                if (File.Exists(read))
                {
                    if (Load(read, k, t, u)) return;
                }
                if (Export) Save(FileFor(level, true), level, k, t, u);
            }
            catch (Exception e) { Console.WriteLine("[svgmap] level " + level + ": " + e.Message); }
        }

        private static void Save(string path, int level, short[] k, int t, int u)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            var groups = new SortedDictionary<int, StringBuilder>();
            for (int y = 0; y < u; y++)
            {
                int x = 0;
                while (x < t)
                {
                    int v = k[x + y * t];
                    if (v == 0) { x++; continue; }
                    int e = x;
                    while (e < t && k[e + y * t] == v) e++;
                    StringBuilder sb;
                    if (!groups.TryGetValue(v, out sb)) groups[v] = sb = new StringBuilder();
                    sb.Append("<rect x=\"").Append(x).Append("\" y=\"").Append(y).Append("\" width=\"").Append(e - x).Append("\" height=\"1\"/>\n");
                    x = e;
                }
            }
            var o = new StringBuilder();
            o.Append("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 ").Append(t).Append(' ').Append(u)
             .Append("\" width=\"").Append(t * 16).Append("\" height=\"").Append(u * 16)
             .Append("\" data-level=\"").Append(level).Append("\" data-tiles-w=\"").Append(t).Append("\" data-tiles-h=\"").Append(u)
             .Append("\" shape-rendering=\"crispEdges\">\n");
            o.Append("<!-- collision grid: each <g data-value> = cell value (1 blocked, 3 door/special, 16384/-32768 flags). Edit rects to change collision. -->\n");
            foreach (var kv in groups)
                o.Append("<g id=\"v").Append(kv.Key < 0 ? "n" + (-kv.Key) : kv.Key.ToString()).Append("\" data-value=\"").Append(kv.Key)
                 .Append("\" fill=\"").Append(ColorFor(kv.Key)).Append("\" fill-opacity=\"0.6\">\n").Append(kv.Value).Append("</g>\n");
            o.Append("</svg>\n");
            File.WriteAllText(path, o.ToString(), new UTF8Encoding(false));
            Console.WriteLine("[svgmap] exported " + path + " (" + t + "x" + u + ")");
        }

        private static bool Load(string path, short[] k, int t, int u)
        {
            var doc = XDocument.Load(path);
            var root = doc.Root;
            int w = int.Parse((string)root.Attribute("data-tiles-w") ?? "-1", CultureInfo.InvariantCulture);
            int h = int.Parse((string)root.Attribute("data-tiles-h") ?? "-1", CultureInfo.InvariantCulture);
            if (w != t || h != u) { Console.WriteLine("[svgmap] size mismatch in " + path + " (" + w + "x" + h + " vs " + t + "x" + u + ")"); return false; }
            var tmp = new short[k.Length];
            foreach (var g in root.Descendants())
            {
                if (g.Name.LocalName != "g") continue;
                var dv = g.Attribute("data-value");
                if (dv == null) continue;
                short v = short.Parse(dv.Value, CultureInfo.InvariantCulture);
                foreach (var r in g.Elements())
                {
                    if (r.Name.LocalName != "rect") continue;
                    int rx = (int)Math.Round(double.Parse((string)r.Attribute("x") ?? "0", CultureInfo.InvariantCulture));
                    int ry = (int)Math.Round(double.Parse((string)r.Attribute("y") ?? "0", CultureInfo.InvariantCulture));
                    int rw = (int)Math.Round(double.Parse((string)r.Attribute("width") ?? "1", CultureInfo.InvariantCulture));
                    int rh = (int)Math.Round(double.Parse((string)r.Attribute("height") ?? "1", CultureInfo.InvariantCulture));
                    for (int yy = Math.Max(0, ry); yy < Math.Min(u, ry + rh); yy++)
                        for (int xx = Math.Max(0, rx); xx < Math.Min(t, rx + rw); xx++)
                            tmp[xx + yy * t] = v;
                }
            }
            Array.Copy(tmp, k, k.Length);
            return true;
        }
    }
}
