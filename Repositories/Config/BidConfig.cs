using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class BidConfig : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.HasOne(b => b.Tender)
                .WithMany(t => t.Bids)
                .HasForeignKey(b => b.TenderID);

            builder.HasOne(b => b.Supplier)
                .WithMany(s => s.Bids)
                .HasForeignKey(b => b.Supplier_Name);
        }
    }
}
