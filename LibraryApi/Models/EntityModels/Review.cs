/// <summary>
/// Class mapping the database table for reviews
/// </summary>
namespace LibraryApi.Models.EntityModels
{
    public class Review
    {
        /// <summary>
        /// The review Id for the
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
        /// The the review
        /// </summary>
        public string ShortReview {get; set;}
        /// <summary>
        /// Stars
        /// </summary>
        public int Stars {get; set;}
    }
}