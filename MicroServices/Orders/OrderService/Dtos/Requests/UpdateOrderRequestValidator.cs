using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace OrderService.Dtos.Requests
{
    public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
            RuleFor(req => req.Price).GreaterThan(0);
            RuleFor(req => req.Quantity).GreaterThan(0);
            RuleFor(req => req.Status).MinimumLength(2).MaximumLength(200);
            RuleFor(req => req.AddressId).GreaterThan(0);
        }
    }
}