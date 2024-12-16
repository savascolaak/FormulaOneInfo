using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOneInfo.Data.Migrations
{
    /// <inheritdoc />
    public partial class PilotTableModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nationality",
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
                values: new object[] { new DateTime(2024, 12, 16, 22, 15, 8, 481, DateTimeKind.Local).AddTicks(1283), new DateTime(2024, 12, 16, 22, 15, 8, 481, DateTimeKind.Local).AddTicks(1284) });

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "Nationality" },
                values: new object[] { new DateTime(2024, 12, 16, 22, 15, 8, 481, DateTimeKind.Local).AddTicks(2060), new DateTime(2024, 12, 16, 22, 15, 8, 481, DateTimeKind.Local).AddTicks(2061), "UK" });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 16, 22, 15, 8, 481, DateTimeKind.Local).AddTicks(3747), new DateTime(2024, 12, 16, 22, 15, 8, 481, DateTimeKind.Local).AddTicks(3748) });

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 16, 22, 15, 8, 481, DateTimeKind.Local).AddTicks(4299), new DateTime(2024, 12, 16, 22, 15, 8, 481, DateTimeKind.Local).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 16, 22, 15, 8, 481, DateTimeKind.Local).AddTicks(4782), new DateTime(2024, 12, 16, 22, 15, 8, 481, DateTimeKind.Local).AddTicks(4783) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Pilots");

            migrationBuilder.UpdateData(
                table: "GrandPrixes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(2797), new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(2798) });

            migrationBuilder.UpdateData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(3633), new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(3633) });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(5426), new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(5426) });

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(6801), new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(6801) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(7470), new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(7470) });
        }
    }
}
