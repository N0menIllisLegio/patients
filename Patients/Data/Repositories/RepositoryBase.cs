using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Patients.Data.Repositories.Interfaces;

namespace Patients.Data.Repositories
{
  public abstract class RepositoryBase<TEntity>: IRepositoryBase<TEntity>
    where TEntity : class
  {
    public RepositoryBase(AppDbContext context)
    {
      Context = context;
      DbSet = context.Set<TEntity>();
    }

    protected AppDbContext Context { get; }

    protected DbSet<TEntity> DbSet { get; }

    public async Task<List<TEntity>> GetAllByWhereAsync(Expression<Func<TEntity, bool>> match,
      bool disableTracking = false)
    {
      return disableTracking
        ? await DbSet.AsNoTracking().Where(match).ToListAsync()
        : await DbSet.Where(match).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>,
      IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true)
    {
      IQueryable<TEntity> query = DbSet;

      if (disableTracking)
      {
        query = query.AsNoTracking();
      }

      if (include is not null)
      {
        query = include(query);
      }

      return await query.ToListAsync();
    }

    public async Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> match,
      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
      return include is not null
        ? await include(DbSet).FirstOrDefaultAsync(match)
        : await DbSet.FirstOrDefaultAsync(match);
    }

    public virtual async Task<TEntity> FindAsync(object id)
    {
      return await DbSet.FindAsync(id);
    }

    public virtual TEntity Update(TEntity entity)
    {
      return DbSet.Update(entity).Entity;
    }

    public virtual TEntity Add(TEntity entity)
    {
      return DbSet.Add(entity).Entity;
    }

    public virtual void AddRange(IEnumerable<TEntity> entities)
    {
      DbSet.AddRange(entities);
    }

    public virtual TEntity Remove(TEntity entity)
    {
      return DbSet.Remove(entity).Entity;
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
    {
      DbSet.RemoveRange(entities);
    }

    public async Task<TEntity> ReloadAsync(TEntity entity)
    {
      await Context.Entry(entity).ReloadAsync();
      return entity;
    }
  }
}
