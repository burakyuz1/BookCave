using BookCave.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        private readonly static int maxNameLength = 50;
        private readonly string nullOrEmptyMessage = "This field is required";
        private readonly string maxNameLengthMessage = $"This field can be maximum {maxNameLength} characters";

        private readonly static int maxDetailLength = 500;
        private readonly string maxDetailLengthMessage = $"This field can be maximum {maxDetailLength} characters";

        private readonly static int minUnitPrice = 1;
        private readonly string minUnitPriceMessage = $"This field can be greater then {minUnitPrice}";

        private readonly static int minStock = 1;
        private readonly string minStockMessage = $"This field can be greater then {minStock}";
        public BookValidator()
        {
            RuleFor(x => x.ISBN)
               .NotNull().WithMessage(nullOrEmptyMessage)
               .NotEmpty().WithMessage(nullOrEmptyMessage)
               .MaximumLength(13).WithMessage("ISBN should be 13 digit")
               .MinimumLength(13).WithMessage("ISBN should be 13 digit");

            RuleFor(x => x.Name)
               .NotNull().WithMessage(nullOrEmptyMessage)
               .NotEmpty().WithMessage(nullOrEmptyMessage)
               .MaximumLength(maxNameLength).WithMessage(maxNameLengthMessage);

            RuleFor(x => x.Name)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .NotEmpty().WithMessage(nullOrEmptyMessage)

                .MaximumLength(maxNameLength).WithMessage(maxNameLengthMessage);


            RuleFor(x => x.PublishYear)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .InclusiveBetween(1600, DateTime.Now.Year).WithMessage($"Publish year can be between 1600 and {DateTime.Now.Year}.");

            RuleFor(x => x.Details)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .MaximumLength(maxDetailLength).WithMessage(maxDetailLengthMessage);

            RuleFor(x => (int)x.NumberOfPages)
               .NotNull().WithMessage(nullOrEmptyMessage)
               .NotEmpty().WithMessage(nullOrEmptyMessage)
                .InclusiveBetween(30, ushort.MaxValue).WithMessage($"Number of page should be between 30 and {ushort.MaxValue} ");

            RuleFor(x => x.UnitPrice)
              .NotEmpty().WithMessage(nullOrEmptyMessage)
              .NotNull().WithMessage(nullOrEmptyMessage)
              .LessThan(minUnitPrice).WithMessage(minUnitPriceMessage);

            RuleFor(x => x.Stock)
              .NotEmpty().WithMessage(nullOrEmptyMessage)
              .NotNull().WithMessage(nullOrEmptyMessage)
              .LessThan(minStock).WithMessage(minStockMessage);

            RuleFor(x => x.Status)
             .NotEmpty().WithMessage(nullOrEmptyMessage)
             .NotNull().WithMessage(nullOrEmptyMessage);


        }
    }
}
