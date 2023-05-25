using KpblcNCadWindows.Infrastructure;
using Teigha.Runtime;

namespace KpblcNCadWindows.NCadCommands
{
    public static class MessageCommands
    {
        [CommandMethod("kpblc-info")]
        public static void KpblcInfoMsg()
        {
            MessageService msgService = new MessageService();
            msgService.InfoMessage("Проверка");
        }

        [CommandMethod("kpblc-error")]
        public static void KpblcErrorMsg()
        {
            MessageService msgService = new MessageService();
            try
            {
                var res = 50.0 / 0;
                msgService.ConsoleMessge(res.ToString());
            }
            catch (System.Exception ex)
            {
                msgService.ExceptionMessage(ex);
            }
        }
    }
}
