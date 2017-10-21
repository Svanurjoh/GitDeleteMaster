using System;
using LibraryApi.Models.Exceptions;
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
            try
            {
                var book = _bookService.GetBookById(bookId);
                return Ok(book);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpPost("books")]
        public IActionResult AddBook([FromBody] BookViewModel newBook)
        {
            if(!ModelState.IsValid) { return StatusCode(412); }
            _bookService.AddBook(newBook);

            return StatusCode(201);
        }

        [HttpDelete("books/{bookId}")]
        public IActionResult DeleteBookById(int bookId)
        {
            try
            {
                _bookService.DeleteBookById(bookId);
                return StatusCode(204);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpPut("books/{bookId}")]
        public IActionResult EditBook([FromBody] BookViewModel updateBook, int bookId)
        {
            try
            {
                _bookService.EditBook(updateBook, bookId);
                return StatusCode(204);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("users/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                return Ok(user);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpPost("users")]
        public IActionResult AddUser([FromBody] PersonViewModel newUser)
        {
            if(!ModelState.IsValid) { return StatusCode(204); }
            _userService.AddUser(newUser);
            
            return StatusCode(201);
        }

        [HttpDelete("users/{userId}")]
        public IActionResult DeleteUserById(int userId)
        {
            try
            {
                _userService.DeleteUserById(userId);
                return StatusCode(204);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }            
        }

        [HttpPut("users/{userId}")]
        public IActionResult EditUser([FromBody] PersonViewModel updateUser, int userId)
        {
            try
            {
                _userService.EditUser(updateUser, userId);
                return StatusCode(204);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpGet("users/{userId}/books")]
        public IActionResult GetUserBooks(int userId)
        {
            try
            {
                var user = _bookService.GetBooksOnLoadForUser(userId);
                return Ok(user);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpPost("users/{userId}/books/{bookId}")]
        public IActionResult AddNewLoanToUser(int userId, int bookId)
        {
            try
            {
                _bookService.AddNewLoan(userId, bookId);
                return StatusCode(201);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpDelete("users/{userId}/books/{bookId}")]
        public IActionResult ReturnUsersBook(int userId, int bookId)
        {
            try
            {
                _bookService.DeleteLoan(userId, bookId);
                return StatusCode(204);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(LoanNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpPut("users/{userId}/books/{bookId}")]
        public IActionResult UpdateBookLoanInformation(int userId, int bookId)
        {
            try
            {
                _bookService.ExtendLoanOnBook(userId, bookId);
                return StatusCode(200);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(LoanNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        /*[HttpGet("users/{userId}/reviews")]
        public IActionResult GetUserReviews(int userId)
        {
            try
            {
                var userReviews = _reviewService.GetUserReviews(userId);
                return Ok(userReviews);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpGet("users/{userId}/reviews/{bookId}")]
        public IActionResult GetBookReview(int userId, int bookId)
        {
            try
            {
                var bookReview = _reviewService.GetBookReview(userId, bookId);
                return Ok(bookReview);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpPost("users/{userId}/reviews/{bookId}")]
        public IActionResult AddNewReview(int userId, int bookId)
        {
            try
            {
                _reviewService.AddNewReview(userId, bookId);
                return StatusCode(201);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpDelete("users/{userId}/reviews/{bookId}")]
        public IActionResult RemoveReviewFromBook(int userId, int bookId)
        {
            try
            {
                _reviewService.RemoveReviewFromBook(userId, bookId);
                return StatusCode(204);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpPut("users/{userId}/reviews/{bookId}")]
        public IActionResult UpdateBookReview(int userId, int bookId)
        {
            try
            {
                _reviewService.UpdateBookReview(userId, bookId);
                return StatusCode(200);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpGet("users/{userId}/recommendation")]
        public IActionResult GetBooksRecommendation(int userId)
        {
            try
            {
                var books = _recommendationService.GetBooksRecommendation(userId);
                return Ok(books);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpGet("books/reviews")]
        public IActionResult GetAllReviews()
        {
            var reviews = _reviewService.GetAllReviews();

            return Ok(reviews);
        }

        [HttpGet("books/{bookId}/reviews")]
        public IActionResult GetAllReviewsForBook(int bookId)
        {
            try
            {
                var bookReviews = _reviewService.GetAllReviewsForBook(bookId);
                
                return Ok(bookReviews);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpGet("books/{bookId}/reviews/{userId}")]
        public IActionResult GetUserReviewOfBook(int bookId, int userId)
        {
            try
            {
                var userReviews = _reviewService.GetUserReviewOfBook(bookId, userId);
                
                return Ok(userReviews);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpPut("books/{bookId}/reviews/{userId}")]
        public IActionResult UpdateUserReviewOfBook(int bookId, int userId)
        {
            try
            {
                _reviewService.UpdateUserReviewOfBook(bookId, userId);
                
                return StatusCode(201);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }

        [HttpDelete("books/{bookId}/reviews/{userId}")]
        public IActionResult RemoveUserReviewOfBook(int bookId, int userId)
        {
            try
            {
                _reviewService.RemoveUserReviewOfBook(bookId, userId);
                
                return StatusCode(204);
            }
            catch(PersonNotFoundException msg)
            {
                return NotFound(msg);
            }
            catch(BookNotFoundException msg)
            {
                return NotFound(msg);
            }
        }*/
    }
}
