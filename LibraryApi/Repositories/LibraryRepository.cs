﻿using System;
using System.Collections.Generic;
using System.IO;
using LibraryApi.Models.EntityModels;
using Newtonsoft.Json;
using System.Linq;
using LibraryApi.Models.DTOModels;
using LibraryApi.Models.ViewModels;
using LibraryApi.Models.Exceptions;

namespace LibraryApi.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly AppDataContext _db;

        public LibraryRepository(AppDataContext db)
        {
            _db = db;
        }

        public void BooksLoadJson()
        {
            if(isDbEmpty("books"))
            {
                using (StreamReader r = new StreamReader("Books.json"))
                {
                    string json = r.ReadToEnd();
                    List<Book> Books = JsonConvert.DeserializeObject<List<Book>>(json);

                    foreach(var b in Books)
                    {
                        _db.Books.Add(new Book{
                            Title = b.Title,
                            AuthorFirstName = b.AuthorFirstName,
                            AuthorLastName = b.AuthorLastName,
                            PublishDate = b.PublishDate,
                            ISBN = b.ISBN
                        });
                    }
                    _db.SaveChanges();
                }
            }
        }

        public void PersonsLoadJson()
        {
            if(isDbEmpty("persons"))
            {
                using (StreamReader r = new StreamReader("Persons.json"))
                {
                    string json = r.ReadToEnd();
                    List<Person> Persons = JsonConvert.DeserializeObject<List<Person>>(json);

                    foreach(var p in Persons)
                    {
                        _db.Persons.Add(new Person{
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Address = p.Address,
                            Email = p.Email
                        });
                        _db.SaveChanges();
                        if(p.LoanedBooks != null)
                        {
                            foreach(var b in p.LoanedBooks)
                            {
                                _db.Loans.Add(new Loans{
                                    PersonId = p.Id,
                                    BookId = b.BookId,
                                    LoanedAt = b.LoanedAt
                                });
                            }
                            _db.SaveChanges();
                        }
                    }
                    _db.SaveChanges();
                }
            } 
        }

        private Boolean isDbEmpty(string database)
        {
            if(database == "books")
            {
                var emptyCheck = (from db in _db.Books
                                  where db.Id == 1
                                  select db).SingleOrDefault();
                if(emptyCheck == null)
                {
                    return true;
                } 
            }
            else if(database == "persons")
            {
                var emptyCheck = (from db in _db.Persons
                                  where db.Id == 1
                                  select db).SingleOrDefault();
                if(emptyCheck == null)
                {
                    return true;
                } 
            }
            return false;                      
        }

        //Books

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var books = (from b in _db.Books
                         select new BookDTO{
                            Title = b.Title,
                            AuthorFirstName = b.AuthorFirstName,
                            AuthorLastName = b.AuthorLastName,
                            PublishDate = b.PublishDate,
                            ISBN = b.ISBN}).ToList();
            return books;
        }

        public BookDTO GetBookById(int bookId)
        {
            var book = (from b in _db.Books
                        where bookId == b.Id
                        select new BookDTO{
                            Title = b.Title,
                            AuthorFirstName = b.AuthorFirstName,
                            AuthorLastName = b.AuthorLastName,
                            PublishDate = b.PublishDate,
                            ISBN = b.ISBN
                        }).SingleOrDefault();

            if(book == null) {throw new BookNotFoundException("Book not found!");}

            return book;
        }

        public void AddBook(BookViewModel newBook)
        {
            var book = new Book{
                Title = newBook.Title,
                AuthorFirstName = newBook.AuthorFirstName,
                AuthorLastName = newBook.AuthorLastName,
                PublishDate = newBook.ReleaseDate,
                ISBN = newBook.ISBN
            };
            _db.Add(book);
            _db.SaveChanges();
        }

        public void DeleteBookById(int bookId)
        {
            var book = (from b in _db.Books
                        where bookId == b.Id
                        select new Book{
                            Id = b.Id,
                            Title = b.Title,
                            AuthorFirstName = b.AuthorFirstName,
                            AuthorLastName = b.AuthorLastName,
                            PublishDate = b.PublishDate,
                            ISBN = b.ISBN
                        }).SingleOrDefault();

            if(book == null) { throw new BookNotFoundException("Book not found!"); }

            _db.Remove(book);
            _db.SaveChanges();
        }

        public void EditBook(BookViewModel updateBook, int bookId)
        {
            var updatedBook = (from b in _db.Books
                            where b.Id == bookId
                            select b).SingleOrDefault();

            if(updatedBook == null) { throw new BookNotFoundException("Book not found!"); }

            updatedBook.Title = updateBook.Title;
            updatedBook.AuthorFirstName = updateBook.AuthorFirstName;
            updatedBook.AuthorLastName = updateBook.AuthorLastName;
            updatedBook.PublishDate = updateBook.ReleaseDate;
            updatedBook.ISBN = updateBook.ISBN;

            _db.SaveChanges();
        }

        //Users

        public IEnumerable<PersonDTO> GetAllUsers()
        {
            var users = (from u in _db.Persons
                           select new PersonDTO{
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Address = u.Address,
                            Email = u.Email}).ToList();
            return users;
        }

        public PersonDTO GetUserById(int userId)
        {
            var user = (from u in _db.Persons
                        where userId == u.Id
                        select new PersonDTO{
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Address = u.Address,
                            Email = u.Email
                        }).SingleOrDefault();

            if(user == null) { throw new PersonNotFoundException("User not found"); }

            return user;
        }

        public void AddUser(PersonViewModel newUser)
        {
            var user = new Person{
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Address = newUser.Address,
                Email = newUser.Email
            };

            _db.Add(user);
            _db.SaveChanges();
        }

        public void DeleteUserById(int userId)
        {
            var user = (from u in _db.Persons
                        where userId == u.Id
                        select new Person{
                            Id = u.Id,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Address = u.Address,
                            Email = u.Email
                        }).SingleOrDefault();

            if(user == null) { throw new PersonNotFoundException("User not found"); }

            _db.Remove(user);
            _db.SaveChanges();
        }

        public void EditUser(PersonViewModel updateUser, int userId)
        {
            var updatedUser = (from u in _db.Persons
                            where u.Id == userId
                            select u).SingleOrDefault();

            if(updatedUser == null) { throw new PersonNotFoundException("User not found!"); }

            updatedUser.FirstName = updateUser.FirstName;
            updatedUser.LastName = updateUser.LastName;
            updatedUser.Address = updateUser.Address;
            updatedUser.Email = updateUser.Email;

            _db.SaveChanges();
        }

        public IEnumerable<BookDTO> GetBooksOnLoadForUser(int userId)
        {
            var booksOnLoan = (from u in _db.Persons
                               join l in _db.Loans on u.Id equals l.PersonId
                               where userId == l.PersonId
                               join b in _db.Books on l.BookId equals b.Id
                               select new BookDTO {
                                   Title = b.Title,
                                   AuthorFirstName = b.AuthorFirstName,
                                   AuthorLastName = b.AuthorLastName,
                                   PublishDate = b.PublishDate,
                                   ISBN = b.ISBN
                               }).ToList();

            if(booksOnLoan == null) { throw new PersonNotFoundException("Persons doesn't exist or has no books on loan!"); }

            return booksOnLoan;
        }

        public void AddNewLoan(int userId, int bookId)
        {
            var user = GetUserById(userId);
            if(user == null) { throw new PersonNotFoundException("User not found"); }

            var book = GetBookById(bookId);
            if(book == null) { throw new BookNotFoundException("Book not found"); }

            var loan = new Loans {
                PersonId = userId,
                BookId = bookId,
                LoanedAt = DateTime.Now
            };

            _db.Add(loan);
            _db.SaveChanges();
        }

        public void DeleteLoan(int userId, int bookId)
        {
            var user = GetUserById(userId);
            if(user == null) { throw new PersonNotFoundException("User not found"); }

            var book = GetBookById(bookId);
            if(book == null) { throw new BookNotFoundException("Book not found"); }

            var loan = (from l in _db.Loans
                        where userId == l.PersonId
                        && bookId == l.BookId
                        select l).SingleOrDefault();

            if(loan == null) { throw new LoanNotFoundException("User doesn't have this book on loan"); }

            _db.Remove(loan);
            _db.SaveChanges();
        }

        public void ExtendLoanOnBook(int userId, int bookId)
        {
            var user = GetUserById(userId);
            if(user == null) { throw new PersonNotFoundException("User not found"); }

            var book = GetBookById(bookId);
            if(book == null) { throw new BookNotFoundException("Book not found"); }

            var loan = (from l in _db.Loans
                        where userId == l.PersonId
                        && bookId == l.BookId
                        select l).SingleOrDefault();

            if(loan == null) { throw new LoanNotFoundException("User doesn't have this book on loan"); }

            loan.LoanedAt = DateTime.Now;

            _db.SaveChanges();
            //GetLoans(userId, bookId);
        }
        
        //Test fall. Ma deletea
        public void GetLoans(int userId, int bookId)
        {
            var loan = (from l in _db.Loans
                        where userId == l.PersonId
                        && bookId == l.BookId
                        select l).ToList();

            foreach(var l in loan)
            {
                Console.WriteLine(l.LoanedAt);
            }
        }
    }
}
