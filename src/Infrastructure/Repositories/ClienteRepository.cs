using TechChallenge.src.Adapters.Driven.Infra.DataContext;
using Domain.Adapters;
using Domain.Entities;

namespace TechChallenge.src.Adapters.Driven.Infra.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}