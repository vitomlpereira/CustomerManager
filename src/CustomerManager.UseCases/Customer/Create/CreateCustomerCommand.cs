using Ardalis.Result;
using CommonLibrary;

namespace CustomerService.UseCases.Customer.Create;

public record CreateCustomerCommand(string Name, string CompanyName) : ICommand<Result<Guid>>;
