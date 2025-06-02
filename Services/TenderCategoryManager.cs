using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class TenderCategoryManager : ITenderCategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public TenderCategoryManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<TenderCategory>> GetAllTenderCategoriesAsync(bool trackChanges)
            => await _repositoryManager.TenderCategory.FindAllAsync(trackChanges);
    }
}
