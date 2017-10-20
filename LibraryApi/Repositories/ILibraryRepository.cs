using System.Collections.Generic;
using LibraryApi.Models.DTOModels;
using LibraryApi.Models.ViewModels;

namespace LibraryApi.Repositories
{
    public interface ILibraryRepository
    {
        void PersonsLoadJson();
        void BooksLoadJson();
        IEnumerable<BookDTO> GetAllBooks();
        BookDTO GetBookById(int bookId);
        void AddBook(BookViewModel newBook);
        void DeleteBookById(int bookId);
        IEnumerable<PersonDTO> GetAllUsers();
        PersonDTO GetUserById(int userId);
        void AddUser(PersonViewModel newUser);
        void DeleteUserById(int userId);
    }
}