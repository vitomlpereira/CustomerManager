using CustomerService.UseCases.Customer;
using CustomerService.UseCases.Customer.List;

namespace CustomerService.Infrastructure.Data.Queries;

public class FakeListCustomerQueryService : IListCustomerQueryService
{
  public Task<IEnumerable<CustomerDto>> ListAsync()
  {
    List<CustomerDto> result = [
                                 new CustomerDto(Guid.NewGuid(), "Fake Customer 1", "Company Name 1"),
                                 new CustomerDto(Guid.NewGuid(), "Fake Customer 2", "Company Name 2")
                               ];

    return Task.FromResult(result.AsEnumerable());
  }
}
