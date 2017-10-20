using System;
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

        [HttpGet("")]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();

            return Ok(books);
        }

        [HttpGet("persons")]
        public IActionResult GetAllPersons()
        {
            var persons = _userService.GetAllPersons();
            return Ok(persons);
        }
    }

}
