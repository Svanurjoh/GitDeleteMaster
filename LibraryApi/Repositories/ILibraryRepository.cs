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
        void EditBook(BookViewModel updateBook, int bookId);
        void EditUser(PersonViewModel updateUser, int userId);
        IEnumerable<BookDTO> GetBooksOnLoadForUser(int userId);
        void AddNewLoan(int userId, int bookId);
        void DeleteLoan(int userId, int bookId);
        void ExtendLoanOnBook(int userId, int bookId);
    }
}