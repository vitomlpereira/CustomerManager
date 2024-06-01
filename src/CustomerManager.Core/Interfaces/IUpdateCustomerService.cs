using Ardalis.Result;
using CustomerService.Core.CustomerAggregate;

namespace CustomerService.Core.Interfaces;

public interface IUpdateCustomerService
{
  public Task<Result> UpdateCustomer(Customer custumer);
}
