using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversorAPI.Migrations
{
    /// <inheritdoc />
    public partial class Cambioanotebook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 22, 15, 49, 31, 231, DateTimeKind.Local).AddTicks(635));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 19, 16, 23, 19, 801, DateTimeKind.Local).AddTicks(4774));
        }
    }
}
