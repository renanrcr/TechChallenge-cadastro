using TechChallenge.src.Adapters.Driven.Infra.DataContext;
using Domain.Adapters;
using Domain.Entities;

namespace TechChallenge.src.Adapters.Driven.Infra.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}