using TechChallenge.src.Adapters.Driven.Infra.DataContext;
using TechChallenge.src.Adapters.Driven.Infra.Repositories;
using Domain.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class InfraModuleDependency
    {
        public static void AddInfraModule(this IServiceCollection services)
        {
            services.AddScoped<DataBaseContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ITabelaPrecoRepository, TabelaPrecoRepository>();
        }
    }
}