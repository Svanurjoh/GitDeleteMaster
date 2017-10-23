/// <summary>
/// Class mapping the database table for reviews
/// </summary>
namespace LibraryApi.Models.DTOModels
{
    public class ReviewDTO
    {
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