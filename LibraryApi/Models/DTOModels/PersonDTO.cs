/// <summary>
/// Class used to polymorph the database entity for person 
/// </summary>
namespace LibraryApi.Models.DTOModels
{
    public class PersonDTO
    {
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
    }
}