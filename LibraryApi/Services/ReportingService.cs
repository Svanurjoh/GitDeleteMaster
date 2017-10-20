using System.Collections.Generic;
using LibraryApi.Models.DTOModels;
using LibraryApi.Models.EntityModels;
using LibraryApi.Repositories;

namespace LibraryApi.Services
{
    public class ReportingService : IReportingService
    {
        private readonly ILibraryRepository _repo;

        public ReportingService(ILibraryRepository repo)
        {
            _repo = repo;
        }

    }
}