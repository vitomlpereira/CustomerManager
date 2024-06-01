using FastEndpoints;
using Ardalis.Result;
using MediatR;
using CustomerService.Web.Endpoints.CustomerEndpoints;
using CustomerService.UseCases.Customer.Delete;

namespace CustomerService.Web.CustomerEndpoints;

/// <summary>
/// Delete a Contributor.
/// </summary>
public class Delete(IMediator _mediator) : Endpoint<DeleteCustomerRequest>
{
  public override void Configure()
  {
    Delete(DeleteCustomerRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteCustomerRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteCustomerCommand(request.CustomerId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
    // TODO: Handle other issues as needed
  }
}
