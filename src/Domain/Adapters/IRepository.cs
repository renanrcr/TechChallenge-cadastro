using System.Linq.Expressions;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Domain.Adapters
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntidadeBase<Guid>
    {
        Task Adicionar(TEntity entity);

        Task<TEntity?> ObterPorId(Guid id);

        Task<List<TEntity>> ObterTodos();

        Task Atualizar(TEntity entity);

        Task Remover(TEntity entity);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task<bool> Existe(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}