using Entities.Models;
using Repositories.Contratcs;
using Services.Contracts;

namespace Services
{
    public class SupplierManager : ISupplierService
    {
        private readonly IRepositoryManager _repositoryManager;

        public SupplierManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Supplier> GetSupplier(User user, bool trackChanges)
         => await _repositoryManager.Supplier.FindByConditionAsync(
             s => s.Username == user.UserName,
            trackChanges);
    }
}
