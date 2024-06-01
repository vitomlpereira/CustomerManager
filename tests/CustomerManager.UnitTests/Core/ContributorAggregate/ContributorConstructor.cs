using CustomerService.Core.CustomerAggregate;
using Xunit;

namespace CustomerService.UnitTests.Core.CustomerAggregate;

public class ContributorConstructor
{
  private readonly string _testName = "test name";
  private Customer? _testContributor;

  private Customer CreateContributor()
  {
    return new Customer(_testName);
  }

  [Fact]
  public void InitializesName()
  {
    _testContributor = CreateContributor();

    Assert.Equal(_testName, _testContributor.Name);
  }
}
