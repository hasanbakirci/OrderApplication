using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CustomerService.Dtos.Requests
{
    public class CreateCustomerRequestValidator :AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(req => req.AddressId).NotEmpty().GreaterThan(0);
            RuleFor(req => req.Email).NotEmpty().EmailAddress();
            RuleFor(req => req.Name).NotEmpty().MinimumLength(2).MaximumLength(200);
        }
    }
}