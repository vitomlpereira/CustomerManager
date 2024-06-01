using Ardalis.Result;
using CommonLibrary;

namespace CustomerService.UseCases.Customer.Delete;

public record DeleteCustomerCommand(Guid CustomerId) : ICommand<Result>;
