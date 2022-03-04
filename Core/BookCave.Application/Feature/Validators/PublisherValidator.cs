using BookCave.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Validators
{
    public class PublisherValidator:AbstractValidator<Publisher>
    {
        private readonly static int maxLength = 50;
        private readonly string nullOrEmptyMessage = "This field is required";
        private readonly string maxLengthMessage = $"This field can be maximum {maxLength} characters";
        public PublisherValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .MaximumLength(50).WithMessage(maxLengthMessage);
        }
    }
}
