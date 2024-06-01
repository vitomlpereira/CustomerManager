using FastEndpoints;
using FluentValidation;

namespace CustomerService.Web.Endpoints.CustomerEndpoints;

public class GetCustomerByIdValidator : Validator<GetCustomerByIdRequest>
{
  public GetCustomerByIdValidator()
  {
   
  }
}
