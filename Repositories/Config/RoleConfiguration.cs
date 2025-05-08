using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        private readonly List<Guid> _roleIds;

        public RoleConfiguration(List<Guid> roleIds)
        {
            _roleIds = roleIds;
        }

        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.Property(r => r.Name)
                .HasColumnName("Role_Name")
                .HasColumnType("nvarchar(240)");

            builder.Property(r => r.NormalizedName)
                .HasColumnName("NormalizedRole_Name")
                .HasColumnType("nvarchar(240)");

            builder.HasData(
                new IdentityRole<Guid>
                {
                    Id = _roleIds[0],
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole<Guid>
                {
                    Id = _roleIds[1],
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
