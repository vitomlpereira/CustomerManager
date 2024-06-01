﻿using Microsoft.EntityFrameworkCore;

namespace CommonLibrary.Repository;


public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
  protected DbContext DbContext { get; set; }


  public RepositoryBase(DbContext dbContext)
  {
    DbContext = dbContext;
  }

  public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
  {
    DbContext.Set<T>().Add(entity);

    await SaveChangesAsync(cancellationToken);

    return entity;
  }


  public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
  {
    DbContext.Set<T>().AddRange(entities);

    await SaveChangesAsync(cancellationToken);

    return entities;
  }


  public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
  {
    DbContext.Set<T>().Update(entity);

    await SaveChangesAsync(cancellationToken);
  }


  public virtual async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
  {
    DbContext.Set<T>().UpdateRange(entities);

    await SaveChangesAsync(cancellationToken);
  }


  public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
  {
    DbContext.Set<T>().Remove(entity);

    await SaveChangesAsync(cancellationToken);
  }

  public virtual async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
  {
    DbContext.Set<T>().RemoveRange(entities);

    await SaveChangesAsync(cancellationToken);
  }

  public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    return await DbContext.SaveChangesAsync(cancellationToken);
  }

  public virtual async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
  {
    return await DbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
  }



  public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
  {
    return await DbContext.Set<T>().CountAsync(cancellationToken);
  }


  public virtual async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
  {
    return await DbContext.Set<T>().AnyAsync(cancellationToken);
  }

}
