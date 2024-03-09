using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace API.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerGenConfig(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            services.AddSwaggerGen(delegate (SwaggerGenOptions c)
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechChallenge", Version = "v1" });

                c.EnableAnnotations();

                c.CustomSchemaIds((Type x) => x.FullName);

                c.ExampleFilters();
            });
        }
    }
}
