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
    public class GetBooksAllQueryHandler : IRequestHandler<GetBooksAllQuery, List<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksAllQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> Handle(GetBooksAllQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.GetAllAsync();
            return result;
        }
    }
}
