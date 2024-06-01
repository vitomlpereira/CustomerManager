using CommonLibrary;
using CustomerService.UseCases.Customer.List;
using CustomerService.Web.Endpoints.CustomerEndpoints;
using FastEndpoints;

namespace CustomerService.Web.CustomerEndpoints;

/// <summary>
/// List all Customers
/// </summary>
public class List(IEventPublisher _publisher) : EndpointWithoutRequest<CustomerListResponse>
{
  public override void Configure()
  {
    Get("/Customers");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _publisher.SendQuery(new ListCustomerQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new CustomerListResponse
      {
        Customers = result.Value.Select(c => new Customer(c.Id, c.Name, c.CompanyName)).ToList()
      };
    }
  }
}
