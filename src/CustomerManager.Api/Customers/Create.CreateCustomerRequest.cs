using System.ComponentModel.DataAnnotations;

namespace CustomerService.Web.Endpoints.CustomerEndpoints;

public class CreateCustomerRequest
{
  public const string Route = "/Customers";

  [Required]
  public string? Name { get; set; }
  public string? CompanyName { get; set; }
}
