using Domain.Adapters;
using Infrastructure.Tests.Context;
using TechChallenge.src.Adapters.Driven.Infra.Repositories;

namespace Infrastructure.Tests.Adapters
{
    public class ITabelaPrecoRepositoryMock
    {
        public static ITabelaPrecoRepository GetMock()
        {
            var dbContext = DataBaseContextTests.CreateDbContext();
            return new TabelaPrecoRepository(dbContext);
        }
    }
}
