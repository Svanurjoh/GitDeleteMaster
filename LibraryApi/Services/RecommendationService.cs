using System.Collections.Generic;
using LibraryApi.Models.DTOModels;
using LibraryApi.Models.EntityModels;
using LibraryApi.Repositories;

namespace LibraryApi.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly ILibraryRepository _repo;

        public RecommendationService(ILibraryRepository repo)
        {
            _repo = repo;
        }

    }
}