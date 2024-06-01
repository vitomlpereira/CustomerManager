using System.Reflection;
using CustomerService.Core.CustomerAggregate;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Infrastructure.Data;

public class AppDbContext : DbContext
{
  
  public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
  {
   
  }

  public DbSet<Customer> Customers => Set<Customer>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
     return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false); 
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
