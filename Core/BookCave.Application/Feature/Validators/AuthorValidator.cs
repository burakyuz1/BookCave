using BookCave.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        private readonly static int maxLength = 100;
        private readonly string nullOrEmptyMessage = "This field is required";
        private readonly string maxLengthMessage = $"This field can be maximum {maxLength} characters";
        public AuthorValidator()
        {
            RuleFor(x => x.FullName)
            .NotNull().WithMessage(nullOrEmptyMessage)
            .NotEmpty().WithMessage(nullOrEmptyMessage)
            .MaximumLength(maxLength).WithMessage(maxLengthMessage);
        }
    }
}
