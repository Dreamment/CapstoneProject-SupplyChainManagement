using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(s => s.SupplierName);
            builder.Property(s => s.SupplierName)
                .HasColumnName("Supplier_Name")
                .HasColumnType("nvarchar(240)");

            builder.Property(s => s.Address)
                .HasColumnName("Address")
                .HasColumnType("nvarchar(240)");

            builder.Property(s => s.Country)
                .HasColumnName("Country")
                .HasColumnType("nvarchar(40)");

            builder.Property(s => s.ContactPerson)
                .HasColumnName("Contact_Person")
                .HasColumnType("nvarchar(150)");

            builder.Property(s => s.Telephone)
                .HasColumnName("Telephone")
                .HasColumnType("nvarchar(40)");

            builder.Property(s => s.Email)
                .HasColumnName("E_Mail")
                .HasColumnType("nvarchar(240)");

            builder.Property(s => s.TaxId)
                .HasColumnName("Tax_ID")
                .HasColumnType("nvarchar(40)");

            builder.Property(s => s.Username)
                .HasColumnName("User_Name")
                .HasColumnType("nvarchar(150)")
                .IsRequired(true);

            builder.HasOne(s => s.User)
                .WithOne(u => u.Supplier)
                .HasPrincipalKey<User>(u => u.UserName)
                .HasForeignKey<Supplier>(s => s.Username);

            builder.HasMany(s => s.TenderSuppliers)
                .WithOne(ts => ts.Supplier)
                .HasForeignKey(ts => ts.SupplierName);

            builder.HasMany(s => s.Bids)
                .WithOne(b => b.Supplier)
                .HasForeignKey(b => b.SupplierName);

            builder.HasData(
                new Supplier
                {
                    SupplierName = "Emre",
                    Address = "Emre",
                    Country = "Emre",
                    ContactPerson = "Emre",
                    Telephone = "987654321",
                    Email = "emre@emre.com",
                    TaxId = "1234567890",
                    IsActive = true,
                    Username = "Emre",
                });
        }
    }
}
