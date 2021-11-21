using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WookieBooks.Domain.Models;

namespace WookieBooks.Application.Queries
{
    public class GetBooksAllQuery : IRequest<List<Book>>
    {
    }
}
