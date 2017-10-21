using System.Collections.Generic;
using LibraryApi.Models.DTOModels;
using LibraryApi.Models.EntityModels;
using LibraryApi.Models.ViewModels;
using LibraryApi.Repositories;

namespace LibraryApi.Services
{
    public class BookService : IBookService
    {
        private readonly ILibraryRepository _repo;

        public BookService(ILibraryRepository repo)
        {
            _repo = repo;
        }

        public void BooksLoadJson()
        {
            _repo.BooksLoadJson();
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            return _repo.GetAllBooks();
        }

        public BookDTO GetBookById(int bookId)
        {
            return _repo.GetBookById(bookId);
        }

        public void AddBook(BookViewModel newBook)
        {
            _repo.AddBook(newBook);
        }

        public void DeleteBookById(int bookId)
        {
            _repo.DeleteBookById(bookId);
        }

        public void EditBook(BookViewModel updateBook, int bookId)
        {
            _repo.EditBook(updateBook, bookId);
        }

        public IEnumerable<BookDTO> GetBooksOnLoadForUser(int userId)
        {
            return _repo.GetBooksOnLoadForUser(userId);
        }

        public void AddNewLoan(int userId, int bookId)
        {
            _repo.AddNewLoan(userId, bookId);
        }

        public void DeleteLoan(int userId, int bookId)
        {
            _repo.DeleteLoan(userId, bookId);
        }

        public void ExtendLoanOnBook(int userId, int bookId)
        {
            _repo.ExtendLoanOnBook(userId, bookId);
        }
    }
}