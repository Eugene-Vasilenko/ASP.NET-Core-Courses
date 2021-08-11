using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace WebApplication1.CustomLogging
{
    public class CustomFileLogger : ILogger
    {
        private readonly FileLoggerProvider _provider;

        private static object _lock = new object();

        public CustomFileLogger(FileLoggerProvider provider)
        {
            _provider = provider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var filePath = Path.Combine(_provider.Options.FolderPath, _provider.Options.FileName);

            var logLine = formatter(state, exception) + Environment.NewLine;

            lock (_lock)
            {
                File.AppendAllText(filePath, logLine);
            }
        }
    }
}