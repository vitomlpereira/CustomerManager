using Ardalis.Result;
using CommonLibrary;

namespace CustomerService.UseCases.Customer.List;

public record ListCustomerQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<CustomerDto>>>;
