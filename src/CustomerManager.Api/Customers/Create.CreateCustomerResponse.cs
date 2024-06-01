namespace CustomerService.Web.Endpoints.CustomerEndpoints;

public class CreateCustomerResponse(Guid id, string name, string companyName)
{
  public Guid Id { get; set; } = id;
  public string Name { get; set; } = name;
  public string CompanyName { get; set; } = companyName;
}
