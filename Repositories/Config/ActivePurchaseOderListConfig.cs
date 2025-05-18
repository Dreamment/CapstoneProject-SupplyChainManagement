using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ActivePurchaseOderListConfig : IEntityTypeConfiguration<ActivePurchaseOrderList>
    {
        public void Configure(EntityTypeBuilder<ActivePurchaseOrderList> builder)
        {
            builder.ToTable("Active_Purchase_Order_List");

            builder.HasKey(apol => apol.ActivePurchaseOrderListId);
            builder.Property(apol => apol.ActivePurchaseOrderListId)
                .HasColumnName("Active_Purchase_Order_List_ID")
                .ValueGeneratedOnAdd();

            builder.Property(apol => apol.Purchase_Order_ID)
                .HasColumnName("Purchase_Order_ID")
                .HasColumnType("nvarchar(80)");

            builder.Property(apol => apol.Barcode)
                .HasColumnName("Barcode")
                .HasColumnType("nvarchar(40)");

            builder.Property(apol => apol.Quantity)
                .HasColumnName("Quantity")
                .HasColumnType("int");

            builder.Property(apol => apol.InvoicedQuantity)
                .HasColumnName("Invoiced_Quantity")
                .HasColumnType("int");
        }
    }
}
