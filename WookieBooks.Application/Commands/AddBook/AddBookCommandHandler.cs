using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WookieBooks.Application.Exceptions;
using WookieBooks.Domain.Interfaces;
using WookieBooks.Domain.Models;

namespace WookieBooks.Application.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Unit> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            // Check whether a book exist with same author and title 
            var result = await _bookRepository.GetByTitleOrAuthorAsync(request.Title, request.Author);
            if (result.Count > 0)
            {
                throw new BookExistException("Book Exist");
            }
            await _bookRepository.AddAsync(new Book()
            {
                Author = request.Author,
                CoverImage = request.CoverImage,
                Description = request.Description,
                Price = request.Price,
                Title = request.Title
            });
            return Unit.Value;
        }
    }
}
