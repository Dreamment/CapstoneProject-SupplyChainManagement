using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class BidConfig : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.ToTable("Bids");

            builder.HasKey(b => b.BidId);
            builder.Property(b => b.BidId)
                .HasColumnName("BidID")
                .ValueGeneratedOnAdd();

            builder.Property(b => b.TenderId)
                .HasColumnName("TenderID")
                .IsRequired(true);
            builder.HasOne(b => b.Tender)
                .WithMany(t => t.Bids)
                .HasForeignKey(b => b.TenderId);

            builder.Property(b => b.SupplierName)
                .HasColumnName("Supplier_Name")
                .HasColumnType("nvarchar(240)")
                .IsRequired(true);
            builder.HasOne(b => b.Supplier)
                .WithMany(s => s.Bids)
                .HasForeignKey(b => b.SupplierName);

            builder.Property(b => b.Amount)
                .HasColumnName("Amount")
                .HasColumnType("decimal(15,2)")
                .IsRequired(true);

            builder.Property(b => b.SubmittedAt)
                .HasColumnName("SubmittedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

            builder.Property(b => b.IsAccepted)
                .HasColumnName("IsAccepted")
                .HasDefaultValue(false);
        }
    }
}
