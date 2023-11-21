using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mappedtbltoentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Entities_EntityName",
                table: "Features");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.AlterColumn<byte>(
                name: "ApprovalStatus",
                table: "Features",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "EntityTbl",
                columns: table => new
                {
                    EntityName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTbl", x => x.EntityName);
                });

            migrationBuilder.InsertData(
                table: "EntityTbl",
                columns: new[] { "EntityName", "Description" },
                values: new object[,]
                {
                    { "Character", "This character entity contains features for Character data " },
                    { "Driver", "This driver entity contains features for driver data" },
                    { "Stock", "This Stock entity contains features for Stock data" }
                });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 1,
                columns: new[] { "ApprovalStatus", "CreatedAt" },
                values: new object[] { (byte)0, new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2738) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 2,
                columns: new[] { "ApprovalStatus", "CreatedAt" },
                values: new object[] { (byte)0, new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2752) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 3,
                columns: new[] { "ApprovalStatus", "CreatedAt" },
                values: new object[] { (byte)0, new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2754) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 4,
                columns: new[] { "ApprovalStatus", "CreatedAt" },
                values: new object[] { (byte)0, new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2797) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 5,
                columns: new[] { "ApprovalStatus", "CreatedAt" },
                values: new object[] { (byte)0, new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2799) });

            migrationBuilder.AddForeignKey(
                name: "FK_Features_EntityTbl_EntityName",
                table: "Features",
                column: "EntityName",
                principalTable: "EntityTbl",
                principalColumn: "EntityName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_EntityTbl_EntityName",
                table: "Features");

            migrationBuilder.DropTable(
                name: "EntityTbl");

            migrationBuilder.AlterColumn<bool>(
                name: "ApprovalStatus",
                table: "Features",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

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

            migrationBuilder.InsertData(
                table: "Entities",
                columns: new[] { "EntityName", "Description" },
                values: new object[,]
                {
                    { "Character", "This character entity contains features for Character data " },
                    { "Driver", "This driver entity contains features for driver data" },
                    { "Stock", "This Stock entity contains features for Stock data" }
                });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 1,
                columns: new[] { "ApprovalStatus", "CreatedAt" },
                values: new object[] { false, new DateTime(2023, 11, 16, 14, 37, 19, 337, DateTimeKind.Local).AddTicks(7392) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 2,
                columns: new[] { "ApprovalStatus", "CreatedAt" },
                values: new object[] { false, new DateTime(2023, 11, 16, 14, 37, 19, 337, DateTimeKind.Local).AddTicks(7437) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 3,
                columns: new[] { "ApprovalStatus", "CreatedAt" },
                values: new object[] { false, new DateTime(2023, 11, 16, 14, 37, 19, 337, DateTimeKind.Local).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 4,
                columns: new[] { "ApprovalStatus", "CreatedAt" },
                values: new object[] { false, new DateTime(2023, 11, 16, 14, 37, 19, 337, DateTimeKind.Local).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 5,
                columns: new[] { "ApprovalStatus", "CreatedAt" },
                values: new object[] { false, new DateTime(2023, 11, 16, 14, 37, 19, 337, DateTimeKind.Local).AddTicks(7442) });

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Entities_EntityName",
                table: "Features",
                column: "EntityName",
                principalTable: "Entities",
                principalColumn: "EntityName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
