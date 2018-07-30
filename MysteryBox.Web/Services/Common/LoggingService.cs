using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MysteryBox.WebService.Services.Common
{
    public class LoggingService<T> : ILoggingService<T>
    {
        private readonly ILogger<T> _logger;

        public LoggingService(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string logMessage)
        {
            _logger.LogInformation(logMessage);
        }

        public void LogInformation<TLogObject>(string logMessage, TLogObject obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            _logger.LogInformation($"{logMessage} : {jsonString}");
        }

        public void LogInformation(string logMessage, int id)
        {
            _logger.LogInformation(logMessage, id);
        }

        public void LogWarning<TObject>(string logMessage, TObject obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            _logger.LogWarning($"{logMessage} : {jsonString}");
        }

        public void LogError(string logMessage)
        {
            _logger.LogError(logMessage);
        }
    }
}
