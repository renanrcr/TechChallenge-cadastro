using Microsoft.EntityFrameworkCore;
using TechChallenge.src.Adapters.Driven.Infra.DataContext;

namespace TechChallenge.src.Adapters.Driven.Infra
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