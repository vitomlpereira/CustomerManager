using CommonLibrary.Entity;

namespace CustomerService.Core.CustomerAggregate;

public class Customer(string name, string companyName) : EntityBase<Guid>, IAggregateRoot
{
  public string Name { get; private set; } = name;
  public string CompanyName { get; private set; } = companyName;

  public void UpdateName(string updatedName)
  {
    Name = updatedName;
  }

}
