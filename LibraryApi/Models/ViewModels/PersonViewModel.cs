using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models.ViewModels
{
    public class PersonViewModel
    {
        /// <summary>
        /// First name of the person
        /// </summary>
        /// <returns></returns>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the person
        /// </summary>
        /// <returns></returns>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Person's email
        /// </summary>
        /// <returns></returns>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Person's address
        /// </summary>
        /// <returns></returns>
        [Required]
        public String Address { get; set; }
    }
}