using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;
using System.Reflection;

namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<User, Role, Guid>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Acceptance> Acceptances { get; set; }
        public DbSet<ActiveAcceptanceControl> ActiveAcceptanceControls { get; set; }
        public DbSet<ActiveInvoiceList> ActiveInvoiceLists { get; set; }
        public DbSet<ActivePurchaseOrderList> ActivePurchaseOrderLists { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OldBid> OldBids { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<RawMaterialData> RawMaterialDatas { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderCategory> TenderCategories { get; set; }
        public DbSet<TenderSupplier> TenderSuppliers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roleIds = new List<Guid>
            {
                Guid.Parse("9eb3717a-d2be-4234-856e-fde874c302f3"),
                Guid.Parse("2cfca43a-c260-44db-950f-ef75d58f4259"),
                Guid.Parse("cc0b8568-8ac2-4a8b-b341-fc517a7d75ff")
            };

            var userIds = new List<Guid> { 
                Guid.Parse("c7780a04-a2ec-43e3-b25c-d26ea34e1340"),
                Guid.Parse("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"),
            };

            builder.ApplyConfiguration(new RoleConfig(roleIds));
            builder.ApplyConfiguration(new UserConfig(userIds));
            builder.ApplyConfiguration(new UserRolesConfig(userIds, roleIds));
            builder.ApplyConfiguration(new AcceptanceConfig());
            builder.ApplyConfiguration(new ActiveAcceptanceControlConfig());
            builder.ApplyConfiguration(new ActiveInvoiceListConfig());
            builder.ApplyConfiguration(new ActivePurchaseOrderListConfig());
            builder.ApplyConfiguration(new BidConfig());
            builder.ApplyConfiguration(new InvoiceConfig());
            builder.ApplyConfiguration(new LocationConfig());
            builder.ApplyConfiguration(new OldBidConfig());
            builder.ApplyConfiguration(new PurchaseOrderConfig());
            builder.ApplyConfiguration(new RawMaterialDataConfig());
            builder.ApplyConfiguration(new SupplierConfig());
            builder.ApplyConfiguration(new TenderConfig());
            builder.ApplyConfiguration(new TenderCategoryConfig());
            builder.ApplyConfiguration(new TenderSupplierConfig());
        }
    }
}