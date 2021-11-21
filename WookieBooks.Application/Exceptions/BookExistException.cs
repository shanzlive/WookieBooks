using System;
using System.Collections.Generic;
using System.Text;

namespace WookieBooks.Application.Exceptions
{
    public class BookExistException : Exception
    {
        public BookExistException(string message) : base(message)
        {
        }
    }
}
