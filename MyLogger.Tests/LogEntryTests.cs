using System;
using Xunit;

namespace MyLogger.Tests
{
    public class LogEntryTests
    {
        [Fact]
        public void Constructor_CreatesExpectedLogEntry()
        {
            var ex = new FormatException("Hello world");
            var additionalArgs = new object[] { "object 1", 2 };

            var entry = new LogEntry(
                severity: LoggingEventType.Information, 
                message: "message",
                exception: ex, 
                args: additionalArgs);

            Assert.Equal(LoggingEventType.Information, entry.Severity);
            Assert.Equal("message", entry.Message);
            Assert.Equal("Hello world", entry.Exception.Message);
            Assert.Equal(ex, entry.Exception);
            Assert.Equal(additionalArgs, entry.Args);
            Assert.Equal("object 1", entry.Args[0].ToString());
            Assert.Equal(2, (int)entry.Args[1]);
        }
    }
}
