using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");

            builder.HasKey(l => l.LocationId);
            builder.Property(l => l.LocationId)
                .HasColumnName("Location_ID")
                .ValueGeneratedOnAdd();

            builder.Property(l => l.LocationAddress)
                .HasColumnName("Location_Address")
                .HasColumnType("nvarchar(40)");

            builder.Property(l => l.WarehouseName)
                .HasColumnName("Warehouse_Name")
                .HasColumnType("nvarchar(150)");

            builder.Property(l => l.LocationType)
                .HasColumnName("Location_Type")
                .HasColumnType("nvarchar(80)");

            builder.Property(l => l.Capacity)
                .HasColumnName("Capacity")
                .HasColumnType("float");

            builder.Property(l => l.UsedCapacity)
                .HasColumnName("Used_Capacity")
                .HasColumnType("float");

            builder.Property(l => l.LocationStatus)
                .HasColumnName("Location_Status")
                .HasColumnType("nvarchar(80)");

            builder.Property(l => l.BlockExplanationId)
                .HasColumnName("Block_Explanation_ID")
                .HasColumnType("int");

            builder.Property(l => l.Explanation)
                .HasColumnName("Explanation")
                .HasColumnType("nvarchar(max)");
        }
    }
}
