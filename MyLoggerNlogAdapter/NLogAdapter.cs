using MyLogger;
using NLog;
using System;

namespace MyLoggerNlogAdapter
{
    public class NLogAdapter<T> : MyLogger.ILogger
    {
        private readonly Logger _logger = LogManager.GetLogger(typeof(T).FullName);

        public bool IsDebug => _logger.IsDebugEnabled;

        public void Log(LogEntry entry)
        {
            switch (entry.Severity)
            {
                case LoggingEventType.Verbose:
                    _logger.Trace(entry.Exception, entry.Message, entry.Args);
                    break;
                case LoggingEventType.Debug:
                    _logger.Debug(entry.Exception, entry.Message, entry.Args);
                    break;
                case LoggingEventType.Information:
                    _logger.Info(entry.Exception, entry.Message, entry.Args);
                    break;
                case LoggingEventType.Warning:
                    _logger.Warn(entry.Exception, entry.Message, entry.Args);
                    break;
                case LoggingEventType.Error:
                    _logger.Error(entry.Exception, entry.Message, entry.Args);
                    break;
                case LoggingEventType.Fatal:
                    _logger.Fatal(entry.Exception, entry.Message, entry.Args);
                    break;
                default:
                    throw new ArgumentException($"Severity {entry.Severity} is not supported by NLogAdapter", "Severity");
            }
        }
    }
}
