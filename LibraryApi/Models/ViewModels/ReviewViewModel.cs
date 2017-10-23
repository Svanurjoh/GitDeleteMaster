using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models.ViewModels
{
    public class ReviewViewModel
    {
        /// <summary>
        /// The the review
        /// </summary>
        [Required]
        public string ShortReview {get; set;}
        /// <summary>
        /// Stars
        /// </summary>
        [Required]
        public int Stars {get; set;}
    }
}