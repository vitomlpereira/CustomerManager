using CustomerService.Core.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Infrastructure.Data;

public static class SeedData
{
  public static readonly Customer Customer1 = new("Customer 1", "Company 1" );
  public static readonly Customer Customer2 = new("Customer 2", "Company 2");

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = 
      new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
    {
      
      if (dbContext.Customers.Any())
      {
        return; 
      }

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Customers)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    dbContext.Customers.Add(Customer1);
    dbContext.Customers.Add(Customer2);

    dbContext.SaveChanges();
  }
}
