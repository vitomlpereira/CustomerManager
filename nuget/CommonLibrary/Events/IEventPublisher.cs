using Ardalis.Result;

namespace CommonLibrary;

public interface IEventPublisher
{
  Task<Result<T>> SendCommand<T>(ICommand<Result<T>> command);
  Task<Result<T>> SendQuery<T>(IQuery<Result<T>> query);

}
