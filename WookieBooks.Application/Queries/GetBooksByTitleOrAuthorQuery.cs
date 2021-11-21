using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WookieBooks.Domain.Models;

namespace WookieBooks.Application.Queries
{
    public class GetBooksByTitleOrAuthorQuery : IRequest<List<Book>>
    {
        public GetBooksByTitleOrAuthorQuery(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public string Title { get; set; }
        public string Author { get; set; }
    }
}
