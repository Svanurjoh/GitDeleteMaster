using System;
using System.Collections.Generic;
using LibraryApi.Models.DTOModels;
using LibraryApi.Models.ViewModels;

namespace LibraryApi.Services
{
    public interface IBookService
    {
        void BooksLoadJson();
        IEnumerable<BookDTO> GetAllBooks();
        BookDTO GetBookById(int bookId);
        void AddBook(BookViewModel newBook);
        void DeleteBookById(int bookId);
        void EditBook(BookViewModel updateBook, int bookId);
    }
}
