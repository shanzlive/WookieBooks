using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WookieBooks.Application.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
