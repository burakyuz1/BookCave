using BookCave.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Validators
{
    class OrderDetailValidator : AbstractValidator<OrderDetail>
    {
        private readonly static int maxLength = 50;
        private readonly string nullOrEmptyMessage = "This field is required";
        private readonly string maxLengthMessage = $"This field can be maximum {maxLength} characters";

        public OrderDetailValidator()
        {            
            RuleFor(x => x.UnitPrice)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .InclusiveBetween(0, 255).WithMessage($"Quantity can be between 0 and 255");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .NotNull().WithMessage(nullOrEmptyMessage);

        }
    }
}
