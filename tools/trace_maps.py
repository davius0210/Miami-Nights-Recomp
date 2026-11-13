# Vectorise exported level backgrounds with vtracer, and turn edited SVGs back into runtime PNGs.
#
#   python -I tools/trace_maps.py trace [lvl ...]   res/maps/lvl_<id>_bg.png  -> art/maps/lvl_<id>_bg.svg
#   python -I tools/trace_maps.py apply [lvl ...]   art/maps/lvl_<id>_bg.svg  -> res/maps/lvl_<id>_bg_edit.png
#
# The PNG is exported by the game (MN_EXPORT_MAPS=1) at world origin (-48,-240); the SVG keeps the same
# size/viewBox so anything you draw in it (wider walls, new furniture, extra rooms) lines up with the game.
# At runtime, res/maps/lvl_<id>_bg_edit.png (if present and the same size) replaces the live-rendered background
# outside the camera window, which is what fills the widescreen sides.
import sys, os, glob, io, re
from PIL import Image

ROOT = os.path.abspath(os.path.join(os.path.dirname(os.path.abspath(__file__)), ".."))
RES = os.path.join(ROOT, "res", "maps")
ART = os.path.join(ROOT, "art", "maps")


def levels(args, pattern):
    if args:
        return args
    return sorted(re.match(r"lvl_(-?\d+)_", os.path.basename(p)).group(1) for p in glob.glob(pattern))


def trace(ids):
    import vtracer
    os.makedirs(ART, exist_ok=True)
    for i in ids:
        src = os.path.join(RES, "lvl_%s_bg.png" % i)
        dst = os.path.join(ART, "lvl_%s_bg.svg" % i)
        # mode "none" keeps hard pixel edges (pixel-art); no speckle filtering so 1px details survive.
        # NOTE: the vtracer Python binding segfaults when called with keyword args -> pass ALL args positionally:
        # (in, out, colormode, hierarchical, mode, filter_speckle, color_precision, layer_difference,
        #  corner_threshold, length_threshold, max_iterations, splice_threshold, path_precision)
        tmp = dst + ".rgba.png"
        Image.open(src).convert("RGBA").save(tmp)
        vtracer.convert_image_to_svg_py(tmp, dst, "color", "stacked", "none", 0, 8, 1, 60, 4.0, 10, 45, 2)
        os.remove(tmp)
        w, h = Image.open(src).size
        svg = open(dst, encoding="utf-8").read()
        if "viewBox" not in svg:
            svg = svg.replace("<svg ", '<svg viewBox="0 0 %d %d" shape-rendering="crispEdges" ' % (w, h), 1)
        svg = svg.replace("<svg ", '<svg data-level="%s" data-origin-x="-48" data-origin-y="-240" ' % i, 1)
        open(dst, "w", encoding="utf-8").write(svg)
        print("traced", dst, "%dKB" % (len(svg) // 1024))


def apply(ids):
    import resvg_py
    for i in ids:
        src = os.path.join(ART, "lvl_%s_bg.svg" % i)
        ref = os.path.join(RES, "lvl_%s_bg.png" % i)
        dst = os.path.join(RES, "lvl_%s_bg_edit.png" % i)
        png = bytes(resvg_py.svg_to_bytes(svg_path=src))
        im = Image.open(io.BytesIO(png)).convert("RGB")
        if os.path.exists(ref):
            r = Image.open(ref).convert("RGB")
            if r.size != im.size:
                print("size mismatch for", src, im.size, "vs", r.size, "- skipped")
                continue
            a, b = r.tobytes(), im.tobytes()
            diff = sum(1 for k in range(0, len(a), 3) if a[k:k + 3] != b[k:k + 3])
            print("level %s: %d px differ from the game render (%.2f%%)" % (i, diff, 100.0 * diff / (len(a) // 3)))
        im.save(dst)
        print("applied", dst)


if __name__ == "__main__":
    cmd, rest = sys.argv[1], sys.argv[2:]
    if cmd == "trace":
        trace(levels(rest, os.path.join(RES, "lvl_*_bg.png")))
    elif cmd == "apply":
        apply(levels(rest, os.path.join(ART, "lvl_*_bg.svg")))
    else:
        print(__doc__ or "usage: trace|apply [lvl ...]")
