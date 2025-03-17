using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tracker.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false),
                    StatusId = table.Column<byte>(type: "INTEGER", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "AppliedDate", "CompanyName", "Position", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 2, 12, 43, 44, 586, DateTimeKind.Local).AddTicks(2832), "Bulk Tea Importers", "Tea Lady", (byte)1 },
                    { 2, new DateTime(2025, 3, 2, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(6989), "Coca Cola NZ", "Taste Tester", (byte)1 },
                    { 3, new DateTime(2025, 3, 3, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7003), "Griffens Food Company", "Packaging Assistents Assistent", (byte)1 },
                    { 4, new DateTime(2025, 3, 6, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7007), "Sausage Roles R Us", "Personal Assistant", (byte)3 },
                    { 5, new DateTime(2025, 3, 6, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7008), "Sausage Roles R Us", "Sales Manager", (byte)1 },
                    { 6, new DateTime(2025, 3, 6, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7012), "Aunt Megs", "Gossip", (byte)1 },
                    { 7, new DateTime(2025, 3, 7, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7014), "Kings Water", "Plumber", (byte)1 },
                    { 8, new DateTime(2025, 3, 7, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7016), "Ashphalts Under Us", "Heavy Machinery Operator", (byte)2 },
                    { 9, new DateTime(2025, 3, 8, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7018), "Driver Ed", "Driving Instructor", (byte)1 },
                    { 10, new DateTime(2025, 3, 9, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7020), "Customs", "Drugs Detection Dog", (byte)1 },
                    { 11, new DateTime(2025, 3, 10, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7022), "Shipping NZ", "Captain First Class", (byte)1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");
        }
    }
}
