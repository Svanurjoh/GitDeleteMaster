using System;
using System.Collections.Generic;
using LibraryApi.Models.DTOModels;

namespace LibraryApi.Services
{
    public interface IBookService
    {
        void BooksLoadJson();
        IEnumerable<BookDTO> GetAllBooks();
    }
}
