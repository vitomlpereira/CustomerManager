using CustomerService.UseCases.Customer;
using CustomerService.UseCases.Customer.List;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Infrastructure.Data.Queries;

public class ListCustomerQueryService(AppDbContext _db) : IListCustomerQueryService
{
  public async Task<IEnumerable<CustomerDto>> ListAsync()
  {
 
    var result = await _db.Database.SqlQuery<CustomerDto>
                            ($"SELECT Id,Name, CompanyName FROM Customers")
                            .ToListAsync();

    return result;
  }
}
