using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTenderSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenderSuppliers",
                columns: table => new
                {
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    Supplier_Name = table.Column<string>(type: "nvarchar(240)", nullable: false),
                    BidId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderSuppliers", x => new { x.TenderId, x.Supplier_Name });
                    table.ForeignKey(
                        name: "FK_TenderSuppliers_Bids_BidId",
                        column: x => x.BidId,
                        principalTable: "Bids",
                        principalColumn: "BidID");
                    table.ForeignKey(
                        name: "FK_TenderSuppliers_Suppliers_Supplier_Name",
                        column: x => x.Supplier_Name,
                        principalTable: "Suppliers",
                        principalColumn: "Supplier_Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenderSuppliers_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "TenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340"),
                column: "ConcurrencyStamp",
                value: "79d54b0f-3013-4b77-8ceb-e711b04d533d");

            migrationBuilder.CreateIndex(
                name: "IX_TenderSuppliers_BidId",
                table: "TenderSuppliers",
                column: "BidId",
                unique: true,
                filter: "[BidId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TenderSuppliers_Supplier_Name",
                table: "TenderSuppliers",
                column: "Supplier_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenderSuppliers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340"),
                column: "ConcurrencyStamp",
                value: "b947211d-c6a8-464d-82ae-661005ad6dee");
        }
    }
}
