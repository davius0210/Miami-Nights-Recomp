# MiamiNight — rebuild/ (MonoGame, .NET 8)

Playable reconstruction of the J2ME game
`Miami Nights - Singles in The City` (Samsung S8000 480x800).
This folder alone is all you need to build and run.

## Requirements

- .NET 8 SDK
- Your own original `.jar` (not included in the repo)

## Run

```sh
cd rebuild
# place your .jar in this folder, then extract resources into res/:
#   res/0..21, res/dataIGP, res/icon.png, res/META-INF/...
dotnet build
dotnet run
```

`res/` is loaded by path, exactly like `getResourceAsStream` did
(`Midp.ResPath`). Do not commit `res/`, `*.jar`, `shot_f12.png`,
or `crash.log`.

## Controls

Arrows/WASD = d-pad, Enter/Space/Z = fire, 0-9 = digits,
Esc/Backspace = softkeys, mouse click = pointer,
F10 = widescreen, F11 = fullscreen, F12 = dump `shot_f12.png`,
`#` = stats panel toggle.

Env: `MN_AUTO=1` autoplay harness, `MN_AI_LOG=1` NPC AI log,
`MN_EXPORT_MAPS=1` export `res/maps/lvl_*.svg`,
`MN_NO_SVGMAP=1` ignore collision SVGs.

## Folder contents

```
Program.cs, Game1.cs   # MIDlet lifecycle + 66 ms fixed-step driver
GloftMMN.cs            # resource container, string table, audio channels
a.cs                   # sprite + bitmap-font engine
b.cs d.cs e.cs         # small classes, flags, drawable wrapper
c.cs                   # IGP/RMS/dialogs/network
f.cs                   # world/levels, tilemap, collision grid (k/t/u)
g.cs                   # NPC/relationship simulation
h.cs                   # Canvas + state machine (~10k lines)
NpcAi.cs               # needs-driven NPC AI (optional, off original path)
StatsPanel.cs          # Sims-style player stats panel
Engine/                # Midp, Display, Rms, Audio, Collision, SvgMap,
                       # JavaRandom, Shims, Helpers, SimpleFont
res/                   # LOCAL, extracted from YOUR jar (git-ignored)
art/                   # SVG sources (menu, bedroom)
tools/                 # extract_res.py, fixers, midi_probe.py, ...
```

Line-by-line port of the validated decompiles (`namespace MiamiNights`,
`sbyte` everywhere, `m_`/`_` naming rules — see `PORTING.md`).

## Limitations

- MIDI timbre is a soft-synth approximation (structure/tempo/loops kept).
- System font fallback is font8x8 (game text uses its own archives).
- `vibrate()` is a no-op, locale defaults to English.
- Occasional silent exit after minutes of play (no managed stack;
  see `STATUS.md` "Open issue"; `crash.log` sink plus
  `[QUIT-SITE-*]`/`[DRIVER]` markers are in place).
