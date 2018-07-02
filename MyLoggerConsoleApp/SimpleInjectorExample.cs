using MyLogger;

namespace MyLoggerConsoleApp
{
    public class SimpleInjectorExample
    {
        private readonly ILogger _logger;

        public SimpleInjectorExample(ILogger logger)
        {
            _logger = logger;
        }
        public void Log(string message, params object[] args)
        {
            _logger.Info(message, args);
        }
    }
}
