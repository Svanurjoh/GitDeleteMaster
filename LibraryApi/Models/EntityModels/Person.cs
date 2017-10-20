using System.Collections.Generic;
/// <summary>
/// Class mapping the database table for persons
/// </summary>
namespace LibraryApi.Models.EntityModels
{
    public class Person
    {
        /// <summary>
        /// The id for the person
        /// </summary>
        public int Id {get; set;}
        /// <summary>
        /// The first name of the person
        /// </summary>
        public string FirstName {get; set;}
        /// <summary>
        /// The last name of the person
        /// </summary>
        public string LastName {get; set;}
        /// <summary>
        /// The address for the person
        /// </summary>
        public string Address {get; set;}
        /// <summary>
        /// The email of the person
        /// </summary>
        public string Email {get; set;}
        /// <summary>
        /// List of books on loan for this person
        /// </summary>
        public List<Loans> LoanedBooks {get; set;}
    }
}