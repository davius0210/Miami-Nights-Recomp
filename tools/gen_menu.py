# Generates art/menu.svg (320x180 pixel-art launcher screen) and renders res/wide/menu.png.
# usage: python -I gen_menu.py   (run from anywhere)
import os, io, sys
import resvg_py
from PIL import Image

here = os.path.dirname(os.path.abspath(__file__))
OUT_SVG = os.path.join(here, "..", "art", "menu.svg")
OUT_PNG = os.path.join(here, "..", "res", "wide", "menu.png")

G = {
 "A": ["01110","10001","10001","11111","10001","10001","10001"],
 "C": ["01110","10001","10000","10000","10000","10001","01110"],
 "D": ["11110","10001","10001","10001","10001","10001","11110"],
 "E": ["11111","10000","10000","11110","10000","10000","11111"],
 "F": ["11111","10000","10000","11110","10000","10000","10000"],
 "G": ["01110","10001","10000","10111","10001","10001","01111"],
 "H": ["10001","10001","10001","11111","10001","10001","10001"],
 "I": ["01110","00100","00100","00100","00100","00100","01110"],
 "L": ["10000","10000","10000","10000","10000","10000","11111"],
 "M": ["10001","11011","10101","10101","10001","10001","10001"],
 "N": ["10001","11001","10101","10011","10001","10001","10001"],
 "Q": ["01110","10001","10001","10001","10101","10010","01101"],
 "R": ["11110","10001","10001","11110","10100","10010","10001"],
 "S": ["01111","10000","10000","01110","00001","00001","11110"],
 "T": ["11111","00100","00100","00100","00100","00100","00100"],
 "U": ["10001","10001","10001","10001","10001","10001","01110"],
 "W": ["10001","10001","10001","10101","10101","11011","10001"],
 "Y": ["10001","10001","01010","00100","00100","00100","00100"],
 " ": ["00000"] * 7,
}


def text(s, cx, y, scale, fill, shadow=None):
    w = len(s) * 6 * scale - scale
    x0 = cx - w // 2
    out = []
    for pass_fill, dx, dy in ([(shadow, scale, scale)] if shadow else []) + [(fill, 0, 0)]:
        for i, ch in enumerate(s):
            g = G[ch]
            for r, row in enumerate(g):
                c = 0
                while c < 5:
                    if row[c] == "1":
                        e = c
                        while e < 5 and row[e] == "1":
                            e += 1
                        out.append('<rect x="%d" y="%d" width="%d" height="%d" fill="%s"/>' % (
                            x0 + i * 6 * scale + c * scale + dx, y + r * scale + dy, (e - c) * scale, scale, pass_fill))
                        c = e
                    else:
                        c += 1
    return "".join(out)


W, H = 320, 180
S = []
# sky: banded gradient
bands = ["#1a0b3b", "#25104f", "#321564", "#451a76", "#5c1f84", "#7a2490", "#a02a94", "#c83392", "#e8478a", "#f8647a", "#ff8a6a", "#ffb070", "#ffd080"]
sky_h = 112
bh = sky_h / len(bands)
for i, c in enumerate(bands):
    S.append('<rect x="0" y="%d" width="%d" height="%d" fill="%s"/>' % (int(i * bh), W, int(bh) + 2, c))
# stars
import random
rnd = random.Random(7)
for _ in range(40):
    x, y = rnd.randrange(0, W), rnd.randrange(0, 60)
    S.append('<rect x="%d" y="%d" width="1" height="1" fill="#ffe8ff"/>' % (x, y))
# sun with stripes
cx, cy, r = 160, 98, 34
S.append('<defs><clipPath id="sun"><circle cx="%d" cy="%d" r="%d"/></clipPath></defs>' % (cx, cy, r))
S.append('<g clip-path="url(#sun)"><rect x="%d" y="%d" width="%d" height="%d" fill="#ffd45c"/>' % (cx - r, cy - r, 2 * r, 2 * r))
S.append('<rect x="%d" y="%d" width="%d" height="%d" fill="#ff9a5a"/>' % (cx - r, cy - 8, 2 * r, 2 * r))
S.append('<rect x="%d" y="%d" width="%d" height="%d" fill="#f0507a"/>' % (cx - r, cy + 14, 2 * r, 2 * r))
for i, hh in enumerate((2, 3, 4, 5)):
    S.append('<rect x="%d" y="%d" width="%d" height="%d" fill="%s"/>' % (cx - r, cy + 6 + i * 8, 2 * r, hh, "#5c1f84"))
S.append("</g>")
# skyline silhouette
sx = 0
heights = [18, 26, 14, 34, 22, 40, 16, 28, 20, 36, 24, 14, 30, 18, 44, 22, 28, 16, 34, 20]
for h in heights:
    w = 16
    S.append('<rect x="%d" y="%d" width="%d" height="%d" fill="#2a0f4a"/>' % (sx, sky_h - h, w, h + 2))
    for wy in range(sky_h - h + 4, sky_h - 2, 6):
        if rnd.random() > 0.45:
            S.append('<rect x="%d" y="%d" width="2" height="2" fill="#ffd080"/>' % (sx + 3 + rnd.randrange(0, 3) * 4, wy))
    sx += w
# ground: neon grid
S.append('<rect x="0" y="%d" width="%d" height="%d" fill="#1b0a36"/>' % (sky_h, W, H - sky_h))
S.append('<rect x="0" y="%d" width="%d" height="1" fill="#ff5fa8"/>' % (sky_h, W))
for i in range(1, 9):
    y = sky_h + int(i * i * 0.95)
    S.append('<rect x="0" y="%d" width="%d" height="1" fill="#7a2490"/>' % (y, W))
for i in range(-10, 11):
    x1 = 160 + i * 6
    x2 = 160 + i * 30
    S.append('<line x1="%d" y1="%d" x2="%d" y2="%d" stroke="#5c1f84" stroke-width="1"/>' % (x1, sky_h, x2, H))


def palm(px, py, flip):
    d = -1 if flip else 1
    o = ['<rect x="%d" y="%d" width="4" height="%d" fill="#12062a"/>' % (px - 2, py, H - py)]
    for dx, dy in ((-26, 6), (-22, -10), (-8, -20), (8, -20), (22, -10), (26, 6), (-14, 16), (14, 16)):
        o.append('<path d="M%d %d L%d %d L%d %d Z" fill="#12062a"/>' % (px, py, px + dx * d, py + dy, px + dx * d // 2 + 4, py + dy // 2 + 8))
    return "".join(o)


S.append(palm(34, 70, False))
S.append(palm(290, 62, True))
S.append(palm(54, 96, True))
BACKDROP_LEN = len(S)
# title
S.append(text("MIAMI NIGHTS", 160, 12, 4, "#ffffff", "#e8478a"))
S.append(text("SINGLES IN THE CITY", 160, 48, 2, "#ffd080", "#5c1f84"))
# buttons (kept in sync with Game1.cs LauncherItems)
BTN = [("START", 84), ("FULLSCREEN", 106), ("WIDE SCREEN", 128), ("QUIT", 150)]
for label, y in BTN:
    S.append('<rect x="90" y="%d" width="140" height="18" fill="#12062a"/><rect x="91" y="%d" width="138" height="16" fill="#2a0f4a"/>' % (y, y + 1))
    S.append('<rect x="91" y="%d" width="138" height="2" fill="#451a76"/>' % (y + 1))
    S.append(text(label, 160, y + 2, 2, "#ffffff"))
svg = '<svg xmlns="http://www.w3.org/2000/svg" width="%d" height="%d" viewBox="0 0 %d %d" shape-rendering="crispEdges">%s</svg>' % (W, H, W, H, "\n".join(S))
os.makedirs(os.path.dirname(OUT_SVG), exist_ok=True)
open(OUT_SVG, "w", encoding="utf-8").write(svg)
png = bytes(resvg_py.svg_to_bytes(svg_path=OUT_SVG))
Image.open(io.BytesIO(png)).convert("RGB").save(OUT_PNG)
print("ok", OUT_PNG, len(svg))
# plain backdrop (no title/buttons) for chat/loading screens in widescreen
bsvg = '<svg xmlns="http://www.w3.org/2000/svg" width="%d" height="%d" viewBox="0 0 %d %d" shape-rendering="crispEdges">%s</svg>' % (W, H, W, H, "".join(S[:BACKDROP_LEN]))
open(os.path.join(here, "..", "art", "backdrop.svg"), "w", encoding="utf-8").write(bsvg)
Image.open(io.BytesIO(bytes(resvg_py.svg_to_bytes(svg_string=bsvg)))).convert("RGB").save(os.path.join(here, "..", "res", "wide", "backdrop.png"))
print("ok backdrop")
