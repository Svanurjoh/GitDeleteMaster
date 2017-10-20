using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models.ViewModels
{
    public class BookViewModel
    {
        /// <summary>
        /// Title of the book
        /// </summary>
        /// <returns></returns>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// First name of the book author
        /// </summary>
        /// <returns></returns>
        [Required]
        public string AuthorFirstName { get; set; }
        /// <summary>
        /// Last name of the book author
        /// </summary>
        /// <returns></returns>
        [Required]
        public string AuthorLastName { get; set; }
        /// <summary>
        /// Release date of the book
        /// </summary>
        /// <returns></returns>
        [Required]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// ISBN number for the book
        /// </summary>
        /// <returns></returns>
        [Required]
        public string ISBN { get; set; }

    }
}