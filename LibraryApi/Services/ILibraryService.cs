using System;
using System.Collections.Generic;
using LibraryApi.Models.DTOModels;

namespace LibraryApi.Services
{
    public interface ILibraryService
    {
        void BooksLoadJson();
        void PersonsLoadJson();
        IEnumerable<BookDTO> GetAllBooks();
        IEnumerable<PersonDTO> GetAllPersons();
    }
}
