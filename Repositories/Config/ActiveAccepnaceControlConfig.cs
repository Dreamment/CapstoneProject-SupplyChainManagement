using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ActiveAccepnaceControlConfig : IEntityTypeConfiguration<ActiveAcceptanceControl>
    {
        public void Configure(EntityTypeBuilder<ActiveAcceptanceControl> builder)
        {
            builder.ToTable("Active_Acceptance_Control");

            builder.HasKey(aac => aac.ActiveAcceptanceControlId);
            builder.Property(aac => aac.ActiveAcceptanceControlId)
                .HasColumnName("Active_Acceptance_Control_ID")
                .ValueGeneratedOnAdd();

            builder.Property(aac => aac.AcceptanceId)
                .HasColumnName("Acceptance_ID")
                .HasColumnType("int");

            builder.Property(aac => aac.Barcode)
                .HasColumnName("Barcode")
                .HasColumnType("nvarchar(240)");

            builder.Property(aac => aac.InvoiceQuantity)
                .HasColumnName("Invoice_Quantity")
                .HasColumnType("int");

            builder.Property(aac => aac.Accepted_Quantity)
                .HasColumnName("Accepted_Quantity")
                .HasColumnType("int");
        }
    }
}
