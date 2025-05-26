using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class UserRolesConfig : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        private readonly Guid _userId;
        private readonly List<Guid> _roleIds;

        public UserRolesConfig(Guid userId, List<Guid> roleIds)
        {
            _userId = userId;
            _roleIds = roleIds;
        }

        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = _userId,
                    RoleId = _roleIds[0] // Admin role
                },
                new IdentityUserRole<Guid>
                {
                    UserId = _userId,
                    RoleId = _roleIds[1] // Purchaser role
                },
                new IdentityUserRole<Guid>
                {
                    UserId = _userId,
                    RoleId = _roleIds[2] // Supplier role
                },
                new IdentityUserRole<Guid>
                {
                    UserId = _userId,
                    RoleId = _roleIds[3] // User role
                }
            );
        }
    }
}
