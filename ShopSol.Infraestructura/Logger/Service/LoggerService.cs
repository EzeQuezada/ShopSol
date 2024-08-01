

using ShopSol.Infraestructura.Logger.Interfaces;

namespace ShopSol.Infraestructura.Logger.Service
{
    public class LoggerService : ILoggerService
    {
        public void LogError(Exception ex, string message)
        {
            this.LogError(ex, message);
        }

        public void LogInformation(string message)
        {
            this.LogInformation(message);
        }
    }
}
