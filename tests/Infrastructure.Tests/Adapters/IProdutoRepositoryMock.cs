using Domain.Adapters;
using Infrastructure.Tests.Context;
using TechChallenge.src.Adapters.Driven.Infra.Repositories;

namespace Infrastructure.Tests.Adapters
{
    public class IProdutoRepositoryMock
    {
        public static IProdutoRepository GetMock()
        {
            var dbContext = DataBaseContextTests.CreateDbContext();
            return new ProdutoRepository(dbContext);
        }
    }
}
