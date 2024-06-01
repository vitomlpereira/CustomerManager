using Ardalis.Result;

namespace CustomerService.Core.Interfaces;

public interface IDeleteCustomerService
{
   public Task<Result> DeleteCustomerById(Guid customerId);
}
