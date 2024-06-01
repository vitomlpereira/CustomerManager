using Ardalis.Result;
using CommonLibrary;
using CustomerService.UseCases.Customer.Get;
using CustomerService.UseCases.Customer.Update;
using CustomerService.Web.Endpoints.CustomerEndpoints;
using FastEndpoints;

namespace CustomerService.Web.CustomerEndpoints;

public class Update(IEventPublisher _publisher) : Endpoint<UpdateCustomerRequest, UpdateCustomerResponse>
{
  public override void Configure()
  {
    Put(UpdateCustomerRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync( UpdateCustomerRequest request, CancellationToken cancellationToken)
  {
    var result = await _publisher.SendCommand(new UpdateCustomerCommand(request.CustomerId, request.Name!));

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetCustomerQuery(request.CustomerId);

    var queryResult = await _publisher.SendQuery(query);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateCustomerResponse(new Customer(dto.Id, dto.Name, dto.CompanyName));
      return;
    }
  }
}
