# Miami Nights - Singles in The City [480x800] (Samsung S8000) — Reconstruction Log

Target: `Miami Nights - Singles in The City [480x800] (Samsung S8000) (andrew-lviv.net).jar`
SHA-256: `a583024575b332976ed12f7685a8161305ee4065e1c68e861042eeafcea5eaad`
REA evidence: `ev_b30122fac3dc783d3117230146b69fcf3fa89a1a88415368832b5072d42fa809` (zip inventory, 36 entries, 0 integrity contradictions, coverage complete).

## 1. Engine / platform (observed)

| Fact | Evidence |
|---|---|
| J2ME MIDlet, not .NET / Godot / native | `META-INF/MANIFEST.MF`: `MicroEdition-Configuration: CLDC-1.0`, `MicroEdition-Profile: MIDP-2.0`, `MIDlet-1: MiamiNights, /icon.png, GloftMMN` |
| Pure Java bytecode, **zero native split** | class magic `CA FE BA BE 00 03 00 2D` = class version 45 (CLDC); no `.so`/`.dll`/`.sis` in archive |
| Vendor | `MIDlet-Vendor: [ANDREW-LVIV] / Gameloft SA`, `MIDlet-Version: 1.0.5`, built by `1.4.2_10` |
| Entry point | `GloftMMN extends MIDlet` → spawns `h` (`Canvas` + `Runnable`) on a Thread |
| Target device art | 480x800 in filename, but code hardcodes **240x400 logical canvas** (half-res QVGA-class rendering, scaled by handset) |

Decompilation tooling decision: .NET (ILSpy) and Godot (gdsdecomp) do **not** apply — no CIL, no Godot scenes.
Correct tool = Java decompiler for legacy bytecode: **CFR 0.152** (`cfr-0.152.jar`), ran against the JAR.

## 2. Code map (9 classes, obfuscated single-letter names)

| Class | Size | Role (observed) |
|---|---|---|
| `GloftMMN` | 8.9K | MIDlet + **resource container reader** (`b/h/i/j/k`) + **MMAPI audio manager** (Player[], 1 channel, wav/midi) |
| `h` | 118K | `Canvas`+`Runnable`: main loop, input, UI state machine, RMS save/load, HUD, screen flow |
| `g` | 48K | Gameplay simulation: NPCs, relationships (`love`/`friendship` stats), AI, story |
| `f` | 67K | World/level data: tile layers, object placement, camera, rendering of scene |
| `c` | 30K | `dataIGP` parser, dialogs/menus, network (`ConnectionNotFoundException`), RMS, system-Font text |
| `a` | 11.7K | **Sprite + bitmap-font engine** (frame/compose/animation tables, 7 pixel encodings) |
| `d` | 1.9K | Graphics helper (cached drawable objects, `c(int)` accessors) |
| `e` | 1.1K | Feature flags/constants (`e.h` = pooled-image mode) |
| `b` | 184B | Tiny marker class |

## 3. Resource container format (files `0`..`21` in JAR) — DECODED

Read path: `GloftMMN.b(String)` → `GloftMMN.h(int)` → `GloftMMN.j(int)`.

```
offset 0 : u32 LE  count
offset 4 : u32 LE  offsets[count]      (B[0] implied 0, B[i] = value at 4+4*(i-1))
base     = 4 + 4*count                 (variable C in code)
record n = [base+B[n] .. base+B[n+1])
   byte 0        = TYPE  (GloftMMN.j → k[type]: 0="?", 1="audio/x-wav", 2="audio/midi")
   bytes 1..     = payload, length = B[n+1]-B[n]-1
```
Extractor: `tools/extract_res.py` → `assets/res<N>/`.

Inventory (payload magics, verified):
- `/0` 2×PNG splash/loading art (19791 B + 37373 B); `/1` sprite+PNG; `/2` font-ish blob + 43 B.
- `/3` **localized strings table**: u32 LE offset header + ISO-8859-1 blob; loaded by `GloftMMN.a("/3", lang)`; read via `GloftMMN.k(id)`. `'|'` → `\n` for one language, `@` prefix = fallback marker.
- `/8` level tile layers (4-bit packed tiles, `f.case 6/11`); `/13` 40 object-placement records (u16 runs).
- `/14`..`/17` 24 records each = per-object **sprite archives** (see §4).
- `/18` 6×MIDI (type=2 ✓), `/19` 21× mix of MIDI + 4-byte `61 20 0d 0a` placeholders (type=0).
- `/5` `/6` `/10` `/11` `/12` `/21` and records in `/1` `/2` `/4` = `df 03 ...` **sprite/font archives** (§4).
- `/20` small binary tables; `/21` 1-record font used only when `h.h==21` (`%` → MIDlet-Version).
- Loose files: `icon.png` (MIDlet-Icon), `sfx_shower.wav` (stray, not referenced by code), `dataIGP` (§5).

## 4. Sprite/font archive format — DECODED from `a.a(byte[],int,int,boolean)`

Payload layout (little-endian):
```
byte  0        : ignored by parser (0xDF marker)
u32   [1..4]   : flags (0x4000 = 't' → 5-byte composition entries)
u16   a        : frame count
a × (i8 width, i8 height)         ; width<0 → 6-byte placeholder rect (s[])
u16   g_count  : composition groups   (entry size t?5:4 bytes)
u16   d_count  : action groups  → per group: i8 count, u8 + u16 index, then 4-byte f-table
u16   anim_cnt : animation table, 5 bytes each (j[])
u16   h_count  : action sets    → i8 count, u8 + u16 index (i[])
i8 s16 pixfmt-marker (n7)         ; palette encoding:
      -30584 (0x8888): 4 B/entry (ARGB)   17476 (0x4444): u16 RGB555
       21781 (0x5555): u16 RGB555 → ARGB expand
u8   palette count (l), u8 palette size (0→256)
s16  pixel-encoding marker (this.n):
      25840 masked-RLE | 10225 RLE run | 22258 RLE lit | 5632 = 4bpp
      1024 = 2bpp | 512 = 1bpp | 22018 = raw 8bpp
per frame: u16 len → pixel blob (q[]/r[] offsets)
```
Render: `Image.createRGBImage` per frame (`a.a(int,int,int,int,int)`), transforms via flip bits (0=none,1=hflip,2=vflip,3=both), text via glyph map `A[256]` + advance table `g[]`.

## 5. `dataIGP` format — DECODED from `c.b()/c.b(int)`

```
u16 LE count
count × u32 LE payload offsets
blob[n] = bytes at (2 + 4*count + off[n]) .. next off
```
12 entries; consumed by `c.java` (images → `Image.createImage`, tables, strings). "IGP" = Gameloft in-game-purchase/promo container, here holding build-specific config art.

## 6. Audio

- One MMAPI `Player` channel (`GloftMMN.s[1]`), mime by record TYPE byte: `{"?","audio/x-wav","audio/midi"}`.
- Load queue (`p[]`/`q[]`), deferred commands `t[]` (create/start/stop/pause/resume) pumped from game loop `GloftMMN.d()`.
- MIDI assets: `/18` (6), `/19` (16 usable, 5 placeholder records).

## 7. Rebuild strategy

1. Decompile: CFR 0.152 → `decompile/*.java` (done, 9 files, ~766 KB).
2. Compile against real MIDP/CLDC API (MicroEmulator `microemu-cldc`/`microemu-midp`) → Java-SE-verifiable behavior.
3. Package `rebuild/game.jar`: original manifest + all original resources + recompiled classes.
4. Runtime smoke test: MicroEmulator launcher (same JVM, MIDP API in-process).
5. Optional authenticity pass: re-verify class version 45 + preverify for real CLDC devices (tooling not present on this host — recorded as limitation).

## Open items / limitations
- `h.h` state machine semantics (screen flow) documented from code, not executed on device.
- Whether `/19` 4-byte placeholders are intentional stubs (crack leftover) vs original: unknown.
- Original Samsung S8000 scaling behavior (240x400 → 480x800) is device firmware, not in JAR: unknown.
