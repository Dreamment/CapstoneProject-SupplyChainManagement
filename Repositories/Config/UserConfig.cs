using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        private readonly List<Guid> _userIds;

        public UserConfig(List<Guid> userIds)
        {
            _userIds = userIds;
        }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.UserName)
                .HasColumnName("User_Name")
                .HasColumnType("nvarchar(150)");

            builder.Property(u => u.NormalizedUserName)
                .HasColumnName("NormalizedUser_Name")
                .HasColumnType("nvarchar(150)");

            builder.Property(u => u.PasswordHash)
                .HasColumnName("Password");

            builder.Property(u => u.Email)
                .HasColumnName("E_Mail")
                .HasColumnType("nvarchar(240)");

            builder.Property(u => u.EmailConfirmed)
                .HasColumnName("E_mailConfirmed")
                .HasColumnType("nvarchar(240)");

            builder.Property(u => u.NormalizedEmail)
                .HasColumnName("NormalizedE_Mail")
                .HasColumnType("nvarchar(240)");

            builder.Property(u => u.PhoneNumber)
                .HasColumnName("Telephone")
                .HasColumnType("nvarchar(40)");

            builder.Property(u => u.PhoneNumberConfirmed)
                .HasColumnName("TelephoneConfirmed")
                .HasColumnType("nvarchar(40)");

            builder.Property(u => u.ConcurrencyStamp)
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAddOrUpdate();

            builder.HasData(
                new User
                {
                    Id = _userIds[0],
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAEAACcQAAAAEK1UJlTVFUSnIG7wzErpGrmGlG8/+UwZiCkLEhu8cP+XpYYMznxyZc2sVPsFN3Aytw==",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    PhoneNumber = "123456789",
                    Role_Name = "Admin",
                    Status = true,
                    SecurityStamp = "79e9e60f-e9ac-46a7-8a2c-e055070ec83a"
                },
                new User
                {
                    Id = _userIds[1],
                    UserName = "Emre",
                    NormalizedUserName = "EMRE",
                    PasswordHash = null,
                    Email = "emre@emre.com",
                    NormalizedEmail = "EMRE@EMRE.COM",
                    PhoneNumber = "987654321",
                    Role_Name = "Supplier",
                    Status = true,
                    SecurityStamp = "b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5e6"
                });
        }
    }
}
