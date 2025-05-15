using Entities.Models;
using Repositories.Contratcs;
using Services.Contracts;

namespace Services
{
    public class TenderManager : ITenderService
    {
        private readonly IRepositoryManager _repositoryManager;

        public TenderManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Tender>> GetAllTenders(bool trackChanges)
        {
            return await _repositoryManager.Tender.FindAllAsync(trackChanges);
        }
    }
}
