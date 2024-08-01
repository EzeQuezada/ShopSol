namespace ShopSol.Infraestructura.Logger.Interfaces
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogError(Exception ex, string message);
    }
}
