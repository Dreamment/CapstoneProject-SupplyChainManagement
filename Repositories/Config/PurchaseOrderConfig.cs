using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class PurchaseOrderConfig : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.ToTable("Purchase_Order");

            builder.HasKey(po => po.PurchaseOrderId);
            builder.Property(po => po.PurchaseOrderId)
                .HasColumnName("Purchase_Order_Id")
                .HasColumnType("nvarchar(80)");

            builder.Property(po => po.Username)
                .HasColumnName("User_Name")
                .HasColumnType("nvarchar(150)");

            builder.Property(po => po.SupplierName)
                .HasColumnName("Supplier_Name")
                .HasColumnType("nvarchar(240)");

            builder.Property(po => po.PurchaseOrderStatus)
                .HasColumnName("Purchase_Order_Status")
                .HasColumnType("nvarchar(80)");

            builder.Property(po => po.LastUpdate)
                .HasColumnName("Last_Update")
                .HasColumnType("datetime");

            builder.Property(po => po.OrderDate)
                .HasColumnName("Order_Date")
                .HasColumnType("datetime");

            builder.Property(po => po.ExpectedDeliveryDate)
                .HasColumnName("Expected_Delivery_Date")
                .HasColumnType("datetime");

            builder.Property(po => po.TotalQuantity)
                .HasColumnName("Total_Quantity")
                .HasColumnType("int");

            builder.Property(po => po.InvoiceTotal)
                .HasColumnName("Invoice_Total")
                .HasColumnType("int");

            builder.Property(po => po.Notes)
                .HasColumnName("Notes")
                .HasColumnType("nvarchar(max)");
        }
    }
}
