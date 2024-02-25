using TechChallenge.src.Core.Application.Notificacoes;
using TechChallenge.src.Core.Domain.Adapters;

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