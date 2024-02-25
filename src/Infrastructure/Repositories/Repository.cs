using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechChallenge.src.Adapters.Driven.Infra.DataContext;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Adapters.Driven.Infra.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntidadeBase<Guid>, new()
    {
        protected readonly DataBaseContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(DataBaseContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<bool> Existe(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().AnyAsync(predicate);
        }

        public virtual async Task<TEntity?> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}