# Java → C# MonoGame Port Rules — MiamiNights reconstruction

**Source of truth**: `decompile_vf/*.java` — VALIDATED (javac-clean, `package MiamiNights;`, all
shadowing qualified as `MiamiNights.X.Y`). Translate these, not the CFR originals.

**Target**: `rebuild/*.cs`, `namespace MiamiNights`, one .cs per .java (same class names a,b,c,d,e,f,g,h,GloftMMN).

## 0. Ground rule

Line-by-line translation. No restructuring, no renames beyond rules below, no "improvements".
Every branch, constant, index, cast, comment-worthy quirk preserved. If unsure → keep Java form
and note `// PORT-QUESTION:` for integration pass.

## 1. Type mapping

| Java | C# |
|---|---|
| `byte` (SIGNED!) | **`sbyte`** — everywhere: fields, locals, arrays `byte[]`→`sbyte[]`, params |
| `(byte)expr` | `(sbyte)expr` (unchecked default → truncates like Java; for >127 literals `(sbyte)0xFF` style OK) |
| `x & 0xFF` on byte | works as-is: sbyte sign-extends then masks ✓ identical |
| `int/long/short/char/float/double` | same |
| `boolean` | `bool` |
| `Integer` boxing, `new Integer(x)` | plain `int` (Dictionary<int,int> etc. for tables) |
| `Hashtable` | `Dictionary<int,int>` or `Dictionary<object,object>` per usage |
| `Vector` | `List<T>`; `Stack`→`Stack<T>`; `StringBuffer`→`StringBuilder` |
| `java.util.Random` | `MiamiNights.JavaRandom` (same method names: nextInt() etc.) |
| `System.arraycopy` | `Array.Copy` (same arg order; component types match since both sides become sbyte[]) |
| `System.gc()` | `GC.Collect()` |
| `System.currentTimeMillis()` | `Environment.TickCount64`-style helper: `MiaNow.Ms()` (provide: `DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()`) |
| `System.out.println` | `Console.WriteLine` |
| `e.printStackTrace()` | `Console.WriteLine(e)` |

File IO boundaries: `File.ReadAllBytes`→`byte[]` → `GloftMMN.ToS(byte[])` (Buffer.BlockCopy) → `sbyte[]`; reverse via `ToB(sbyte[])`.

## 2. NAME RULES (the critical ones)

**R1 — method/field collision (CS0102):** if the class declares a FIELD named `N` and also a
METHOD named `N`, the C# method is named **`m_N`** (all overloads keep `m_`). Apply at
declarations AND call sites: `x.a(...)`→`x.m_a(...)`, `GloftMMN.h(3)`→`GloftMMN.m_h(3)`.

Per-class collision lists (from tools/collisions.py):

- a: a b c d
- c: a b c d e f g h i j k l m n
- d: a b c d e
- f: a b c d e f g h i j k l m n o p q r s
- g: a b c d e f h j k l m n o p q r s t
- GloftMMN: a b c d e f g h i j k l m n o p q r s t u v
- h: a b c d e g h i j k l m n o p q r
- e: (none — no methods), b: (none)

Constructors named like the class are LEGAL in C# even with same-named field → never rename ctors.

**R5 — member named as enclosing class (CS0542):** `class X { <type> X; }` is ILLEGAL in C#
(unlike Java). The FIELD gets **underscore suffix**: class `h`'s static int `h` → `h_`;
class `a`'s int `a` → `a_`; class `d`'s `a d` → `d_`; class `e`'s bool `e` → `e_`;
class `c`'s int `c` → `c_`; class `f`'s short `f` → `f_`; class `g`'s `g` → `g_` (if present).
Apply at decl AND every access: `x.h` → `x.h_` (same-class receiver), `MiamiNights.h.h` →
`MiamiNights.h.h_` (qualified), bare self-field `h` → `h_`. Receiver type is known from the Java
expression context — only rename when the receiver is THAT class. My already-written files
(a.cs/GloftMMN.cs/TEMP_STUBS) use this rule — match it.

Any CS0102 not in this table at build time: apply the same `m_` rule.

**R2 — qualified refs:** `MiamiNights.X.Y` in the Java source stays verbatim (already correct).
Never unqualify. `MiamiNights` = our namespace ✓.

**R3 — engine members are PascalCase:** see §4 table (Graphics `graphics.setColor` → `SetColor` etc).

**R4 — new driver members on `h`** (Game1 interop, not from Java): see §5.

## 3. Language gotchas

- **substring(begin, end)** → `Substring(begin, end - begin)` ⚠ ALWAYS. `substring(x)` → `Substring(x)`.
- `charAt(i)` → indexer `s[i]`; `length()`/`.length` → `.Length` property (methods → properties for arrays/strings).
- `String.compareTo(b)` → `string.CompareOrdinal(a,b)`; `==` on strings = value eq in both ✓.
- `toUpperCase()/toLowerCase()` → `ToUpperInvariant()/ToLowerInvariant()` (locale deviation accepted).
- `new String(bytes, off, len, "ISO-8859-1")` → `GloftMMN.Iso1(bytes, off, len)`.
- `s.getBytes("ISO-8859-1")` → `GloftMMN.IsoBytes(s)`.
- `s.split(regex)` → `MiaStr.JavaSplit(s, regex)` (Java drops trailing empty strings; helper provided).
- Java `>>` = C# `>>`; Java `>>>` = C# `>>>` (C#11 ✓).
- int/long overflow: wraparound (unchecked default ✓ keep csproj default).
- `/` and `%` truncate toward zero in both ✓.
- `switch` fall-through: VF emits `break;` normally; empty combined labels (`case 1: case 2:`) OK in C#.
  Real fall-through (statements after case, no break) → C# `goto case N;` — build catches.
- Labeled break: VF output has NONE. If encountered → restructure with flag/goto.
- `synchronized method` → plain method (single-threaded port; add comment `// was synchronized`).
- Static/instance field initializers map 1:1; Java static-init blocks → static constructor if ordering matters.
- `Math.abs/min/max/floor/ceil` ✓ same.
- Ternary, do-while, for-init multi-decl ✓ all valid C#.
- catch clause types ✓; `catch (Exception e)` ✓.
- `char` arithmetic promotes unsigned 16-bit ✓ identical.

## 4. Engine API map (javax.microedition.* → our engine types)

| Java | C# |
|---|---|
| `Graphics.setColor(int)` / `(r,g,b)` | `SetColor` (int overload has FF000000 OR-keeping as impl'd) |
| `fillRect/drawRect/fillTriangle/drawLine` | same names Pascal: `FillRect/DrawRect/FillTriangle/DrawLine` |
| `setClip/clipRect/translate` | `SetClip/ClipRect/Translate` |
| `getClipWidth/getClipHeight` | `GetClipWidth/GetClipHeight` |
| `drawImage(img,x,y,anchor)` | `DrawImage(img,x,y,anchor)` — anchor constants same (HCENTER=1,VCENTER=2,LEFT=4,RIGHT=8,TOP=16,BOTTOM=32) |
| `drawRegion(img,sx,sy,w,h,tr,dx,dy,anchor)` | `DrawRegion` (TRANS 0..3 same) |
| `drawRGB(int[],off,stride,x,y,w,h,alpha)` | `DrawRGB` |
| `drawString(s,x,y,anchor)` / `setFont` / `getFont` | `DrawString/SetFont/GetFont` |
| `Image.createImage(...)` / `createRGBImage` | `Image.CreateImage / Image.CreateRGBImage` (static) |
| `img.getRGB/wid/height/getGraphics` | `GetRGB/GetWidth/GetHeight/GetGraphics` |
| `Font.getFont(f,sty,sz)` / `getHeight()` | `Font.GetFont(...) / Height` property |
| `Canvas` overrides | `protected override` Paint/KeyPressed/KeyReleased/PointerPressed/PointerReleased/ShowNotify/HideNotify (C# Pascal) |
| `getGameAction(key)` | `GetGameAction(key)` (Midp table exact) |
| `RecordStore.openRecordStore/enumerateRecords/getRecord/setRecord/addRecord/nextRecordId/hasNextElement/destroy/reset/closeRecordStore` | Pascal: `OpenRecordStore/EnumerateRecords/GetRecord/SetRecord/AddRecord/NextRecordId/HasNextElement/Destroy/Reset/CloseRecordStore` |
| `Manager.createPlayer(is, mime)` | `Manager.CreatePlayer(stream, mime)` |
| `player.realize/prefetch/start/stop/setLoopCount/close/deallocate` | `Realize/Prefetch/Start/Stop/SetLoopCount/Close/Deallocate` |
| `repaint/serviceRepaints` | no-ops `Repaint/ServiceRepaints` (Game1 drives frames) |

## 5. `h` driver members (NEW, written by h-porting step; Game1 calls these)

```csharp
public static h Inst;                  // singleton (GloftMMN ctor: c = new h(); MiamiNights.h.Inst = c;
                                       //   original thread start REMOVED - Game1 drives)
                                       // instance members (original instance methods, access widened
                                       // from protected -> public with `// was protected` comment):
public void Paint(Graphics g);         // original paint(g)  [made public]
public void KeyPressed(int code);      // original keyPressed(code)  [was protected]
public void KeyReleased(int code);
public void PointerPressed(int x,int y);
public void PointerReleased(int x,int y);
public void ShowNotify();  public void HideNotify();   // original showNotify/hideNotify (already public)
                                       // statics:
public static bool HiddenByLoop;               // original static field aE
public static void m_a();                      // original static a(): sets h_ = -1 (quit sentinel)
public void RunInit();                 // original run() HEAD (up to while loop): c.a(GloftMMN.b,this,240,400); printlns; GloftMMN.f=true; bS=true;
public bool FrameStep();               // ONE original loop iteration body:
                                       //   if(!aE) paint-path; RETURNS false when original `while(h>=0)` would exit
                                       //   -> Game1 then runs exit cleanup (GloftMMN.m_e/m_d/m_c + DestroyApp)
```
NOTE: R5 applies — class h's static field `h` is renamed **`h_`** everywhere (incl. qualified
`MiamiNights.h.h_` refs I already wrote in a.cs/GloftMMN.cs).
Original run() pacing (sleep/gc/66ms) NOT ported — Game1 fixed-step 66ms plays that role.

## 6. GloftMMN specifics (already rewritten in `rebuild/GloftMMN.cs` — READ IT FIRST)

- Resource container API + audio channel machine already ported; call sites translate per R1 m_ rule
  against the REWRITTEN file (its method list = original names with `m_` applied where colliding).
- `GloftMMN.l` (JavaRandom) is NULL until original assignment site runs — same NPE-risk as Java (never triggered).
- Static fields (`h` count, `i` sizes, `j` type, `k` mime, `n/o` string table) are public as needed.

## 7. Engine files already written (DO NOT rewrite)

`Engine/Midp.cs` (Graphics/Image/Font/MIDP constants), `Engine/Display.cs` (MIDlet/Canvas/Display),
`Engine/Rms.cs`, `Engine/Audio.cs` (Manager/Player/MidiSynth/Wav), `Engine/SimpleFont.cs`,
`Engine/JavaRandom.cs`, `GloftMMN.cs`, `Game1.cs`, `Program.cs`.

## 8. Verification (per agent)

1. Your file: syntactic + rule self-check (all `MiamiNights.` quals kept, sbyte applied, m_ renames applied).
2. Do NOT run `dotnet build` — cross-file deps mean integration build is done centrally.
3. Return: file path + counts (methods ported) + PORT-QUESTIONs + any deviations.

## 9. What NOT to port

- `run()` while-loop/pacing/sleep (Game1 does it), `Thread` creation in GloftMMN ctor.
- `System.out.println` debug: KEEP (Console.WriteLine) — behavior-visible on console only.
- MIDP-only classes not referenced.
