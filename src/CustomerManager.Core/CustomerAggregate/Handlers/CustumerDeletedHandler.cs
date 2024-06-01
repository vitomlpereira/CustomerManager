using CustomerService.Core.CustomerAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerService.Core.CustomerAggregate.Handlers;


internal class CustumerDeletedHandler(ILogger<CustumerDeletedHandler> _logger) : INotificationHandler<CustomerDeletedEvent>
{
  public async Task Handle(CustomerDeletedEvent customerDeletedEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Handling customer Deleted event for {contributorId}", customerDeletedEvent.CustomerId);

    // Send notification 

    await Task.Delay(1);
  }
}
