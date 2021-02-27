using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Patients.Data.Repositories.Interfaces
{
  public interface IRepositoryBase<TEntity>
  {
    Task<List<TEntity>> GetAllByWhereAsync(Expression<Func<TEntity, bool>> match,
     bool disableTracking = false);

    Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>,
      IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true);

    Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> match,
      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

    Task<TEntity> FindAsync(object id);

    TEntity Update(TEntity entity);

    TEntity Add(TEntity entity);

    TEntity Remove(TEntity entity);

    void RemoveRange(IEnumerable<TEntity> entity);

    Task<TEntity> ReloadAsync(TEntity entity);
  }
}
