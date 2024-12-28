using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webprogramlama4.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "Role", "Username" },
                values: new object[] { 1, new DateTime(2024, 12, 28, 22, 28, 5, 663, DateTimeKind.Local).AddTicks(9163), "admin@example.com", "sau", "Admin", "G211210041@sakarya.edu.tr" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
