using System;

/// <summary>
/// Class used to polymorph the database entity for Book
/// </summary>
namespace LibraryApi.Models.DTOModels
{
    public class BookDTO
    {
        /// <summary>
        /// The name of the book
        /// </summary>
        public string Title {get; set;}
        /// <summary>
        /// The authors first name
        /// </summary>
        public string AuthorFirstName {get; set;}
        /// <summary>
        /// The authors last name
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