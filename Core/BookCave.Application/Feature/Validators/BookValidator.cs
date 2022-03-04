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
        private readonly static int maxLength = 50;
        private readonly string nullOrEmptyMessage = "This field is required";
        private readonly string maxLengthMessage = $"This field can be maximum {maxLength} characters";

        public BookValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .MaximumLength(maxLength).WithMessage(maxLengthMessage);

            RuleFor(x => x.PublishYear)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .InclusiveBetween(1600, DateTime.Now.Year).WithMessage($"Publish year can be between 1600 and {DateTime.Now.Year}.");
        }
    }
}
