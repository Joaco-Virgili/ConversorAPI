using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversorAPI.Migrations
{
    /// <inheritdoc />
    public partial class Cambioencurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Currencys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 24, 1, 11, 42, 882, DateTimeKind.Local).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "Currencys",
                keyColumn: "Id",
                keyValue: 1,
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Currencys",
                keyColumn: "Id",
                keyValue: 2,
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Currencys",
                keyColumn: "Id",
                keyValue: 3,
                column: "State",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Currencys");

            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 22, 15, 49, 31, 231, DateTimeKind.Local).AddTicks(635));
        }
    }
}
