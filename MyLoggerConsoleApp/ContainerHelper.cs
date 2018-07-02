using MyLoggerSerilogAdapter;
using Serilog;
using SimpleInjector;

namespace MyLoggerConsoleApp
{
    /// <summary>
    /// Simple Injector Container / Setup
    /// </summary>
    public static class ContainerHelper
    {
        static readonly Container _container = new Container();
        public static Container Container => _container;

        static ContainerHelper()
        {
            ConfigureSerilog();

            // Register SerilogAdapters as singletons
            _container.RegisterConditional(
                typeof(MyLogger.ILogger),
                c => typeof(SerilogAdapter<>).MakeGenericType(c.Consumer.ImplementationType),
                Lifestyle.Singleton,
                c => true);

            _container.Verify();
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
    }
}
