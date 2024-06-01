using Ardalis.Result;
using CommonLibrary.Events;
using MediatR;

namespace CommonLibrary;

public class EventPublisher : IEventPublisher
{
  private readonly IMediator _mediator;
  private readonly IEventSourceDispatcher _eventSourceDispatcher;

  public EventPublisher(IMediator mediator,
                        IEventSourceDispatcher eventSourceDispatcher)
  {
    _mediator = mediator;
    _eventSourceDispatcher = eventSourceDispatcher;
  }

    
  public async Task<Result<T>> SendCommand<T>(ICommand<Result<T>> command)
  {
    var result = _mediator.Send(command);

    if (result.IsCompletedSuccessfully)
    {
      await _eventSourceDispatcher.SaveEvent(command);
    }

    return result.Result;

  }

  public Task<Result<T>> SendQuery<T>(IQuery<Result<T>> query)
  {
    return _mediator.Send(query);
  }
}

