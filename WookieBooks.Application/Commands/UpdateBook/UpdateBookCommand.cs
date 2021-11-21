using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WookieBooks.Application.Commands.UpdateBook

{
    public class UpdateBookCommand : IRequest
    {
        public UpdateBookCommand(int id, string title, string description, string author, string coverImage, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            CoverImage = coverImage;
            Price = price;
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get;}
        public string Author { get;}
        public string CoverImage { get;  }
        public decimal Price { get; }

    }
}
