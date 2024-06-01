using Ardalis.Result;
using CommonLibrary.Repository;
using CustomerService.Core.CustomerAggregate;
using CustomerService.Core.CustomerAggregate.Events;
using CustomerService.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerService.Core.Services;

public class CreateCustomerService(IRepository<Customer> _repository,
                                   IMediator _mediator,
                                   ILogger<CreateCustomerService> _logger) : ICreateCustomerService
{
  public async Task<Result> CreateCustomer(Customer custumer)
  {
    _logger.LogInformation("Creating Customer {Name}", custumer.Name);

    var createdCustomer = await _repository.AddAsync(custumer);

    var domainEvent = new CustomerDeletedEvent(createdCustomer.Id);

    await _mediator.Publish(domainEvent);
    
    return Result.Success();
  }

}
