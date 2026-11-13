// javax.microedition lifecycle + UI base classes (minimal, per usage in the original MIDlet).
namespace MiamiNights
{
    public abstract class MIDlet
    {
        public abstract void StartApp();
        public abstract void PauseApp();
        public abstract void DestroyApp(bool unconditional);
        public void NotifyDestroyed() { }

        public virtual string GetAppProperty(string key) { return Midp.AppProperty(key); }
    }

    public abstract class Displayable
    {
        public virtual int GetWidth() { return 240; }
        public virtual int GetHeight() { return 400; }
        public virtual void ShowNotify() { }
        public virtual void HideNotify() { }
        public bool IsShown() { return true; }

        // MIDP commands (used by c.java dialogs)
        public void AddCommand(Command cmd) { }
        public void RemoveCommand(Command cmd) { }
        public void SetCommandListener(CommandListener cl) { CommandListener = cl; }
        public CommandListener CommandListener;
    }

    public abstract class Canvas : Displayable
    {
        // event delivery: ported subclasses override with protected methods
        protected virtual void Paint(Graphics g) { }
        protected virtual void KeyPressed(int keyCode) { }
        protected virtual void KeyReleased(int keyCode) { }
        protected virtual void KeyRepeated(int keyCode) { }
        protected virtual void PointerPressed(int x, int y) { }
        protected virtual void PointerReleased(int x, int y) { }
        protected virtual void PointerDragged(int x, int y) { }

        public int GetGameAction(int keyCode) { return Midp.GetGameAction(keyCode); }
        public void Repaint() { }
        public void ServiceRepaints() { }
        public void SetFullScreenMode(bool mode) { }

        // Driver used by Game1 (ports call their own protected overrides through these statics)
        public static System.Action<Graphics> PaintHandler;
        public static System.Action<int> KeyPressedHandler;
        public static System.Action<int> KeyReleasedHandler;
        public static System.Action<int, int> PointerPressedHandler;
        public static System.Action<int, int> PointerReleasedHandler;
    }

    public sealed class Display
    {
        private static Display instance;
        public Displayable Current;
        public static Display GetDisplay(MIDlet m) { return instance ?? (instance = new Display()); }
        public void SetCurrent(Displayable d) { Current = d; }
    }
}
