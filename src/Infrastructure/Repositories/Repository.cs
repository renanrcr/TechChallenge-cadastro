using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechChallenge.src.Adapters.Driven.Infra.DataContext;
using Domain.Adapters;
using Domain.Entities;
using System.Collections.Generic;

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
            return await DbSet.AsNoTracking().Where(x => x.DataExclusao.Date == DateTime.MinValue.Date).Where(predicate).ToListAsync();
        }

        public async Task<bool> Existe(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().AnyAsync(predicate);
        }

        public virtual async Task<TEntity?> ObterPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(x => x.DataExclusao.Date == DateTime.MinValue.Date).FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.AsNoTracking().Where(x => x.DataExclusao.Date == DateTime.MinValue.Date).ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DetachLocal(_ => _.Id == entity.Id);
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DetachLocal(_ => _.Id == entity.Id);
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(TEntity entity)
        {
            DetachLocal(_ => _.Id == entity.Id);
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

        public virtual void DetachLocal(Func<TEntity, bool> predicate)
        {
            var local = Db.Set<TEntity>().Local.FirstOrDefault(predicate);
            if(local != null)
            {
                DbSet.Entry(local).State = EntityState.Detached;
            }
        }
    }
}