using System;

/// <summary>
/// Class mapping the database table for loans
/// </summary>
namespace LibraryApi.Models.EntityModels
{
    public class Loans
    {
        /// <summary>
        /// The loans Id
        /// </summary>
        public int Id {get; set;}
        /// <summary>
        /// The persons Id who has a book on loan
        /// </summary>
        public int PersonId {get; set;}
        /// <summary>
        /// The book Id of the book on loan
        /// </summary>
        public int BookId {get; set;}
        /// <summary>
        /// The date and time the book was taken on loan
        /// </summary>
        public DateTime LoanedAt {get; set;}
    }
}