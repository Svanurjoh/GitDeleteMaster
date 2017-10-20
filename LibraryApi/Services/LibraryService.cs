using System.Collections.Generic;
using LibraryApi.Models.DTOModels;
using LibraryApi.Models.EntityModels;
using LibraryApi.Repositories;

namespace LibraryApi.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _repo;

        public LibraryService(ILibraryRepository repo)
        {
            _repo = repo;
        }

        public void BooksLoadJson()
        {
            _repo.BooksLoadJson();
        }

        public void PersonsLoadJson()
        {
            _repo.PersonsLoadJson();
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            return _repo.GetAllBooks();
        }

        public IEnumerable<PersonDTO> GetAllPersons()
        {
            return _repo.GetAllPersons();
        }
    }
}