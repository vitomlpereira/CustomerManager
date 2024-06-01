using Ardalis.Result;
using CommonLibrary;

namespace CustomerService.UseCases.Customer.Update;

public record UpdateCustomerCommand(Guid CustomerID, string UpdatedCustomerName) : ICommand<Result<CustomerDto>>;
