using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Repositories.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
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
                .HasColumnName("Password")
                .HasColumnType("nvarchar(40)");

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

            builder.Property(u => u.SecurityStamp)
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
