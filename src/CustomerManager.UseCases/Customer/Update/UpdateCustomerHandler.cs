using Ardalis.Result;
using CommonLibrary;
using CommonLibrary.Repository;

namespace CustomerService.UseCases.Customer.Update;

public class UpdateCustomerHandler(IRepository<Core.CustomerAggregate.Customer> _repository) : ICommandHandler<UpdateCustomerCommand, Result<CustomerDto>>
{
  public async Task<Result<CustomerDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
  {
    var customerToUpdate = await _repository.GetByIdAsync(request.CustomerID, cancellationToken);

    if (customerToUpdate == null)
    {
      return Result.NotFound();
    }

    customerToUpdate.UpdateName(request.UpdatedCustomerName);

    await _repository.UpdateAsync(customerToUpdate, cancellationToken);

    return Result.Success(new CustomerDto(customerToUpdate.Id,customerToUpdate.Name, customerToUpdate.CompanyName));
  }
}
