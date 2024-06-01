using Ardalis.Result;
using CommonLibrary;

namespace CustomerService.UseCases.Customer.Get;

public record GetCustomerQuery(Guid CustomerId) : IQuery<Result<CustomerDto>>;
