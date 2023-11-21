using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Creationsandseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    EntityName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.EntityName);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    FeatureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureDataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalStatus = table.Column<bool>(type: "bit", nullable: false),
                    AdminComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeatureID);
                    table.ForeignKey(
                        name: "FK_Features_Entities_EntityName",
                        column: x => x.EntityName,
                        principalTable: "Entities",
                        principalColumn: "EntityName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Entities",
                columns: new[] { "EntityName", "Description" },
                values: new object[,]
                {
                    { "Character", "This character entity contains features for Character data " },
                    { "Driver", "This driver entity contains features for driver data" },
                    { "Stock", "This Stock entity contains features for Stock data" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "FeatureID", "AdminComments", "ApprovalStatus", "CreatedAt", "EntityName", "FeatureDataType", "FeatureName", "UserID", "Value" },
                values: new object[,]
                {
                    { 1, "good", false, new DateTime(2023, 11, 16, 14, 37, 19, 337, DateTimeKind.Local).AddTicks(7392), "Driver", "double", "Rating", 0, "4.8" },
                    { 2, "good", false, new DateTime(2023, 11, 16, 14, 37, 19, 337, DateTimeKind.Local).AddTicks(7437), "Driver", "int", "TripsToday", 0, "12" },
                    { 3, "good", false, new DateTime(2023, 11, 16, 14, 37, 19, 337, DateTimeKind.Local).AddTicks(7439), "Character", "double", "Height", 0, "5.2" },
                    { 4, "good", false, new DateTime(2023, 11, 16, 14, 37, 19, 337, DateTimeKind.Local).AddTicks(7440), "Character", "double", "Width", 0, "12.6" },
                    { 5, "good", false, new DateTime(2023, 11, 16, 14, 37, 19, 337, DateTimeKind.Local).AddTicks(7442), "Stock", "double", "Price", 0, "2444.12" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_EntityName",
                table: "Features",
                column: "EntityName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
