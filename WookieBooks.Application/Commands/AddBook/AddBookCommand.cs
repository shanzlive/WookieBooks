using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WookieBooks.Application.Commands.AddBook
{
    public class AddBookCommand : IRequest
    {
        public AddBookCommand(string title, string description, string author, string coverImage, decimal price)
        {
            Title = title;
            Description = description;
            Author = author;
            CoverImage = coverImage;
            Price = price;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }

    }
}
