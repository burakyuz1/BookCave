using BookCave.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        private readonly static int maxTitleLength = 20;
        private readonly static int maxDescriptionLength = 255;
        private readonly static int maxCityOrCountryLength = 40;
        private readonly static int maxPhoneNumberLength = 15;
        private readonly string nullOrEmptyMessage = "This field is required";
        private readonly string maxTitleLengthMessage = $"This field can be maximum {maxTitleLength} characters";
        private readonly string maxDescriptionLengthMessage = $"This field can be maximum {maxDescriptionLength} characters";
        private readonly string maxCityOrCountryLengthMessage = $"This field can be maximum {maxCityOrCountryLength} characters"; 
        private readonly string maxPhoneNumberLengthMessage = $"This field can be maximum {maxPhoneNumberLength} characters";

        public ContactValidator()
        {
            RuleFor(x => x.AddressTitle)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .MaximumLength(20).WithMessage(maxTitleLengthMessage);

            RuleFor(x => x.AddressDescription)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .MaximumLength(255).WithMessage(maxDescriptionLengthMessage);

            RuleFor(x => x.Country)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .MaximumLength(40).WithMessage(maxCityOrCountryLengthMessage);

            RuleFor(x => x.City)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .MaximumLength(40).WithMessage(maxCityOrCountryLengthMessage);

            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .MaximumLength(15).WithMessage(maxPhoneNumberLengthMessage);
        }
    }
}
