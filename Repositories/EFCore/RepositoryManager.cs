using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;

            Acceptance = new RepositoryBase<Acceptance>(_context);
            ActiveAcceptanceControl = new RepositoryBase<ActiveAcceptanceControl>(_context);
            ActiveInvoiceList = new RepositoryBase<ActiveInvoiceList>(_context);
            ActivePurchaseOrderList = new RepositoryBase<ActivePurchaseOrderList>(_context);
            Bid = new RepositoryBase<Bid>(_context);
            Invoice = new RepositoryBase<Invoice>(_context);
            Location = new RepositoryBase<Location>(_context);
            PurchaseOrder = new RepositoryBase<PurchaseOrder>(_context);
            RawMaterialData = new RepositoryBase<RawMaterialData>(_context);
            Role = new RepositoryBase<Role>(_context);
            Supplier = new RepositoryBase<Supplier>(_context);
            Tender = new RepositoryBase<Tender>(_context);
            User = new RepositoryBase<User>(_context);
            TenderSupplier = new RepositoryBase<TenderSupplier>(_context);
            OldBid = new RepositoryBase<OldBid>(_context);
        }
        public IRepositoryBase<Acceptance> Acceptance { get; }
        public IRepositoryBase<ActiveAcceptanceControl> ActiveAcceptanceControl { get; }
        public IRepositoryBase<ActiveInvoiceList> ActiveInvoiceList { get; }
        public IRepositoryBase<ActivePurchaseOrderList> ActivePurchaseOrderList { get; }
        public IRepositoryBase<Bid> Bid { get; }
        public IRepositoryBase<Invoice> Invoice { get; }
        public IRepositoryBase<Location> Location { get; }
        public IRepositoryBase<PurchaseOrder> PurchaseOrder { get; }
        public IRepositoryBase<RawMaterialData> RawMaterialData { get; }
        public IRepositoryBase<Role> Role { get; }
        public IRepositoryBase<Supplier> Supplier { get; }
        public IRepositoryBase<Tender> Tender { get; }
        public IRepositoryBase<User> User { get; }
        public IRepositoryBase<TenderSupplier> TenderSupplier { get; }
        public IRepositoryBase<OldBid> OldBid { get; }
        public async Task SaveAsync() 
            => await _context.SaveChangesAsync();
    }
}
