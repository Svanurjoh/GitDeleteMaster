using System.Collections.Generic;
using LibraryApi.Models.DTOModels;
using LibraryApi.Models.EntityModels;
using LibraryApi.Repositories;

namespace LibraryApi.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ILibraryRepository _repo;

        public ReviewService(ILibraryRepository repo)
        {
            _repo = repo;
        }

    }
}