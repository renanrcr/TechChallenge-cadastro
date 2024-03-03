using Domain.Adapters;
using Domain.Notificacoes;
using Microsoft.Extensions.DependencyInjection;

namespace TechChallenge.src.Adapters.Driven.Infra
{
    public static class ApplicationModuleDependency
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
        }
    }
}