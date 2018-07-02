using MyLogger;
using System;

namespace MyLoggerSerilogAdapter
{
    public class SerilogAdapter<T> : ILogger
    {
        private readonly Serilog.ILogger _logger = Serilog.Log.ForContext<T>();

        public bool IsDebug => _logger.IsEnabled(Serilog.Events.LogEventLevel.Debug);

        public void Log(LogEntry entry)
        {
            switch (entry.Severity)
            {
                case LoggingEventType.Verbose:
                    _logger.Verbose(entry.Exception, entry.Message, entry.Args);
                    break;
                case LoggingEventType.Debug:
                    _logger.Debug(entry.Exception, entry.Message, entry.Args);
                    break;
                case LoggingEventType.Information:
                    _logger.Information(entry.Exception, entry.Message, entry.Args);
                    break;
                case LoggingEventType.Warning:
                    _logger.Warning(entry.Exception, entry.Message, entry.Args);
                    break;
                case LoggingEventType.Error:
                    _logger.Error(entry.Exception, entry.Message, entry.Args);
                    break;
                case LoggingEventType.Fatal:
                    _logger.Fatal(entry.Exception, entry.Message, entry.Args);
                    break;
                default:
                    throw new ArgumentException($"Severity {entry.Severity} is not supported by SerilogAdapter", "Severity");
            }
        }
    }
}
