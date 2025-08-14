using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Freelancing.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "IsActive", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Full-stack web development using ASP.NET Core, React, and modern technologies.", null, true, "Custom Web Application", 500.00m, "Web Development" },
                    { 2, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Complete e-commerce solutions with payment integration and inventory management.", null, true, "E-commerce Store", 1200.00m, "E-commerce" },
                    { 3, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Cross-platform mobile apps for iOS and Android using modern frameworks.", null, true, "Mobile Application", 800.00m, "Mobile Development" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 17, 24, 22, 562, DateTimeKind.Local).AddTicks(1734));
        }
    }
}
