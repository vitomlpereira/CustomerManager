using Ardalis.Result;
using CommonLibrary;
using CustomerService.UseCases.Customer.Get;
using CustomerService.Web.Endpoints.CustomerEndpoints;
using FastEndpoints;

namespace CustomerService.Web.CustomerEndpoints;

public class GetById(IEventPublisher _publisher) : Endpoint<GetCustomerByIdRequest, Customer>
{
  public override void Configure()
  {
    Get(GetCustomerByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetCustomerByIdRequest request, CancellationToken cancellationToken)
  {
    var command = new GetCustomerQuery(request.CustomerId);

    var result = await _publisher.SendQuery(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new Customer(result.Value.Id, result.Value.Name, result.Value.CompanyName);
    }
  }
}
