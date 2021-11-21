using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WookieBooks.Domain.Interfaces;
using WookieBooks.Domain.Models;

namespace WookieBooks.Application.Queries
{
    public class GetBooksByTitleOrAuthorQueryHandler : IRequestHandler<GetBooksByTitleOrAuthorQuery, List<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksByTitleOrAuthorQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> Handle(GetBooksByTitleOrAuthorQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetByTitleOrAuthorAsync(request.Title, request.Author, cancellationToken);
        }
    }
}
