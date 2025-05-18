using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");

            builder.HasKey(i => i.InvoiceId);
            builder.Property(i => i.InvoiceId)
                .HasColumnName("Invoice_ID")
                .ValueGeneratedOnAdd();

            builder.Property(i => i.InvoiceNumber)
                .HasColumnName("Invoice_Number")
                .HasColumnType("nvarchar(80)");

            builder.Property(i => i.PurchaseOrderId)
                .HasColumnName("Purchase_Order_ID")
                .HasColumnType("nvarchar(80)");
            
            builder.Property(i => i.WarehouseName)
                .HasColumnName("Warehouse_Name")
                .HasColumnType("nvarchar(150)");

            builder.Property(i => i.GateName)
                .HasColumnName("Gate_Name")
                .HasColumnType("nvarchar(40)");

            builder.Property(i => i.InvoiceStatus)
                .HasColumnName("Invoice_Status")
                .HasColumnType("nvarchar(80)");

            builder.Property(i => i.InvoiceTotal)
                .HasColumnName("Invoice_Total")
                .HasColumnType("int");

            builder.Property(i => i.InvoiceDate)
                .HasColumnName("Invoice_Date")
                .HasColumnType("datetime");

            builder.Property(i => i.DeliveryDate)
                .HasColumnName("Delivery_Date")
                .HasColumnType("datetime");
        }
    }
}
