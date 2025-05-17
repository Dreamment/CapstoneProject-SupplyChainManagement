using Entities.DataTransferObjects.Create;
using Entities.Models;

namespace Services.Contracts
{
    public interface IBidService
    {
        Task<bool> CreateBidAsync(CreateBidDTO createBidDTO, bool trackChanges);
    }
}
