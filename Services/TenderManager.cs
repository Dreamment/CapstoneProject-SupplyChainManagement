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

        public async Task<(IEnumerable<Tender>, IEnumerable<TenderSupplier>)> GetUserTenders(User user, bool trackChanges)
        {
            var supplier = await _repositoryManager.Supplier.FindByConditionWithDetailsAsync(
                s => s.Username == user.UserName,
                trackChanges,
                s => s.TenderSuppliers);

            if (supplier == null || supplier.TenderSuppliers.Count == 0)
                return (new List<Tender>(), new List<TenderSupplier>());

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

            List<TenderSupplier> tenderSuppliers = [];

            foreach (var tenderSupplier in supplier.TenderSuppliers)
            {
                tenderSuppliers.Add(await _repositoryManager.TenderSupplier.FindByConditionWithDetailsAsync(
                    ts => ts.TenderId == tenderSupplier.TenderId && ts.SupplierName == supplier.SupplierName,
                    trackChanges,
                    ts => ts.Bid));
            }

            return (tenders, tenderSuppliers);
        }

        public async Task<Tender> GetUserSpecificTender(Supplier supplier, int tenderId, bool trackChanges)
        {
            var tenderSupplier = await _repositoryManager.TenderSupplier.FindByConditionAsync(
                ts => ts.SupplierName == supplier.SupplierName && ts.TenderId == tenderId, trackChanges);
            if (tenderSupplier == null)
                return null;
            return await _repositoryManager.Tender.FindByConditionWithDetailsAsync(
                t => t.TenderId == tenderId, trackChanges, t => t.Bids);
        }
    }
}
