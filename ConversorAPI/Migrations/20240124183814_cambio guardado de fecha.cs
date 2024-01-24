using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversorAPI.Migrations
{
    /// <inheritdoc />
    public partial class cambioguardadodefecha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 24, 14, 34, 14, 950, DateTimeKind.Local).AddTicks(7979));
        }
    }
}
