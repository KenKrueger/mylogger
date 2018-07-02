using MyLoggerLog4NetAdapter;
using MyLoggerNlogAdapter;
using MyLoggerSerilogAdapter;
using Serilog;
using MyLogger;
namespace MyLoggerConsoleApp
{
    public class Logger<T>
    {
        private readonly MyLogger.ILogger _serilogAdapter;
        private readonly MyLogger.ILogger _nlogAdapter = new NLogAdapter<T>();
        private readonly MyLogger.ILogger _log4netAdapter = new Log4NetAdapter<T>();

        public Logger()
        {
            ConfigureSerilog();
            _serilogAdapter = new SerilogAdapter<T>();
        }

        private static void ConfigureSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} | {SourceContext} | {Level:u4} | {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(
                    "serilogLog.txt",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} | {SourceContext} | {Level:u4} | {Message:lj}{NewLine}{Exception}")
                .Enrich.FromLogContext()
                .CreateLogger();
        }

        public void WriteWithSerilog(string message) => _serilogAdapter.Info(message);
        public void WriteWithLog4Net(string message) => _log4netAdapter.Info(message);
        public void WriteWithNLog(string message) => _nlogAdapter.Info(message);
    }
}
