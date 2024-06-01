using Ardalis.Result;
using CommonLibrary.Events;
using MediatR;

namespace CommonLibrary;

public class EventSourceDispacher : IEventSourceDispatcher
{
  public Task SaveEvent<T>(ICommand<Result<T>> command)
  {
    return Task.CompletedTask;
  }
}

