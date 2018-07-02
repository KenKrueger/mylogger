using System;

namespace MyLogger
{
    public static class LoggerExtensions
    {
        public static void Verbose(this ILogger logger, string message, Exception exception = null, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Verbose, message, exception, args));
        }

        public static void Verbose(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Verbose, message, args: args));
        }

        public static void Info(this ILogger logger, string message, Exception exception = null, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Information, message, exception, args));
        }

        public static void Info(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Information, message, args: args));
        }

        public static void Debug(this ILogger logger, string message, Exception exception = null, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Debug, message, exception, args));
        }

        public static void Debug(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Debug, message, args: args));
        }

        public static void Warn(this ILogger logger, string message, Exception exception = null, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Warning, message, exception, args));
        }

        public static void Warn(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Warning, message, args: args));
        }

        public static void Error(this ILogger logger, string message, Exception exception = null, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Error, message, exception, args));
        }

        public static void Error(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Error, message, args: args));
        }

        public static void Fatal(this ILogger logger, string message, Exception exception = null, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Fatal, message, exception, args));
        }

        public static void Fatal(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEntry(LoggingEventType.Fatal, message, args: args));
        }
    }
}
