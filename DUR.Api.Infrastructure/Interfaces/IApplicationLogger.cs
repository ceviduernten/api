using System;
namespace DUR.Api.Infrastructure.Interfaces
{
    public interface IApplicationLogger
    {
        void LogCritical(string message);
        void LogCritical<T>(string message);
        void LogCritical(Exception exception, string message);
        void LogCritical<T>(Exception exception, string message);

        void LogDebug(string message);
        void LogDebug<T>(string message);
        void LogDebug(Exception exception, string message);
        void LogDebug<T>(Exception exception, string message);

        void LogError(string message);
        void LogError<T>(string message);
        void LogError(Exception exception, string message);
        void LogError<T>(Exception exception, string message);

        void LogInformation(string message);
        void LogInformation<T>(string message);
        void LogInformation(Exception exception, string message);
        void LogInformation<T>(Exception exception, string message);

        void LogTrace(string message);
        void LogTrace<T>(string message);
        void LogTrace(Exception exception, string message);
        void LogTrace<T>(Exception exception, string message);

        void LogWarning(string message);
        void LogWarning<T>(string message);
        void LogWarning(Exception exception, string message);
        void LogWarning<T>(Exception exception, string message);
    }
}
