using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class RemovePurchaserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Acceptance_Hand", "Acceptance_PC", "Analitics", "Buyer", "Carriage_Hand", "Carriage_PC", "Role_Name", "NormalizedRole_Name", "Parameters", "Picking_Hand", "Picking_PC", "PreAcceptance_Hand", "PreAcceptance_PC", "Reports", "Shipment_Bag_Hand", "Shipment_Bag_PC" },
                values: new object[] { new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"), false, false, false, false, false, false, "Purchaser", "PURCHASER", false, false, false, false, false, false, false, false });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") });
        }
    }
}
