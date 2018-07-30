namespace MysteryBox.WebService.Services.Common
{
    public interface ILoggingService<T>
    {
        void LogInformation(string logMessage);
        void LogInformation<TLogObject>(string logMessage, TLogObject obj);
        void LogInformation(string logMessage, int id);
        void LogWarning<TObject>(string logMessage, TObject obj);
        void LogError(string logMessage);
    }
}