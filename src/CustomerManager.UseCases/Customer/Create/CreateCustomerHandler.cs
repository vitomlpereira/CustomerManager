using Ardalis.Result;
using CommonLibrary;
using CommonLibrary.Repository;

namespace CustomerService.UseCases.Customer.Create;

public class CreateCustomerHandler(IRepository<Core.CustomerAggregate.Customer> _customerRepository) : ICommandHandler<CreateCustomerCommand, Result<Guid>>
{
  public async Task<Result<Guid>> Handle(CreateCustomerCommand request,  CancellationToken cancellationToken)
  {
    var newContributor = new Core.CustomerAggregate.Customer(request.Name, request.CompanyName);
  
    var createdItem = await _customerRepository.AddAsync(newContributor, cancellationToken);

    return createdItem.Id;
  }
}
