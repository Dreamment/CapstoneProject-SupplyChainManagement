using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class TenderCategoryConfig : IEntityTypeConfiguration<TenderCategory>
    {
        public void Configure(EntityTypeBuilder<TenderCategory> builder)
        {
            builder.ToTable("TenderCategories");
            builder.HasKey(tc => tc.Id);
            builder.Property(tc => tc.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("CategoryID");
            builder.Property(tc => tc.Name)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR(20)")
                .IsRequired();
            builder.Property(tc => tc.Description)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR(500)")
                .IsRequired(false);
        }
    }
}
