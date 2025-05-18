using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class TenderSupplierConfig : IEntityTypeConfiguration<TenderSupplier>
    {
        public void Configure(EntityTypeBuilder<TenderSupplier> builder)
        {
            builder.HasKey(ts => new { ts.TenderId, ts.SupplierName });

            builder.HasOne(ts => ts.Tender)
                .WithMany(t => t.TenderSuppliers)
                .HasForeignKey(ts => ts.TenderId);

            builder.HasOne(ts => ts.Supplier)
                .WithMany(s => s.TenderSuppliers)
                .HasForeignKey(ts => ts.SupplierName);

            builder.HasOne(ts => ts.Bid)
                .WithOne(b => b.TenderSupplier)
                .HasForeignKey<TenderSupplier>(ts => ts.BidId);

            builder.Property(ts => ts.TenderId)
                .HasColumnName("TenderID")
                .HasColumnType("int");

            builder.Property(ts => ts.SupplierName)
                .HasColumnName("Supplier_Name")
                .HasColumnType("nvarchar(240)");

            builder.Property(ts => ts.BidId)
                .HasColumnName("BidID")
                .HasColumnType("int")
                .IsRequired(false);
        }
    }
}
