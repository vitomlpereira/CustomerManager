using FastEndpoints;
using FluentValidation;

namespace CustomerService.Web.Endpoints.CustomerEndpoints;


public class DeleteCustomerValidator : Validator<DeleteCustomerRequest>
{
  public DeleteCustomerValidator()
  {
    RuleFor(x => x.CustomerId)
    .NotEmpty();
  }
}
