using Domain.Adapters;
using Infrastructure.Tests.Context;
using TechChallenge.src.Adapters.Driven.Infra.Repositories;

namespace Infrastructure.Tests.Adapters
{
    public class IClienteRepositoryMock
    {
        public static IClienteRepository GetMock()
        {
            var dbContext = DataBaseContextTests.CreateDbContext();
            return new ClienteRepository(dbContext);
        }
    }
}
