namespace KpblcNCadExtensions.Interfaces
{
    public interface ICadService
    {
        bool IsDocumentActive { get; }
        void ShowModalWindow(object win);
    }
}
