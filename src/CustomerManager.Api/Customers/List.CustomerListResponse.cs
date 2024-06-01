using CustomerService.Web.CustomerEndpoints;

namespace CustomerService.Web.Endpoints.CustomerEndpoints;

public class CustomerListResponse
{
  public List<Customer> Customers { get; set; } = [];
}
