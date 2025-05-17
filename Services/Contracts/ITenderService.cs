using Entities.Models;

namespace Services.Contracts
{
    public interface ITenderService
    {
        Task<IEnumerable<Tender>> GetAllTenders(bool trackChanges);
        Task<Tender> GetTenderById(int id, bool trackChanges);
        Task<IEnumerable<Tender>> GetUserTenders(User user, bool trackChanges);
    }
}
