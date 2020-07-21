using System;
using DUR.Api.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace DUR.Api.Infrastructure
{
    public class ApplicationLogger : IApplicationLogger
    {
        private readonly ILogger _logger;

        public ApplicationLogger(ILogger<ApplicationLogger> logger)
        {
            _logger = logger;
        }

        public void LogCritical(string message)
        {
            SetCustomProperties();
            _logger.LogCritical(message);
        }

        public void LogCritical(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogCritical(exception, message);
        }

        public void LogCritical<T>(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogCritical(exception, AddType<T>(message));
        }

        public void LogDebug(string message)
        {
            SetCustomProperties();
            _logger.LogDebug(message);
        }

        public void LogDebug(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogDebug(exception, message);
        }

        public void LogDebug<T>(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogDebug(exception, AddType<T>(message));
        }

        public void LogError(string message)
        {
            SetCustomProperties();
            _logger.LogError(message);
        }

        public void LogError(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogError(exception, message);
        }

        public void LogError<T>(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogError(exception, AddType<T>(message));
        }

        public void LogInformation(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogInformation(exception, message);
        }

        public void LogInformation(string message)
        {
            SetCustomProperties();
            _logger.LogInformation(message);
        }

        public void LogInformation<T>(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogInformation(exception, AddType<T>(message));
        }

        public void LogTrace(string message)
        {
            SetCustomProperties();
            _logger.LogTrace(message);
        }

        public void LogTrace(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogTrace(exception, message);
        }

        public void LogTrace<T>(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogTrace(exception, AddType<T>(message));
        }

        public void LogWarning(string message)
        {
            SetCustomProperties();
            _logger.LogWarning(message);
        }

        public void LogWarning(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogWarning(exception, message);
        }

        public void LogWarning<T>(Exception exception, string message)
        {
            SetCustomProperties();
            _logger.LogWarning(exception, AddType<T>(message));
        }

        public void LogCritical<T>(string message)
        {
            SetCustomProperties();
            _logger.LogCritical(AddType<T>(message));
        }

        public void LogDebug<T>(string message)
        {
            SetCustomProperties();
            _logger.LogDebug(AddType<T>(message));
        }

        public void LogError<T>(string message)
        {
            SetCustomProperties();
            _logger.LogError(AddType<T>(message));
        }

        public void LogInformation<T>(string message)
        {
            SetCustomProperties();
            _logger.LogInformation(AddType<T>(message));
        }

        public void LogTrace<T>(string message)
        {
            SetCustomProperties();
            _logger.LogTrace(AddType<T>(message));
        }

        public void LogWarning<T>(string message)
        {
            SetCustomProperties();
            _logger.LogWarning(AddType<T>(message));
        }

        private void SetCustomProperties()
        {
            // FOR ADDITIONAL USE
        }

        private string AddType<T>(string message)
        {
            return (message + "T = typeof " + typeof(T).Name);
        }
    }
}
