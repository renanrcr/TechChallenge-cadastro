using TechChallenge.src.Adapters.Driven.Infra.DataContext;
using Domain.Adapters;
using Domain.Entities;

namespace TechChallenge.src.Adapters.Driven.Infra.Repositories
{
    public class TabelaPrecoRepository : Repository<TabelaPreco>, ITabelaPrecoRepository
    {
        public TabelaPrecoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}