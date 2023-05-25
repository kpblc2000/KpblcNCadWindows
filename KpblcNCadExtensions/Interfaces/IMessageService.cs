using System.Runtime.CompilerServices;

namespace KpblcNCadExtensions.Interfaces
{
    public interface IMessageService
    {
        void ErrorMessage(string Message, [CallerMemberName] string CallMethodName = null);
        void InfoMessage(string Message, [CallerMemberName] string CallMethodName = null);
        void ExceptionMessage(string Message, [CallerMemberName] string CallMethodName = null);
        void ConsoleMessge(string Message, [CallerMemberName] string CallMethodName = null);

    }
}
