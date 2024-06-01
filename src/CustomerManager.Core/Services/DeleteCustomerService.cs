using Ardalis.Result;
using CommonLibrary.Repository;
using CustomerService.Core.CustomerAggregate;
using CustomerService.Core.CustomerAggregate.Events;
using CustomerService.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerService.Core.Services;

public class DeleteCustomerService(
    IRepository<Customer> _repository,
    IMediator _mediator,
    ILogger<DeleteCustomerService> _logger) : IDeleteCustomerService
{
  public async Task<Result> DeleteCustomerById(Guid customerId)
  {
    _logger.LogInformation("Deleting Customer {customerId}", customerId);

    var aggregateToDelete = new Customer("test","4343") ; //await _repository.GetByIdAsync(customerId);

    if (aggregateToDelete == null)
      return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);

    var domainEvent = new CustomerDeletedEvent(customerId);
    await _mediator.Publish(domainEvent);
    return Result.Success();

  }
}
