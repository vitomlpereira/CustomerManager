using MediatR;

namespace CommonLibrary;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
