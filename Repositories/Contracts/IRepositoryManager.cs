using Entities.Models;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IRepositoryBase<Acceptance> Acceptance { get; }
        IRepositoryBase<ActiveAcceptanceControl> ActiveAcceptanceControl { get; }
        IRepositoryBase<ActiveInvoiceList> ActiveInvoiceList { get; }
        IRepositoryBase<ActivePurchaseOrderList> ActivePurchaseOrderList { get; }
        IRepositoryBase<Bid> Bid { get; }
        IRepositoryBase<Invoice> Invoice { get; }
        IRepositoryBase<Location> Location { get; }
        IRepositoryBase<OldBid> OldBid { get; }
        IRepositoryBase<PurchaseOrder> PurchaseOrder { get; }
        IRepositoryBase<RawMaterialData> RawMaterialData { get; }
        IRepositoryBase<Role> Role { get; }
        IRepositoryBase<Supplier> Supplier { get; }
        IRepositoryBase<Tender> Tender { get; }
        IRepositoryBase<TenderCategory> TenderCategory { get; }
        IRepositoryBase<TenderSupplier> TenderSupplier { get; }
        IRepositoryBase<User> User { get; }
        Task SaveAsync();
    }
}
