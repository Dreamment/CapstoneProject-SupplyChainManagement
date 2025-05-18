using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class AcceptanceConfig : IEntityTypeConfiguration<Acceptance>
    {
        public void Configure(EntityTypeBuilder<Acceptance> builder)
        {
            builder.ToTable("Acceptance");

            builder.HasKey(a => a.AcceptanceId);
            builder.Property(a => a.AcceptanceId)
                .HasColumnName("Acceptance_ID")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.PurchaseOrderId)
                .HasColumnName("Purchase_Order_ID")
                .HasColumnType("nvarchar(80)");

            builder.Property(a => a.InvoiceId)
                .HasColumnName("Invoice_ID")
                .HasColumnType("int");

            builder.Property(a => a.MultiUser)
                .HasColumnName("Multi_User")
                .HasColumnType("int");

            builder.Property(a => a.AcceptanceStatus)
                .HasColumnName("Acceptance_Status")
                .HasColumnType("nvarchar(80)");

            builder.Property(a => a.InvoiceTotal)
                .HasColumnName("Invoice_Total")
                .HasColumnType("int");

            builder.Property(a => a.AcceptedTotal)
                .HasColumnName("Accepted_Total")
                .HasColumnType("int");

            builder.Property(a => a.StartTime)
                .HasColumnName("Start_Time");

            builder.Property(a => a.FinishTime)
                .HasColumnName("Finish_Time");

            builder.Property(a => a.Username)
                .HasColumnName("User_Name")
                .HasColumnType("nvarchar(150)");
        }
    }
}
