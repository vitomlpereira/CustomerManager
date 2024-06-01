using MediatR;

namespace CommonLibrary;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
