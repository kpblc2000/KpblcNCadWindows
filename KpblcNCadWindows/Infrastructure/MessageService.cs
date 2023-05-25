using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KpblcNCadExtensions.Interfaces;
using System.Windows;
using HostMgd.ApplicationServices;
using Application = HostMgd.ApplicationServices.Application;

namespace KpblcNCadWindows.Infrastructure
{
    public class MessageService : IMessageService
    {
        public MessageService()
        {
            _curVersion = typeof(MessageService).Assembly.GetName().Version.ToString(3);
        }
        public void ErrorMessage(string Message, [CallerMemberName] string CallMethodName = null)
        {
            MessageBox.Show(
                (string.IsNullOrWhiteSpace(CallMethodName) ? "" : CallMethodName) + " вызвал ошибку " + Message,
                Title("Ошибка"), MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void InfoMessage(string Message, [CallerMemberName] string CallMethodName = null)
        {
            MessageBox.Show(
                (string.IsNullOrWhiteSpace(CallMethodName) ? "" : CallMethodName) + " вызвал ошибку " + Message,
                Title("Информация"), MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ExceptionMessage(Exception exception, [CallerMemberName] string CallMethodName = null)
        {
            MessageBox.Show(
                (string.IsNullOrWhiteSpace(CallMethodName) ? "" : CallMethodName) + " вызвал системную ошибку " +
                exception.Message, Title("Системная ошибка"), MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ConsoleMessge(string Message, [CallerMemberName] string CallMethodName = null)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null)
            {
                InfoMessage(Message, CallMethodName);
                return;
            }

            doc.Editor.WriteMessage("\n" + (!string.IsNullOrWhiteSpace(CallMethodName) ? CallMethodName + " : " : "") +
                                    Message + "\n");
        }

        public string CurrentVersion => _curVersion;

        private string Title(string Message)
        {
            return "KpblcNCad v." + _curVersion + " : " + Message;
        }
        private string _curVersion;
    }
}
