using System;

namespace LibraryApi.Models.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException() {}
        public BookNotFoundException(string message) : base(message) {}
    }
}