using Entities.Models;

namespace Services.Contracts
{
    public interface ITenderService
    {
        Task<IEnumerable<Tender>> GetAllTenders(bool trackChanges);
        Task<Tender> GetTenderById(int id, bool trackChanges);
        Task<(IEnumerable<Tender>,IEnumerable<TenderSupplier>)> GetUserTenders(User user, bool trackChanges);
        Task<Tender> GetUserSpecificTender(Supplier supplier, int tenderId, bool trackChanges);
    }
}
