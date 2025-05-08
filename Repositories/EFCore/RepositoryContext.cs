using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;
using System.Reflection;

namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
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
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<RawMaterialData> RawMaterialDatas { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var roleIds = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
            };

            builder.ApplyConfiguration(new RoleConfiguration(roleIds));
        }
    }
}