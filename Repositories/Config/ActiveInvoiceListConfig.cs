using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ActiveInvoiceListConfig : IEntityTypeConfiguration<ActiveInvoiceList>
    {
        public void Configure(EntityTypeBuilder<ActiveInvoiceList> builder)
        {
            builder.ToTable("Active_Invoice_List");

            builder.HasKey(ail => ail.ActiveInvoiceListId);
            builder.Property(ail => ail.ActiveInvoiceListId)
                .HasColumnName("Active_Invoice_List_ID")
                .ValueGeneratedOnAdd();

            builder.Property(ail => ail.InvoiceId)
                .HasColumnName("Invoice_ID")
                .HasColumnType("int");

            builder.Property(ail => ail.Barcode)
                .HasColumnName("Barcode")
                .HasColumnType("nvarchar(40)");

            builder.Property(ail => ail.Quantity)
                .HasColumnName("Quantity")
                .HasColumnType("int");
        }
    }
}
