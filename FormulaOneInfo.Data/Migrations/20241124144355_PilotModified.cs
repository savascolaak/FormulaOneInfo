using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOneInfo.Data.Migrations
{
    /// <inheritdoc />
    public partial class PilotModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pilots",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Results",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Pilots",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "GrandPrixes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(2455), new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(2455) });

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "FirstName", "LastName", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(3229), "Lewis", "Hamilton", new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(5044), new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(5045) });

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(5583), new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(5584) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(7069), new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(7070) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Pilots");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Pilots",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Results",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "GrandPrixes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(7143), new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(7144) });

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(7845), new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(7846), "Lewis Hamilton" });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(9564), new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(9565) });

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 13, 21, 59, 22, 349, DateTimeKind.Local).AddTicks(104), new DateTime(2024, 11, 13, 21, 59, 22, 349, DateTimeKind.Local).AddTicks(105) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 13, 21, 59, 22, 349, DateTimeKind.Local).AddTicks(559), new DateTime(2024, 11, 13, 21, 59, 22, 349, DateTimeKind.Local).AddTicks(559) });
        }
    }
}
