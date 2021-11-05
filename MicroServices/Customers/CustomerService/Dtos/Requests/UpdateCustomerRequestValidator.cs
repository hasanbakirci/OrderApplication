using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CustomerService.Dtos.Requests
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
            RuleFor(req => req.AddressId).GreaterThan(0);
            RuleFor(req => req.Email).EmailAddress();
            RuleFor(req => req.Name).MinimumLength(3).MaximumLength(200);
        }
    }
}