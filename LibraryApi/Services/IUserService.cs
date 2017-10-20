using System;
using System.Collections.Generic;
using LibraryApi.Models.DTOModels;

namespace LibraryApi.Services
{
    public interface IUserService
    {
        void PersonsLoadJson();
        IEnumerable<PersonDTO> GetAllUsers();
    }
}
