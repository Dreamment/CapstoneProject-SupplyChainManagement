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

        public async Task<IEnumerable<Tender>> GetUserTenders(User user, bool trackChanges)
        {
            var supplier = await _repositoryManager.Supplier.FindByConditionWithDetailsAsync(
                s => s.User_Name == user.UserName,
                trackChanges,
                s => s.TenderSuppliers);

            if (supplier == null || supplier.TenderSuppliers.Count == 0)
                return [];

            List<Tender> tenders = [];

            foreach (var tenderSupplier in supplier.TenderSuppliers)
            {
                var tender = await _repositoryManager.Tender.FindByConditionAsync(
                    t => t.TenderID == tenderSupplier.TenderId,
                    trackChanges);
                if (tender != null)
                {
                    tenders.Add(tender);
                }
            }
            return tenders;
        }
    }
}
