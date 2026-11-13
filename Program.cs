using System;
using System.IO;
using System.Threading.Tasks;

namespace MiamiNights
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                File.AppendAllText(Path.Combine(AppContext.BaseDirectory, "crash.log"),
                    "\n=== " + DateTime.Now + " ===\n" + e.ExceptionObject);
            TaskScheduler.UnobservedTaskException += (s, e) =>
                File.AppendAllText(Path.Combine(AppContext.BaseDirectory, "crash.log"),
                    "\n=== task ===\n" + e.Exception);
            using (var game = new Game1())
                game.Run();
        }
    }
}
