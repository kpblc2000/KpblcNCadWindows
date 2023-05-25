using KpblcNCadWindows.Infrastructure;
using KpblcNCadWindows.Views;
using Teigha.Runtime;

namespace KpblcNCadWindows.NCadCommands
{
    public static class WindowCommand
    {
        [CommandMethod("kpblc-win")]
        public static void KpblcWindowCommand()
        {
            CadService cadService = new CadService();
            EmptyWindow win = new EmptyWindow();
            cadService.ShowModalWindow(win);
        }
    }
}
