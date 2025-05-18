using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class RawMaterialDataConfig : IEntityTypeConfiguration<RawMaterialData>
    {
        public void Configure(EntityTypeBuilder<RawMaterialData> builder)
        {
            builder.ToTable("Raw_Material_Data");

            builder.HasKey(rmd => rmd.CompanyBarcode);
            builder.Property(rmd => rmd.CompanyBarcode)
                .HasColumnName("Company_Barcode")
                .HasColumnType("nvarchar(40)");

            builder.Property(rmd => rmd.OldBarcode)
                .HasColumnName("Old_Barcode")
                .HasColumnType("nvarchar(40)");

            builder.Property(rmd => rmd.Brand)
                .HasColumnName("Brand")
                .HasColumnType("nvarchar(80)");

            builder.Property(rmd => rmd.FabricComposition)
                .HasColumnName("Fabric_Composition")
                .HasColumnType("nvarchar(80)");

            builder.Property(rmd => rmd.Color)
                .HasColumnName("Color")
                .HasColumnType("nvarchar(80)");

            builder.Property(rmd => rmd.Amount)
                .HasColumnName("Amount")
                .HasColumnType("float");

            builder.Property(rmd => rmd.Unit)
                .HasColumnName("Unit")
                .HasColumnType("nvarchar(80)");

            builder.Property(rmd => rmd.Price)
                .HasColumnName("Price")
                .HasColumnType("float");
        }
    }
}
