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
            => await _repositoryManager.Tender.FindAllAsync(trackChanges);

        public async Task<Tender> GetTenderById(int id, bool trackChanges)
            => await _repositoryManager.Tender.FindByConditionAsync(
                t => t.TenderId == id, trackChanges);

        public async Task<IEnumerable<Tender>> GetUserTenders(User user, bool trackChanges)
        {
            var supplier = await _repositoryManager.Supplier.FindByConditionWithDetailsAsync(
                s => s.Username == user.UserName,
                trackChanges,
                s => s.TenderSuppliers);

            if (supplier == null || supplier.TenderSuppliers.Count == 0)
                return [];

            List<Tender> tenders = [];

            foreach (var tenderSupplier in supplier.TenderSuppliers)
            {
                var tender = await _repositoryManager.Tender.FindByConditionWithDetailsAsync(
                    t => t.TenderId == tenderSupplier.TenderId,
                    trackChanges,
                    t => t.Bids);
                if (tender != null)
                {
                    tenders.Add(tender);
                }
            }
            return tenders;
        }
    }
}
