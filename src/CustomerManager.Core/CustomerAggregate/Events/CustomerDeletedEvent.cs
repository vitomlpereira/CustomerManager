using CommonLibrary;

namespace CustomerService.Core.CustomerAggregate.Events;

internal sealed class CustomerDeletedEvent(Guid customerId) : DomainEventBase
{
  public Guid CustomerId { get; init; } = customerId;
}
