using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

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
            //var children = Configuration.GetSection("Logging:LogLevel").GetChildren();

            //foreach (var child in children)
            //{
            //    Console.WriteLine(child.Key + "=" + child.Value);
            //}

            var myLibraryConfig = Configuration.GetSection("CustomSection").Get<MyLibraryConfig>();

            Console.WriteLine("Key1: " + myLibraryConfig.Key1);
            Console.WriteLine("Key2: " + myLibraryConfig.Key2);
            Console.WriteLine("Key3: " + myLibraryConfig.Key3);
            Console.WriteLine("SomeConfiguration: " + myLibraryConfig.GroupedConfig.SomeConfiguration);
            Console.WriteLine("SomeConfiguration1: " + myLibraryConfig.GroupedConfig.SomeConfiguration1);

            services.Configure<MyLibraryConfig>(Configuration.GetSection("CustomSection"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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