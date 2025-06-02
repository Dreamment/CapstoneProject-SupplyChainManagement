using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTenderCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Tenders",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TenderCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderCategories", x => x.CategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_CategoryID",
                table: "Tenders",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenders_TenderCategories_CategoryID",
                table: "Tenders",
                column: "CategoryID",
                principalTable: "TenderCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenders_TenderCategories_CategoryID",
                table: "Tenders");

            migrationBuilder.DropTable(
                name: "TenderCategories");

            migrationBuilder.DropIndex(
                name: "IX_Tenders_CategoryID",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Tenders");
        }
    }
}
