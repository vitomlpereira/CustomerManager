using CustomerService.UseCases.Customer.Create;
using CustomerService.Web.Endpoints.CustomerEndpoints;
using FastEndpoints;

namespace CustomerService.Web.CustomerEndpoints;

/// <summary>
/// Create a new Customer
/// </summary>
/// <remarks>
/// Creates a new Customer given a name.
/// </remarks>
public class Create(CommonLibrary.IEventPublisher _publisher) : Endpoint<CreateCustomerRequest, CreateCustomerResponse>
{
  public override void Configure()
  {
    Post(CreateCustomerRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
  {
    var result = await _publisher.SendCommand(new CreateCustomerCommand(request.Name!, request.CompanyName!));

    if(result.IsSuccess)
    {
      Response = new CreateCustomerResponse(result.Value, request.Name!,request.CompanyName!);
      return;
    }
    
  }
}
