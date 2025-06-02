using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class TenderConfig : IEntityTypeConfiguration<Tender>
    {
        public void Configure(EntityTypeBuilder<Tender> builder)
        {
            builder.ToTable("Tenders");

            builder.HasKey(t => t.TenderId);
            builder.Property(t => t.TenderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("TenderID");

            builder.Property(t => t.CategoryId)
                .HasColumnName("CategoryID")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(t => t.Title)
                .HasColumnName("Title")
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnType("TEXT");

            builder.Property(t => t.ContractDetails)
                .HasColumnType("TEXT");

            builder.Property(t => t.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(t => t.Deadline)
                .HasColumnName("Deadline")
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(t => t.Status)
                .HasColumnName("Status")
                .HasColumnType("TINYINT")
                .IsRequired();

            builder.HasOne(t => t.Category)
                .WithMany(tc => tc.Tenders)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(t => t.Bids)
                .WithOne(b => b.Tender)
                .HasForeignKey(b => b.TenderId);
            builder.HasMany(t => t.TenderSuppliers)
                .WithOne(ts => ts.Tender)
                .HasForeignKey(ts => ts.TenderId);
        }
    }
}
