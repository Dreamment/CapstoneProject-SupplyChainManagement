using Entities.DataTransferObjects.Filter;
using Entities.DataTransferObjects.Home;
using Entities.Enums;
using Entities.Models;

namespace Services.Contracts
{
    public interface ITenderService
    {
        Task<IEnumerable<Tender>> GetAllTenders(bool trackChanges);
        Task<Tender> GetTenderById(int id, bool trackChanges);
        Task<(IEnumerable<Tender>,IEnumerable<TenderSupplier>)> GetUserTenders(User user, bool trackChanges);
        Task<Tender?> GetUserSpecificTender(Supplier supplier, int tenderId, bool trackChanges);
        Task<(IEnumerable<Tender>, IEnumerable<TenderSupplier>)> GetUserTendersFiltered(User user, TenderFilter filter, bool trackChanges);
        Task<(IEnumerable<Tender> Tenders, IEnumerable<TenderSupplier> TenderSuppliers, int TotalCount)>GetUserTendersFilteredPaged(
            User user, TenderFilter filter, int page, int pageSize, bool trackChanges);
        Task<(IEnumerable<Tender> Tenders, IEnumerable<TenderSupplier> TenderSuppliers, int TotalCount)> GetUserTendersFilteredSortedPaged(
            User user, TenderFilter filter, int page, int pageSize, TenderSortOrder tenderSortOrder, bool trackChanges);
        Task<SupplierHomeGetTendersDTO> GetSupplierHomeGetTendersDTO(User user, int tenderCount, bool trackChanges);
        Task<AdminHomeGetTendersDTO> GetAdminHomeTenders();
    }
}
