using BookCave.Domain.Entities;
using FluentValidation;

namespace BookCave.Application.Feature.Validators
{
    class OrderDetailValidator : AbstractValidator<OrderDetail>
    {
        private readonly static int maxLength = 255;
        private readonly string nullOrEmptyMessage = "This field is required";
        private readonly string maxLengthMessage = $"This field can be maximum {maxLength} characters";

        public OrderDetailValidator()
        {
            RuleFor(x => x.UnitPrice)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .LessThanOrEqualTo(0).WithMessage("Price can not be negative or zero.");

            RuleFor(x => (int)x.Quantity)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .InclusiveBetween(0, maxLength).WithMessage(maxLengthMessage);
        }
    }
}
