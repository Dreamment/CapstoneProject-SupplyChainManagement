using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEntitiesAndUpdateConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderSuppliers_Bids_BidId",
                table: "TenderSuppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderSuppliers_Tenders_TenderId",
                table: "TenderSuppliers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_TenderSuppliers_BidId",
                table: "TenderSuppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActiveAcceptanceControls",
                table: "ActiveAcceptanceControls");

            migrationBuilder.RenameTable(
                name: "ActiveAcceptanceControls",
                newName: "Active_Acceptance_Control");

            migrationBuilder.RenameColumn(
                name: "BidId",
                table: "TenderSuppliers",
                newName: "BidID");

            migrationBuilder.RenameColumn(
                name: "TenderId",
                table: "TenderSuppliers",
                newName: "TenderID");

            migrationBuilder.RenameColumn(
                name: "Purchase_Order_ID",
                table: "Purchase_Order",
                newName: "Purchase_Order_Id");

            migrationBuilder.AlterColumn<string>(
                name: "User_Name",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                type: "nvarchar(max)",
                rowVersion: true,
                nullable: true,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tenders",
                type: "VARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Tenders",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "Tenders",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tenders",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Role_Name",
                table: "Roles",
                type: "nvarchar(240)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(240)",
                oldMaxLength: 240);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Roles",
                type: "nvarchar(max)",
                rowVersion: true,
                nullable: true,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedRole_Name",
                table: "Roles",
                type: "nvarchar(240)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Raw_Material_Data",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Raw_Material_Data",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Order_Date",
                table: "Purchase_Order",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Last_Update",
                table: "Purchase_Order",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expected_Delivery_Date",
                table: "Purchase_Order",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "Used_Capacity",
                table: "Locations",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Capacity",
                table: "Locations",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Invoice_Date",
                table: "Invoice",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Delivery_Date",
                table: "Invoice",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedAt",
                table: "Bids",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "Bids",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Active_Acceptance_Control",
                type: "nvarchar(240)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_User_Name",
                table: "Users",
                column: "User_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Active_Acceptance_Control",
                table: "Active_Acceptance_Control",
                column: "Active_Acceptance_Control_ID");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Acceptance_Hand", "Acceptance_PC", "Analitics", "Buyer", "Carriage_Hand", "Carriage_PC", "Role_Name", "NormalizedRole_Name", "Parameters", "Picking_Hand", "Picking_PC", "PreAcceptance_Hand", "PreAcceptance_PC", "Reports", "Shipment_Bag_Hand", "Shipment_Bag_PC" },
                values: new object[,]
                {
                    { new Guid("2cfca43a-c260-44db-950f-ef75d58f4259"), false, false, false, false, false, false, "Supplier", "SUPPLIER", false, false, false, false, false, false, false, false },
                    { new Guid("9eb3717a-d2be-4234-856e-fde874c302f3"), false, false, false, false, false, false, "Admin", "ADMIN", false, false, false, false, false, false, false, false },
                    { new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"), false, false, false, false, false, false, "Purchaser", "PURCHASER", false, false, false, false, false, false, false, false }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340"),
                column: "SecurityStamp",
                value: null);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2cfca43a-c260-44db-950f-ef75d58f4259"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") });

            migrationBuilder.CreateIndex(
                name: "IX_TenderSuppliers_BidID",
                table: "TenderSuppliers",
                column: "BidID",
                unique: true,
                filter: "[BidID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_User_Name",
                table: "Suppliers",
                column: "User_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedRole_Name",
                unique: true,
                filter: "[NormalizedRole_Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Users_User_Name",
                table: "Suppliers",
                column: "User_Name",
                principalTable: "Users",
                principalColumn: "User_Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderSuppliers_Bids_BidID",
                table: "TenderSuppliers",
                column: "BidID",
                principalTable: "Bids",
                principalColumn: "BidID");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderSuppliers_Tenders_TenderID",
                table: "TenderSuppliers",
                column: "TenderID",
                principalTable: "Tenders",
                principalColumn: "TenderID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Users_User_Name",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderSuppliers_Bids_BidID",
                table: "TenderSuppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderSuppliers_Tenders_TenderID",
                table: "TenderSuppliers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_User_Name",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TenderSuppliers_BidID",
                table: "TenderSuppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_User_Name",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Active_Acceptance_Control",
                table: "Active_Acceptance_Control");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2cfca43a-c260-44db-950f-ef75d58f4259"), new Guid("c7780a04-a2ec-43e3-b25c-d26ea34e1340") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("9eb3717a-d2be-4234-856e-fde874c302f3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("2cfca43a-c260-44db-950f-ef75d58f4259"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NormalizedRole_Name",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Active_Acceptance_Control",
                newName: "ActiveAcceptanceControls");

            migrationBuilder.RenameColumn(
                name: "BidID",
                table: "TenderSuppliers",
                newName: "BidId");

            migrationBuilder.RenameColumn(
                name: "TenderID",
                table: "TenderSuppliers",
                newName: "TenderId");

            migrationBuilder.RenameColumn(
                name: "Purchase_Order_Id",
                table: "Purchase_Order",
                newName: "Purchase_Order_ID");

            migrationBuilder.AlterColumn<string>(
                name: "User_Name",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldRowVersion: true,
                oldNullable: true,
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tenders",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Tenders",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TINYINT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "Tenders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tenders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Role_Name",
                table: "Roles",
                type: "nvarchar(240)",
                maxLength: 240,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(240)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Raw_Material_Data",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Raw_Material_Data",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Order_Date",
                table: "Purchase_Order",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Last_Update",
                table: "Purchase_Order",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expected_Delivery_Date",
                table: "Purchase_Order",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<float>(
                name: "Used_Capacity",
                table: "Locations",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Capacity",
                table: "Locations",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Invoice_Date",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Delivery_Date",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedAt",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "Bids",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "ActiveAcceptanceControls",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(240)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Role_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActiveAcceptanceControls",
                table: "ActiveAcceptanceControls",
                column: "Active_Acceptance_Control_ID");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role_Name = table.Column<string>(type: "nvarchar(240)", maxLength: 256, nullable: true),
                    NormalizedRole_Name = table.Column<string>(type: "nvarchar(240)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Role_Name", "NormalizedRole_Name" },
                values: new object[,]
                {
                    { new Guid("9eb3717a-d2be-4234-856e-fde874c302f3"), null, "Admin", "ADMIN" },
                    { new Guid("a4d69dbb-1ff6-4d01-8cca-24b210bb0ed4"), null, "User", "USER" }
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
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedRole_Name",
                unique: true,
                filter: "[NormalizedRole_Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderSuppliers_Bids_BidId",
                table: "TenderSuppliers",
                column: "BidId",
                principalTable: "Bids",
                principalColumn: "BidID");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderSuppliers_Tenders_TenderId",
                table: "TenderSuppliers",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "TenderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
