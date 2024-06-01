using System.ComponentModel.DataAnnotations;

namespace CustomerService.Web.Endpoints.CustomerEndpoints;

public class GetCustomerByIdRequest
{
  public const string Route = "/Customers/{customerId:Guid}";
  public static string BuildRoute(Guid customerId) => Route.Replace("{customerId:Guid}", customerId.ToString());

  [Required]
  public Guid CustomerId { get; set; }

}
