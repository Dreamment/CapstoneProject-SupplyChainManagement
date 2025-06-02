using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2cfca43a-c260-44db-950f-ef75d58f4259"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cc0b8568-8ac2-4a8b-b341-fc517a7d75ff"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "E_Mail", "E_mailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedE_Mail", "NormalizedUser_Name", "Password", "Telephone", "TelephoneConfirmed", "Role_Name", "Salary", "SecurityStamp", "Status", "TwoFactorEnabled", "User_Name" },
                values: new object[] { new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"), 0, "emre@emre.com", "0", false, null, "EMRE@EMRE.COM", "EMRE", null, "987654321", "0", "Supplier", 0f, "b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5e6", true, false, "Emre" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2cfca43a-c260-44db-950f-ef75d58f4259"), new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4") });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Supplier_Name", "Address", "Contact_Person", "Country", "E_Mail", "IsActive", "Tax_ID", "Telephone", "User_Name" },
                values: new object[] { "Emre", "Emre", "Emre", "Emre", "emre@emre.com", true, "1234567890", "987654321", "Emre" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2cfca43a-c260-44db-950f-ef75d58f4259"), new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4") });

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Supplier_Name",
                keyValue: "Emre");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2cfca43a-c260-44db-950f-ef75d58f4259"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") },
                    { new Guid("cc0b8568-8ac2-4a8b-b341-fc517a7d75ff"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") }
                });
        }
    }
}
