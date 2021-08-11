using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication1.CustomLogging;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostBuilderContext, configureLogging) =>
                {
                    configureLogging.ClearProviders();
                    configureLogging.AddConsole();

                    var loggingOptions = hostBuilderContext.Configuration.GetSection("FileLog").Get<LoggingOptions>();
                    configureLogging.AddProvider(new FileLoggerProvider(loggingOptions));

                    // configureLogging.SetMinimumLevel(LogLevel.Trace);
                    // configureLogging.AddFilter("Microsoft", LogLevel.Warning);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}