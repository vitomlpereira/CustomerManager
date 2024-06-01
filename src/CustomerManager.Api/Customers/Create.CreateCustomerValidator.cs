using CustomerService.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace CustomerService.Web.Endpoints.CustomerEndpoints;

public class CreateCustomerValidator : Validator<CreateCustomerRequest>
{
  public CreateCustomerValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }
}
