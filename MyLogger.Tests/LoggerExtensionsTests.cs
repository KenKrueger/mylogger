using Moq;
using System;
using System.Linq;
using Xunit;

namespace MyLogger.Tests
{
    public class LoggerExtensionsTests
    {
        private Mock<ILogger> _mockLogger;
        private ILogger _logger;

        public LoggerExtensionsTests()
        {
            _mockLogger = new Mock<ILogger>();
            _logger = _mockLogger.Object;
        }

        // Verbose
        [Fact]
        public void Verbose_WithMessage_LogsMessage()
        {
            _logger.Verbose("test");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "test"
                && e.Severity == LoggingEventType.Verbose
                && e.Exception == null
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Verbose_WithException_LogsException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Verbose("with exception", exception);
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with exception"
                && e.Severity == LoggingEventType.Verbose
                && e.Exception.Message == "Uh oh"
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Verbose_WithArgs_LogsArgs()
        {
            _logger.Verbose("with args", 1, "2");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args"
                && e.Severity == LoggingEventType.Verbose
                && e.Exception == null
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }

        [Fact]
        public void Verbose_WithArgsAndException_LogsArgsAndException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Verbose("with args and exception", exception, 1, "2");

            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args and exception"
                && e.Severity == LoggingEventType.Verbose
                && e.Exception.Message == "Uh oh"
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }

        // Information
        [Fact]
        public void Information_WithMessage_LogsMessage()
        {
            _logger.Info("test");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "test" 
                && e.Severity == LoggingEventType.Information 
                && e.Exception == null 
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Information_WithException_LogsException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Info("with exception", exception);
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with exception" 
                && e.Severity == LoggingEventType.Information 
                && e.Exception.Message == "Uh oh" 
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Information_WithArgs_LogsArgs()
        {
            _logger.Info("with args", 1, "2");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args"
                && e.Severity == LoggingEventType.Information
                && e.Exception == null
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }

        [Fact]
        public void Information_WithArgsAndException_LogsArgsAndException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Info("with args and exception", exception, 1, "2");

            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args and exception"
                && e.Severity == LoggingEventType.Information
                && e.Exception.Message == "Uh oh"
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }

        // Debug
        [Fact]
        public void Debug_WithMessage_LogsMessage()
        {
            _logger.Debug("test");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "test"
                && e.Severity == LoggingEventType.Debug
                && e.Exception == null
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Debug_WithException_LogsException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Debug("with exception", exception);
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with exception"
                && e.Severity == LoggingEventType.Debug
                && e.Exception.Message == "Uh oh"
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Debug_WithArgs_LogsArgs()
        {
            _logger.Debug("with args", 1, "2");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args"
                && e.Severity == LoggingEventType.Debug
                && e.Exception == null
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }

        [Fact]
        public void Debug_WithArgsAndException_LogsArgsAndException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Debug("with args and exception", exception, 1, "2");

            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args and exception"
                && e.Severity == LoggingEventType.Debug
                && e.Exception.Message == "Uh oh"
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }

        // Warnings
        [Fact]
        public void Warn_WithMessage_LogsMessage()
        {
            _logger.Warn("test");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "test"
                && e.Severity == LoggingEventType.Warning
                && e.Exception == null
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Warn_WithException_LogsException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Warn("with exception", exception);
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with exception"
                && e.Severity == LoggingEventType.Warning
                && e.Exception.Message == "Uh oh"
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Warn_WithArgs_LogsArgs()
        {
            _logger.Warn("with args", 1, "2");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args"
                && e.Severity == LoggingEventType.Warning
                && e.Exception == null
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }

        [Fact]
        public void Warn_WithArgsAndException_LogsArgsAndException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Warn("with args and exception", exception, 1, "2");

            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args and exception"
                && e.Severity == LoggingEventType.Warning
                && e.Exception.Message == "Uh oh"
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }

        // Errors
        [Fact]
        public void Error_WithMessage_LogsMessage()
        {
            _logger.Error("test");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "test"
                && e.Severity == LoggingEventType.Error
                && e.Exception == null
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Error_WithException_LogsException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Error("with exception", exception);
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with exception"
                && e.Severity == LoggingEventType.Error
                && e.Exception.Message == "Uh oh"
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Error_WithArgs_LogsArgs()
        {
            _logger.Error("with args", 1, "2");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args"
                && e.Severity == LoggingEventType.Error
                && e.Exception == null
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }

        [Fact]
        public void Error_WithArgsAndException_LogsArgsAndException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Error("with args and exception", exception, 1, "2");

            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args and exception"
                && e.Severity == LoggingEventType.Error
                && e.Exception.Message == "Uh oh"
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }

        // Fatal
        [Fact]
        public void Fatal_WithMessage_LogsMessage()
        {
            _logger.Fatal("test");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "test"
                && e.Severity == LoggingEventType.Fatal
                && e.Exception == null
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Fatal_WithException_LogsException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Fatal("with exception", exception);
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with exception"
                && e.Severity == LoggingEventType.Fatal
                && e.Exception.Message == "Uh oh"
                && !e.Args.Any())),
                Times.Once);
        }

        [Fact]
        public void Fatal_WithArgs_LogsArgs()
        {
            _logger.Fatal("with args", 1, "2");
            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args"
                && e.Severity == LoggingEventType.Fatal
                && e.Exception == null
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }

        [Fact]
        public void Fatal_WithArgsAndException_LogsArgsAndException()
        {
            var exception = new ArgumentException("Uh oh");
            _logger.Fatal("with args and exception", exception, 1, "2");

            _mockLogger.Verify(l => l.Log(It.Is<LogEntry>(
                e => e.Message == "with args and exception"
                && e.Severity == LoggingEventType.Fatal
                && e.Exception.Message == "Uh oh"
                && (int)e.Args[0] == 1
                && e.Args[1].ToString() == "2")),
                Times.Once);
        }
    }
}
