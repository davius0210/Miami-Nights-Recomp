// DesktopGL harness that reproduces the original MIDlet lifecycle + h.run() loop.
// Original: Thread(h) { while (h>=0) { repaint(); pace to 66ms; watchdog 1500ms } }
// Here: MonoGame fixed step 66ms drives the same per-frame path:
//   paint -> b(g){ e() logic+render; q(); GloftMMN.d() audio pump } -> software 2x upscale -> present.
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MiamiNights
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static Game1 Instance;
        private readonly GraphicsDeviceManager gm;
        private SpriteBatch sb;
        private Texture2D presentTex;

        // physical screen == original device: 480x800 (2x the 240x400 logical canvas)
        public const int SCREEN_W = 480;
        public const int SCREEN_H = 800;

        internal Image screenImage;     // 480x800 CPU buffer = the "device Graphics" target
        internal Graphics screenGfx;

        private GloftMMN midlet;
        private bool running = true;
        private long frameStartMs;

        private KeyboardState prevKb;
        private MouseState prevMouse;

        // MN_SHARP=1 restores hard pixel edges
        static readonly SamplerState SmoothSampler = Environment.GetEnvironmentVariable("MN_SHARP") == "1" ? SamplerState.PointClamp : SamplerState.LinearClamp;

        public Game1()
        {
            Instance = this;
            gm = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 720,
                SynchronizeWithVerticalRetrace = false,
            };
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            // original loop paces to >=66ms per frame (~15 FPS)
            IsFixedTimeStep = true;
            // original paced at 66ms; we run 2x (movement/clock are ms-based via h.aH), animations divided back to original pace
            string fpsEnv = Environment.GetEnvironmentVariable("MN_FPS");
            int fpsDiv = fpsEnv == "15" ? 1 : fpsEnv == "30" ? 2 : 4;   // default 60 fps, sprite animation stays at original 15 fps pace
            TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / (15 * fpsDiv));
            d.AnimDiv = fpsDiv;
        }

        protected override void Initialize()
        {
            base.Initialize();
            Window.Title = "Miami Nights - Singles in The City (reconstruction)";
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);
            presentTex = new Texture2D(GraphicsDevice, SCREEN_W, SCREEN_H, false, SurfaceFormat.Color);
            screenImage = new Image(SCREEN_W, SCREEN_H);
            screenGfx = new Graphics(screenImage);

            // MIDlet lifecycle: new GloftMMN() -> startApp() -> setCurrent(canvas) -> showNotify()
            SoundFontSynth.Preload();
            midlet = new GloftMMN();
            midlet.StartApp();
            // original thread head: run() init before while(h>=0) loop
            h.Inst.RunInit();
            frameStartMs = NowMs();
        }

        private static long NowMs() { return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); }

        protected override void Update(GameTime gameTime)
        {
            PumpInput();
            base.Update(gameTime);
        }

        private bool dbgWide;
        private string winShot;
        private void MaybeWinShot()
        {
            if (winShot == null) return;
            try
            {
                int w = GraphicsDevice.PresentationParameters.BackBufferWidth, h = GraphicsDevice.PresentationParameters.BackBufferHeight;
                var px = new Color[w * h];
                GraphicsDevice.GetBackBufferData(px);
                using (var bmp = new System.Drawing.Bitmap(w, h))
                {
                    for (int y = 0; y < h; y++) for (int x = 0; x < w; x++) { var c = px[y * w + x]; bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(c.R, c.G, c.B)); }
                    bmp.Save(Path.Combine(AppContext.BaseDirectory, winShot));
                }
            }
            catch (Exception e) { Console.WriteLine("[winshot] " + e.Message); }
            winShot = null;
        }
        private int lastY = -99;
        private int autoTick; private int shotCount; private int worldFrames; private int exploreTick;
        private static readonly bool AutoPlay = Environment.GetEnvironmentVariable("MN_AUTO") == "1";
        private void PumpInput()
        {
            if (launcher) { LauncherInput(); return; }
            // MN_AUTO: bypass character creation (h_==17) with the game's own start sequence
            // (same code as the in-game "ARE YOU SURE? -> YES" path: g.m_a(true) + m_a(8) + y=67).
            if (AutoPlay && !creationDone && MiamiNights.h.h_ == 17 && MiamiNights.h.at)
            {
                creationDone = true;
                MiamiNights.h.af = "SIMON";
                GloftMMN.m_b(5);
                MiamiNights.g.m_a(true);
                MiamiNights.h.m_a(8);
                MiamiNights.h.y = 67;
                MiamiNights.h.K = 0;
                MiamiNights.h.z = -1;
                MiamiNights.h.i = 0;
                Console.WriteLine("[AUTO] character creation bypassed -> y=67");
            }
            if (AutoPlay && shotCount < 14)
            {
                autoTick++;
                // script-driven states: suppress generic fire (the scripts below drive it);
                // y==0 fires only on TRAVEL SIGNS (never on bed/shower); story/menus fire normally
                bool scriptDriven = creationDone && (MiamiNights.h.y == 0 || MiamiNights.h.y == 30 || MiamiNights.h.y == 31);
                bool allowFire = !scriptDriven || (MiamiNights.h.y == 0 && MiamiNights.f.aR >= 0);
                int ph = autoTick % (scriptDriven ? 60 : 30);
                if (allowFire && ph == 1) DeliverKey(Midp.KEY_FIRE, true);
                if (allowFire && ph == 4) DeliverKey(Midp.KEY_FIRE, false);
                // level select (h_==15): y=30 city map -> FIRE opens district list (y=31);
                // y=31 list -> DOWN to first UNLOCKED location (g.ah) -> FIRE = travel
                if (creationDone && (MiamiNights.h.y == 30 || MiamiNights.h.y == 31))
                {
                    int cyc = autoTick % 30;
                    if (MiamiNights.h.y == 30)
                    {
                        if (cyc == 10) DeliverKey(Midp.KEY_FIRE, true);
                        if (cyc == 14) DeliverKey(Midp.KEY_FIRE, false);
                    }
                    else
                    {
                        int cnt = MiamiNights.h.U[1];
                        int target = -1;
                        for (int k = 0; k < cnt && k < MiamiNights.h.R.Length; k++)
                        {
                            int lv = MiamiNights.h.R[k] - 141;
                            if (lv >= 0 && lv < MiamiNights.g.ah.Length && MiamiNights.g.ah[lv] != 0) { target = k; break; }
                        }
                        if (target >= 0 && MiamiNights.h.U[0] != target)
                        {
                            if (cyc == 10) DeliverKey(Midp.KEY_DOWN, true);
                            if (cyc == 14) DeliverKey(Midp.KEY_DOWN, false);
                        }
                        else if (target >= 0)
                        {
                            if (cyc == 10) DeliverKey(Midp.KEY_FIRE, true);
                            if (cyc == 14) DeliverKey(Midp.KEY_FIRE, false);
                        }
                    }
                }
                // free-play exploration (y==0): long walks with stand-still pauses
                // (lets the NPC AI approach the player)
                if (creationDone && MiamiNights.h.y == 0 && MiamiNights.h.h_ == 8)
                {
                    exploreTick++;
                    int[] dirs = { Midp.KEY_UP, Midp.KEY_RIGHT, Midp.KEY_DOWN, Midp.KEY_LEFT };
                    int dcode = dirs[(exploreTick / 240) % 4];
                    int cyc = exploreTick % 240;
                    if (cyc == 10) DeliverKey(dcode, true);
                    if (cyc == 190) DeliverKey(dcode, false);   // long trek (3s ~5 tiles) to get far from NPCs, then stand
                    if (cyc == 150) { DeliverKey(Midp.KEY_SOFT1, false); }
                }
            }
            KeyboardState kb = Keyboard.GetState();
            if (kb != prevKb)
            {
                foreach (Keys k in kb.GetPressedKeys())
                    if (!prevKb.IsKeyDown(k)) DeliverKey(MapKey(k), true);
                foreach (Keys k in prevKb.GetPressedKeys())
                    if (!kb.IsKeyDown(k)) DeliverKey(MapKey(k), false);
                prevKb = kb;
            }

            MouseState m = Mouse.GetState();
            // pointer coords: original halves DEVICE coords (device is 2x logical), we are already device space
            int mx, my;
            if (wideActive) { if (!WideToLegacy(m.X, m.Y, out mx, out my)) { mx = -1; my = -1; } }
            else
            {
                Rectangle vr = ViewRect();
                mx = (int)((m.X - vr.X) * (long)SCREEN_W / Math.Max(1, vr.Width));
                my = (int)((m.Y - vr.Y) * (long)SCREEN_H / Math.Max(1, vr.Height));
                if (m.X < vr.X || m.Y < vr.Y) { mx = -1; my = -1; }
            }
            bool inside = mx >= 0 && my >= 0 && mx < SCREEN_W && my < SCREEN_H;
            if (inside)
            {
                if (m.LeftButton == ButtonState.Pressed && prevMouse.LeftButton == ButtonState.Released)
                    h.Inst.PointerPressed(mx, my);
                if (m.LeftButton == ButtonState.Released && prevMouse.LeftButton == ButtonState.Pressed)
                    h.Inst.PointerReleased(mx, my);
            }
            prevMouse = m;
        }

        // keyboard -> MIDP raw key codes (the exact values h.c()/getGameAction() expect)
        private static int MapKey(Keys k)
        {
            switch (k)
            {
                case Keys.Up: return Midp.KEY_UP;
                case Keys.Down: return Midp.KEY_DOWN;
                case Keys.Left: return Midp.KEY_LEFT;
                case Keys.Right: return Midp.KEY_RIGHT;
                case Keys.W: return Midp.KEY_UP;
                case Keys.S: return Midp.KEY_DOWN;
                case Keys.A: return Midp.KEY_LEFT;
                case Keys.D: return Midp.KEY_RIGHT;
                case Keys.Enter:
                case Keys.Space:
                case Keys.Z: return Midp.KEY_FIRE;
                case Keys.Escape: return Midp.KEY_SOFT1;
                case Keys.Back: return Midp.KEY_SOFT2;
                case Keys.NumPad0: return Midp.KEY_NUM0;
                case Keys.NumPad1: return Midp.KEY_NUM1;
                case Keys.NumPad2: return Midp.KEY_NUM2;
                case Keys.NumPad3: return Midp.KEY_NUM3;
                case Keys.NumPad4: return Midp.KEY_NUM4;
                case Keys.NumPad5: return Midp.KEY_NUM5;
                case Keys.NumPad6: return Midp.KEY_NUM6;
                case Keys.NumPad7: return Midp.KEY_NUM7;
                case Keys.NumPad8: return Midp.KEY_NUM8;
                case Keys.NumPad9: return Midp.KEY_NUM9;
                case Keys.D0: return Midp.KEY_NUM0;
                case Keys.D1: return Midp.KEY_NUM1;
                case Keys.D2: return Midp.KEY_NUM2;
                case Keys.D3: return Midp.KEY_NUM3;
                case Keys.D4: return Midp.KEY_NUM4;
                case Keys.D5: return Midp.KEY_NUM5;
                case Keys.D6: return Midp.KEY_NUM6;
                case Keys.D7: return Midp.KEY_NUM7;
                case Keys.D8: return Midp.KEY_NUM8;
                case Keys.D9: return Midp.KEY_NUM9;
                case Keys.OemMinus: return Midp.KEY_STAR;   // '*' position varies by layout
                case Keys.OemQuestion: return Midp.KEY_POUND;
                default: return 0;
            }
        }

        private static readonly HashSet<int> zeroKeys = new HashSet<int>();

        private void DeliverKey(int midpCode, bool pressed)
        {
            if (midpCode == 0) return;
            if (pressed) h.Inst.KeyPressed(midpCode);
            else h.Inst.KeyReleased(midpCode);
        }

        protected override void Draw(GameTime gameTime)
        {
            long frameStart = NowMs();
            if (launcher) { DrawLauncher(); base.Draw(gameTime); return; }

            if (h.HiddenByLoop) // aE: original skips repaint while "hidden"
            {
                // still present whatever is on screen (original device held last frame)
                Present();
                base.Draw(gameTime);
                return;
            }

            try
            {
                // ---- original paint(screenGfx): runs e() (logic+render) via b(g), then software 2x upscale ----
                if (MiamiNights.h.y != lastY) { Console.WriteLine("[state] y=" + MiamiNights.h.y + " z=" + MiamiNights.h.z); lastY = MiamiNights.h.y; }
                Graphics.WorldClipSeen = false;
                MiamiNights.f.WorldDrawn = false;
                MiamiNights.h.TransActive = false;
                h.Inst.Paint(screenGfx);
                wideActive = wideMode && (Graphics.WorldClipSeen || MiamiNights.f.WorldDrawn);   // world drawn this frame (incl. action wheel / chat overlays)
                // menus opened over the world (action wheel, talk) reuse the last world frame without redrawing it:
                // stay wide while the same level is loaded and the screen still has the gameplay layout
                if (!wideActive && wideMode && fullTex != null && MiamiNights.f.m != null && MiamiNights.f.CurLevel == fullLevel && GameplayLayout())
                    wideActive = true;
                if (AutoPlay && wideActive && !dbgWide) { dbgWide = true; Console.WriteLine("[wide] first gameplay frame tick=" + autoTick); }
                if (ExportAll && MiamiNights.f.WorldDrawn && !exportAllDone) { exportAllDone = true; BatchExportAll(); return; }
                UpdateFullBg();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // original: red exception banner (aB = screen graphics)
                screenGfx.SetColor(255, 0, 0);
                screenGfx.FillRect(0, 0, 240, 100);
                screenGfx.SetColor(255, 255, 255);
                screenGfx.DrawString(ex.ToString(), 0, 0, 0);
            }

            Present();

            // original loop condition: while (h >= 0); field h_ (R5) -> quit requested
            if (MiamiNights.h.h_ < 0)
            {
                Console.WriteLine("[DRIVER] quit sentinel -> run-tail cleanup + Exit");
                GloftMMN.m_e();
                GloftMMN.m_d();
                GloftMMN.m_c();
                midlet.DestroyApp(true);
                Exit();
                return;
            }

            // original watchdog: frame took >1500ms -> hideNotify()+showNotify() cycle
            long took = NowMs() - frameStart;
            if (took > 1500)
            {
                h.Inst.HideNotify();
                h.Inst.ShowNotify();
            }
            frameStartMs = frameStart;

            base.Draw(gameTime);
        }

        private static bool prevF12;
        private int autoDump;
        private int[] presentBuf;
        private bool creationDone;   // MN_AUTO: one-shot character-creation bypass

        private void DumpShot(string name = "shot_f12.png")
        {
            try
            {
                int[] px = new int[screenImage.W * screenImage.H];
                presentTex.GetData(px);
                using (var bmp = new System.Drawing.Bitmap(screenImage.W, screenImage.H))
                {
                    for (int y = 0; y < screenImage.H; y++)
                        for (int x = 0; x < screenImage.W; x++)
                        {
                            int c = px[y * screenImage.W + x];
                            c = ((c & 0xFF) << 16) | (c & 0xFF00) | ((c >> 16) & 0xFF); // ABGR -> RGB
                            bmp.SetPixel(x, y, System.Drawing.Color.FromArgb((c >> 16) & 255, (c >> 8) & 255, c & 255));
                        }
                    string path = Path.Combine(AppContext.BaseDirectory, name);
                    bmp.Save(path);
                    Console.WriteLine("[shot] " + path);
                }
            }
            catch (Exception e) { Console.WriteLine("[shot fail] " + e.Message); }
        }

        // largest 480x800 rect that fits the window, centered (aspect preserved)
        private Rectangle ViewRect()
        {
            int ww = GraphicsDevice.Viewport.Width, wh = GraphicsDevice.Viewport.Height;
            float sc = Math.Min(ww / (float)SCREEN_W, wh / (float)SCREEN_H);
            int w = (int)(SCREEN_W * sc), h = (int)(SCREEN_H * sc);
            return new Rectangle((ww - w) / 2, (wh - h) / 2, w, h);
        }



        private Color[] hudBuf; private Texture2D hudTex;


        // ---------------- modern launcher / main menu (art: tools/gen_menu.py -> res/wide/menu.png) ----------------
        private bool launcher = Environment.GetEnvironmentVariable("MN_AUTO") != "1";
        private int launcherSel;
        private Texture2D menuTex, whiteTex;
        private KeyboardState launcherPrevKb;
        private MouseState launcherPrevMouse;
        private static readonly string[] LauncherItems = { "START", "FULLSCREEN", "WIDE SCREEN", "QUIT" };
        private static readonly int[] LauncherY = { 84, 106, 128, 150 };   // art px (320x180), x 90..230, h 18

        private Rectangle MenuRect()
        {
            int ww = GraphicsDevice.Viewport.Width, wh = GraphicsDevice.Viewport.Height;
            float sc = Math.Min(ww / 320f, wh / 180f);
            int w = (int)(320 * sc), h = (int)(180 * sc);
            return new Rectangle((ww - w) / 2, (wh - h) / 2, w, h);
        }

        private Rectangle ButtonRect(int i)
        {
            var m = MenuRect(); float sc = m.Width / 320f;
            return new Rectangle(m.X + (int)(90 * sc), m.Y + (int)(LauncherY[i] * sc), (int)(140 * sc), (int)(18 * sc));
        }

        private void LauncherActivate(int i)
        {
            switch (i)
            {
                case 0: launcher = false; prevKb = Keyboard.GetState(); prevMouse = Mouse.GetState(); break;
                case 1: gm.ToggleFullScreen(); break;
                case 2: wideMode = !wideMode; break;
                case 3: Exit(); break;
            }
        }

        private void LauncherInput()
        {
            var kb = Keyboard.GetState();
            bool Pressed(Keys k) { return kb.IsKeyDown(k) && !launcherPrevKb.IsKeyDown(k); }
            if (Pressed(Keys.Up) || Pressed(Keys.W)) launcherSel = (launcherSel + LauncherItems.Length - 1) % LauncherItems.Length;
            if (Pressed(Keys.Down) || Pressed(Keys.S)) launcherSel = (launcherSel + 1) % LauncherItems.Length;
            bool go = Pressed(Keys.Enter) || Pressed(Keys.Space) || Pressed(Keys.Z);
            var m = Mouse.GetState();
            for (int i = 0; i < LauncherItems.Length; i++)
                if (ButtonRect(i).Contains(m.X, m.Y))
                {
                    launcherSel = i;
                    if (m.LeftButton == ButtonState.Released && launcherPrevMouse.LeftButton == ButtonState.Pressed) go = true;
                }
            launcherPrevKb = kb; launcherPrevMouse = m;
            if (Pressed(Keys.F11)) gm.ToggleFullScreen();
            if (go) LauncherActivate(launcherSel);
        }

        private void DrawLauncher()
        {
            if (menuTex == null)
            {
                try { using (var fs = File.OpenRead(Midp.ResPath("wide/menu.png"))) menuTex = Texture2D.FromStream(GraphicsDevice, fs); }
                catch (Exception e) { Console.WriteLine("[menu] " + e.Message); launcher = false; return; }
                whiteTex = new Texture2D(GraphicsDevice, 1, 1); whiteTex.SetData(new[] { Color.White });
            }
            GraphicsDevice.Clear(new Color(26, 11, 59));
            var m = MenuRect(); float sc = m.Width / 320f;
            sb.Begin(samplerState: SmoothSampler, blendState: BlendState.AlphaBlend);
            sb.Draw(menuTex, m, Color.White);
            for (int i = 0; i < LauncherItems.Length; i++)
            {
                var r = ButtonRect(i);
                if (i == launcherSel)
                {
                    sb.Draw(whiteTex, r, new Color(255, 95, 168, 110));
                    int t = Math.Max(1, (int)sc);
                    sb.Draw(whiteTex, new Rectangle(r.X, r.Y, r.Width, t), Color.White);
                    sb.Draw(whiteTex, new Rectangle(r.X, r.Bottom - t, r.Width, t), Color.White);
                    sb.Draw(whiteTex, new Rectangle(r.X, r.Y, t, r.Height), Color.White);
                    sb.Draw(whiteTex, new Rectangle(r.Right - t, r.Y, t, r.Height), Color.White);
                }
                if (i == 2 && !wideMode) sb.Draw(whiteTex, new Rectangle(r.X, r.Y + r.Height / 2, r.Width, Math.Max(1, (int)sc)), new Color(255, 255, 255, 160)); // "off" strike
            }
            sb.End();
        }





        // gameplay screen = black status strip on top and black HUD strip at the bottom around the world window
        private bool GameplayLayout()
        {
            int[] px = screenImage.Pixels;
            int[] probes = { 4, 240, 475 };
            foreach (int x in probes)
            {
                if ((px[4 * SCREEN_W + x] & 0xFFFFFF) != 0) return false;      // top strip
                if ((px[645 * SCREEN_W + x] & 0xFFFFFF) != 0) return false;    // bottom strip
            }
            return true;
        }

        // characters/animated objects outside the original 240px window (drawn by the game's own layer-3 renderer)
        private Image entImg; private Graphics entGfx; private Texture2D entTex; private Color[] entBuf;

        private void DrawWideEntities(int ww, int wh, float k)
        {
            int left = (int)Math.Ceiling(fullWorldRect.X / k) + 2;
            int right = (int)Math.Ceiling((ww - fullWorldRect.Right) / k) + 2;
            if (left <= 2 && right <= 2) return;
            int w = left + 240 + right, h = 75 + 240;
            if (entImg == null || entImg.W != w)
            {
                entImg = new Image(w, h);
                entGfx = new Graphics(entImg) { WideWorld = true };
                entTex?.Dispose();
                entTex = new Texture2D(GraphicsDevice, w, h, false, SurfaceFormat.Color);
                entBuf = new Color[w * h];
            }
            Array.Clear(entImg.Pixels, 0, entImg.Pixels.Length);
            entGfx.SetClip(0, 0, w, h);
            MiamiNights.f.RenderWideEntities(entGfx, left, w);
            var px = entImg.Pixels;
            for (int i = 0; i < px.Length; i++)
            {
                int c = px[i];
                entBuf[i] = (c & unchecked((int)0xFF000000)) == 0 ? Color.Transparent
                          : new Color((byte)((c >> 16) & 255), (byte)((c >> 8) & 255), (byte)(c & 255), (byte)255);
            }
            entTex.SetData(entBuf);
            sb.Draw(entTex, new Rectangle((int)Math.Round(fullWorldRect.X - left * k), 0, (int)Math.Round(w * k), wh),
                    new Rectangle(0, 75, w, 240), Color.White);
        }

        // map-change wipe (h.m_a(int,int)) applied to the whole window instead of the 240px column
        private void DrawTransition()
        {
            if (!MiamiNights.h.TransActive) return;
            int ww = GraphicsDevice.Viewport.Width, wh = GraphicsDevice.Viewport.Height;
            if (whiteTex == null) { whiteTex = new Texture2D(GraphicsDevice, 1, 1); whiteTex.SetData(new[] { Color.White }); }
            int w = MiamiNights.h.TransMode == 0 ? (int)Math.Ceiling(ww * MiamiNights.h.TransP / 256f) : ww;
            if (w <= 0) return;
            sb.Begin(samplerState: SmoothSampler, blendState: BlendState.Opaque);
            sb.Draw(whiteTex, new Rectangle(0, 0, w, wh), Color.Black);
            sb.End();
        }
        private float lastFocusX;
        private Texture2D backdropTex;

        private Rectangle RoomBgRect(int ww, int wh, float focusX)
        {
            float k = wh / 240f;
            return new Rectangle((int)Math.Round(ww / 2f + (MiamiNights.f.FullX0 - focusX) * k),
                                 (int)Math.Round((MiamiNights.f.FullY0 - MiamiNights.f.D) * k),
                                 (int)Math.Round(fullTex.Width * k), (int)Math.Round(fullTex.Height * k));
        }

        // side fill for non-gameplay screens (chat, loading, menus): the current room if still loaded, else the sunset art
        private void DrawWideBackdrop(int ww, int wh)
        {
            bool roomLoaded = wideMode && fullTex != null && MiamiNights.f.m != null && MiamiNights.f.CurLevel == fullLevel;
            sb.Begin(samplerState: SmoothSampler, blendState: BlendState.Opaque);
            if (roomLoaded)
            {
                GraphicsDevice.Clear(new Color(((fullBl >> 16) & 255) / 2, ((fullBl >> 8) & 255) / 2, (fullBl & 255) / 2));
                sb.Draw(fullTex, RoomBgRect(ww, wh, lastFocusX), new Color(120, 120, 135));
            }
            else
            {
                if (backdropTex == null)
                {
                    try { using (var fs = File.OpenRead(Midp.ResPath("wide/backdrop.png"))) backdropTex = Texture2D.FromStream(GraphicsDevice, fs); }
                    catch (Exception) { }
                }
                if (backdropTex != null)
                {
                    float cs = Math.Max(ww / 320f, wh / 180f);
                    int cw = (int)(320 * cs), ch = (int)(180 * cs);
                    sb.Draw(backdropTex, new Rectangle((ww - cw) / 2, (wh - ch) / 2, cw, ch), new Color(150, 150, 165));
                }
            }
            sb.End();
        }

        // ---- MN_EXPORT_ALL=1 : load every level through the original loader and export bg + collision ----
        private static readonly bool ExportAll = Environment.GetEnvironmentVariable("MN_EXPORT_ALL") == "1";
        private bool exportAllDone;

        private void BatchExportAll()
        {
            int n = MiamiNights.f.i.Length / 3;
            Console.WriteLine("[exportall] levels: " + n);
            var scratch = new Image(240, 400).GetGraphics();
            int ok = 0;
            for (int lvl = 0; lvl < n; lvl++)
            {
                try
                {
                    MiamiNights.h.k = false;
                    MiamiNights.f.bd = 0;
                    int steps = 0;
                    bool done = false;
                    while (steps++ < 600)
                    {
                        MiamiNights.h.k = false;
                        if (MiamiNights.f.m_a(scratch, lvl)) { done = true; break; }
                    }
                    if (!done || MiamiNights.f.CurLevel != lvl) { Console.WriteLine("[exportall] level " + lvl + " did not load"); continue; }
                    var big = MiamiNights.f.RenderFullBackground();
                    if (big == null) { Console.WriteLine("[exportall] level " + lvl + " no background"); continue; }
                    ExportBg(big, lvl);
                    ok++;
                }
                catch (Exception e) { Console.WriteLine("[exportall] level " + lvl + ": " + e); }
            }
            Console.WriteLine("[exportall] done " + ok + "/" + n);
            Exit();
        }

        // ---- widescreen from the real, uncropped level background (f.RenderFullBackground) ----
        private static readonly bool ExportMaps = Environment.GetEnvironmentVariable("MN_EXPORT_MAPS") == "1";
        private bool fullActive;
        private Texture2D fullTex;
        private int fullLevel = -999, fullTick, fullMinX, fullMaxX, fullBl;
        private Rectangle fullWorldRect;
        private readonly HashSet<int> exportedBg = new HashSet<int>();

        private void UpdateFullBg()
        {
            fullActive = false;
            if (!wideActive) return;
            if (!MiamiNights.f.WorldDrawn) { fullActive = fullTex != null; return; }   // reuse last background
            int lvl = MiamiNights.f.CurLevel;
            if (fullTex == null || lvl != fullLevel || ++fullTick % 30 == 0)
            {
                Image big;
                try { big = MiamiNights.f.RenderFullBackground(); }
                catch (Exception e) { Console.WriteLine("[fullbg] " + e.Message); return; }
                if (big == null) return;
                int bl = MiamiNights.f.bl & 0xFFFFFF;
                int minX = int.MaxValue, maxX = int.MinValue;
                for (int y = 0; y < big.H; y++)
                    for (int x = 0; x < big.W; x++)
                        if ((big.Pixels[y * big.W + x] & 0xFFFFFF) != bl) { if (x < minX) minX = x; if (x > maxX) maxX = x; }
                if (minX > maxX) return;   // level not drawn by the tile renderer -> keep the legacy wide fill
                fullMinX = MiamiNights.f.FullX0 + minX; fullMaxX = MiamiNights.f.FullX0 + maxX + 1; fullBl = bl;
                if (ExportMaps && lvl >= 0 && exportedBg.Add(lvl)) ExportBg(big, lvl);
                Texture2D tex = null;
                string edit = Path.Combine(SvgMap.MapDir(false), "lvl_" + lvl + "_bg_edit.png");
                if (File.Exists(edit))
                {
                    try { using (var fs = File.OpenRead(edit)) tex = Texture2D.FromStream(GraphicsDevice, fs); }
                    catch (Exception e) { Console.WriteLine("[fullbg] edit: " + e.Message); }
                    if (tex != null && (tex.Width != big.W || tex.Height != big.H)) { Console.WriteLine("[fullbg] edit size mismatch " + edit); tex.Dispose(); tex = null; }
                }
                if (tex == null)
                {
                    tex = new Texture2D(GraphicsDevice, big.W, big.H, false, SurfaceFormat.Color);
                    var px = new Color[big.W * big.H];
                    for (int i = 0; i < px.Length; i++)
                    {
                        int c = big.Pixels[i];
                        px[i] = new Color((byte)((c >> 16) & 255), (byte)((c >> 8) & 255), (byte)(c & 255), (byte)255);
                    }
                    tex.SetData(px);
                }
                fullTex?.Dispose();
                fullTex = tex; fullLevel = lvl;
            }
            fullActive = true;
        }

        private static void ExportBg(Image big, int lvl)
        {
            try
            {
                string dir = SvgMap.MapDir(true);
                Directory.CreateDirectory(dir);
                string path = Path.Combine(dir, "lvl_" + lvl + "_bg.png");
                using (var bmp = new System.Drawing.Bitmap(big.W, big.H))
                {
                    for (int y = 0; y < big.H; y++)
                        for (int x = 0; x < big.W; x++)
                        {
                            int c = big.Pixels[y * big.W + x];
                            bmp.SetPixel(x, y, System.Drawing.Color.FromArgb((c >> 16) & 255, (c >> 8) & 255, c & 255));
                        }
                    bmp.Save(path);
                }
                Console.WriteLine("[fullbg] exported " + path + " origin=(" + MiamiNights.f.FullX0 + "," + MiamiNights.f.FullY0 + ")");
            }
            catch (Exception e) { Console.WriteLine("[fullbg] export: " + e.Message); }
        }

        private void DrawFullWide(int ww, int wh)
        {
            float k = wh / 240f;                       // screen px per logical px (world window is 240 tall)
            int C = MiamiNights.f.C, D = MiamiNights.f.D;
            float focusX;
            float half = ww / (2f * k);
            if ((fullMaxX - fullMinX) <= 2 * half) focusX = (fullMinX + fullMaxX) / 2f;   // whole room fits: centre it
            else focusX = Math.Max(fullMinX + half, Math.Min(fullMaxX - half, C + 120f)); // follow camera, clamp to room
            fullWorldRect = new Rectangle((int)Math.Round(ww / 2f + (C - focusX) * k), 0, (int)Math.Round(240 * k), wh);
            lastFocusX = focusX;
            GraphicsDevice.Clear(new Color((fullBl >> 16) & 255, (fullBl >> 8) & 255, fullBl & 255));
            var L = Layout();
            sb.Begin(samplerState: SmoothSampler, blendState: BlendState.AlphaBlend);
            sb.Draw(fullTex, RoomBgRect(ww, wh, focusX), Color.White);
            DrawWideEntities(ww, wh, k);
            if (MiamiNights.h.TransActive && MiamiNights.h.TransMode == 0)
            {
                // the frame's left part is already wiped to black: draw only the unwiped part, the window-wide wipe covers the rest
                int cut = Math.Min(480, 480 * MiamiNights.h.TransP >> 8);
                float sxk = fullWorldRect.Width / 480f;
                if (cut < 480)
                    sb.Draw(presentTex, new Rectangle(fullWorldRect.X + (int)Math.Round(cut * sxk), 0, fullWorldRect.Width - (int)Math.Round(cut * sxk), wh),
                            new Rectangle(cut, SrcWorld.Y, 480 - cut, SrcWorld.Height), Color.White);
            }
            else
                sb.Draw(presentTex, fullWorldRect, SrcWorld, Color.White);
            DrawHud(L);
            sb.End();
        }

        // ---------------- widescreen compositor (gameplay only) ----------------
        private bool wideMode = true, wideActive;
        private static bool prevF10;
        // source slices in device px of the 480x800 frame
        private static readonly Rectangle SrcWorld = new Rectangle(0, 150, 480, 480);
        // HUD sources (device px of the 480x800 frame), measured from the game's own layout
        private static readonly Rectangle SrcClock  = new Rectangle(0, 116, 100, 34);
        private static readonly Rectangle SrcCoin   = new Rectangle(286, 114, 42, 36);
        private static readonly Rectangle SrcMoney  = new Rectangle(330, 116, 150, 34);   // right-aligned digits
        private static readonly Rectangle SrcAction = new Rectangle(64, 632, 352, 108);  // action bar ("BED", prompts)
        private static readonly Rectangle SrcHome   = new Rectangle(0, 740, 64, 60);
        private static readonly Rectangle SrcPhone  = new Rectangle(416, 740, 64, 60);

        private struct HudItem { public Rectangle src, dst; public HudItem(Rectangle s, Rectangle d) { src = s; dst = d; } }
        private struct WideLayout { public float s; public Rectangle world, topLeft, topRight; public HudItem clock, coin, money, action, home, phone; }

        // tight bounds of non-transparent pixels inside a HUD source rect (so panels hug the text)
        private Rectangle Tight(Rectangle r)
        {
            if (hudBuf == null) return r;
            int x0 = int.MaxValue, y0 = int.MaxValue, x1 = -1, y1 = -1;
            for (int y = r.Y; y < r.Bottom; y++)
                for (int x = r.X; x < r.Right; x++)
                    if (hudBuf[y * SCREEN_W + x].A != 0) { if (x < x0) x0 = x; if (x > x1) x1 = x; if (y < y0) y0 = y; if (y > y1) y1 = y; }
            return x1 < 0 ? new Rectangle(r.X, r.Y, 0, 0) : new Rectangle(x0, y0, x1 - x0 + 1, y1 - y0 + 1);
        }

        private static Rectangle Scale(Rectangle src, int x, int y, float k) { return new Rectangle(x, y, (int)Math.Round(src.Width * k), (int)Math.Round(src.Height * k)); }

        private WideLayout Layout()
        {
            int ww = GraphicsDevice.Viewport.Width, wh = GraphicsDevice.Viewport.Height;
            var L = new WideLayout();
            L.s = wh / 480f;
            int wsz = wh;
            L.world = fullActive ? fullWorldRect : new Rectangle((ww - wsz) / 2, 0, wsz, wsz);
            float k = wh / 720f * 1.25f;                 // HUD scale (device px -> screen)
            int m = (int)(18 * wh / 720f), pad = (int)(10 * wh / 720f);
            // top-left: clock panel
            var clk = Tight(SrcClock);
            L.clock = new HudItem(clk, Scale(clk, m + pad, m + pad, k));
            L.topLeft = new Rectangle(m, m, L.clock.dst.Width + 2 * pad, (int)(36 * k) + 2 * pad);
            L.clock.dst.Y = L.topLeft.Y + (L.topLeft.Height - L.clock.dst.Height) / 2;
            // top-right: coin + money panel (right aligned)
            var mon = Tight(SrcMoney); var coin = Tight(SrcCoin);
            int monW = (int)Math.Round(mon.Width * k), coinW = (int)Math.Round(coin.Width * k), gap = (int)(8 * k);
            int panelW = coinW + gap + monW + 2 * pad, panelH = (int)(38 * k) + 2 * pad;
            L.topRight = new Rectangle(ww - m - panelW, m, panelW, panelH);
            L.coin = new HudItem(coin, Scale(coin, L.topRight.X + pad, 0, k));
            L.coin.dst.Y = L.topRight.Y + (panelH - L.coin.dst.Height) / 2;
            L.money = new HudItem(mon, Scale(mon, L.coin.dst.Right + gap, 0, k));
            L.money.dst.Y = L.topRight.Y + (panelH - L.money.dst.Height) / 2;
            // bottom corners: home + phone buttons; bottom centre: action bar
            float bk = k * 1.15f;
            L.home = new HudItem(SrcHome, Scale(SrcHome, m, 0, bk)); L.home.dst.Y = wh - m - L.home.dst.Height;
            L.phone = new HudItem(SrcPhone, Scale(SrcPhone, 0, 0, bk)); L.phone.dst.X = ww - m - L.phone.dst.Width; L.phone.dst.Y = wh - m - L.phone.dst.Height;
            L.action = new HudItem(SrcAction, Scale(SrcAction, 0, 0, k)); L.action.dst.X = (ww - L.action.dst.Width) / 2; L.action.dst.Y = wh - m - L.action.dst.Height;
            return L;
        }

        private void DrawPanel(Rectangle r)
        {
            if (r.Width <= 0 || whiteTex == null) return;
            int t = Math.Max(2, r.Height / 16);
            sb.Draw(whiteTex, r, new Color(14, 6, 34, 185));
            sb.Draw(whiteTex, new Rectangle(r.X + t, r.Bottom - t, r.Width - 2 * t, t), new Color(255, 95, 168, 230));   // neon accent
            sb.Draw(whiteTex, new Rectangle(r.X, r.Y, r.Width, 1), new Color(255, 255, 255, 40));
        }

        // modern HUD (call inside an AlphaBlend batch)
        private void DrawHud(WideLayout L)
        {
            if (hudTex == null || MiamiNights.h.TransActive) return;
            if (whiteTex == null) { whiteTex = new Texture2D(GraphicsDevice, 1, 1); whiteTex.SetData(new[] { Color.White }); }
            DrawPanel(L.topLeft);
            DrawPanel(L.topRight);
            foreach (var it in new[] { L.clock, L.coin, L.money, L.action, L.home, L.phone })
                if (it.src.Width > 0) sb.Draw(hudTex, it.dst, it.src, Color.White);
        }

        private void DrawWide()
        {
            int ww = GraphicsDevice.Viewport.Width, wh = GraphicsDevice.Viewport.Height;
            if (fullActive && fullTex != null) { DrawFullWide(ww, wh); return; }
            var L = Layout();
            // 1) procedural side fill: mirrored world slice tiled outward, dimmed
            sb.Begin(samplerState: SmoothSampler, blendState: BlendState.Opaque);
            var dim = new Color(105, 105, 115);
            for (int k = 1; L.world.X - k * L.world.Width < ww; k++)
            {
                var fx = (k % 2 == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                sb.Draw(presentTex, new Rectangle(L.world.X - k * L.world.Width, 0, L.world.Width, L.world.Height), SrcWorld, dim, 0, Vector2.Zero, fx, 0);
                sb.Draw(presentTex, new Rectangle(L.world.X + k * L.world.Width, 0, L.world.Width, L.world.Height), SrcWorld, dim, 0, Vector2.Zero, fx, 0);
                if (k > 8) break;
            }
            sb.End();
            // 2) crisp world, 3) HUD panels at the edges
            sb.Begin(samplerState: SmoothSampler, blendState: BlendState.Opaque);
            sb.Draw(presentTex, L.world, SrcWorld, Color.White);
            sb.End();
            sb.Begin(samplerState: SmoothSampler, blendState: BlendState.AlphaBlend);
            DrawHud(L);
            sb.End();
        }

        // window pixel -> legacy 480x800 device coords; false if it hits nothing interactive
        private bool WideToLegacy(int x, int y, out int lx, out int ly)
        {
            var L = Layout();
            lx = ly = -1;
            foreach (var it in new[] { L.home, L.phone, L.action, L.coin, L.money, L.clock })
                if (it.src.Width > 0 && it.dst.Width > 0 && it.dst.Contains(x, y))
                {
                    lx = it.src.X + (int)((x - it.dst.X) * (long)it.src.Width / it.dst.Width);
                    ly = it.src.Y + (int)((y - it.dst.Y) * (long)it.src.Height / it.dst.Height);
                    return true;
                }
            if (L.world.Contains(x, y))
            {
                lx = (int)((x - L.world.X) * (long)SrcWorld.Width / L.world.Width) + SrcWorld.X;
                ly = (int)((y - L.world.Y) * (long)SrcWorld.Height / L.world.Height) + SrcWorld.Y;
                return true;
            }
            return false;
        }

        private static bool prevF11;

        private void Present()
        {
            var src = screenImage.Pixels;
            if (presentBuf == null) presentBuf = new int[src.Length];
            for (int i = 0; i < src.Length; i++)
            {
                int c = src[i];   // ARGB -> XNA ABGR, opaque
                presentBuf[i] = unchecked((int)0xFF000000) | ((c & 0xFF) << 16) | (c & 0xFF00) | ((c >> 16) & 0xFF);
            }
            presentTex.SetData(presentBuf);
            if (wideActive)
            {
                if (hudBuf == null) { hudBuf = new Color[SCREEN_W * SCREEN_H]; hudTex = new Texture2D(GraphicsDevice, SCREEN_W, SCREEN_H, false, SurfaceFormat.Color); }
                for (int i = 0; i < presentBuf.Length; i++)
                {
                    int row = i / SCREEN_W, c = presentBuf[i];
                    bool outside = row < 150 || row >= 630;
                    hudBuf[i] = (outside && (c & 0xFFFFFF) == 0) ? Color.Transparent : new Color((byte)(c & 255), (byte)((c >> 8) & 255), (byte)((c >> 16) & 255), (byte)255);
                }
                hudTex.SetData(hudBuf);
            }
            if (AutoPlay && shotCount < 14 && wideActive && ++worldFrames % 100 == 0) { winShot = "win" + shotCount + ".png"; DumpShot("shot_world" + (shotCount++) + ".png"); }
            if (++autoDump == 150 && !AutoPlay) DumpShot();   // one-shot verification dump (frame ~150)
            bool f12 = Keyboard.GetState().IsKeyDown(Keys.F12);
            if (f12 && !prevF12) DumpShot();
            prevF12 = f12;
            bool f11 = Keyboard.GetState().IsKeyDown(Keys.F11);
            if (f11 && !prevF11) { gm.ToggleFullScreen(); }
            prevF11 = f11;
            bool f10 = Keyboard.GetState().IsKeyDown(Keys.F10);
            if (f10 && !prevF10) wideMode = !wideMode;
            prevF10 = f10;
            GraphicsDevice.Clear(Color.Black);
            if (wideActive) { DrawWide(); DrawTransition(); MaybeWinShot(); return; }
            int ww = GraphicsDevice.Viewport.Width, wh = GraphicsDevice.Viewport.Height;
            Rectangle vr = ViewRect();
            if (vr.Width < ww || vr.Height < wh) DrawWideBackdrop(ww, wh);
            sb.Begin(samplerState: SmoothSampler, blendState: BlendState.Opaque);
            sb.Draw(presentTex, vr, Color.White);
            sb.End();
            DrawTransition();
        }

        protected override void OnDeactivated(object sender, EventArgs e)
        {
            base.OnDeactivated(sender, e);
            h.Inst?.HideNotify();
        }

        protected override void OnActivated(object sender, EventArgs e)
        {
            base.OnActivated(sender, e);
            h.Inst?.ShowNotify();
        }

        protected override void UnloadContent()
        {
            h.Inst.HideNotify();
            if (midlet != null) midlet.DestroyApp(true);
            base.UnloadContent();
        }
    }
}
