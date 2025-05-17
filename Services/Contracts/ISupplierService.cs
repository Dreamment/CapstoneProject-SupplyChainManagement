using Entities.Models;

namespace Services.Contracts
{
    public interface ISupplierService
    {
        Task<Supplier> GetSupplier(User user, bool trackChanges);
    }
}
