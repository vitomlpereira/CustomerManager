using Ardalis.SharedKernel;
using CustomerService.Core.CustomerAggregate;
using CustomerService.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace CustomerService.UnitTests.Core.Services;

public class DeleteContributorService_DeleteContributor
{
  private readonly IRepository<Customer> _repository = Substitute.For<IRepository<Customer>>();
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  private readonly ILogger<DeleteCustomerService> _logger = Substitute.For<ILogger<DeleteCustomerService>>();

  private readonly DeleteCustomerService _service;

  public DeleteContributorService_DeleteContributor()
  {
    _service = new DeleteCustomerService(_repository, _mediator, _logger);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindContributor()
  {
    var result = await _service.DeleteContributor(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}
