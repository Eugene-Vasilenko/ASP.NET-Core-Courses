using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.Configure<RouteOptions>(_ =>
            {
                _.ConstraintMap.Add("cust", typeof(CustomRouteConstrain));
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var routeHandler = new RouteHandler(async context =>
            //{
            //    var routeDataValues = context.GetRouteData().Values;

            //    var serialize = JsonSerializer.Serialize(routeDataValues);

            //    await context.Response.WriteAsync(serialize);
            //});

            //var routeBuilder = new RouteBuilder(app, routeHandler);

            //routeBuilder.MapRoute("DefaultRoute",
            //    "{controller:minlength(7)}/{action:cust(test)}/{id:int?}",
            //    new { controller = "Home", action = "Index" }
            //    );

            //routeBuilder.Routes.Add(new CustomRouter());

            //var router = routeBuilder.Build();

            //app.UseRouter(router);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}