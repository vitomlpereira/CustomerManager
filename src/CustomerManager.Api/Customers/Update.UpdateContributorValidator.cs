using CustomerService.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace CustomerService.Web.Endpoints.CustomerEndpoints;


public class UpdateCustomerValidator : Validator<UpdateCustomerRequest>
{
  public UpdateCustomerValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    
  }
}
