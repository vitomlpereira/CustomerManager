using Ardalis.SharedKernel;
using CustomerService.Core.CustomerAggregate;
using CustomerService.UseCases.Customer.Create;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CustomerService.UnitTests.UseCases.Contributors;

public class CreateContributorHandlerHandle
{
  private readonly string _testName = "test name";
  private readonly IRepository<Customer> _repository = Substitute.For<IRepository<Customer>>();
  private CreateCustomerHandler _handler;

  public CreateContributorHandlerHandle()
  {
      _handler = new CreateContributorHandler(_repository);
  }

  private Customer CreateContributor()
  {
    return new Customer(_testName);
  }

  [Fact]
  public async Task ReturnsSuccessGivenValidName()
  {
    _repository.AddAsync(Arg.Any<Customer>(), Arg.Any<CancellationToken>())
      .Returns(Task.FromResult(CreateContributor()));
    var result = await _handler.Handle(new CreateCustomerCommand(_testName, null), CancellationToken.None);

    result.IsSuccess.Should().BeTrue();    
  }
}
