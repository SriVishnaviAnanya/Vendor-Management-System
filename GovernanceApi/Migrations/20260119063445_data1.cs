using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovernanceApi.Migrations
{
    /// <inheritdoc />
    public partial class data1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplianceChecklists",
                columns: table => new
                {
                    ComplianceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    NDASigned = table.Column<bool>(type: "bit", nullable: false),
                    CertificationsValid = table.Column<bool>(type: "bit", nullable: false),
                    RegulatoryCompliant = table.Column<bool>(type: "bit", nullable: false),
                    ComplianceScore = table.Column<int>(type: "int", nullable: false),
                    ComplianceStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceChecklists", x => x.ComplianceId);
                });

            migrationBuilder.CreateTable(
                name: "NonComplianceLogs",
                columns: table => new
                {
                    NonComplianceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Escalated = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonComplianceLogs", x => x.NonComplianceId);
                });

            migrationBuilder.CreateTable(
                name: "VendorPerformances",
                columns: table => new
                {
                    PerformanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    DeliveryQuality = table.Column<int>(type: "int", nullable: false),
                    SLAAdherence = table.Column<int>(type: "int", nullable: false),
                    SLARemarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ComplianceScore = table.Column<int>(type: "int", nullable: false),
                    IssueCount = table.Column<int>(type: "int", nullable: false),
                    FinalRating = table.Column<int>(type: "int", nullable: false),
                    SLARatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorPerformances", x => x.PerformanceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceChecklists_VendorId",
                table: "ComplianceChecklists",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_NonComplianceLogs_ContractId",
                table: "NonComplianceLogs",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_NonComplianceLogs_VendorId",
                table: "NonComplianceLogs",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorPerformances_VendorId",
                table: "VendorPerformances",
                column: "VendorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplianceChecklists");

            migrationBuilder.DropTable(
                name: "NonComplianceLogs");

            migrationBuilder.DropTable(
                name: "VendorPerformances");
        }
    }
}
