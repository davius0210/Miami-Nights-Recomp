# MiamiNights — MonoGame Reconstruction Status

## Pipeline completed
1. **Recon** — `RECON.md` (engine/assets/containers/formats, REA evidence `ev_b30122...`).
2. **Decompile** — CFR 0.152 + Vineflower 1.11.1; VF chosen as base; validated to
   **0 javac errors** (`tools/fix_decompile.py` loop: 1992 → 0: `MiamiNights.` package
   qualification for obfuscation shadowing, 51 manual type fixes cross-referenced to CFR
   + bytecode field types, `package MiamiNights;`).
3. **Rebuild (C# / MonoGame DesktopGL, net8.0)** — `rebuild/`:
   - Engine: `Engine/Midp.cs` (Graphics/Image/Font, CPU int[] ARGB, MIDP clip/anchor/TRANS
     semantics), `Display.cs` (MIDlet/Canvas/Displayable), `Rms.cs` (RecordStore→file),
     `Audio.cs` (MMAPI surface + WAV + built-in SMF MIDI synth), `SimpleFont.cs` (font8x8),
     `JavaRandom.java→JavaRandom.cs` (exact java.util.Random LCG), `Shims.cs` (Vector/Hashtable/
     Command/CommandListener/Runnable/ConnectionNotFound), `Helpers.cs` (sbyte↔byte, ISO-8859-1,
     JavaSplit, MiaNow.Ms).
   - Driver: `Game1.cs` — 480x800 window = original device space; 66 ms fixed step (original
     run() pacing); paint→e() logic+render→audio pump; 1500 ms hide/show watchdog; input pump
     feeding original keyPressed/pointer pipeline (MIDP keycode table exact); quit via `h_ < 0`.
   - Ports (1:1 from validated VF, `namespace MiamiNights`):
     `GloftMMN.cs` (resources/strings/audio channels), `a.cs` (sprite+bitmap-font engine),
     `b.cs d.cs e.cs` (hand), `c.cs` (IGP/RMS/dialogs/net), `f.cs` (world/levels),
     `g.cs` (simulation), `h.cs` (Canvas/state machine, 10.1k lines).
   - Naming contract: `PORTING.md` (R1 m_ for field/method collisions, R2 keep quals,
     R5 underscore for member==class name, sbyte everywhere, substring end-begin, etc).
4. **Build: SUCCESS** (0 errors after: keyword `as` escapes, static-ctor modifier strip,
   internal backfill for Java package-private methods (42 in g), overload-ambiguity casts
   per Java invocation rules, `goto label745`, jagged arrays, Stream.Skip→Seek, sbyte
   Image.CreateImage overloads).

## Assets
- Original JAR resources extracted byte-identical → `rebuild/res/` (0..21 containers,
  dataIGP, icon.png, META-INF manifest); loaded by path like `getResourceAsStream` did.
- Container format decoder: `tools/extract_res.py` (verified PNG/MIDI magics inside).

## Runtime
- **Verified running end-to-end** (three screenshots + full play log):
  1. `shot.png` — main menu: logo art, original bitmap-font buttons (NEW GAME / OPTIONS /
     INSTRUCTIONS / ABOUT), selection cursor.
  2. `rebuild/bin/.../shot_f12.png` (auto frame-150 backbuffer dump) — **in-game level**:
     sunset sky + skyline + palms (BG sets), perspective floor (map layers), NPC sprites
     with palettes (archive decode), placed props (object placement table).
  3. Log: boot → GAME_INIT + full SCRIPTING (attributes/NPC actions/templates/occupations/
     conditions/reactions) → LEVELS_INIT → LLOAD 0..22 → level-reload cycles, with the
     original's own console prints intact; **0 MIDI failures** (all 21 songs parse+play).
- Runtime fixes found via play log (all CFR cross-verified):
  1. `GloftMMN.m_c` passed sound-id as channel → `m_c(n) = m_a(n,1)` (original `c(n)=a(n,1)`).
  2. VF `byte var4` stride-11 counter over 72 records (CFR: `int`) → OOR every frame → int.
     Systematic sweep (`tools/vf_type_diff.py`) fixed **14** such silent mis-inferences +
     **6** `for(sbyte …)` loop counters (VF defect class: type-wrong-but-javac-valid).
  3. MIDI synth: (a) status byte double-consume, (b) **running-status** events (`b0<0x80`
     IS d1 — was reading 2 more bytes) → now **21/21 MIDIs parse** (`tools/midi_probe.py`
     byte-faithful replica proves it).
  4. `OnActivated` before `LoadContent` NRE → null guards.
  5. F12 = backbuffer dump hook (`shot_f12.png`) for occlusion-proof verification.
- Residual logged-but-recovered (original catch paths): one-shot `h.m_c(int,int)` OOR
  during scene setup (caught by original `b(g)` handler; game continues).

## Open issue (honest status)
- **Intermittent silent process exit** after ~60–120 s of play (3 observed runs; other runs
  played 3+ min through multiple level cycles with movement ticks). Characteristics:
  no managed stack, `crash.log` (AppDomain handler) empty, no WER/Application-log entry,
  exit code 1, occurs right after the original `TTTT…` debug print during world draw
  (`v[6].m_a(aB)` — CPU blit, acyclic) or shortly after level-music player churn.
- Instrumentation IN PLACE for next session: `[QUIT-SITE-1/2]` + `[DRIVER]` markers (ruled
  out: game-quit paths — none fired), `crash.log` unhandled-exception sink, per-frame
  `shot_f12.png` dump, byte-faithful `tools/midi_probe.py`.
- Ranked hypotheses: MonoGame/OpenAL native race (SoundEffect create/dispose churn at level
  transitions vs. ported every-frame `GC.Collect()` finalizer pressure — known MonoGame
  pattern), stack-overflow in an untraced path, GC/finalizer timing. Managed code paths are
  javac-validated + compile-clean + log-consistent up to the exit point.

## Known limitations / accepted deviations
- MIDI timbre approximated by built-in synth (structure/tempo/loops preserved; phone
  MMAPI synth unavailable). `Player.Stop` loses position (no position API in MonoGame).
- System `Font` fallback = font8x8 (game text uses its own archives — unaffected).
- `microedition.locale` → manifest lookup (absent → English path, same as default).
- roundRect helper approximated (2 sites in h); vibrate() no-op (device API).
- Software quadrant 2x upscale in original paint() kept semantically (game renders to
  240x400 offscreen then presents 480x800 point-scaled — pixel-identical output).
- Invariant globalization: toUpperCase → invariant (phone locale deviates for non-EN).

## Added features (NPC AI + Sims-style stats UI)
- **`rebuild/NpcAi.cs`** — needs-driven NPC AI layer (new file; original code touched only
  at two hooks):
  - per-NPC needs decay on the game clock (hygiene↓ hunger↑ fatigue↑ bathroom↑ social↑,
    direct clamped writes — no player-side reaction side effects);
  - utility decisions every 2-5 s: dirty→shower/sink/towel/jacuzzi, hungry→fridge/food,
    tired→bed/couch, bladder→toilet, lonely→seek nearest character (incl. player),
    else random wander;
  - locomotion reuses `g.m_a(int[])` with the exact save/restore + tile-occupancy dance
    from `g.m_o()`; object targets resolved through the `f.m_l()` I-table name walk;
  - **yields to the original reaction system**: pauses the plan while `b[3]/A/b[12]/b[19]`
    are set and resumes when clear (30 s pause-timeout drops the plan); full state reset
    on zone reload (`f.e` identity change) / new game;
  - hooks: `h.cs` world tick (`NpcAi.Tick()` right before `f.m_n()`), and `f.cs` `m_n()`
    skips `g.m_o()` for NPCs the AI drives that frame (`NpcAi.Owned`).
  - verified in-game (`MN_AUTO=1 MN_AI_LOG=1`): decisions logged, 72 movement steps,
    driving/move counters, pause↔resume around reactions, zone reset, active-NPC counts.
- **`rebuild/StatsPanel.cs`** — Sims-style stats panel for the main player (drawn at the
  end of the `h_==8` frame, full-canvas clip): HYGIENE / HUNGER / ENERGY / BATHROOM /
  SOCIAL / CULTURE / HEALTH / CHARISMA / FITNESS as label + value% + bar; bar colored
  green≥60 / orange≥30 / red<30 (goodness direction per stat), title = player name.
  Toggle: `#`/`?` key (`aC[12]`, free MIDP slot) — default ON, shown while playing only
  (`y==0 && z<0`).
- **`Engine/SimpleFont.cs` fix** — pre-existing crash: glyph data holds 112 rows starting
  at ASCII 16, but Build() iterated 128 → `ArgumentOutOfRangeException` on first
  `Graphics.DrawString` call (masked: DrawString had no real callers). Now index-mapped
  (row i → ASCII i+16) with a missing-glyph guard.
- Test harness (only with `MN_AUTO=1`, never active in normal play): character-creation
  bypass via the game's own start sequence, sign-only fire during free play, walk/stand
  exploration, level-select driver (y=30 map → y=31 list → first unlocked `g.ah`
  destination → travel). `MN_AI_LOG=1` enables the [AI] decision/step log.
