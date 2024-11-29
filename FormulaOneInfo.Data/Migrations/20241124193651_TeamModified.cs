using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOneInfo.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeamModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartedDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Teams",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "CreatedDate", "ModifiedDate", "StartedDate", "Thumbnail" },
                values: new object[] { new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(7470), new DateTime(2024, 11, 24, 22, 36, 51, 421, DateTimeKind.Local).AddTicks(7470), new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "default.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartedDate",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Teams");

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
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(3229), new DateTime(2024, 11, 24, 17, 43, 55, 336, DateTimeKind.Local).AddTicks(3230) });

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
    }
}
