using CommonLibrary.Entity;

namespace CommonLibrary.Repository;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
  Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

  Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

  Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

  Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

  Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

  Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

  Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;
}
