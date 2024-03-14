using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TechChallenge.src.Adapters.Driven.Infra.DataContext;

namespace Infrastructure.Tests.Context
{
    public class DataBaseContextTests
    {
        private static readonly ILoggerFactory DebugLogFactory = new LoggerFactory();

        public static DataBaseContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(databaseName: $"DataBaseTests{Guid.NewGuid()}")
                .UseLoggerFactory(DebugLogFactory)
                .EnableSensitiveDataLogging()
                .Options;

            var dbContext = new DataBaseContext(options);

            return dbContext;
        }
    }
}
