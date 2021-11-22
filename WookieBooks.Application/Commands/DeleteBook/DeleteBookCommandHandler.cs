using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WookieBooks.Application.Exceptions;
using WookieBooks.Domain.Interfaces;

namespace WookieBooks.Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            // Check whether the id is valid 
            var result = await _bookRepository.GetByIdAsync(request.Id);
            if(result is null)
            {
                throw new BookNotExistException("Book not found");
            }
            await _bookRepository.DeleteAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
