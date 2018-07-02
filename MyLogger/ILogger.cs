namespace MyLogger
{
    public interface ILogger
    {
        void Log(LogEntry entry);
        bool IsDebug { get; }
    }
}
