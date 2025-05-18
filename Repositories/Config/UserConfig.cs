using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        private readonly Guid _userId;

        public UserConfig(Guid userId)
        {
            _userId = userId;
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
                    Id = _userId,
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAEAACcQAAAAEK1UJlTVFUSnIG7wzErpGrmGlG8/+UwZiCkLEhu8cP+XpYYMznxyZc2sVPsFN3Aytw==",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    PhoneNumber = "123456789",
                    Role_Name = "Admin",
                    Status = true
                });
        }
    }
}
