using Ardalis.Result;
using CommonLibrary;
using CommonLibrary.Repository;

namespace CustomerService.UseCases.Customer.Get;


public class GetCustomerHandler(IRepository<Core.CustomerAggregate.Customer> _repository) : IQueryHandler<GetCustomerQuery, Result<CustomerDto>>
{
  public async Task<Result<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
  {

    var entity = await _repository.GetByIdAsync(request.CustomerId);

    if (entity == null) return Result.NotFound();

    return new CustomerDto(entity.Id, entity.Name, entity.CompanyName);
  }
}
