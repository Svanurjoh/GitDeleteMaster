using System;
using System.Collections.Generic;
using LibraryApi.Models.DTOModels;
using LibraryApi.Models.ViewModels;

namespace LibraryApi.Services
{
    public interface IUserService
    {
        void PersonsLoadJson();
        IEnumerable<PersonDTO> GetAllUsers();
        PersonDTO GetUserById(int userId);
        void AddUser(PersonViewModel newUser);
        void DeleteUserById(int userId);
        void EditUser(PersonViewModel updateUser, int userId);
    }
}
