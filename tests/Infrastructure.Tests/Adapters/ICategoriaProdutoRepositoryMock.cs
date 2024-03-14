using Domain.Adapters;
using Infrastructure.Tests.Context;
using TechChallenge.src.Adapters.Driven.Infra.Repositories;

namespace Infrastructure.Tests.Adapters
{
    public class ICategoriaProdutoRepositoryMock
    {
        public static ICategoriaProdutoRepository GetMock()
        {
            var dbContext = DataBaseContextTests.CreateDbContext();

            return new CategoriaProdutoRepository(dbContext);
        }
    }
}
