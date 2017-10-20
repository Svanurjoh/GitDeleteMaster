using System.Collections.Generic;
using LibraryApi.Models.DTOModels;

namespace LibraryApi.Repositories
{
    public interface ILibraryRepository
    {
        void PersonsLoadJson();
        void BooksLoadJson();
        IEnumerable<BookDTO> GetAllBooks();
        IEnumerable<PersonDTO> GetAllPersons();
    }
}