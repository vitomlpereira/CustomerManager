namespace CustomerService.Web.Endpoints.CustomerEndpoints;

public record DeleteCustomerRequest
{
  public const string Route = "/Customers/{customerId:Guid}";
  public static string BuildRoute(Guid customerId) => Route.Replace("{customerId:Guid}", customerId.ToString());

  public Guid CustomerId { get; set; }
}
