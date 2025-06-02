using Entities.Models;

namespace Services.Contracts
{
    public interface ITenderCategoryService
    {
        Task<IEnumerable<TenderCategory>> GetAllTenderCategoriesAsync(bool trackChanges);
    }
}
