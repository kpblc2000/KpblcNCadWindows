using HostMgd.ApplicationServices;
using KpblcNCadExtensions.Interfaces;
using System.Windows;
using Application = HostMgd.ApplicationServices.Application;

namespace KpblcNCadWindows.Infrastructure
{
    public class CadService : ICadService
    {
        public bool IsDocumentActive
        {
            get
            {
                Document doc = Application.DocumentManager.MdiActiveDocument;
                return doc != null && doc.IsActive;
            }
        }

        public void ShowModalWindow(object win)
        {
            Window winObj = win as Window;
            if (winObj != null)
            {
                Application.ShowModalWindow(winObj);
            }
        }

    }
}
