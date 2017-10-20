using System.Collections.Generic;
using LibraryApi.Models.DTOModels;
using LibraryApi.Models.EntityModels;
using LibraryApi.Repositories;

namespace LibraryApi.Services
{
    public class UserService : IUserService
    {
        private readonly ILibraryRepository _repo;

        public UserService(ILibraryRepository repo)
        {
            _repo = repo;
        }

        public void PersonsLoadJson()
        {
            _repo.PersonsLoadJson();
        }
        public IEnumerable<PersonDTO> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }
    }
}