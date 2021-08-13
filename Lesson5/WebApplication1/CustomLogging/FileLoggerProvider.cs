using Microsoft.Extensions.Logging;
using System.IO;

namespace WebApplication1.CustomLogging
{
    [ProviderAlias("CustomFileLogger")]
    public class FileLoggerProvider : ILoggerProvider
    {
        public readonly LoggingOptions Options;

        public FileLoggerProvider(LoggingOptions options)
        {
            Options = options;

            if (!Directory.Exists(Options.FolderPath))
            {
                Directory.CreateDirectory(Options.FolderPath);
            }
        }

        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new CustomFileLogger(this);
        }
    }
}