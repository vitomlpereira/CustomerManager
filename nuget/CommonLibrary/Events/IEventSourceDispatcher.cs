using Ardalis.Result;

namespace CommonLibrary.Events;

public interface IEventSourceDispatcher
{
  Task SaveEvent<T>(ICommand<Result<T>> command);
}
