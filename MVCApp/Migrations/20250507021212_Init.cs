using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acceptance",
                columns: table => new
                {
                    Acceptance_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purchase_Order_ID = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Invoice_ID = table.Column<int>(type: "int", nullable: false),
                    Multi_User = table.Column<int>(type: "int", nullable: false),
                    Acceptance_Status = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Invoice_Total = table.Column<int>(type: "int", nullable: false),
                    Accepted_Total = table.Column<int>(type: "int", nullable: false),
                    Start_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finish_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acceptance", x => x.Acceptance_ID);
                });

            migrationBuilder.CreateTable(
                name: "Active_Invoice_List",
                columns: table => new
                {
                    Active_Invoice_List_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoice_ID = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Active_Invoice_List", x => x.Active_Invoice_List_ID);
                });

            migrationBuilder.CreateTable(
                name: "Active_Purchase_Order_List",
                columns: table => new
                {
                    Active_Purchase_Order_List_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purchase_Order_ID = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Invoiced_Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Active_Purchase_Order_List", x => x.Active_Purchase_Order_List_ID);
                });

            migrationBuilder.CreateTable(
                name: "ActiveAcceptanceControls",
                columns: table => new
                {
                    Active_Acceptance_Control_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acceptance_ID = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Invoice_Quantity = table.Column<int>(type: "int", nullable: false),
                    Accepted_Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveAcceptanceControls", x => x.Active_Acceptance_Control_ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Invoice_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoice_Number = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Purchase_Order_ID = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Warehouse_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gate_Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Invoice_Status = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Invoice_Total = table.Column<int>(type: "int", nullable: false),
                    Invoice_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivery_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Invoice_ID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Location_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location_Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Warehouse_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Location_Type = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Capacity = table.Column<float>(type: "real", nullable: false),
                    Used_Capacity = table.Column<float>(type: "real", nullable: false),
                    Location_Status = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Block_Explanation_ID = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Location_ID);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Order",
                columns: table => new
                {
                    Purchase_Order_ID = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Supplier_Name = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Purchase_Order_Status = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Last_Update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expected_Delivery_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_Quantity = table.Column<int>(type: "int", nullable: false),
                    Invoice_Total = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Order", x => x.Purchase_Order_ID);
                });

            migrationBuilder.CreateTable(
                name: "Raw_Material_Data",
                columns: table => new
                {
                    Company_Barcode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Old_Barcode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Fabric_Composition = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raw_Material_Data", x => x.Company_Barcode);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_Name = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Buyer = table.Column<bool>(type: "bit", nullable: false),
                    Analitics = table.Column<bool>(type: "bit", nullable: false),
                    PreAcceptance_PC = table.Column<bool>(type: "bit", nullable: false),
                    PreAcceptance_Hand = table.Column<bool>(type: "bit", nullable: false),
                    Acceptance_PC = table.Column<bool>(type: "bit", nullable: false),
                    Acceptance_Hand = table.Column<bool>(type: "bit", nullable: false),
                    Shipment_Bag_PC = table.Column<bool>(type: "bit", nullable: false),
                    Shipment_Bag_Hand = table.Column<bool>(type: "bit", nullable: false),
                    Picking_PC = table.Column<bool>(type: "bit", nullable: false),
                    Picking_Hand = table.Column<bool>(type: "bit", nullable: false),
                    Carriage_PC = table.Column<bool>(type: "bit", nullable: false),
                    Carriage_Hand = table.Column<bool>(type: "bit", nullable: false),
                    Reports = table.Column<bool>(type: "bit", nullable: false),
                    Parameters = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_Name);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier_Name = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Contact_Person = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    E_Mail = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Tax_ID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    TenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.TenderID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    E_Mail = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Role_Name = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Name);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    BidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderID = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.BidID);
                    table.ForeignKey(
                        name: "FK_Bids_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Tenders_TenderID",
                        column: x => x.TenderID,
                        principalTable: "Tenders",
                        principalColumn: "TenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_SupplierID",
                table: "Bids",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_TenderID",
                table: "Bids",
                column: "TenderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acceptance");

            migrationBuilder.DropTable(
                name: "Active_Invoice_List");

            migrationBuilder.DropTable(
                name: "Active_Purchase_Order_List");

            migrationBuilder.DropTable(
                name: "ActiveAcceptanceControls");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Purchase_Order");

            migrationBuilder.DropTable(
                name: "Raw_Material_Data");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Tenders");
        }
    }
}
