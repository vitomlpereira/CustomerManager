using Ardalis.Result;
using CustomerService.Core.CustomerAggregate;

namespace CustomerService.Core.Interfaces;

public interface ICreateCustomerService
{
  public Task<Result> CreateCustomer(Customer custumer);
}
