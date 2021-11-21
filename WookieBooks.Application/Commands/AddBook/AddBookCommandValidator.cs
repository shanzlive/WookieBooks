using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WookieBooks.Application.Commands.AddBook
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        
        public AddBookCommandValidator()
        {
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
