using Entities.Enums;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class OldBidConfig : IEntityTypeConfiguration<OldBid>
    {
        public void Configure(EntityTypeBuilder<OldBid> builder)
        {
            builder.ToTable("OldBids");

            builder.HasKey(b => b.OldBidId);
            builder.Property(b => b.OldBidId)
                .HasColumnName("OldBidID")
                .ValueGeneratedOnAdd();

            builder.Property(b => b.TenderId)
                .HasColumnName("TenderID")
                .IsRequired(true);

            builder.Property(b => b.SupplierName)
                .HasColumnName("Supplier_Name")
                .HasColumnType("nvarchar(240)")
                .IsRequired(true);

            builder.Property(b => b.Amount)
                .HasColumnName("Amount")
                .HasColumnType("decimal(15,2)")
                .IsRequired(true);

            builder.Property(b => b.OldStatus)
                .HasColumnName("OldStatus")
                .HasColumnType("tinyint")
                .IsRequired(true)
                .HasDefaultValue(BidStatus.Pending);

        }
    }
}
