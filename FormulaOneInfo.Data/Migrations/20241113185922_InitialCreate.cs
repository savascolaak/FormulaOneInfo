using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOneInfo.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrandPrixes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Track = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GrandPrixDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandPrixes_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    GrandPrixId = table.Column<int>(type: "int", nullable: false),
                    PilotId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_GrandPrixes_GrandPrixId",
                        column: x => x.GrandPrixId,
                        principalTable: "GrandPrixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "CreatedDate", "DateOfBirth", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Note", "Thumbnail" },
                values: new object[] { 1, new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(7845), new DateTime(1985, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(7846), "Lewis Hamilton", "Lewis Hamilton İngiliz Pilot", "Default.jpg" });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "CreatedDate", "EndDate", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Note", "StartedDate" },
                values: new object[] { 1, new DateTime(2024, 11, 13, 21, 59, 22, 349, DateTimeKind.Local).AddTicks(104), new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2024, 11, 13, 21, 59, 22, 349, DateTimeKind.Local).AddTicks(105), "Formula 1 2024 Sezonu", "Formula 1 2024 Sezonu", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Note" },
                values: new object[] { 1, new DateTime(2024, 11, 13, 21, 59, 22, 349, DateTimeKind.Local).AddTicks(559), true, false, new DateTime(2024, 11, 13, 21, 59, 22, 349, DateTimeKind.Local).AddTicks(559), "Mercedes-Amg Petronas", "Formula 1 Mercedes Team" });

            migrationBuilder.InsertData(
                table: "GrandPrixes",
                columns: new[] { "Id", "City", "Country", "CreatedDate", "GrandPrixDate", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Note", "SeasonId", "Track" },
                values: new object[] { 1, "Bahreyn", "Birleşik Arap Emirlikleri", new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(7143), new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(7144), "Formula 2024 Bahreyn GP", "Formula 1 2024 Bahreyn GP", 1, "Sakhir" });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "Id", "CreatedDate", "GrandPrixId", "IsActive", "IsDeleted", "ModifiedDate", "Note", "Order", "PilotId", "Points", "TeamId" },
                values: new object[] { 1, new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(9564), 1, true, false, new DateTime(2024, 11, 13, 21, 59, 22, 348, DateTimeKind.Local).AddTicks(9565), "Results", 7, 1, 6, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixes_SeasonId",
                table: "GrandPrixes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_GrandPrixId",
                table: "Results",
                column: "GrandPrixId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_PilotId",
                table: "Results",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_TeamId",
                table: "Results",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "GrandPrixes");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Seasons");
        }
    }
}
