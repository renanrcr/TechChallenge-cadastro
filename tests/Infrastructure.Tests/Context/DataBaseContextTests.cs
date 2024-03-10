using Microsoft.EntityFrameworkCore;
using TechChallenge.src.Adapters.Driven.Infra.DataContext;

namespace Infrastructure.Tests.Context
{
    public class DataBaseContextTests
    {
        public static DataBaseContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(databaseName: "DataBaseTests")
                .EnableSensitiveDataLogging()
                .Options;

            var dbContext = new DataBaseContext(options);

            return dbContext;
        }
    }
}
