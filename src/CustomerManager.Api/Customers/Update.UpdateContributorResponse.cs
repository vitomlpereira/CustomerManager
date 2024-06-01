using CustomerService.Web.CustomerEndpoints;

namespace CustomerService.Web.Endpoints.CustomerEndpoints;

public class UpdateCustomerResponse(Customer customer)
{
  public Customer Customer { get; set; } = customer;
}
