using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WookieBooks.Application.Exceptions;
using WookieBooks.Domain.Interfaces;
using WookieBooks.Domain.Models;

namespace WookieBooks.Application.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.GetByIdAsync(request.Id);
            if (result is null)
            {
                throw new BookNotExistException("Book not found");
            }
            await _bookRepository.UpdateAsync(new Book(request.Id, request.Title, request.Description, request.Author, request.CoverImage, request.Price));
            return Unit.Value;
        }
    }
}
