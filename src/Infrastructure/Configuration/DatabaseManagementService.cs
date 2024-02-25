using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.src.Adapters.Driven.Infra.DataContext;

namespace Infrastructure.Configuration
{
    public class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateAsyncScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<DataBaseContext>();
                dbContext.Database.EnsureCreated();
                // Here is the migration executed
                dbContext.Database.Migrate();
            }
        }
    }
}