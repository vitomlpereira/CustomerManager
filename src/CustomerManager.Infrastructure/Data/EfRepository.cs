using CommonLibrary.Entity;
using CommonLibrary.Repository;

namespace CustomerService.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(AppDbContext dbContext) : base(dbContext)
  {
  }

}
