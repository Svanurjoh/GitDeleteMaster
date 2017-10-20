using System;

/// <summary>
/// Class mapping the database table for books
/// </summary>
namespace LibraryApi.Models.EntityModels
{
    public class Book
    {
        /// <summary>
        /// The book Id for the book
        /// </summary>
        public int Id {get; set;}
        /// <summary>
        /// The name of the book
        /// </summary>
        public string Title {get; set;}
        /// <summary>
        /// The authors forname of the book
        /// </summary>
        public string AuthorFirstName {get; set;}
        /// <summary>
        /// The authors sirname of the book
        /// </summary>
        public string AuthorLastName {get; set;}
        /// <summary>
        /// The published date for the book
        /// </summary>
        public DateTime? PublishDate {get; set;}
        /// <summary>
        /// The ISBN number for the book
        /// </summary>
        public string ISBN {get; set;}
    }
}