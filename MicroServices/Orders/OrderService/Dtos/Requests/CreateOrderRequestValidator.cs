using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace OrderService.Dtos.Requests
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(req => req.AddressId).NotEmpty();
            RuleFor(req => req.ProductId).NotEmpty();
            RuleFor(req => req.CustomerId).NotEmpty();
            RuleFor(req => req.Price).NotEmpty().GreaterThan(0);
            RuleFor(req => req.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(req => req.Status).NotEmpty().MinimumLength(2).MaximumLength(200);
        }
    }
}