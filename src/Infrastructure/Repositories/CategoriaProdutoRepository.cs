using TechChallenge.src.Adapters.Driven.Infra.DataContext;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Adapters.Driven.Infra.Repositories
{
    public class CategoriaProdutoRepository : Repository<CategoriaProduto>, ICategoriaProdutoRepository
    {
        public CategoriaProdutoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}