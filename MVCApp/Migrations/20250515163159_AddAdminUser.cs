using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "E_Mail", "E_mailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedE_Mail", "NormalizedUser_Name", "Password", "Telephone", "TelephoneConfirmed", "Role_Name", "Salary", "Status", "TwoFactorEnabled", "User_Name" },
                values: new object[] { new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340"), 0, "b947211d-c6a8-464d-82ae-661005ad6dee", "admin@admin.com", "0", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEK1UJlTVFUSnIG7wzErpGrmGlG8/+UwZiCkLEhu8cP+XpYYMznxyZc2sVPsFN3Aytw==", "123456789", "0", "Admin", 0f, true, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("9eb3717a-d2be-4234-856e-fde874c302f3"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") },
                    { new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9eb3717a-d2be-4234-856e-fde874c302f3"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
