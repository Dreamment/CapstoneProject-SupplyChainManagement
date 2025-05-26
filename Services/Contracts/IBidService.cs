using Entities.DataTransferObjects.Create;
using Entities.Models;

namespace Services.Contracts
{
    public interface IBidService
    {
        Task<bool> MakeABidAsync(CreateBidDTO createBidDTO, bool trackChanges);
        Task<IEnumerable<OldBid>> GetOldBidsAsync(int tenderId, string supplierName, bool trackChanges);
        Task<Bid> GetSpecificBidAsync(int tenderId, string supplierName, bool trackChanges);
    }
}
