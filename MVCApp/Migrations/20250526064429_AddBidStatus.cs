using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class AddBidStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Bids");

            migrationBuilder.AddColumn<byte>(
                name: "OldStatus",
                table: "OldBids",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Bids",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldStatus",
                table: "OldBids");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bids");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Bids",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
