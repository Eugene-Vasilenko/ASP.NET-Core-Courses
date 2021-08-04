using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ServicesNew;

namespace WebApi
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICounter, Counter>();

            services.AddSingleton<IMessageService, MessageService>();
            services.AddSingleton<IAnotherService, AnotherService>();

            return services;
        }
    }
}