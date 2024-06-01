using Ardalis.Result;
using CommonLibrary;

namespace CustomerService.UseCases.Customer.List;

public class ListCustomerHandler(IListCustomerQueryService _query) : IQueryHandler<ListCustomerQuery, Result<IEnumerable<CustomerDto>>>
{
  public async Task<Result<IEnumerable<CustomerDto>>> Handle(ListCustomerQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
