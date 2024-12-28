using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webprogramlama4.Migrations
{
    /// <inheritdoc />
    public partial class AdminSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 22, 30, 11, 490, DateTimeKind.Local).AddTicks(25));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 22, 28, 5, 663, DateTimeKind.Local).AddTicks(9163));
        }
    }
}
