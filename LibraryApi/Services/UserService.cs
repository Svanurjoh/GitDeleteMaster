using System.Collections.Generic;
using LibraryApi.Models.DTOModels;
using LibraryApi.Models.EntityModels;
using LibraryApi.Models.ViewModels;
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

        public PersonDTO GetUserById(int userId)
        {
            return _repo.GetUserById(userId);
        }

        public void AddUser(PersonViewModel newUser)
        {
            _repo.AddUser(newUser);
        }

        public void DeleteUserById(int userId)
        {
            _repo.DeleteUserById(userId);
        }
    }
}