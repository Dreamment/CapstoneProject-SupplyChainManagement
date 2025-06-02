using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class UserRolesConfig : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        private readonly List<Guid> _userIds;
        private readonly List<Guid> _roleIds;

        public UserRolesConfig(List<Guid> userIds, List<Guid> roleIds)
        {
            _userIds = userIds;
            _roleIds = roleIds;
        }

        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = _userIds[0],
                    RoleId = _roleIds[0]
                },
                new IdentityUserRole<Guid>
                {
                    UserId = _userIds[1],
                    RoleId = _roleIds[1]
                }

            );
        }
    }
}
