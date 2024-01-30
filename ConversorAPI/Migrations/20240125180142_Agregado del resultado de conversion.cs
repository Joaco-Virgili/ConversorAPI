using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversorAPI.Migrations
{
    /// <inheritdoc />
    public partial class Agregadodelresultadodeconversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Result",
                table: "CurrencyConversions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "Date", "FromCurrencyId", "Result" },
                values: new object[] { 100.0, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), 2, 109.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "CurrencyConversions");

            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "Date", "FromCurrencyId" },
                values: new object[] { 10.0, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Local), 3 });
        }
    }
}
