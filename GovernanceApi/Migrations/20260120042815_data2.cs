using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovernanceApi.Migrations
{
    /// <inheritdoc />
    public partial class data2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CalculatedDate",
                table: "VendorPerformances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "FinalScore",
                table: "VendorPerformances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Penalty",
                table: "VendorPerformances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VendorRating",
                table: "VendorPerformances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Severity",
                table: "NonComplianceLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculatedDate",
                table: "VendorPerformances");

            migrationBuilder.DropColumn(
                name: "FinalScore",
                table: "VendorPerformances");

            migrationBuilder.DropColumn(
                name: "Penalty",
                table: "VendorPerformances");

            migrationBuilder.DropColumn(
                name: "VendorRating",
                table: "VendorPerformances");

            migrationBuilder.DropColumn(
                name: "Severity",
                table: "NonComplianceLogs");
        }
    }
}
