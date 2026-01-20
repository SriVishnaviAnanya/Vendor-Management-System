using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovernanceApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFinalRatingColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalRating",
                table: "VendorPerformances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinalRating",
                table: "VendorPerformances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
