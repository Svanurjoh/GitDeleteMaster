using System;

namespace LibraryApi.Models.Exceptions
{
    public class PersonNotFoundException : Exception
    {
        public PersonNotFoundException() {}
        public PersonNotFoundException(string message) : base(message) {}
    }
}