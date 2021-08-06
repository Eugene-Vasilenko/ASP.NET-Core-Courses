using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebApplication1
{
    public class Startup1
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                Console.WriteLine("Middleware #1 input");

                await next.Invoke();

                Console.WriteLine("Middleware #1 output");
            });

            app.Map("/ref1", async (appBuilder) =>
            {
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Hello World from ref1!");
                });
            });

            app.Map("/ref2", async (appBuilder) =>
            {
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Hello World from ref2!");
                });
            });

            app.MapWhen((context) =>
                {
                    return context.Request.Headers.ContainsKey("TestHeared");
                }
                , async (appBundle) =>
            {
                appBundle.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Hello World from MapWhen!");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}