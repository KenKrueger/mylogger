using log4net;
using MyLogger;
using System;

namespace MyLoggerLog4NetAdapter
{
    // Doesn't matter if implementing ILogger<T> or ILogger
    // Preference would depend on what DI library is used
    public class Log4NetAdapter<T> : ILogger
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(T));

        public bool IsDebug => _logger.IsDebugEnabled;

        public void Log(LogEntry entry)
        {
            switch (entry.Severity)
            {
                case LoggingEventType.Verbose:
                    _logger.Logger.Log(typeof(T), log4net.Core.Level.Verbose, entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Debug:
                    _logger.Debug(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Information:
                    _logger.Info(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Warning:
                    _logger.Warn(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Error:
                    _logger.Error(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Fatal:
                    _logger.Fatal(entry.Message, entry.Exception);
                    break;
                default:
                    throw new ArgumentException($"Severity {entry.Severity} is not supported by Log4NetAdapter", "Severity");
            }
        }
    }
}
