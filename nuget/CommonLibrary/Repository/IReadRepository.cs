using CommonLibrary.Entity;

namespace CommonLibrary.Repository;


public interface IReadRepository<T> where T : class, IAggregateRoot
{
  Task<T> FirstOrDefaultAsync();
}
