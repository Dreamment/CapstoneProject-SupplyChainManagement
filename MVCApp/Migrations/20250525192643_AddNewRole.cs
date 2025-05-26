using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Acceptance_Hand", "Acceptance_PC", "Analitics", "Buyer", "Carriage_Hand", "Carriage_PC", "Role_Name", "NormalizedRole_Name", "Parameters", "Picking_Hand", "Picking_PC", "PreAcceptance_Hand", "PreAcceptance_PC", "Reports", "Shipment_Bag_Hand", "Shipment_Bag_PC" },
                values: new object[] { new Guid("cc0b8568-8ac2-4a8b-b341-fc517a7d75ff"), false, false, false, false, false, false, "User", "USER", false, false, false, false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340"),
                column: "SecurityStamp",
                value: "79e9e60f-e9ac-46a7-8a2c-e055070ec83a");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cc0b8568-8ac2-4a8b-b341-fc517a7d75ff"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cc0b8568-8ac2-4a8b-b341-fc517a7d75ff"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cc0b8568-8ac2-4a8b-b341-fc517a7d75ff"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340"),
                column: "SecurityStamp",
                value: null);
        }
    }
}
