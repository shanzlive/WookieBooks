using System;
using System.Collections.Generic;
using System.Text;

namespace WookieBooks.Application.Exceptions
{
    public class BookNotExistException : Exception
    {
        public BookNotExistException(string message) : base(message)
        {
        }
    }
}
