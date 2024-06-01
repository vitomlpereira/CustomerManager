using System.ComponentModel.DataAnnotations;

namespace CustomerService.Web.Endpoints.CustomerEndpoints;

public class UpdateCustomerRequest
{
  public const string Route = "/Customers/{customerId:Guid}";
  public static string BuildRoute(Guid customerId) => Route.Replace("{customerId:Guid}", customerId.ToString());

  [Required]
  public Guid CustomerId { get; set; }
   
  [Required]
  public string? Name { get; set; }
  [Required]
  public string? CompanyName { get; set; }
}
