using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WookieBooks.Application.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
