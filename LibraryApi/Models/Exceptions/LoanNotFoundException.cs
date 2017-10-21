using System;

namespace LibraryApi.Models.Exceptions
{
    public class LoanNotFoundException : Exception
    {
        public LoanNotFoundException() {}
        public LoanNotFoundException(string message) : base(message) {}
    }
}