using Entities.Models;

namespace Services.Contracts
{
    public interface ITenderService
    {
        Task<IEnumerable<Tender>> GetAllTenders(bool trackChanges);
    }
}
