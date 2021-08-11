using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            // logger.Log(LogLevel.Trace, "Trace");
            // logger.Log(LogLevel.Debug, "Debug");
            // logger.Log(LogLevel.Information, "Information");
            // logger.Log(LogLevel.Warning, "Warning");
            // logger.Log(LogLevel.Error, "Error");
            // logger.Log(LogLevel.Critical, "Critical");
            // logger.Log(LogLevel.None, "None");

            // var loggingOptions = Configuration.GetSection("FileLog").Get<LoggingOptions>();
            //
            // var loggerFactory = LoggerFactory.Create(builder =>
            // {
            //     builder.AddProvider(new FileLoggerProvider(loggingOptions));
            // });
            //
            // var logger1 = loggerFactory.CreateLogger("Custom Logger");

            logger.LogInformation("Information");
            logger.LogInformation("Information 1");
            logger.LogInformation("Information 2");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}