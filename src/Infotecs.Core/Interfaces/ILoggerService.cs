namespace Infotecs.Core.Interfaces
{
    public interface ILoggerService<T>
    {
        void LogInformation(string message, params object[] args);
        void LogError(string message, params object[] args);
    }
}
