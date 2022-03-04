using BookCave.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Feature.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        private readonly static int maxTitleLength = 30;
        private readonly static int maxContentLength = 255;
        private readonly string nullOrEmptyMessage = "This field is required";
        private readonly string maxTitleLengthMessage = $"This field can be maximum {maxTitleLength} characters";
        private readonly string maxContentLengthMessage = $"This field can be maximum {maxContentLength} characters";

        public CommentValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage(nullOrEmptyMessage)
                .NotEmpty().WithMessage(nullOrEmptyMessage)
                .MaximumLength(maxTitleLength).WithMessage(maxTitleLengthMessage);

            RuleFor(x => x.Content)
               .NotNull().WithMessage(nullOrEmptyMessage)
               .NotEmpty().WithMessage(nullOrEmptyMessage)
               .MaximumLength(maxContentLength).WithMessage(maxContentLengthMessage);
        }
    }
}
