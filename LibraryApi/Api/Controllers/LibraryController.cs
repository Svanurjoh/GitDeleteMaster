using System;
using LibraryApi.Models.ViewModels;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/library")]
    public class LibraryController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IRecommendationService _recommendationService;
        private readonly IReportingService _reportingService;
        private readonly IReviewService _reviewService;

        public LibraryController(IBookService bookService, IUserService userService, IRecommendationService recommendationService,
                                    IReportingService reportingService, IReviewService reviewService)
        {
            _bookService = bookService;
            _bookService.BooksLoadJson();

            _userService = userService;
            _userService.PersonsLoadJson();

            _recommendationService = recommendationService;
            _reportingService = reportingService;
            _reviewService = reviewService;
        }

        [HttpGet("books")]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();

            return Ok(books);
        }

        [HttpGet("books/{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
            var book = _bookService.GetBookById(bookId);

            return Ok(book);
        }

        [HttpPost("books")]
        public IActionResult AddBook([FromBody] BookViewModel newBook)
        {
            if(!ModelState.IsValid) {return StatusCode(412);}
            _bookService.AddBook(newBook);

            return StatusCode(201);
        }

        [HttpDelete("books/{bookId}")]
        public IActionResult DeleteBookById(int bookId)
        {
            _bookService.DeleteBookById(bookId);

            return StatusCode(204);
        }

        [HttpGet("persons")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }


    }

}
